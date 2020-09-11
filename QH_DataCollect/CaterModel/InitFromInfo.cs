using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 界面初始化信息
    /// </summary>
    public partial class InitFormInfo
    {
        public InitFormInfo() { }

        private static string _title;
        private static int _workFlowNums;
        private static string _plc;

        /// <summary>
        /// 标题
        /// </summary>
        public static string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 工作流程数量
        /// </summary>
        public static int WorkFlowNums
        {
            set { _workFlowNums = value; }
            get { return _workFlowNums; }
        }

        /// <summary>
        /// PLC类型
        /// </summary>
        public static string PLC
        {
            set { _plc = value; }
            get { return _plc; }
        }


    }
}
