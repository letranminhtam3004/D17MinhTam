﻿using Microsoft.EntityFrameworkCore;

namespace LastTest.Entities
{
    public class MyDbContext :DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<ChiPhi> ChiPhi { get; set; }
        public DbSet<CuaHang> CuaHang { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DonHang_SanPham>DonHang_SanPham { get; set; }
        public DbSet<KhachHang_DiaChiNhanHang> khachHang_DiaChiNhanHang { get; set; }
        public DbSet<KhachHang_MoiQuanHe> khachHang_MoiQuanHe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang_SanPham>()
                .HasKey(dhsp => new { dhsp.IDDonHang, dhsp.IDSanPham });


            //modelBuilder.Entity<KhachHang>()
            //   .Property(kh=>kh.IDKhachHang)
            //   .HasDefaultValue(modelBuilder.Entity<DonHang_SanPham>());
        }

        
    }
}
