using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamProject.Controllers
{
    [Authorize]
    public class DemoController : Controller
    {
        [Authorize(Roles = "admin, student")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Demo
        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "student")]
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult Questions_List()
        {
            return RedirectToAction("Index", "Questions");
        }
        public ActionResult Exam_List()
        {
            return RedirectToAction("Index", "Exams");
        }
        public ActionResult Results_List()
        {
            return RedirectToAction("Index", "results");
        }
        public ActionResult Students_Exam()
        {
            return RedirectToAction("Index", "Students");
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Logout", "Account");
        }
    }
}

