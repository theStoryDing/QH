using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 使用者（用户）信息状态
    /// </summary>
    public partial class UserInfo
    {
        //用户等级
        public enum UserLevel
        {
            Operator, // 操作员
            Technician, //工程师
            Administrator // 管理员
        }
 
        /// <summary>
        /// 当前用户等级
        /// </summary>
        public static UserLevel CurrentLevel = UserLevel.Operator;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { set; get; }
    }
}
