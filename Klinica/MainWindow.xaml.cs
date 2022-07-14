using System.Windows;
using System.Windows.Navigation;
using Klinica.Datebase;

namespace Klinica
{
    public partial class MainWindow : NavigationWindow
    {
        public static KlinicaDBEntities1 DB = new KlinicaDBEntities1();
        public static Worker userValue = null;
        public static Patient patientValue = null;
        public static TimingSegmentation timingSegmentationValue = null;
        public MainWindow()
        {

            InitializeComponent();
            string str = "Частная клиника " + '\u0022' + "Айболит" + '\u0022';
            this.Title = str;
            MnWindow.NavigationService.Navigate(new Pages.Authorization());
        }
    }
}
