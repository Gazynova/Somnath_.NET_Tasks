using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Hackathon_SQL.Utility
{
    static class DbConnUtil
    {
        static IConfiguration _iconfiguration;
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }
        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()//used to build configuration object from dataSource
                        .SetBasePath(Directory.GetCurrentDirectory())//settting the path to applications current directory
                        .AddJsonFile("C:\\Users\\User\\Desktop\\DontNet\\Somnath_.NET_Tasks\\Hackathon_SQL\\appsettings.json");//load the configuration setting from this json file
            _iconfiguration = builder.Build();//compiling configuration into Iconfiguration
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");

        }
    }
}
