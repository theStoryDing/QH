using System;
using System.IO;
using System.Reflection;

namespace CaterCommon
{
    /// <summary>
    /// log4net 帮助类
    /// </summary>
    public partial class LogHelper
    {
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum LogLevelEnum
        {
            Debug = 0,
            Info = 1,
            Warn = 2,
            Error = 3,
            Fatal = 4
        }

        /// <summary>
        /// 当前保存日志等级
        /// </summary>
        public static LogLevelEnum CurrentLogLevel = LogLevelEnum.Info;

        /// <summary>
        /// 日志存放天数
        /// </summary>
        public static int LogFileExistDay = 3;

        public readonly static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 普通日志信息的记录数
        /// </summary>
        public static int InfoCount;

        /// <summary>
        /// 一般错误日志信息的记录数
        /// </summary>
        public static int ErrorCount;

        /// <summary>
        /// 致命日志信息的记录数
        /// </summary>
        public static int FatalCount;

        /// <summary>
        /// 记录普通信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Info(string msg, System.Exception ex = null)
        {
            if ((int)CurrentLogLevel <= (int)LogLevelEnum.Info)
            {
                if (null != ex)
                {
                    log.Info(msg, ex);

                }
                else
                {
                    log.Info(msg);
                }
                InfoCount++;
            }

        }

        /// <summary>
        /// 记录一般错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Error(string msg, System.Exception ex = null)
        {
            if ((int)CurrentLogLevel <= (int)LogLevelEnum.Error)
            {
                if (null != ex)
                {
                    log.Error(msg, ex);
                }
                else
                {
                    log.Error(msg);
                }
                ErrorCount++;
            }
        }


        /// <summary>
        /// 记录致命错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Fatal(string msg, System.Exception ex = null)
        {
            if ((int)CurrentLogLevel <= (int)LogLevelEnum.Fatal)
            {
                if (null != ex)
                {
                    log.Fatal(msg, ex);
                }
                else
                {
                    log.Fatal(msg);
                }
                FatalCount++;
            }
        }

        /// <summary>
        /// 清理存放超过一定期限的日志文件
        /// </summary>
        /// <param name="saveDay">保存天数</param>
        public static void DeleteLogFile(int saveDay)
        {
            string filePath = System.Environment.CurrentDirectory + @"\log\";
            //string filePath = LogFilePath;

            DateTime nowTime = DateTime.Now;

            string[] logfile = Directory.GetFiles(filePath, "*.log", SearchOption.AllDirectories); //获取日志文件；

            foreach (string file in logfile)
            {

                FileInfo fileInfo = new FileInfo(file);
                TimeSpan t = nowTime - fileInfo.CreationTime;

                if (t.Days >= saveDay)
                {
                    File.Delete(file);
                }
            }

        }
    }
}
