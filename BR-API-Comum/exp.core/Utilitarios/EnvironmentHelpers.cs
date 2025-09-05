using System;
using System.Configuration;

namespace exp.core.Utilitarios
{
    public static class EnvironmentHelpers
    {
        public enum Environment
        {
            Undefined,
            Local,
            Development,
            Production
        }

        public static Environment GetEnvironment()
        {
            try
            {
                return (Environment)Enum.Parse(typeof(Environment),
                    ConfigurationManager.AppSettings["App.Environment"]);
            }
            catch
            {
                return Environment.Undefined;
            }
        }

        public static bool IsLocalOrDev()
        {
            var env = GetEnvironment();
            return env == Environment.Local || env == Environment.Development ? true : false;
        }

        public static bool IsProduction()
        {
            return GetEnvironment() == Environment.Production ? true : false;
        }
    }
}