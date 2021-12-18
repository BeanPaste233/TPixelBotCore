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
        public static Config config = new Config("test",123456789);
        public static void LoadConfig() 
        {
            if (File.Exists(configPath))
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));

            }
            else {
                File.WriteAllText(configPath,JsonConvert.SerializeObject(config,Formatting.Indented));
            }
        
        }
    }
} 
