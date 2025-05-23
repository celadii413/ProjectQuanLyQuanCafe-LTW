using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=VIV;Initial Catalog=ProjectQLQuanCafe;Integrated Security=True;";
        string maBanHienTai = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhSachMonAn();
            LoadBanAn();
        }

        private void LoadDanhSachMonAn()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaMon, TenMon FROM MenuThucDon", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu món ăn trong MenuThucDon.");
                        return;
                    }

                    cboMonAn.DataSource = dt;
                    cboMonAn.DisplayMember = "TenMon";
                    cboMonAn.ValueMember = "MaMon";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải món ăn: " + ex.Message);
            }
        }

        private void LoadBanAn()
        {
            flowLayoutPanel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaBan, TenBan, TrangThaiB FROM Ban", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Button btn = new Button();
                    btn.Width = 100;
                    btn.Height = 75;
                    btn.Text = reader["TenBan"].ToString();
                    btn.Tag = reader["MaBan"].ToString();

                    string trangThai = reader["TrangThaiB"].ToString();
                    if (trangThai == "Trống")
                        btn.BackColor = Color.LightGreen;
                    else if (trangThai == "Đang dùng")
                        btn.BackColor = Color.Orange;
                    else
                        btn.BackColor = Color.LightGray;

                    btn.Click += Btn_Click;

                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e){}
        private void dgvHoaDon_CellContentClick(object sender, EventArgs e){}
        
        private void txtTongTien_TextChanged(object sender, EventArgs e){}

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            maBanHienTai = btn.Tag.ToString();
            LoadHoaDonTheoBan(maBanHienTai);
        }
        private void LoadHoaDonTheoBan(string maBan)
        {
            dgvHoaDon.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                SELECT td.TenMon, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                FROM HoaDon hd
                JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                JOIN MenuThucDon td ON ct.MaMon = td.MaMon
                WHERE hd.MaBan = @MaBan AND hd.TrangThaiHD = N'Đang xử lý'", conn);

                cmd.Parameters.AddWithValue("@MaBan", maBan);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvHoaDon.Rows.Add(reader["TenMon"], reader["SoLuong"], reader["DonGia"], reader["ThanhTien"]);
                }
            }

            TinhTongTien();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanHienTai))
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            string maMon = cboMonAn.SelectedValue.ToString();
            int soLuong = (int)numSoLuong.Value;

            decimal donGia = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DonGia FROM MenuThucDon WHERE MaMon = @MaMon", conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                donGia = (decimal)cmd.ExecuteScalar();

                // Tạo hóa đơn nếu chưa có
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE MaBan = @MaBan AND TrangThaiHD = N'Đang xử lý'", conn);
                check.Parameters.AddWithValue("@MaBan", maBanHienTai);
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells[3].Value != null)
                    tongTien += Convert.ToDecimal(row.Cells[3].Value);
            }

            decimal giamGia = (decimal)numGiamGia.Value / 100;
            tongTien = tongTien - (tongTien * giamGia);
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }

            decimal giam = tong * numGiamGia.Value / 100;
            txtTongTien.Text = (tong - giam).ToString("N0") + " đ";
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanHienTai))
            {
                MessageBox.Show("Chọn bàn trước khi thanh toán.");
                return;
            }

            decimal tongTien = Convert.ToDecimal(txtTongTien.Text.Replace(",", ""));

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET TongTien = @TongTien, GioRaHD = GETDATE(), TrangThaiHD = N'Đã thanh toán' WHERE MaBan = @MaBan AND TrangThaiHD = N'Đang xử lý'", conn);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaBan", maBanHienTai);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thanh toán thành công!");
            LoadBanAn();
            dgvHoaDon.Rows.Clear();
            txtTongTien.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            string maBanMoi = comboChuyenBan.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(maBanHienTai) || string.IsNullOrEmpty(maBanMoi))
            {
                MessageBox.Show("Chọn bàn cần chuyển và bàn đích.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET MaBan = @BanMoi WHERE MaBan = @BanCu AND TrangThaiHD = N'Đang xử lý'", conn);
                cmd.Parameters.AddWithValue("@BanCu", maBanHienTai);
                cmd.Parameters.AddWithValue("@BanMoi", maBanMoi);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Chuyển bàn thành công!");
            LoadBanAn();
        }
    }
}
