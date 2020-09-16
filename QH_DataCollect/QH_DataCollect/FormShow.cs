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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormShow : Form
    {

        #region 变量

        public const string StartMenuText = "开始运行";
        public const string StopMenuText = "停止运行";

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

        /// <summary>
        /// 握手信号指示灯
        /// </summary>
        MyProgressBar BarPulse = null;
        
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
        }
              
        private void FormShow_Load(object sender, EventArgs e)
        {
            //更新界面
            UpdateLayOut();
        }

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
            BarPulse = new MyProgressBar();

            ChangeColor(BarPLC, progressBarPLC);
            ChangeColor(BarSQL, progressBarSQL);
            ChangeColor(BarPulse, progressBarPulse);
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

        private void 清屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvMessage.Rows.Clear();
           
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateShowMessage("测试");
            LogHelper.Error("测试");
            LogHelper.Fatal("测试");
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
    }
}
