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

namespace StatDownloader.Menu.Settings.Network
{
    /// <summary>
    /// Interaction logic for ProxySettings.xaml
    /// </summary>
    public partial class ProxySettings : Window
    {
        private Class.Config.Config config = new Class.Config.Config();

        public ProxySettings()
        {
            InitializeComponent();
        }

        private void LoadSettings()
        {
            this.TextBox_ProxyServerAddress.Text = this.config._ProxyServerAddress;
            this.TextBox_ProxyServerPort.Text = this.config._ProxyServerPort;
            this.TextBox_ProxyServerUser.Text = this.config._ProxyServerUser;
            this.TextBox_ProxyServerPassword.Text = this.config._ProxyServerPassword;
            this.CheckBox_UseProxyServer.IsChecked = this.config._UseProxyServer;

            if (this.config._UseProxyServer)
            {
                this.CheckBox_UseProxyServer.IsChecked = true;
                this.TextBox_ProxyServerAddress.IsEnabled = true;
                this.TextBox_ProxyServerPort.IsEnabled = true;
                this.TextBox_ProxyServerUser.IsEnabled = true;
                this.TextBox_ProxyServerPassword.IsEnabled = true;
            }
            else
            {
                this.CheckBox_UseProxyServer.IsChecked = false;
                this.TextBox_ProxyServerAddress.IsEnabled = false;
                this.TextBox_ProxyServerPort.IsEnabled = false;
                this.TextBox_ProxyServerUser.IsEnabled = false;
                this.TextBox_ProxyServerPassword.IsEnabled = false;
            }

            
        }

        private void SaveSettings()
        {
            this.config._ProxyServerAddress = this.TextBox_ProxyServerAddress.Text;
            this.config._ProxyServerPort = this.TextBox_ProxyServerPort.Text;
            this.config._ProxyServerUser = this.TextBox_ProxyServerUser.Text;
            this.config._ProxyServerPassword = this.TextBox_ProxyServerPassword.Text;
            this.config._UseProxyServer = Convert.ToBoolean(this.CheckBox_UseProxyServer.IsChecked);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadSettings();
            this.CheckBox_UseProxyServer.Click += CheckBox_UseProxyServer_Click;
        }

        private void Button_Ok_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            this.SaveSettings();
            this.Close();
        }

        private void Button_Save_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            this.SaveSettings();
        }

        private void Button_Cancel_SaveConfigForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void CheckBox_UseProxyServer_Click(object sender, RoutedEventArgs e)
        {
            if (this.CheckBox_UseProxyServer.IsChecked == true)
            {
                this.CheckBox_UseProxyServer.IsChecked = true;
                this.TextBox_ProxyServerAddress.IsEnabled = true;
                this.TextBox_ProxyServerPort.IsEnabled = true;
                this.TextBox_ProxyServerUser.IsEnabled = true;
                this.TextBox_ProxyServerPassword.IsEnabled = true;
            }
            else
            {
                this.CheckBox_UseProxyServer.IsChecked = false;
                this.TextBox_ProxyServerAddress.IsEnabled = false;
                this.TextBox_ProxyServerPort.IsEnabled = false;
                this.TextBox_ProxyServerUser.IsEnabled = false;
                this.TextBox_ProxyServerPassword.IsEnabled = false;
            }
        }
    }
}
