using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxBase.Model.Menu
{
    /// <summary>
    /// 菜单按钮类
    /// </summary>
    public class wxModelMenuButton
    {
        /// <summary>
        /// 菜单类型
        /// </summary>
        public String type;
        /// <summary>
        /// 菜单按钮名称
        /// </summary>
        public String name;
        /// <summary>
        /// 菜单按钮的关键字
        /// </summary>
        public String key;
        /// <summary>
        /// 当按钮为view的时候,用于定义点击菜单按钮的跳转地址
        /// </summary>
        public String url;
        /// <summary>
        /// 对于官网上设置的自定义菜单,value字段用于保存菜单文本;对于Img和voice类型的菜单,value字段用于保存素材的mediaID;对于Video类型的菜单,value字段用于保存视频的下载链接
        /// </summary>
        public String value;
        public wxModelMenuSubButtons sub_button;
    }
}
