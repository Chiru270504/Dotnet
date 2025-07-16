using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvcwebtask.Models
{
  
    public class repo
    {
        string ds = ConfigurationManager.ConnectionStrings["db"].ToString();
        public void Addemploye(employe emp)
        {
            SqlConnection con = new SqlConnection(ds);
            string query= "insert into emp1(eid,ename,esalary) values(@eid,@ename,@esalary)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@eid", emp.eid);
            cmd.Parameters.AddWithValue("@ename", emp.ename);
            cmd.Parameters.AddWithValue("@esalary", emp.esalary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Editemploye(employe emp)
        {
            SqlConnection con = new SqlConnection(ds);
            string query = "update emp1 set ename=@ename,esalary=@esalary where eid=@eid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@eid", emp.eid);
            cmd.Parameters.AddWithValue("@ename", emp.ename);
            cmd.Parameters.AddWithValue("@esalary", emp.esalary);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Deleteemploye(int id)
        {
            SqlConnection con = new SqlConnection(ds);
            string query = "delete from emp1 where eid=@eid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@eid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<employe> GetAllEmploye()
        {
            List<employe> emp = new List<employe>();
            SqlConnection con = new SqlConnection(ds);
            string query = "select * from emp1";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp.Add(new employe
                {
                    eid = Convert.ToInt32(dr["eid"]),
                    ename = dr["ename"].ToString(),
                    esalary = dr["esalary"].ToString()
                });
            }
          //  con.Close();
            return emp;
        }
    }
}