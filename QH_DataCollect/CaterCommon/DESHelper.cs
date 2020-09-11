using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    /// <summary>
    /// DES可逆加密 
    /// </summary>
    public partial class DESHelper
    {
        #region 可逆加密
        //加密向量 8 个字符
        private const string KEY_64 = "@c3sd#eM";
        /// <summary>
        ///DES可逆 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            StringBuilder strRetValue = new StringBuilder();
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(KEY_64.Substring(0, 8));
                byte[] keyIV = keyBytes;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(data);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

                provider.Mode = CipherMode.ECB;//兼容其他语言的Des加密算法  
                provider.Padding = PaddingMode.Zeros;//自动补0

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                //不使用base64编码
                //return Convert.ToBase64String(mStream.ToArray()); 

                //组织成16进制字符串            
                foreach (byte b in mStream.ToArray())
                {
                    strRetValue.AppendFormat("{0:X2}", b);
                }
                return strRetValue.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("加密失败！");
                throw ex;
            }

        }

        /// <summary>
        /// DES可逆 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            string strRetValue = "";

            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(KEY_64.Substring(0, 8));
                byte[] keyIV = keyBytes;

                //不使用base64解码
                //byte[] inputByteArray = Convert.FromBase64String(decryptString);

                //16进制转换为byte字节
                byte[] inputByteArray = new byte[data.Length / 2];
                for (int x = 0; x < data.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(data.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

                provider.Mode = CipherMode.ECB;//兼容其他语言的Des加密算法  
                provider.Padding = PaddingMode.Zeros;//自动补0  

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                //需要去掉结尾的null字符
                //strRetValue = Encoding.UTF8.GetString(mStream.ToArray());
                strRetValue = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd('\0');
                return strRetValue;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
