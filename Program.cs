using System;
using System.Reflection;
using Maila.Cocoa.Beans.Models.Messages;
using Maila.Cocoa.Framework;
using Maila.Cocoa.Framework.Support;
using TPixelBotCore;
ConfigUtils.LoadConfig();
BotStartupConfig config = new(ConfigUtils.config.VerifyKey, ConfigUtils.config.BotAccount); // 启动配置，请将 YourVerifyKey 改为您的 VerifyKey，12345678 改为机器人的 QQ 号
var succeed = await BotStartup.Connect(config); // 连接 Mirai 并初始化
//AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
BotAPI.OnMemberJoin = e => 
{
    if (ConfigUtils.config.QQGroups.Contains(e.Member.Group.Id))
    {
        UserInfo user = new UserInfo(e.Member.Id,"");
        if (!ConfigUtils.Users.Contains(user))
        {
            ConfigUtils.Users.Add(user);
            BotAPI.SendGroupMessage(e.Member.Group.Id,new PlainMessage($"[{e.Member.MemberName}][{e.Member.Id}]游戏档案成功"));
        }
    }
};
if (succeed) // 如果连接成功
{
    Console.WriteLine("Startup OK"); // 提示连接成功
    
    while (Console.ReadLine() != "exit") ; // 在用户往控制台输入“exit”前持续运行
    await BotStartup.Disconnect(); // 断开连接
    
}
else // 否则
{
    Console.WriteLine("Failed"); // 提示连接失败
}
Console.ReadKey(); 
