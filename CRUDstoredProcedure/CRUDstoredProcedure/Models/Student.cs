using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDstoredProcedure.Models
{
    public class Student
    {
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string City { set; get; }
        public int Phone { set; get; }
        public string Email { set; get; }
        [Required]
        public int PinCode { set; get; }
        public int Department_Id { set; get; }
    }
}