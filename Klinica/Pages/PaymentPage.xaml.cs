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
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;
using Klinica.Datebase;
using System.Reflection;


namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Window
    {
        PaymentHistory payment = new PaymentHistory();
        List<Appointment> appointments;
        public PaymentPage(PaymentHistory paymentHistory)
        {
            InitializeComponent();
            payment = paymentHistory;
            MineGrid.DataContext = paymentHistory;
            if (payment.Status == 0)
            {
                appointments = MainWindow.DB.Appointments.Where(u => u.Paid == 0).Where(u => u.PatientId == MainWindow.patientValue.Id).ToList();
            }
            else
            {
                appointments = MainWindow.DB.PaymentAppointments.Where(u => u.PaymontId == payment.Id).ToList().ConvertAll(u => u.Appointment).ToList();
            }
            DocList.ItemsSource = appointments;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(payment.Status == 0)
            {
                payment.Status = 1;
                MainWindow.DB.PaymentHistories.Add(payment);
                MainWindow.DB.SaveChanges();
                List<PaymentAppointment> paymentAppointments = new List<PaymentAppointment>();
                PaymentHistory history = MainWindow.DB.PaymentHistories.ToList().OrderByDescending(u => u.Id).FirstOrDefault();
                foreach (var item in appointments)
                {
                    item.Paid = 1;
                    PaymentAppointment pa = new PaymentAppointment();
                    pa.PaymontId = payment.Id;
                    pa.AppointmentId = item.Id;
                    paymentAppointments.Add(pa);
                }
                
                MainWindow.DB.PaymentAppointments.AddRange(paymentAppointments);
                MainWindow.DB.SaveChanges();
                
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            string str = "ФИО пациента: " + payment.Patient.PatientName + '\n'
                        + "ФИО врача: " + payment.Worker.WorkerName + '\n'
                        + "Дата: " + payment.Date + '\n'
                        + "Итоговая сумма: " + payment.Sum + '\n'
                        + "Итоговая сумма: " + payment.Sum;
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();
            Word.Paragraph p1 = document.Paragraphs.Add();
            Word.Range r1 = p1.Range;
            r1.Text = str;
            Word.Paragraph p2 = document.Paragraphs.Add();
            Word.Range r2 = p2.Range;
            int s = appointments.Count() + 1;
            Word.Table t2 = document.Tables.Add(r2, s, 6);
            t2.Borders.InsideLineStyle = t2.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            t2.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            Word.Range cellRange;
            cellRange = t2.Cell(1,1).Range;
            cellRange.Text = "Номер";
            cellRange = t2.Cell(1,2).Range;
            cellRange.Text = "Дата и время";
            cellRange = t2.Cell(1,3).Range;
            cellRange.Text = "ФИО врача";
            cellRange = t2.Cell(1,4).Range;
            cellRange.Text = "Специальность";
            cellRange = t2.Cell(1,5).Range;
            cellRange.Text = "Услуга";
            cellRange = t2.Cell(1,6).Range;
            cellRange.Text = "Цена";
            t2.Rows[1].Range.Bold = 1;
            t2.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            int i = 2;
            foreach (var item in appointments)
            {
                cellRange = t2.Cell(i, 1).Range;
                cellRange.Text = item.Id.ToString();
                cellRange = t2.Cell(i, 2).Range;
                cellRange.Text = item.Timing.Date.ToString();
                cellRange = t2.Cell(i, 3).Range;
                cellRange.Text = item.Timing.WorkerFunction.Worker.WorkerName;
                cellRange = t2.Cell(i, 4).Range;
                cellRange.Text = item.Patient.PatientName;
                cellRange = t2.Cell(i, 5).Range;
                cellRange.Text = item.Service.Name;
                cellRange = t2.Cell(i, 6).Range;
                cellRange.Text = item.Service.Price.ToString() + "руб";
                i++;
            }
            application.Visible= true;
            document.SaveAs2(@"C:\SaveFile\Check.docx");

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
