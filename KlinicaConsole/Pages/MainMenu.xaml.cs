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
using KlinicaConsole.DataBase;

namespace KlinicaConsole.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            frameM.Navigate(new Frames.SelectDoctor());
        }
        private void frameM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.DialogResult = true;
        }
    }
}
