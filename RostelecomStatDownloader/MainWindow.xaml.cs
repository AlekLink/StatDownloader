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
using System.Windows.Threading;
using System.ComponentModel;

namespace StatDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long tick;
        private DateTime date;
        private DispatcherTimer timer;
        private Class.Config.Config _Config = new Class.Config.Config();
        
        public MainWindow()
        {
            InitializeComponent();
            //Запускаем таймер
            date = DateTime.Now;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += new EventHandler(tickTimer);
            timer.Start();
            //
        }

        private void tickTimer(object sender, EventArgs e)//Таймер на главной форме.
        {
            tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            this.Timer_Main_StatusBar.Content = String.Format("{0:dd:HH:mm:ss:ff}", stopWatch);
            

            if (this._Config._RostelecomConnectConfig & this._Config._RostelDownloadConfig)
            {
                this._Config._ReadyToDownload = true;
                this.MenuItem_Config_Rostelecom.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                this._Config._ReadyToDownload = false;
                this.MenuItem_Config_Rostelecom.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void MenuItem_Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Config_Click(object sender, RoutedEventArgs e)
        {
            StatDownloader.Menu.Config.StatSrv.RostelecomConnectConfigForm configForm = new Menu.Config.StatSrv.RostelecomConnectConfigForm();
            configForm.Owner = this;
            configForm.ShowDialog();
            if (_Config._RostelecomConnectConfig)
                this.MenuItem_Config_Rostelecom_Connect.Background = new SolidColorBrush(Colors.LightGreen);
            else
                this.MenuItem_Config_Rostelecom_Connect.Background = new SolidColorBrush(Colors.LightPink);

        }

        private void MenuItem_Config_Save_Click(object sender, RoutedEventArgs e)
        {
            StatDownloader.Menu.Config.SaveConfig.RostelDownloadConfigForm configForm = new Menu.Config.SaveConfig.RostelDownloadConfigForm();
            configForm.ShowDialog();
            if (_Config._RostelDownloadConfig)
                this.MenuItem_Config_Rostelecom_Download.Background = new SolidColorBrush(Colors.LightGreen);
            else
                this.MenuItem_Config_Rostelecom_Download.Background = new SolidColorBrush(Colors.LightPink);
        }

        private void MenuItem_Menu_Data_Click(object sender, RoutedEventArgs e)
        {
            Menu.MenuItem.Datas datas = new Menu.MenuItem.Datas();
            datas.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._Config.LoadConfig();
            if (this._Config._RostelecomConnectConfig)
                this.MenuItem_Config_Rostelecom_Connect.Background = new SolidColorBrush(Colors.LightGreen);
            if (this._Config._RostelDownloadConfig)
                this.MenuItem_Config_Rostelecom_Download.Background = new SolidColorBrush(Colors.LightGreen);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._Config.SaveConfig();
        }

        private void MenuItem_Settings_Network_Click(object sender, RoutedEventArgs e)
        {
            Menu.Settings.Network.ProxySettings proxy = new Menu.Settings.Network.ProxySettings();
            proxy.ShowDialog();
        }
    }
}
