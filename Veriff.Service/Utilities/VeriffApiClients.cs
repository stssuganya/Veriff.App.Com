using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Veriff.Service.Utilities
{
    public class VeriffApiClients : HttpClient
    {
        #region Declartion
        private readonly IConfiguration _config;
        #endregion

        #region Constructor

        public VeriffApiClients(IConfiguration config)
        {
            _config = config;

            if (!string.IsNullOrWhiteSpace(GetAppSettings("VeriffApiUrl")))
            {
                this.BaseAddress = new Uri(GetAppSettings("VeriffApiUrl"));
                this.Timeout = new TimeSpan(0, 5, 0);
            }
            this.DefaultRequestHeaders.Accept.Clear();

            this.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Get App Settings
        /// <summary>
        /// Get the appsetting value from the web.config
        /// </summary>
        /// <param name="appKey">appsettings key</param>
        /// <returns></returns>
        public string GetAppSettings(string appKey)
        {
            object value = null;
            value = _config.GetSection("AppSettings:" + appKey).Value;
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
