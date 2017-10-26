using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestScreen
{
    public class CookiesHelper : IDisposable
    {
        private string HostName;
        private JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        public IEnumerable<Cookie> Cookies {get;  set;}
        

        public bool SavedCookiesAreAvailable() { return File.Exists(HostName); }

        public CookiesHelper(string hostName)
        {
            HostName = hostName ?? throw new ArgumentNullException("Parameter hostName cannot be null ", nameof(hostName));

            if (File.Exists(HostName))
            {
                using (var streamReader = new StreamReader(HostName))
                {
                    var jsonContent = streamReader.ReadToEnd();
                    
                    Cookies = JsonConvert.DeserializeObject<IEnumerable<Cookie>>(jsonContent, JsonSerializerSettings);
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
                using (var streamWriter = new StreamWriter(HostName))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(Cookies,JsonSerializerSettings));
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
