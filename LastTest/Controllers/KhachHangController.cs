using LastTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        
        [HttpPost]

        public async Task<ActionResult<KhachHang>> CreateKhachHang([FromBody] KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Loại bỏ cột IDKhachHang ra khỏi danh sách các cột được chèn
            var khachHangWithoutId = new KhachHang
            {
                IDLoaiThe = khachHang.IDLoaiThe,
                MaThe = khachHang.MaThe,
                DanhXung = khachHang.DanhXung,
                Ho = khachHang.Ho,
                Ten = khachHang.Ten,
                DienThoai = khachHang.DienThoai,
                DiaChi = khachHang.DiaChi,
                ThanhPho = khachHang.ThanhPho,
                MaBang = khachHang.MaBang,
                MaQuocGia = khachHang.MaQuocGia,
                TenQuocGia = khachHang.TenQuocGia,
                TenBang = khachHang.TenBang,
                TenQuan = khachHang.TenQuan,
                Email = khachHang.Email,
                CMND = khachHang.CMND,
                NgaySinhNhat = khachHang.NgaySinhNhat,
                GhiNo = khachHang.GhiNo,
                NhanEmail = khachHang.NhanEmail,
                IsUse = khachHang.IsUse,
                NgayHeThong = khachHang.NgayHeThong,
                GioiTinh = khachHang.GioiTinh,
                GhiChu=khachHang.GhiChu
            };
            _context.KhachHang.Add(khachHangWithoutId);
            await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetKhachHang), new { id = khachHangWithoutId.IDKhachHang }, khachHangWithoutId);
            return khachHangWithoutId;
        }

        [HttpPost("TEST")]
        public async Task<ActionResult<KhachHang>> CreateKhachHang111([FromBody] KhachHangDTO khachHangDTO)
        {
            try
            {

                _context.KhachHang.Add(khachHangDTO.KhachHang);

                foreach (var moiQuanHe in khachHangDTO.MoiQuanHes)
                {
                    _context.khachHang_MoiQuanHe.Add(new KhachHang_MoiQuanHe
                    {
                        // Gán các giá trị từ mối quan hệ vào bảng KhachHang_MoiQuanHe
                        // Ví dụ:
                        // KhachHangId: khachHangDTO.KhachHang.IDKhachHang,
                        // TenMoiQuanHe: moiQuanHe.TenMoiQuanHe,
                        IDKhachHang = moiQuanHe.IDKhachHang,
                        ID=moiQuanHe.ID,
                        MoiQuanHe=moiQuanHe.MoiQuanHe,
                        HoTen=moiQuanHe.HoTen,
                        NgaySinh=moiQuanHe.NgaySinh,
                        GioiTinh=moiQuanHe.GioiTinh,
                        NgayHeThong=moiQuanHe.NgayHeThong
                    });
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



        [HttpPut("{id}")]
        public async Task<ActionResult<KhachHang>> UpdateProfile([FromBody] KhachHang khachHang, decimal id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingKhachHang = await _context.KhachHang.FindAsync(id);
            if (existingKhachHang == null)
            {
                return NotFound("KhachHang not found");
            }
            existingKhachHang.IDLoaiThe = khachHang.IDLoaiThe;
            existingKhachHang.MaThe = khachHang.MaThe;
            existingKhachHang.DanhXung = khachHang.DanhXung;
            existingKhachHang.Ho = khachHang.Ho;
            existingKhachHang.Ten = khachHang.Ten;
            existingKhachHang.DienThoai = khachHang.DienThoai;
            existingKhachHang.DiaChi = khachHang.DiaChi;
            existingKhachHang.ThanhPho = khachHang.ThanhPho;
            existingKhachHang.MaBang = khachHang.MaBang;
            existingKhachHang.MaQuocGia = khachHang.MaQuocGia;
            existingKhachHang.TenQuocGia = khachHang.TenQuocGia;
            existingKhachHang.TenBang = khachHang.TenBang;
            existingKhachHang.TenQuan = khachHang.TenQuan;
            existingKhachHang.Email = khachHang.Email;
            existingKhachHang.CMND = khachHang.CMND;
            existingKhachHang.NgaySinhNhat = khachHang.NgaySinhNhat;
            existingKhachHang.GhiNo = khachHang.GhiNo;
            existingKhachHang.NhanEmail = khachHang.NhanEmail;
            existingKhachHang.IsUse = khachHang.IsUse;
            existingKhachHang.NgayHeThong = khachHang.NgayHeThong;
            existingKhachHang.GioiTinh = khachHang.GioiTinh;
            existingKhachHang.GhiChu = khachHang.GhiChu;

            _context.Entry(existingKhachHang).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
