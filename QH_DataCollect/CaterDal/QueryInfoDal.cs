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
    /// 数据查询 数据层
    /// </summary>
    public partial class QueryInfoDal
    {
        public DataTable GetTable(QueryInfo qi)
        {

            SqlParameter[] paras =
            {
                new SqlParameter("@codeType",qi.CodeType),
                new SqlParameter("@status",qi.Status),
                new SqlParameter("@code",qi.Code),
                new SqlParameter("@startTime",qi.Start),
                new SqlParameter("@endTime",qi.End)
            };

            return SqlServerHelper.GetDataTable(CommandType.StoredProcedure, qi.ProcName, paras);

        }
    }
}
