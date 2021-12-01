using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamProject.Models
{
    public class Answers
    {
        public string name { get; set; }
        public int q_id { get; set; }

        public string exam_code { get; set; }

        public string option { get; set; }
    }
}