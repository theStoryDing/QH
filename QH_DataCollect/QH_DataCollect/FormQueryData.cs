using CaterBll;
using CaterCommon;
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
    public partial class FormQueryData : Form
    {
        QueryInfoBll qiBll = new QueryInfoBll();

        public FormQueryData()
        {
            InitializeComponent();
        }

        private void FormQueryData_Load(object sender, EventArgs e)
        {
            InitControl();
            SetDGVStyle(dgvTable);
            //SetCommonTable(ref dgvTable);
        }

        #region 设置DataGridView控件
        private void SetDGVStyle(DataGridView dgv)
        {
            // 列头系统样式，设置为false，自定义才生效
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersWidth = 50;//行标题宽度固定
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//列标题居中显示
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//单元格内容居中显示
            // 网格线颜色
            dgv.GridColor = Color.Gray;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;//奇数行背景色
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //表格铺满
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;//单击选择单元格
            dgv.AllowUserToAddRows = false;//不启用添加 
            dgv.ReadOnly = true;//只读
            dgv.AllowUserToDeleteRows = false;//不启用删除
            //选中时颜色
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Orange;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;


        }
        #endregion


        #region 初始化控件
        private void InitControl()
        {
            dtpStartTime.Value = DateTime.Now.AddYears(-2);
            dtpEndTime.Value = DateTime.Now.AddDays(1);

            cbDevice.SelectedIndex = 1;
            cbType.SelectedIndex = 0;
            cbOK.SelectedIndex = 0;

        }
        #endregion

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            
            //获取存储过程名
            string procName = GetProcName(cbDevice.Text.Trim());
            //获取条码有或无以及条码类型
            string code;
            int type;
            if(string.IsNullOrEmpty(txtBoxCode.Text.Trim()))
            {
                type = 0;
            }
            else
            {
                type = ("托盘码" == cbType.Text) ? 1 : 2;
            }
            code = txtBoxCode.Text.Trim();
            int status;
            switch(cbOK.Text)
            {
                case "OK":
                    status = 1;
                    break;
                case "NG":
                    status = 0;
                    break;
                default:
                    status = 2;
                    break;
            }

            //起始时间不能超过结束时间
            if(dtpStartTime.Value >= dtpEndTime.Value)
            {
                MessageBox.Show("起始时间应小于结束时间!");
                return;
            }

            QueryInfo qi = new QueryInfo()
            {
                ProcName = procName,
                CodeType = type,
                Status = status,
                Code = code,
                Start = dtpStartTime.Value,
                End = dtpEndTime.Value
            };
            //查询数据
            try
            {
                dgvTable.DataSource = null;
                DataTable table = qiBll.GetTable(qi);
                dgvTable.DataSource = table;
                tsslDataNum.Text = string.Format("共 {0} 条数据", dgvTable.RowCount);
                for (int i = 0; i < dgvTable.Columns.Count; i++)
                {
                    //将表格中的时间相关列显示完整
                    if(dgvTable.Columns[i].Name.Contains("Time") || dgvTable.Columns[i].Name.Contains("time"))
                    {
                        dgvTable.Columns[i].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.ff";
                    }
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("找不到【{0}】的数据！，原因：{1}",cbDevice.Text,ex.Message));
            }
            
        }

        #region 根据设备名获取存储过程名
        private string GetProcName(string name)
        {
            switch(name)
            {
                case "组盘机":
                    return "proc_AssemblingSelect";
                default:
                    return null;
                    
            }
        }
        #endregion

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //导出数据到excel表格
            Out2Excel();
        }

        private void Out2Excel()
        {
            //判断表格是否有数据
            if (0 >= dgvTable.RowCount) return;
            //保存路径
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string title = cbDevice.Text;
            new Task(() =>
            {
                try
                {
                    if (ExportExcel.ExportDataToExcel(dgvTable, title,path))
                    {
                        MessageBox.Show("导出成功");
                    }

                }
                catch (Exception ex)
                { 
                    //ErrorLogCount++;
                    MessageBox.Show("导出失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }).Start();


        }
    }
}
