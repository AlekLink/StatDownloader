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

namespace StatDownloader.Forms
{
    /// <summary>
    /// Interaction logic for ErrorForm.xaml
    /// </summary>
    public partial class ErrorForm : Window
    {
        public ErrorForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Показать форму
        /// </summary>
        /// <param name="header">Заголовок окна</param>
        /// <param name="errorPlace">Место возникновения ошибки</param>
        /// <param name="errorText">Сообщение ошибки</param>
        public void ShowDialog(string header, string errorPlace, string errorText)
        {
            this.StatusBarItem_CurrentTime.Content = Content + DateTime.Now.ToString();
            this.RichTextBox_ErrorText.AppendText(errorText);
            this.Label_ErrorPlace.Content = this.Label_ErrorPlace.Content + errorText;
            this.Title = FormsClass.formHeader;
            this.ShowDialog();
        }
    }
}
