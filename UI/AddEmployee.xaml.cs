using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        ReadTable rt=new ReadTable();
        public AddEmployee()
        {
            InitializeComponent();
            
        }
        public List<string> FillDataRow()
        {
            //dr = new DataRow();
            //dr["Id"] = IdTextBox.Text;
            //dr["FirstName"] = FirstNameTextBox.Text;
            //dr["LastName"] = LastNameTextBox.Text;
            //dr["Age"] = AgeTextBox.Text;
            //dr["StartOfWorkYear"] = StartOfWorkingYearTextBox.Text;
            //dr["City"] = CityAddressTextBox.Text;
            //dr["Street"] = StreetAddressTextBox.Text;
            //dr["RoleInCompany"] = JobTitleTextBox.Text;
            //dr["PhoneNumber"] = PhoneNumberTextBox.Text;
            //dr["Email"] = MailAddressTextBox.Text;
            //return dr;
            List<string> list = new List<string>();
            list.Add(IdTextBox.Text);
            list.Add(FirstNameTextBox.Text);
            list.Add(LastNameTextBox.Text);
            list.Add(AgeTextBox.Text);
            list.Add(StartOfWorkingYearTextBox.Text);
            list.Add(CityAddressTextBox.Text);
            list.Add(StreetAddressTextBox.Text);
            list.Add(JobTitleTextBox.Text);
            list.Add(PhoneNumberTextBox.Text);
            list.Add(MailAddressTextBox.Text);
            return list;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> parametrs = FillDataRow();
            List<string> notValid = CheckValid(parametrs);
            if(notValid.Count==0)
            { 
                rt.SetEmployss(parametrs);
                MessageBox.Show("Employee added Successfully");
            }
            else
            {
                string error = "Validation failed for field:";
                for(int i = 0; i < notValid.Count; i++)
                {
                    error += notValid[i] + ',';
                }
                MessageBox.Show(error);
            }
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public List<string> CheckValid(List<string> employss)
        {
            List<string> notValid = new List<string>();
            if (!Regex.IsMatch(employss[0], @"^\d{9}$"))//תעודת זהות
            {
                notValid.Add("ID");
            }
            if ((Regex.IsMatch(employss[1], @"\d")) && (employss[1].Count(char.IsLetter) < 2))//שם פרטי
            {
                notValid.Add("FirstName");
            }
            if ((Regex.IsMatch(employss[2], @"\d")) && (employss[2].Count(char.IsLetter) < 2))//שם פרטי
            {
                notValid.Add("LastName");
            }
            if (!employss[3].All(char.IsDigit))
            {
                notValid.Add("Age");
            }
            if (!employss[4].All(char.IsDigit))
            {
                notValid.Add("Start of working year");
            }
            List<string> roles = rt.LislRoles();
            bool degel = false;
            for (int i = 0; i < roles.Count; i++)
            {
                if (employss[7] == roles[i])
                    degel = true;
            }
            if (degel == false)
            {
                notValid.Add("Job title");
            }
            if (!(employss[8].Length == 10 && employss[8].All(char.IsDigit)))
            {
                notValid.Add("Phone number");
            }
            if (!Regex.IsMatch(employss[9], @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                notValid.Add("Mail address");
            }
            return notValid;
        }
    }
}
