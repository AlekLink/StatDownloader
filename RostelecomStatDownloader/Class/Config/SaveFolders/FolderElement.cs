using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StatDownloader.Class.Config.SaveFolders
{
    public class FolderElement:ConfigurationElement
    {
        [ConfigurationProperty("folderType", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string FolderType
        {
            get { return ((string)(base["folderType"])); }
            set {base["folderType"] = value;}
        }

        [ConfigurationProperty("path", DefaultValue="",IsKey=true,IsRequired=true)]
        public string Path
        {
            get{return((string)(base["path"]));}
            set{base["path"] = value;}
        }
    }
}
