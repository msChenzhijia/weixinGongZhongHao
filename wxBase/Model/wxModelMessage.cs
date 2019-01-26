using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace wxBase.Model
{
    public class wxModelMessage
    {
        /// <summary>
        /// 消息接收方微信号
        /// </summary>
        public String ToUserName { set; get; }
        /// <summary>
        /// 消息发送方微信号
        /// </summary>
        public String FromUserName { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public String CreateTime { set; get; }
        /// <summary>
        /// 信息类型,地理位置:location,文本消息:text消息类型:image
        /// </summary>
        public String MsgType { set; get; }
        /// <summary>
        /// 信息内容
        /// </summary>
        public String Content { set; get; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public Int32 MsgId { set; get; }
        public void ParseXML(String requestStr)
        {
            if (!String.IsNullOrEmpty(requestStr))
            {
                //封装请求类
                try
                {
                    requestStr = requestStr.Replace("<", "<").Replace(">", ">").Replace("/", "/");
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(requestStr);
                    XmlElement rootElement = xmlDocument.DocumentElement;
                    ToUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
                    #region 将整数时间转换未yyyy-MM-dd格式
                    Int64 bigTime = 0;
                    try
                    {
                        bigTime = Convert.ToInt64(CreateTime) * 10000000;//100毫秒为单位
                    }
                    catch (Exception)
                    {


                    }
                    //1970-01-01 08:00:00是基准时间
                    DateTime dt_1970 = new DateTime(1970, 1, 1, 8, 0, 0);
                    long tircks_1970 = dt_1970.Ticks;//1970年1月1日刻度
                    long time_tricks = tircks_1970 + bigTime;//日志日期刻度
                    DateTime dt = new DateTime(time_tricks);//转化未DateTime
                    CreateTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion   
                    MsgId = Convert.ToInt32(rootElement.SelectSingleNode("MsgId").InnerText);
                    MsgType = rootElement.SelectSingleNode("MsgType").InnerText;
                    switch (MsgType)
                    {
                        case "text":
                            Content = rootElement.SelectSingleNode("Content").InnerText;
                            break;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
