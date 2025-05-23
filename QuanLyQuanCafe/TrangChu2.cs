//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace QuanLyQuanCafe
//{
//    public partial class TrangChu2 : Form
//    {
//        public TrangChu2()
//        {
//            InitializeComponent();
//        }

//        private void TrangChu2_Load(object sender, EventArgs e)
//        {
//            timer1.Interval = 1000; // 1 giây
//            timer1.Tick += timer1_Tick;
//            timer1.Start();
//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
//        }

//        private void quảnLýMặtBằngBànToolStripMenuItem_Click(object sender, EventArgs e)
//        {

//        }

//        private void danhSáchBànToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            this.Hide();
//            Form1 formGoiMon = new Form1();
//            formGoiMon.ShowDialog();
//            this.Show(); // Hiện lại form gốc khi đóng form mới
//        }

//        private void toolStripButton1_Click(object sender, EventArgs e)
//        {
//            this.Hide();
//            HoaDon formHoaDon = new HoaDon();
//            formHoaDon.ShowDialog();
//            this.Show(); // Hiện lại form gốc khi đóng form mới
//        }

//        private void toolStripButton5_Click(object sender, EventArgs e)
//        {
//            DialogResult result = MessageBox.Show(
//            "Bạn có chắc chắn muốn thoát không?",
//            "Xác nhận thoát",
//            MessageBoxButtons.YesNo,
//            MessageBoxIcon.Question
//        );

//            if (result == DialogResult.Yes)
//            {
//                Application.Exit();
//            }
//        }
//    }
//}
