using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace StatDownloader.Class.Function.Rostel
{
    public class HttpRequest
    {
        private System.Net.WebResponse responce;
        private System.Net.HttpWebRequest request;
        private System.Net.WebProxy proxy = new WebProxy();
        private Class.Config.Config config = new Config.Config();
        private string uri = string.Empty;
        private string proxyAddr = string.Empty;
        private string proxyPort = string.Empty;
        private string proxyUser = string.Empty;
        private string proxyPassword = string.Empty;
        private bool useProxy = false;
        private bool useProxyCredentials = false;

        private string cookie = string.Empty;

        public HttpRequest()
        {
            this.uri = this.config._serverAddr;
            this.proxyAddr = this.config._ProxyServerAddress;
            this.proxyPort = this.config._ProxyServerPort;
            this.proxyUser = this.config._ProxyServerUser;
            this.proxyPassword = this.config._ProxyServerPassword;
            this.useProxy = this.config._UseProxyServer;
            this.useProxyCredentials = this.config._useProxyCredentials;
        }

        public void startConnection(string method, string data)
        {

            this.request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(this.uri);
            this.request.Method = method;
            this.request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
            this.request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0; OfficeLiveConnector.1.4; OfficeLivePatch.1.3)";
            this.request.ContentType = "application/x-www-form-urlencoded";
            this.request.AllowAutoRedirect = true;
            
            if (this.useProxy)
            {
                
                Uri proxyUri = new Uri(this.proxyAddr + ":" + this.proxyPort);
                if (this.useProxyCredentials)
                {
                    proxy.Credentials = new NetworkCredential(this.proxyUser, this.proxyPassword);
                }
                this.request.Proxy = this.proxy;
            }
            
        }

    }
}
