using StudentExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentExamProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Members modal)
        {
            using(var context = new StudentAccountEntities())
            {
                bool isValid = context.Registers.Any(x => x.Username == modal.Username && x.Password == modal.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(modal.Username, false);
                    return RedirectToAction("Index", "Students");
                }
                ModelState.AddModelError("", "Attempt with wrong Username or Password");
                return View();
            }
        }
        public ActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(Register model)
        {
            using (var context = new StudentAccountEntities())
            {
                context.Registers.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}