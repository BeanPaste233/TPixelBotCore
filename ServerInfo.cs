﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TPixelBotCore
{
    public class ServerInfo
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Token { get; set; }
        public string RestUser { get; set; }
        public string RestPassword { get; set; }
        public ServerInfo(int id,string ip, int port, string token, string userName, string userPwd)
        {
            ID = id;
            IP = ip;
            Port = port;
            Token = token;
            RestUser = userName;
            RestPassword = userPwd;
        }
        public string ConvertToUrl(bool https = false)
        {
            string url = "http://" + IP + ':' + Port.ToString();
            if (https)
            {
                url = "https://" + IP + ':' + Port.ToString();
            }
            return url;
        }
        public JObject GetHttp(string url)
        {
            var client = new HttpClient();
            return JObject.Parse(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result);
        }
        public JObject CreateUser(string userName, string userPwd, string groupName)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl();
                url += $"/v2/users/create?user={userName}&password={userPwd}&group={groupName}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject DeleteUser(string userName)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl();
                url += $"/v2/users/destroy?user={userName}&type=name&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public bool TokenTest()
        {
            string url = ConvertToUrl() + $"/tokentest?token={Token}";
            var response = GetHttp(url);
            return response["status"].ToString() == "200";

        }
        public void CreateToken()
        {
            if (string.IsNullOrEmpty(Token))
            {
                string tokenUrl = ConvertToUrl() + $"/v2/token/create?username={RestUser}&password={RestPassword}";
                var getToken = GetHttp(tokenUrl);
                Token = getToken["token"].ToString();
            }
        }
        public JObject GetOnline() 
        {
            if (TokenTest())
            {
                string onlineUrl = ConvertToUrl() + $"/tpixel/online?token={Token}";
                return GetHttp(onlineUrl);
            }
            return null;
        }
        public JObject GetServerInfo() 
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/tpixel/serverinfo?token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject AddBwl(string plrName) 
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/bwl/add?player={plrName}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject DelBwl(string plrName) 
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/bwl/del?player={plrName}&token={Token}";
                return GetHttp(url);
            }
            return null;

        }
        public JObject AddBan(string ip,string name,string reason) 
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/bans/create?ip={ip}&name={name}&reason={reason}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject DelBan(string name)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/tpixel/delban?player={name}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject ListBans()
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/bans/list?token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject ReadBans(string name)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/bans/read?ban={name}&type=name&caseinsensitive=true&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject Broadcast(string msg)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/server/broadcast?msg={msg}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject Motd()
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v3/server/motd?token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject Off(string msg)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/server/off?confirm=true&message={msg}&nosave=false&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject RawCommand(string cmd)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v3/server/rawcmd?cmd={cmd}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject Reload()
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v3/server/reload?token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject ListUsers()
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/users/list?token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject ReadUser(string name)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/users/read?user={name}&type=name&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
        public JObject UpdateUser(string name,string pwd,string group)
        {
            if (TokenTest())
            {
                string url = ConvertToUrl() + $"/v2/users/update?user={name}&type=name&password={pwd}&group={group}&token={Token}";
                return GetHttp(url);
            }
            return null;
        }
    }
}
