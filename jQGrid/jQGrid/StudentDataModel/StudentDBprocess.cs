using jQGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;

namespace jQGrid.StudentDataModel
{
    public class StudentDBprocess
    {
        List<Student> globalList = new List<Student>(); 
        public List<Student> pagination(int start, int length, List<Student> stulist)
        {
            List<Student> studentlist = new List<Student>();
            studentlist = stulist.Skip(start).Take(length).ToList<Student>();
            globalList = studentlist;
            Console.WriteLine(globalList.Count);
            return studentlist;
        }

        public List<Student> sorting(string columnName,string dir, List<Student> stulist)
        {
            List<Student> studentlist = new List<Student>();
            studentlist = stulist.OrderBy(columnName + " " + dir).ToList<Student>();
            return studentlist;
        }

        public List<Student> searching (string val, List<Student> stulist)
        {
            List<Student> studentlist = new List<Student>();
            if (!string.IsNullOrEmpty(val))//filter
            {
                stulist = stulist.Where(x => x.name.ToLower().Contains(val.ToLower()) || x.city.ToLower().Contains(val.ToLower()) || x.address.ToLower().Contains(val.ToLower()) || x.email.ToLower().Contains(val.ToLower()) || x.phone.ToString().Contains(val.ToLower())).ToList<Student>();
            }
            return stulist;
        }
    }
}