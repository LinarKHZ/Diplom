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
using KlinicaConsole.DataBase;

namespace KlinicaConsole.Frames
{
    /// <summary>
    /// Логика взаимодействия для PolisSerche.xaml
    /// </summary>
    public partial class PolisSerche : Page
    {
        bool timetrue = false;
        public PolisSerche(bool timetrue)
        {
            InitializeComponent();
            this.timetrue = timetrue;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Logn.Text != "")
            {
                
                if (MainWindow.DB.HoneyCards.Where(u => u.Id == Logn.Text).FirstOrDefault() != null)
                {
                    Patient patient = MainWindow.DB.HoneyCards.Where(u => u.Id == Logn.Text).FirstOrDefault().Patient;
                    MainWindow.patientValue = patient;
                    MainWindow.honeyValue = MainWindow.DB.HoneyCards.Where(u => u.Id == Logn.Text).FirstOrDefault();
                    if (timetrue)
                    {
                        NavigationService.Navigate(new TalonPrint());
                    }
                    else
                    {
                        NavigationService.Navigate(new PolisInfo());
                    }

                }                
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Обратитесь в регистратуру");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
