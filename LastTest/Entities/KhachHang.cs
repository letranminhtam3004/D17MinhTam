﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastTest.Entities
{
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDKhachHang { get; set; } //dsad
        public decimal? IDLoaiThe { get; set; }
        public string? MaThe { get; set; }
        public string? DanhXung { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public string DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? ThanhPho { get; set; }
        public string? MaBang { get; set; }
        public string? MaQuocGia { get; set; }
        public string? TenQuocGia { get; set; }
        public string? TenBang { get; set; }
        public string? TenQuan { get; set; }
        public string? Email { get; set; }
        public string? CMND { get; set; }
        public DateTime? NgaySinhNhat { get; set; }
        public byte? GhiNo { get; set; }
        public byte? NhanEmail { get; set; }
        public byte? IsUse { get; set; }

        public DateTime? NgayHeThong { get; set; }
        
        public int? GioiTinh { get; set; }
        public string? GhiChu { get; set; }
    }
}