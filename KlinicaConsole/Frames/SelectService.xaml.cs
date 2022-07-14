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

namespace KlinicaConsole.Frames
{
    /// <summary>
    /// Логика взаимодействия для SelectService.xaml
    /// </summary>
    public partial class SelectService : Page
    {
        Function _function = new Function();
        List<Worker> workers1 = new List<Worker>();
        public SelectService(Function function)
        {
            _function = function;
            InitializeComponent();
            upload();
        }

        private void upload()
        {            //services = MainWindow.DB.Services.Where(u => u.FunctionId == _function.Id).OrderBy(f => f.Name).Skip(SkipValue).Take(20).ToList();
            //ButPanel.ItemsSource = services;
            List<WorkerFunction> _WorkerFunctions = new List<WorkerFunction>();
            _WorkerFunctions = MainWindow.DB.WorkerFunctions.Where(u => u.FunctionId == _function.Id).ToList();
            List<Worker> workers = new List<Worker>();
            foreach (var item in _WorkerFunctions)
            {
                workers.Add(MainWindow.DB.Workers.Where(u => u.Id == item.Id).ToList().FirstOrDefault());
            }
            ButPanel.ItemsSource = workers;
            workers1 = workers;
        }

        private void ServiceClick(object sender, MouseButtonEventArgs e)
        {
            Worker worker = workers1.ElementAt(ButPanel.SelectedIndex);
            WorkerFunction workerFunction = MainWindow.DB.WorkerFunctions.Where(u => u.FunctionId == _function.Id).Where(u => u.WorkerId == worker.Id).FirstOrDefault();
            if(workerFunction != null)
            {
            NavigationService.Navigate(new SelectDate(workerFunction));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
