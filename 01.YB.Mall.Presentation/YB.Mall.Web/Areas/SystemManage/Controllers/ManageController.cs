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
    [HandlerLogin]
    public class ManageController : BaseController
    {
        private readonly IManageService mangService;
        private readonly IRoleService roleService;

        public ManageController(IManageService _mangService, IRoleService _roleService)
        {
            this.mangService = _mangService;
            this.roleService = _roleService;
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public JsonResult InitGrid(ManageQueryModel query)
        {
            return Json(mangService.InitGrid(query), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public JsonResult SubmitForm(ManageInfo mang, string roles, int? keyValue)
        {
            return mangService.SubmitForm(mang, roles.Split(',').Select(int.Parse), keyValue)
                ? Success("操作成功")
                : Error("操作失败");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public JsonResult InitForm(int keyValue)
        {
            var mang = mangService.InitForm(keyValue);
            return Json(new
            {
                ManageId = mang.ManageId,
                Account = mang.Account,
                Birthday = mang.Birthday,
                Description = mang.Description,
                Email = mang.Email,
                Gender = mang.Gender,
                IsEnabled = mang.IsEnabled,
                Phone = mang.Phone,
                RealName = mang.RealName,
                Role = mang.ManageRole.Select(s=>s.RoleId)
            }, JsonRequestBehavior.AllowGet);
        }
    }
}