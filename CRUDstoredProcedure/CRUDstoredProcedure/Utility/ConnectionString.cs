using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDstoredProcedure.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=.; Initial Catalog=StudentManagement;Integrated Security=SSPI;";
        public static string CName
        {
            get => cName;
        }
    }
}