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
using System.Data;
using System.Windows.Forms;

namespace KlinicaConsole.Frames
{
    /// <summary>
    /// Логика взаимодействия для SelectDoctor.xaml
    /// </summary>
    public partial class SelectDoctor : Page
    {
        bool _selected = true;
        public int height = 149;
        List<Function> _functions = new List<Function>();

        public SelectDoctor()
        {
            InitializeComponent();
            FullClick(new object(), new RoutedEventArgs());
            FontWeight fontWeight = FontWeights.Bold;
        }

        private void FullClick(object sender, RoutedEventArgs e)
        {
            if (_selected)
            {
                List<Function> functions = new List<Function>()
                {
                    MainWindow.DB.Functions.Where(u => u.Name == "Терапевт").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Невролог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Дерматолог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Хирург").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Отоларинголог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Стоматолог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Гинеколог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Травмотолог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Офтальмолог").ToList().FirstOrDefault(),
                    MainWindow.DB.Functions.Where(u => u.Name == "Психиатор").ToList().FirstOrDefault()
                };
                ButPanel.ItemsSource = functions;                
                _functions = functions;
                _selected = false;
            }
            else
            {
                ButPanel.ItemsSource = MainWindow.DB.Functions.Where(u => u.Comment == "1").ToList();
                _functions = MainWindow.DB.Functions.Where(u => u.Comment == "1").ToList();
                _selected = true;
            }

        }

        private void DoctorClick(object sender, MouseButtonEventArgs e)
        {
            Function function = _functions.ElementAt(ButPanel.SelectedIndex);
            if (MainWindow.DB.WorkerFunctions.Where(u => u.FunctionId == function.Id).Count() > 0)
            {
                NavigationService.Navigate(new Frames.SelectService(function));
            }
        }

        private void PolisClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PolisSerche(false));
        }
    }
}
