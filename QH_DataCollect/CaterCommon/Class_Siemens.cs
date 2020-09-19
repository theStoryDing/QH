using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Opc.Ua;

namespace CaterCommon
{
    public class Class_Siemens
    {
        /// <summary>
        /// Provides access to the OPC UA server and its services. 
        /// </summary>
        private UAClientHelperAPI m_Server = null;
        /// <summary>
        /// Indicates the connect state.
        /// </summary>
        private bool m_Connected = false;

        public bool IsConnected { get { return m_Connected; } }

        Uri discoveryUrl;
        int Ns;
        public Class_Siemens(string ip, int port, int ns)
        {
            try
            {
                discoveryUrl = null;
                Ns = ns;
                if (string.IsNullOrEmpty(ip))
                {
                    discoveryUrl = new Uri("opc.tcp://localhost:4840");
                    // Create client API server object
                    m_Server = new UAClientHelperAPI();
                    // Attach to certificate event
                    m_Server.CertificateValidationNotification += new CertificateValidationEventHandler(m_Server_CertificateEvent);
                }
                else
                {
                    // Create client API server object
                    m_Server = new UAClientHelperAPI();
                    // Attach to certificate event
                    m_Server.CertificateValidationNotification += new CertificateValidationEventHandler(m_Server_CertificateEvent);
                    //string sUrl = string.Format("opc.tcp://{0}:{1}", ip, port.ToString());
                    string sUrl = string.Format("opc.tcp://{0}:{1}", ip, port.ToString());
                    discoveryUrl = new Uri(sUrl);
                }
            }
            catch
            {

            }
        }
        #region Event Handler
        void m_Server_CertificateEvent(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // Ask user if he wants to trust the certificate
            DialogResult result = MessageBox.Show(
                "Do you want to accept the untrusted server certificate: \n" +
                "\nSubject Name: " + e.Certificate.SubjectName.Name +
                "\nIssuer Name: " + e.Certificate.IssuerName.Name,
                "Untrusted Server Certificate",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // If the certificate is stored in the trust list, the user is not asked again
                e.Accept = true;
            }
            else
            {
                e.Accept = false;
            }
        }
        #endregion
        public int Connect()
        {
            try
            {
                List<object> Listtmp = new List<object>();
                ApplicationDescriptionCollection servers = null;
                servers = m_Server.FindServers(discoveryUrl.ToString());
                //for (int i = 0; i < servers.Count; i++)
                //{

                //    // Create discovery client and get the available endpoints.
                EndpointDescriptionCollection endpoints = null;
                //    string sUrl;
                //    sUrl = servers[i].DiscoveryUrls[0];
                //    discoveryUrl = new Uri(sUrl);
                endpoints = m_Server.GetEndpoints(discoveryUrl.ToString());
                // Create wrapper and fill the combobox.

                for (int j = 0; j < endpoints.Count; j++)
                {
                    // Create endpoint wrapper.
                    EndpointWrapper wrapper = new EndpointWrapper(endpoints[j]);
                    Listtmp.Add(wrapper);
                    // Add it to the combobox.
                    // UrlCB.Items.Add(wrapper);
                }
                if (Listtmp != null)
                {

                    // Call connect with URL
                    //m_Server.Connect(Listtmp[0].ToString(), "none", MessageSecurityMode.None, false, "", "");
                    m_Server.Connect(((EndpointWrapper)Listtmp[0]).Endpoint, false, "", "");
                }
                else
                {
                    m_Connected = false;
                    return -1;
                }
                //}
                //servers[i].ApplicationName;
                m_Connected = true;
                return 0;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                if (m_Connected)
                {
                    // Disconnect from server.
                    Disconnect();
                }
                m_Connected = false;
                return -1;

            }
        }
        public int Disconnect()
        {

            try
            {
                m_Server.Disconnect();
                m_Connected = false;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        //ns=3;s="数据块_1"."bbb"
        /// <summary>
        /// 读取多个变量
        /// </summary>
        /// <param name="Nodes">读取的地址,格式为：块名.变量名</param>
        /// <returns></returns>
        public List<string> PLC_ReadValues(List<string> Nodes)
        {
            if (m_Connected)
            {
                int i = 0;
                foreach (string str in Nodes)
                {
                    Nodes[i] = _GetFormat(str);
                    i++;
                }
                return m_Server.ReadValues(Nodes);
            }
            else
                return null;

        }
        /// <summary>
        /// 读取单个变量
        /// </summary>
        /// <param name="Node">读取的地址,格式为：块名.变量名</param>
        /// <returns></returns>
        public string PLC_ReadValues(string Node)
        {
            if (m_Connected)
                return m_Server.ReadValues(new List<string>(new string[] { _GetFormat(Node) }))[0];
            else
                return null;
        }
        /// <summary>
        /// 写入多个变量
        /// </summary>
        /// <param name="values">写入的值</param>
        /// <param name="nodeid">写入的地址,格式为：块名.变量名</param>
        public void PLC_WriteValues(List<string> values, List<string> nodeid)
        {
            if (m_Connected)
            {
                int i = 0;
                foreach (string str in nodeid)
                {
                    nodeid[i] = _GetFormat(str);
                    i++;
                }
                m_Server.WriteValues(values, nodeid);
            }

        }
        /// <summary>
        /// 写入单个变量信息
        /// </summary>
        /// <param name="values">写入的值</param>
        /// <param name="nodeid">写入的地址,格式为：块名.变量名</param>
        public bool PLC_WriteValues(string values, string nodeid)
        {
            try
            {
                m_Server.WriteValues(new List<string>(new string[] { values }), new List<string>(new string[] { _GetFormat(nodeid) }));
            }
            catch (Exception ex)
            {
                return false; ;
            }
            return true;
        }


        /// <summary>
        /// 转换成OPCUA支持的读写格式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string _GetFormat(string data)
        {
            if (data.Contains('.'))
            {
                return SwitchFormat(data.Split(new char[] { '.' }));
            }
            else if (data.Contains("/"))
            {
                return SwitchFormat(data.Split(new char[] { '/' }));
            }
            else
            {
                return string.Format("ns={0};s=t|{1}", Ns, data);
            }
        }

        private string SwitchFormat(string[] value)
        {
            StringBuilder sb = new StringBuilder();
            string _str = null;
            if (2 == Ns)
            {

                foreach (string temp in value)
                {
                    sb.Append(string.Format("/{0}", temp));
                }
                sb.Remove(0, 1);
                _str = string.Format("ns={0};s={1}", Ns, sb);
            }
            else if (3 == Ns)
            {

                foreach (string temp in value)
                {
                    if (temp.Contains("["))
                    {
                        string[] test = temp.Split(new char[] { '[', ']' }, StringSplitOptions.None);
                        sb.Append(string.Format(".\"{0}\"[{1}]", test[0], test[1]));
                    }
                    else
                    {
                        sb.Append(string.Format(".\"{0}\"", temp));
                    }
                }
                sb.Remove(0, 1);
                _str = string.Format("ns={0};s={1}", Ns, sb);
            }
            else
            {
                foreach (string temp in value)
                {
                    if (temp.Contains("["))
                    {
                        string[] test = temp.Split(new char[] { '[', ']' }, StringSplitOptions.None);
                        sb.Append(string.Format(".{0}[{1}]", test[0], test[1]));
                    }
                    else
                    {
                        sb.Append(string.Format(".{0}", temp));
                    }
                }
                sb.Remove(0, 1);
                _str = string.Format("ns={0};s=t|{1}", Ns, sb);
            }


            return _str;
        }

        #region no use
        /*
        public uint GetNamespaceIndex(String uri)
        {
            return m_Server.GetNamespaceIndex(uri);
        }
        public string GetNamespaceUri(uint index)
        {
            return m_Server.GetNamespaceUri(index);
        }

        public List<String> GetNamespaceArray()
        {
            return m_Server.GetNamespaceArray();
        }
        public ReferenceDescriptionCollection BrowseRoot()
        {
            return m_Server.BrowseRoot();
        }
        public ReferenceDescriptionCollection BrowseNode(ReferenceDescription refDesc)
        {
            return m_Server.BrowseNode(refDesc);
        }
        public ReferenceDescriptionCollection BrowseNodeByReferenceType(ReferenceDescription refDesc, NodeId refTypeId)
        {
            return m_Server.BrowseNodeByReferenceType( refDesc,  refTypeId);
        }
        public Subscription Subscribe(int publishingInterval)
        {
            return m_Server.Subscribe(publishingInterval);
        }
        */
        #endregion

    }
}
