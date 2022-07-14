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
using System.Windows.Shapes;
using Klinica.Datebase;
using Microsoft.Win32;

namespace Klinica.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDocument.xaml
    /// </summary>
    public partial class AddDocument : Window
    {
        bool IsLab = false;
        Patient patient = new Patient();
        string s = "";
        public AddDocument()
        {
            InitializeComponent();
            catbox.ItemsSource = MainWindow.DB.DocumentsCategories.ToList().ConvertAll(u => u.Name);

        }
        public AddDocument(Patient patient):this()
        {
            IsLab = true;
            this.patient = patient;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (s != "")
            {
                try
                {
                    String[] strings = s.Split('\u005C');
                    string str = strings[strings.Length - 1];
                    Pfile file = new Pfile();
                    file.Name = str;
                    file.Bin = File.ReadAllBytes(s);
                    MainWindow.DB.Pfiles.Add(file);
                    MessageBox.Show("1");
                    MainWindow.DB.SaveChanges();
                    Document document = new Document();
                    document.Name = NName.Text;
                    document.WorkerId = MainWindow.userValue.Id;
                    document.PfileId = MainWindow.DB.Pfiles.ToList().Last().Id;
                    document.CategoryId = catbox.SelectedIndex + 1;
                    if (IsLab)
                    {
                        document.PatientId = patient.Id;
                    }
                    document.Comment = Comment.Text + " ";
                    MainWindow.DB.Documents.Add(document);
                    MainWindow.DB.SaveChanges();
                    this.DialogResult = true;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "Word file|*.doc;*.docx;";
            if (openFileDialog.ShowDialog() == true)
            {
                s = openFileDialog.FileName;

                String[] strings = s.Split('\u005C');
                string str = strings[strings.Length - 1];
                NName.Text = str;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
    }
}
