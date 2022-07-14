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
using Klinica.Pages;
using Klinica.Datebase;

namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для WorkPanel.xaml
    /// </summary>
    public partial class WorkPanel : Page
    {
        public WorkPanel()
        {
            InitializeComponent();
            Button1(new object(), new RoutedEventArgs());
            if(MainWindow.patientValue != null && MainWindow.timingSegmentationValue != null && MainWindow.timingSegmentationValue.Appointment != null)
            {
                MessageBox.Show(MainWindow.patientValue.Id + " " + MainWindow.timingSegmentationValue.Appointment.PatientId);

                if (MainWindow.patientValue.Id == MainWindow.timingSegmentationValue.Appointment.PatientId)
                {
                    but0.Visibility = Visibility.Visible;
                }
                else
                {
                    but0.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                but0.Visibility = Visibility.Collapsed;
            }
        }
        private void Button0(object sender, RoutedEventArgs e)
        {
            //frameWork.Navigate(new Frames.RecepFrame());
        }
        private void Button1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.patientValue != null)
            {
                frameWork.Navigate(new Frames.PatientFrame.PatientInfo());
            }
            else
            {
                NavigationService.Navigate(new PacientList(1));
            }
        }

        private void Button2(object sender, RoutedEventArgs e)
        {

            frameWork.Navigate(new Frames.PatientFrame.RecordInfo());
        }
        private void Button3(object sender, RoutedEventArgs e)
        {
            frameWork.Navigate(new Frames.DocumentList(MainWindow.patientValue.Id));
        }

        private void Button4(object sender, RoutedEventArgs e)
        {
            //frame1.Navigate(new Frames.Help());
            frameWork.Navigate(new Frames.PatientFrame.Price());

        }
        private void Button5(object sender, RoutedEventArgs e)
        {
            frameWork.Navigate(new Frames.PatientFrame.LabInfo());
        }
        private void Button7(object sender, RoutedEventArgs e)
        {
            //frame1.Navigate(new Frames.Help());
        }
    }
}
