using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ErrorHandling.Helpers
{
    public static class SimpleLogger
    {
        public static void Error(string message, Exception ex)
        {
            File.AppendAllLines(HttpContext.Current.Server.MapPath("~/errors.log"), new string[] {
                message,
                $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")} - {ex.ToString()}"
            });
        }
    }
}