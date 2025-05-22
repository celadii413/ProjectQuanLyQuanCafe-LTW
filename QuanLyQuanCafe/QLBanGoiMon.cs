using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;

namespace QuanLyQuanCafe
{
    public partial class Form1 : Form
    {
        private QuanCafeDB db = new QuanCafeDB();
        private string maBanHienTai = "";
        private string maHoaDonHienTai = "";
        private DateTime gioVao;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e){}
        private void dgvHoaDon_CellContentClick(object sender, EventArgs e){}
        
        private void txtTongTien_TextChanged(object sender, EventArgs e){}

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhSachBan();
            LoadMenuMon();
            KhoiTaoGridView();

            numSoLuong.Minimum = 1;
            numSoLuong.Maximum = 100;
        }

        private void LoadDanhSachBan()
        {
            flowLayoutPanel1.Controls.Clear();
            comboChuyenBan.Items.Clear();

            foreach (var ban in db.Bans)
            {
                Button btn = new Button();
                btn.Text = $"Bàn {ban.MaBan}";
                btn.Width = 80;
                btn.Height = 50;
                btn.Tag = ban.MaBan;
                btn.Margin = new Padding(5);
                btn.BackColor = (ban.TrangThaiB.Trim() == "Có người") ? Color.Gold : Color.LightGray;
                btn.Click += Ban_Click;

                flowLayoutPanel1.Controls.Add(btn);
                comboChuyenBan.Items.Add(ban.MaBan);
            }
        }

        private void LoadMenuMon()
        {
            cboMonAn.DataSource = db.MenuThucDons.ToList();
            cboMonAn.DisplayMember = "TenMon";
            cboMonAn.ValueMember = "MaMon";
        }

        private void KhoiTaoGridView()
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("TenMon", "Tên món");
            dgvHoaDon.Columns.Add("SoLuong", "Số lượng");
            dgvHoaDon.Columns.Add("DonGia", "Đơn giá");
            dgvHoaDon.Columns.Add("ThanhTien", "Thành tiền");
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            maBanHienTai = btn.Tag.ToString();
            gioVao = DateTime.Now;

            // Kiểm tra nếu bàn chưa có hóa đơn, tạo mới
            var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaBan == maBanHienTai && h.TrangThaiHD == "Chưa thanh toán");
            if (hoaDon == null)
            {
                maHoaDonHienTai = "HD" + DateTime.Now.Ticks.ToString();
                hoaDon = new QuanLyQuanCafe.Models.HoaDon
                {
                    MaHD = maHoaDonHienTai,
                    MaBan = maBanHienTai,
                    MaNV = "NV001",
                    NgayLap = DateTime.Today,
                    GioVaoHD = gioVao,
                    GioRaHD = gioVao,
                    TongTien = 0,
                    TrangThaiHD = "Chưa thanh toán",
                    GhiChuHD = ""
                };

                db.HoaDons.Add(hoaDon);

                // Cập nhật trạng thái bàn
                var ban = db.Bans.FirstOrDefault(b => b.MaBan == maBanHienTai);
                if (ban != null) ban.TrangThaiB = "Có người";
                db.SaveChanges();
            }
            else
            {
                maHoaDonHienTai = hoaDon.MaHD;
            }

            dgvHoaDon.Rows.Clear();
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            var chiTiets = db.ChiTietHoaDons
                .Where(c => c.MaHD == maHoaDonHienTai)
                .ToList();

            foreach (var item in chiTiets)
            {
                var mon = db.MenuThucDons.Find(item.MaMon);
                dgvHoaDon.Rows.Add(mon.TenMon, item.SoLuong, item.DonGia, item.ThanhTien);
            }

            CapNhatTongTien();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maHoaDonHienTai))
            {
                MessageBox.Show("Vui lòng chọn bàn trước.");
                return;
            }

            var mon = (MenuThucDon)cboMonAn.SelectedItem;
            int soLuong = (int)numSoLuong.Value;
            decimal thanhTien = mon.DonGia * soLuong;

            // Thêm vào CSDL
            var ct = db.ChiTietHoaDons.FirstOrDefault(c => c.MaHD == maHoaDonHienTai && c.MaMon == mon.MaMon);
            if (ct == null)
            {
                ct = new ChiTietHoaDon
                {
                    MaHD = maHoaDonHienTai,
                    MaMon = mon.MaMon,
                    SoLuong = soLuong,
                    DonGia = mon.DonGia,
                    ThanhTien = thanhTien
                };
                db.ChiTietHoaDons.Add(ct);
            }
            else
            {
                ct.SoLuong += soLuong;
                ct.ThanhTien = ct.SoLuong * ct.DonGia;
            }

            db.SaveChanges();
            LoadChiTietHoaDon();
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
            if (string.IsNullOrEmpty(maHoaDonHienTai)) return;

            var hoaDon = db.HoaDons.Find(maHoaDonHienTai);
            if (hoaDon == null) return;

            hoaDon.GioRaHD = DateTime.Now;
            hoaDon.TrangThaiHD = "Đã thanh toán";
            hoaDon.TongTien = db.ChiTietHoaDons
            .Where(c => c.MaHD == maHoaDonHienTai)
            .Sum(c => (decimal?)c.ThanhTien) ?? 0;


            // Bàn trở về trạng thái trống
            var ban = db.Bans.Find(hoaDon.MaBan);
            if (ban != null) ban.TrangThaiB = "Trống";

            db.SaveChanges();
            MessageBox.Show("Thanh toán thành công!");

            dgvHoaDon.Rows.Clear();
            txtTongTien.Text = "";
            LoadDanhSachBan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                string tenMon = dgvHoaDon.CurrentRow.Cells["TenMon"].Value.ToString();
                var mon = db.MenuThucDons.FirstOrDefault(m => m.TenMon == tenMon);

                var chiTiet = db.ChiTietHoaDons.FirstOrDefault(c => c.MaHD == maHoaDonHienTai && c.MaMon == mon.MaMon);
                if (chiTiet != null)
                {
                    db.ChiTietHoaDons.Remove(chiTiet);
                    db.SaveChanges();
                    LoadChiTietHoaDon();
                }
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (comboChuyenBan.SelectedItem == null) return;
            string banMoi = comboChuyenBan.SelectedItem.ToString();

            var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHD == maHoaDonHienTai && h.TrangThaiHD == "Chưa thanh toán");
            if (hoaDon != null)
            {
                hoaDon.MaBan = banMoi;

                var banCu = db.Bans.Find(maBanHienTai);
                if (banCu != null) banCu.TrangThaiB = "Trống";

                var banMoiEntity = db.Bans.Find(banMoi);
                if (banMoiEntity != null) banMoiEntity.TrangThaiB = "Có người";

                db.SaveChanges();
                LoadDanhSachBan();
                MessageBox.Show($"Đã chuyển bàn {maBanHienTai} → {banMoi}");
                maBanHienTai = banMoi;
            }
        }
    }
}
