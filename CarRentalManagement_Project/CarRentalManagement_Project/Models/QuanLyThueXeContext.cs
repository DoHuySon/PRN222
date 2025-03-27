using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement_Project.Models;

public partial class QuanLyThueXeContext : DbContext
{
    public QuanLyThueXeContext()
    {
    }

    public QuanLyThueXeContext(DbContextOptions<QuanLyThueXeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoHiem> BaoHiems { get; set; }

    public virtual DbSet<DonThueXe> DonThueXes { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiXe> LoaiXes { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyStockDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoHiem>(entity =>
        {
            entity.HasKey(e => e.MaBaoHiem).HasName("PK__BaoHiem__AACE9D887BF56C15");

            entity.ToTable("BaoHiem");

            entity.Property(e => e.LoaiBaoHiem).HasMaxLength(100);
            entity.Property(e => e.MucPhiBaoHiem).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaDonThueNavigation).WithMany(p => p.BaoHiems)
                .HasForeignKey(d => d.MaDonThue)
                .HasConstraintName("FK__BaoHiem__MaDonTh__4E88ABD4");
        });

        modelBuilder.Entity<DonThueXe>(entity =>
        {
            entity.HasKey(e => e.MaDonThue).HasName("PK__DonThueX__DC63E095C54FB8D6");

            entity.ToTable("DonThueXe");

            entity.HasIndex(e => e.TinhTrang, "IX_DonThueXe_TinhTrang");

            entity.Property(e => e.DiaDiemNhanXe).HasMaxLength(255);
            entity.Property(e => e.DiaDiemTraXe).HasMaxLength(255);
            entity.Property(e => e.TinhTrang).HasMaxLength(20);
            entity.Property(e => e.TongGiaThue).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DonThueXes)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DonThueXe__MaKha__4316F928");

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.DonThueXes)
                .HasForeignKey(d => d.MaXe)
                .HasConstraintName("FK__DonThueXe__MaXe__440B1D61");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E560BBABF8");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Email, "UQ__KhachHan__A9D105346849EF28").IsUnique();

            entity.HasIndex(e => e.SoCmnd, "UQ__KhachHan__F5EEA1C682089AC6").IsUnique();

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(20)
                .HasColumnName("SoCMND");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
        });

        modelBuilder.Entity<LoaiXe>(entity =>
        {
            entity.HasKey(e => e.MaLoaiXe).HasName("PK__LoaiXe__122512B59AA54BEB");

            entity.ToTable("LoaiXe");

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenLoaiXe).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47A7C96C2B");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Email, "UQ__NhanVien__A9D105343AB25CC6").IsUnique();

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__D4B258440ADE8F13");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTienThanhToan).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(20);

            entity.HasOne(d => d.MaDonThueNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaDonThue)
                .HasConstraintName("FK__ThanhToan__MaDon__4AB81AF0");
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.MaXe).HasName("PK__Xe__272520CDFAA94BBB");

            entity.ToTable("Xe");

            entity.HasIndex(e => e.TrangThai, "IX_Xe_TrangThai");

            entity.HasIndex(e => e.BienSoXe, "UQ__Xe__A78059927D9A7088").IsUnique();

            entity.Property(e => e.BienSoXe).HasMaxLength(20);
            entity.Property(e => e.GiaThueMotNgay).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HangXe).HasMaxLength(50);
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MauXe).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.MaLoaiXeNavigation).WithMany(p => p.Xes)
                .HasForeignKey(d => d.MaLoaiXe)
                .HasConstraintName("FK__Xe__MaLoaiXe__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
