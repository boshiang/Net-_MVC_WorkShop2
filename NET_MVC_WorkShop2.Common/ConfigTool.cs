using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_MVC_WorkShop2.Common
{
    public class ConfigTool
    {
        public static string GetDBConnectionString(string connName)
        {
            return
                System.Configuration.ConfigurationManager.
                    ConnectionStrings[connName].ConnectionString.ToString();
        }
    }
}
