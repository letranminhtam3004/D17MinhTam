using System.ComponentModel.DataAnnotations;

namespace LastTest.Entities
{
    public class ChiPhi
    {
        [Key]
        public decimal IDChiPhi { get; set; }
        public DateTime NgayPhatSinh { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
        public decimal IDNguoiNhap { get; set; }
        public DateTime NgayHeThong { get; set; }
        public short IDLoaiChiPhi { get; set; }
    }
}
