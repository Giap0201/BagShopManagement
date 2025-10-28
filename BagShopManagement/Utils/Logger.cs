// Utils/Logger.cs
using System;
using System.IO;

namespace BagShopManagement.Utils
{
    public static class Logger
    {
        private static readonly string LogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? ".", "bagshop_logs.txt");
        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(LogFile, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}");
            }
            catch { /* swallow logging errors */ }
        }
    }
}
