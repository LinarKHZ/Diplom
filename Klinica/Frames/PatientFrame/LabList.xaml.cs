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

namespace Klinica.Frames.PatientFrame
{
    /// <summary>
    /// Логика взаимодействия для LabList.xaml
    /// </summary>
    public partial class LabList : Page
    {

        List<LabResult> documents = new List<LabResult>();
        public LabList()
        {
            InitializeComponent();
            DocList.ItemsSource = MainWindow.DB.LabResults.ToList().OrderByDescending(u => u.LabCatalog.DateTimeTaken).ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var itemsInfo = documents;
            if (Number.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Id.ToString().IndexOf(Number.Text.ToLower()) != -1).ToList();
            }
            if (NName.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.LabCatalog.Appointment.Service.Name.ToLower().IndexOf(NName.Text.ToLower()) != -1).ToList();
            }
            if (PName.Text != "")
            {

                List<LabResult> doc = new List<LabResult>();
                foreach (var item in itemsInfo)
                {
                    if (item.LabCatalog.Appointment.Patient != null)
                    {
                        if (item.LabCatalog.Appointment.Patient.PatientName.ToLower().IndexOf(PName.Text.ToLower()) != -1)
                        {
                            doc.Add(item);
                        }
                    }
                }
                itemsInfo = doc;
            }
            if (Comment.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Comment.ToLower().IndexOf(Comment.Text.ToLower()) != -1).ToList();
            }
            if (catbox.SelectedIndex != 0)
            {
                if (catbox.SelectedIndex==1)
                {
                    itemsInfo = itemsInfo.Where(i => i.LabCatalog.DateResultReal != null).ToList();
                }
                else
                {
                    itemsInfo = itemsInfo.Where(i => i.LabCatalog.DateResultReal == null).ToList();
                }
            }

            //if (itemsInfo != null)
            //{
            DocList.ItemsSource = itemsInfo;
            //}
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Number.Text = "";
            NName.Text = "";
            PName.Text = "";
            Comment.Text = "";
            catbox.SelectedIndex = 0;
            Save_Click(this, new RoutedEventArgs());
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new NewLab(((sender as ListViewItem).DataContext as LabResult).LabCatalog.Appointment.TimingSegmentations.FirstOrDefault()));
        }
    }
}
