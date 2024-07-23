using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ReadTable
    {
        DBConnection dbConnect=new DBConnection();
        Dictionary<int, List<string>> interviewsByCandidate;

        public DataTable GetTableEmployss()
        {
            DataTable dt = dbConnect.GetAllEmployees();
            return dt;
        }
        public DataTable GetTableEmployssByRole(string role)
        {
            DataTable dt = dbConnect.GetEmployessByRole(role);
            return dt;
        }
        public DataTable GetEmployessByCategoryAndOption(string category, string option)
        {
            DataTable dt = dbConnect.GetEmployessByCategoryAndOption(category, option);
            return dt;
        }
        public List<string> LislRoles()
        {
            List<string> roles = new List<string>();
            DataTable dt=dbConnect.GetRoles();
            for(int i=0; i<dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                roles.Add(dr[0].ToString());
            }
            return roles;
        }
        public List<string> ListOptions(string category)
        {
            List<string> options = new List<string>();
            DataTable dt = dbConnect.GetOptions(category);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                options.Add(dr[0].ToString());
            }
            return options;
        }
        public List<ItemsCandid> LislCandidates()
        {
            List<ItemsCandid> candidItems = new List<ItemsCandid>();
            DataTable dt = dbConnect.GetAllCandidates();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                candidItems.Add(new ItemsCandid { Id = dr[0].ToString(), Name = dr[1].ToString()+" " + dr[2].ToString() });
            }
            return candidItems;
        }
        public void SetEmployss(List<string> employss)
        {

            dbConnect.SetEmployees(employss);
        }
        public Dictionary<int, List<string>> MakeDictInterviews()
        {
            DataTable dt = dbConnect.GetAllInterviews();
            interviewsByCandidate = dt.AsEnumerable()
            .GroupBy(row => row.Field<int>("CandidateId"))
            .ToDictionary(
                group => group.Key,
                group => group
                    .Select(row =>
                        new
                        {
                            InterviewNumber = row.Field<int>("InterviewNumber"),
                            InterviewerId = row.Field<int>("InterviewerId"),
                            InterviewDate = row.Field<DateTime?>("InterviewDate"),
                            RoleInCompany = row.Field<string>("RoleInCompany")
                        })
                    .OrderBy(interview => interview.InterviewDate)
                    .Select(interview =>
                        $"{interview.InterviewNumber}, " +
                        $"{interview.InterviewerId}, " +
                        $"{interview.InterviewDate?.ToShortDateString()}, " +
                        $"{interview.RoleInCompany}")
                    .ToList()
            );
            return interviewsByCandidate;
        }
        public List<string> GetInterOfCandid(string id)
        {
            int idInt=int.Parse(id);
            List<string> interviews= interviewsByCandidate[idInt];
            return interviews;
        }


    }
}
