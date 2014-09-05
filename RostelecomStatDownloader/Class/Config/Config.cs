using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace StatDownloader.Class.Config
{
    [XmlRoot(elementName:"RosTelStatConfiguration")]
    public class Config
    {
        private static Config _instance;
     

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }
        
        public static List<String> PhoneNumberAll = new List<string>();
        public static List<String> PhoneNumberDownload = new List<string>();

        public static string DailyPath;
        public static string WeeklyPath;
        public static string BilingPath;
        public static bool RostelDownloadAsIs;
        public static bool RostelDownloadExcel;
        public static bool RostelDownloadCSV;
        public static bool RostelDownloadConfig;

        public static string Login;
        public static string Password;
        public static string serverAddr;
        public static bool RostelecomConnectConfig;

        public static string ProxyServerAddress;
        public static string ProxyServerPort;
        public static string ProxyServerUser;
        public static string ProxyServerPassword;
        public static bool UseProxyServer;

        public static bool ReadyToDownload;


        public string _Login { get { return Login; } set { Login = value; } }

        public string _Password {get { return Password; } set { Password = value; } }

        public string _serverAddr { get { return serverAddr; } set { serverAddr = value; } }

        public string _DailyPath { get { return DailyPath; } set { DailyPath = value; } }

        public string _WeeklyPath { get { return WeeklyPath; } set { WeeklyPath = value; } }

        public string _BilingPath { get { return BilingPath; } set { BilingPath = value; } }

        public string _ProxyServerAddress { get { return ProxyServerAddress; } set { ProxyServerAddress = value; } }

        public string _ProxyServerPort { get { return ProxyServerPort; } set { ProxyServerPort = value; } }

        public string _ProxyServerUser { get { return ProxyServerUser; } set { ProxyServerUser = value; } }

        public string _ProxyServerPassword { get { return ProxyServerPassword; } set { ProxyServerPassword = value; } }

        public bool _UseProxyServer { get { return UseProxyServer; } set { UseProxyServer = value; } }

        public bool _RostelDownloadConfig { get { return RostelDownloadConfig; } set { RostelDownloadConfig = value; } }

        public bool _RostelDownloadAsIs { get { return RostelDownloadAsIs; } set { RostelDownloadAsIs = value; } }

        public bool _RostelDownloadExcel { get { return RostelDownloadExcel; } set { RostelDownloadExcel = value; } }

        public bool _RostelDownloadCSV { get { return RostelDownloadCSV; } set { RostelDownloadCSV = value; } }

        public bool _RostelecomConnectConfig { get { return RostelecomConnectConfig; } set { RostelecomConnectConfig = value; } }

        public bool _ReadyToDownload { get { return ReadyToDownload; } set { ReadyToDownload = value; } }

        public List<string> _PhoneNumberAll { get { return PhoneNumberAll; } set { PhoneNumberAll = value; } }

        public List<string> _PhoneNumberDownload { get { return PhoneNumberDownload; } set { PhoneNumberDownload = value; } }

        public void SaveConfig()
        {
            Config configApp = new Config();

            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (StreamWriter writer = new StreamWriter("Config.xml"))
            {
                serializer.Serialize(writer, configApp);
                writer.Close();
            }
        }

        public void LoadConfig()
        {
            Config configApp = new Config(); ;

            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (StreamReader reader = new StreamReader("Config.xml"))
            {
                Config deserialize = (Config)serializer.Deserialize(reader);
                reader.Close();

            }
        }
        
    }
}
