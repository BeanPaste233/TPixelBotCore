using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPixelBotCore
{
    public class Config
    {
        public string VerifyKey { get; set; }
        public long BotAccount { get; set; }
        public int TmodPort { get; set; }
        public Config(string key,int account) {
            VerifyKey = key;
            BotAccount = account;
        }
    }
}
