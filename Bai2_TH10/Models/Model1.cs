using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bai2_TH10.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_ChiTiet> tbl_ChiTiet { get; set; }
        public virtual DbSet<tbl_HoaDon> tbl_HoaDon { get; set; }
        public virtual DbSet<tbl_KhachHang> tbl_KhachHang { get; set; }
        public virtual DbSet<tbl_SanPham> tbl_SanPham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_ChiTiet>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ChiTiet>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .HasMany(e => e.tbl_ChiTiet)
                .WithRequired(e => e.tbl_HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SanPham>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_SanPham>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_SanPham>()
                .HasMany(e => e.tbl_ChiTiet)
                .WithRequired(e => e.tbl_SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
