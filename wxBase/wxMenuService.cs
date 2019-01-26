using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxBase
{
    /// <summary>
    /// 微信菜单
    /// </summary>
    public static class wxMenuService
    {
        /// <summary>
        /// 创建微信菜单
        /// </summary>
        /// <param name="menufile"></param>
        /// <returns></returns>
        public static String Create(String menufile)
        {
            String menu_content = File.ReadAllText(menufile, Encoding.GetEncoding("GB2312"));
            String url= "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + weixinService.Access_token;
            String result = HttpService.Post(url, menu_content);
            return result;
        }
        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        /// <returns></returns>
        public static String Get()
        {
            String url = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token=" + weixinService.Access_token;
            String result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public static String delete()
        {
            String url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + weixinService.Access_token;
            String result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 用于获取自定义菜单的配置情况
        /// </summary>
        /// <returns></returns>
        public static String GetConfig()
        {
            String url = "https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token=" + weixinService.Access_token;
            String result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 用于创建自定义菜单
        /// </summary>
        /// <param name="menufile">用于指定保存自定义菜单JSON字符串的txt文件名。</param>
        /// <returns></returns>
        public static String addConditional(String menufile)
        {
            string menu_content = File.ReadAllText(menufile, Encoding.GetEncoding("GB2312"));
            string url = "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token=" + weixinService.Access_token;
            string result = HttpService.Post(url, menu_content);
            return result;
        }
        /// <summary>
        /// 删除个性化菜单
        /// </summary>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public static String deleconditional(String menuid)
        {
            String json="{\"menuid\":\""+menuid+"\"}";
            String url = "http://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token=" + weixinService.Access_token;
            String result = HttpService.Post(url, json);
            return result;
        }
        /// <summary>
        /// 用于测试用户个性化菜单匹配结果
        /// </summary>
        /// <param name="userid">要测试的用户的微信号或者openid</param>
        /// <returns></returns>
        public static String trymatch(string userid)
        {
            String json = "{\"user_id\":\"" + userid + "\"}";
            String url = "https://api.weixin.qq.com/cgi-btn/menu/trymatch?access_token=" + weixinService.Access_token;
            String result = HttpService.Post(url, json);
            return result;
        }
    }

}
