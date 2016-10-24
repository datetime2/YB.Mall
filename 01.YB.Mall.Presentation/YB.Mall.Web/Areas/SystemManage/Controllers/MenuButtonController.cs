using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Web.Controllers;

namespace YB.Mall.Web.Areas.SystemManage.Controllers
{
    public class MenuButtonController : BaseController
    {
        [HttpGet]
        public JsonResult ButtonGrid()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}