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
using Word = Microsoft.Office.Interop.Word;
using Klinica.Datebase;
using System.Reflection;
namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для NewRecord.xaml
    /// </summary>
    public partial class NewRecord : Page
    {
        List<Service> services = new List<Service>();
        public NewRecord()
        {
            InitializeComponent();
            FIODoctor.Text = MainWindow.timingSegmentationValue.Timing.WorkerFunction.Worker.WorkerName;
            DoctorFuction.Text = MainWindow.timingSegmentationValue.Timing.WorkerFunction.Function.Name;
            FIOPatient.Text = MainWindow.patientValue.PatientName;
            DateSelect.Text = String.Format("{0:MM/dd/yyyy}", MainWindow.timingSegmentationValue.Timing.Date);
            var abc = MainWindow.timingSegmentationValue.TimeS;
            TimeSelect.Text = abc.ToString();
            services = MainWindow.DB.Services.Where(u => u.FunctionId == MainWindow.timingSegmentationValue.Timing.WorkerFunction.Function.Id).Where(u => u.Status == 1).ToList();
            ServiceList.ItemsSource = services;

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Service serv = new Service();
                serv = (sender as ListViewItem).DataContext as Service;
                Appointment appointment = new Appointment();
                appointment.PatientId = MainWindow.patientValue.Id;
                appointment.TimingId = MainWindow.timingSegmentationValue.TimingId;
                appointment.ServicesId = serv.Id;
                appointment.Paid = 0;
                MainWindow.DB.Appointments.Add(appointment);
                MainWindow.DB.SaveChanges();
                var timing = MainWindow.DB.TimingSegmentations.Where(u => u.Id == MainWindow.timingSegmentationValue.Id).FirstOrDefault();
                timing.AppointmentId = MainWindow.DB.Appointments.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                MainWindow.DB.SaveChanges();
                {
                    string str = "ФИО пациента: " + MainWindow.patientValue.PatientName + '\n'
                                + "ФИО врача: " + MainWindow.timingSegmentationValue.Timing.WorkerFunction.Worker.WorkerName + '\n'
                                + "Дата: " + MainWindow.timingSegmentationValue.Timing.Date + '\n'
                                + "Время начала: " + MainWindow.timingSegmentationValue.TimeS + '\n'
                                + "Время окончания: " + MainWindow.timingSegmentationValue.TimeF + '\n'
                                + "Специальность: " + MainWindow.timingSegmentationValue.Appointment.Service.Name + '\n'
                                + "Кабинет: " + MainWindow.timingSegmentationValue.Timing.WorkerFunction.Cabinet + '\n'
                                + " ";
                    var application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph p1 = document.Paragraphs.Add();
                    Word.Range r1 = p1.Range;
                    r1.Text = str;
                    application.Visible = true;
                    document.SaveAs2(@"C:\SaveFile\Naprav.docx");
                }
                NavigationService.Navigate(new DoctorSerch());
            }
            catch (Exception ex)
            {
                var innexc = ex.InnerException;
                while (innexc != null)
                {
                    MessageBox.Show("Внутренняя Ошибка" + innexc.HResult + "\n" + innexc.Message);
                    innexc = innexc.InnerException;
                }
            }
        }
    }
}
