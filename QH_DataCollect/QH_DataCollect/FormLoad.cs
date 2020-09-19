using CaterCommon;
using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    /// <summary>
    /// 加载界面，用于加载配置文件
    /// </summary>
    public partial class FormLoad : Form
    {
        /// <summary>
        /// 进度信息
        /// </summary>
        private string Msg { set; get; }

        /// <summary>
        /// 是否完成加载
        /// </summary>
        private bool IsLoadCompele;  

        public FormLoad()
        {
            InitializeComponent();
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 20;
        }

        /// <summary>
        /// 文件加载线程
        /// </summary>
        Thread LoadThread = null;

        private void FormLoad_Load(object sender, EventArgs e)
        {
            LoadThread = new Thread(FileLoading);
            LoadThread.Start();
            TimeUpdate.Start();
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        private void FileLoading()
        {
            try
            {
                //加载通用配置文件
                Msg = "加载通用配置文件中……";
                CommonFileLoading();
                Thread.Sleep(1000);

                Msg = "加载PLC配置文件中……";
                PLCFileLoading();
                Thread.Sleep(1000);

                Msg = "加载数据库配置文件中……";
                SQLFileLoading();
                Thread.Sleep(1000);

                Msg = "程序正在打开……";
                Thread.Sleep(1000);
                IsLoadCompele = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载配置文件失败，原因" + ex.Message);
                LogHelper.Error("加载配置文件失败，原因" + ex.Message);
            }
                       
        }

        #region 加载数据库配置文件
        private void SQLFileLoading()
        {
            DirectoryInfo str = new DirectoryInfo(string.Format(@"{0}..\..\..\config\SQL.xml", Application.StartupPath));
            string path = str.FullName;
            SQLInfo.Server = XMLHelper.ReadNode(path, "server");
            SQLInfo.DB = XMLHelper.ReadNode(path, "db");
            SQLInfo.UserID = XMLHelper.ReadNode(path, "userid");
            SQLInfo.Password = DESHelper.Decode(XMLHelper.ReadNode(path, "password"));
            SQLInfo.IsSave = ("1" == XMLHelper.ReadNode(path, "issave")) ? true : false;
        }
        #endregion

        #region 加载通用配置文件
        private void CommonFileLoading()
        {
            DirectoryInfo str = new DirectoryInfo(string.Format(@"{0}..\..\..\config\Common.xml", Application.StartupPath));
            string path = str.FullName;
            InitFormInfo.Title = XMLHelper.ReadNode(path,"title");
            InitFormInfo.PLC = XMLHelper.ReadNode(path, "plc");
            InitFormInfo.WorkFlowNums = Convert.ToInt32(XMLHelper.ReadNode(path, "workFlowNums"));
        }
        #endregion

        #region 加载PLC配置文件
        private void PLCFileLoading()
        {
            DirectoryInfo str = new DirectoryInfo(string.Format(@"{0}..\..\..\config\PLC.xml", Application.StartupPath));
            string path = str.FullName;

            for(int i = 0; i< InitFormInfo.WorkFlowNums; i++)
            {
                Global.ListPLCInfo.Add(new PLCInfo()
                {
                    Device = XMLHelper.ReadNode(path, string.Format("plc{0}//device", i+1)),
                    IP = XMLHelper.ReadNode(path, string.Format("plc{0}//ip", i + 1)),
                    Port = Convert.ToInt32(XMLHelper.ReadNode(path, string.Format("plc{0}//port", i + 1))),
                    NS = Convert.ToInt32(XMLHelper.ReadNode(path, string.Format("plc{0}//ns", i + 1)))
                });
            }
            
        }
        #endregion

        private void TextShow(string text, bool isComplete)
        {
            if(!isComplete)
            {
                //加载中
                this.lblShow.Text = text;
            }
            else
            {
                //加载完成
                this.lblShow.Text = text;
                CloseForm();
            }

        }

        private void TimeUpdate_Tick(object sender, EventArgs e)
        {
            TextShow(Msg,IsLoadCompele);
        }

        private void CloseForm()
        {
            TimeUpdate.Stop();
            //关闭线程
            if (null != LoadThread && LoadThread.IsAlive)
            {
                LoadThread.Abort();
                LoadThread = null;
            }
            this.Close();
        }
    }
}
