using System;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Text;
using Microsoft.AspNet.Http;
#if DNX451
using System.Net.Http.Headers;

namespace WarehouseMonitor
{
    public class BasicAuthHttpModule
    {
        #region Methods
       
        public static bool ApplicationAuthenticateRequest(HttpContext context, Microsoft.Extensions.OptionsModel.IOptions<DataSettings> dataSettings)
        {
            bool ret = false;
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals(AuthenticationSchemes.Basic.ToString("g"), StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    ret = AuthenticateUser(authHeaderVal, dataSettings);
                }
            }

            return ret;
        }

        private static bool CheckPassword(string username, string password, Microsoft.Extensions.OptionsModel.IOptions<DataSettings> dataSettings)
        {
            bool ret = false;

            if (dataSettings != null)
            {
                if (username == dataSettings.Value.Username
                && password == dataSettings.Value.Password)
                {
                    ret = true;
                }
            }

            return ret;
        }

        private static bool AuthenticateUser(AuthenticationHeaderValue header, Microsoft.Extensions.OptionsModel.IOptions<DataSettings> dataSettings)
        {
            try
            {
                var encoding = ASCIIEncoding.GetEncoding("iso-8859-1");
                string credentials = encoding.GetString(Convert.FromBase64String(header.Parameter));

                string[] parts = credentials.Split(':');
                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password, dataSettings))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion 
    }
}
#endif
