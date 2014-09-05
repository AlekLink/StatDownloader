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
using System.Windows.Threading;

namespace StatDownloader.Menu.MenuItem
{
    /// <summary>
    /// Interaction logic for Datas.xaml
    /// </summary>
    public partial class Datas : Window
    {
        private static List<string> listAvaNum = new List<string>();
        private static List<string> listDownNum = new List<string>();
        private Class.Config.Config config = new Class.Config.Config();
        private DispatcherTimer timer;

        public Datas()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += new EventHandler(tickTimer);
            timer.Start();
        }

        private void tickTimer(object sender, EventArgs e)//Таймер на главной форме.
        {
            this.Label_Login.Content = this.config._Login;
            this.Label_Passwrd.Content = this.config._Password;
            this.Label_Addr.Content = this.config._serverAddr;

            this.Label_DailyPath.Content = this.config._DailyPath;
            this.Label_WeeklyPath.Content = this.config._WeeklyPath;
            this.Label_BilingPath.Content = this.config._BilingPath;
            this.Label_SaveConfigForm.Content = this.config._RostelDownloadConfig;
            this.Label_StatSrvForm.Content = this.config._RostelecomConnectConfig;
            this.Label_ReadyToDownload.Content = this.config._ReadyToDownload; 

            this.ListBox_Ava_PhoneNum.Items.Clear();
            this.ListBox_Down_PhoneNum.Items.Clear();

            foreach (string s in this.config._PhoneNumberAll)
            {
                this.ListBox_Ava_PhoneNum.Items.Add(s);
                this.Label_Ava_PhoneNum_Count.Content = this.ListBox_Ava_PhoneNum.Items.Count.ToString();
            }
            
            foreach (string s in this.config._PhoneNumberDownload)
            {
                this.ListBox_Down_PhoneNum.Items.Add(s);
                this.Label_Down_PhoneNum_Count.Content = this.ListBox_Down_PhoneNum.Items.Count.ToString();
            }
        }
    }
}
