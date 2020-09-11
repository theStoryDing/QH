namespace CaterUI
{
    partial class FormShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarPulse = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarSQL = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarPLC = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IP设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始监听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试读写ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.progressBarPulse);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.progressBarSQL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.progressBarPLC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 516);
            this.panel1.TabIndex = 0;
            // 
            // progressBarPulse
            // 
            this.progressBarPulse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarPulse.Location = new System.Drawing.Point(307, 496);
            this.progressBarPulse.Name = "progressBarPulse";
            this.progressBarPulse.Size = new System.Drawing.Size(29, 15);
            this.progressBarPulse.TabIndex = 10;
            this.progressBarPulse.Value = 100;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "握手信号:";
            // 
            // progressBarSQL
            // 
            this.progressBarSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarSQL.Location = new System.Drawing.Point(162, 496);
            this.progressBarSQL.Name = "progressBarSQL";
            this.progressBarSQL.Size = new System.Drawing.Size(29, 15);
            this.progressBarSQL.TabIndex = 8;
            this.progressBarSQL.Value = 100;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "SQL:";
            // 
            // progressBarPLC
            // 
            this.progressBarPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarPLC.Location = new System.Drawing.Point(57, 496);
            this.progressBarPLC.Name = "progressBarPLC";
            this.progressBarPLC.Size = new System.Drawing.Size(29, 15);
            this.progressBarPLC.TabIndex = 6;
            this.progressBarPLC.Value = 100;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "PLC:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 461);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(189)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(767, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "显示";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(189)))));
            this.tabPage2.Controls.Add(this.dgvMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "信息";
            // 
            // dgvMessage
            // 
            this.dgvMessage.AllowUserToAddRows = false;
            this.dgvMessage.AllowUserToDeleteRows = false;
            this.dgvMessage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(189)))));
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTime,
            this.ColumnMsg});
            this.dgvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessage.Location = new System.Drawing.Point(3, 3);
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.ReadOnly = true;
            this.dgvMessage.RowTemplate.Height = 27;
            this.dgvMessage.Size = new System.Drawing.Size(766, 423);
            this.dgvMessage.TabIndex = 0;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTime.Frozen = true;
            this.ColumnTime.HeaderText = "时间";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 150;
            // 
            // ColumnMsg
            // 
            this.ColumnMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMsg.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnMsg.HeaderText = "信息";
            this.ColumnMsg.Name = "ColumnMsg";
            this.ColumnMsg.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IP设置ToolStripMenuItem,
            this.开始监听ToolStripMenuItem,
            this.测试读写ToolStripMenuItem,
            this.清屏ToolStripMenuItem,
            this.测试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(778, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // IP设置ToolStripMenuItem
            // 
            this.IP设置ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.IP设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IP设置ToolStripMenuItem.Image")));
            this.IP设置ToolStripMenuItem.Name = "IP设置ToolStripMenuItem";
            this.IP设置ToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.IP设置ToolStripMenuItem.Text = "PLC通讯设置";
            // 
            // 开始监听ToolStripMenuItem
            // 
            this.开始监听ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.开始监听ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("开始监听ToolStripMenuItem.Image")));
            this.开始监听ToolStripMenuItem.Name = "开始监听ToolStripMenuItem";
            this.开始监听ToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.开始监听ToolStripMenuItem.Text = "开始监听";
            // 
            // 测试读写ToolStripMenuItem
            // 
            this.测试读写ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.测试读写ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("测试读写ToolStripMenuItem.Image")));
            this.测试读写ToolStripMenuItem.Name = "测试读写ToolStripMenuItem";
            this.测试读写ToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.测试读写ToolStripMenuItem.Text = "测试读写";
            // 
            // 清屏ToolStripMenuItem
            // 
            this.清屏ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.清屏ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("清屏ToolStripMenuItem.Image")));
            this.清屏ToolStripMenuItem.Name = "清屏ToolStripMenuItem";
            this.清屏ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.清屏ToolStripMenuItem.Text = "清屏";
            this.清屏ToolStripMenuItem.Click += new System.EventHandler(this.清屏ToolStripMenuItem_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Visible = false;
            // 
            // FormShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(783, 516);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormShow";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormShow";
            this.Load += new System.EventHandler(this.FormShow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem IP设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始监听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试读写ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.ProgressBar progressBarPulse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarSQL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarPLC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMsg;
    }
}