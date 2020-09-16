using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class UserInfoBll
    {
        //创建数据层对象
        UserInfoDal uiDal = new UserInfoDal();

        //登录
        public LoginState Login(string name, string pwd)
        {
            UserInfo ui = uiDal.GetbyName(name);
            if(null == ui)
            {
                //用户名错误
                return LoginState.NameError;
            }
            if (ui.Pwd.Equals(Md5Helper.EncryptString(pwd)))
            {
                //密码正确
                //登录成功
                return LoginState.Ok;
            }
            else
            {
                //密码错误
                return LoginState.PwdError;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool AlterPwd(UserInfo ui)
        {
            return uiDal.Update(ui) > 0;
        }
    }
}
