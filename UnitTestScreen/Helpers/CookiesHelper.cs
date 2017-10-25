using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using Newtonsoft.Json;

namespace UnitTestScreen
{
    public class CookiesHelper : IDisposable
    {
        private string HostName;
        public IEnumerable<Cookie> Cookies {get;  set;}

        public bool SavedCookiesAreAvailable() { return File.Exists(HostName); }

        public CookiesHelper(string hostName)
        {
            HostName = hostName ?? throw new ArgumentNullException("Parameter hostName cannot be null ", nameof(hostName));

            if (File.Exists(HostName))
            {
                using (var streamReader = new StreamReader(this.HostName))
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

        public void Dispose()
        {
            using (var streamWriter = new StreamWriter(HostName))
            {
                streamWriter.Write(JsonConvert.SerializeObject(Cookies,
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
            }
        }
    }
}
