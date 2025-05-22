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
using System.Data.Entity;
using System.IO;

namespace QuanLyQuanCafe
{
    public partial class NhanVien : Form // Tên Form NhanVien dựa trên hình ảnh
    {
        private QuanCafeDB db = new QuanCafeDB();
        private bool isAddingNew = false; // Biến cờ cho chế độ thêm mới

        public NhanVien()
        {
            InitializeComponent();
            KhoiTaoDataGridView(); // Khởi tạo cấu trúc DataGridView
            SetControlState(false); // Vô hiệu hóa các controls nhập liệu ban đầu
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData(); // Tải dữ liệu nhân viên vào DataGridView
        }

        private void KhoiTaoDataGridView()
        {
            dgvNhanVien.Columns.Clear();
            dgvNhanVien.AutoGenerateColumns = false; // Tắt tự động tạo cột

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MaNV", HeaderText = "Mã NV", DataPropertyName = "MaNV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "HoTenNV", HeaderText = "Họ Tên", DataPropertyName = "HoTenNV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TenCV", HeaderText = "Chức Vụ", DataPropertyName = "TenCV" }); // Dữ liệu từ Navigation Property
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TenCa", HeaderText = "Ca Làm", DataPropertyName = "TenCa" }); // Dữ liệu từ Navigation Property
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThaiNV", HeaderText = "Trạng Thái", DataPropertyName = "TrangThaiNV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "EmailNV", HeaderText = "Email", DataPropertyName = "EmailNV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SDTNV", HeaderText = "Số ĐT", DataPropertyName = "SDTNV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn() { Name = "AnhDaiDien", HeaderText = "Ảnh Đại Diện", DataPropertyName = "AnhDaiDien", Visible = false }); // Ẩn cột đường dẫn ảnh

            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn toàn bộ hàng
            dgvNhanVien.ReadOnly = true; // Không cho phép sửa trực tiếp trên DGV
        }

        private void LoadComboBoxes()
        {
            cboChucVu.DataSource = db.ChucVus.ToList();
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";
            cboChucVu.SelectedIndex = -1;

            cboCaLam.DataSource = db.CaLams.ToList();
            cboCaLam.DisplayMember = "TenCa";
            cboCaLam.ValueMember = "MaCa";
            cboCaLam.SelectedIndex = -1;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang làm");
            cboTrangThai.Items.Add("Nghỉ việc");
            cboTrangThai.SelectedIndex = -1;
        }

        private void LoadData()
        {
            // Tải dữ liệu nhân viên, bao gồm cả Chức vụ và Ca làm để hiển thị tên thay vì mã
            dgvNhanVien.DataSource = db.NhanViens
                                        .Include(nv => nv.ChucVu)
                                        .Include(nv => nv.CaLam)
                                        .Select(nv => new
                                        {
                                            nv.MaNV,
                                            nv.HoTenNV,
                                            TenCV = nv.ChucVu.TenCV,
                                            TenCa = nv.CaLam.TenCa,
                                            nv.TrangThaiNV,
                                            nv.EmailNV,
                                            nv.SDTNV,
                                            nv.AnhDaiDien
                                        })
                                        .ToList();
        }

        private void SetControlState(bool enableEdit)
        {
            txtMaNhanVien.Enabled = isAddingNew; // Mã NV chỉ enabled khi thêm mới
            txtHoTen.Enabled = enableEdit;
            cboChucVu.Enabled = enableEdit;
            cboCaLam.Enabled = enableEdit;
            cboTrangThai.Enabled = enableEdit;
            txtEmail.Enabled = enableEdit;
            txtSoDienThoai.Enabled = enableEdit;
            btnChonAnh.Enabled = enableEdit;

            btnThemMoi.Enabled = !enableEdit;
            btnSua.Enabled = !enableEdit && (dgvNhanVien.SelectedRows.Count > 0);
            btnXoa.Enabled = !enableEdit && (dgvNhanVien.SelectedRows.Count > 0);
            btnLuu.Enabled = enableEdit;
            btnHuy.Enabled = enableEdit;
            btnChamCong.Enabled = !enableEdit && (dgvNhanVien.SelectedRows.Count > 0);
        }

        private void ClearForm()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            cboChucVu.SelectedIndex = -1;
            cboCaLam.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            pictureBoxAnhDaiDien.Image = null; // Xóa ảnh
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            ClearForm();
            SetControlState(true);
            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                isAddingNew = false;
                SetControlState(true);
                txtMaNhanVien.Enabled = false; // Không cho phép sửa mã nhân viên khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    var nvToDelete = db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);

                    if (nvToDelete != null)
                    {
                        // Kiểm tra ràng buộc khóa ngoại (ví dụ: nếu NV có tài khoản, hóa đơn, chấm công)
                        // Bạn cần xử lý các ràng buộc này hoặc đảm bảo DB đã cấu hình cascade delete
                        var taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.MaNV == maNV);
                        if (taiKhoan != null) db.TaiKhoans.Remove(taiKhoan);

                        var hoaDons = db.HoaDons.Where(hd => hd.MaNV == maNV).ToList();
                        if (hoaDons.Any()) MessageBox.Show("Nhân viên này có hóa đơn liên quan. Không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Cần xử lý chi tiết hóa đơn trước khi xóa hóa đơn, hoặc không cho phép xóa NV nếu có HD
                        // db.HoaDons.RemoveRange(hoaDons);

                        var chamCongs = db.ChamCongs.Where(cc => cc.MaNV == maNV).ToList();
                        if (chamCongs.Any()) db.ChamCongs.RemoveRange(chamCongs);

                        db.NhanViens.Remove(nvToDelete);

                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm();
                            SetControlState(false);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text) || string.IsNullOrEmpty(txtHoTen.Text) ||
                cboChucVu.SelectedValue == null || cboCaLam.SelectedValue == null || cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên (Mã NV, Họ Tên, Chức Vụ, Ca Làm, Trạng Thái).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (isAddingNew)
                {
                    // Thêm mới
                    if (db.NhanViens.Any(nv => nv.MaNV == txtMaNhanVien.Text.Trim()))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newNV = new Models.NhanVien
                    {
                        MaNV = txtMaNhanVien.Text.Trim(),
                        HoTenNV = txtHoTen.Text.Trim(),
                        MaCV = cboChucVu.SelectedValue.ToString(),
                        MaCa = cboCaLam.SelectedValue.ToString(),
                        TrangThaiNV = cboTrangThai.SelectedItem.ToString(),
                        EmailNV = txtEmail.Text.Trim(),
                        SDTNV = txtSoDienThoai.Text.Trim(),
                        AnhDaiDien = pictureBoxAnhDaiDien.Tag?.ToString() // Lưu đường dẫn ảnh
                    };
                    db.NhanViens.Add(newNV);
                }
                else
                {
                    // Cập nhật
                    string maNV = txtMaNhanVien.Text.Trim();
                    var existingNV = db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);
                    if (existingNV != null)
                    {
                        existingNV.HoTenNV = txtHoTen.Text.Trim();
                        existingNV.MaCV = cboChucVu.SelectedValue.ToString();
                        existingNV.MaCa = cboCaLam.SelectedValue.ToString();
                        existingNV.TrangThaiNV = cboTrangThai.SelectedItem.ToString();
                        existingNV.EmailNV = txtEmail.Text.Trim();
                        existingNV.SDTNV = txtSoDienThoai.Text.Trim();
                        existingNV.AnhDaiDien = pictureBoxAnhDaiDien.Tag?.ToString(); // Cập nhật đường dẫn ảnh
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Lưu thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
                SetControlState(false);
                isAddingNew = false;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetControlState(false);
            isAddingNew = false;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;
                    pictureBoxAnhDaiDien.Image = Image.FromFile(imagePath);
                    // Lưu đường dẫn ảnh vào Tag của PictureBox để lưu vào DB sau
                    pictureBoxAnhDaiDien.Tag = imagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isAddingNew) // Chỉ đổ dữ liệu khi không ở chế độ thêm mới
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNhanVien.Text = row.Cells["MaNV"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTenNV"].Value?.ToString();

                // Đổ dữ liệu vào ComboBoxes
                string tenCV = row.Cells["TenCV"].Value?.ToString();
                cboChucVu.SelectedValue = db.ChucVus.FirstOrDefault(cv => cv.TenCV == tenCV)?.MaCV;

                string tenCa = row.Cells["TenCa"].Value?.ToString();
                cboCaLam.SelectedValue = db.CaLams.FirstOrDefault(cl => cl.TenCa == tenCa)?.MaCa;

                cboTrangThai.SelectedItem = row.Cells["TrangThaiNV"].Value?.ToString();

                txtEmail.Text = row.Cells["EmailNV"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SDTNV"].Value?.ToString();

                // Load ảnh đại diện
                string imagePath = row.Cells["AnhDaiDien"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    pictureBoxAnhDaiDien.Image = Image.FromFile(imagePath);
                    pictureBoxAnhDaiDien.Tag = imagePath;
                }
                else
                {
                    pictureBoxAnhDaiDien.Image = null; // Hoặc một ảnh mặc định
                    pictureBoxAnhDaiDien.Tag = null;
                }

                SetControlState(false); // Vô hiệu hóa controls, chờ nhấn Sửa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnChamCong.Enabled = true;
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                ChamCongNhanVien chamCongForm = new ChamCongNhanVien(maNV); // Truyền MaNV sang form chấm công
                chamCongForm.ShowDialog();
                // Sau khi form chấm công đóng, có thể tải lại dữ liệu nếu cần
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}