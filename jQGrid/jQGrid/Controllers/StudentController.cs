using jQGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using jQGrid.StudentDataModel;
namespace jQGrid.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        /*
        public ActionResult GetList()
        {
            using(DBModels db = new DBModels())
            {
                var stList = db.Students.ToList<Student>();
                return Json(new { data = stList }, JsonRequestBehavior.AllowGet);
            }
        }
        */
        [HttpPost]
        public ActionResult GetList()
        {
            //Server side Processing
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchVal = Request["search[value]"];
            string sortColumnName = Request["columns["+ Request["order[0][column]"]+"][name]"];
            string sortDir = Request["order[0][dir]"];
            StudentDBprocess sdb = new StudentDBprocess();
            List<Student> stuList = new List<Student>();
            List<Student> stuList1 = new List<Student>();
            using (DBModels db = new DBModels())
            {
                stuList = db.Students.ToList<Student>();
                int totalrows = stuList.Count;
                stuList1 = sdb.pagination(start, length, stuList);

                stuList1 = sdb.searching(searchVal, stuList1);
                int filteredrows = stuList.Count;
                stuList1 = sdb.sorting(sortColumnName, sortDir, stuList1);
                
                return Json(new { data = stuList1,draw = Request["draw"],recordsTotal = totalrows,recordsFiltered = filteredrows  }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}