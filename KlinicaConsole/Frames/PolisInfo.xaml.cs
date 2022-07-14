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

namespace KlinicaConsole.Frames
{
    /// <summary>
    /// Логика взаимодействия для PolisInfo.xaml
    /// </summary>
    public partial class PolisInfo : Page
    {
        public PolisInfo()
        {
            InitializeComponent();
            FullName_Click(new object(), new RoutedEventArgs());
        }

        private void FullName_Click(object sender, RoutedEventArgs e)
        {
            PolisFrame.Navigate(new UserInfo());
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            PolisFrame.Navigate(new HistoryList());
        }

        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectDoctor());
            MainWindow.patientValue = null;
        }
    }
}
