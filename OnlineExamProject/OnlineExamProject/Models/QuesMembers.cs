using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamProject.Models
{
    public class QuesMembers
    {
        public int id { get; set; }
  
        public string exam_code { get; set; }

        public string question { get; set; }
 
        public string option_A { get; set; }

        public string option_B { get; set; }

        public string option_C { get; set; }

        public string option_D { get; set; }

        public string correct_answer { get; set; }

    }
}