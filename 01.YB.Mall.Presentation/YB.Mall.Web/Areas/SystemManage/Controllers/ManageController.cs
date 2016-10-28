using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Model.QueryModel;
using YB.Mall.Service;
using YB.Mall.Web.Controllers;

namespace YB.Mall.Web.Areas.SystemManage.Controllers
{
    public class ManageController : BaseController
    {
        private readonly IManageService mangService;
        public ManageController(IManageService _mangService)
        {
            this.mangService = _mangService;
        }
        [HttpGet]
        public JsonResult InitGrid(ManageQueryModel query)
        {
            return Json(mangService.InitGrid(query),JsonRequestBehavior.AllowGet);
        }
    }
}