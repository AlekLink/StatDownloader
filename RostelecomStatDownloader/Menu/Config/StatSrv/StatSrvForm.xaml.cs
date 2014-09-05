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
using System.IO;
using System.Xml.Serialization;

namespace StatDownloader.Menu.Config.StatSrv
{
    /// <summary>
    /// Interaction logic for StatSrvForm.xaml
    /// </summary>
    public partial class RostelecomConnectConfigForm : Window
    {
        private Class.Config.Config configClass = new Class.Config.Config();
        public RostelecomConnectConfigForm()
        {
            InitializeComponent();
        }

        private void Save()
        {
            configClass._Login = this.TextBox_Login.Text;
            configClass._Password = this.TextBox_Password.Text;
            configClass._serverAddr = this.TextBox_Server.Text;
        }

        private void Load()
        {
            this.TextBox_Login.Text = this.configClass._Login;
            this.TextBox_Password.Text = this.configClass._Password;
            this.TextBox_Server.Text = this.configClass._serverAddr;
        }

        private void Button_Ok_StatSrvForm_Click(object sender, RoutedEventArgs e)
        {
            this.Save();
            this.Close();
        }

        private void Button_Save_SattSrvForm_Click(object sender, RoutedEventArgs e)
        {
            this.Save();
        }

        private void Button_Cancel_SattSrvForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.TextBox_Login.Text != "" & this.TextBox_Password.Text != "" & this.TextBox_Server.Text != "")
                this.configClass._RostelecomConnectConfig = true;
            else
                this.configClass._RostelecomConnectConfig = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Load();
        }
    }
}
