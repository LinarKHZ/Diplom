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
    /// Логика взаимодействия для StaticList.xaml
    /// </summary>
    public partial class StaticList : Page
    {
        public StaticList()
        {
            InitializeComponent();
            DateTime date = DateTime.Now.Date;
            int date1 = DateTime.Now.Month;
            int date2 = DateTime.Now.Year;
            int c1= 0;
            int c2= 0;
            int c3= 0;
            int c4= 0;
            int c5= 0;
            int c6= 0;
            int b1= 0;
            int b2= 0;
            int b3= 0;
            foreach (var item in MainWindow.DB.HistoryAuts.ToList())
            {
                if (item.Datetime.Date == date)
                {
                    c1 = c1 + 1;
                }
            }
            foreach (var item in MainWindow.DB.HistoryAuts.ToList())
            {
                if (item.Datetime.Month == date1)
                {
                    c2 = c2 + 1;
                }
            }
            foreach (var item in MainWindow.DB.HistoryAuts.ToList())
            {
                if (item.Datetime.Year == date2)
                {
                    c3 = c3 + 1;
                }
            }
            foreach (var item in MainWindow.DB.ReceptionServices.ToList())
            {
                if (item.TimeTable.Date == date)
                {
                    c4 = c4 + 1;
                }
            }
            foreach (var item in MainWindow.DB.ReceptionServices.ToList())
            {
                if (item.TimeTable.Date.Month == date1)
                {
                    c5 = c5 + 1;
                }
            }
            foreach (var item in MainWindow.DB.ReceptionServices.ToList())
            {
                if (item.TimeTable.Date.Year == date2)
                {
                    c6 = c6 + 1;
                }
            }
            foreach (var item in MainWindow.DB.HistoryLogins.ToList())
            {
                if (item.Datetime.Value.Date == date)
                {
                    b1 = b1 + 1;
                }
            }
            foreach (var item in MainWindow.DB.HistoryLogins.ToList())
            {
                if (item.Datetime.Value.Month == date1)
                {
                    b2 = b2 + 1;
                }
            }
            foreach (var item in MainWindow.DB.HistoryLogins.ToList())
            {
                if (item.Datetime.Value.Year == date2)
                {
                    b3 = b3 + 1;
                }
            }
            Info infoPac = new Info(c1, c2, c3, c4, c5, c6);
            Info infoDoc = new Info(b1,b2,b3,0,0,0);
            PacInfo.Content = infoPac;
            DocInfo.Content = infoDoc;
        }
        class Info
        {
            int Pac1 { get; set; }
            int Pac2 { get; set; }
            int Pac3 { get; set; }
            int Pac4 { get; set; }
            int Pac5 { get; set; }
            int Pac6 { get; set; }
            public Info(int pac1, int pac2, int pac3, int pac4, int pac5, int pac6)
            {
                Pac1 = pac1;
                Pac2 = pac2;
                Pac3 = pac3;
                Pac4 = pac4;
                Pac5 = pac5;
                Pac6 = pac6;
            }

        }
    }
}
