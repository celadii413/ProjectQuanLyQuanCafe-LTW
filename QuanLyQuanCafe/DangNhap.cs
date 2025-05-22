using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class DangNhap : Form
    {
        private QuanCafeDB db = new QuanCafeDB();
        public DangNhap()
        {
            InitializeComponent();
            txtTenDangNhap.Text = "admin";
            txtMatKhau.Text = "123";
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Để tạo dữ liệu mẫu nếu database trống (chỉ chạy lần đầu)
            if (!db.NhanViens.Any())
            {
                var chucVu = new ChucVu { MaCV = "CV001", TenCV = "Quản lý" };
                var caLam = new CaLam { MaCa = "CA001", TenCa = "Ca sáng" };
                db.ChucVus.Add(chucVu);
                db.CaLams.Add(caLam);
                db.SaveChanges(); // Lưu trước để có khóa ngoại

                var nv = new NhanVien
                {
                    MaNV = "NV001",
                    HoTenNV = "Admin",
                    MaCV = "CV001",
                    MaCa = "CA001",
                    TrangThaiNV = "Đang làm",
                    EmailNV = "admin@example.com",
                    SDTNV = "0123456789"
                };
                db.NhanViens.Add(nv);
                db.SaveChanges();

                var tk = new TaiKhoan
                {
                    MaNV = "NV001",
                    TenDangNhap = "admin",
                    MatKhau = HashPassword("123"), // Mật khẩu mặc định là "123"
                    LoaiTaiKhoan = "Admin"
                };
                db.TaiKhoans.Add(tk);
                db.SaveChanges();

                // Tạo vài bàn mẫu
                for (int i = 0; i <= 10; i++)
                {
                    db.Bans.Add(new Ban { MaBan = $"B{i}", TenBan = $"Bàn {i}", TrangThaiB = "Trống" });
                }
                db.SaveChanges();

                // Tạo vài món ăn mẫu
                db.MenuThucDons.Add(new MenuThucDon { MaMon = "CF001", TenMon = "Cà phê đen", DonGia = 20000, LoaiMon = "Cà phê" });
                db.MenuThucDons.Add(new MenuThucDon { MaMon = "TR001", TenMon = "Trà sữa", DonGia = 30000, LoaiMon = "Trà" });
                db.MenuThucDons.Add(new MenuThucDon { MaMon = "BAN001", TenMon = "Bánh ngọt", DonGia = 25000, LoaiMon = "Đồ ăn vặt" });
                db.SaveChanges();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = HashPassword(txtMatKhau.Text.Trim()); // Hash mật khẩu nhập vào để so sánh

            var taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);

            if (taiKhoan != null)
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lấy thông tin nhân viên liên quan
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == taiKhoan.MaNV);

                // Mở form TrangChu và truyền thông tin người dùng
                TrangChu trangChuForm = new TrangChu(nhanVien.HoTenNV, taiKhoan.LoaiTaiKhoan); // Truyền tên và loại tài khoản
                this.Hide(); // Ẩn form đăng nhập
                trangChuForm.ShowDialog(); // Hiển thị form Trang Chủ

                // Sau khi form TrangChu đóng, kiểm tra lại nếu muốn hiện lại FormDangNhap hoặc thoát ứng dụng
                this.Close(); // Đóng form đăng nhập khi TrangChu đóng
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load_1(object sender, EventArgs e)
        {

        }
    }
}
