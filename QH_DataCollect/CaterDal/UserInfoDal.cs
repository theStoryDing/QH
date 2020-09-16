using CaterCommon;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    /// <summary>
    /// 用户信息数据层
    /// </summary>
    public partial class UserInfoDal
    {
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns></returns>
        public UserInfo GetbyName(string name)
        {
            UserInfo ui = null;
            string sql = "select * from T_User Where uid=@name";
            SqlParameter para = new SqlParameter("@name", name);
            DataTable dt = SqlServerHelper.GetDataTable(sql, para);
            if(0 < dt.Rows.Count)
            {
                ui = new UserInfo()
                {
                    Name = name,
                    Pwd = dt.Rows[0][2].ToString()
                };
            }

            return ui;
        }

        public int Update(UserInfo ui)
        {
            List<SqlParameter> listPs = new List<SqlParameter>();
            //构造update的sql语句
            string sql = "update T_User set pwd=@pwd where uid=@name";
            listPs.Add(new SqlParameter("@pwd", Md5Helper.EncryptString(ui.Pwd)));
            listPs.Add(new SqlParameter("@name", ui.Name));

            return SqlServerHelper.ExecuteNonQuery(CommandType.Text, sql, listPs.ToArray());
        }
    }
}
