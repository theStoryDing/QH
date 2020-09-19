using CaterCommon;
using CaterModel;
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
    /// 主界面
    /// </summary>
    public partial class FormMain : Form
    {

        #region 变量
        //定时刷新日志数
        private System.Threading.Timer RefreshLogTimer;
        //采用同步上下文方式更改UI线程中属性
        SynchronizationContext SyncContext = null;

        //程序运行模式设置
        public enum RunMode { None, OnLine, Test, OffLine }
        public RunMode CurrentRunMode = RunMode.OffLine;

        #endregion

        #region GUI
        //界面窗体链表
        public List<FormShow> ListDisplayForm = new List<FormShow>();
        public List<Panel> ListPanelControl = new List<Panel>();
        public List<Label> ListLabelControl = new List<Label>();
        //tab控制分页
        private List<Panel> ListTabPanel = new List<Panel>();
        private List<TabPage> ListTabPage = new List<TabPage>();
        #endregion

        #region 窗体成员变量
        public FormLogin LoginForm;
        FormQueryData QueryDataForm;

        #endregion

        public FormMain()
        {
            InitializeComponent();
            
            //缓存机制，防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            SyncContext = SynchronizationContext.Current;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //标题
            this.Text = InitFormInfo.Title;
            //软件开启时间
            tssl_startTime.Text = string.Format("软件开启：{0}", DateTime.Now);
            //本机IP地址
            tssl_localIP.Text = string.Format("本地IP：{0}", GetLocalIp());
            //登录状态
            //界面布局
            UpdateLayOut();
            //注册用户登录事件
            LoginForm = new FormLogin();
            UserInfo.CurrentLevel = UserInfo.UserLevel.Administrator;
            LoginForm.LoginEvent += UserLogin;
            UserLogin("管理员");

            //定时刷新控件状态
            RefreshLogTimer = new System.Threading.Timer(LogRefresh, null, 0, Timeout.Infinite);


        }


        #region 日志数刷新
        private void LogRefresh(object state)
        {
            SendOrPostCallback callback = o =>
            {
                tssl_errorLog.Text = LogHelper.ErrorCount.ToString();
                tssl_fatalLog.Text = LogHelper.FatalCount.ToString();

                //日志文件错误数

                if (99999 < (LogHelper.FatalCount + LogHelper.ErrorCount))
                {
                    LogHelper.FatalCount = 0;
                    LogHelper.ErrorCount = 0;
                }
            };
            SyncContext.Post(callback, null);
            if (null != RefreshLogTimer)
            {               
                RefreshLogTimer.Change(350, Timeout.Infinite);
            }
        }
        #endregion

        #region 防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 界面布局
        private void UpdateLayOut()
        {
            #region 窗体界面
            int num = InitFormInfo.WorkFlowNums;
            int maxNum = 4; //一个页面最多4个窗体
            if (1 > num)
            {
                num = 1;
            }

            if (maxNum >= num)
            {
                for (int i = 0; i < num; i++)
                {
                    ListDisplayForm.Add(new FormShow(i));
                    ListLabelControl.Add(new Label());
                    ListPanelControl.Add(new Panel());
                    panelMain.Controls.Add(ListPanelControl[i]);
                    ListPanelControl[i].Controls.Add(ListDisplayForm[i]);
                    ListDisplayForm[i].Show();
                    ListPanelControl[i].Controls.Add(ListLabelControl[i]);
                }

                #region 工作流程在4个以内时界面布局
                int w = panelMain.Width;
                int h = panelMain.Height;
                switch (num)
                {
                    case 1:
                        ListPanelControl[0].Location = new Point(0, 0);
                        ListPanelControl[0].Size = new Size(w, h);
                        break;
                    case 2:
                        ListPanelControl[0].Location = new Point(0, 0);
                        ListPanelControl[0].Size = new Size((int)(w / 2), h);
                        ListPanelControl[1].Location = new Point((int)(w / 2), 0);
                        ListPanelControl[1].Size = new Size((int)(w / 2), h);
                        break;
                    case 3:
                        ListPanelControl[0].Location = new Point(0, 0);
                        ListPanelControl[0].Size = new Size((int)(w / 3), (int)(h));

                        ListPanelControl[1].Location = new Point((int)(w / 3), 0);
                        ListPanelControl[1].Size = new Size((int)(w / 3), (int)(h));

                        ListPanelControl[2].Location = new Point((w * 2) / 3, 0);
                        ListPanelControl[2].Size = new Size(w / 3, (int)(h));
                        break;
                    case 4:
                        ListPanelControl[0].Location = new Point(0, 0);
                        ListPanelControl[0].Size = new Size((int)(w / 2), (int)(h / 2));

                        ListPanelControl[1].Location = new Point((int)(w / 2), 0);
                        ListPanelControl[1].Size = new Size((int)(w / 2), (int)(h / 2));

                        ListPanelControl[2].Location = new Point(0, (int)(h / 2));
                        ListPanelControl[2].Size = new Size((int)(w / 2), (int)(h / 2));

                        ListPanelControl[3].Location = new Point((int)(w / 2), (int)(h / 2));
                        ListPanelControl[3].Size = new Size((int)(w / 2), (int)(h / 2));
                        break;
                }
                for (int i = 0; i < num; i++)
                {
                    ArrangeDisplay(ListDisplayForm[i], ListLabelControl[i], ListPanelControl[i],Global.ListPLCInfo[i].IP, i);
                }

                #endregion
            }
            else
            {
                #region 窗体超过4个时界面布局
                TabControl tabControl = new TabControl();
                tabControl.Dock = DockStyle.Fill;
                this.panelMain.Controls.Add(tabControl);

                //计算需要的 tab页数
                int tab_num = Convert.ToInt16(Math.Ceiling(num * 1.0 / maxNum));
                //tabcontrol 第i页
                for (int i = 0; i < tab_num; i++)
                {
                    Panel tabPanel = new Panel();
                    tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabPanel.Name = "tabpanel" + i.ToString();

                    //第i页 第j个窗体
                    for (int j = 0; j < maxNum; j++)
                    {
                        int k = i * maxNum + j;  //第k个窗体

                        if (k < num)
                        {
                            ListDisplayForm.Add(new FormShow(k));
                            ListLabelControl.Add(new Label());
                            ListPanelControl.Add(new Panel());
                            tabPanel.Controls.Add(ListPanelControl[k]);
                            ListPanelControl[k].Controls.Add(ListDisplayForm[k]);
                            ListDisplayForm[k].Show();
                            ListPanelControl[k].Controls.Add(ListLabelControl[k]);
                        }

                    }

                    ListTabPanel.Add(tabPanel); //panel分组添加到tabpage

                    //增添tabcontrol分页
                    TabPage tabPage = new TabPage();
                    tabPage.BorderStyle = BorderStyle.None;
                    tabPage.Controls.Add(ListTabPanel[i]);
                    tabPage.Name = "tabPage" + i.ToString();
                    tabPage.Padding = new System.Windows.Forms.Padding(3);
                    tabPage.TabIndex = i;
                    tabPage.Text = "第" + (i + 1).ToString() + "组";
                    tabPage.UseVisualStyleBackColor = true;
                    ListTabPage.Add(tabPage);
                    tabControl.Controls.Add(ListTabPage[i]);

                    #region 界面布局
                    int w = ListTabPanel[i].Width;
                    int h = ListTabPanel[i].Height;
                    int formIndex = i * maxNum;
                    if (i == tab_num - 1)
                    {
                        //最后一页 窗体铺满
                        switch (num % maxNum)
                        {
                            case 1:
                                ListPanelControl[formIndex].Location = new Point(0, 0);
                                ListPanelControl[formIndex].Size = new Size(w, h);
                                break;
                            case 2:
                                ListPanelControl[formIndex].Location = new Point(0, 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), h);
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point((int)(w / 2), 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), h);
                                break;
                            case 3:
                                ListPanelControl[formIndex].Location = new Point(0, 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 3), (int)(h));
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point((int)(w / 3), 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 3), (int)(h));
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point((w * 2) / 3, 0);
                                ListPanelControl[formIndex].Size = new Size(w / 3, (int)(h));
                                break;
                            case 0:
                                ListPanelControl[formIndex].Location = new Point(0, 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point((int)(w / 2), 0);
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point(0, (int)(h / 2));
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                                formIndex++;
                                ListPanelControl[formIndex].Location = new Point((int)(w / 2), (int)(h / 2));
                                ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                                break;
                        }
                    }
                    else
                    {
                        if (formIndex < num)
                        {
                            ListPanelControl[formIndex].Location = new Point(0, 0);
                            ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                        }

                        formIndex++;
                        if (formIndex < num)
                        {
                            ListPanelControl[formIndex].Location = new Point((int)(w / 2), 0);
                            ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                        }

                        formIndex++;
                        if (formIndex < num)
                        {
                            ListPanelControl[formIndex].Location = new Point(0, (int)(h / 2));
                            ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                        }

                        formIndex++;
                        if (formIndex < num)
                        {
                            ListPanelControl[formIndex].Location = new Point((int)(w / 2), (int)(h / 2));
                            ListPanelControl[formIndex].Size = new Size((int)(w / 2), (int)(h / 2));
                        }
                    }



                    #endregion
                }
                for (int i = 0; i < num; i++)
                {
                    ArrangeDisplay(ListDisplayForm[i], ListLabelControl[i], ListPanelControl[i],Global.ListPLCInfo[i].IP, i);
                }
                #endregion
            }

            #endregion
        }

        

        private void ArrangeDisplay(FormShow dis, Label label, Panel panel,string ip, int i)
        {
            label.Dock = DockStyle.Top;
            label.Height = 20;
            label.BackColor = Color.FromArgb(250, 249, 222);
            label.Text = string.Format("PLC {0}:[{1}]", (i + 1).ToString(), ip);
            label.ForeColor = Color.Black;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.TextAlign = ContentAlignment.MiddleCenter;
            dis.Location = new Point(0, 21);
            dis.Size = new Size(panel.Width, panel.Height - label.Height);
        }

        #endregion

        #region 获取本地IP
        private string GetLocalIp()
        {

            string ip = string.Empty;
            foreach (System.Net.IPAddress _ip in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (_ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = _ip.ToString();
                    break;
                }

            }
            return ip;
        }

        #endregion

        #region 用户登录触发事件
        private void UserLogin(string user)
        {
            switch (user)
            {
                case "管理员":
                    UserInfo.CurrentLevel = UserInfo.UserLevel.Administrator;
                    break;
                case "工程师":
                    UserInfo.CurrentLevel = UserInfo.UserLevel.Technician;
                    //登录计时
                    timerLogin.Start();
                    break;
                default:
                    break;
            }
            tssl_currentUser.Text = user;
            UpdateControlStatus();

        }

        /// <summary>
        /// 更新控件状态
        /// </summary>
        private void UpdateControlStatus()
        {
            //程序是否在运行
            bool isOnLine = (RunMode.OnLine == CurrentRunMode) ? true : false;
            //工程师
            bool isTech = (UserInfo.UserLevel.Technician == UserInfo.CurrentLevel) ? true : false;
            //管理员
            bool isAdmin = (UserInfo.UserLevel.Administrator == UserInfo.CurrentLevel) ? true : false;
            //在线状态时，更改菜单栏状态

            this.设置ToolStripMenuItem.Enabled = isTech && !isOnLine;

            if (isOnLine)
            {
                // this.Spinner.BackColor = System.Drawing.Color.ActiveCaption;
                this.Spinner.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.Spinner.Style = DMSkin.Metro.MetroColorStyle.Lime;
                this.Spinner.Theme = DMSkin.Metro.MetroThemeStyle.Light;

                tssl_currentState.ForeColor = Color.LimeGreen;
                tssl_currentState.Text = "在线";
            }
            else
            {
                // this.Spinner.BackColor = System.Drawing.;
                this.Spinner.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.Spinner.Style = DMSkin.Metro.MetroColorStyle.Red;
                this.Spinner.Theme = DMSkin.Metro.MetroThemeStyle.Light;

                tssl_currentState.ForeColor = Color.OrangeRed;
                tssl_currentState.Text = "离线";
            }
            btn_StopRunning.Enabled = isOnLine;
            btn_Run.Enabled = !isOnLine;

            //用户登录更新子菜单操作 如果满足工程师权限且非在线状态则允许操作菜单，否则禁止
            for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
            {
                ListDisplayForm[i].UpdateFormDataAccessLevelMenuState(isTech, isOnLine);
            }
        }
        #endregion

        #region 登录计时器
        private void timerLogin_Tick(object sender, EventArgs e)
        {
            timerLogin.Stop();

        }
        #endregion

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != LoginForm)
            {
                LoginForm.StartPosition = FormStartPosition.CenterParent;
                LoginForm.ShowDialog();
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin("管理员");
        }



        #region 退出程序
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("将要退出应用程序，请先停止运行程序，以防丢失数据，是否继续？",
                                "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FormShowExit();

                    if (null != RefreshLogTimer)
                    {
                        RefreshLogTimer.Dispose();
                    }
                }
                finally
                {
                    this.Dispose();//放此类占有的资源
                    System.GC.Collect();
                    this.Close();
                    Application.Exit();
                    System.Environment.Exit(System.Environment.ExitCode);
                }

            }
            else
            {
                if (null != e) e.Cancel = true;
            }
        }

        //子窗体退出
        private void FormShowExit()
        {
            for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
            {
                ListDisplayForm[i].Exit();
            }
            ListDisplayForm.Clear();
        }
        #endregion

        private void btn_exit_Click(object sender, EventArgs e)
        {
            FormMain_FormClosing(null, null);
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            PLCStart();
        }

        #region PLC运行
        private void PLCStart()
        {
            //检测PLC与数据库是否全部链接上
            bool isRun = true;
            for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
            {
                isRun = isRun && ListDisplayForm[i].ConnectPLC;
                isRun = isRun && ListDisplayForm[i].ConnectSQL;
            }
            if (isRun)
            {
                //窗体状态更改
                CurrentRunMode = RunMode.OnLine;
                UpdateControlStatus();
                for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
                {
                    ListDisplayForm[i].StartListen();
                }
            }
            else
            {
                MessageBox.Show("PLC或数据库未连接，程序无法启动，请检查连接！");
            }
        }
        #endregion

        private void btn_StopRunning_Click(object sender, EventArgs e)
        {
            PCLStop();
        }

        #region PLC停止
        private void PCLStop()
        {
            //停止处理
            for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
            {
                ListDisplayForm[i].StopListen();
            }
            //窗体状态更改
            CurrentRunMode = RunMode.OffLine;
            UpdateControlStatus();
        }

        #endregion

        private void 数据库通讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormSQL sql = new FormSQL())
            {
                sql.StartPosition = FormStartPosition.CenterParent;
                sql.ChangeDBEvent += ChangeDB;
                sql.ShowDialog();
            }
        }

        #region 数据库参数发生变化是触发
        private void ChangeDB()
        {
            for (int i = 0; i < InitFormInfo.WorkFlowNums; i++)
            {
                ListDisplayForm[i].InitSQL();
            }
        }

        #endregion

        private void timer_deleteLogFile_Tick(object sender, EventArgs e)
        {
            LogHelper.DeleteLogFile(LogHelper.LogFileExistDay);
        }


        private void 日志信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + "\\log");
        }

        private void 数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == QueryDataForm || QueryDataForm.IsDisposed)
            {
                QueryDataForm = new FormQueryData
                {
                    StartPosition = FormStartPosition.Manual,
                    Size = Screen.PrimaryScreen.WorkingArea.Size
                };
                QueryDataForm.Show();
            }
            else
            {
                QueryDataForm.Activate();
            }
        }
    }
}
