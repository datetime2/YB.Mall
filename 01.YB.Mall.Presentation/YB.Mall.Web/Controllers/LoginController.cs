using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Service;

namespace YB.Mall.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IManageService mangService;

        public LoginController(IManageService _mangService)
        {
            this.mangService = _mangService;
        }
        [HttpPost]
        public JsonResult ManageLogin(string loginname, string password, string code)
        {
            var manage = mangService.Login(loginname, password);
            if (manage != null)
                return Success("操作成功");
            else
                return Error("用户名密码错误");
        }

        [HttpGet]
        public ActionResult AuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
    }
}