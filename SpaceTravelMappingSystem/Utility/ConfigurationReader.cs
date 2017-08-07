namespace SpaceTravelMappingSystem.Utility
{
    using System;
    using System.Configuration;

    public static class ConfigurationReader
    {
        public static int ReadInt(string key)
        {
            return int.Parse(ConfigurationManager.AppSettings[key]);
        }
        public static string ReadString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static decimal ReadDecimal(string key)
        {
            return Decimal.Parse(ConfigurationManager.AppSettings[key]);
        }
    }
}