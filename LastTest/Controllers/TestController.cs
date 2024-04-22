using LastTest.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LastTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TestController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("CuaHang")]
        public async Task<IActionResult> GetCuaHangs()
        {
            try
            {
                var cuaHangs = await _context.DonHang.Take(10).ToListAsync();
                return Ok(cuaHangs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet("DonHangSanPham")]
        public async Task<IActionResult> GetDonHangSanPham()
        {
            try
            {
                var donHangs = await _context.DonHang_SanPham.Take(10).ToListAsync();
                return Ok(donHangs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



        [HttpPost("DoanhThuTheoNam111")]
        public ActionResult<IEnumerable<BaoCaoTongDoanhThu>> GetBaoCaoTongDoanhThu111(string tungay, string denngay, string listidcuahang = null) //xem lai 
        {
            try
            {
                tungay += " 00:00:00";
                denngay += " 23:59:59";
                DateTime fromDate, toDate;
                if (!DateTime.TryParse(tungay, out fromDate) || !DateTime.TryParse(denngay, out toDate))
                {
                    return BadRequest("Invalid date format.");
                }
                var result = _context.CuaHang.Select(c => new BaoCaoTongDoanhThu
                {
                    TenCuaHang = c.TenCuaHang,
                    IDCuaHang = c.IDCuaHang,
                    //SoLuong1 = _context.DonHang_SanPham
                    //    .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == c.IDCuaHang && d.NgayDatHang.Month == 1))
                    //    .Sum(ds => ds.SoLuong),

                    SoLuong1 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 1
                        && d.IDTrangThaiHienTai!=7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong2 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 2
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong3 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 3 
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong4 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 4 
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong5 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 5 
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong6 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 6 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong7 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 7 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong8 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 8 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong9 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 9 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong10 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 10 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong11 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 11 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),

                    SoLuong12 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 12 && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.SoLuong),



                   
                    DoanhThu1 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 1
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu2 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 2
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu3 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 3
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu4 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 4
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu5 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 5
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu6 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 6
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu7 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 7
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu8 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 8
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu9 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 9
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu10 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 10
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu11 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 11
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                    DoanhThu12 = _context.DonHang_SanPham
                        .Where(ds => _context.DonHang.Any(d => d.IDDonHang == ds.IDDonHang && d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate && d.IDDonHang == ds.IDDonHang && d.NgayDatHang.Month == 12
                        && d.IDTrangThaiHienTai != 7))
                        .Where(ds => _context.SanPham.Any(s => s.IDSanPham == ds.IDSanPham))
                        .Sum(ds => ds.ThanhTien),

                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        


        [HttpPost("DoanhThuTheoNam2111")]  
        public ActionResult<IEnumerable<BaoCaoTongDoanhThu>> GetBaoCaoTongDoanhThu4111(string tungay, string denngay, string listidcuahang = "all")
        {
            try
            {
                tungay += " 00:00:00";
                denngay += " 23:59:59";
                DateTime fromDate, toDate;
                if (!DateTime.TryParse(tungay, out fromDate) || !DateTime.TryParse(denngay, out toDate))
                {
                    return BadRequest("Invalid date format.");
                }
                var list = (from kh in _context.KhachHang
                            join d in _context.DonHang on kh.IDKhachHang equals d.IDKhachHang
                            join ds in _context.DonHang_SanPham on d.IDDonHang equals ds.IDDonHang
                            join s in _context.SanPham on ds.IDSanPham equals s.IDSanPham

                            where d.NgayDatHang >= fromDate && d.NgayDatHang <= toDate
                                && d.IDTrangThaiHienTai != 7
                            group new { s.IDCuaHang, d.HinhThucThanhToan, Thang = d.NgayDatHang.Month, ds.SoLuong, ds.ThanhTien }
                            by new { s.IDCuaHang, d.HinhThucThanhToan, Thang = d.NgayDatHang.Month } into grouped
                            select new
                            {
                                IDCuaHang = grouped.Key.IDCuaHang,
                                HinhThucThanhToan = grouped.Key.HinhThucThanhToan,
                                Thang = grouped.Key.Thang,
                                SoLuong = grouped.Sum(x => x.SoLuong),
                                ThanhTien = grouped.Sum(x => x.ThanhTien)
                            }
                           ).ToList();
                if (listidcuahang == "all")
                {
                    var result = new BaoCaoTongDoanhThu
                    {
                        SoLuong1 = list.Where(x => x.Thang == 1).Sum(x=>x.SoLuong),
                        SoLuong2 = list.Where(x => x.Thang == 2).Sum(x=>x.SoLuong),
                        SoLuong3 = list.Where(x => x.Thang == 3).Sum(x=>x.SoLuong),
                        SoLuong4 = list.Where(x => x.Thang == 4).Sum(x=>x.SoLuong),
                        SoLuong5 = list.Where(x => x.Thang == 5).Sum(x=>x.SoLuong),
                        SoLuong6 = list.Where(x => x.Thang == 6).Sum(x=>x.SoLuong),
                        SoLuong7 = list.Where(x => x.Thang == 7).Sum(x=>x.SoLuong),
                        SoLuong8 = list.Where(x => x.Thang == 8).Sum(x=>x.SoLuong),
                        SoLuong9 = list.Where(x => x.Thang == 9).Sum(x=>x.SoLuong),
                        SoLuong10 = list.Where(x => x.Thang == 10).Sum(x=>x.SoLuong),
                        SoLuong11 = list.Where(x => x.Thang == 11).Sum(x=>x.SoLuong),
                        SoLuong12 = list.Where(x => x.Thang == 12).Sum(x=>x.SoLuong),
                        DoanhThu1 = list.Where(x => x.Thang == 1).Sum(x=>x.ThanhTien ),
                        DoanhThu2 = list.Where(x => x.Thang == 2).Sum(x=>x.ThanhTien ),
                        DoanhThu3 = list.Where(x => x.Thang == 3).Sum(x=>x.ThanhTien ),
                        DoanhThu4 = list.Where(x => x.Thang == 4).Sum(x=>x.ThanhTien ),
                        DoanhThu5 = list.Where(x => x.Thang == 5).Sum(x=>x.ThanhTien ),
                        DoanhThu6 = list.Where(x => x.Thang == 6).Sum(x=>x.ThanhTien ),
                        DoanhThu7 = list.Where(x => x.Thang == 7).Sum(x=>x.ThanhTien ),
                        DoanhThu8 = list.Where(x => x.Thang == 8).Sum(x=>x.ThanhTien ),
                        DoanhThu9 = list.Where(x => x.Thang == 9).Sum(x=>x.ThanhTien ),
                        DoanhThu10 = list.Where(x => x.Thang == 10).Sum(x=>x.ThanhTien ),
                        DoanhThu11 = list.Where(x => x.Thang == 11).Sum(x=>x.ThanhTien ),
                        DoanhThu12 = list.Where(x => x.Thang == 12).Sum(x => x.ThanhTien)
                    };

                    return Ok(result);
                }



                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }
}

