using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class FormMain : Form
    {
        #region GUI
        //界面窗体链表
        public List<FormShow> ListDisplayForm = new List<FormShow>();
        public List<Panel> ListPanelControl = new List<Panel>();
        public List<Label> ListLabelControl = new List<Label>();
        //tab控制分页
        private List<Panel> ListTabPanel = new List<Panel>();
        private List<TabPage> ListTabPage = new List<TabPage>();
        #endregion


        public FormMain()
        {
            InitializeComponent();
            //缓存机制，防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //界面布局
            UpdateLayOut();
        }

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
    
    }
}
