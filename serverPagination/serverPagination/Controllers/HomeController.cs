using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace serverPagination.Controllers
{
    public class HomeController : Controller
    {
        public object ent { get; private set; }

        public ActionResult All(int rwaId = 0)
        {
            return View();
        }

        public string GetPatientList(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch)
        {
            string test = string.Empty;
            sSearch = sSearch.ToLower();
            int totalRecord = ent.Patients.Count();
            var patients = new List<Patient>();
            if (!string.IsNullOrEmpty(sSearch))
                patients = ent.Patients.Where(a => a.EmailId.ToLower().Contains(sSearch)
                || a.PatientName.ToLower().Contains(sSearch)
                || a.MobileNumber.StartsWith(sSearch)
                ).OrderBy(a => a.Id).Skip(iDisplayStart).Take(iDisplayLength).ToList();
            else
                patients = ent.Patients.OrderBy(a => a.Id).Skip(iDisplayStart).Take(iDisplayLength).ToList();

            var result = (from p in patients
                          join s in ent.StateMasters
      on p.StateMaster_Id equals s.Id
                          join c in ent.CityMasters
                          on p.CityMaster_Id equals c.Id
                          select new PatientDTO
                          {
                              CityName = c.CityName,
                              StateName = s.StateName,
                              Id = p.Id,
                              IsApproved = p.IsApproved,
                              IsDeleted = p.IsDeleted,
                              CityMaster_Id = p.CityMaster_Id,
                              EmailId = p.EmailId,
                              MobileNumber = p.MobileNumber,
                              StateMaster_Id = p.StateMaster_Id,
                              PatientName = p.PatientName,
                              Rwa_Id = p.Rwa_Id,
                              Location = p.Location,
                          }
                         ).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("{");
            sb.Append("\"sEcho\": ");
            sb.Append(sEcho);
            sb.Append(",");
            sb.Append("\"iTotalRecords\": ");
            sb.Append(totalRecord);
            sb.Append(",");
            sb.Append("\"iTotalDisplayRecords\": ");
            sb.Append(totalRecord);
            sb.Append(",");
            sb.Append("\"aaData\": ");
            sb.Append(JsonConvert.SerializeObject(result));
            sb.Append("}");
            return sb.ToString();
        }
    }
}