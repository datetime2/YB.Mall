using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Model;
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
        [HttpGet]
        public JsonResult InitTree(MenuQueryModel query)
        {
            return Json(menuService.MenuTree(query), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult InitForm(int keyValue)
        {
            return Json(menuService.SingleMenu(keyValue), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitForm(MenuInfo menu, int? keyValue)
        {
            var res = new JsonResult();
            if (menuService.SubmitForm(menu, keyValue))
                return Success("操作成功");
            else
                return Error("操作失败");
        }
    }
}