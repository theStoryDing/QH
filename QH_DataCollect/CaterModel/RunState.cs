using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// 运行状态模式
    /// </summary>
    public partial class RunState
    {
        public enum RunMode
        {
            None,
            OnLine,
            Test,
            OffLine

        }

        public static RunMode CurrentRunMode = RunMode.OffLine;
    }
}
