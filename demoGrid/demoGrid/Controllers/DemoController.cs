using demoGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoGrid.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Gets the to-do Lists.    
        /*public JsonResult GetCustomers(string word, int page, int rows, string searchString)
        {
            //#1 Create Instance of DatabaseContext class for Accessing Database.  
            using (DatabaseContext db = new DatabaseContext())
            {
                //#2 Setting Paging  
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;

                //#3 Linq Query to Get Customer   
                var Results = db.Student.Select(
                    a => new
                    {
                        a.id,
                        a.name,
                        a.city,
                        a.address,
                        a.email,
                        a.phone,
                    });

                //#4 Get Total Row Count  
                int totalRecords = Results.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

                //#5 Setting Sorting  
                /*if (sord.ToUpper() == "DESC")
                {
                    Results = Results.OrderByDescending(s => s.CustomerID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }
                else
                {
                    Results = Results.OrderBy(s => s.CustomerID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }*/
                //#6 Setting Search  
               /* if (!string.IsNullOrEmpty(searchString))
                {
                    Results = Results.Where(m => m.name == searchString);
                }
                //#7 Sending Json Object to View.  
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }*/
        }
    }

