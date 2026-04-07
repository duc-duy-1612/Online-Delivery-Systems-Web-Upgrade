using System;

namespace ĐACN.Models
{
    public class DanhGiaNhaHangDisplayViewModel
    {
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public decimal? Diem { get; set; }
        public string NhanXet { get; set; }
        public int? LuotMua { get; set; }
        public DateTime? ThoiGianDat { get; set; }
        public DateTime? ThoiGianDanhGia { get; set; }
    }
}