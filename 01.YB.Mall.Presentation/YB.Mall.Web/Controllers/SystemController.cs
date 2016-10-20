using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Service;

namespace YB.Mall.Web.Controllers
{
    public class SystemController : Controller
    {
        private readonly IMenuService meunService;
        private readonly IRoleService roleService;

        public SystemController(IMenuService _meunService, IRoleService _roleService)
        {
            meunService = _meunService;
            roleService = _roleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetRoleMenu()
        {
            return Json(roleService.RoleMenu(1), JsonRequestBehavior.AllowGet);
        }
    }
}