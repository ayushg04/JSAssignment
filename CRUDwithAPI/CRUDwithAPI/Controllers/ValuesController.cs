using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
namespace CRUDwithAPI.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=LAP-1002\SQLEXPRESS; database=master; Integrated Security=true;");
        // GET api/values
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dummy", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No Data found";
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            //return "value";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dummy where id = ('"+id+"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No Data found";
            }
        }

        // POST api/values
        public string Post([FromBody] string name)
        {
            SqlCommand cmd = new SqlCommand("insert into Dummy(name) values('"+name+ "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Data entered Successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("update Dummy set name = '"+value+"' where id = '"+id+"'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Data updated Successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from Dummy where id = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Data deleted Successfully";
            }
            else
            {
                return "Something went wrong";
            }

        }
    }
}
