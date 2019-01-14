using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxBase.Model;

namespace wxBase
{
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public class weixinService
    {
        private static String appidStr = ConfigurationManager.AppSettings["appid"];
        private static String appsecretStr = ConfigurationManager.AppSettings["appsecret"];
        /// <summary>
        /// 用于保存access_token的值
        /// </summary>
        private static String access_token;
        public static DateTime token_validate_time = DateTime.Now.AddDays(-1);
        public static String Access_token
        {
            get
            {
                //过期就再重新获取
                if (token_validate_time<=DateTime.Now)
                {
                    String Url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appidStr + "&secret=" + appsecretStr;
                    access_token = HttpService.Get(Url);
                }
                wxAccessToken token = JSONHepler.JsonToObject<wxAccessToken>(access_token);
                token_validate_time = DateTime.Now.AddSeconds(token.expires_in);
                return token.access_token;

            }
        }
        private static String Token
        {
            get
            {
                return GetAooConfig("token");
            }
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strKey">配置项</param>
        /// <returns></returns>
        public static String GetAooConfig(String strKey)
        {
            foreach (String key in ConfigurationManager.AppSettings)
            {
                if (key==strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }
        /// <summary>
        /// signature是通过token和timestamp和nonce三个参数进行字典序排序,将三个参数拼接一个字符串进行加密
        /// </summary>
        /// <param name="token"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        public static String make_signature(String timestamp,String nonce)
        {
            //字典序排序
            var arr = new[] { Token, timestamp, nonce }.OrderBy(z => z).ToArray();
            //字符串连接
            var arrString = string.Join("", arr);
            //SHA1加密
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var shalArr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder signature = new  StringBuilder();
            foreach (var b in shalArr)
            {
                signature.AppendFormat("{0:x2}", b);
            }
            return signature.ToString();
        }
    }
}
