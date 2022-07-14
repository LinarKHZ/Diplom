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
using KlinicaConsole.Pages;
using System.Diagnostics;
using System.Threading;

namespace KlinicaConsole
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static KlinicaDBEntities DB = new KlinicaDBEntities();
        public static Patient patientValue;
        public static TimeTable tableValue;
        public static HoneyCard honeyValue;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            if (mainMenu.ShowDialog() == true)
            {
                MessageBox.Show("Работа завершилась с ошибкой" + '\u0022' + "0" + '\u0022');
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                MessageBox.Show("Работа завершилась с ошибкой" + '\u0022' + "-1" + '\u0022');
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
