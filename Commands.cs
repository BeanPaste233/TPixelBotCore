using Maila.Cocoa.Beans.Models.Messages;
using Maila.Cocoa.Framework;
using Maila.Cocoa.Framework.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TPixelBotCore
{
    [BotModule]
    public class Commands : BotModuleBase
    {
        
        [TextRoute("小豆")] // 收到“hello cocoa”时调用此方法
        public static async  void Run(MessageSource src)
        {
            await Task.Delay(3000);
            src.Send("我在");
        }
        [TextRoute("在线")] 
        public static async void Online(MessageSource src)
        {
            if (!ConfigUtils.config.QQGroups.Contains(src.Group.Id))
            {
                return;
            }
            await Task.Delay(3000);
            List<IMessage> message = new List<IMessage>();
            foreach (var server in ConfigUtils.Servers)
            {
                var infoObj = server.GetServerInfo();
                var plrObj = server.GetOnline();
                if (infoObj != null && plrObj != null)
                {
                    message.Add(new FaceMessage(190));
                    message.Add(new PlainMessage($"[{infoObj["name"].ToString()}]当前在线({infoObj["count"]}/{infoObj["maxcount"]})"));
                    message.Add(new FaceMessage(190));
                    message.Add(new PlainMessage("\n"));
                    message.Add(new PlainMessage($"{(plrObj["online"].ToString()==""?"当前无玩家在线": plrObj["online"].ToString())}"));
                    message.Add(new PlainMessage("\n"));
                }
            }
            src.Send(message.ToArray());
        }
        [TextRoute("注册")] 
        public static async void Register(MessageSource src)
        {
            await Task.Delay(3000);
            src.Send("注册尼玛呢？没写好"); 
            
        }
        
    }
}
