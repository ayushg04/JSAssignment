using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExamProject.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}