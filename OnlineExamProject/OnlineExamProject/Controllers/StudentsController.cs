using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamProject.Models;

namespace OnlineExamProject.Controllers
{
    public class StudentsController : Controller
    {
        private RegistrationAccountEntities db = new RegistrationAccountEntities();
        string ec;
        ansCalculator anc = new ansCalculator();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }
        public ActionResult Apply(int id, result res)
        {
            using (var context = new RegistrationAccountEntities())
            {
                var name = User.Identity.Name;
                var exam_code = id.ToString();
                ec = exam_code;
                var isValid = context.Questions.Where(x => x.exam_code == exam_code).AsEnumerable();
                if (isValid.Count()>0)
                {
                    var ishaving = context.results.Where(x => x.name == name).AsEnumerable();
                    if (ishaving.Count() > 0)
                    {
                        ViewBag.Title = "Already Attempted";
                        return RedirectToAction("submit", "Students");
                    }
                    else
                    {
                        return RedirectToAction("StartTest", "Students");
                    }
                }
                else
                {
                    return View();
                }
            }
        }
        public ActionResult StartTest()
        {

            return View(db.Questions.ToList());
        }
        [HttpPost]
        public ActionResult StartTest(FormCollection a,result res)
        {
            
            var exc = ec;
                var name = User.Identity.Name;
                using(RegistrationAccountEntities db = new RegistrationAccountEntities()) {
                var Student_Answer = new Student_Answers();
                var dmark = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    var ans1 = a[i];
                    var keys = a.Keys[i];

                    Student_Answer.exam_code = "102";
                    Student_Answer.name = name;
                    Student_Answer.q_id = keys;
                    Student_Answer.option = ans1;
                    db.Student_Answers.Add(Student_Answer);
                    db.SaveChanges();
                    dmark = anc.ansCal(name, keys, "102", ans1);
                }
                res.name = name;
                res.exam_code = "102";
                res.marks = dmark;
                db.results.Add(res);
                db.SaveChanges();
                //submit(name);
            }
            
            return RedirectToAction("submit", "Students");

        }
        public ActionResult submit()
        {
            var name = User.Identity.Name;
            var final_marks = db.results.FirstOrDefault(x => x.name == name);
            ViewBag.Title = "Submitted Successfully";
            return View(final_marks);
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
