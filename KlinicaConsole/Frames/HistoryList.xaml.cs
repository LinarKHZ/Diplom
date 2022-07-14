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
    /// Логика взаимодействия для HistoryList.xaml
    /// </summary>
    public partial class HistoryList : Page
    {
        public HistoryList()
        {
            InitializeComponent();
            HistryList.ItemsSource = MainWindow.DB.ReceptionServices.Where(u => u.HoneyCardId == MainWindow.honeyValue.Id).OrderByDescending(u => u.TimeTable.Date).ToList();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Распечатать");
        }
    }
}
