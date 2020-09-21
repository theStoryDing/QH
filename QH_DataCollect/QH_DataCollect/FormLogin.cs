using CaterBll;
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
    /// 登录界面
    /// </summary>
    public partial class FormLogin : Form
    {
        //声明事件     
        public Action<string> LoginEvent;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.cb_user.SelectedIndex = 0;
            this.txt_password.Text = null;
            this.txt_password.Select();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //获取用户输入的信息
            string name = cb_user.Text.Trim();
            string pwd = txt_password.Text.Trim();

            UserInfoBll uiBll = new UserInfoBll();
            LoginState loginState = uiBll.Login(name, pwd);
            switch(loginState)
            {
                case LoginState.Ok:
                    //将员工级别传递过去
                    UserInfo.CurrentLevel = UserInfo.UserLevel.Technician;
                    LoginEvent.Invoke("工程师");
                    this.Close();
                    break;
                case LoginState.NameError:
                    MessageBox.Show("用户名错误");
                    break;
                case LoginState.PwdError:
                    MessageBox.Show("密码错误");
                    break;
            }

        }

        private void btn_modifyPassword_Click(object sender, EventArgs e)
        {
            using (FormPassword pwd = new FormPassword(cb_user.Text))
            {
                pwd.StartPosition = FormStartPosition.CenterParent;
                pwd.ShowDialog();
            }
        }
    }
}
