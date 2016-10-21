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
    public class RoleController : BaseController
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            this.roleService = _roleService;
        }
        [HttpGet]
        public JsonResult RoleGrid(RoleQueryModel query)
        {
            var grid = roleService.RoleGrid(query);
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
    }
}