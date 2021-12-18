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
            await Task.Delay(3000);
            byte[] buffer = new byte[1024*1024*2]; 
            StringBuilder serverinfo = new StringBuilder();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),ConfigUtils.config.TmodPort));
            socket.Send(Encoding.UTF8.GetBytes("getonline"));
            int length = socket.Receive(buffer);
            serverinfo.AppendLine($"当前模组服在线人数:{Encoding.UTF8.GetString(buffer,0,length)}");
            socket.Send(Encoding.UTF8.GetBytes("getnames"));
            length = socket.Receive(buffer);
            serverinfo.AppendLine($"{Encoding.UTF8.GetString(buffer, 0, length)}");
            src.Send(serverinfo.ToString()); // 向来源发送“Hi!”
        }
    }
}
