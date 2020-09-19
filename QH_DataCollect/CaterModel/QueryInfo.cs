using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 查询数据信息
    /// </summary>
    public partial class QueryInfo
    {
        private string _tableName;
        private string _code;
        private int _codeType;
        private int _status;
        private DateTime _start;
        private DateTime _end;

        /// <summary>
        /// 存储过程名
        /// </summary>
        public string ProcName
        {
            set { _tableName = value; }
            get { return _tableName; }
        }

        /// <summary>
        /// 条码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }

        /// <summary>
        /// 条码类型 托盘/电池/无 0 =无条码， 1= 托盘，2= 电池条码
        /// </summary>
        public int CodeType
        {
            set { _codeType = value; }
            get { return _codeType; }
        }

        /// <summary>
        /// OK、NG、ALL三种状态 0=NG, 1=OK, 2=ALL
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 查询的起始时间
        /// </summary>
        public DateTime Start
        {
            set { _start = value; }
            get { return _start; }
        }

        /// <summary>
        /// 查询的结束时间
        /// </summary>
        public DateTime End
        {
            set { _end = value; }
            get { return _end; }
        }

    }
}
