using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ĐACN.Models
{
    // === VIEW MODEL CHO ĐÁNH GIÁ ===
    public class DanhGiaViewModel
    {
        public string MaDon { get; set; }
        public string MaNH { get; set; }
        public string TenNH { get; set; }
        public string MaShipper { get; set; }
        public string TenShipper { get; set; }

        // Đánh giá nhà hàng
        public int SoSaoNhaHang { get; set; }
        public string BinhLuanNhaHang { get; set; }

        // Đánh giá Shipper
        public int SoSaoShipper { get; set; }
        public string BinhLuanShipper { get; set; }
    }

    public class ReviewDisplayModel
    {
        public string TenKH { get; set; }
        public int SoSao { get; set; }
        public string BinhLuan { get; set; }
        public DateTime ThoiGian { get; set; }
        public string Avatar { get; set; } // Nếu muốn hiện avatar (tạm thời để placeholder)
    }
}