using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamProject.Models
{
    public class ExamMembers
    {
        public int id { get; set; }

        public string exam_name { get; set; }

        public string exam_code { get; set; }

    }
}