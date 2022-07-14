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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using Klinica.Datebase;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Klinica.Pages
{
    /// <summary>
    /// Логика взаимодействия для DocumentView.xaml
    /// </summary>
    public partial class DocumentView : System.Windows.Window
    {
        public DocumentView(Datebase.Document document)
        {
            InitializeComponent();
            string filename = @"C:\SaveFile\" + document.Pfile.Name;
            System.IO.File.WriteAllBytes(filename, MainWindow.DB.Pfiles.Where(u => u.Id == document.PfileId).ToList().FirstOrDefault().Bin);
            string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(filename), "\\",System.IO.Path.GetFileNameWithoutExtension(filename), ".xps");
            documentViewer.Document = ConvertWordDocToXPSDoc(filename, newXPSDocumentName).GetFixedDocumentSequence();
        }
        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);
            var doc = wordApplication.ActiveDocument;
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();
                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }
    }
}
