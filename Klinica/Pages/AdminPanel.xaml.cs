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

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void UserClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.UserList());
        }
        private void DoctorClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.DoctorList());
        }

        private void PatientClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.PatientList());
        }
        private void ServicesClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.ServicesList());
        }

        private void HoneyClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.HoneyList());

        }

        private void TimeRecordClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.TimeRecordClick());
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
        private void StaticClick(object sender, RoutedEventArgs e)
        {
            //FramePanel.Navigate(new Frames.AdminFrame.StaticList());
        }
        
    }
}
