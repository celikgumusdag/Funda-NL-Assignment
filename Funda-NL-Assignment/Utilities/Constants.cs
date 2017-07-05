using System.Configuration;
using System.IO;

namespace Funda_NL_Assignment.Utilities
{
    public static class Constants
    {
        public static string Url = ConfigurationManager.AppSettings["url"];
        public static string Browser = ConfigurationManager.AppSettings["browser"];
    }
}