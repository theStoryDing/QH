using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CaterCommon
{
    /// <summary>
    /// 读写xml文件（xmlDocument) 帮助类
    /// </summary>
     public partial class XMLHelper
     {
 
        public XMLHelper()
        {
            
        }


        #region 根据路径找到文件是否存在
        /// <summary>
        /// 根据路径找到文件是否存在
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>存在返回true，否则false</returns>
        public static bool IsExists(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;

            return File.Exists(path) ? true : false;
        }
        #endregion

        #region 读取节点的属性值
        /// <summary>
        /// 读取节点的属性值
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="AttributeName">属性名</param>
        /// <returns></returns>
        public static string ReadNode(string path, string nodeName, string attributeName)
        {
            try
            {
                if (!IsExists(path)) return null;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(path);
                XmlElement _root = _doc.DocumentElement;
                XmlNode xmlNode = _root.SelectSingleNode(nodeName);

                if (null == xmlNode || null == xmlNode.Attributes[attributeName]) return null;

                return xmlNode.Attributes[attributeName].Value;

            }
            catch (Exception ex)
            {
                throw new Exception("读取节点失败：" + ex.Message);
            }

        }
        #endregion

        #region 读取节点文本
        public static string ReadNode(string path, string nodeName)
        {
            try
            {
                if (!IsExists(path)) return null;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(path);
                XmlElement _root = _doc.DocumentElement;
                XmlNode xmlNode = _root.SelectSingleNode(nodeName);

                if (null == xmlNode) return null;

                return xmlNode.InnerXml;

            }
            catch (Exception ex)
            {
                throw new Exception("读取节点失败：" + ex.Message);
            }
        }
        #endregion

        #region 写入节点文本
        /// <summary>
        /// 写入节点文本，如果该节点不存在则创建
        /// </summary>
        /// <param name="path">xml文档路径</param>
        /// <param name="nodeName">节点名</param>
        /// <param name="value">写入值</param>
        public static void WriteNode(string path, string nodeName, Object value)
        {
            try
            {
                if (!IsExists(path)) return;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(path);
                XmlElement _root = _doc.DocumentElement;
                XmlNode xmlNode = _root.SelectSingleNode(nodeName);

                if (null == xmlNode)
                {
                    var _element = _doc.CreateElement(nodeName);
                    _element.InnerXml = value.ToString();
                    _root.AppendChild(_element);
                }
                else
                {
                    xmlNode.InnerXml = value.ToString();
                }
                _doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception("写入节点失败：" + ex.Message);
            }
        }
        

        //存在子节点
        public static void WriteNode(string path, string node, string nodeSon, object value)
        {
            try
            {
                if (!IsExists(path)) return;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(path);
                XmlElement _root = _doc.DocumentElement;
                XmlNode xmlNode = _root.SelectSingleNode(node);

                if (null == xmlNode)
                {
                    //不存在则创建
                    var _element = _doc.CreateElement(node);
                    _root.AppendChild(_element);
                    var _elementSon = _doc.CreateElement(nodeSon);
                    _elementSon.InnerXml = value.ToString();
                    _element.AppendChild(_elementSon);
                }
                else
                {
                    //读取子节点
                    var _nodeSon = xmlNode.SelectSingleNode(nodeSon);
                    if (null == _nodeSon)
                    {
                        var _element = _doc.CreateElement(nodeSon);
                        _element.InnerXml = value.ToString();
                        xmlNode.AppendChild(_element);
                    }
                    else
                    {
                        _nodeSon.InnerXml = value.ToString();
                    }
                }
                _doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception("写入节点失败：" + ex.Message);
            }
        }
        #endregion

        #region 更该节点属性
        public static void WriteNodeAttribute(string path, string nodeName, string attributeName, object value)
        {
            try
            {
                if (!IsExists(path)) return;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(path);
                XmlElement _root = _doc.DocumentElement;
                XmlNode xmlNode = _root.SelectSingleNode(nodeName);

                if (null == xmlNode)
                {
                    //创建节点
                    var _element = _doc.CreateElement(nodeName);
                    _element.InnerXml = value.ToString();
                    _root.AppendChild(_element);
                }

                if(null == xmlNode.Attributes[attributeName])
                {
                    XmlElement _node = (XmlElement)xmlNode;
                    _node.SetAttribute(attributeName, value.ToString());

                }
                else
                {
                    xmlNode.Attributes[attributeName].Value = value.ToString();
                }

                _doc.Save(path);
            }
            catch (Exception ex)
            {
                throw new Exception("写入节点属性失败：" + ex.Message);
            }
        }
        #endregion

    }
}
