using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPixelBotCore
{
    public class UserInfo
    {
        public long ID { get; set; }
        public string PlayerName { get; set; }
        public bool IsBannedInServer { get; set; }
        public bool IsBannedInGroup { get; set; }
        public UserInfo(long id,string plrName,bool bannedInServer=false,bool bannedInGroup=false)
        {
            ID = id;
            PlayerName = plrName;
            IsBannedInServer = bannedInServer;
            IsBannedInGroup = bannedInGroup;
        }
    }
}
