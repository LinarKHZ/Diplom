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
using Klinica.Frames;
using Klinica.Datebase;

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecepPanel.xaml
    /// </summary>
    public partial class RecepPanel : Page
    {

        public RecepPanel()
        {
            InitializeComponent();
            Panel_Click(new object(), new RoutedEventArgs());
        }

        public RecepPanel(TimingSegmentation timing,Patient patient)
        {

        }

        private void Panel_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Frames.DoctorSerch());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.PacientList(1));

        }
        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Frames.NewPatient());

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

            frame1.Navigate(new Frames.DocumentList());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}