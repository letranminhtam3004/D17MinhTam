using System.ComponentModel.DataAnnotations.Schema;

namespace LastTest.Entities
{
    public class KhachHangDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public KhachHang KhachHang { get; set; }
        public KhachHang_MoiQuanHe[]? MoiQuanHes { get; set; }
    }
}
