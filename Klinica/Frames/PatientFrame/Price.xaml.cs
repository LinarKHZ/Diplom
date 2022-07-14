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
using Klinica.Datebase;
using Klinica.Pages;

namespace Klinica.Frames.PatientFrame
{
    /// <summary>
    /// Логика взаимодействия для Price.xaml
    /// </summary>
    public partial class Price : Page
    {
        List<PaymentHistory> payments = new List<PaymentHistory>();

        public Price()
        {
            InitializeComponent();
            payments = payments.Where(u => u.PatientId == MainWindow.patientValue.Id).ToList().OrderByDescending(u => u.Date).ToList();
            payments = MainWindow.DB.PaymentHistories.Where(u => u.PatientId == MainWindow.patientValue.Id).ToList();
            List<Appointment> appointments = MainWindow.DB.Appointments.Where(u => u.Paid == 0).Where(u => u.PatientId == MainWindow.patientValue.Id).ToList();
            PaymentHistory paymentHistory = new PaymentHistory();
            if (appointments.Count > 0)
            {
                paymentHistory.Date = DateTime.Now.Date;
                int sum = 0;
                foreach (var item in appointments)
                {
                    sum = sum + item.Service.Price;
                }
                paymentHistory.Sum = sum;
                paymentHistory.Patient = MainWindow.DB.Patients.Where(u => u.Id == MainWindow.patientValue.Id).FirstOrDefault();
                paymentHistory.PatientId = MainWindow.patientValue.Id;
                paymentHistory.Worker = MainWindow.DB.Workers.Where(u => u.Id == MainWindow.userValue.Id).FirstOrDefault();
                paymentHistory.WorkerId = MainWindow.userValue.Id;
                paymentHistory.Status = 0;
                payments.Add(paymentHistory);
            }
            DocList.ItemsSource = payments;

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (MainWindow.userValue.RoleId == 3)
            {
                PaymentPage pay = new PaymentPage((sender as ListViewItem).DataContext as PaymentHistory);
                pay.ShowDialog();
                NavigationService.Navigate(new Price());
            }
            else
            {

            }
        }
    }
}
