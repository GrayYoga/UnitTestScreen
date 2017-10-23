using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using Newtonsoft.Json;

namespace UnitTestScreen
{
    public class CookiesHelper : IDisposable
    {
        public IEnumerable<Cookie> Cookies {get;  set;}

        public bool SavedCookiesIsAvailable() { return File.Exists(HostName); }

        private string HostName;

        public CookiesHelper(string hostName)
        {
            if(hostName != null)
            {
                HostName = hostName;
                if (File.Exists(HostName))
                {
                    using (StreamReader streamReader = new StreamReader(this.HostName))
                    {
                        Cookies = JsonConvert.DeserializeObject<IEnumerable<Cookie>>(streamReader.ReadToEnd(),
                            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    }
                }
                else
                {
                    Cookies = new List<Cookie>();
                }
            }
        }

        public void Dispose()
        {
            if (HostName != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(this.HostName))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(Cookies,
                        new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
                }
            }
        }
    }
}
