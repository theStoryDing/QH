using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using OMRON.Compolet.CIPCompolet64;


namespace CaterCommon
{
    /// <summary>
    /// 欧姆龙PLC
    /// </summary>
    public partial class PLC64Omron
    {
        public NJCompolet NJPLC;
        public PLC64Omron(string PLCAddress, int PortNo, IContainer Container)
        {
            try
            {
                NJPLC = new NJCompolet(Container);
                NJPLC.ConnectionType = OMRON.Compolet.CIPCompolet64.ConnectionType.UCMM;
                NJPLC.LocalPort = PortNo;
                NJPLC.PeerAddress = PLCAddress;
                NJPLC.UseRoutePath = false;
                NJPLC.DontFragment = false;
                NJPLC.ReceiveTimeLimit = ((long)(750));
            }
            catch (Exception )
            { 
              // throw(ex);
            }
        }

        public  bool ConnectionState
        {
            get
            {
                return NJPLC.IsConnected;
            }

            set
            {
                // throw new NotImplementedException();
            }
        }


        public  int Write<T>(int addr, T value, int group)
        {
            throw new NotImplementedException();
        }
        public  int Read<T>(int addr, out T value, int group)
        {
            throw new NotImplementedException();
        }

        // 以变量名方式
        public  int Read<T>(string varname, out T val)
        {
            val = default(T);
            if (varname != null)
            {
                try
                {
                    val = (T)NJPLC.ReadVariable(varname);
                }
                catch (Exception )
                {
                    return 0;
                }
            }
            if (val != null)
                return 1;
            else
                return 0;
        }
        public  int Write<T>(string varname, T val)
        {
            try
            {
                NJPLC.WriteVariable(varname, val);
            }
            catch (Exception )
            {
                return 0;
            }

            if ((object)val == (object)(NJPLC.ReadVariable(varname)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public  bool Connect()
        {
            try
            {
                NJPLC.Active = true;
            }
            catch (Exception )
            {
                NJPLC.Active = false;
            }
            return NJPLC.IsConnected;
        }
        public  void Dispose()
        {
            NJPLC.Dispose();
            // throw new NotImplementedException();
        }

        public bool ActiveConnection()
        {
            try
            {
                NJPLC.Active = true;
            }
            catch (Exception )
            {
               // NJPLC.Active = false;
            }
            return NJPLC.IsConnected;
        }

        public bool ReadTagValue(string TagName, out object TagValue)
        {
            TagValue = null;
            if (TagName != null)
            {
                try
                {
                    TagValue = NJPLC.ReadVariable(TagName);
                }
                catch (Exception )
                {
                    return false;
                }
            }
            if (TagValue != null)
                return true;
            else
                return false;
        }

        public bool ReadMultiTagValue(string[] TagNameList, out object[] TagValueList)
        {
            int Len = TagNameList.Length;
            Hashtable retVals = null;
            TagValueList = new object[Len];
            try
            {
                retVals = NJPLC.ReadVariableMultiple(TagNameList);
            }
            catch (Exception )
            {
                return false;
            }

            if (retVals != null)
            {
                for (int i = 0; i < Len; i++)
                {
                    TagValueList[i] = (object)retVals[TagNameList[i]];
                }
                return true;
            }
            else
                return false;
        }

        public bool WriteTagValue(string TagName, object TagValue)
        {
            try
            {
                NJPLC.WriteVariable(TagName, TagValue);
            }
            catch (Exception )
            {
                return false;
            }

            
            
                return true;
            
        }

        public string GetValueOfVariables(object val)
        {
            string valStr = string.Empty;
            if (val == null)
                return "0";           
            if (val.GetType().IsArray)
            {
                Array valArray = val as Array;
                if (valArray.Rank == 1)
                {
                    valStr += "[";
                    foreach (object a in valArray)
                    {
                        valStr += this.GetValueString(a) + ",";
                    }
                    valStr = valStr.TrimEnd(',');
                    valStr += "]";
                }
                else if (valArray.Rank == 2)
                {
                    for (int i = 0; i <= valArray.GetUpperBound(0); i++)
                    {
                        valStr += "[";
                        for (int j = 0; j <= valArray.GetUpperBound(1); j++)
                        {
                            valStr += this.GetValueString(valArray.GetValue(i, j)) + ",";
                        }
                        valStr = valStr.TrimEnd(',');
                        valStr += "]";
                    }
                }
                else if (valArray.Rank == 3)
                {
                    for (int i = 0; i <= valArray.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= valArray.GetUpperBound(1); j++)
                        {
                            valStr += "[";
                            for (int z = 0; z <= valArray.GetUpperBound(2); z++)
                            {
                                valStr += this.GetValueString(valArray.GetValue(i, j, z)) + ",";
                            }
                            valStr = valStr.TrimEnd(',');
                            valStr += "]";
                        }
                    }
                }
            }
            else
            {
                valStr = this.GetValueString(val);
            }
            return valStr;
        }
        private string GetValueString(object val)
        {
            if (val is float || val is double || val is int)
            {
                return string.Format("{0}", val);
            }
            else
            {
                return val.ToString();
            }
        }
    }
}
