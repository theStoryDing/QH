namespace CaterUI
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库通讯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_currentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_currentState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_localIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_errorLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_fatalLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_startTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Spinner = new DMSkin.Metro.Controls.MetroProgressSpinner();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_StopRunning = new DMSkin.Controls.DMButton();
            this.btn_exit = new DMSkin.Controls.DMButton();
            this.btn_Run = new DMSkin.Controls.DMButton();
            this.timerLogin = new System.Windows.Forms.Timer(this.components);
            this.timer_deleteLogFile = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.信息查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1662, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.注销ToolStripMenuItem});
            this.用户ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.用户ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("用户ToolStripMenuItem.Image")));
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("登录ToolStripMenuItem.Image")));
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("注销ToolStripMenuItem.Image")));
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库通讯ToolStripMenuItem});
            this.设置ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("设置ToolStripMenuItem.Image")));
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 数据库通讯ToolStripMenuItem
            // 
            this.数据库通讯ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("数据库通讯ToolStripMenuItem.Image")));
            this.数据库通讯ToolStripMenuItem.Name = "数据库通讯ToolStripMenuItem";
            this.数据库通讯ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.数据库通讯ToolStripMenuItem.Text = "数据库通讯";
            this.数据库通讯ToolStripMenuItem.Click += new System.EventHandler(this.数据库通讯ToolStripMenuItem_Click);
            // 
            // 信息查看ToolStripMenuItem
            // 
            this.信息查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据查询ToolStripMenuItem,
            this.日志信息ToolStripMenuItem});
            this.信息查看ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.信息查看ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("信息查看ToolStripMenuItem.Image")));
            this.信息查看ToolStripMenuItem.Name = "信息查看ToolStripMenuItem";
            this.信息查看ToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.信息查看ToolStripMenuItem.Text = "信息查看";
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("数据查询ToolStripMenuItem.Image")));
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            this.数据查询ToolStripMenuItem.Click += new System.EventHandler(this.数据查询ToolStripMenuItem_Click);
            // 
            // 日志信息ToolStripMenuItem
            // 
            this.日志信息ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("日志信息ToolStripMenuItem.Image")));
            this.日志信息ToolStripMenuItem.Name = "日志信息ToolStripMenuItem";
            this.日志信息ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.日志信息ToolStripMenuItem.Text = "日志信息";
            this.日志信息ToolStripMenuItem.Click += new System.EventHandler(this.日志信息ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作手册ToolStripMenuItem,
            this.关于软件ToolStripMenuItem});
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.帮助ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("帮助ToolStripMenuItem.Image")));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 操作手册ToolStripMenuItem
            // 
            this.操作手册ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("操作手册ToolStripMenuItem.Image")));
            this.操作手册ToolStripMenuItem.Name = "操作手册ToolStripMenuItem";
            this.操作手册ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.操作手册ToolStripMenuItem.Text = "操作手册";
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关于软件ToolStripMenuItem.Image")));
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssl_currentUser,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.tssl_currentState,
            this.toolStripStatusLabel6,
            this.tssl_localIP,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel9,
            this.tssl_errorLog,
            this.toolStripStatusLabel11,
            this.toolStripStatusLabel4,
            this.tssl_fatalLog,
            this.toolStripStatusLabel10,
            this.tssl_startTime,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 978);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1662, 25);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(93, 20);
            this.toolStripStatusLabel1.Text = "当前用户:";
            // 
            // tssl_currentUser
            // 
            this.tssl_currentUser.ForeColor = System.Drawing.Color.Black;
            this.tssl_currentUser.Name = "tssl_currentUser";
            this.tssl_currentUser.Size = new System.Drawing.Size(13, 20);
            this.tssl_currentUser.Text = " ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel3.Text = "||";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(104, 20);
            this.toolStripStatusLabel2.Text = "当前模式：";
            // 
            // tssl_currentState
            // 
            this.tssl_currentState.ForeColor = System.Drawing.Color.OrangeRed;
            this.tssl_currentState.Name = "tssl_currentState";
            this.tssl_currentState.Size = new System.Drawing.Size(39, 20);
            this.tssl_currentState.Text = "离线";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel6.Text = "||";
            // 
            // tssl_localIP
            // 
            this.tssl_localIP.ForeColor = System.Drawing.Color.Black;
            this.tssl_localIP.Image = ((System.Drawing.Image)(resources.GetObject("tssl_localIP.Image")));
            this.tssl_localIP.Name = "tssl_localIP";
            this.tssl_localIP.Size = new System.Drawing.Size(91, 20);
            this.tssl_localIP.Text = "本机IP：";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel8.Text = "||";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel9.Image")));
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(125, 20);
            this.toolStripStatusLabel9.Text = "日志Error数：";
            // 
            // tssl_errorLog
            // 
            this.tssl_errorLog.ForeColor = System.Drawing.Color.Crimson;
            this.tssl_errorLog.Name = "tssl_errorLog";
            this.tssl_errorLog.Size = new System.Drawing.Size(27, 20);
            this.tssl_errorLog.Text = "00";
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel11.Text = "||";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel4.Image")));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(123, 20);
            this.toolStripStatusLabel4.Text = "日志Fatal数：";
            // 
            // tssl_fatalLog
            // 
            this.tssl_fatalLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.tssl_fatalLog.Name = "tssl_fatalLog";
            this.tssl_fatalLog.Size = new System.Drawing.Size(27, 20);
            this.tssl_fatalLog.Text = "00";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel10.Text = "||";
            // 
            // tssl_startTime
            // 
            this.tssl_startTime.ForeColor = System.Drawing.Color.Black;
            this.tssl_startTime.Image = ((System.Drawing.Image)(resources.GetObject("tssl_startTime.Image")));
            this.tssl_startTime.Name = "tssl_startTime";
            this.tssl_startTime.Size = new System.Drawing.Size(104, 20);
            this.tssl_startTime.Text = "软件开启：";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel5.Text = "||";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel7.Image")));
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(161, 20);
            this.toolStripStatusLabel7.Text = "开发：M&&E/软件部";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1662, 950);
            this.panel1.TabIndex = 9;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(79, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1583, 950);
            this.panelMain.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.Spinner, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(79, 950);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Spinner
            // 
            this.Spinner.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.Spinner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(222)))));
            this.Spinner.DM_CustomBackground = true;
            this.Spinner.DM_Maximum = 100;
            this.Spinner.DM_Speed = 2F;
            this.Spinner.DM_UseCustomBackColor = true;
            this.Spinner.DM_UseSelectable = true;
            this.Spinner.DM_UseStyleColors = true;
            this.Spinner.DM_Value = 30;
            this.Spinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spinner.Location = new System.Drawing.Point(3, 3);
            this.Spinner.Name = "Spinner";
            this.Spinner.Size = new System.Drawing.Size(73, 60);
            this.Spinner.Style = DMSkin.Metro.MetroColorStyle.Red;
            this.Spinner.TabIndex = 2;
            this.Spinner.Theme = DMSkin.Metro.MetroThemeStyle.Light;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btn_StopRunning, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_exit, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_Run, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(73, 878);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // btn_StopRunning
            // 
            this.btn_StopRunning.BackColor = System.Drawing.Color.Transparent;
            this.btn_StopRunning.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_StopRunning.BackgroundImage")));
            this.btn_StopRunning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_StopRunning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StopRunning.DM_DisabledColor = System.Drawing.Color.Empty;
            this.btn_StopRunning.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btn_StopRunning.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.btn_StopRunning.DM_NormalColor = System.Drawing.Color.Transparent;
            this.btn_StopRunning.DM_Radius = 1;
            this.btn_StopRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_StopRunning.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StopRunning.ForeColor = System.Drawing.Color.Black;
            this.btn_StopRunning.Image = null;
            this.btn_StopRunning.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_StopRunning.Location = new System.Drawing.Point(4, 296);
            this.btn_StopRunning.Margin = new System.Windows.Forms.Padding(4);
            this.btn_StopRunning.Name = "btn_StopRunning";
            this.btn_StopRunning.Size = new System.Drawing.Size(65, 284);
            this.btn_StopRunning.TabIndex = 12;
            this.btn_StopRunning.Text = "停止";
            this.btn_StopRunning.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_StopRunning.UseVisualStyleBackColor = false;
            this.btn_StopRunning.Click += new System.EventHandler(this.btn_StopRunning_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::QH_DataCollect.Properties.Resources._24;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.DM_DisabledColor = System.Drawing.Color.Empty;
            this.btn_exit.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btn_exit.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.btn_exit.DM_NormalColor = System.Drawing.Color.Transparent;
            this.btn_exit.DM_Radius = 1;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_exit.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.Image = null;
            this.btn_exit.Location = new System.Drawing.Point(4, 588);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(65, 286);
            this.btn_exit.TabIndex = 13;
            this.btn_exit.Text = "退出";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.Transparent;
            this.btn_Run.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Run.BackgroundImage")));
            this.btn_Run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Run.DM_DisabledColor = System.Drawing.Color.Empty;
            this.btn_Run.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btn_Run.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.btn_Run.DM_NormalColor = System.Drawing.Color.Transparent;
            this.btn_Run.DM_Radius = 1;
            this.btn_Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Run.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Run.ForeColor = System.Drawing.Color.Black;
            this.btn_Run.Image = null;
            this.btn_Run.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Run.Location = new System.Drawing.Point(4, 4);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(65, 284);
            this.btn_Run.TabIndex = 11;
            this.btn_Run.Text = "运行";
            this.btn_Run.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Run.UseCompatibleTextRendering = true;
            this.btn_Run.UseMnemonic = false;
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // timerLogin
            // 
            this.timerLogin.Interval = 60000;
            this.timerLogin.Tick += new System.EventHandler(this.timerLogin_Tick);
            // 
            // timer_deleteLogFile
            // 
            this.timer_deleteLogFile.Enabled = true;
            this.timer_deleteLogFile.Interval = 60000;
            this.timer_deleteLogFile.Tick += new System.EventHandler(this.timer_deleteLogFile_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1662, 1003);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "QH数据采集程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库通讯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_currentUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_currentState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tssl_localIP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel tssl_errorLog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssl_fatalLog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel tssl_startTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DMSkin.Metro.Controls.MetroProgressSpinner Spinner;
        private DMSkin.Controls.DMButton btn_StopRunning;
        private DMSkin.Controls.DMButton btn_exit;
        private DMSkin.Controls.DMButton btn_Run;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timerLogin;
        private System.Windows.Forms.Timer timer_deleteLogFile;
    }
}

