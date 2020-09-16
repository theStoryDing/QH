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
    /// SQLserver数据库帮助类
    /// </summary>
    public partial class SqlServerHelper
    {
        //获取连接字符串
        private static string connStr = string.Format("server = {0};database={1};uid={2};pwd={3};Integrated Security = false; MultipleActiveResultSets=true",
                                         SQLInfo.Server,SQLInfo.DB,SQLInfo.UserID,SQLInfo.Password);

        #region 是否可以连接数据库
        public static bool IsConnectSql()
        {
            using (SqlConnection SqlConn = new SqlConnection(connStr))
            {
                try
                {
                    SqlConn.Open();
                    if (SqlConn.State == ConnectionState.Open) return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("连接SQLserver数据库失败，原因：" + ex.Message);
                }
                return false;
            }
        }
        #endregion

        #region 增删改操作，返回影响行数
        /// <summary>
        /// 知悉insert、update、delete语句，成功返回影响行数，失败回滚
        /// </summary>
        /// <param name="type">执行语句的类型</param>
        /// <param name="sql">执行语句</param>
        /// <param name="ps">参数</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(CommandType type, string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    int num = 0;
                    conn.Open();
                    //添加事务
                    SqlTransaction tran = conn.BeginTransaction();                   
                    try
                    {
                        cmd.CommandType = type;
                        cmd.CommandText = sql;
                        cmd.Transaction = tran;
                        //把参数添加到cmd命令中。
                        cmd.Parameters.AddRange(ps);
                        num = cmd.ExecuteNonQuery();
                        tran.Commit();
                        cmd.Parameters.Clear();
                    }
                    catch(Exception ex)
                    {
                        //异常 回滚
                        tran.Rollback();
                        throw new Exception("sql语句执行失败，原因：" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return num;
                }
            }
        }
        #endregion

        #region 查询 获取首行首列
        /// <summary>
        /// 查询sql,获取首行首列
        /// </summary>
        /// <param name="type">命令类型(存储过程,命令文本, 其它.)</param>
        /// <param name="sql">SQL语句或存储过程名称</param>
        /// <param name="ps">参数</param>
        /// <return>首行首列</returns>
        public static object ExecuteScalar(CommandType type, string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = type;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(ps);
                        return cmd.ExecuteScalar();
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("获取sql首行首列失败，原因：" + ex.Message);
                    }                    
                }
            }
        }
        #endregion

        #region 获取结果集
        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="ps">参数</param>
        /// <returns>结果集</returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    //构造适配器对象
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    //构造数据表，用于接收查询结果
                    DataTable dt = new DataTable();
                    //添加参数
                    adapter.SelectCommand.Parameters.AddRange(ps);
                    //执行结果
                    adapter.Fill(dt);
                    //返回结果集
                    return dt;
                }
                catch(Exception ex)
                {
                    throw new Exception("获取结果集失败，原因" + ex.Message);
                }
                
            }
        }
        #endregion

    }
}
