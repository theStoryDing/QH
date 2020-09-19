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
    public partial class FormSQL : Form
    {
        public Action ChangeDBEvent;

        public FormSQL()
        {
            InitializeComponent();
        }

        private void FormSQL_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txt_server.Text = SQLInfo.Server;
            txt_dbName.Text = SQLInfo.DB;
            txt_user.Text = SQLInfo.UserID;
            txt_pwd.Text = SQLInfo.Password;

            if (!SQLInfo.IsSave)
            {
                radioButton_close.Checked = true;
            }
            else
            {
                radioButton_open.Checked = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo str = new DirectoryInfo(string.Format(@"{0}..\..\..\config\SQL.xml", Application.StartupPath));
                string path = str.FullName;

                SQLInfo.Server = txt_server.Text;
                SQLInfo.DB = txt_dbName.Text;
                SQLInfo.UserID = txt_user.Text;
                SQLInfo.Password = txt_pwd.Text;
                if (radioButton_close.Checked)
                {
                    SQLInfo.IsSave = false;
                }
                else
                {
                    SQLInfo.IsSave = true;
                }
               
                XMLHelper.WriteNode(path,"server", SQLInfo.Server);
                XMLHelper.WriteNode(path, "sb", SQLInfo.DB);
                XMLHelper.WriteNode(path, "userid", SQLInfo.UserID);
                XMLHelper.WriteNode(path, "password", DESHelper.Encode(SQLInfo.Password));
                XMLHelper.WriteNode(path, "issave", (SQLInfo.IsSave) ? "1" : "0");
                ChangeDBEvent();
                this.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error("数据库参数变更发生异常！", ex);
            }
        }
    }
}
