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
    /// Логика взаимодействия для TalonPrint.xaml
    /// </summary>
    public partial class TalonPrint : Page
    {
        public TalonPrint()
        {
            InitializeComponent();
            ReceptionService receptionService = new ReceptionService();
            receptionService.HoneyCardId = MainWindow.honeyValue.Id;
            receptionService.TimeTibleId = MainWindow.tableValue.Id;
            TimeTable timeTable = MainWindow.DB.TimeTables.Where(u => u.Id == MainWindow.tableValue.Id).FirstOrDefault();
            timeTable.Status = 2;
            MainWindow.DB.ReceptionServices.Add(receptionService);
            MainWindow.DB.SaveChanges();
            HistoryAut historyLogin = new HistoryAut();
            historyLogin.Datetime = DateTime.Now;
            int int1 = MainWindow.DB.ReceptionServices.Where(u => u.HoneyCardId == MainWindow.honeyValue.Id).Where(u => u.TimeTibleId == MainWindow.tableValue.Id).FirstOrDefault().Id;
            historyLogin.ReceptionService = int1;
            MainWindow.DB.HistoryAuts.Add(historyLogin);
            MainWindow.DB.SaveChanges();
            T1.Content = "Номер талона: " + MainWindow.DB.ReceptionServices.Count();
            T2.Content = "ФИО пациента: " + MainWindow.patientValue.LastName + " " + MainWindow.patientValue.Name + " " + MainWindow.patientValue.Patronymic;
            T3.Content = "ФИО врача: " + MainWindow.tableValue.WorkerFunction.Worker.LastName + " " + MainWindow.tableValue.WorkerFunction.Worker.Name[0] + ". " + MainWindow.tableValue.WorkerFunction.Worker.Patronymic[0];
            T4.Content = "Дата: " + MainWindow.tableValue.Date;
            T5.Content = "Время: " + MainWindow.tableValue.Time;
            T6.Content = "Кабинет: " + MainWindow.tableValue.CabinetNumber;

        }

        private void FullClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectDoctor());
        }
    }
}
