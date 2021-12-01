using OnlineExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineExamProject.Controllers
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
            using (var context = new RegistrationAccountEntities())
            {
                bool isValid = context.Registers.Any(x => x.Username == modal.Username && x.Password == modal.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(modal.Username, false);
                    return RedirectToAction("Index", "Demo");
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
        public ActionResult SignUP(Register model, Members modal)
        {
            using (var context = new RegistrationAccountEntities())
            {
                bool isValid = context.Registers.Any(x => x.Username == modal.Username && x.Password == modal.Password);
                if (isValid)
                {
                    ModelState.AddModelError("", "User Already Has an Account. Please try with different UserName.");
                    return View();
                }
/*                List<Register> roll_list = context.Registers.Where(x => x.id == modal.Id).ToList();
                ViewBag.list = new SelectList(roll_list,"id", "Role");*/
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
