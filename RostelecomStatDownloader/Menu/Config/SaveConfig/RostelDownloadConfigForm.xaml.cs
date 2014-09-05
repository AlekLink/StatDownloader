using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Xml.Serialization;
using System.Windows.Forms;


namespace StatDownloader.Menu.Config.SaveConfig
{
    /// <summary>
    /// Interaction logic for SaveConfigForm.xaml
    /// </summary>
    public partial class RostelDownloadConfigForm : Window
    {
        private List<String> AvaList = new List<string>();
        private List<String> DownList = new List<string>();
        private Class.Config.Config _ConfigApp = new Class.Config.Config();


        public RostelDownloadConfigForm()
        {
            InitializeComponent();
        }      

        private void SaveConfig() // Сохраняем конфигурацию.
        {
            this.AvaList.Clear();
            this.DownList.Clear();

            this._ConfigApp._DailyPath = this.TextBox_DayliDownload_SaveConfigForm.Text;
            this._ConfigApp._WeeklyPath = this.TextBox_WeeklyDownload_SaveConfigForm.Text;
            this._ConfigApp._BilingPath = this.TextBox_BilingDownload_SaveConfigForm.Text;
            this._ConfigApp._RostelDownloadAsIs = Convert.ToBoolean(this.CheckBox_AsIs_SaveConfigForm.IsChecked);
            this._ConfigApp._RostelDownloadExcel = Convert.ToBoolean(this.CheckBox_Excel_SaveConfigForm.IsChecked);
            this._ConfigApp._RostelDownloadCSV = Convert.ToBoolean(this.CheckBox_Csv_SaveConfigForm.IsChecked);

            this._ConfigApp._PhoneNumberAll.Clear();
            this._ConfigApp._PhoneNumberDownload.Clear();

            foreach (string s in this.ListBox_Available_SaveConfigForm.Items)
            {
                this.AvaList.Add(s);
            }

            foreach (string s in this.ListBox_Download_SaveConfigForm.Items)
            {
                this.DownList.Add(s);
            }

            this._ConfigApp._PhoneNumberAll = this.AvaList;
            this._ConfigApp._PhoneNumberDownload = this.DownList;
        }

        private void LoadConfig() //Загружаем конфигурацию.
        {
            this.TextBox_DayliDownload_SaveConfigForm.Text = this._ConfigApp._DailyPath;
            this.TextBox_WeeklyDownload_SaveConfigForm.Text = this._ConfigApp._WeeklyPath;
            this.TextBox_BilingDownload_SaveConfigForm.Text = this._ConfigApp._BilingPath;
            this.CheckBox_AsIs_SaveConfigForm.IsChecked = this._ConfigApp._RostelDownloadAsIs;
            this.CheckBox_Excel_SaveConfigForm.IsChecked = this._ConfigApp._RostelDownloadExcel;
            this.CheckBox_Csv_SaveConfigForm.IsChecked = this._ConfigApp._RostelDownloadCSV;

            foreach (string s in this._ConfigApp._PhoneNumberAll)
            {
                this.ListBox_Available_SaveConfigForm.Items.Add(s);
            }
            
            foreach (string s in this._ConfigApp._PhoneNumberDownload)
            {
                this.ListBox_Download_SaveConfigForm.Items.Add(s);
            }

            this.Label_Load_StatusBar_SaveConfigForm.Content = "Номеров для загрузки: " 
                + this.ListBox_Download_SaveConfigForm.Items.Count.ToString();

            this.Label_Ready_StatusBar_SaveConfigForm.Content = "Доступно номеров: " 
                + this.ListBox_Available_SaveConfigForm.Items.Count.ToString();   
        }
        //
        private void DelAvailableListBoxElement()
        {
            this.ListBox_Available_SaveConfigForm.Items.Remove(this.ListBox_Available_SaveConfigForm.SelectedItem);
            this.Label_Ready_StatusBar_SaveConfigForm.Content = "Доступно номеров: " 
                + this.ListBox_Available_SaveConfigForm.Items.Count.ToString();
        }



        // Кнопки Begin
        private void Button_Ok_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            SaveConfig();
            this.Close();
        }

        private void Button_Save_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            SaveConfig();
        }

        private void Button_Cancel_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_DayliDownload_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                this.TextBox_DayliDownload_SaveConfigForm.Text = dialog.SelectedPath;
            }
        }

        private void Button_WeeklyDownload_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                this.TextBox_WeeklyDownload_SaveConfigForm.Text = dialog.SelectedPath;
            }
        }

        private void Button_BilingDownload_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                this.TextBox_BilingDownload_SaveConfigForm.Text = dialog.SelectedPath;
            }
        }

        private void Button_AddNewNumber_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            bool match = false;
            if (this.TextBox_AddNewNumber_SaveConfigForm.Text != "")
            {
                foreach (string s in this.ListBox_Available_SaveConfigForm.Items)
                {
                    if (s == this.TextBox_AddNewNumber_SaveConfigForm.Text)
                    {
                        match = true;
                    }
                }
                if (match)
                {
                    System.Windows.MessageBox.Show("Такой номер уже присутствует в списке.", "Предупреждение");
                    this.TextBox_AddNewNumber_SaveConfigForm.Text = "";
                }
                else
                {
                    this.ListBox_Available_SaveConfigForm.Items.Add(this.TextBox_AddNewNumber_SaveConfigForm.Text);
                    this.Label_Ready_StatusBar_SaveConfigForm.Content = "Доступно номеров: " 
                        + this.ListBox_Available_SaveConfigForm.Items.Count.ToString();

                    this.TextBox_AddNewNumber_SaveConfigForm.Text = "";
                }
            }
        }

        private void Button_DelNewNumber_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBox_Available_SaveConfigForm.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Выделите номер для удаления из списка.", "Предупреждение");
            }
            else
            {
                while (this.ListBox_Available_SaveConfigForm.SelectedItems.Count > 0)
                {
                    this.DelAvailableListBoxElement();
                }
            }
        }

        private void Button_Add_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBox_Available_SaveConfigForm.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Выделите номер для переноса.", "Предупреждение");
            }
            else
            {
                while (this.ListBox_Available_SaveConfigForm.SelectedItems.Count > 0)
                {
                    this.ListBox_Download_SaveConfigForm.Items.Add(this.ListBox_Available_SaveConfigForm.SelectedItem);
                    this.Label_Load_StatusBar_SaveConfigForm.Content = "Номеров для загрузки: " 
                        + this.ListBox_Download_SaveConfigForm.Items.Count.ToString();

                    this.DelAvailableListBoxElement();
                }
            }
        }

        private void Button_Remove_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {

            if (this.ListBox_Download_SaveConfigForm.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Выделите номер для переноса.", "Предупреждение");
            }
            else
            {
                while (this.ListBox_Download_SaveConfigForm.SelectedItems.Count > 0)
                {
                    this.ListBox_Available_SaveConfigForm.Items.Add(this.ListBox_Download_SaveConfigForm.SelectedItem);
                    this.ListBox_Download_SaveConfigForm.Items.Remove(this.ListBox_Download_SaveConfigForm.SelectedItem);
                    this.Label_Load_StatusBar_SaveConfigForm.Content = "Номеров для загрузки: " + this.ListBox_Download_SaveConfigForm.Items.Count.ToString();
                    this.Label_Ready_StatusBar_SaveConfigForm.Content = "Доступно номеров: " + this.ListBox_Available_SaveConfigForm.Items.Count.ToString();
                }
            }
        }
        //Кнопки End


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((this._ConfigApp._DailyPath != "" | this._ConfigApp._WeeklyPath != "" | this._ConfigApp._BilingPath != "") & this._ConfigApp._PhoneNumberDownload.Count > 0)
                this._ConfigApp._RostelDownloadConfig = true;
            else
                this._ConfigApp._RostelDownloadConfig = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadConfig();
        }
    }
}
