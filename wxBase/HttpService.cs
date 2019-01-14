using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wxBase
{
    /// <summary>
    /// 请求方式类
    /// </summary>
    public class HttpService
    {
        /// <summary>
        /// 实现以GET方式提交数据的功能
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public  static String Get(String uri)
        {
            String strLine = "", data = "";
            using (WebClient wc=new WebClient())
            {
                try
                {
                    using (Stream stream = wc.OpenRead(uri))
                    {
                        using (StreamReader sr=new StreamReader(stream))
                        {
                            while ((strLine=sr.ReadLine())!=null)
                            {
                                data += strLine;
                            }
                            sr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
                wc.Dispose();
            }
            return data;
        }
        /// <summary>
        /// 实现以POST方式提交数据的功能
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="PostData"></param>
        /// <returns></returns>
        public static String Post(String uri,String PostData)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(PostData);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            webRequest.Method = "post";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newstream = webRequest.GetRequestStream();
            newstream.Write(byteArray, 0, byteArray.Length);
            newstream.Close();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            String data = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            return data;
        }
    }
}
