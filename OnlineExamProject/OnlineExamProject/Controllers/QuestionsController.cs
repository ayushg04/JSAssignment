using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamProject.Models;

namespace OnlineExamProject.Controllers
{
    public class QuestionsController : Controller
    {
        private RegistrationAccountEntities db = new RegistrationAccountEntities();

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question, QuesMembers qm)
        {
            using (var context = new RegistrationAccountEntities())
            {
                bool isValid = context.Questions.Any(x => x.exam_code == qm.exam_code || x.question == qm.question);
                if (isValid)
                {
                    ModelState.AddModelError("", "Question credentials already exist. Please try Again");
                    return View();
                }
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuesMembers qm, Question question)
        {
            using (var context = new RegistrationAccountEntities())
            {
                bool isValid = context.Questions.Any(x => x.exam_code == qm.exam_code || x.question == qm.question);
                if (isValid)
                {
                    ModelState.AddModelError("", "Question credentials already exist. Please try Again");
                    return View();
                }
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
        public ActionResult Logout()
        {
            return RedirectToAction("Logout", "Account");
        }
    }
}
