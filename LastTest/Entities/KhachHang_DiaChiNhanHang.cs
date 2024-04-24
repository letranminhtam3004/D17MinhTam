using System.ComponentModel.DataAnnotations;

namespace LastTest.Entities
{
    public class KhachHang_DiaChiNhanHang
    {
        [Key]
        public decimal IDDiaChiNhanHang { get; set; }
        public decimal IDKhachHang { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public string DienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? MaBang { get; set; }
        public string? MaQuocGia { get; set; }
        public string? ThanhPho { get; set; }
        public string? TenQuocGia { get; set; }
        public bool? MacDinh { get; set; }
        public string? TenBang { get; set; }
        public string? TenQuan { get; set; }
        public DateTime? NgayHeThong { get; set; }
    }
}
