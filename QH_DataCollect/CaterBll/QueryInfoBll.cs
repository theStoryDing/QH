using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    /// <summary>
    /// 数据查询 逻辑层
    /// </summary>
    public partial class QueryInfoBll
    {
        QueryInfoDal qiDal = new QueryInfoDal();

        public DataTable GetTable(QueryInfo qi)
        {
            return qiDal.GetTable(qi);
        }
    }
}
