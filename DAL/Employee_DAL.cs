using MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Employee_DAL
   {
        //vijay

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public List<Employee_Model>GetCountry()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("spGetCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            List<Employee_Model> lst = new List<Employee_Model>();

            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new Employee_Model()
                {
                   CountryId=Convert.ToInt32(item["CountryId"]),
                   CountryName=(item["CountryName"].ToString())
                    
                });

            }

            return lst;
        }

        public List<Employee_Model>State(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SpState", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CountryId", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            List<Employee_Model> lst = new List<Employee_Model>();
            
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new Employee_Model()
                {
                    StateId=Convert.ToInt32(item["StateId"]),
                    StateName=(item["StateName"].ToString())
                });

            }

            return lst;

        }



         public int CreateEmp(Employee_Model EM)
         {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SP_CreateEmp1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpName", EM.EmpName);
            cmd.Parameters.AddWithValue("@Resume", EM.Resume);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }


        public List<Employee_Model> EmployList()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("Sp_ListEmp1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            DataTable dt = new DataTable();

            dt = ds.Tables[0];

            List<Employee_Model> lst = new List<Employee_Model>();

            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new Employee_Model()
                {
                    EmpId = Convert.ToInt32(item["EmpId"]),
                    EmpName = (item["EmpName"].ToString()),
                    Resume = (item["Resume"].ToString()),
                    CountryName = (item["CountryName"].ToString()),
                    StateName = (item["StateName"].ToString())

                });

            }
            return lst;

        }



    }
}
