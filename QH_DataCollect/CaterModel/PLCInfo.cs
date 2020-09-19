using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// PLC 信息 地址、端口等
    /// </summary>
    public partial class PLCInfo
    {
        public PLCInfo() { }

        private string _deviceName;
        private string _ip;
        private int _port;
        private int _ns;

        /// <summary>
        /// 设备名
        /// </summary>
        public string Device
        {
            set { _deviceName = value;}
            get { return _deviceName; }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port
        {
            set { _port = value; }
            get { return _port; }
        }

        /// <summary>
        /// 协议NS
        /// </summary>
        public int NS
        {
            set { _ns = value; }
            get { return _ns; }
        }
    }
}
