using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExcelData.Models
{
    public class DemoContext: DbContext
    {
        public DemoContext() : base("ConString")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}