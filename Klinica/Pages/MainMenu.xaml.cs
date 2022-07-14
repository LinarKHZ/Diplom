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

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private BrushConverter bc = new BrushConverter();

        public MainMenu()
        {
            InitializeComponent();
            Panel_Click (new object(), new RoutedEventArgs());
        }

        private void Panel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.patientValue != null)
            {
                frame1.Navigate(new Frames.WorkPanel());
            }
            else
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
                            frame1.Navigate(new Frames.WorkPanel());
                        }
                        else
                        {
                        }
                    }

                    frame1.Navigate(new Frames.PacientList(1));
                }
                else
                {
                    frame1.Navigate(new Frames.PacientList(1));
                }
            }

        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

            DateTime dateTime = DateTime.Now.Date;
            var timing = MainWindow.DB.Timings.Where(u => u.Date == dateTime).Where(u => u.WorkerFunction.Worker.Id == MainWindow.userValue.Id).FirstOrDefault();
            DoctorTime doctorTime = new DoctorTime(timing,true);
            if (doctorTime.ShowDialog() == true)
            {
                frame1.Navigate(new Frames.WorkPanel());
            }
            else
            {
                MessageBox.Show("Выбранное время не содержит пациента");
                frame1.Navigate(new Frames.PacientList(1));
            }

        }
        private void Doctor_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.PacientList(1));

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.DoctorSerch(true));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Doc_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.DocumentList());
        }
    }
}
