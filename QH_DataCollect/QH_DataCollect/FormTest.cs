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
    /// <summary>
    /// PLC读写测试
    /// </summary>
    public partial class FormTest : Form
    {
        PLC64Omron Omron;
        Class_Siemens OpcUa;

        public FormTest(PLC64Omron omron, int plcIndex)
        {
            InitializeComponent();
            Omron = omron;
            this.Text = "PLC " + (plcIndex + 1) + "读写测试";
        }

        public FormTest(Class_Siemens opcua, int plcIndex)
        {
            InitializeComponent();
            OpcUa = opcua;
            this.Text = "PLC " + (plcIndex + 1) + "读写测试";
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void Btn_read_Click(object sender, EventArgs e)
        {
            switch (InitFormInfo.PLC)
            {
                case "Omron":
                    ReadOmron();
                    break;
                case "Siemens":
                    ReadOpcUa();
                    break;
            }
        }

        private void ReadOpcUa()
        {
            string value = null;
            try
            {
                if (OpcUa.IsConnected)
                {

                    var result = OpcUa.PLC_ReadValues(txt_node.Text.Trim());
                    lbl_result.Text = "结果：" + value;
                    return;
                }
                lbl_result.Text = "结果：连接断开";
            }
            catch (Exception ex)
            {
                lbl_result.Text = "结果：读取异常！原因：" + ex.Message;
            }
            
        }

        private void ReadOmron()
        {
            try
            {
                if (Omron.ConnectionState)
                {
                    object value;
                    Omron.ReadTagValue(txt_node.Text, out value);
                    lbl_result.Text = "结果：" + value.ToString();
                    return;
                }
                lbl_result.Text = "结果：连接断开";
            }
            catch (Exception ex)
            {
                lbl_result.Text = "结果：读取异常！原因：" + ex.Message;
            }
            
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            switch (InitFormInfo.PLC)
            {
                case "Omron":
                    WriteOmron();
                    break;
                case "Siemens":
                    WriteOpcUa();
                    break;
            }
        }

        private void WriteOmron()
        {
            try
            {
                if (Omron.ConnectionState)
                {
                    if (Omron.WriteTagValue(txt_node.Text, txt_value.Text))
                    {
                        lbl_result.Text = "结果：写入成功！";
                        return;
                    }
                }
                lbl_result.Text = "结果：连接断开";
            }
            catch (Exception ex)
            {
                lbl_result.Text = "结果：写入异常！原因：" + ex.Message;
            }
            
        }

        private void WriteOpcUa()
        {
            try
            {
                if (OpcUa.IsConnected)
                {
                    if (OpcUa.PLC_WriteValues(txt_value.Text.Trim(), txt_node.Text.Trim()))
                    {
                        lbl_result.Text = "结果：写入成功";
                        return;
                    }
                }
                lbl_result.Text = "结果：连接断开";
            }
            catch (Exception ex)
            {
                lbl_result.Text = "结果：写入异常！原因：" + ex.Message;
            }
            
        }
    }
}
