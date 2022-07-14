using System;
using System.Collections.Generic;
using System.IO;
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
using System.Globalization;
using Microsoft.Win32;


namespace KlinicaConsole.Frames
{
    /// <summary>   
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        Patient patient = MainWindow.patientValue;
        public UserInfo()
        {
            InitializeComponent();
            FName.Text = patient.LastName;
            NName.Text = patient.Name;
            LName.Text = patient.Patronymic;
            Birthday.Text = patient.Birthday.ToString("D", CultureInfo.GetCultureInfo("en-US"));
            Passport.Text = patient.PassportData;
            SNILS.Text = patient.SNILS;
            Adress.Text = patient.Address;
            Email.Text = patient.Email;
            Telephone.Text = patient.Telephone;
        }
    }
}
