using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace VeriffApi.com.Utilities
{
    public class Utility
    {
        #region Get App Settings
        /// <summary>
        /// Get the appsetting value from the web.config
        /// </summary>
        /// <param name="appKey">appsettings key</param>
        /// <returns></returns>
        public static string GetAppSettings(string appKey)
        {
            object value = null;
            value = ConfigurationManager.AppSettings[appKey];
            if (value != null)
            {
                return value.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
