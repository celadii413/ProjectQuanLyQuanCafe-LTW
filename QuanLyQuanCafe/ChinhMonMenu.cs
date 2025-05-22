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
    public partial class ChinhMonMenu : Form
    {
        QuanCafeDB db = new QuanCafeDB();

        public ChinhMonMenu()
        {
            InitializeComponent();
        }

        private void ChinhMonMenu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];
                txtMaMon.Text = row.Cells["MaMon"].Value.ToString();
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtLoaiMon.Text = row.Cells["LoaiMon"].Value.ToString();

                txtMaMon.Enabled = false;
            }
        }

        private void LoadData()
        {
            dgvThucDon.DataSource = db.MenuThucDons
                                  .Select(m => new { m.MaMon, m.TenMon, m.DonGia, m.LoaiMon })
                                  .ToList();

            dgvThucDon.Columns[0].HeaderText = "Mã món";
            dgvThucDon.Columns[1].HeaderText = "Tên món";
            dgvThucDon.Columns[2].HeaderText = "Đơn giá";
            dgvThucDon.Columns[3].HeaderText = "Loại món";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            if (db.MenuThucDons.Any(m => m.MaMon == ma))
            {
                MessageBox.Show("Mã món đã tồn tại!");
                return;
            }

            var mon = new MenuThucDon()
            {
                MaMon = ma,
                TenMon = txtTenMon.Text.Trim(),
                DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                LoaiMon = txtLoaiMon.Text.Trim()
            };

            db.MenuThucDons.Add(mon);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Đã thêm món thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            var mon = db.MenuThucDons.FirstOrDefault(m => m.MaMon == ma);
            if (mon == null)
            {
                MessageBox.Show("Không tìm thấy món!");
                return;
            }

            mon.TenMon = txtTenMon.Text.Trim();
            mon.DonGia = decimal.Parse(txtDonGia.Text.Trim());
            mon.LoaiMon = txtLoaiMon.Text.Trim();

            db.SaveChanges();
            LoadData();
            MessageBox.Show("Đã cập nhật món!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            var mon = db.MenuThucDons.FirstOrDefault(m => m.MaMon == ma);
            if (mon == null)
            {
                MessageBox.Show("Không tìm thấy món!");
                return;
            }

            db.MenuThucDons.Remove(mon);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Đã xóa món!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtDonGia.Clear();
            txtLoaiMon.Clear();

            txtMaMon.Enabled = true;
        }

    }
}
