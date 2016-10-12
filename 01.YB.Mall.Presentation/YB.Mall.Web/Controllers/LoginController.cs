using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Service;

namespace YB.Mall.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IManageService mangService;

        public LoginController(IManageService _mangService)
        {
            this.mangService = _mangService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ManageLogin(string loginname,string password,string code)
        {
            return Json(null);
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
    }
}