using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public partial class Global
    {
        /// <summary>
        /// 存放PLC信息的表单
        /// </summary>
        public static List<PLCInfo> ListPLCInfo = new List<PLCInfo>();

        /// <summary>
        /// 当PLCIP发生改变时，索引0的数字变为1，索引1存储变更的索引号。
        /// </summary>
        public static int[] PLCIndex = { 0, 0 };

        
    }
}
