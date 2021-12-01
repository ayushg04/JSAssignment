using DemoEntityF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoEntityF.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
            Student usermodel = new Student();
            return View(usermodel);
        }
    }
}