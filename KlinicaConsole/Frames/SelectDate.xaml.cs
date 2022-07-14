using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KlinicaConsole.DataBase;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace KlinicaConsole.Frames
{
    /// <summary>
    /// Логика взаимодействия для SelectDate.xaml
    /// </summary>
    public partial class SelectDate : Page
    {
        public WorkerFunction workerFunction = new WorkerFunction();
        public List<TimeTable> _timeTable = new List<TimeTable>();
        public SelectDate( WorkerFunction _workerFunction)
        {
            InitializeComponent();
            workerFunction = _workerFunction;
            CalMane.SelectedDate = DateTime.Now;
            
        }
        private void Load()
        {
            DateTime date = CalMane.SelectedDate.Value.Date;
            List<TimeTable> timeTables = MainWindow.DB.TimeTables.Where(u => u.Date == date).Where(u => u.DoctorId == workerFunction.Id).ToList();
            foreach (var item in timeTables)
            {
                DateTime date1 = item.Date + item.Time;
                if (date1 < DateTime.Now)
                {
                    item.Status = 2;
                }
            }
            ButPanel.ItemsSource = timeTables;
            _timeTable = timeTables;
        }

        private void DateClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TimeTable table = new TimeTable();
            if (ButPanel.SelectedIndex > -1)
            {
                table = _timeTable.ElementAt(ButPanel.SelectedIndex);
                MainWindow.tableValue = table;
                NavigationService.Navigate(new PolisSerche(true));
            }

        }
        class DateClass
        {
            public string Name { get; set; }
            public int Status { get; set; }
            public DateClass(string name, int status) { Name = name; Status = status; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void CalendarMine_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ButPanel.Focus();
            Load();
        }
    }
}
