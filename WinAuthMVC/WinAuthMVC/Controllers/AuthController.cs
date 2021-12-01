using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinAuthMVC.Controllers
{
    [Authorize (Users=@"ayush,admin")]
    public class AuthController : Controller
    {
        // GET: Auth
        [Authorize(Users = @"admin")]
        public ActionResult ByAdmin()
        {
            return View();
        }
        [Authorize (Users=@"ayush,admin")]
        public ActionResult ByUsers()
        {
            return View();
        }
    }
}