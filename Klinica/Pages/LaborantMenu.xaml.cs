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

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для LaborantMenu.xaml
    /// </summary>
    public partial class LaborantMenu : Page
    {
        public LaborantMenu()
        {
            InitializeComponent();
            //Panel_Click(this, new RoutedEventArgs());
        }

        private void Panel_Click(object sender, RoutedEventArgs e)
        {

            DateTime dateTime = DateTime.Now.Date;
            List<TimingSegmentation> timings = MainWindow.DB.TimingSegmentations.Where(u => u.Timing.Date == dateTime).Where(u => u.Timing.WorkerFunction.Worker.Id == MainWindow.userValue.Id).ToList();
            if (timings.Count > 0)
            {
                foreach (var item in timings)
                {
                    DateTime date1 = item.Timing.Date.Add(item.TimeS);
                    DateTime date2 = item.Timing.Date.Add(item.TimeF);
                    if ((DateTime.Now > date1) && (DateTime.Now < date2) && (item.AppointmentId != null))
                    {
                        MainWindow.patientValue = item.Appointment.Patient;

                        frame1.Navigate(new Frames.PatientFrame.NewLab(item));

                    }
                    else
                    {

                    }
                }

                User_Click(this, new RoutedEventArgs());
            }
            else
            {
            }


        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

            DateTime dateTime = DateTime.Now.Date;
            var timing = MainWindow.DB.Timings.Where(u => u.Date == dateTime).Where(u => u.WorkerFunction.Worker.Id == MainWindow.userValue.Id).FirstOrDefault();
            DoctorTime doctorTime = new DoctorTime(timing, true);
            if (doctorTime.ShowDialog() == true)
            {
                frame1.Navigate(new Frames.PatientFrame.NewLab(MainWindow.timingSegmentationValue));
            }
            else
            {
                MessageBox.Show("Выбранное время не содержит пациента123");
                Anal_Click(this, new RoutedEventArgs());
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Doc_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.DocumentList());
        }
        private void Anal_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Frames.PatientFrame.LabList());
        }
    }
}
