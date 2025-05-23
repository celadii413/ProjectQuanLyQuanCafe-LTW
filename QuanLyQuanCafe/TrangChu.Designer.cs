//using System.Drawing;
//using System.Windows.Forms;

//namespace QuanLyQuanCafe
//{
//    partial class TrangChu
//    {
//        /// <summary>
//        ///  Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        ///  Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        ///  Required method for Designer support - do not modify
//        ///  the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
//            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.cấuHìnhHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.saoLưuVàPhụcHồiDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
//            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchMónĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.chiTiếtMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýMặtBằngBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchKhuVựcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýNhânSựToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.nghiệpVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.lậpHóaĐơnOrderMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.danhSáchHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.báoCáoVàThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.báoCáoChiTiếtBánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.báoCáoChấmCôngLươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.báoCáoHoạtĐộngBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
//            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
//            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
//            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
//            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
//            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
//            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
//            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
//            this.timer1 = new System.Windows.Forms.Timer(this.components);
//            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
//            this.menuStrip1.SuspendLayout();
//            this.toolStrip1.SuspendLayout();
//            this.statusStrip1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // menuStrip1
//            // 
//            this.menuStrip1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.hệThốngToolStripMenuItem,
//            this.danhMụcToolStripMenuItem,
//            this.nghiệpVụToolStripMenuItem,
//            this.báoCáoVàThốngKêToolStripMenuItem});
//            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
//            this.menuStrip1.Name = "menuStrip1";
//            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
//            this.menuStrip1.Size = new System.Drawing.Size(948, 29);
//            this.menuStrip1.TabIndex = 1;
//            this.menuStrip1.Text = "menuStrip1";
//            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
//            // 
//            // hệThốngToolStripMenuItem
//            // 
//            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.đổiMậtKhẩuToolStripMenuItem,
//            this.quảnLýNgườiDùngToolStripMenuItem,
//            this.cấuHìnhHệThốngToolStripMenuItem,
//            this.saoLưuVàPhụcHồiDữLiệuToolStripMenuItem,
//            this.toolStripSeparator1,
//            this.thoátToolStripMenuItem});
//            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
//            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(93, 25);
//            this.hệThốngToolStripMenuItem.Text = "Hệ Thống ";
//            // 
//            // đổiMậtKhẩuToolStripMenuItem
//            // 
//            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
//            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
//            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật Khẩu";
//            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
//            // 
//            // quảnLýNgườiDùngToolStripMenuItem
//            // 
//            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
//            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
//            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản Lý Người Dùng";
//            // 
//            // cấuHìnhHệThốngToolStripMenuItem
//            // 
//            this.cấuHìnhHệThốngToolStripMenuItem.Name = "cấuHìnhHệThốngToolStripMenuItem";
//            this.cấuHìnhHệThốngToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
//            this.cấuHìnhHệThốngToolStripMenuItem.Text = "Cấu Hình Hệ Thống";
//            // 
//            // saoLưuVàPhụcHồiDữLiệuToolStripMenuItem
//            // 
//            this.saoLưuVàPhụcHồiDữLiệuToolStripMenuItem.Name = "saoLưuVàPhụcHồiDữLiệuToolStripMenuItem";
//            this.saoLưuVàPhụcHồiDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
//            this.saoLưuVàPhụcHồiDữLiệuToolStripMenuItem.Text = "Sao Lưu và Phục Hồi Dữ Liệu ";
//            // 
//            // toolStripSeparator1
//            // 
//            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripSeparator1.Name = "toolStripSeparator1";
//            this.toolStripSeparator1.Size = new System.Drawing.Size(287, 6);
//            // 
//            // thoátToolStripMenuItem
//            // 
//            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
//            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
//            this.thoátToolStripMenuItem.Text = "Thoát";
//            // 
//            // danhMụcToolStripMenuItem
//            // 
//            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem,
//            this.quảnLýMặtBằngBànToolStripMenuItem,
//            this.quảnLýNhânSựToolStripMenuItem,
//            this.toolStripSeparator2,
//            this.thoátToolStripMenuItem1});
//            this.danhMụcToolStripMenuItem.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.danhMụcToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
//            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
//            this.danhMụcToolStripMenuItem.Text = "Danh Mục ";
//            // 
//            // quảnLýThựcĐơnMónĂnToolStripMenuItem
//            // 
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.danhSáchMónĂnToolStripMenuItem,
//            this.danhSáchMenuToolStripMenuItem,
//            this.chiTiếtMenuToolStripMenuItem});
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem.Name = "quảnLýThựcĐơnMónĂnToolStripMenuItem";
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
//            this.quảnLýThựcĐơnMónĂnToolStripMenuItem.Text = "Quản Lý Thực Đơn & Món Ăn";
//            // 
//            // danhSáchMónĂnToolStripMenuItem
//            // 
//            this.danhSáchMónĂnToolStripMenuItem.Name = "danhSáchMónĂnToolStripMenuItem";
//            this.danhSáchMónĂnToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
//            this.danhSáchMónĂnToolStripMenuItem.Text = "Danh Sách Món Ăn";
//            // 
//            // danhSáchMenuToolStripMenuItem
//            // 
//            this.danhSáchMenuToolStripMenuItem.Name = "danhSáchMenuToolStripMenuItem";
//            this.danhSáchMenuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
//            this.danhSáchMenuToolStripMenuItem.Text = "Danh Sách Menu";
//            // 
//            // chiTiếtMenuToolStripMenuItem
//            // 
//            this.chiTiếtMenuToolStripMenuItem.Name = "chiTiếtMenuToolStripMenuItem";
//            this.chiTiếtMenuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
//            this.chiTiếtMenuToolStripMenuItem.Text = "Chi Tiết Menu";
//            // 
//            // quảnLýMặtBằngBànToolStripMenuItem
//            // 
//            this.quảnLýMặtBằngBànToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.danhSáchBànToolStripMenuItem,
//            this.danhSáchKhuVựcToolStripMenuItem});
//            this.quảnLýMặtBằngBànToolStripMenuItem.Name = "quảnLýMặtBằngBànToolStripMenuItem";
//            this.quảnLýMặtBằngBànToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
//            this.quảnLýMặtBằngBànToolStripMenuItem.Text = "Quản Lý Mặt Bằng & Bàn";
//            // 
//            // danhSáchBànToolStripMenuItem
//            // 
//            this.danhSáchBànToolStripMenuItem.Name = "danhSáchBànToolStripMenuItem";
//            this.danhSáchBànToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
//            this.danhSáchBànToolStripMenuItem.Text = "Danh Sách Bàn";
//            this.danhSáchBànToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBànToolStripMenuItem_Click);
//            // 
//            // danhSáchKhuVựcToolStripMenuItem
//            // 
//            this.danhSáchKhuVựcToolStripMenuItem.Name = "danhSáchKhuVựcToolStripMenuItem";
//            this.danhSáchKhuVựcToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
//            this.danhSáchKhuVựcToolStripMenuItem.Text = "Danh Sách Khu Vực";
//            // 
//            // quảnLýNhânSựToolStripMenuItem
//            // 
//            this.quảnLýNhânSựToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.danhSáchNhânViênToolStripMenuItem});
//            this.quảnLýNhânSựToolStripMenuItem.Name = "quảnLýNhânSựToolStripMenuItem";
//            this.quảnLýNhânSựToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
//            this.quảnLýNhânSựToolStripMenuItem.Text = "Quản Lý Nhân Sự";
//            // 
//            // danhSáchNhânViênToolStripMenuItem
//            // 
//            this.danhSáchNhânViênToolStripMenuItem.Name = "danhSáchNhânViênToolStripMenuItem";
//            this.danhSáchNhânViênToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
//            this.danhSáchNhânViênToolStripMenuItem.Text = "Danh Sách Nhân Viên";
//            // 
//            // nghiệpVụToolStripMenuItem
//            // 
//            this.nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.quảnLýBánToolStripMenuItem});
//            this.nghiệpVụToolStripMenuItem.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.nghiệpVụToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
//            this.nghiệpVụToolStripMenuItem.Size = new System.Drawing.Size(97, 25);
//            this.nghiệpVụToolStripMenuItem.Text = "Nghiệp Vụ ";
//            // 
//            // quảnLýBánToolStripMenuItem
//            // 
//            this.quảnLýBánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.lậpHóaĐơnOrderMónToolStripMenuItem,
//            this.danhSáchHóaĐơnToolStripMenuItem});
//            this.quảnLýBánToolStripMenuItem.Name = "quảnLýBánToolStripMenuItem";
//            this.quảnLýBánToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
//            this.quảnLýBánToolStripMenuItem.Text = "Quản Lý Bán Hàng";
//            // 
//            // lậpHóaĐơnOrderMónToolStripMenuItem
//            // 
//            this.lậpHóaĐơnOrderMónToolStripMenuItem.Name = "lậpHóaĐơnOrderMónToolStripMenuItem";
//            this.lậpHóaĐơnOrderMónToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
//            this.lậpHóaĐơnOrderMónToolStripMenuItem.Text = "Lập Hóa Đơn / Order Món ";
//            // 
//            // danhSáchHóaĐơnToolStripMenuItem
//            // 
//            this.danhSáchHóaĐơnToolStripMenuItem.Name = "danhSáchHóaĐơnToolStripMenuItem";
//            this.danhSáchHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
//            this.danhSáchHóaĐơnToolStripMenuItem.Text = "Danh Sách Hóa Đơn ";
//            // 
//            // báoCáoVàThốngKêToolStripMenuItem
//            // 
//            this.báoCáoVàThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.báoCáoChiTiếtBánHàngToolStripMenuItem,
//            this.báoCáoChấmCôngLươngToolStripMenuItem,
//            this.báoCáoHoạtĐộngBànToolStripMenuItem});
//            this.báoCáoVàThốngKêToolStripMenuItem.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.báoCáoVàThốngKêToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.báoCáoVàThốngKêToolStripMenuItem.Name = "báoCáoVàThốngKêToolStripMenuItem";
//            this.báoCáoVàThốngKêToolStripMenuItem.Size = new System.Drawing.Size(168, 25);
//            this.báoCáoVàThốngKêToolStripMenuItem.Text = "Báo Cáo và Thống Kê";
//            // 
//            // báoCáoChiTiếtBánHàngToolStripMenuItem
//            // 
//            this.báoCáoChiTiếtBánHàngToolStripMenuItem.Name = "báoCáoChiTiếtBánHàngToolStripMenuItem";
//            this.báoCáoChiTiếtBánHàngToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
//            this.báoCáoChiTiếtBánHàngToolStripMenuItem.Text = "Báo Cáo Chi Tiết Bán Hàng";
//            // 
//            // báoCáoChấmCôngLươngToolStripMenuItem
//            // 
//            this.báoCáoChấmCôngLươngToolStripMenuItem.Name = "báoCáoChấmCôngLươngToolStripMenuItem";
//            this.báoCáoChấmCôngLươngToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
//            this.báoCáoChấmCôngLươngToolStripMenuItem.Text = "Báo Cáo Lương";
//            // 
//            // báoCáoHoạtĐộngBànToolStripMenuItem
//            // 
//            this.báoCáoHoạtĐộngBànToolStripMenuItem.Name = "báoCáoHoạtĐộngBànToolStripMenuItem";
//            this.báoCáoHoạtĐộngBànToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
//            this.báoCáoHoạtĐộngBànToolStripMenuItem.Text = "Báo Cáo Hoạt Động Bàn";
//            // 
//            // toolStrip1
//            // 
//            this.toolStrip1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.toolStripButton1,
//            this.toolStripButton2,
//            this.toolStripButton4,
//            this.toolStripButton5});
//            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
//            this.toolStrip1.Name = "toolStrip1";
//            this.toolStrip1.Size = new System.Drawing.Size(948, 28);
//            this.toolStrip1.TabIndex = 2;
//            this.toolStrip1.Text = "toolStrip1";
//            // 
//            // toolStripButton1
//            // 
//            this.toolStripButton1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripButton1.Image = global::QuanLyQuanCafe.Properties.Resources.invoice__1_;
//            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton1.Name = "toolStripButton1";
//            this.toolStripButton1.Size = new System.Drawing.Size(150, 25);
//            this.toolStripButton1.Text = "Lập Hóa Đơn Mới";
//            // 
//            // toolStripButton2
//            // 
//            this.toolStripButton2.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripButton2.Image = global::QuanLyQuanCafe.Properties.Resources.table__1_;
//            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton2.Name = "toolStripButton2";
//            this.toolStripButton2.Size = new System.Drawing.Size(98, 25);
//            this.toolStripButton2.Text = "Vị Trí Bàn";
//            // 
//            // toolStripButton4
//            // 
//            this.toolStripButton4.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripButton4.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripButton4.Image = global::QuanLyQuanCafe.Properties.Resources.cutlery;
//            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton4.Name = "toolStripButton4";
//            this.toolStripButton4.Size = new System.Drawing.Size(144, 25);
//            this.toolStripButton4.Text = "Quản Lý Món Ăn";
//            // 
//            // toolStripButton5
//            // 
//            this.toolStripButton5.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripButton5.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripButton5.Image = global::QuanLyQuanCafe.Properties.Resources.logout;
//            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton5.Name = "toolStripButton5";
//            this.toolStripButton5.Size = new System.Drawing.Size(108, 25);
//            this.toolStripButton5.Text = "Đăng Xuất ";
//            // 
//            // statusStrip1
//            // 
//            this.statusStrip1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.toolStripStatusLabel1,
//            this.toolStripStatusLabel2,
//            this.lblDateTime,
//            this.toolStripProgressBar1,
//            this.toolStripStatusLabel4});
//            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
//            this.statusStrip1.Name = "statusStrip1";
//            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
//            this.statusStrip1.Size = new System.Drawing.Size(948, 27);
//            this.statusStrip1.TabIndex = 3;
//            this.statusStrip1.Text = "statusStrip1";
//            // 
//            // toolStripStatusLabel1
//            // 
//            this.toolStripStatusLabel1.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
//            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
//            this.toolStripStatusLabel1.Size = new System.Drawing.Size(145, 21);
//            this.toolStripStatusLabel1.Text = "Người Dùng : Admin";
//            // 
//            // toolStripStatusLabel2
//            // 
//            this.toolStripStatusLabel2.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
//            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
//            this.toolStripStatusLabel2.Size = new System.Drawing.Size(133, 21);
//            this.toolStripStatusLabel2.Text = "Chức Vụ : Quản Lý";
//            // 
//            // lblDateTime
//            // 
//            this.lblDateTime.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
//            this.lblDateTime.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.lblDateTime.Name = "lblDateTime";
//            this.lblDateTime.Size = new System.Drawing.Size(85, 21);
//            this.lblDateTime.Text = "Thời Gian : ";
//            // 
//            // toolStripProgressBar1
//            // 
//            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
//            this.toolStripProgressBar1.Size = new System.Drawing.Size(235, 19);
//            // 
//            // toolStripStatusLabel4
//            // 
//            this.toolStripStatusLabel4.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
//            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
//            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
//            this.toolStripStatusLabel4.Size = new System.Drawing.Size(133, 21);
//            this.toolStripStatusLabel4.Text = "Phiên Bản : 1.0.0.1";
//            // 
//            // thoátToolStripMenuItem1
//            // 
//            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
//            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(277, 26);
//            this.thoátToolStripMenuItem1.Text = "Thoát";
//            // 
//            // toolStripSeparator2
//            // 
//            this.toolStripSeparator2.Name = "toolStripSeparator2";
//            this.toolStripSeparator2.Size = new System.Drawing.Size(274, 6);
//            // 
//            // TrangChu
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
//            this.ClientSize = new System.Drawing.Size(948, 466);
//            this.Controls.Add(this.statusStrip1);
//            this.Controls.Add(this.toolStrip1);
//            this.Controls.Add(this.menuStrip1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
//            this.IsMdiContainer = true;
//            this.MainMenuStrip = this.menuStrip1;
//            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.Name = "TrangChu";
//            this.Text = "Trang chủ";
//            this.menuStrip1.ResumeLayout(false);
//            this.menuStrip1.PerformLayout();
//            this.toolStrip1.ResumeLayout(false);
//            this.toolStrip1.PerformLayout();
//            this.statusStrip1.ResumeLayout(false);
//            this.statusStrip1.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private MenuStrip menuStrip1;
//        private ToolStripMenuItem hệThốngToolStripMenuItem;
//        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
//        private ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
//        private ToolStripMenuItem cấuHìnhHệThốngToolStripMenuItem;
//        private ToolStripMenuItem saoLưuVàPhụcHồiDữLiệuToolStripMenuItem;
//        private ToolStripSeparator toolStripSeparator1;
//        private ToolStripMenuItem thoátToolStripMenuItem;
//        private ToolStripMenuItem danhMụcToolStripMenuItem;
//        private ToolStripMenuItem quảnLýThựcĐơnMónĂnToolStripMenuItem;
//        private ToolStripMenuItem danhSáchMónĂnToolStripMenuItem;
//        private ToolStripMenuItem danhSáchMenuToolStripMenuItem;
//        private ToolStripMenuItem chiTiếtMenuToolStripMenuItem;
//        private ToolStripMenuItem quảnLýMặtBằngBànToolStripMenuItem;
//        private ToolStripMenuItem danhSáchBànToolStripMenuItem;
//        private ToolStripMenuItem danhSáchKhuVựcToolStripMenuItem;
//        private ToolStripMenuItem quảnLýNhânSựToolStripMenuItem;
//        private ToolStripMenuItem danhSáchNhânViênToolStripMenuItem;
//        private ToolStripMenuItem nghiệpVụToolStripMenuItem;
//        private ToolStripMenuItem quảnLýBánToolStripMenuItem;
//        private ToolStripMenuItem lậpHóaĐơnOrderMónToolStripMenuItem;
//        private ToolStripMenuItem danhSáchHóaĐơnToolStripMenuItem;
//        private ToolStripMenuItem báoCáoVàThốngKêToolStripMenuItem;
//        private ToolStripMenuItem báoCáoChiTiếtBánHàngToolStripMenuItem;
//        private ToolStripMenuItem báoCáoChấmCôngLươngToolStripMenuItem;
//        private ToolStripMenuItem báoCáoHoạtĐộngBànToolStripMenuItem;
//        private ToolStrip toolStrip1;
//        private ToolStripButton toolStripButton1;
//        private ToolStripButton toolStripButton2;
//        private ToolStripButton toolStripButton4;
//        private ToolStripButton toolStripButton5;
//        private StatusStrip statusStrip1;
//        private ToolStripStatusLabel toolStripStatusLabel1;
//        private ToolStripStatusLabel toolStripStatusLabel2;
//        private ToolStripStatusLabel lblDateTime;
//        private ToolStripProgressBar toolStripProgressBar1;
//        private ToolStripStatusLabel toolStripStatusLabel4;
//        private Timer timer1;
//        private ToolStripSeparator toolStripSeparator2;
//        private ToolStripMenuItem thoátToolStripMenuItem1;
//    }
//}