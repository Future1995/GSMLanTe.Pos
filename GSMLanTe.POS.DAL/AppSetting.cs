using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLanTe.POS.DAL
{
    public static class AppSetting
    {
        public static readonly string ServerConnectionString = ConfigurationManager.ConnectionStrings["MySqlConStr"].ConnectionString;
        public static readonly string LocalConnectionString = ConfigurationManager.ConnectionStrings["LocalConStr"].ConnectionString;
    }
}
