using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyQuanCafe.Models
{
    public partial class QuanCafeDB : DbContext
    {
        public QuanCafeDB()
            : base("name=QuanCafeDB")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<MenuThucDon> MenuThucDons { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .Property(e => e.MaBan)
                .IsUnicode(false);

            modelBuilder.Entity<Ban>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.Ban)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.MaChamCong)
                .IsUnicode(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.MaDoanhThu)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.DoanhThu1)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaBan)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.DoanhThus)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuThucDon>()
                .Property(e => e.MaMon)
                .IsUnicode(false);

            modelBuilder.Entity<MenuThucDon>()
                .Property(e => e.DonGia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MenuThucDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.MenuThucDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChamCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MaTK)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaMon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.DonGia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(21, 2);
        }
    }
}
