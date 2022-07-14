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
    /// Логика взаимодействия для LabInfo.xaml
    /// </summary>
    public partial class LabInfo : Page
    {
        List<LabResult> labResults = new List<LabResult>();
        public LabInfo()
        {
            InitializeComponent();
            Save_Click(this, new RoutedEventArgs());
            DocList.ItemsSource = MainWindow.DB.LabResults.Where(u => u.LabCatalog.Appointment.PatientId == MainWindow.patientValue.Id).OrderByDescending(u => u.LabCatalog.DateTimeTaken).ToList();
            catbox.ItemsSource = MainWindow.DB.Services.Where(u => u.CategoryId == 1).ToList();

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var itemsInfo = labResults;
            if (Number.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Id.ToString().IndexOf(Number.Text.ToLower()) != -1).ToList();
            }
            if (NName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.LabCatalog.WorkerFunction.Worker.WorkerName.ToLower().IndexOf(NName.Text.ToLower()) != -1).ToList();
            }
            if (PName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.LabCatalog.Appointment.Patient.PatientName.ToLower().IndexOf(PName.Text.ToLower()) != -1).ToList();

            }
            itemsInfo = itemsInfo.Where(i => i.LabCatalog.Appointment.Service.Id == ((Service)catbox.SelectedItem).Id).ToList();

            DocList.ItemsSource = itemsInfo;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
