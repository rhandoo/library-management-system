using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LMS.Domain
{
    public static class Config
    {
        private const string CONNECTIONSTRING_NAME = "LmsDbConnectionString";

        public static string GetDatabaseConnectionString()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[1];

            return settings.ConnectionString;
        }
    }
}
