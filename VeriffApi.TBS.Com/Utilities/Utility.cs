using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace VeriffApi.TBS.Com.Utilities
{
    #region Seperate class for configuration manager
    /// <summary>
    /// ConfigurationManager
    /// </summary>
    static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
    #endregion
    public static class Utility
    {
        #region Get App Settings
        /// <summary>
        /// Get the appsetting value from the web.config
        /// </summary>
        /// <param name="appKey">appsettings key</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            var value = ConfigurationManager.AppSetting.GetSection("AppSettings:" + key).Value;
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
