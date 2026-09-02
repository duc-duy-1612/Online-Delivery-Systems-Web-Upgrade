using System;
using System.Web.Mvc;
using ĐACN.Models;

namespace ĐACN.Filters
{
    public class AdminAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tk = filterContext.HttpContext.Session["TaiKhoan"] as TaiKhoan;
            
            if (tk == null || tk.VaiTro != "Admin")
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { success = false, message = "Bạn không có quyền thực hiện hành động này." },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
