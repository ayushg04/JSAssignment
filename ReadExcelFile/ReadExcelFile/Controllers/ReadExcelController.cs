using ReadExcelFile.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ReadExcelFile.Controllers
{
    public class ReadExcelController : Controller
    {
        // GET: ReadExcel
        public ActionResult Index(int? page)
        {
            if (Session["ExcelData"] != null)
                ReadSession(Convert.ToInt32(page));
            return View();
        }
        [HttpPost]
        public ActionResult Index(ReadExcelFile.Models.ReadExcel readExcel)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Upload/" + readExcel.file.FileName);
                readExcel.file.SaveAs(path);

                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                //Sheet Name
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                excelConnection.Close();
                //End

                //Putting Excel Data in DataTable
                DataTable dataTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + tableName + "]", excelConnection);
                adapter.Fill(dataTable);
                //End

                Session["ExcelData"] = dataTable;
                ReadSession(1);
            }
            return View();
        }
        void ReadSession(int page)
        {
            DataTable dataTable = (DataTable)Session["ExcelData"];

            var totalRecords = dataTable.Rows.Count;
            var pageSize = 10;
            var skip = pageSize * (page - 1);
            var canPage = skip < totalRecords;

            if (canPage)
            {
                var record = dataTable.AsEnumerable().Select(p => p)
                             .Skip(skip)
                             .Take(pageSize)
                             .ToArray();

                var columnName = dataTable.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

                StringBuilder sb = new StringBuilder();

                sb.Append("<table>");

                sb.Append("<thead><tr>");
                foreach (var col in columnName)
                    sb.Append("<td>" + col + "</td>");
                sb.Append("</tr></thead>");

                sb.Append("<tbody>");
                foreach (var rec in record)
                {
                    sb.Append("<tr>");
                    foreach (var val in rec.ItemArray)
                    {
                        sb.Append("<td>" + val + "</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</tbody>");

                sb.Append("</table>");

                ViewBag.ExcelData = sb.ToString();

                PagingInfo pagingInfo = new PagingInfo();
                pagingInfo.CurrentPage = page;
                pagingInfo.TotalItems = totalRecords;
                pagingInfo.ItemsPerPage = pageSize;
                ViewBag.Paging = pagingInfo;
            }
        }
    }
}