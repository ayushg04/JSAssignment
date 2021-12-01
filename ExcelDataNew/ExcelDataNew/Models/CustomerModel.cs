using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelDataNew.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        ///<summary>
        /// Gets or sets Name.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets Country.
        ///</summary>
        public string Country { get; set; }
    }
}