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
    /// <summary>
    /// PLC通讯设置
    /// </summary>
    public partial class FormPLC : Form
    {

        //plc索引号
        private int index;
        //更改PLC地址时间
        public Action ChangePLCIPEvent;

        public FormPLC(int i)
        {
            InitializeComponent();
            index = i;
        }

        private void FormPLC_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            tb_ip.Text = Global.ListPLCInfo[index].IP;
            tb_port.Text = Global.ListPLCInfo[index].Port.ToString();
            tb_ns.Text = Global.ListPLCInfo[index].NS.ToString();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            DirectoryInfo str = new DirectoryInfo(string.Format(@"{0}..\..\..\config\PLC.xml", Application.StartupPath));
            string path = str.FullName;

            Global.ListPLCInfo[index].IP = tb_ip.Text.Trim();
            Global.ListPLCInfo[index].Port = Convert.ToInt32(tb_port.Text);
            Global.ListPLCInfo[index].NS = Convert.ToInt32(tb_ns.Text);

            XMLHelper.WriteNode(path,"Ip" + (index+1).ToString(), "ip", Global.ListPLCInfo[index].IP);
            XMLHelper.WriteNode(path,"Ip" + (index + 1).ToString(), "ip", Global.ListPLCInfo[index].IP);
            XMLHelper.WriteNode(path,"Ip" + (index + 1).ToString(), "ip", Global.ListPLCInfo[index].IP);

            ChangePLCIPEvent();
            this.Close();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
