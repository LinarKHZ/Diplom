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
    /// Логика взаимодействия для RecordInfo.xaml
    /// </summary>
    public partial class RecordInfo : Page
    {
        public RecordInfo()
        {
            InitializeComponent();

            var c = MainWindow.DB.DescriptionVisits.Where(u => u.Appointment.PatientId == MainWindow.patientValue.Id).ToList().OrderByDescending(u => u.Appointment.Timing.Date).ToList();
            RecordList.ItemsSource = c;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DescriptionVisit descriptionVisit = (sender as ListViewItem).DataContext as DescriptionVisit;
            RecordPanel recordPanel = new RecordPanel(descriptionVisit);
            recordPanel.ShowDialog();
        }
    }
}
