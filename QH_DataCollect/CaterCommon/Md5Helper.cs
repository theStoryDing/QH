using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    /// <summary>
    /// MD5加密帮助类,密码不可逆
    /// </summary>
    public partial class Md5Helper
    {
        public static string EncryptString(string str)
        {
            //utf8,x2
            //00-ff
            //0a
            //创建对象的方法：构造方法，静态方法（工厂）
            MD5 md5 = MD5.Create();
            //将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            //调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            //将加密结果进行转换字符串
            StringBuilder sb=new StringBuilder();
            foreach (byte b in byteNew)
            {
                //将字符转换成16进制表示的字符串，而且是恒占用两从头再来
                sb.Append(b.ToString("x2"));
            }
            //返回加蜜的字符串
            return sb.ToString();
        }
    }
}
