using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Service;
using YB.Mall.Web.Controllers;

namespace YB.Mall.Web.Areas.SystemManage.Controllers
{
    public class MenuButtonController : BaseController
    {
        private readonly IMenuButtonService buttonService;
        public MenuButtonController(IMenuButtonService _buttonService)
        {
            this.buttonService = _buttonService;
        }
        [HttpGet]
        public JsonResult InitGrid(MenuButtonQueryModel query)
        {
            return Json(buttonService.ButtonGrid(query), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult InitForm(int? keyValue)
        {
            var button = buttonService.SingleButton(s => s.ButtonId == keyValue);
            return Json(new MenuButtonInfo
            {
                ButtonId = button.ButtonId,
                MenuId = button.MenuId,
                ButtonName = button.ButtonName,
                ElementId = button.ElementId,
                Event = button.Event,
                Icon = button.Icon,
                IsEnabled = button.IsEnabled,
                Location = button.Location
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitForm(MenuButtonInfo button, int? keyValue)
        {
            return buttonService.SubmitForm(button, keyValue) ? Success("操作成功") : Error("操作失败");
        }
        [HttpPost]
        public JsonResult Remove(int? keyValue)
        {
            return buttonService.Remove(s => s.ButtonId == keyValue) ? Success("操作成功") : Error("操作失败");
        }
    }
}