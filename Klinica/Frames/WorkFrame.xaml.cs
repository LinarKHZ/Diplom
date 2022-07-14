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

namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для WorkFrame.xaml
    /// </summary>
    public partial class WorkFrame : Page
    {
        List<TimePatient> time1 = new List<TimePatient>();
        public WorkFrame()
        {
            InitializeComponent();
            CalendarMine.SelectedDate = DateTime.Now;
            Load();
        }
        private void Load()
        {
            DateTime date = CalendarMine.SelectedDate.Value.Date;
            
            List<TimeTable> tables = MainWindow.DB.TimeTables.Where(u => u.Date == date).Where(u => u.WorkerFunction.Worker.UserId == MainWindow.userValue.Id).ToList();
            List<TimePatient> patients = new List<TimePatient>();
            foreach (TimeTable table in tables)
            {
                ReceptionService receptionService = MainWindow.DB.ReceptionServices.Where(u => u.TimeTable.Id == table.Id).ToList().FirstOrDefault();
                patients.Add(new TimePatient( table, receptionService));
            }
            PatientList.ItemsSource = patients;
            time1 = patients;
        }
        class TimePatient
        {
            public TimeTable Time { get; set; }
            public ReceptionService Reception { get; set; }
            public TimePatient()
            {

            }
            public TimePatient(TimeTable time, ReceptionService reception)
            {
                Time = time;
                Reception = reception;
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("хуй");
            if (PatientList.SelectedIndex>-1)
            {
                TimePatient timePatient = time1.ElementAt(PatientList.SelectedIndex);
                patText.Text = timePatient.Reception.HoneyCard.Patient.LastName + " " +
                               timePatient.Reception.HoneyCard.Patient.Name + " " +
                               timePatient.Reception.HoneyCard.Patient.Patronymic + ", " +
                               "Дата рождения:" + " " +
                               timePatient.Reception.HoneyCard.Patient.Birthday.Date + ", " +
                               "Id:" + " " +
                               timePatient.Reception.HoneyCard.Patient.Id + ", " +
                               "СНИЛС:" + " " +
                               timePatient.Reception.HoneyCard.Patient.SNILS + ", " +
                               "Паспорт:" + " " +
                               timePatient.Reception.HoneyCard.Patient.PassportData + ", " +
                               "Полис ОМС:" + " " +
                               timePatient.Reception.HoneyCard.Id + ", " +
                               "Адрес регистрации:" + " " +
                               timePatient.Reception.HoneyCard.Patient.Address + ", " +
                               "Телефон:" + ", " +
                               timePatient.Reception.HoneyCard.Patient.Telephone;
                ReceptionService receptionService = timePatient.Reception;
                var RS = MainWindow.DB.ReceptionServices.Where(u => u.HoneyCardId == receptionService.HoneyCardId).OrderByDescending(u => u.TimeTable.Date).ToList();
                HistryList.ItemsSource = RS;
            }
            
        }

        private void CalendarMine_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void Protocol_LostFocus(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.SaveChanges();
        }
    }
}
