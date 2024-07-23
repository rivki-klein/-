using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.ComponentModel;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Object[][] Arr { get; set; }
        ReadTable rt;
        public DataTable dt {  get; set; }
        string selectedCategory;

        public MainWindow()
        {

            //הצגת הטבלה
            rt = new ReadTable();
            InitializeComponent();
            dt=rt.GetTableEmployss();
            DataContext = this;

            //מילוי קומבובוקס קטגוריות
            List<string> categorie = new List<string> { "City", "RoleInCompany", "StartOfWorkYear", "עשור" };
            ComboBoxFilterCategory.ItemsSource = categorie;
            //מילוי קומבובוקס של סעיף 4
            //List<string> options = new List<string>();
            //options = rt.LislRoles();
            //ComboBoxFilterOptions.ItemsSource = options;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWin = new AddEmployee();
            addEmployeeWin.ShowDialog();
        }

        private void CandidateDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            selectedCategory = ComboBoxFilterCategory.SelectedItem.ToString();
            FillCBOptionns(selectedCategory);
        }

        private void Button_Click_Find(object sender, RoutedEventArgs e)
        {
            FindCandidate findCandidate= new FindCandidate();
            findCandidate.ShowDialog();
        }
        
        //private void ComboBoxFilterOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    String role = ComboBoxFilterOptions.SelectedItem.ToString();
        //    dt = rt.GetTableEmployssByRole(role);
        //    PropertyChanged(this, new PropertyChangedEventArgs("dt"));
        //    DataContext = this;
        //}
        private void ComboBoxFilterOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String option = ComboBoxFilterOptions.SelectedItem.ToString();
            dt = rt.GetEmployessByCategoryAndOption(selectedCategory, option);
            PropertyChanged(this, new PropertyChangedEventArgs("dt"));
            DataContext = this;
        }
        private void FillCBOptionns(string category)
        {
            List<string> options = new List<string>();
            options = rt.ListOptions(category);
            ComboBoxFilterOptions.ItemsSource = options;
        }
    }
}
