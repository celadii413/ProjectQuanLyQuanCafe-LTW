namespace QuanLyQuanCafe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        [Key]
        [StringLength(20)]
        public string MaDoanhThu { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [Column("DoanhThu")]
        public decimal? DoanhThu1 { get; set; }

        [StringLength(255)]
        public string GhiChuDT { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
