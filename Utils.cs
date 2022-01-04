using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TPixelBotCore
{
    public static class Utils
    {
        /// <summary>
        /// 获取Url的返回内容 然后转化成Jobject对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static JObject GetHttp(string url)
        {
            var client = new HttpClient();
            return JObject.Parse(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result);
        }
    }
}
