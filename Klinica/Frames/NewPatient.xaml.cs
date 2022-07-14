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

namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для NewPatient.xaml
    /// </summary>
    public partial class NewPatient : Page
    {
        Patient patient = new Patient();
        public NewPatient()
        {
            InitializeComponent();
            patient.Birthday = DateTime.Now.Date;
            MainGrid.DataContext = patient;
            var list = MainWindow.DB.SocStatus.ToList();
            List<string> strings = new List<string>();
            foreach (var item in list)
            {
                strings.Add(item.Name);
            }
            BenefitBox.ItemsSource = strings;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patient.CreateDatetime = DateTime.Now.Date;
                if (patient.PatientSex == 1)
                {
                    patient.Sex = "ж";
                }
                else
                {
                    patient.Sex = "м";
                }
                
                {
                    MainWindow.DB.Patients.Add(patient);
                    MainWindow.DB.SaveChanges();
                    MessageBox.Show("Успешно добален");
                    NavigationService.Navigate(new DoctorSerch());
                }               
            }
            catch (Exception ex)
            {
                var innexc = ex.InnerException;
                while (innexc != null)
                {
                    MessageBox.Show("Внутренняя Ошибка" + innexc.HResult + "\n" + innexc.Message);
                    innexc = innexc.InnerException;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorSerch());
        }
    }
}
