using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;

namespace QuanLyQuanCafe
{
    public partial class ChamCong : Form
    {
        private QuanCafeDB db = new QuanCafeDB();
        public ChamCong()
        {
            InitializeComponent();
            dgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChamCong.AllowUserToAddRows = false;
            LoadChamCongData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadChamCongData();
        }

        private void LoadChamCongData()
        {
            dgvChamCong.DataSource = db.ChamCongs
                .Select(c => new
                {
                    c.MaChamCong,
                    c.MaNV,
                    c.NgayLamViec,
                    GioVao = c.GioVaoCC,
                    GioRa = c.GioRaCC,
                    c.CaLam,
                    c.GhiChuCC
                }).ToList();
        }
        private void ClearForm()
        {
            txtMaChamCong.Clear();
            txtMaNV.Clear();
            txtGioVao.Clear();
            txtGioRa.Clear();
            //txtCaLam.Clear();
            //txtGhiChu.Clear();
            dtpNgayLamViec.Value = DateTime.Today;
            btnLuu.Enabled = true;
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChamCong.Rows[e.RowIndex];
                txtMaChamCong.Text = row.Cells["MaChamCong"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                dtpNgayLamViec.Value = (DateTime)row.Cells["NgayLamViec"].Value;
                txtGioVao.Text = ((DateTime)row.Cells["GioVao"].Value).ToString("HH:mm:ss");
                txtGioRa.Text = ((DateTime)row.Cells["GioRa"].Value).ToString("HH:mm:ss");
                //txtCaLam.Text = row.Cells["CaLam"].Value.ToString();
                //txtGhiChu.Text = row.Cells["GhiChuCC"].Value.ToString();
                btnLuu.Enabled = false;
            }
        }

        private void btnGioVao_Click(object sender, EventArgs e)
        {
            txtGioVao.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnGioRa_Click(object sender, EventArgs e)
        {
            txtGioRa.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maChamCong = txtMaChamCong.Text.Trim();
            if (db.ChamCongs.Any(c => c.MaChamCong == maChamCong))
            {
                MessageBox.Show("Mã chấm công đã tồn tại!");
                return;
            }

            QuanLyQuanCafe.Models.ChamCong cc = new QuanLyQuanCafe.Models.ChamCong()
            {
                MaChamCong = maChamCong,
                MaNV = txtMaNV.Text.Trim(),
                NgayLamViec = dtpNgayLamViec.Value.Date,
                GioVaoCC = DateTime.Parse($"{dtpNgayLamViec.Value:yyyy-MM-dd} {txtGioVao.Text.Trim()}"),
                GioRaCC = DateTime.Parse($"{dtpNgayLamViec.Value:yyyy-MM-dd} {txtGioRa.Text.Trim()}")
                //CaLam = txtCaLam.Text.Trim(),
                //GhiChuCC = txtGhiChu.Text.Trim()
            };

            db.ChamCongs.Add(cc);
            db.SaveChanges();
            MessageBox.Show("Đã thêm thành công!");
            LoadChamCongData();
            ClearForm();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            string maChamCong = txtMaChamCong.Text.Trim();
            var cc = db.ChamCongs.FirstOrDefault(c => c.MaChamCong == maChamCong);
            if (cc == null)
            {
                MessageBox.Show("Không tìm thấy mã chấm công!");
                return;
            }

            cc.MaNV = txtMaNV.Text.Trim();
            cc.NgayLamViec = dtpNgayLamViec.Value.Date;
            cc.GioVaoCC = DateTime.Parse(dtpNgayLamViec.Value.ToShortDateString() + " " + txtGioVao.Text.Trim());
            cc.GioRaCC = DateTime.Parse(dtpNgayLamViec.Value.ToShortDateString() + " " + txtGioRa.Text.Trim());
            //cc.CaLam = txtCaLam.Text.Trim();
            //cc.GhiChuCC = txtGhiChu.Text.Trim();

            db.SaveChanges();
            MessageBox.Show("Đã cập nhật thành công!");
            LoadChamCongData();
            ClearForm();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChamCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChamCong.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvChamCong.Rows[e.RowIndex];
                txtMaChamCong.Text = selectedRow.Cells["MaChamCong"].Value?.ToString();
                txtMaNV.Text = selectedRow.Cells["MaNV"].Value?.ToString();
                if (selectedRow.Cells["NgayLamViec"].Value != DBNull.Value && selectedRow.Cells["NgayLamViec"].Value is DateTime)
                {
                    dtpNgayLamViec.Value = ((DateTime)selectedRow.Cells["NgayLamViec"].Value).Date;
                }
                else
                {
                    dtpNgayLamViec.Value = DateTime.Today;
                }

                if (selectedRow.Cells["GioVao"].Value != DBNull.Value && selectedRow.Cells["GioVao"].Value is DateTime)
                {
                    DateTime gioVaoDT = (DateTime)selectedRow.Cells["GioVao"].Value;
                    txtGioVao.Text = gioVaoDT.ToString("HH:mm:ss");
                }
                else
                {
                    txtGioVao.Text = "";
                }

                if (selectedRow.Cells["GioRa"].Value != DBNull.Value && selectedRow.Cells["GioRa"].Value is DateTime)
                {
                    DateTime gioRaDT = (DateTime)selectedRow.Cells["GioRa"].Value;
                    txtGioRa.Text = gioRaDT.ToString("HH:mm:ss");
                }
                else
                {
                    txtGioRa.Text = "";
                }
                btnLuu.Enabled = false;
            }
            else
            {
                ClearForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maChamCong = txtMaChamCong.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maChamCong) || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(txtGioRa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Chấm Công, Mã NV và Giờ Ra!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chamCong = db.ChamCongs.FirstOrDefault(c => c.MaChamCong == maChamCong && c.MaNV == maNV);
            if (chamCong == null)
            {
                MessageBox.Show("Không tìm thấy bản ghi để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime gioRa;
            if (!DateTime.TryParseExact($"{dtpNgayLamViec.Value:yyyy-MM-dd} {txtGioRa.Text}", "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out gioRa))
            {
                MessageBox.Show("Giờ Ra không đúng định dạng (HH:mm:ss)!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gioRa <= chamCong.GioVaoCC)
            {
                MessageBox.Show("Giờ Ra phải sau Giờ Vào!", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chamCong.GioRaCC = gioRa;
            db.SaveChanges();
            MessageBox.Show("Đã cập nhật Giờ Ra thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadChamCongData();
            ClearForm();
        }

    }
}
