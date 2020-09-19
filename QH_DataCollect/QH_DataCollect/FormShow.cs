using CaterCommon;
using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormShow : Form
    {

        #region 变量
        /// <summary>
        /// 当前窗体索引号
        /// </summary>
        private int Index;
        public const string StartMenuText = "开始运行";
        public const string StopMenuText = "停止运行";

        //程序运行模式设置
        public enum RunMode { None, OnLine, OffLine, OnListen, OffListen }
        public RunMode currentRunMode = RunMode.OffLine;

        FormPLC PLCForm;
        #endregion

        #region 数据库变量
        //数据库连接状态
        private bool IsConnectSQL = false;
        public bool ConnectSQL { get { return IsConnectSQL; } }

        //连接数据库失败次数
        public int ConnectSQLNum;
        #endregion

        #region PLC变量
        //是否连接PLC
        private bool IsConnectPLC = false;
        public bool ConnectPLC { get { return IsConnectPLC; } }

        //PLC握手信号
        private int PLCPulse = 0;

        //握手心跳标志
        private bool IsStart = false;
        private bool IsHandshake = false;
        private bool IsOne = false;

        //欧姆龙PLC
        PLC64Omron PLCOmron;
        //西门子plc
        Class_Siemens PLCSiemens;
        //触发标志
        private volatile int ReadTRG = 0;          //PLC触发交互
        private volatile int OldReadTRG = 1;

        #endregion

        #region 线程
        //处理数据线程启动开关
        public bool IsThreadRunning = true;
        //定时刷新UI
        private System.Threading.Timer RefreshTimer;
        //采用同步上下文方式更改UI线程中属性
        private SynchronizationContext SyncContext = null;
        //PLC线程取消操作
        private CancellationTokenSource Cts = null;
        //处理数据的线程
        private Thread DealDataThread = null;

        //数据存储队列
        private BlockQueue<int> BlockQueue = new BlockQueue<int>(100);
        //数据库 锁
        private readonly object SQLLock = new object();

        #endregion

        #region UI控件
        /// <summary>
        /// PLC指示灯
        /// </summary>
        MyProgressBar BarPLC = null; 

        /// <summary>
        /// 数据库指示灯
        /// </summary>
        MyProgressBar BarSQL = null;

      
        
        //表格组件的最大行数
        public readonly int MaxTableRowNum = 38;
        //指示灯
        public List<MyProgressBar> ListLamp = new List<MyProgressBar>();
        //生成textBox控件用来显示顺序
        public List<TextBox> ListTextBoxesNum = new List<TextBox>();
        //生成textBox控件用来显示条码
        public List<TextBox> ListTextBoxesCode = new List<TextBox>();     
        //生成表格组件
        public TableLayoutPanel TablePanel = null;       
        #endregion

        public FormShow(int i)
        {
            InitializeComponent();
            this.TopLevel = false; // 不是最顶层窗体
            //缓存机制，防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            SyncContext = SynchronizationContext.Current;
            Index = i;
        }
              
        private void FormShow_Load(object sender, EventArgs e)
        {
            //更新界面
            UpdateLayOut();
            //初始化线程
            InitThread();
            //初始化数据库
            InitSQL();
            //PLC 初始化
            InitPLC();

            //启动线程
            if (Cts != null)
            {
                Cts.Cancel();      //取消PC_PLC_SignalExchange线程
            }
            Cts = new CancellationTokenSource();
            switch (InitFormInfo.PLC)
            {
                case "Omron":
                    new Task(() => PC_PLC_SignalExchange_Omron(Cts.Token, false)).Start();
                    break;
                case "Siemens":
                    new Task(() => PC_PLC_SignalExchange_Siemens(Cts.Token, false)).Start();
                    break;

            }


        }

        #region 初始化线程
        private void InitThread()
        {
            //定时刷新控件状态
            RefreshTimer = new System.Threading.Timer(UIRefresh, null, 0, Timeout.Infinite);
            //处理队列数据线程
            DealDataThread = new Thread(DealQueue);
            DealDataThread.Start();

        }
        #endregion

        #region 处理队列中的数据
        private void DealQueue()
        {
            while (IsThreadRunning)
            {
                try
                {
                    DealData();
                }
                catch (Exception ex)
                {
                    LogHelper.Fatal("处理队列线程发生异常！", ex);
                }
            }
        }

        private void DealData()
        {
            try
            {
                var data = BlockQueue.Dequeue();

               
            }
            catch (Exception ex)
            {
                UpdateShowMessage("处理数据时发生异常,原因：" + ex.Message);
                throw new Exception("处理数据时发生异常,原因：" + ex.Message);
            }


        }
        #endregion

        #region 初始化数据库
        public void InitSQL()
        {
            //测试本机数据库是否可连接
           new Task(()=> ConnectSQLTest()).Start();

        }

        
        private void ConnectSQLTest()
        {
            try
            {
                IsConnectSQL = false;
                if (!IsConnectSQL)
                {
                    IsConnectSQL = SqlServerHelper.IsConnectSql();
                }
                if (IsConnectSQL)
                {
                    ConnectSQLNum = 0;
                    UpdateShowMessage("数据库SQL连接成功！");
                }
            }
            catch (Exception ex)
            {
                UpdateShowMessage("SQL连接异常，原因：" + ex.Message);
                LogHelper.Fatal("SQL连接异常！", ex);

                ConnectSQLNum++;
                IsConnectSQL = false;
                SQLInfo.Server = ".";
                switch(ConnectSQLNum)
                {
                    //更改数据库的地址，尝试重连数据库
                    case 1:
                        SQLInfo.Server = ".";
                        ConnectSQLTest();
                        break;
                    case 2:
                        SQLInfo.Server = "127.0.0.1";
                        ConnectSQLTest();
                        break;
                    case 3:
                        SQLInfo.Server = "localhost";
                        ConnectSQLTest();
                        break;
                    default:
                        break;
                }
               
            }
        }

        #endregion

        #region 初始化plc
        private void InitPLC()
        {
            switch(InitFormInfo.PLC)
            {
                case "Omron":
                    InitOmronPLC();
                    break;
                case "Siemens":
                    InitSiemensPLC();
                    break;
                
            }
                 
        }

        #region 初始化欧姆龙PLC
        private void InitOmronPLC()
        {
            try
            {
                IsConnectPLC = false;
                if (null != PLCOmron)
                {
                    PLCOmron.Dispose();
                    PLCOmron = null;
                }
                //注意：连接多个PLC时，要根据连接不同的端口
                PLCOmron = new PLC64Omron(Global.ListPLCInfo[Index].IP, 2, this.Container);

                //PLC_Connect_Omron();
            }
            catch (Exception ex)
            {
                LogHelper.Fatal("欧姆龙PLC初始化失败！", ex);
            }
        }
        #endregion

        #region 初始化西门子plc
        private void InitSiemensPLC()
        {
            try
            {
                IsConnectPLC = false;
                if (null !=PLCSiemens)
                {
                    PLCSiemens.Disconnect();
                    PLCSiemens = null;
                }
                PLCSiemens = new Class_Siemens(Global.ListPLCInfo[Index].IP, Global.ListPLCInfo[Index].Port, Global.ListPLCInfo[Index].NS);
            }
            catch (Exception ex)
            {
                LogHelper.Fatal("西门子PLC初始化失败！", ex);
            }
        }

        #endregion

        #endregion

        #region 与欧姆龙PLC交互线程
        private void PC_PLC_SignalExchange_Omron(CancellationToken token, bool v)
        {
            while (!token.IsCancellationRequested)
            {
                #region 判断plc是否断线
                if (!IsConnectPLC)
                {
                    UpdateShowMessage("正在连接PLC……");
                    new Task(() => ConnectOmronPLC()).Start();
                    Thread.Sleep(3000);
                    continue;
                }
                #endregion
                Thread.Sleep(1);

                #region 发送握手信号
                if (IsHandshake)
                {
                    if (IsStart)
                    {
                        IsOne = !IsOne;

                        PLCPulse = IsOne ? 1 : 2;

                        IsHandshake = false;
                        bool back = false;
                        back = PLCOmron.WriteTagValue(null , PLCPulse);
                        if (!back)
                        {
                            IsConnectPLC = false;
                            PLCPulse = 0;
                        }

                    }
                    else
                    {
                        PLCPulse = 0;
                    }
                }
                #endregion

                #region 与PLC 交互
                if (v)
                {
                    try
                    {
                        object isRead;
                        PLCOmron.ReadTagValue(null, out isRead);
                        ReadTRG = (1 == (int)isRead) ? 1 : 0;
                        if (1 != ReadTRG)
                        {
                            OldReadTRG = 0;
                        }
                        else
                        {
                            if (0 < ReadTRG - OldReadTRG)
                            {
                                //读取数据
                                ReadDataFromPLC_Omron();
                            }
                            OldReadTRG = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        UpdateShowMessage("读取PLC 数据异常:" + ex.Message);
                        LogHelper.Fatal("与plc交互异常！", ex);
                    }
                }
                #endregion

            }
        }

        private void ReadDataFromPLC_Omron()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 连接西门子PLC
        private void ConnectOmronPLC()
        {
            //如果未连接
            if (IsConnectPLC == false && PLCOmron != null)
            {
                bool back = PLCOmron.Connect();
                if (back)
                {
                    IsConnectPLC = true;
                    UpdateShowMessage("PLC连接成功！");
                }
                else
                {
                    IsConnectPLC = false;
                    Thread.Sleep(3000);
                    ConnectOmronPLC();
                }
            }
        }

        #endregion

        #region 西门子plc交互线程
        private void PC_PLC_SignalExchange_Siemens(CancellationToken token, bool v)
        {
            DateTime x = DateTime.Now;
            while (!token.IsCancellationRequested)
            {
                #region 判断plc是否断线
                if (!IsConnectPLC)
                {
                    UpdateShowMessage("正在连接PLC……");
                    Task task1 = Task.Run(() =>
                    {
                        ConnectPLCSiemens();
                    });
                    task1.Wait();

                    Thread.Sleep(3000);
                    continue;
                }
                #endregion


                Thread.Sleep(1);

                #region 发送握手信号
                if (IsHandshake)
                {
                    if (IsStart)
                    {
                        IsOne = !IsOne;

                        PLCPulse = IsOne ? 1 : 2;

                        IsHandshake = false;
                        bool back = false;
                        try
                        {
                            back = PLCSiemens.PLC_WriteValues(PLCPulse.ToString(), null);
                        }
                        catch (Exception ex)
                        {
                            IsConnectPLC = false;
                            UpdateShowMessage("握手信号异常，与PLC断开连接！");

                        }
                        if (!back)
                        {
                            IsConnectPLC = false;
                            PLCPulse = 0;
                        }

                    }
                    else
                    {
                        PLCPulse = 0;
                    }
                }
                #endregion

                #region 与PLC 交互
                if (v)
                {
                    try
                    {
                        #region 读取plc数据
                        var isRead = PLCSiemens.PLC_ReadValues("");
                        ReadTRG = ("1" == isRead) ? 1 : 0;
                        if (1 != ReadTRG)
                        {
                            OldReadTRG = 0;
                        }
                        else
                        {
                            if (0 < ReadTRG - OldReadTRG)
                            {
                                //读取数据
                                ReadDataFromPLC();
                            }
                            OldReadTRG = 1;
                        }

                        #endregion


                    }
                    catch (Exception ex)
                    {             
                        UpdateShowMessage(string.Format("与plc交互异常：{0}！", ex.Message));
                        LogHelper.Fatal(string.Format("与plc交互异常：{0}！", ex.Message));
                    }
                }
                #endregion

            }
        }

        private void ReadDataFromPLC()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 连接西门子plc

        private void ConnectPLCSiemens()
        {
            //如果未连接
            if (IsConnectPLC == false && PLCSiemens != null)
            {
                try
                {
                    var back = PLCSiemens.Connect();
                    if (0 == back)
                    {
                        IsConnectPLC = true;
                        UpdateShowMessage("连接PLC 成功！");

                    }
                    else
                    {
                        IsConnectPLC = false;
                        Thread.Sleep(3000);
                        ConnectPLCSiemens();
                    }
                }
                catch (Exception ex)
                {
                    IsConnectPLC = false;
                    UpdateShowMessage("连接PLC 异常；原因：" + ex.Message);
                    LogHelper.Fatal(ex.Message);
                }

            }
        }
        #endregion

        #region UI刷新
        private void UIRefresh(object state)
        {
            SendOrPostCallback callback = o =>
            {
                //数据库指示灯
                if (!IsConnectSQL)
                {
                    if (Color.FromArgb(252, 71, 71) != BarSQL.BackColor)
                    {
                        BarSQL.BackColor = Color.FromArgb(252, 71, 71);
                    }
                }
                else
                {
                    if (Color.FromArgb(6, 176, 37) != BarSQL.BackColor)
                    {
                        BarSQL.BackColor = Color.FromArgb(6, 176, 37);
                    }
                }

                //PLC指示灯
                if (!IsConnectPLC)
                {
                    if (Color.FromArgb(252, 71, 71) != BarPLC.BackColor)
                    {
                        BarPLC.BackColor = Color.FromArgb(252, 71, 71);
                    }
                }
                else
                {
                    if (Color.FromArgb(6, 176, 37) != BarPLC.BackColor)
                    {
                        BarPLC.BackColor = Color.FromArgb(6, 176, 37);
                    }
                }
                //脉冲
                lblPulse.Text = string.Format("握手信号:{0}", PLCPulse);
            
            };
            if (null != RefreshTimer)
            {
                if (IsDisposed || !this.IsHandleCreated) return;
                SyncContext.Post(callback, null);
                RefreshTimer.Change(350, Timeout.Infinite);
            }

        }
        #endregion

        #region 更新界面布局
        private void UpdateLayOut()
        {
            //动态添加控件
            UpdateForm();
            //UpdateForm2();
            //设置datagrideview控件
            UpdateDataGridView();
            //用自定义的progressBar控件覆系统控件
            InitProgressBar();

        }

       

        #region 用自定义的progressBar控件覆系统控件
        private void InitProgressBar()
        {
            BarPLC = new MyProgressBar();
            BarSQL = new MyProgressBar();
  

            ChangeColor(BarPLC, progressBarPLC);
            ChangeColor(BarSQL, progressBarSQL);
        
        }
        #endregion

        #region 改变进度条的颜色
        /// <summary>
        /// 覆盖系统进度条
        /// </summary>
        /// <param name="bar">自定义进度条</param>
        /// <param name="container">容器进度条</param>
        /// <param name="value">进度条显示值</param>
        private void ChangeColor(MyProgressBar bar, ProgressBar container)
        {
            bar.Parent = container;
            bar.Minimum = 0;//进度条显示最小值
            bar.Maximum = 100;//进度条显示最大值
            bar.Width = container.Width;
            bar.Height = container.Height;
            bar.BackColor = Color.FromArgb(252, 71, 71);
        }

        #endregion

        #region 设置dataGridView
        private void UpdateDataGridView()
        {
            Init_DataGridView(dgvMessage);
        }

        public static void Init_DataGridView(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;//列宽不自动调整,手工添加列 
            DGV.RowHeadersWidth = 50;//行标题宽度固定
            DGV.RowHeadersVisible = false;
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//不能用鼠标调整列标头宽度 
            DGV.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;//奇数行背景色
            //DGV.BackgroundColor = System.Drawing.Color.White;//控件背景色
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//列标题居中显示
            DGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//单元格内容居中显示  //行为
            DGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Wheat;
            DGV.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            //DGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            DGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            DGV.AutoGenerateColumns = false;//不自动创建列
            DGV.AllowUserToAddRows = false;//不启用添加 
            DGV.ReadOnly = true;//只读
            DGV.AllowUserToDeleteRows = false;//不启用删除
            DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;//单击单元格选中单个  
            DGV.MultiSelect = false;//不能多选 
            DGV.AllowUserToResizeRows = false;
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                DGV.Columns[i].ReadOnly = false;
            }
        }


        #endregion

        #region 方式1 动态生成显示界面
        private void UpdateForm()
        {
            TablePanel = new TableLayoutPanel();
            TablePanel.ColumnCount = 3;
            // 设置cell样式，增加线条
            TablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            TablePanel.Dock = DockStyle.Fill;
            TablePanel.AutoScroll = true;
            TablePanel.Padding = new Padding(0, 0, 10, 0);
            //每行单元格占比
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.1f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.85f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.05f));
           
            tabPage1.Controls.Add(TablePanel);

            for (int i = 0; i <= MaxTableRowNum; i++)
            {
                if (0 == i)
                {
                    ListTextBoxesNum.Add(new TextBox()
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Text = "托盘",
                        Dock = DockStyle.Fill,
                        ReadOnly = true,                       
                    });
                }
                else
                {
                    ListTextBoxesNum.Add(new TextBox()
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Text = i.ToString(),
                        Dock = DockStyle.Fill,
                        ReadOnly = true
                    });
                }

                ListTextBoxesCode.Add(new TextBox()
                {
                    TextAlign = HorizontalAlignment.Center,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Tag = i,
                    BackColor = Color.FromArgb(250, 249, 222),

                });

                ListLamp.Add(new MyProgressBar()
                {
                    Dock = DockStyle.Fill,
                    Minimum = 0,
                    Maximum = 100,
                    BackColor = Color.FromArgb(252, 71, 71)

                });
              
                //按顺序添加控件
                TablePanel.Controls.Add(ListTextBoxesNum[i], 0, i);
                TablePanel.Controls.Add(ListTextBoxesCode[i], 1, i);
                TablePanel.Controls.Add(ListLamp[i], 2, i);
                //鼠标移动到控件上方变色
                ListTextBoxesCode[i].MouseMove += ChangeTextColor;
                ListTextBoxesCode[i].MouseLeave += RecoverTextColor;

            }
        }

        #region 鼠标移动到控件上方变色
        private void RecoverTextColor(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.FromArgb(250, 249, 222);
        }

        private void ChangeTextColor(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.Orange;
        }
        #endregion


        #endregion

        #region 方式2 动态生成界面
        private void UpdateForm2()
        {
            TablePanel = new TableLayoutPanel();
            TablePanel.ColumnCount = 6;
            // 设置cell样式，增加线条
            TablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            TablePanel.Dock = DockStyle.Fill;
            TablePanel.AutoScroll = true;
            TablePanel.Padding = new Padding(0, 0, 10, 10);
            //每行单元格占比
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.05f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.3f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.15f));

            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.05f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.3f));
            TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.15f));

            tabPage1.Controls.Add(TablePanel);

            int textNum = 1;
            int codeNum = 1;
            int barNum = 1;
            for (int row = 0; row <= 19; row++)
            {
                for (int column = 0; column <= 5; column++)
                {
                    if (0 == row)
                    {
                        if (0 == column)
                        {
                            ListTextBoxesNum.Add(new TextBox()
                            {
                                TextAlign = HorizontalAlignment.Center,
                                Text = "托盘",
                                Dock = DockStyle.Fill,
                                ReadOnly = true,
                            });

                            ListTextBoxesCode.Add(new TextBox()
                            {
                                TextAlign = HorizontalAlignment.Center,
                                ReadOnly = true,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FromArgb(250, 249, 222),

                            });

                            ListLamp.Add(new MyProgressBar()
                            {
                                Dock = DockStyle.Fill,
                                Minimum = 0,
                                Maximum = 100,
                                BackColor = Color.FromArgb(252, 71, 71)

                            });
                            TablePanel.Controls.Add(ListTextBoxesNum[0], 0, row);
                            TablePanel.Controls.Add(ListTextBoxesCode[0], 1, row);
                            TablePanel.Controls.Add(ListLamp[0], 2, row);
                            //鼠标移动到控件上方变色
                            ListTextBoxesCode[0].MouseMove += ChangeTextColor;
                            ListTextBoxesCode[0].MouseLeave += RecoverTextColor;
                        }
                    }
                    else
                    {
                        if (column == 0 || column == 3)
                        {
                            ListTextBoxesNum.Add(new TextBox()
                            {
                                TextAlign = HorizontalAlignment.Center,
                                Text = textNum.ToString(),
                                Dock = DockStyle.Fill,
                                ReadOnly = true,
                            });

                            TablePanel.Controls.Add(ListTextBoxesNum[textNum], column, row);
                            textNum++;
                        }

                        if (column == 1 || column == 4)
                        {
                            ListTextBoxesCode.Add(new TextBox()
                            {
                                TextAlign = HorizontalAlignment.Center,
                                ReadOnly = true,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FromArgb(250, 249, 222),

                            });
                            TablePanel.Controls.Add(ListTextBoxesCode[codeNum], column, row);
                            //鼠标移动到控件上方变色
                            ListTextBoxesCode[codeNum].MouseMove += ChangeTextColor;
                            ListTextBoxesCode[codeNum].MouseLeave += RecoverTextColor;
                            codeNum++;
                        }

                        if (column == 2 || column == 5)
                        {
                            ListLamp.Add(new MyProgressBar()
                            {
                                Dock = DockStyle.Fill,
                                Minimum = 0,
                                Maximum = 100,
                                BackColor = Color.FromArgb(252, 71, 71)

                            });
                            TablePanel.Controls.Add(ListLamp[barNum], column, row);
                            barNum++;
                        }
                    }


                }

            }
        }
        #endregion

        #endregion

        #region 更新信息
        private void UpdateShowMessage(string strData)
        {
            Action<string> act = (p_str) =>
            {
                int index = dgvMessage.Rows.Add();//默认添加数字类型
                dgvMessage.Rows[index].Cells[0].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dgvMessage.Rows[index].Cells[1].Value = strData;
                if (dgvMessage.Rows.Count > 200)
                    dgvMessage.Rows.RemoveAt(0);
                //滚动到最新行 以下两种方式
                //dgvMessage.FirstDisplayedScrollingRowIndex = dgvMessage.RowCount - 1;
                dgvMessage.CurrentCell = dgvMessage.Rows[dgvMessage.RowCount - 1].Cells[0];
            };
            this.BeginInvoke(act, strData);

            // 安全访问控件
            //if (dgvMessage.InvokeRequired)
            //{
            //    while (!dgvMessage.IsHandleCreated)
            //    {
            //        if (dgvMessage.Disposing || dgvMessage.IsDisposed)
            //        {
            //            return;
            //        }
            //        this.BeginInvoke(act, strData);
            //    }
            //}
            //else
            //{
            //    act(strData);
            //}

        }
        #endregion

        #region 更新显示界面的控件状态
        /// <summary>
        /// 更新显示界面控件相关信息
        /// </summary>
        /// <param name="index">电池的索引号</param>
        /// <param name="code">电池条码</param>
        /// <param name="isOk">是否OK</param>
        private void UpdateTextAndBarStatus(BatteryStatusInfo batteryInfo)
        {
            Action<BatteryStatusInfo> act = (str) =>
            {
                ListTextBoxesCode[batteryInfo.Index].Text = batteryInfo.Code;
                ListLamp[batteryInfo.Index].BackColor = (batteryInfo.IsOK) ? Color.FromArgb(6, 176, 37) : Color.FromArgb(252, 71, 71);
            };
            this.Invoke(act, batteryInfo);
        }

        #endregion

        private void Timer_pulse_Tick(object sender, EventArgs e)
        {
            IsHandshake = true;
        }

        private void 清屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvMessage.Rows.Clear();
           
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateShowMessage("测试");

        }

        private void 开始运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(StartMenuText == this.开始运行ToolStripMenuItem.Text)
            {
                if (StartListen())
                {
                    this.开始运行ToolStripMenuItem.Text = StopMenuText;
                }
            }
            else
            {
                if (StopListen())
                {
                    this.开始运行ToolStripMenuItem.Text = StartMenuText;
                }
            }
        }

        #region 主界面用户权限更改通知窗体改变菜单栏
        public void UpdateFormDataAccessLevelMenuState(bool bTech, bool bOnLine)
        {
            this.IP设置ToolStripMenuItem.Enabled = bTech && !bOnLine;
            //this.开始运行ToolStripMenuItem.Enabled = bTech && !bOnLine;
            this.测试读写ToolStripMenuItem.Enabled = bTech && !bOnLine;
            //如果是开始实时，则菜单栏 开始运行 更改为 停止运行
            if (bOnLine)
            {
                this.开始运行ToolStripMenuItem.Text = StopMenuText;
            }
            else
            {
                this.开始运行ToolStripMenuItem.Text = StartMenuText;
            }
        }
        #endregion

        #region 开始监听PLC

        public bool StartListen()
        {
            if (IsStart)
            {
                currentRunMode = RunMode.OnListen;
                return true;
            }

            try
            {
                //开始监听plc
                if (IsConnectPLC && IsConnectSQL)//plc和数据库同时连上
                {
                    //开启握手
                    IsStart = true;
                    //握手信号计时器
                    Timer_pulse.Start();
                    //2.开启线程
                    if (Cts != null)
                    {
                        Cts.Cancel();      //取消FormLoad时PC_PLC_SignalExchange线程
                    }
                    Cts = new CancellationTokenSource();
                    switch (InitFormInfo.PLC)
                    {
                        case "Omron":
                            new Task(() => PC_PLC_SignalExchange_Omron(Cts.Token, true)).Start();
                            break;
                        case "Siemens":
                            new Task(() => PC_PLC_SignalExchange_Siemens(Cts.Token, true)).Start();
                            break;

                    }
                    //更新开始监听时菜单栏状态
                    currentRunMode = RunMode.OnListen;

                }
                else
                {
                    //监听失败
                    IsStart = false;
                    currentRunMode = RunMode.OffListen;
                    MessageBox.Show("PLC或数据库未连接，程序无法启动，请检查连接！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                UpdateShowMessage(string.Format("程序运行异常，原因:{0}", ex.Message));
                LogHelper.Fatal(string.Format("程序运行异常，原因:{0}", ex.Message));
                return false;
            }
            return true;
        }
        #endregion

        #region 停止监听PLC

        public bool StopListen()
        {
            if (!IsStart)
            {
                currentRunMode = RunMode.OffListen;
                return true;
            }

            try
            {
                //停止监听plc
                //关闭握手
                IsStart = false;
                //握手信号计时器
                Timer_pulse.Stop();
                //2.停止交互线程
                if (Cts != null)
                {
                    Cts.Cancel();      //取消FormLoad时PC_PLC_SignalExchange线程
                }
                Cts = new CancellationTokenSource();
                switch (InitFormInfo.PLC)
                {
                    case "Omron":
                        new Task(() => PC_PLC_SignalExchange_Omron(Cts.Token, false)).Start();
                        break;
                    case "Siemens":
                        new Task(() => PC_PLC_SignalExchange_Siemens(Cts.Token, false)).Start();
                        break;

                }
                //更新停止监听时菜单栏状态
                currentRunMode = RunMode.OffListen;
            }
            catch (Exception ex)
            {
                UpdateShowMessage(string.Format("停止程序异常，原因：{0}", ex.Message));
                LogHelper.Fatal(string.Format("停止程序异常，原因：{0}",ex.Message));
                currentRunMode = RunMode.OffListen;
                return false;
            }

            return true;
        }
        #endregion

        #region 退出程序
        public void Exit()
        {
            Task task = Task.Run(() =>
            {
                //停止PLC交互
                IsConnectPLC = false;
                //关闭阻塞队列
                BlockQueue.CompleteAdding();
             
                while (!BlockQueue.IsCompleted)
                {
                    //等待队列数据处理完
                    Thread.Sleep(100);
                }
                BlockQueue.Close();
  
                //关闭处理线程
                IsThreadRunning = false;
             
                if (null != DealDataThread && DealDataThread.IsAlive)
                {
                    DealDataThread.Abort();
                    DealDataThread = null;
                }
       

                if (Cts != null)
                {
                    Cts.Cancel();
                    Cts.Dispose();
                }

                if (null != RefreshTimer)
                {
                    RefreshTimer.Dispose();
                    RefreshTimer = null;
                }

            });

        }




        #endregion

        private void IP设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == PLCForm || PLCForm.IsDisposed)
            {
                PLCForm = new FormPLC(Index);
                PLCForm.ChangePLCIPEvent += ChangePLCIP;
                PLCForm.Show(this);

            }
            else
            {
                PLCForm.Activate();
            }
        }

        #region 更改PLCIP时触发事件
        private void ChangePLCIP()
        {
            UpdateShowMessage("PLC IP 地址变更，断开连接，正在重新初始化……");
            Global.PLCIndex[0] = 1;
            Global.PLCIndex[1] = Index;
            //重连PLC
            //InitPLC();
            new Task(() => InitPLC()).Start();
        }
        #endregion

        private void 测试读写ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(InitFormInfo.PLC)
            {
                case "Omron":
                    OmronPLCTest();
                    break;
                case "Siemens":
                    SiemensPLCTest();
                    break;
            }
        }

        #region 西门子测试
        private void SiemensPLCTest()
        {
            using (FormTest plc = new FormTest(PLCSiemens, Index))
            {
                plc.StartPosition = FormStartPosition.CenterScreen;
                plc.ShowDialog();

            }
        }
        #endregion

        #region 欧姆龙PLC读写测试
        private void OmronPLCTest()
        {
            using (FormTest plc = new FormTest(PLCOmron, Index))
            {
                plc.StartPosition = FormStartPosition.CenterScreen;
                plc.ShowDialog();
            }
        }
        #endregion

    }
}
