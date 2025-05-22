using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class DoanhThu : Form
    {
        private List<ChiTietDoanhThu> danhSachChiTiet = new List<ChiTietDoanhThu>();
        public DoanhThu()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvChiTietDoanhThu.AutoGenerateColumns = false;
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            dgvChiTietDoanhThu.DataSource = null;
            dgvChiTietDoanhThu.DataSource = danhSachChiTiet;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuong = (int)numericUpDown1.Value;
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal thanhTien = soLuong * donGia;
                txtThanhTien.Text = thanhTien.ToString("0.00");
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng đơn giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietDoanhThu chiTiet = new ChiTietDoanhThu()
                {
                    MaChiTiet = txtMaChiTiet.Text,
                    Ngay = dateTimePicker1.Value,
                    MaMon = txtMaMon.Text,
                    SoLuong = (int)numericUpDown1.Value,
                    DonGia = decimal.Parse(txtDonGia.Text),
                    GhiChu = textBox1.Text
                };
                danhSachChiTiet.Add(chiTiet);
                HienThiDanhSach();
                ClearInputFields();
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var chiTiet = danhSachChiTiet.FirstOrDefault(c => c.MaChiTiet == txtMaChiTiet.Text);
            if (chiTiet != null)
            {
                chiTiet.Ngay = dateTimePicker1.Value;
                chiTiet.MaMon = txtMaMon.Text;
                chiTiet.SoLuong = (int)numericUpDown1.Value;
                chiTiet.DonGia = decimal.Parse(txtDonGia.Text);
                chiTiet.GhiChu = textBox1.Text;
                HienThiDanhSach();
                ClearInputFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var chiTiet = danhSachChiTiet.FirstOrDefault(c => c.MaChiTiet == txtMaChiTiet.Text);
            if (chiTiet != null)
            {
                danhSachChiTiet.Remove(chiTiet);
                HienThiDanhSach();
                ClearInputFields();
            }
        }

        private void dgvChiTietDoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dong = dgvChiTietDoanhThu.Rows[e.RowIndex].DataBoundItem as ChiTietDoanhThu;
                txtMaChiTiet.Text = dong.MaChiTiet;
                dateTimePicker1.Value = dong.Ngay;
                txtMaMon.Text = dong.MaMon;
                numericUpDown1.Value = dong.SoLuong;
                txtDonGia.Text = dong.DonGia.ToString();
                txtThanhTien.Text = dong.ThanhTien.ToString("0.00");
                textBox1.Text = dong.GhiChu;
            }
        }

        private void ClearInputFields()
        {
            txtMaChiTiet.Clear();
            txtMaMon.Clear();
            numericUpDown1.Value = 0;
            txtDonGia.Clear();
            txtThanhTien.Clear();
            textBox1.Clear();
        }
    }
}
