using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamProject.Models
{
    public class ansCalculator
    {
        int final_mark;
        string nam;
        public int ansCal(string name, string ques, string code, string ans)
        {
            
            using(var context = new RegistrationAccountEntities())
            {
                var isValid = context.Questions.Where(x => x.exam_code == code && x.question == ques && x.correct_answer == ans).AsEnumerable();
                if (isValid.Count() > 0)
                {
                    final_mark += 1;
                    nam = name;
                }
            }

            return final_mark;
        }

    }
}