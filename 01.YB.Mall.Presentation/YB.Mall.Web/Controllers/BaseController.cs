using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}