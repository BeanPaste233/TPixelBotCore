﻿using Maila.Cocoa.Framework;
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
            src.Send("我在"); // 向来源发送“Hi!”
        }
        [TextRoute("在线")] 
        public static async void Online(MessageSource src)
        {
            StringBuilder serverInfo = new StringBuilder();
            foreach (var server in ConfigUtils.Servers)
            {
                var infoObj = server.GetServerInfo();
                var plrObj = server.GetOnline();
                if (infoObj!=null&&plrObj!=null)
                {
                    serverInfo.AppendLine($"[{infoObj["name"].ToString()}]当前在线({infoObj["count"]}/{infoObj["maxcount"]})");
                    serverInfo.AppendLine($"{plrObj["online"]}");
                    serverInfo.AppendLine($"#f190");
                }
            }
            src.Send(serverInfo.ToString());
        }
    }
}
