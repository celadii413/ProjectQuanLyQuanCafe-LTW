using QuanLyQuanCafe.Models;
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
    public partial class HoaDon : Form
    {
        private QuanCafeDB db = new QuanCafeDB();
        private string currentMaHD = "";
        public HoaDon()
        {
            InitializeComponent();
            KhoiTaoDataGridView();
            SetControlState(false);
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            txtTongTienHoaDon.ReadOnly = true;
            txtKhachCanTra.ReadOnly = true;
        }
        private void KhoiTaoDataGridView()
        {
            dgvChiTietMonAn.Columns.Clear();
            dgvChiTietMonAn.Columns.Add("MaMon", "Mã Món");
            dgvChiTietMonAn.Columns["MaMon"].Visible = false; // Ẩn cột mã món

            dgvChiTietMonAn.Columns.Add("TenMon", "Tên món");
            dgvChiTietMonAn.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietMonAn.Columns.Add("DonGia", "Đơn giá");
            dgvChiTietMonAn.Columns.Add("ThanhTien", "Thành tiền");

            // Cho phép người dùng thêm/sửa trực tiếp trên DataGridView
            dgvChiTietMonAn.AllowUserToAddRows = true;
            dgvChiTietMonAn.AllowUserToDeleteRows = true;

            // Định dạng tiền tệ
            dgvChiTietMonAn.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietMonAn.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void LoadComboBoxes()
        {
            // Load ComboBox Nhân viên
            cboNhanVien.DataSource = db.NhanViens.ToList();
            cboNhanVien.DisplayMember = "HoTenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;

            // Load ComboBox Bàn số
            cboBanSo.DataSource = db.Bans.ToList();
            cboBanSo.DisplayMember = "MaBan"; // Hoặc TenBan nếu bạn có
            cboBanSo.ValueMember = "MaBan";
            cboBanSo.SelectedIndex = -1;

            // Load dữ liệu cho cột Tên món trong DataGridView (sử dụng DataGridViewComboBoxColumn)
            // Cần thêm cột ComboBox cho món ăn nếu muốn chọn từ menu
            // Hoặc đơn giản hơn là có 2 textbox/combobox cho phép chọn món và số lượng
            // Ở đây tôi giả định bạn sẽ nhập tên món và số lượng thủ công hoặc có cơ chế thêm món từ bên ngoài
            // Nếu muốn chọn món từ Combobox trong DGV, cần sửa lại KhoiTaoDataGridView
        }

        private void SetControlState(bool enable)
        {
            txtMaHoaDon.Enabled = false; // Mã hóa đơn thường chỉ đọc
            cboNhanVien.Enabled = enable;
            cboBanSo.Enabled = enable;
            dtpNgayBan.Enabled = enable;
            dgvChiTietMonAn.Enabled = enable;
            txtGiamGia.Enabled = enable;

            btnHoaDonMoi.Enabled = !enable;
            btnLuuHoaDon.Enabled = enable;
            btnThanhToanVaIn.Enabled = enable; // Có thể chỉ enable khi có dữ liệu
            btnHuyHoaDon.Enabled = enable;
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChiTietMonAn.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            decimal giamGiaValue = 0;
            if (decimal.TryParse(txtGiamGia.Text, out giamGiaValue))
            {
                // Giả định giảm giá là số tiền hoặc phần trăm tùy theo logic của bạn
                // Ở đây tôi giả định giảm giá là tiền
                tong -= giamGiaValue;
            }

            txtTongTienHoaDon.Text = tong.ToString("N0");
            txtKhachCanTra.Text = tong.ToString("N0"); // Khách cần trả = tổng tiền sau giảm giá
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            currentMaHD = "HD" + DateTime.Now.Ticks.ToString(); // Tạo mã hóa đơn mới
            txtMaHoaDon.Text = currentMaHD;
            dtpNgayBan.Value = DateTime.Now;
            SetControlState(true);
            cboNhanVien.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHoaDon.Text) || cboNhanVien.SelectedValue == null || cboBanSo.SelectedValue == null || dgvChiTietMonAn.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin hóa đơn và thêm món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvChiTietMonAn.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Hóa đơn trống, không thể lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Models.HoaDon hoaDon = db.HoaDons.FirstOrDefault(hd => hd.MaHD == currentMaHD);
                bool isNew = false;

                if (hoaDon == null)
                {
                    hoaDon = new Models.HoaDon();
                    db.HoaDons.Add(hoaDon);
                    isNew = true;
                }

                hoaDon.MaHD = txtMaHoaDon.Text;
                hoaDon.MaNV = cboNhanVien.SelectedValue.ToString();
                hoaDon.MaBan = cboBanSo.SelectedValue.ToString();
                hoaDon.NgayLap = dtpNgayBan.Value.Date;
                hoaDon.GioVaoHD = hoaDon.GioVaoHD ?? DateTime.Now; // Giữ nguyên giờ vào nếu đã có, nếu không thì đặt là hiện tại
                hoaDon.GioRaHD = null; // Chưa thanh toán nên GioRaHD là null
                hoaDon.TrangThaiHD = "Chưa thanh toán"; // Trạng thái hóa đơn khi lưu
                hoaDon.GhiChuHD = ""; // Có thể thêm trường ghi chú nếu có

                // Xóa các chi tiết hóa đơn cũ nếu là cập nhật
                if (!isNew)
                {
                    var oldDetails = db.ChiTietHoaDons.Where(ct => ct.MaHD == currentMaHD).ToList();
                    db.ChiTietHoaDons.RemoveRange(oldDetails);
                }

                decimal tongTien = 0;
                foreach (DataGridViewRow row in dgvChiTietMonAn.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Lấy dữ liệu từ DataGridView
                    string tenMon = row.Cells["TenMon"].Value?.ToString();
                    if (string.IsNullOrEmpty(tenMon)) continue; // Bỏ qua dòng trống

                    var mon = db.MenuThucDons.FirstOrDefault(m => m.TenMon == tenMon);
                    if (mon == null)
                    {
                        MessageBox.Show($"Món '{tenMon}' không tồn tại trong menu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Hoặc xử lý khác
                    }

                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    decimal thanhTien = soLuong * donGia; // Tính lại thành tiền đảm bảo

                    var chiTiet = new ChiTietHoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaMon = mon.MaMon,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = thanhTien
                    };
                    db.ChiTietHoaDons.Add(chiTiet);
                    tongTien += thanhTien;
                }

                decimal giamGiaValue = 0;
                if (decimal.TryParse(txtGiamGia.Text, out giamGiaValue))
                {
                    tongTien -= giamGiaValue;
                }

                hoaDon.TongTien = tongTien;

                // Cập nhật trạng thái bàn nếu là hóa đơn mới hoặc bàn cũ đang trống
                var ban = db.Bans.FirstOrDefault(b => b.MaBan == hoaDon.MaBan);
                if (ban != null)
                {
                    if (ban.TrangThaiB.Trim() == "Trống") // Chỉ thay đổi nếu đang trống
                    {
                        ban.TrangThaiB = "Có người";
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetControlState(false);
                ClearForm(); // Sau khi lưu, có thể reset form để tạo hóa đơn mới
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
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này? Mọi thay đổi sẽ bị mất.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(currentMaHD))
                {
                    // Nếu là hóa đơn đã tồn tại trong DB, cần xóa ChiTietHoaDon và HoaDon
                    var hoaDonToDelete = db.HoaDons.FirstOrDefault(hd => hd.MaHD == currentMaHD && hd.TrangThaiHD == "Chưa thanh toán");
                    if (hoaDonToDelete != null)
                    {
                        var chiTietToDelete = db.ChiTietHoaDons.Where(ct => ct.MaHD == currentMaHD).ToList();
                        db.ChiTietHoaDons.RemoveRange(chiTietToDelete);
                        db.HoaDons.Remove(hoaDonToDelete);

                        // Cập nhật trạng thái bàn về "Trống" nếu nó đang "Có người" do hóa đơn này
                        var ban = db.Bans.FirstOrDefault(b => b.MaBan == hoaDonToDelete.MaBan);
                        if (ban != null && ban.TrangThaiB.Trim() == "Có người")
                        {
                            ban.TrangThaiB = "Trống";
                        }

                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Hóa đơn đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi hủy hóa đơn trong database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                ClearForm();
                SetControlState(false);
                currentMaHD = ""; // Reset mã hóa đơn hiện tại
            }
        }


        private void btnHoaDonMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = "HD" + DateTime.Now.Ticks;
            cboNhanVien.SelectedIndex = -1;
            cboBanSo.SelectedIndex = -1;
            dtpNgayBan.Value = DateTime.Today;
            dgvChiTietMonAn.Rows.Clear();
            txtTongTienHoaDon.Clear();
            txtGiamGia.Clear();
            txtKhachCanTra.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Logic thanh toán và in (có thể giống với phần thanh toán của QuanLyBanGoiMon)
            // Cần lưu hóa đơn trước, sau đó in
            button2_Click(sender, e); // Gọi sự kiện lưu trước

            if (!string.IsNullOrEmpty(currentMaHD)) // Nếu hóa đơn đã được lưu thành công
            {
                var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.MaHD == currentMaHD);
                if (hoaDon != null)
                {
                    hoaDon.GioRaHD = DateTime.Now;
                    hoaDon.TrangThaiHD = "Đã thanh toán";

                    // Cập nhật trạng thái bàn về "Trống"
                    var ban = db.Bans.FirstOrDefault(b => b.MaBan == hoaDon.MaBan);
                    if (ban != null)
                    {
                        ban.TrangThaiB = "Trống";
                    }

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Hóa đơn đã được thanh toán và sẵn sàng để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Implement printing logic here
                        ClearForm();
                        SetControlState(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật trạng thái thanh toán hoặc in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ClearForm()
        {
            txtMaHoaDon.Clear();
            cboNhanVien.SelectedIndex = -1;
            cboBanSo.SelectedIndex = -1;
            dtpNgayBan.Value = DateTime.Now;
            dgvChiTietMonAn.Rows.Clear();
            txtTongTienHoaDon.Clear();
            txtGiamGia.Clear();
            txtKhachCanTra.Clear();
        }
        private void dgvChiTietMonAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietMonAn.Rows[e.RowIndex];

                // Cập nhật DonGia và Thành tiền khi TenMon được nhập
                if (e.ColumnIndex == dgvChiTietMonAn.Columns["TenMon"].Index && row.Cells["TenMon"].Value != null)
                {
                    string tenMon = row.Cells["TenMon"].Value.ToString();
                    var mon = db.MenuThucDons.FirstOrDefault(m => m.TenMon == tenMon);
                    if (mon != null)
                    {
                        row.Cells["MaMon"].Value = mon.MaMon;
                        row.Cells["DonGia"].Value = mon.DonGia;
                        if (row.Cells["SoLuong"].Value == null) row.Cells["SoLuong"].Value = 0; // Đặt mặc định số lượng nếu trống

                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        row.Cells["ThanhTien"].Value = soLuong * mon.DonGia;
                    }
                    else
                    {
                        row.Cells["MaMon"].Value = "";
                        row.Cells["DonGia"].Value = 0;
                        row.Cells["ThanhTien"].Value = 0;
                    }
                }
                // Cập nhật Thành tiền khi Số lượng hoặc Đơn giá thay đổi
                else if ((e.ColumnIndex == dgvChiTietMonAn.Columns["SoLuong"].Index || e.ColumnIndex == dgvChiTietMonAn.Columns["DonGia"].Index) &&
                         row.Cells["SoLuong"].Value != null && row.Cells["DonGia"].Value != null)
                {
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    row.Cells["ThanhTien"].Value = soLuong * donGia;
                }
                CapNhatTongTien();
            }
        }

        private void dgvChiTietMonAn_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CapNhatTongTien(); // Cập nhật lại tổng tiền khi xóa dòng
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CapNhatTongTien(); // Cập nhật lại tổng tiền khi giảm giá thay đổi
        }
    }
}



