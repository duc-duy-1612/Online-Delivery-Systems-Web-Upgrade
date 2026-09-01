using System;

namespace ĐACN.Models
{
    public class DonHangListViewModel
    {
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime? ThoiGianDat { get; set; }
        public decimal? TongTien { get; set; }
        public string TrangThai { get; set; }
        public string TenShipper { get; set; } // Lưu tên shipper dưới dạng string để tránh proxy issue
    }
}

