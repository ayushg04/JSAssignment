using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamProject.Models
{
    public class Members
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

    }
}