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
    /// Логика взаимодействия для DoctorSerch.xaml
    /// </summary>
    public partial class DoctorSerch : Page
    {
        bool IsDoctor = false;
        public DoctorSerch()
        {
            InitializeComponent();
            CalendarMine.SelectedDate = DateTime.Now;
        }
        public DoctorSerch(bool flag):this()
        {
            IsDoctor = true;
            if (IsDoctor)
            {

            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoctorTime doctorTime = new DoctorTime((sender as ListViewItem).DataContext as Timing);
            if (doctorTime.ShowDialog() == true)
            {
                NavigationService.Navigate(new PacientList(true));
            }
            else MessageBox.Show("no");
        }

        private void CalendarMine_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = CalendarMine.SelectedDate.Value.Date;
            DoctorList.ItemsSource = MainWindow.DB.Timings.Where(u => u.Date == date).Where(u => u.WorkerFunction.Worker.Deleted == 0).OrderBy(u => u.WorkerId).ToList();
        }
    }
}
