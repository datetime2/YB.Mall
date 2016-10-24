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
    public class MenuController : BaseController
    {
        private readonly IMenuService menuService;
        public MenuController(IMenuService _menuService)
        {
            this.menuService = _menuService;
        }

        [HttpGet]
        public JsonResult InitGrid(MenuQueryModel query)
        {
            return Json(menuService.MenuGrid(query), JsonRequestBehavior.AllowGet);
        }
    }
}