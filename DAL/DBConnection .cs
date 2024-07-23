using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DBConnection
    {
        public DataTable GetAllEmployees()
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Employees";

            DataTable tableEmployees = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(tableEmployees);
            return tableEmployees;
        }
        public DataTable GetRoles()
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT DISTINCT RoleInCompany FROM Employees";

            DataTable roles = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(roles);
            return roles;
        }
        public DataTable GetOptions(string category)
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT DISTINCT "+category+ " FROM Employees";

            DataTable options = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(options);
            return options;
        }

        public DataTable GetAllCandidates()
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Candidates";

            DataTable tableCandidates = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(tableCandidates);
            return tableCandidates;
        }
        public DataTable GetAllInterviews()
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Interviews";

            DataTable tableInterviews = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(tableInterviews);
            return tableInterviews;
        }
        public DataTable GetEmployessByRole(string role)
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Employees WHERE Employees.RoleInCompany='" + role + "';";

            DataTable tableInterviews = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(tableInterviews);
            return tableInterviews;
        }
        public DataTable GetEmployessByCategoryAndOption(string category, string option) 
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Employees WHERE Employees." + category + "='" + option + "';";

            DataTable tableInterviews = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(tableInterviews);
            return tableInterviews;
        }
        public void SetEmployees(List<string> employees)
        {
            string conStr = ConfigurationManager.ConnectionStrings["InterviewsManager"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;


            SqlCommand com = new SqlCommand();
            com.Connection = con;
            int id = int.Parse(employees[0]);
            int age = int.Parse(employees[3]);
            int start = int.Parse(employees[4]);

            com.CommandText = string.Format("SET IDENTITY_INSERT Employees ON INSERT INTO Employees(Id,FirstName,LastName,Age,StartOfWorkYear,City,Street,RoleInCompany,PhoneNumber,Email) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", id, employees[1], employees[2], age, start, employees[5], employees[6], employees[7], employees[8], employees[9]);

            try 
            { 
                con.Open();
                int rowsAffected = com.ExecuteNonQuery();
                Console.WriteLine("Rows affected: {0}", rowsAffected);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            } 
            finally
            {
                con.Close();
            }

        }
    }
}
