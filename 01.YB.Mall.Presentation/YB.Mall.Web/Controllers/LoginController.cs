using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Extend.Helper;
using YB.Mall.Extend.Operator;
using YB.Mall.Extend.Web;
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
        public JsonResult ManageLogin(string username, string password, string code)
        {
            var manage = mangService.Login(username, password);
            if (manage != null && manage.ManageId>0)
            {
                var operatorModel = new OperatorModel
                {
                    UserId = manage.ManageId + "",
                    UserCode = manage.Account,
                    UserName = manage.RealName,
                    RoleId = manage.ManageRole.Select(s => s.RoleId + "").Aggregate((c, n) => c + "," + n),
                    LoginIPAddress = Net.Ip,
                    IsSystem = manage.Account.Equals("admin")
                };
                OperatorProvider.Provider.AddCurrent(operatorModel);
                return Success("操作成功");
            }
            return Error("用户名密码错误");
        }

        public ActionResult OutLogin()
        {
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult AuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
    }
}