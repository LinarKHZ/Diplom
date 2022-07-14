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

namespace Klinica.Frames.PatientFrame
{
    /// <summary>
    /// Логика взаимодействия для RecordList.xaml
    /// </summary>
    public partial class RecordPanel : Window
    {
        DescriptionVisit dec = new DescriptionVisit();
        public RecordPanel(DescriptionVisit visit)
        {
            InitializeComponent();
            dec = visit;
            MainGrid.DataContext = MainWindow.DB.DescriptionVisits.Where(u => u.Id == visit.Id).FirstOrDefault();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var pat = MainWindow.DB.DescriptionVisits.Where(u => u.Id == dec.Id).FirstOrDefault();
            pat = MainGrid.DataContext as DescriptionVisit;
            MainWindow.DB.SaveChanges();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            MainGrid.DataContext = MainWindow.DB.DescriptionVisits.Where(u => u.Id == dec.Id).FirstOrDefault();
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            dec = MainGrid.DataContext as DescriptionVisit;
            string str = "ФИО пациента: " + dec.Appointment.Patient.PatientName  + '\n'
                        + "ФИО врача: " + dec.Appointment.Timing.WorkerFunction.Worker.WorkerName + '\n'
                        + "Дата: " + dec.Appointment.Timing.Date + '\n'
                        + "Специальность: " + dec.Appointment.Service.Name + '\n'
                        + "Жалобы: " + dec.Complaints + '\n'
                        + "Анамнез: " + dec.Anamnesis + '\n'
                        + "Обследование: " + dec.Examination + '\n'
                        + "План лечения: " + dec.TreatmentPlan + '\n'
                        + "План обследования: " + dec.SurveyPlan + '\n'
                        + "Рекомендации: " + dec.Recommendations + '\n'
                        + "Заключение: " + dec.Conclusion + '\n'
                        + "Итоговая сумма: " + dec.Id;
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();
            Word.Paragraph p1 = document.Paragraphs.Add();
            Word.Range r1 = p1.Range;
            r1.Text = str;
            application.Visible = true;
            document.SaveAs2(@"C:\SaveFile\Diagnos.docx");
        }
    }
}
