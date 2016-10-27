using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Extend.Helper;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;
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
            var menu = menuService.InitForm(keyValue);
            return Json(new MenuInfo
            {
                Icon = menu.Icon,
                MenuName = menu.MenuName,
                IsEnabled = menu.IsEnabled,
                MenuId = menu.MenuId,
                ParentId = menu.ParentId,
                UrlPath = menu.UrlPath,
                Target = menu.Target,
                Remark = menu.Remark,
                Sort = menu.Sort,
                ElementId = menu.ElementId,
                Event = menu.Event
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitForm(MenuInfo menu, int? keyValue)
        {
            return menuService.SubmitForm(menu, keyValue) ? Success("操作成功") : Error("操作失败");
        }

        [HttpPost]
        public JsonResult Remove(int? keyValue)
        {
            return menuService.Remove(s => s.MenuId == keyValue) ? Success("操作成功") : Error("操作失败");
        }
        /// <summary>
        /// 类型下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitMenuType()
        {
            return Json(EnumHelper.ToDescriptionDictionary<AuthorizeType>().Select(s => new TreeSelectModel
            {
                id = s.Value,
                text = s.Key
            }), JsonRequestBehavior.AllowGet);
        }
    }
}