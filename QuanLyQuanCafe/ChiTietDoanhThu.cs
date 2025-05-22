using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoanhThuCF
{
    public class ChiTietDoanhThu
    {
        public string MaChiTiet { get; set; }
        public DateTime Ngay { get; set; }
        public string MaMon { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string GhiChu { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }

}
