using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 电池状态信息
    /// </summary>
    public partial class BatteryStatusInfo
    {
        public BatteryStatusInfo()
        { }

        private int _index;
        private string _code;
        private bool _isOK;

        /// <summary>
        /// 电池序号
        /// </summary>
        public int Index
        {
            set { _index = value; }
            get { return _index; }
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
        /// 是否OK
        /// </summary>
        public bool IsOK
        {
            set { _isOK = value; }
            get { return _isOK; }
        }
    }
}
