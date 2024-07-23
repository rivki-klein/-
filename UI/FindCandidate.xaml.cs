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
using System.Windows.Shapes;


namespace UI
{
    /// <summary>
    /// Interaction logic for FindCandidate.xaml
    /// </summary>
    public partial class FindCandidate : Window
    {
        ReadTable rt=new ReadTable();
        public FindCandidate()
        {
            InitializeComponent();
            //מילוי קומבובוקס
            List<ItemsCandid> options = new List<ItemsCandid>();
            options = rt.LislCandidates();
            ComboboxChooseCandidate.ItemsSource = options;
            ComboboxChooseCandidate.DisplayMemberPath = "Name"; // מה שיוצג בקומבובוקס
            ComboboxChooseCandidate.SelectedValuePath = "Id";
            //יצירת המילון
            rt.MakeDictInterviews();
        }

        private void ComboboxChooseCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxChooseCandidate.SelectedItem != null)
            {
                string selectedCandidateId = ComboboxChooseCandidate.SelectedValue.ToString();
                List<string> interviews = rt.GetInterOfCandid(selectedCandidateId);
                DataGridInterviews.ItemsSource = interviews.Select(interview => new { InterviewDetails = interview }).ToList();
            }
        }
    }
}
