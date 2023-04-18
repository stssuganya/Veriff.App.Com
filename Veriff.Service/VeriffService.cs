using Microsoft.Extensions.Configuration;
using System;
using Veriff.Core.Model;
using Veriff.Service.Utilities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Veriff.Core.IServices;

namespace Veriff.Service
{
    public class VeriffService: IVeriffService
    {
        #region Delcaration
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor

        public VeriffService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Create Veriff Session
        public bool CreateVeriffSession(verification verification)
        {
            bool isSaved = false;
            #region Call Payment API Method
            using (var client = new VeriffApiClients(_configuration))
            {
                string authKey = GetAppSettings("ApiKey");
                #region API Headers
                if (!string.IsNullOrWhiteSpace(authKey))
                {
                    client.DefaultRequestHeaders.Add("ApiKey", authKey);
                }
                #endregion
                string addTLUri = "VeriffApi/CreateSession";
                var tlResponse = client.PostAsJsonAsync(addTLUri, verification);

                if (tlResponse != null && tlResponse.IsCompleted)
                {
                    
                }
                
            }
            #endregion
            return isSaved;
        }
        #endregion

        #region Get App Settings

        /// <summary>
        /// Get the appsetting value from the web.config
        /// </summary>
        /// <returns></returns>
        public string GetAppSettings(string key)
        {
            var value = _configuration.GetSection("AppSettings:" + key).Value;
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
