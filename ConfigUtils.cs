using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TPixelBotCore
{
    public static class ConfigUtils
    {
        public static string configPath = Environment.CurrentDirectory + "/config.json";
        public static string serversPath = Environment.CurrentDirectory + "/servers.json";
        public static Config config = new Config("test",123456789);
        public static List<ServerInfo> Servers = new List<ServerInfo>();
        public static void LoadConfig() 
        {
            if (File.Exists(configPath))
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
            else 
                File.WriteAllText(configPath,JsonConvert.SerializeObject(config,Formatting.Indented));
            if (File.Exists(serversPath))
                Servers = JsonConvert.DeserializeObject<List<ServerInfo>>(File.ReadAllText(serversPath));
            else
                Servers.Add(new ServerInfo(Servers.Count+1,"127.0.0.1",7878,"114514","114514","114514"));
                File.WriteAllText(serversPath, JsonConvert.SerializeObject(Servers, Formatting.Indented));
        }
    }
} 
