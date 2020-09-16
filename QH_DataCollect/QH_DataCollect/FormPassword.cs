using System;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormPassword : Form
    {
        string user { set; get; }

        public FormPassword(string name)
        {
            InitializeComponent();
            user = name;
        }

        private void FormPassword_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            string oldPwd = txt_oldPassword.Text.Trim();
            string newPwd = txt_newPassword.Text.Trim();
            string finalPwd = txt_finalPassword.Text.Trim();

            UserInfoBll uiBll = new UserInfoBll();
            //首先确认旧密码是否正确
            LoginState login = uiBll.Login(user, oldPwd);
            if(LoginState.PwdError == login)
            {
                MessageBox.Show("原始密码错误！");
                return;
            }  
            
            if(!newPwd.Equals(finalPwd))
            {
                MessageBox.Show("确认密码和新密码不一致！");
                return;
            }
            //开始修改密码
            UserInfo ui = new UserInfo()
            {
                Name = user,
                Pwd = finalPwd
            };
            
            if(uiBll.AlterPwd(ui))
            {
                MessageBox.Show("密码修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码修改失败，请稍后再试！");
            }
        }
    }
}
