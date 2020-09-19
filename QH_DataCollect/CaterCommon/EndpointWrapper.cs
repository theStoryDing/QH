using Opc.Ua;

namespace CaterCommon
{
    class EndpointWrapper
    {
        #region Construction
        public EndpointWrapper(EndpointDescription endpoint)
        {
            m_endpoint = endpoint;
        }
        #endregion

        #region Fields
        private EndpointDescription m_endpoint;
        #endregion

        #region Properties
        /// <summary>
        /// Provides the session being established with an OPC UA server.
        /// </summary>
        public EndpointDescription Endpoint
        {
            get { return m_endpoint; }
            set { m_endpoint = value; }
        }
        #endregion

        public override string ToString()
        {
            string sRet = m_endpoint.Server.ApplicationName.Text;
            sRet += " [";
            char seperator = '#';
            string[] collection = m_endpoint.SecurityPolicyUri.Split(seperator);
            sRet += collection[1];
            sRet += ", ";
            sRet += m_endpoint.SecurityMode.ToString();
            sRet += "] [";
            sRet += m_endpoint.EndpointUrl;
            sRet += "]";
            return sRet;
        }
    }
}
