using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    partial class XuatKho
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            label9 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            dataGridView1 = new DataGridView();
            label10 = new Label();
            textBox6 = new TextBox();
            button7 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 9);
            label1.Name = "label1";
            label1.Size = new Size(425, 38);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Xuất Kho Nguyên Liệu";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(22, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 353);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Phiếu Xuất Kho";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 41);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Xuất Phiếu : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 82);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 2;
            label3.Text = "Nguyên Liệu :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 130);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 2;
            label4.Text = "Số Lượng Xuất : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 176);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 3;
            label5.Text = "Ngày Xuất :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 221);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 2;
            label6.Text = "Ghi Chú : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 263);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 2;
            label7.Text = "Mã Hóa Đơn : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 310);
            label8.Name = "label8";
            label8.Size = new Size(97, 20);
            label8.TabIndex = 3;
            label8.Text = "Mã Yêu Cầu : ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 38);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(289, 27);
            textBox2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(162, 123);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(289, 27);
            numericUpDown1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(162, 79);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(288, 82);
            label9.Name = "label9";
            label9.Size = new Size(64, 20);
            label9.TabIndex = 2;
            label9.Text = "SL Tồn : ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(358, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(93, 27);
            textBox1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(162, 169);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(289, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 214);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(289, 27);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(162, 260);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(289, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(162, 307);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(289, 27);
            textBox5.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(22, 441);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Tạo Mới";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(184, 441);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Sửa ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(348, 441);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "Xóa ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(518, 441);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Lưu";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(689, 441);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "Hủy";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(856, 441);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 7;
            button6.Text = "In Phiếu";
            button6.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(540, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(410, 300);
            dataGridView1.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(540, 78);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 9;
            label10.Text = "Tìm Kiếm";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 9F);
            textBox6.Location = new Point(618, 75);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(229, 27);
            textBox6.TabIndex = 10;
            // 
            // button7
            // 
            button7.Location = new Point(853, 75);
            button7.Name = "button7";
            button7.Size = new Size(97, 27);
            button7.TabIndex = 11;
            button7.Text = "Search";
            button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 502);
            Controls.Add(button7);
            Controls.Add(textBox6);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label9;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private DataGridView dataGridView1;
        private Label label10;
        private TextBox textBox6;
        private Button button7;
    }
}