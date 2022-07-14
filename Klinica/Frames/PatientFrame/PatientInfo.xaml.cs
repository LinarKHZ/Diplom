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

namespace Klinica.Frames.PatientFrame
{
    /// <summary>
    /// Логика взаимодействия для PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Page
    {
        public PatientInfo()
        {
            InitializeComponent();
            Patient patient = MainWindow.patientValue;

            var list = MainWindow.DB.SocStatus.ToList();
            List<string> strings = new List<string>();
            foreach (var item in list)
            {
                strings.Add(item.Name);
            }
            BenefitBox.ItemsSource = strings;
            MainGrid.DataContext = patient;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var pat = MainWindow.DB.Patients.Where(u => u.Id == MainWindow.patientValue.Id).FirstOrDefault();
            pat = MainGrid.DataContext as Patient;
            MainWindow.DB.SaveChanges();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            NavigationService.Navigate(new PatientInfo());
        }
    }
}
