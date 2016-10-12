using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Model;
using YB.Mall.Service;

namespace YB.Mall.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public ActionResult Index()
        {
            userService.Register(new UserInfo
            {
                UserName = "51aspx",
                PassPlat = new Guid().ToString(),
                PassWord = new Guid().ToString(),
                CreateTime = DateTime.Now
            });
            //userService.Login("51aspx", "00000000-0000-0000-0000-000000000000");

            return View();
        }
    }
}