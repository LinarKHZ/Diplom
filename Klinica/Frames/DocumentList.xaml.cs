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
using Klinica.Pages;
using Microsoft.Win32;

namespace Klinica.Frames
{
    /// <summary>
    /// Логика взаимодействия для DocumentList.xaml
    /// </summary>
    public partial class DocumentList : Page
    {
        List<Document> documents = new List<Document>();
        public DocumentList()
        {
            InitializeComponent();
            catbox.ItemsSource = MainWindow.DB.DocumentsCategories.ToList().ConvertAll(u => u.Name);

            PName.IsEnabled = true;
            catbox.SelectedIndex = 0;
        }
        public DocumentList(int Id):this()
        {
            PName.Text = Id.ToString();
            PName.IsEnabled = false;

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
                itemsInfo = itemsInfo.Where(i => i.Name.ToLower().IndexOf(NName.Text.ToLower()) != -1).ToList();
            }
            if (PName.Text != "")
            {

                List<Document> doc = new List<Document>();
                foreach (var item in itemsInfo)
                {
                    if (item.Patient != null)
                    {
                        if (item.Patient.PatientName.ToLower().IndexOf(PName.Text.ToLower()) != -1)
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
            if (Comment.Text != "")
            {
                itemsInfo = itemsInfo.Where(i => i.Comment.ToLower().IndexOf(Comment.Text.ToLower()) != -1).ToList();
            }
            itemsInfo = itemsInfo.Where(i => i.CategoryId == catbox.SelectedIndex+1).ToList();

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
            Page_Loaded(this, new RoutedEventArgs());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            documents = MainWindow.DB.Documents.OrderBy(p => p.Name).ToList();
            MainWindow.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DocList.ItemsSource = documents;
            Save_Click(new object(), new RoutedEventArgs());
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DocumentView document = new DocumentView((sender as ListViewItem).DataContext as Document);
            document.ShowDialog();

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.AddDocument();
            win.ShowDialog();
            Page_Loaded(new object(), new RoutedEventArgs());
        }
    }
}