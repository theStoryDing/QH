/*******************************************
 * 本程序应用于plc之间的数据交互（欧姆龙/西门子PLC）
 * 
 *******************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process process = RunningInstance();
            bool createdNew = true; //返回是否赋予了使用线程的互斥体初始所属权
            System.Threading.Mutex instance = new System.Threading.Mutex(true, Application.ProductName, out createdNew); //同步基元变量           
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Loading();
                Application.Run(new FormMain());
            }
            else
            {
                HandleRunningInstance(process);
                MessageBox.Show("该应用程序已经被打开！");
                System.Threading.Thread.Sleep(100);
                System.Environment.Exit(1);
                return;
            }
        }

        #region 加载
        private static void Loading()
        {
            FormLoad formLoad = new FormLoad();
            formLoad.ShowDialog();
        }
        #endregion


        #region 点击一个已经打开的程序时 激活窗口

        /// <summary>
        /// 该函数设置由不同线程产生的窗口的显示状态。
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分。</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零。</returns> 
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        // <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄。</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零。</returns> 
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;



        /// <summary>
        /// 获取正在运行的实例，没有运行的实例返回null;
        /// </summary> 
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 显示已运行的程序。
        /// </summary>
        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL); //显示，可以注释掉
            SetForegroundWindow(instance.MainWindowHandle);            //放到前端
        }
        #endregion


        #region 捕捉系统异常
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // UI thread exception.
            var msg = e.Exception.ToString();
            var ss = string.Format("{0}发生UI线程异常。\r\n{1}\r\n\r\n\r\n", DateTime.Now, msg);
            System.IO.File.AppendAllText(Application.StartupPath + @"\log\系统异常.log", ss);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // unknown exception.
            var msg = e.ExceptionObject.ToString();
            var ss = string.Format("{0}发生非UI系统异常。\r\n{1}\r\n\r\n\r\n", DateTime.Now, msg);
            System.IO.File.AppendAllText(Application.StartupPath + @"\log\系统异常.log", ss);
        }

        #endregion

    }
}
