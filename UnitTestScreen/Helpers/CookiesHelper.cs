using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestScreen
{
    public class CookiesHelper : IDisposable
    {
        private string HostName;
        private JsonSerializerSettings jsonSerializerSettings;

        public IEnumerable<Cookie> Cookies {get;  set;}
        
        public bool SavedCookiesAreAvailable()
        {
            return File.Exists(HostName);
        }

        public CookiesHelper(string hostName)
        {
            HostName = hostName ?? throw new ArgumentNullException("Parameter hostName cannot be null ", nameof(hostName));

            jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            if (File.Exists(HostName))
            {
                using (var streamReader = new StreamReader(HostName))
                {
                    var jsonContent = streamReader.ReadToEnd();
                    
                    Cookies = JsonConvert.DeserializeObject<IEnumerable<Cookie>>(jsonContent, jsonSerializerSettings);
                }
            }
            else
            {
                Cookies = new List<Cookie>();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if(Cookies.Count() > 0)
                {
                    using (var streamWriter = new StreamWriter(HostName))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(Cookies, jsonSerializerSettings));
                    }
                }
                disposedValue = true;
            }
        }

        ~CookiesHelper()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
