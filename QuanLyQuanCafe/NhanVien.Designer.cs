//using System.Drawing;
//using System.Windows.Forms;

//namespace QuanLyQuanCafe
//{
//    partial class NhanVien
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
//            this.cboTrangThai = new System.Windows.Forms.ComboBox();
//            this.cboCaLam = new System.Windows.Forms.ComboBox();
//            this.cboChucVu = new System.Windows.Forms.ComboBox();
//            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
//            this.txtEmail = new System.Windows.Forms.TextBox();
//            this.txtHoTen = new System.Windows.Forms.TextBox();
//            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
//            this.label9 = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.pictureBoxAnhDaiDien = new System.Windows.Forms.PictureBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.btnChonAnh = new System.Windows.Forms.Button();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.btnChamCong = new System.Windows.Forms.Button();
//            this.btnHuy = new System.Windows.Forms.Button();
//            this.btnLuu = new System.Windows.Forms.Button();
//            this.btnXoa = new System.Windows.Forms.Button();
//            this.btnSua = new System.Windows.Forms.Button();
//            this.btnThemMoi = new System.Windows.Forms.Button();
//            this.label10 = new System.Windows.Forms.Label();
//            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
//            this.groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnhDaiDien)).BeginInit();
//            this.panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(12, 7);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(418, 38);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Quản Lý Thông Tin Nhân Viên ";
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.cboTrangThai);
//            this.groupBox1.Controls.Add(this.cboCaLam);
//            this.groupBox1.Controls.Add(this.cboChucVu);
//            this.groupBox1.Controls.Add(this.txtSoDienThoai);
//            this.groupBox1.Controls.Add(this.txtEmail);
//            this.groupBox1.Controls.Add(this.txtHoTen);
//            this.groupBox1.Controls.Add(this.txtMaNhanVien);
//            this.groupBox1.Controls.Add(this.label9);
//            this.groupBox1.Controls.Add(this.label8);
//            this.groupBox1.Controls.Add(this.label7);
//            this.groupBox1.Controls.Add(this.label6);
//            this.groupBox1.Controls.Add(this.label5);
//            this.groupBox1.Controls.Add(this.label4);
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Location = new System.Drawing.Point(12, 54);
//            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.groupBox1.Size = new System.Drawing.Size(418, 306);
//            this.groupBox1.TabIndex = 1;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Thông Tin Nhân Viên ";
//            // 
//            // cboTrangThai
//            // 
//            this.cboTrangThai.FormattingEnabled = true;
//            this.cboTrangThai.Location = new System.Drawing.Point(164, 183);
//            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.cboTrangThai.Name = "cboTrangThai";
//            this.cboTrangThai.Size = new System.Drawing.Size(226, 24);
//            this.cboTrangThai.TabIndex = 8;
//            // 
//            // cboCaLam
//            // 
//            this.cboCaLam.FormattingEnabled = true;
//            this.cboCaLam.Location = new System.Drawing.Point(164, 146);
//            this.cboCaLam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.cboCaLam.Name = "cboCaLam";
//            this.cboCaLam.Size = new System.Drawing.Size(226, 24);
//            this.cboCaLam.TabIndex = 8;
//            // 
//            // cboChucVu
//            // 
//            this.cboChucVu.FormattingEnabled = true;
//            this.cboChucVu.Location = new System.Drawing.Point(164, 105);
//            this.cboChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.cboChucVu.Name = "cboChucVu";
//            this.cboChucVu.Size = new System.Drawing.Size(226, 24);
//            this.cboChucVu.TabIndex = 7;
//            // 
//            // txtSoDienThoai
//            // 
//            this.txtSoDienThoai.Location = new System.Drawing.Point(164, 262);
//            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtSoDienThoai.Name = "txtSoDienThoai";
//            this.txtSoDienThoai.Size = new System.Drawing.Size(226, 22);
//            this.txtSoDienThoai.TabIndex = 6;
//            // 
//            // txtEmail
//            // 
//            this.txtEmail.Location = new System.Drawing.Point(164, 223);
//            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtEmail.Name = "txtEmail";
//            this.txtEmail.Size = new System.Drawing.Size(226, 22);
//            this.txtEmail.TabIndex = 6;
//            // 
//            // txtHoTen
//            // 
//            this.txtHoTen.Location = new System.Drawing.Point(164, 66);
//            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtHoTen.Name = "txtHoTen";
//            this.txtHoTen.Size = new System.Drawing.Size(226, 22);
//            this.txtHoTen.TabIndex = 6;
//            // 
//            // txtMaNhanVien
//            // 
//            this.txtMaNhanVien.Location = new System.Drawing.Point(164, 29);
//            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtMaNhanVien.Name = "txtMaNhanVien";
//            this.txtMaNhanVien.Size = new System.Drawing.Size(226, 22);
//            this.txtMaNhanVien.TabIndex = 5;
//            // 
//            // label9
//            // 
//            this.label9.AutoSize = true;
//            this.label9.Location = new System.Drawing.Point(23, 265);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(101, 16);
//            this.label9.TabIndex = 6;
//            this.label9.Text = "Số Điện Thoại : ";
//            // 
//            // label8
//            // 
//            this.label8.AutoSize = true;
//            this.label8.Location = new System.Drawing.Point(23, 226);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(50, 16);
//            this.label8.TabIndex = 6;
//            this.label8.Text = "Email : ";
//            // 
//            // label7
//            // 
//            this.label7.AutoSize = true;
//            this.label7.Location = new System.Drawing.Point(23, 186);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(82, 16);
//            this.label7.TabIndex = 6;
//            this.label7.Text = "Trạng Thái : ";
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Location = new System.Drawing.Point(23, 146);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(59, 16);
//            this.label6.TabIndex = 6;
//            this.label6.Text = "Ca Làm :";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(23, 107);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(62, 16);
//            this.label5.TabIndex = 6;
//            this.label5.Text = "Chức Vụ :";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(23, 68);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(61, 16);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "Họ Tên : ";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(23, 31);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(97, 16);
//            this.label3.TabIndex = 5;
//            this.label3.Text = "Mã Nhân Viên :";
//            // 
//            // pictureBoxAnhDaiDien
//            // 
//            this.pictureBoxAnhDaiDien.Location = new System.Drawing.Point(490, 72);
//            this.pictureBoxAnhDaiDien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.pictureBoxAnhDaiDien.Name = "pictureBoxAnhDaiDien";
//            this.pictureBoxAnhDaiDien.Size = new System.Drawing.Size(252, 238);
//            this.pictureBoxAnhDaiDien.TabIndex = 2;
//            this.pictureBoxAnhDaiDien.TabStop = false;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(490, 54);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(87, 16);
//            this.label2.TabIndex = 3;
//            this.label2.Text = "Ảnh Đại Diện ";
//            // 
//            // btnChonAnh
//            // 
//            this.btnChonAnh.Location = new System.Drawing.Point(622, 315);
//            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnChonAnh.Name = "btnChonAnh";
//            this.btnChonAnh.Size = new System.Drawing.Size(120, 23);
//            this.btnChonAnh.TabIndex = 4;
//            this.btnChonAnh.Text = "Chọn Ảnh ...";
//            this.btnChonAnh.UseVisualStyleBackColor = true;
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.btnChamCong);
//            this.panel1.Controls.Add(this.btnHuy);
//            this.panel1.Controls.Add(this.btnLuu);
//            this.panel1.Controls.Add(this.btnXoa);
//            this.panel1.Controls.Add(this.btnSua);
//            this.panel1.Controls.Add(this.btnThemMoi);
//            this.panel1.Location = new System.Drawing.Point(12, 389);
//            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(755, 53);
//            this.panel1.TabIndex = 5;
//            // 
//            // btnChamCong
//            // 
//            this.btnChamCong.Location = new System.Drawing.Point(636, 15);
//            this.btnChamCong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnChamCong.Name = "btnChamCong";
//            this.btnChamCong.Size = new System.Drawing.Size(94, 23);
//            this.btnChamCong.TabIndex = 6;
//            this.btnChamCong.Text = "Chấm Công";
//            this.btnChamCong.UseVisualStyleBackColor = true;
//            // 
//            // btnHuy
//            // 
//            this.btnHuy.Location = new System.Drawing.Point(512, 15);
//            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnHuy.Name = "btnHuy";
//            this.btnHuy.Size = new System.Drawing.Size(94, 23);
//            this.btnHuy.TabIndex = 6;
//            this.btnHuy.Text = "Hủy";
//            this.btnHuy.UseVisualStyleBackColor = true;
//            // 
//            // btnLuu
//            // 
//            this.btnLuu.Location = new System.Drawing.Point(389, 15);
//            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnLuu.Name = "btnLuu";
//            this.btnLuu.Size = new System.Drawing.Size(94, 23);
//            this.btnLuu.TabIndex = 6;
//            this.btnLuu.Text = "Lưu";
//            this.btnLuu.UseVisualStyleBackColor = true;
//            // 
//            // btnXoa
//            // 
//            this.btnXoa.Location = new System.Drawing.Point(266, 15);
//            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnXoa.Name = "btnXoa";
//            this.btnXoa.Size = new System.Drawing.Size(94, 23);
//            this.btnXoa.TabIndex = 6;
//            this.btnXoa.Text = "Xóa";
//            this.btnXoa.UseVisualStyleBackColor = true;
//            // 
//            // btnSua
//            // 
//            this.btnSua.Location = new System.Drawing.Point(144, 15);
//            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnSua.Name = "btnSua";
//            this.btnSua.Size = new System.Drawing.Size(94, 23);
//            this.btnSua.TabIndex = 6;
//            this.btnSua.Text = "Sửa";
//            this.btnSua.UseVisualStyleBackColor = true;
//            // 
//            // btnThemMoi
//            // 
//            this.btnThemMoi.Location = new System.Drawing.Point(22, 15);
//            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnThemMoi.Name = "btnThemMoi";
//            this.btnThemMoi.Size = new System.Drawing.Size(94, 23);
//            this.btnThemMoi.TabIndex = 0;
//            this.btnThemMoi.Text = "Thêm Mới ";
//            this.btnThemMoi.UseVisualStyleBackColor = true;
//            // 
//            // label10
//            // 
//            this.label10.AutoSize = true;
//            this.label10.Location = new System.Drawing.Point(12, 370);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(73, 16);
//            this.label10.TabIndex = 6;
//            this.label10.Text = "Chức Năng";
//            // 
//            // dgvNhanVien
//            // 
//            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvNhanVien.Location = new System.Drawing.Point(12, 462);
//            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.dgvNhanVien.Name = "dgvNhanVien";
//            this.dgvNhanVien.RowHeadersWidth = 51;
//            this.dgvNhanVien.Size = new System.Drawing.Size(755, 273);
//            this.dgvNhanVien.TabIndex = 7;
//            // 
//            // NhanVien
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(786, 751);
//            this.Controls.Add(this.dgvNhanVien);
//            this.Controls.Add(this.label10);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.btnChonAnh);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.pictureBoxAnhDaiDien);
//            this.Controls.Add(this.groupBox1);
//            this.Controls.Add(this.label1);
//            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.Name = "NhanVien";
//            this.Text = "Quản lý thông tin nhân Viên";
//            this.groupBox1.ResumeLayout(false);
//            this.groupBox1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnhDaiDien)).EndInit();
//            this.panel1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private Label label1;
//        private GroupBox groupBox1;
//        private PictureBox pictureBoxAnhDaiDien;
//        private TextBox txtSoDienThoai;
//        private TextBox txtEmail;
//        private TextBox txtHoTen;
//        private TextBox txtMaNhanVien;
//        private Label label9;
//        private Label label8;
//        private Label label7;
//        private Label label6;
//        private Label label5;
//        private Label label4;
//        private Label label3;
//        private Label label2;
//        private Button btnChonAnh;
//        private ComboBox cboTrangThai;
//        private ComboBox cboCaLam;
//        private ComboBox cboChucVu;
//        private Panel panel1;
//        private Button btnChamCong;
//        private Button btnHuy;
//        private Button btnLuu;
//        private Button btnXoa;
//        private Button btnSua;
//        private Button btnThemMoi;
//        private Label label10;
//        private DataGridView dgvNhanVien;
//    }
//}