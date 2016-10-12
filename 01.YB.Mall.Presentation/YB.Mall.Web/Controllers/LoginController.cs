using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}