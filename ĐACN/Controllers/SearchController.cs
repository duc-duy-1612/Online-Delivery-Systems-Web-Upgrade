using ĐACN;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ĐACN.Controllers
{
    public class SearchController : BaseController
    {
        public ActionResult Index(string keyword)
        {
            var result = db.MonAns
                .Include("NhaHang.TaiKhoan")
                .Where(m => m.NhaHang != null && m.NhaHang.TaiKhoan != null && m.NhaHang.TaiKhoan.TrangThai == true &&
                            (keyword == null ||
                            m.TenMon.Contains(keyword) ||
                            m.NhaHang.TenNH.Contains(keyword) ||
                            m.LoaiMonAn.TenLoai.Contains(keyword)))
                .ToList();

            ViewBag.Keyword = keyword;
            return View(result);
        }

        [HttpGet]
        public JsonResult LiveSearch(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return Json(new { success = true, items = new object[0] }, JsonRequestBehavior.AllowGet);

            string keyword = RemoveVietnameseSigns(q).ToLower().Trim();

            // Tìm nhà hàng
            var nhaHangs = db.NhaHangs
                .Where(nh => nh.TaiKhoan != null && nh.TaiKhoan.TrangThai == true)
                .ToList()
                .Where(nh => RemoveVietnameseSigns(nh.TenNH).ToLower().Contains(keyword))
                .Select(nh => new {
                    type = "nhahang",
                    id = nh.MaNH,
                    title = nh.TenNH,
                    desc = nh.DiaChi,
                    img = "/images/nhahang/" + nh.HinhAnh,
                    url = Url.Action("XemMenu", "KhachHang", new { id = nh.MaNH })
                }).Take(3).ToList();

            // Tìm món ăn
            var monAns = db.MonAns
                .Where(m => m.NhaHang != null && m.NhaHang.TaiKhoan != null && m.NhaHang.TaiKhoan.TrangThai == true)
                .ToList()
                .Where(m => RemoveVietnameseSigns(m.TenMon).ToLower().Contains(keyword))
                .Select(m => new {
                    type = "monan",
                    id = m.MaMon,
                    title = m.TenMon,
                    desc = string.Format("{0:N0} đ", m.Gia),
                    img = "/images/monan/" + m.HinhAnh,
                    url = Url.Action("XemMenu", "KhachHang", new { id = m.MaNH })
                }).Take(4).ToList();

            var results = nhaHangs.Cast<object>().Concat(monAns).ToList();

            return Json(new { success = true, items = results }, JsonRequestBehavior.AllowGet);
        }
    }
}