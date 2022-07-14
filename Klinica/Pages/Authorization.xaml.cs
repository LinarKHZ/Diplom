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
using System.Security.Cryptography;
using Klinica.Datebase;

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            Logn.Text = "User";
            Pass.Password = "User";
            MainWindow.patientValue = null;
            MainWindow.userValue = null;
            MainWindow.timingSegmentationValue = null;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Logn.Text != "" && Pass.Password != "")
            {
                Worker worker = MainWindow.DB.Workers.Where(u => u.Login == Logn.Text).FirstOrDefault();
                if (worker != null)
                {
                    string sSourceData;
                    sSourceData = Pass.Password;
                    if ((worker.Password == sSourceData) & (worker.Deleted == 0))
                    {
                        MainWindow.userValue = worker;
                        switch (worker.RoleId)
                        {
                            case 1:                                
                                this.NavigationService.Navigate(new Pages.AdminPanel());
                                break;                                
                            case 2:
                                this.NavigationService.Navigate(new Pages.MenedgerMenu());
                                break;
                            case 3:
                                this.NavigationService.Navigate(new Pages.RecepPanel());
                                break;
                            case 4:
                                this.NavigationService.Navigate(new Pages.MainMenu());
                                break;
                            case 5:
                                this.NavigationService.Navigate(new Pages.LaborantMenu());
                                break;
                            default:
                                break;
                        }   
                    }
                    else
                    {
                        MessageBox.Show("Пароль не правильный!");
                    }

                }
                else MessageBox.Show("Логин или пароль не правильный!");
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void Path_Click(object sender, MouseButtonEventArgs e)
        {
            if (PassText.Visibility == Visibility.Visible)
            {
                Pass.Password = PassText.Text;
                PassText.Visibility = Visibility.Hidden;
                Pass.Visibility = Visibility.Visible;
            }
            else
            {
                PassText.Text = Pass.Password;
                PassText.Visibility = Visibility.Visible;
                Pass.Visibility = Visibility.Hidden;
            }
        }

        private void Logn_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Logn.Text == "Логин" && PassText.Text == "Пароль" || PassText.Text == "")
                Logn.Text = "";
            else if (Logn.Text == "Логин")
            {
                Logn.Text = "";
                PassText.Visibility = Visibility.Hidden;
                Pass.Visibility = Visibility.Visible;
            }
        }

        private void Logn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Logn.Text == "")
                Logn.Text = "Логин";
        }

        private void PassText_GotFocus(object sender, RoutedEventArgs e)
        {
            Pass.Focus();
            PassText.Visibility = Visibility.Hidden;
            Pass.Visibility = Visibility.Visible;
            Pass.Focus();
        }

        private void Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == "")
            {
                Pass.Visibility = Visibility.Hidden;
                PassText.Visibility = Visibility.Visible;
                PassText.Text = "Пароль";
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Registration());
            MessageBox.Show("Обратитесь в регистратуру");
        }
    }
}
