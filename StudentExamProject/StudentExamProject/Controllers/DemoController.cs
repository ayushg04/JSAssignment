using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentExamProject.Controllers
{
    [Authorize]
    public class DemoController : Controller
    {
        // GET: Demo
        [Authorize(Roles ="Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "Student")]
        public ActionResult Student()
        {
            return View();
        }
    }
}