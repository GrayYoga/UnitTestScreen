using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace UnitTestScreen
{
    public class CookiesHelper
    {
        
        IEnumerable<Cookie> _cookies;
        public IEnumerable<Cookie> Cookies {
            get { return _cookies; }
            set
            {
                _cookies = value;
                using (StreamWriter streamWriter = new StreamWriter(this.HostName))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(_cookies,
                        new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All}));
                }
            }
        }

        public bool IsSet { get; }
        private string HostName;
        public CookiesHelper(string HostName = null)
        {
            if(HostName != null)
            {
                // проверить наличие файла
                this.HostName = HostName;
                if (File.Exists(this.HostName))
                {
                    IsSet = true;
                    using (StreamReader streamReader = new StreamReader(this.HostName))
                    {
                        _cookies = JsonConvert.DeserializeObject<IEnumerable<Cookie>>(streamReader.ReadToEnd(),
                            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    }
                }
            }
        }
    }
}
