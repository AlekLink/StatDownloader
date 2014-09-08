using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatDownloader.Class.Function.Rostel
{
    class DataCollector
    {
        private Class.Config.Config config = new Config.Config();
        private System.Net.WebResponse responce;
        private System.Net.HttpWebRequest request;
        private string uri = String.Empty;
        private string login = String.Empty;
        private string password = String.Empty;
        private List<string> numbers = new List<string>();

        public DataCollector()
        {
            this.uri = this.config._serverAddr;
            this.login = this.config._Login;
            this.password = this.config._Password;
            this.numbers = this.config._PhoneNumberDownload;
        }

        
    }
}
