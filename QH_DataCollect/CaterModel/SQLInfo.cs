using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 数据库 连接信息
    /// </summary>
    public partial class SQLInfo
    {
        public SQLInfo() { }

        private static string _server;
        private static string _db;
        private static string _userid;
        private static string _password;
        private static bool _isSave;

        /// <summary>
        /// 数据库服务器地址
        /// </summary>
        public static string Server
        {
            set { _server = value; }
            get { return _server; }
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public static string DB
        {
            set { _db = value; }
            get { return _db; }
        }

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public static string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        /// <summary>
        /// 允许存入数据库
        /// </summary>
        public static bool IsSave
        {
            set { _isSave = value; }
            get { return _isSave; }
        }
    }
}
