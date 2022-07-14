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

namespace Klinica.Frames.AdminFrame
{
    /// <summary>
    /// Логика взаимодействия для HoneyList.xaml
    /// </summary>
    public partial class HoneyList : Page
    {
        public HoneyList()
        {
            InitializeComponent();
            HoneyL.ItemsSource = MainWindow.DB.HoneyCards.ToList();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
