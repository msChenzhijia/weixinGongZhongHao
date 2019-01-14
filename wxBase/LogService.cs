using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxBase
{
    public static  class LogService
    {
        /// <summary>
        /// 保存日志文件的文件夹
        /// </summary>
        static String logDir = "Log";
        /// <summary>
        /// 日志文件
        /// </summary>
        static String logFile = "";
        public static void Write(String text)
        {
            #region 如果日志文件夹不存在,则创建
            String dir = AppDomain.CurrentDomain.BaseDirectory + "//" + logDir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            #endregion
            //日志文件名包含日期
            logFile = dir + "//" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            //记录日志
            File.AppendAllText(logFile, DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]:   ") + text+ "\r\n");
        }

    }
}
