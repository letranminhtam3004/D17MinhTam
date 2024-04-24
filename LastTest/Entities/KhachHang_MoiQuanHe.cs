using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastTest.Entities
{
    public class KhachHang_MoiQuanHe
    {
        [Key]
        public int ID { get; set; }
        public int IDKhachHang { get; set; }
        public string? MoiQuanHe { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public DateTime? NgayHeThong { get; set; }
    }
}
