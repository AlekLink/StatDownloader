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
    [XmlRoot(elementName: "RosTelStatConfiguration")]
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
        public static bool useProxyCredentials;

        public static bool ReadyToDownload;

        /// <summary>
        /// Ростелеком.
        /// Пользователь сервера статистики.
        /// </summary>
        public string _Login { get { return Login; } set { Login = value; } }
        /// <summary>
        /// Ростелеком.
        /// Пароль сервера статистики.
        /// </summary>
        public string _Password { get { return Password; } set { Password = value; } }
        /// <summary>
        /// Ростелеком.
        /// Адрес сервера статистики.
        /// </summary>
        public string _serverAddr { get { return serverAddr; } set { serverAddr = value; } }
        /// <summary>
        /// Ростелеком.
        /// Путь сохранения. 
        /// Ежедневная статистика.
        /// </summary>
        public string _DailyPath { get { return DailyPath; } set { DailyPath = value; } }
        /// <summary>
        /// Ростелеком.
        /// Путь сохранения. 
        /// Еженедельная статистика.
        /// </summary>
        public string _WeeklyPath { get { return WeeklyPath; } set { WeeklyPath = value; } }
        /// <summary>
        /// Ростелеком.
        /// Путь сохранения.
        /// Ежемесячный билинг.
        /// </summary>
        public string _BilingPath { get { return BilingPath; } set { BilingPath = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Адрес.
        /// </summary>
        public string _ProxyServerAddress { get { return ProxyServerAddress; } set { ProxyServerAddress = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Порт.
        /// </summary>
        public string _ProxyServerPort { get { return ProxyServerPort; } set { ProxyServerPort = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Пользователь.
        /// </summary>
        public string _ProxyServerUser { get { return ProxyServerUser; } set { ProxyServerUser = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Пароль.
        /// </summary>
        public string _ProxyServerPassword { get { return ProxyServerPassword; } set { ProxyServerPassword = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Использование прокси.
        /// </summary>
        public bool _UseProxyServer { get { return UseProxyServer; } set { UseProxyServer = value; } }
        /// <summary>
        /// Ростелеком.
        /// Форма RostelDownloadConfigForm.
        /// Статус заполнения.
        /// </summary>
        public bool _RostelDownloadConfig { get { return RostelDownloadConfig; } set { RostelDownloadConfig = value; } }
        /// <summary>
        /// Ростелеком.
        /// Способ сохранения.
        /// Как есть.
        /// </summary>
        public bool _RostelDownloadAsIs { get { return RostelDownloadAsIs; } set { RostelDownloadAsIs = value; } }
        /// <summary>
        /// Ростелеком.
        /// Способ сохранения.
        /// Сохранять в Excel.
        /// </summary>
        public bool _RostelDownloadExcel { get { return RostelDownloadExcel; } set { RostelDownloadExcel = value; } }
        /// <summary>
        /// Ростелеком.
        /// Способ сохранения.
        /// Сохранять в CSV.
        /// </summary>
        public bool _RostelDownloadCSV { get { return RostelDownloadCSV; } set { RostelDownloadCSV = value; } }
        /// <summary>
        /// Ростелеком.
        /// Форма RostelecomConnectConfigForm.
        /// Статус заполнения.
        /// </summary>
        public bool _RostelecomConnectConfig { get { return RostelecomConnectConfig; } set { RostelecomConnectConfig = value; } }
        /// <summary>
        /// Ростелеком.
        /// Готовность к загрузке. 
        /// </summary>
        public bool _ReadyToDownload { get { return ReadyToDownload; } set { ReadyToDownload = value; } }
        /// <summary>
        /// Ростелеком.
        /// Прокси сервер.
        /// Использование прокси пользователя.
        /// </summary>
        public bool _useProxyCredentials { get { return useProxyCredentials; } set { useProxyCredentials = value; } }
        /// <summary>
        /// Ростелеком.
        /// Список номеров.
        /// Все.
        /// </summary>
        public List<string> _PhoneNumberAll { get { return PhoneNumberAll; } set { PhoneNumberAll = value; } }
        /// <summary>
        /// Ростелеком.
        /// Список номеров.
        /// Для загрузки.
        /// </summary>
        public List<string> _PhoneNumberDownload { get { return PhoneNumberDownload; } set { PhoneNumberDownload = value; } }
        /// <summary>
        /// Ростелеком.
        /// Сохранить конфигурацию в файл.
        /// </summary>
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
        /// <summary>
        /// Ростелеком.
        /// Загрузить конфигурацию из файла.
        /// </summary>
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
