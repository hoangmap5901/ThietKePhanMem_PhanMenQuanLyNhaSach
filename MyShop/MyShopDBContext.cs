using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyShop
{
    public partial class MyShopDBContext : DbContext
    {
        public MyShopDBContext()
        {
        }

        public MyShopDBContext(DbContextOptions<MyShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Trusted_Connection=Yes; Initial Catalog=MyShopDB; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.ChiTietDonHangId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChiTietDonHangID");

                entity.Property(e => e.DonHangId).HasColumnName("DonHang_ID");

                entity.Property(e => e.SachId).HasColumnName("Sach_ID");

                entity.HasOne(d => d.DonHang)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.DonHangId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.Sach)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.SachId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ChiTietDonHang_Sach");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");

                entity.Property(e => e.DonHangId).HasColumnName("DonHangID");

                entity.Property(e => e.KhachHangId).HasColumnName("KhachHang_ID");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.TrangThaiDonHangId).HasColumnName("TrangThaiDonHang_ID");

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.TrangThaiDonHang)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.TrangThaiDonHangId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DonHang_TrangThaiDonHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.ImagePath).HasMaxLength(200);

                entity.Property(e => e.SoDienThoai).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(200);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.ToTable("Sach");

                entity.Property(e => e.SachId).HasColumnName("SachID");

                entity.Property(e => e.ImagePath).HasMaxLength(200);

                entity.Property(e => e.TacGia).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(200);

                entity.Property(e => e.TheLoaiId).HasColumnName("TheLoai_ID");

                entity.HasOne(d => d.TheLoai)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.TheLoaiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Sach_Sach");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoanID");

                entity.Property(e => e.MatKhau).HasMaxLength(200);

                entity.Property(e => e.TenDangNhap).HasMaxLength(200);

                entity.Property(e => e.VaiTro).HasMaxLength(200);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.ToTable("TheLoai");

                entity.Property(e => e.TheLoaiId).HasColumnName("TheLoaiID");

                entity.Property(e => e.Ten).HasMaxLength(200);
            });

            modelBuilder.Entity<TrangThaiDonHang>(entity =>
            {
                entity.ToTable("TrangThaiDonHang");

                entity.Property(e => e.TrangThaiDonHangId).HasColumnName("TrangThaiDonHangID");

                entity.Property(e => e.ChuHienThi).HasMaxLength(200);

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.TrangThai).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
