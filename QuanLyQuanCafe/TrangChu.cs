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
    public partial class TrangChu : Form
    {
        private string _tenDangNhap;
        private string _chucVu;
        private Timer timerThoiGian;
        public TrangChu(string tenDangNhap, string chucVu)
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Đặt form là container MDI

            _tenDangNhap = tenDangNhap;
            _chucVu = chucVu;

            toolStripStatusLabelUser.Text = $"Người Dùng : {_tenDangNhap}"; // Tên người dùng
            toolStripStatusLabelRole.Text = $"Chức Vụ : {_chucVu}";     // Chức vụ

            // Khởi tạo và chạy Timer cho thời gian
            timerThoiGian = new Timer();
            timerThoiGian.Interval = 1000; // Cập nhật mỗi giây
            timerThoiGian.Tick += TimerThoiGian_Tick;
            timerThoiGian.Start();
        }
        private void TimerThoiGian_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = $"Thời Gian : {DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}"; // Hiển thị thời gian
        }
        private void OpenMdiChildForm(Form childForm)
        {
            // Kiểm tra xem form đã được mở chưa
            Form existingForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.GetType() == childForm.GetType());

            if (existingForm == null)
            {
                // Nếu chưa mở, tạo mới và hiển thị
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
            {
                // Nếu đã mở, đưa lên phía trước
                existingForm.Activate();
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýKhoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchBànToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
