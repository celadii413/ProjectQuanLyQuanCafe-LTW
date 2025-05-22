namespace QuanLyQuanCafe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        [StringLength(20)]
        public string MaChamCong { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLamViec { get; set; }

        public DateTime GioVaoCC { get; set; }

        public DateTime GioRaCC { get; set; }

        [Required]
        [StringLength(255)]
        public string GhiChuCC { get; set; }

        [Required]
        [StringLength(20)]
        public string CaLam { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
