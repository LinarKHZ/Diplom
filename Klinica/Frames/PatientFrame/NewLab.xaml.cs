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
    /// Логика взаимодействия для NewLab.xaml
    /// </summary>
    public partial class NewLab : Page
    {
        LabResult lab = new LabResult();
        public NewLab(TimingSegmentation timing)
        {
            InitializeComponent();
            LabCatalog labCatalog = MainWindow.DB.LabCatalogs.Where(u => u.AppointId == timing.AppointmentId).FirstOrDefault();
            if (labCatalog == null)
            {
                LabCatalog catalog = new LabCatalog();
                catalog.WorkerId = MainWindow.userValue.Id;
                catalog.AppointId = timing.Appointment.Id;
                catalog.DateTimeTaken = DateTime.Now;
                catalog.DateResultExpected = DateTime.Now.AddDays(1);
                MainWindow.DB.LabCatalogs.Add(catalog);
                MainWindow.DB.SaveChanges();
                LabResult labResult = new LabResult();
                labResult.LabCatalogId = MainWindow.DB.LabCatalogs.ToList().OrderByDescending(u => u.Id).FirstOrDefault().Id;
                labResult.Result = "";
                labResult.Comment = "";
                MainGrid.DataContext = labResult;
                lab = labResult;
                MainWindow.DB.LabResults.Add(((LabResult)MainGrid.DataContext));
                MainWindow.DB.SaveChanges();
            }
            else
            {
                LabResult labResult = MainWindow.DB.LabResults.Where(u => u.LabCatalogId == labCatalog.Id).FirstOrDefault();
                MainGrid.DataContext = labResult;
            }

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.LabResults.Add(((LabResult)MainGrid.DataContext));
            MainWindow.DB.SaveChanges();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
