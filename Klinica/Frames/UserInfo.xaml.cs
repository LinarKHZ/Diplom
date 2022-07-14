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
using Klinica.Datebase;
using System.Globalization;
using Microsoft.Win32;


namespace Klinica.Frames
{
    /// <summary>   
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        Worker worker = MainWindow.DB.Workers.Where(u => u.UserId == MainWindow.userValue.Id).ToList().ElementAtOrDefault(0);
        public UserInfo()
        {
            InitializeComponent();
            FName.Text = worker.LastName;
            NName.Text = worker.Name;
            LName.Text = worker.Patronymic;
            Birthday.Text = worker.Birthday.ToString("D", CultureInfo.GetCultureInfo("en-US"));
            Passport.Text = worker.PassportData;
            SNILS.Text = worker.SNILS;
            Adress.Text = worker.Address;
            Email.Text = worker.Email;
            Telephone.Text = worker.Telephone;
        }

    }
}
