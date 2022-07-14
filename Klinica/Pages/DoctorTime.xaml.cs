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
using Klinica.Datebase;
using Klinica.Frames;

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorTime.xaml
    /// </summary>
    public partial class DoctorTime : Window
    {
        Timing _timing = new Timing();
        bool IsDoctor = false;
        public DoctorTime(Timing timing)
        {
            _timing = timing;
            List<TimingSegmentation> timings = MainWindow.DB.TimingSegmentations.Where(u => u.TimingId == _timing.Id).OrderBy(u => u.TimeS).ToList();
            foreach (var item in timings)
            {
                DateTime date = item.Timing.Date.Add(item.TimeS);
                if (DateTime.Now > date)
                {
                    item.Actively = 2;
                }
                else
                {
                    item.Actively = 1;
                }
            }
            InitializeComponent();
            TimingList.ItemsSource = timings;
            DoctorText.Text = timing.WorkerFunction.Worker.WorkerName;
        }
        public DoctorTime(Timing timing,bool flag)
        {
            _timing = timing;
            List<TimingSegmentation> timings = MainWindow.DB.TimingSegmentations.Where(u => u.TimingId == _timing.Id).OrderBy(u => u.TimeS).ToList();
            foreach (var item in timings)
            {
                DateTime date = item.Timing.Date.Add(item.TimeS);
                if (DateTime.Now > date)
                {
                    item.Actively = 2;
                }
                else
                {
                    item.Actively = 1;
                }
            }
            InitializeComponent();
            TimingList.ItemsSource = timings;
            DoctorText.Text = timing.WorkerFunction.Worker.WorkerName;
            IsDoctor = true;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsDoctor)
            {
                MainWindow.timingSegmentationValue = (sender as ListViewItem).DataContext as TimingSegmentation;
                if (MainWindow.timingSegmentationValue.AppointmentId != null)
                {
                    MainWindow.patientValue = MainWindow.DB.Patients.Where(u => u.Id == MainWindow.timingSegmentationValue.Appointment.PatientId).FirstOrDefault();
                    this.DialogResult = true;

                }
                else
                {
                    this.Close();
                }

            }
            else
            {
                if (((sender as ListViewItem).DataContext as TimingSegmentation).Actively == 1)
                {
                    MainWindow.timingSegmentationValue = (sender as ListViewItem).DataContext as TimingSegmentation;
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Это время не доступно");
                }
            }
        }
    }
}
