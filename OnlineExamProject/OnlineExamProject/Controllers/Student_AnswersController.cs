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
    public class Student_AnswersController : Controller
    {
        private RegistrationAccountEntities db = new RegistrationAccountEntities();

        // GET: Student_Answers
        public ActionResult Index()
        {
            return View(db.Student_Answers.ToList());
        }

        // GET: Student_Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Answers student_Answers = db.Student_Answers.Find(id);
            if (student_Answers == null)
            {
                return HttpNotFound();
            }
            return View(student_Answers);
        }

        // GET: Student_Answers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,q_id,exam_code,option")] Student_Answers student_Answers)
        {
            if (ModelState.IsValid)
            {
                db.Student_Answers.Add(student_Answers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_Answers);
        }

        // GET: Student_Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Answers student_Answers = db.Student_Answers.Find(id);
            if (student_Answers == null)
            {
                return HttpNotFound();
            }
            return View(student_Answers);
        }

        // POST: Student_Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,q_id,exam_code,option")] Student_Answers student_Answers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Answers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_Answers);
        }

        // GET: Student_Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Answers student_Answers = db.Student_Answers.Find(id);
            if (student_Answers == null)
            {
                return HttpNotFound();
            }
            return View(student_Answers);
        }

        // POST: Student_Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Answers student_Answers = db.Student_Answers.Find(id);
            db.Student_Answers.Remove(student_Answers);
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
    }
}
