using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastTest.Entities
{
    public class DonHang
    {
        [Key]
        public decimal IDDonHang { get; set; }
        public string MaDonHang { get; set; }
        public string? MaDonChung { get; set; }
        public decimal? IDNguoiTaoDon { get; set; }
        public decimal? IDKhachHang { get; set; }
        public string? HoTenNguoiNhan { get; set; }
        public string? DiaChiNhan { get; set; }
        public string? ThanhPhoNhan { get; set; }
        public string? MaBangNhan { get; set; }
        public string? TenQuocGiaNhan { get; set; }
        public string? MaQuocGiaNhan { get; set; }
        public string? TenBangNhan { get; set; }
        public string? TenQuanNhan { get; set; }
        public string? DienThoaiKhachHang { get; set; }
        public string? DienThoaiNguoiNhan { get; set; }
        public byte? HinhThucNhanHang { get; set; }
        public byte? HinhThucThanhToan { get; set; }
        public string? GhiChu { get; set; }
        public Int16? TongSoLuong { get; set; }
        public decimal? TongSoTien { get; set; }
        public decimal? TongTienDichVuCongThem { get; set; }
        public decimal? VAT { get; set; }
        public string? MaGiamGia { get; set; }
        public decimal? SoTienGiam { get; set; }
        public decimal? PhiShip { get; set; }
        public decimal? TongSoTienThanhToan { get; set; }
        public decimal? IDNguoiCapNhat { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime? NgayGiaoHangDuKien { get; set; }
        public decimal? SoTienGiamTrenSanPham { get; set; }
        public DateTime? NgayHeThong { get; set; }
        public Int32? IDTrangThaiHienTai { get; set; }
        public string? LoaiDonHang { get; set; }
        public string? TenCuaHang { get; set; }
        [NotMapped]
        public decimal IDCuaHang { get; internal set; }
        [NotMapped]
        public object DonHang_SanPham { get; internal set; }
    }
}
