using System.ComponentModel.DataAnnotations;

namespace LastTest.Entities
{
    public class SanPham
    {
        [Key]
        public decimal IDSanPham { get; set; }
        public string MaSanPham { get; set; }
        public int KhoiLuong { get; set; }
        public int Dai { get; set; }
        public int Rong { get; set; }
        public int Cao { get; set; }
        public string TenSanPham { get; set; }
        public decimal TriGia { get; set; }
        public decimal GiaBan { get; set; }
        public string GiaTriTienTe { get; set; }
        public float GiamGia { get; set; }
        public string MoTa { get; set; }
        public short SoLuong { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime NgayHetHan { get; set; }
        public short ThoiGianBaoHanh { get; set; }
        public decimal IDCuaHang { get; set; }
        public short IDDonViTinh { get; set; }
        public DateTime NgayTaoDauTien { get; set; }
        public decimal GiaSauGiam { get; set; }
        public decimal IDNguoiNhap { get; set; }
        public byte SanPhamTrucTuyen { get; set; }
    }
}
