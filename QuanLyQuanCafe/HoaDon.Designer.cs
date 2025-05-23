//using System.Drawing;
//using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;
//using System.Xml.Linq;

//namespace QuanLyQuanCafe
//{
//    partial class HoaDon
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
//            this.label1 = new System.Windows.Forms.Label();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
//            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
//            this.cboNhanVien = new System.Windows.Forms.ComboBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.cboBanSo = new System.Windows.Forms.ComboBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.txtKhachCanTra = new System.Windows.Forms.TextBox();
//            this.txtGiamGia = new System.Windows.Forms.TextBox();
//            this.txtTongTienHoaDon = new System.Windows.Forms.TextBox();
//            this.label12 = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.dgvChiTietMonAn = new System.Windows.Forms.DataGridView();
//            this.panel2 = new System.Windows.Forms.Panel();
//            this.btnHuyHoaDon = new System.Windows.Forms.Button();
//            this.btnThanhToanVaIn = new System.Windows.Forms.Button();
//            this.btnLuuHoaDon = new System.Windows.Forms.Button();
//            this.btnHoaDonMoi = new System.Windows.Forms.Button();
//            this.groupBox1.SuspendLayout();
//            this.groupBox2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMonAn)).BeginInit();
//            this.panel2.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.ForeColor = System.Drawing.Color.Black;
//            this.label1.Location = new System.Drawing.Point(172, 9);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(332, 38);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Lập Hóa Đơn Bán Hàng ";
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.dtpNgayBan);
//            this.groupBox1.Controls.Add(this.txtMaHoaDon);
//            this.groupBox1.Controls.Add(this.cboNhanVien);
//            this.groupBox1.Controls.Add(this.label2);
//            this.groupBox1.Controls.Add(this.label4);
//            this.groupBox1.Controls.Add(this.cboBanSo);
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Controls.Add(this.label5);
//            this.groupBox1.Location = new System.Drawing.Point(12, 58);
//            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox1.Size = new System.Drawing.Size(637, 175);
//            this.groupBox1.TabIndex = 1;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Thông Tin Chung Hóa Đơn";
//            // 
//            // dtpNgayBan
//            // 
//            this.dtpNgayBan.Location = new System.Drawing.Point(258, 139);
//            this.dtpNgayBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.dtpNgayBan.Name = "dtpNgayBan";
//            this.dtpNgayBan.Size = new System.Drawing.Size(250, 22);
//            this.dtpNgayBan.TabIndex = 2;
//            // 
//            // txtMaHoaDon
//            // 
//            this.txtMaHoaDon.Location = new System.Drawing.Point(258, 31);
//            this.txtMaHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtMaHoaDon.Name = "txtMaHoaDon";
//            this.txtMaHoaDon.Size = new System.Drawing.Size(250, 22);
//            this.txtMaHoaDon.TabIndex = 2;
//            // 
//            // cboNhanVien
//            // 
//            this.cboNhanVien.FormattingEnabled = true;
//            this.cboNhanVien.Location = new System.Drawing.Point(258, 64);
//            this.cboNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.cboNhanVien.Name = "cboNhanVien";
//            this.cboNhanVien.Size = new System.Drawing.Size(250, 24);
//            this.cboNhanVien.TabIndex = 5;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(134, 33);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(88, 16);
//            this.label2.TabIndex = 0;
//            this.label2.Text = "Mã Hóa Đơn :";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(134, 144);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(73, 16);
//            this.label4.TabIndex = 3;
//            this.label4.Text = "Ngày Bán :";
//            // 
//            // cboBanSo
//            // 
//            this.cboBanSo.FormattingEnabled = true;
//            this.cboBanSo.Location = new System.Drawing.Point(258, 102);
//            this.cboBanSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.cboBanSo.Name = "cboBanSo";
//            this.cboBanSo.Size = new System.Drawing.Size(250, 24);
//            this.cboBanSo.TabIndex = 6;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(134, 71);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(75, 16);
//            this.label3.TabIndex = 2;
//            this.label3.Text = "Nhân Viên :";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(134, 108);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(60, 16);
//            this.label5.TabIndex = 4;
//            this.label5.Text = "Bàn Số : ";
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.txtKhachCanTra);
//            this.groupBox2.Controls.Add(this.txtGiamGia);
//            this.groupBox2.Controls.Add(this.txtTongTienHoaDon);
//            this.groupBox2.Controls.Add(this.label12);
//            this.groupBox2.Controls.Add(this.label11);
//            this.groupBox2.Controls.Add(this.label10);
//            this.groupBox2.Controls.Add(this.dgvChiTietMonAn);
//            this.groupBox2.Location = new System.Drawing.Point(12, 254);
//            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox2.Size = new System.Drawing.Size(637, 298);
//            this.groupBox2.TabIndex = 4;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Chi Tiết Món Ăn :";
//            // 
//            // txtKhachCanTra
//            // 
//            this.txtKhachCanTra.Location = new System.Drawing.Point(407, 265);
//            this.txtKhachCanTra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtKhachCanTra.Name = "txtKhachCanTra";
//            this.txtKhachCanTra.Size = new System.Drawing.Size(211, 22);
//            this.txtKhachCanTra.TabIndex = 5;
//            // 
//            // txtGiamGia
//            // 
//            this.txtGiamGia.Location = new System.Drawing.Point(407, 234);
//            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtGiamGia.Name = "txtGiamGia";
//            this.txtGiamGia.Size = new System.Drawing.Size(211, 22);
//            this.txtGiamGia.TabIndex = 5;
//            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
//            // 
//            // txtTongTienHoaDon
//            // 
//            this.txtTongTienHoaDon.Location = new System.Drawing.Point(407, 203);
//            this.txtTongTienHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtTongTienHoaDon.Name = "txtTongTienHoaDon";
//            this.txtTongTienHoaDon.Size = new System.Drawing.Size(211, 22);
//            this.txtTongTienHoaDon.TabIndex = 5;
//            // 
//            // label12
//            // 
//            this.label12.AutoSize = true;
//            this.label12.Location = new System.Drawing.Point(248, 267);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(104, 16);
//            this.label12.TabIndex = 3;
//            this.label12.Text = "Khách Cần Trả : ";
//            // 
//            // label11
//            // 
//            this.label11.AutoSize = true;
//            this.label11.Location = new System.Drawing.Point(248, 236);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(69, 16);
//            this.label11.TabIndex = 2;
//            this.label11.Text = "Giảm Giá :";
//            // 
//            // label10
//            // 
//            this.label10.AutoSize = true;
//            this.label10.Location = new System.Drawing.Point(248, 205);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(134, 16);
//            this.label10.TabIndex = 1;
//            this.label10.Text = "Tổng Tiền Hóa Đơn : ";
//            // 
//            // dgvChiTietMonAn
//            // 
//            this.dgvChiTietMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvChiTietMonAn.Location = new System.Drawing.Point(20, 21);
//            this.dgvChiTietMonAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.dgvChiTietMonAn.Name = "dgvChiTietMonAn";
//            this.dgvChiTietMonAn.RowHeadersWidth = 51;
//            this.dgvChiTietMonAn.Size = new System.Drawing.Size(598, 173);
//            this.dgvChiTietMonAn.TabIndex = 0;
//            // 
//            // panel2
//            // 
//            this.panel2.Controls.Add(this.btnHuyHoaDon);
//            this.panel2.Controls.Add(this.btnThanhToanVaIn);
//            this.panel2.Controls.Add(this.btnLuuHoaDon);
//            this.panel2.Controls.Add(this.btnHoaDonMoi);
//            this.panel2.Location = new System.Drawing.Point(119, 566);
//            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.panel2.Name = "panel2";
//            this.panel2.Size = new System.Drawing.Size(530, 27);
//            this.panel2.TabIndex = 5;
//            // 
//            // btnHuyHoaDon
//            // 
//            this.btnHuyHoaDon.Location = new System.Drawing.Point(407, 2);
//            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
//            this.btnHuyHoaDon.Size = new System.Drawing.Size(119, 23);
//            this.btnHuyHoaDon.TabIndex = 6;
//            this.btnHuyHoaDon.Text = "Hủy Hóa Đơn";
//            this.btnHuyHoaDon.UseVisualStyleBackColor = true;
//            this.btnHuyHoaDon.Click += new System.EventHandler(this.button4_Click);
//            // 
//            // btnThanhToanVaIn
//            // 
//            this.btnThanhToanVaIn.Location = new System.Drawing.Point(253, 2);
//            this.btnThanhToanVaIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnThanhToanVaIn.Name = "btnThanhToanVaIn";
//            this.btnThanhToanVaIn.Size = new System.Drawing.Size(148, 23);
//            this.btnThanhToanVaIn.TabIndex = 6;
//            this.btnThanhToanVaIn.Text = "Thanh Toán và In";
//            this.btnThanhToanVaIn.UseVisualStyleBackColor = true;
//            this.btnThanhToanVaIn.Click += new System.EventHandler(this.button3_Click);
//            // 
//            // btnLuuHoaDon
//            // 
//            this.btnLuuHoaDon.Location = new System.Drawing.Point(128, 2);
//            this.btnLuuHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
//            this.btnLuuHoaDon.Size = new System.Drawing.Size(119, 23);
//            this.btnLuuHoaDon.TabIndex = 6;
//            this.btnLuuHoaDon.Text = "Lưu Hóa Đơn";
//            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
//            this.btnLuuHoaDon.Click += new System.EventHandler(this.button2_Click);
//            // 
//            // btnHoaDonMoi
//            // 
//            this.btnHoaDonMoi.Location = new System.Drawing.Point(3, 2);
//            this.btnHoaDonMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnHoaDonMoi.Name = "btnHoaDonMoi";
//            this.btnHoaDonMoi.Size = new System.Drawing.Size(119, 23);
//            this.btnHoaDonMoi.TabIndex = 0;
//            this.btnHoaDonMoi.Text = "Hóa Đơn Mới ";
//            this.btnHoaDonMoi.UseVisualStyleBackColor = true;
//            this.btnHoaDonMoi.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // HoaDon
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(665, 613);
//            this.Controls.Add(this.panel2);
//            this.Controls.Add(this.groupBox2);
//            this.Controls.Add(this.groupBox1);
//            this.Controls.Add(this.label1);
//            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.Name = "HoaDon";
//            this.Text = "Hóa đơn";
//            this.Load += new System.EventHandler(this.HoaDon_Load);
//            this.groupBox1.ResumeLayout(false);
//            this.groupBox1.PerformLayout();
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox2.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMonAn)).EndInit();
//            this.panel2.ResumeLayout(false);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private Label label1;
//        private GroupBox groupBox1;
//        private Label label2;
//        private Label label4;
//        private Label label3;
//        private Label label5;
//        private TextBox txtMaHoaDon;
//        private ComboBox cboNhanVien;
//        private ComboBox cboBanSo;
//        private DateTimePicker dtpNgayBan;
//        private GroupBox groupBox2;
//        private TextBox txtKhachCanTra;
//        private TextBox txtGiamGia;
//        private TextBox txtTongTienHoaDon;
//        private Label label12;
//        private Label label11;
//        private Label label10;
//        private DataGridView dgvChiTietMonAn;
//        private Panel panel2;
//        private Button btnHuyHoaDon;
//        private Button btnThanhToanVaIn;
//        private Button btnLuuHoaDon;
//        private Button btnHoaDonMoi;
//    }
//}
