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
using Klinica.Datebase;
using System.Windows.Shapes;

namespace Klinica.Frames.AdminFrame
{
    /// <summary>
    /// Логика взаимодействия для TimeRecordClick.xaml
    /// </summary>
    public partial class TimeRecordClick : Page
    {
        public TimeRecordClick()
        {
            InitializeComponent();
            HoneyL.ItemsSource = MainWindow.DB.ReceptionServices.ToList();
            ReceptionService receptions = MainWindow.DB.ReceptionServices.FirstOrDefault();
            var q = receptions.TimeTable.WorkerFunction.Worker;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
