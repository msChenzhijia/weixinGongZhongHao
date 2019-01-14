using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxBase.Model
{
    public class wxAccessToken
    {
        /// <summary>
        /// 许可令牌
        /// </summary>
        public String access_token;
        /// <summary>
        /// 有效时长(秒)
        /// </summary>
        public int expires_in;
    }
}
