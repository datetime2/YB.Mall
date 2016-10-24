using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;

namespace YB.Mall.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult Form()
        {
            return View();
        }
        public virtual ActionResult Detail()
        {
            return View();
        }
        protected virtual JsonResult Success(string message)
        {
            return Json(new AjaxResult { state = ResultType.success.ToString(), message = message }, JsonRequestBehavior.AllowGet);
        }
        protected virtual JsonResult Success(string message, object data)
        {
            return Json(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }, JsonRequestBehavior.AllowGet);
        }
        protected virtual JsonResult Error(string message)
        {
            return Json(new AjaxResult { state = ResultType.error.ToString(), message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}