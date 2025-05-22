using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Form1 : Form
    {
        private QuanCafeDB db = new QuanCafeDB();
        private string maHoaDonHienTai = "";
        private string maBanHienTai = "";
        private DateTime ngayBanHienTai = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhSachBan(); 
            LoadMenuThucDon(); 
            KhoiTaoDataGridView(); 

            numSoLuong.Minimum = 1;
            numSoLuong.Maximum = 100;
            txtTongTien.ReadOnly = true; 
            CapNhatTongTien(); 
        }

        private void KhoiTaoDataGridView()
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("MaMon", "Mã món"); 
            dgvHoaDon.Columns["MaMon"].Visible = false; 

            dgvHoaDon.Columns.Add("TenMon", "Tên món"); 
            dgvHoaDon.Columns.Add("SoLuong", "Số lượng"); 
            dgvHoaDon.Columns.Add("DonGia", "Đơn giá"); 
            dgvHoaDon.Columns.Add("ThanhTien", "Thành tiền"); 

            dgvHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        public static class TrangThaiBan
        {
            public const string CoNguoi = "Có người";
            public const string Trong = "Trống";
        }

        private void LoadDanhSachBan()
        {
            flowLayoutPanel1.Controls.Clear();

            var bans = db.Bans.ToList();
            foreach (var ban in bans)
            {
                Button btn = new Button();
                bool coNguoi = ban.TrangThaiB.Trim() == TrangThaiBan.CoNguoi;

                btn.Text = $"Bàn {ban.MaBan}\n{(coNguoi ? TrangThaiBan.CoNguoi : TrangThaiBan.Trong)}";
                btn.BackColor = coNguoi ? Color.Gold : Color.LightYellow; 
                btn.Tag = ban.MaBan; 
                btn.Width = 80;
                btn.Height = 50;
                btn.Margin = new Padding(5);
                btn.Click += Ban_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }

            comboChuyenBan.Items.Clear();
            comboChuyenBan.Items.AddRange(db.Bans.Select(b => b.MaBan).ToArray()); 
            if (comboChuyenBan.Items.Count > 0)
            {
                comboChuyenBan.SelectedIndex = -1; 
            }
        }

        private void LoadMenuThucDon()
        {
            cboMonAn.DataSource = db.MenuThucDons.ToList();
            cboMonAn.DisplayMember = "TenMon";
            cboMonAn.ValueMember = "MaMon";
            if (cboMonAn.Items.Count > 0)
            {
                cboMonAn.SelectedIndex = 0; 
            }
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string newMaBanHienTai = btn.Tag.ToString();

            // Nếu click lại vào bàn đang chọn, không làm gì
            if (maBanHienTai == newMaBanHienTai && !string.IsNullOrEmpty(maHoaDonHienTai))
            {
                // Có thể refresh hoặc thông báo đã chọn
                MessageBox.Show($"Bàn {maBanHienTai} đã được chọn và đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            maBanHienTai = newMaBanHienTai;
            lblTenBanDaChon.Text = $"Bàn {maBanHienTai}"; // Hiển thị bàn đang chọn
            ngayBanHienTai = DateTime.Now;

            // Kiểm tra xem bàn này đã có hóa đơn "Chưa thanh toán" chưa
            var existingHoaDon = db.HoaDons
                                    .Include(hd => hd.ChiTietHoaDons.Select(ct => ct.MenuThucDon)) // Load eager ChiTietHoaDon và MenuThucDon
                                    .FirstOrDefault(h => h.MaBan == maBanHienTai && h.TrangThaiHD == "Chưa thanh toán");

            if (existingHoaDon != null)
            {
                maHoaDonHienTai = existingHoaDon.MaHD;
                ngayBanHienTai = existingHoaDon.NgayLap; // Giữ ngày lập hóa đơn cũ
                // MessageBox.Show($"Đã chọn bàn {maBanHienTai}. Đang tải hóa đơn {maHoaDonHienTai} đã tồn tại.");

                dgvHoaDon.Rows.Clear();
                foreach (var ct in existingHoaDon.ChiTietHoaDons)
                {
                    dgvHoaDon.Rows.Add(ct.MaMon, ct.MenuThucDon.TenMon, ct.SoLuong, ct.DonGia, ct.ThanhTien);
                }
                CapNhatTongTien();
            }
            else
            {
                // Nếu chưa có hóa đơn, tạo mới
                maHoaDonHienTai = "HD" + DateTime.Now.Ticks.ToString(); // Mã hóa đơn duy nhất
                // MessageBox.Show($"Đã chọn bàn {maBanHienTai}. Tạo hóa đơn mới: {maHoaDonHienTai}");
                dgvHoaDon.Rows.Clear();
                txtTongTien.Text = "0 đ";
                numGiamGia.Value = 0;

                // Khi bàn trống được chọn, cập nhật trạng thái bàn thành "Có người" ngay lập tức
                var ban = db.Bans.FirstOrDefault(b => b.MaBan == maBanHienTai);
                if (ban != null && ban.TrangThaiB.Trim() == TrangThaiBan.Trong)
                {
                    ban.TrangThaiB = TrangThaiBan.CoNguoi;
                    try
                    {
                        db.SaveChanges();
                        LoadDanhSachBan(); // Cập nhật màu sắc bàn
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật trạng thái bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanHienTai))
            {
                MessageBox.Show("Vui lòng chọn một bàn trước khi thêm món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedMon = (MenuThucDon)cboMonAn.SelectedItem;
            if (selectedMon == null)
            {
                MessageBox.Show("Vui lòng chọn một món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)numSoLuong.Value;
            decimal donGia = selectedMon.DonGia;
            decimal thanhTien = soLuong * donGia;

            // Kiểm tra xem món đã có trong dgvHoaDon chưa
            bool monDaCo = false;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["MaMon"].Value != null && row.Cells["MaMon"].Value.ToString() == selectedMon.MaMon)
                {
                    // Nếu món đã có, cập nhật số lượng và thành tiền
                    row.Cells["SoLuong"].Value = Convert.ToInt32(row.Cells["SoLuong"].Value) + soLuong;
                    row.Cells["ThanhTien"].Value = Convert.ToDecimal(row.Cells["SoLuong"].Value) * Convert.ToDecimal(row.Cells["DonGia"].Value);
                    monDaCo = true;
                    break;
                }
            }

            if (!monDaCo)
            {
                // Nếu món chưa có, thêm dòng mới
                dgvHoaDon.Rows.Add(selectedMon.MaMon, selectedMon.TenMon, soLuong, donGia, thanhTien);
            }

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            decimal giam = tong * numGiamGia.Value / 100;
            txtTongTien.Text = (tong - giam).ToString("N0") + " đ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanHienTai) || dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và thêm món trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHoaDon.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Hóa đơn trống, không thể thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Xác nhận thanh toán cho bàn {maBanHienTai}? Tổng tiền: {txtTongTien.Text}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                return;
            }

            try
            {
                // Tìm hoặc tạo mới HoaDon
                var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHD == maHoaDonHienTai && h.TrangThaiHD == "Chưa thanh toán");
                bool isNewHoaDon = false;

                if (hoaDon == null)
                {
                    hoaDon = new Models.HoaDon
                    {
                        MaHD = maHoaDonHienTai,
                        MaBan = maBanHienTai,
                        MaNV = "NV001", // Cần lấy MaNV của nhân viên đang đăng nhập
                        NgayLap = ngayBanHienTai.Date,
                        GioVaoHD = ngayBanHienTai,
                        GioRaHD = DateTime.Now,
                        TrangThaiHD = "Đã thanh toán", // Đặt trạng thái đã thanh toán ngay
                        GhiChuHD = ""
                    };
                    db.HoaDons.Add(hoaDon);
                    isNewHoaDon = true;
                }
                else
                {
                    // Cập nhật thông tin hóa đơn hiện có
                    hoaDon.GioRaHD = DateTime.Now;
                    hoaDon.TrangThaiHD = "Đã thanh toán";
                }

                decimal tongTienThucTe = 0;
                List<ChiTietHoaDon> chiTietCanLuu = new List<ChiTietHoaDon>();

                // Xử lý ChiTietHoaDon
                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    if (row.IsNewRow) continue;

                    string maMon = row.Cells["MaMon"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value); // Lấy từ DataGridView

                    // Kiểm tra và cập nhật ChiTietHoaDon nếu đã tồn tại, hoặc thêm mới
                    var chiTietHienCo = db.ChiTietHoaDons.FirstOrDefault(ct => ct.MaHD == maHoaDonHienTai && ct.MaMon == maMon);

                    if (chiTietHienCo != null)
                    {
                        chiTietHienCo.SoLuong = soLuong;
                        chiTietHienCo.DonGia = donGia; // Đảm bảo đơn giá được cập nhật theo giá hiện tại nếu có thay đổi
                        chiTietHienCo.ThanhTien = thanhTien;
                        db.Entry(chiTietHienCo).State = EntityState.Modified;
                    }
                    else
                    {
                        // Thêm mới chi tiết hóa đơn
                        var chiTietMoi = new ChiTietHoaDon
                        {
                            MaHD = maHoaDonHienTai,
                            MaMon = maMon,
                            SoLuong = soLuong,
                            DonGia = donGia,
                            ThanhTien = thanhTien
                        };
                        db.ChiTietHoaDons.Add(chiTietMoi);
                    }
                    tongTienThucTe += thanhTien;
                }

                // Cập nhật TongTien sau khi đã tính toán từ các chi tiết hóa đơn
                hoaDon.TongTien = tongTienThucTe * (1 - (numGiamGia.Value / 100)); // Áp dụng giảm giá vào tổng tiền cuối cùng

                // Cập nhật trạng thái bàn thành "Trống" sau khi thanh toán
                var ban = db.Bans.FirstOrDefault(b => b.MaBan == maBanHienTai);
                if (ban != null)
                {
                    ban.TrangThaiB = TrangThaiBan.Trong; // Đặt trạng thái bàn về "Trống"
                }

                db.SaveChanges(); // Lưu tất cả thay đổi vào database

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form sau khi thanh toán
                dgvHoaDon.Rows.Clear();
                txtTongTien.Text = "0 đ";
                numGiamGia.Value = 0;
                maBanHienTai = ""; // Xóa bàn hiện tại
                maHoaDonHienTai = ""; // Xóa mã hóa đơn hiện tại
                lblTenBanDaChon.Text = "Chưa chọn bàn"; // Đặt lại tên bàn đã chọn

                LoadDanhSachBan(); // Cập nhật lại màu sắc bàn
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    sb.AppendLine($"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                    }
                }
                MessageBox.Show("Lỗi khi lưu database:\n" + sb.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraTrangThaiBan(string giaTri)
        {
            return giaTri == "Trống" || giaTri == "Có người";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                dgvHoaDon.Rows.RemoveAt(dgvHoaDon.CurrentRow.Index);
                CapNhatTongTien();
            }
            else
            {
                MessageBox.Show("Chưa có món nào được chọn!");
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTongTien_TextChanged(object sender, EventArgs e) { }

        private void btnThanhToanMaQR_Click(object sender, EventArgs e)
        {
            var qr = new MaQR();
            qr.ShowDialog();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanHienTai) || comboChuyenBan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn hiện tại và bàn muốn chuyển đến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string banMoi = comboChuyenBan.SelectedItem.ToString();

            if (maBanHienTai == banMoi)
            {
                MessageBox.Show("Không thể chuyển đến cùng một bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm hóa đơn hiện tại của bàn cũ (chưa thanh toán)
            var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaBan == maBanHienTai && h.TrangThaiHD == "Chưa thanh toán");

            if (hoaDon != null)
            {
                // Kiểm tra trạng thái bàn mới
                var banMoiObj = db.Bans.FirstOrDefault(b => b.MaBan == banMoi);
                if (banMoiObj != null && banMoiObj.TrangThaiB.Trim() == TrangThaiBan.CoNguoi)
                {
                    MessageBox.Show($"Bàn {banMoi} hiện đang có khách. Không thể chuyển bàn. Vui lòng gộp hóa đơn nếu cần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật hóa đơn sang bàn mới
                hoaDon.MaBan = banMoi;

                // Cập nhật trạng thái bàn cũ thành "Trống"
                var banCu = db.Bans.FirstOrDefault(b => b.MaBan == maBanHienTai);
                if (banCu != null)
                {
                    banCu.TrangThaiB = TrangThaiBan.Trong;
                }

                // Cập nhật trạng thái bàn mới thành "Có người"
                if (banMoiObj != null)
                {
                    banMoiObj.TrangThaiB = TrangThaiBan.CoNguoi;
                }

                try
                {
                    db.SaveChanges();
                    MessageBox.Show($"Đã chuyển hóa đơn từ bàn {maBanHienTai} sang bàn {banMoi} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại mã bàn hiện tại cho form
                    maBanHienTai = banMoi;
                    lblTenBanDaChon.Text = $"Bàn {maBanHienTai}";
                    LoadDanhSachBan(); // Tải lại danh sách bàn để cập nhật trạng thái trực quan

                    // Hiển thị hóa đơn của bàn mới sau khi chuyển
                    // Không cần tạo hóa đơn mới, chỉ cần load lại chi tiết hóa đơn từ DB
                    Ban_Click(null, null); // Giả lập click để load lại hóa đơn của bàn mới
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chuyển bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Bàn {maBanHienTai} không có hóa đơn nào đang hoạt động để chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
