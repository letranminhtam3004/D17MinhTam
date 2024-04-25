using LastTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LastTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly MyDbContext _context;

        public KhachHangController(MyDbContext context)
        {
            _context = context;
        }


        //public async Task<ActionResult<KhachHang>> CreateKhachHang111([FromBody] KhachHang khachHang, KhachHang_MoiQuanHe[] moiquanhes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _context.KhachHang.Add(khachHang);
        //    await _context.SaveChangesAsync();

        //    foreach (var moiquanhe in moiquanhes)  
        //    {
        //        moiquanhe.IDKhachHang = (int)khachHang.IDKhachHang;
        //        _context.khachHang_MoiQuanHe.Add(moiquanhe);
        //    }
        //    return Ok(khachHang);
        //}

        [HttpGet]
        public async Task<ActionResult<List<KhachHang>>> GetKhachHang()
        {
            return Ok(await _context.KhachHang.Take(10).ToListAsync());
        }
        [HttpGet("GetByID")]

        public async Task<ActionResult<KhachHang>> GetKhachHangById(decimal id)
        {
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return khachHang;
        }


        

        [HttpPost("TEST")]
        public async Task<ActionResult<KhachHang>> CreateKhachHang111([FromBody] KhachHangDTO khachHangDTO)
        {
            try
            {
                var khachHangWithoutId = new KhachHang
                {
                    IDLoaiThe = khachHangDTO.KhachHang.IDLoaiThe,
                    MaThe = khachHangDTO.KhachHang.MaThe,
                    DanhXung = khachHangDTO.KhachHang.DanhXung,
                    Ho = khachHangDTO.KhachHang.Ho,
                    Ten = khachHangDTO.KhachHang.Ten,
                    DienThoai = khachHangDTO.KhachHang.DienThoai,
                    DiaChi = khachHangDTO.KhachHang.DiaChi,
                    ThanhPho = khachHangDTO.KhachHang.ThanhPho,
                    MaBang = khachHangDTO.KhachHang.MaBang,
                    MaQuocGia = khachHangDTO.KhachHang.MaQuocGia,
                    TenQuocGia = khachHangDTO.KhachHang.TenQuocGia,
                    TenBang = khachHangDTO.KhachHang.TenBang,
                    TenQuan = khachHangDTO.KhachHang.TenQuan,
                    Email = khachHangDTO.KhachHang.Email,
                    CMND = khachHangDTO.KhachHang.CMND,
                    NgaySinhNhat = khachHangDTO.KhachHang.NgaySinhNhat,
                    GhiNo = khachHangDTO.KhachHang.GhiNo,
                    NhanEmail = khachHangDTO.KhachHang.NhanEmail,
                    IsUse = khachHangDTO.KhachHang.IsUse,
                    NgayHeThong = khachHangDTO.KhachHang.NgayHeThong,
                    GioiTinh = khachHangDTO.KhachHang.GioiTinh,
                    GhiChu = khachHangDTO.KhachHang.GhiChu
                };

                _context.KhachHang.Add(khachHangWithoutId);
                _context.SaveChanges();

                foreach (var moiQuanHe in khachHangDTO.MoiQuanHes)
                {
                    var qh = new KhachHang_MoiQuanHe
                    {
                        IDKhachHang = (int)khachHangWithoutId.IDKhachHang,
                        ID = moiQuanHe.ID,
                        MoiQuanHe = moiQuanHe.MoiQuanHe,
                        HoTen = moiQuanHe.HoTen,
                        NgaySinh = moiQuanHe.NgaySinh,
                        GioiTinh = moiQuanHe.GioiTinh,
                        NgayHeThong = moiQuanHe.NgayHeThong
                    };
                    _context.khachHang_MoiQuanHe.Add(qh);
                }
                await _context.SaveChangesAsync();

                return Ok("Customer and relationships added successfully!");
            }

            catch (DbUpdateException ex)
            {

                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return StatusCode(500, $"An error occurred while saving the entity changes. See the inner exception for details.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPost("daumoi")]
        public async Task<ActionResult<KhachHang>> CreateKhachHang2111([FromBody] KhachHangDTO khachHangDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Loại bỏ cột IDKhachHang ra khỏi danh sách các cột được chèn
                var khachHangWithoutId = new KhachHang
                {
                    IDLoaiThe = khachHangDTO.KhachHang.IDLoaiThe,
                    MaThe = khachHangDTO.KhachHang.MaThe,
                    DanhXung = khachHangDTO.KhachHang.DanhXung,
                    Ho = khachHangDTO.KhachHang.Ho,
                    Ten = khachHangDTO.KhachHang.Ten,
                    DienThoai = khachHangDTO.KhachHang.DienThoai,
                    DiaChi = khachHangDTO.KhachHang.DiaChi,
                    ThanhPho = khachHangDTO.KhachHang.ThanhPho,
                    MaBang = khachHangDTO.KhachHang.MaBang,
                    MaQuocGia = khachHangDTO.KhachHang.MaQuocGia,
                    TenQuocGia = khachHangDTO.KhachHang.TenQuocGia,
                    TenBang = khachHangDTO.KhachHang.TenBang,
                    TenQuan = khachHangDTO.KhachHang.TenQuan,
                    Email = khachHangDTO.KhachHang.Email,
                    CMND = khachHangDTO.KhachHang.CMND,
                    NgaySinhNhat = khachHangDTO.KhachHang.NgaySinhNhat,
                    GhiNo = khachHangDTO.KhachHang.GhiNo,
                    NhanEmail = khachHangDTO.KhachHang.NhanEmail,
                    IsUse = khachHangDTO.KhachHang.IsUse,
                    NgayHeThong = khachHangDTO.KhachHang.NgayHeThong,
                    GioiTinh = khachHangDTO.KhachHang.GioiTinh,
                    GhiChu = khachHangDTO.KhachHang.GhiChu
                };

                _context.KhachHang.Add(khachHangWithoutId);
                //_context.SaveChanges();

                foreach (var moiQuanHe in khachHangDTO.MoiQuanHes)
                {
                    var qh = new KhachHang_MoiQuanHe
                    {
                        IDKhachHang = (int)khachHangWithoutId.IDKhachHang,
                        ID = moiQuanHe.ID,
                        MoiQuanHe = moiQuanHe.MoiQuanHe,
                        HoTen = moiQuanHe.HoTen,
                        NgaySinh = moiQuanHe.NgaySinh,
                        GioiTinh = moiQuanHe.GioiTinh,
                        NgayHeThong = moiQuanHe.NgayHeThong
                    };
                    _context.khachHang_MoiQuanHe.Add(qh);
                }
                await _context.SaveChangesAsync();

                return Ok("Customer and relationships added successfully!");
            }

            catch (DbUpdateException ex)
            {

                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return StatusCode(500, $"An error occurred while saving the entity changes. See the inner exception for details.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("dsdsadsadsad")]
        public async Task<IActionResult> CreateCustomer([FromBody] KhachHangDTO khachHangDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate phone number
            if (!Regex.IsMatch(khachHangDTO.KhachHang.DienThoai, @"^0[1-9][0-9]{8}$"))
            {
                return BadRequest(new { Success = "00", Message = "Invalid Vietnamese phone number" });
            }

            // Check if phone number already exists
            var existingCustomer = await _context.KhachHang.FirstOrDefaultAsync(c => c.DienThoai == khachHangDTO.KhachHang.DienThoai);
            if (existingCustomer != null)
            {
                return BadRequest(new { Success = "00", Message = "Phone number already exists" });
            }

            
            var khachHangWithoutId = new KhachHang
            {
                IDLoaiThe = khachHangDTO.KhachHang.IDLoaiThe,
                MaThe = khachHangDTO.KhachHang.MaThe,
                DanhXung = khachHangDTO.KhachHang.DanhXung,
                Ho = khachHangDTO.KhachHang.Ho,
                Ten = khachHangDTO.KhachHang.Ten,
                DienThoai = khachHangDTO.KhachHang.DienThoai,
                DiaChi = khachHangDTO.KhachHang.DiaChi,
                ThanhPho = khachHangDTO.KhachHang.ThanhPho,
                MaBang = khachHangDTO.KhachHang.MaBang,
                MaQuocGia = khachHangDTO.KhachHang.MaQuocGia,
                TenQuocGia = khachHangDTO.KhachHang.TenQuocGia,
                TenBang = khachHangDTO.KhachHang.TenBang,
                TenQuan = khachHangDTO.KhachHang.TenQuan,
                Email = khachHangDTO.KhachHang.Email,
                CMND = khachHangDTO.KhachHang.CMND,
                NgaySinhNhat = khachHangDTO.KhachHang.NgaySinhNhat,
                GhiNo = khachHangDTO.KhachHang.GhiNo,
                NhanEmail = khachHangDTO.KhachHang.NhanEmail,
                IsUse = khachHangDTO.KhachHang.IsUse,
                NgayHeThong = khachHangDTO.KhachHang.NgayHeThong,
                GioiTinh = khachHangDTO.KhachHang.GioiTinh,
                GhiChu = khachHangDTO.KhachHang.GhiChu
            };

            _context.KhachHang.Add(khachHangWithoutId);
           // await _context.SaveChangesAsync();

            // Insert customer relationships
            foreach (var moiQuanHe in khachHangDTO.MoiQuanHes)
            {
                var qh = new KhachHang_MoiQuanHe
                {
                   
                    IDKhachHang = (int)khachHangWithoutId.IDKhachHang,
                    ID = moiQuanHe.ID,
                    MoiQuanHe = moiQuanHe.MoiQuanHe,
                    HoTen = moiQuanHe.HoTen,
                    NgaySinh = moiQuanHe.NgaySinh,
                    GioiTinh = moiQuanHe.GioiTinh,
                    NgayHeThong = moiQuanHe.NgayHeThong
                };
                _context.khachHang_MoiQuanHe.Add(qh);
            }
            await _context.SaveChangesAsync();

            //return Ok("Customer and relationships added successfully!");

            return Ok(new { Success = "01", Message = "Customer created successfully" });
        }

        [HttpPut("dsadsadsadsa{id}")]
        public async Task<ActionResult<KhachHang>> UpdateProfile111([FromBody] KhachHangDTO khachHangDTO, decimal id) //decimal or int 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate phone number
            if (!Regex.IsMatch(khachHangDTO.KhachHang.DienThoai, @"^0[1-9][0-9]{8}$"))
            {
                return BadRequest(new { Success = "00", Message = "Invalid Vietnamese phone number" });
            }

            // Check if phone number already exists
            var existingCustomer = await _context.KhachHang.FirstOrDefaultAsync(c => c.DienThoai == khachHangDTO.KhachHang.DienThoai);
            if (existingCustomer != null)
            {
                return BadRequest(new { Success = "00", Message = "Phone number already exists" });
            }
            var existingKhachHang = await _context.KhachHang.FindAsync(id);
            if (existingKhachHang == null)
            {
                return NotFound("KhachHang not found");
            }
            existingKhachHang.IDLoaiThe = khachHangDTO.KhachHang.IDLoaiThe;
            existingKhachHang.MaThe = khachHangDTO.KhachHang.MaThe;
            existingKhachHang.DanhXung =khachHangDTO.KhachHang.DanhXung;
            existingKhachHang.Ho = khachHangDTO.KhachHang.Ho;
            existingKhachHang.Ten = khachHangDTO.KhachHang.Ten;
            existingKhachHang.DienThoai = khachHangDTO.KhachHang.DienThoai;
            existingKhachHang.DiaChi = khachHangDTO.KhachHang.DiaChi;
            existingKhachHang.ThanhPho = khachHangDTO.KhachHang.ThanhPho;
            existingKhachHang.MaBang = khachHangDTO.KhachHang.MaBang;
            existingKhachHang.MaQuocGia = khachHangDTO.KhachHang.MaQuocGia;
            existingKhachHang.TenQuocGia = khachHangDTO.KhachHang.TenQuocGia;
            existingKhachHang.TenBang = khachHangDTO.KhachHang.TenBang;
            existingKhachHang.TenQuan = khachHangDTO.KhachHang.TenQuan;
            existingKhachHang.Email = khachHangDTO.KhachHang.Email;
            existingKhachHang.CMND = khachHangDTO.KhachHang.CMND;
            existingKhachHang.NgaySinhNhat = khachHangDTO.KhachHang.NgaySinhNhat;
            existingKhachHang.GhiNo = khachHangDTO.KhachHang.GhiNo;
            existingKhachHang.NhanEmail = khachHangDTO.KhachHang.NhanEmail;
            existingKhachHang.IsUse = khachHangDTO.KhachHang.IsUse;
            existingKhachHang.NgayHeThong = khachHangDTO.KhachHang.NgayHeThong;
            existingKhachHang.GioiTinh = khachHangDTO.KhachHang.GioiTinh;
            existingKhachHang.GhiChu = khachHangDTO.KhachHang.GhiChu;

            //_context.KhachHang.Add(existingKhachHang);
            decimal decimalId = Convert.ToDecimal(id);
            _context.khachHang_MoiQuanHe.RemoveRange(_context.khachHang_MoiQuanHe.Where(q => q.IDKhachHang == id));
            foreach (var moiQuanHe in khachHangDTO.MoiQuanHes)
            {
                var qh = new KhachHang_MoiQuanHe
                {

                    IDKhachHang = (int)existingKhachHang.IDKhachHang,
                    ID = moiQuanHe.ID,
                    MoiQuanHe = moiQuanHe.MoiQuanHe,
                    HoTen = moiQuanHe.HoTen,
                    NgaySinh = moiQuanHe.NgaySinh,
                    GioiTinh = moiQuanHe.GioiTinh,
                    NgayHeThong = moiQuanHe.NgayHeThong
                };
                _context.khachHang_MoiQuanHe.Add(qh);
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
