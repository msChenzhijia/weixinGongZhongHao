using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace wxBase
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    public class JSONHepler
    {
        /// <summary>
        /// 将对象转换为JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ObjectToJson(object obj)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            try
            {
                return javaScriptSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {

                throw new Exception("JSONHepler.ObjectToJson():" + ex.Message);

            }
        }
        /// <summary>
        /// 将数据表对象转换为键值对集合
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<String,Object>>DataTableToList(DataTable dt)
        {
            List<Dictionary<String, Object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<String, Object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static String DataTableToJson(DataTable dt)
        {
            return ObjectToJson(DataTableToList(dt));
        }
        public static T JsonToObject<T>(String jsonText)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            try
            {
                return javaScriptSerializer.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {

                throw new Exception("JSONHelper.JsonToObject():" + ex.Message);
                return default(T);
            }
        }
    }
}
