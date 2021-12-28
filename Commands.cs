using Maila.Cocoa.Framework;
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
        private static Socket socket;
        
        [TextRoute("小豆")] // 收到“hello cocoa”时调用此方法
        public static async  void Run(MessageSource src)
        {
            await Task.Delay(3000);
            src.Send("我在"); // 向来源发送“Hi!”
        }
        [TextRoute("在线")] // 收到“hello cocoa”时调用此方法
        public static async void Online(MessageSource src)
        {
            
        }
    }
}
