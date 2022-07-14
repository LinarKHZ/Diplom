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
using Klinica.Datebase;
using Klinica.Pages;

namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для PacientList.xaml
    /// </summary>
    public partial class PacientList : Page
    {
         List<Patient> patientL = new List<Patient>();
        bool IsDoctor = false;
        bool IsWorker = false;
        TimingSegmentation timing = new TimingSegmentation();
        public PacientList()
        {
            InitializeComponent();
        }

        public PacientList(bool flag):this()
        {
            IsDoctor = true;
        }
        public PacientList(int il) : this()
        {
            IsWorker = true;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var itemsInfo = patientL;
            if (LName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.LastName.ToLower().IndexOf(LName.Text.ToLower()) != -1).ToList();
            }
            if (NName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Name.ToLower().IndexOf(NName.Text.ToLower()) != -1).ToList();
            }
            if (PName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Patronymic.ToLower().IndexOf(PName.Text.ToLower()) != -1).ToList();
            }
            if (PassportData.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.PassportData.ToLower().IndexOf(PassportData.Text.ToLower()) != -1).ToList();
            }
            if (Sex.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Sex.ToLower().IndexOf(Sex.Text.ToLower()) != -1).ToList();
            }
            if(itemsInfo != null)
            {
                PatientList.ItemsSource = itemsInfo;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LName.Text = "";
            NName.Text = "";
            PName.Text = "";
            PassportData.Text = "";
            Sex.Text = "";
            Page_Loaded(new object(), new RoutedEventArgs());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            patientL = MainWindow.DB.Patients.OrderBy(p => p.LastName).OrderBy(p => p.Name).ToList();
            MainWindow.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            PatientList.ItemsSource = patientL;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.patientValue = (sender as ListViewItem).DataContext as Patient;
            if (IsDoctor)
            {
                NavigationService.Navigate(new NewRecord());
            }
            else
            {
                if (IsWorker)
                {
                    NavigationService.Navigate(new Frames.WorkPanel());
                }
            }
        }
    }
}
