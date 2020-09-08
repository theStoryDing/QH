using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private string Msg { set; get; }   //进度信息
        private bool IsLoadCompele;  //是否完成加载

        public FormLoad()
        {
            InitializeComponent();
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 20;
        }

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
            Msg = "程序正在打开……";
            Thread.Sleep(1000);
            IsLoadCompele = true;           
        }

   

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
