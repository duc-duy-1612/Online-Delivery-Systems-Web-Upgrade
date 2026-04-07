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
    }
}