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
    /// Логика взаимодействия для MenedgerMenu.xaml
    /// </summary>
    public partial class MenedgerMenu : Page
    {
        public MenedgerMenu()
        {
            InitializeComponent();
        }
        private void Panel_Click(object sender, RoutedEventArgs e)
        {

            //frame1.Navigate(new Frames.RecepPanel());

        }

        private void User_Click(object sender, RoutedEventArgs e)
        {

            //frame1.Navigate(new Frames.Helper());

        }
        private void Doctor_Click(object sender, RoutedEventArgs e)
        {

            //frame1.Navigate(new Frames.AdminFrame.PatientList());

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

            //frame1.Navigate(new Frames.Help());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
