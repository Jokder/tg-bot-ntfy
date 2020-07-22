using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using IniParser;
using IniParser.Model;

namespace Main.Config
{
    public class AppConfiguration
    {
        public static bool Debug = false;
        private static string _initPath;
        public static DateTime ConfigFileModifyTime { get; set; }

        internal static void LoadConfig(string configPath)
        {
            var iniDataParser = new FileIniDataParser();
            _initPath = Path.Combine(GetAbsPath(configPath));
            ConfigFileModifyTime = File.GetLastWriteTime(configPath);
            var iniConfig = iniDataParser.ReadFile(_initPath);

            //global sections
            UseProxy = iniConfig["global"]["use_proxy"] == "yes";

            //proxy sections
            Proxy.Type = iniConfig["proxy"]["type"];
            Proxy.Host = iniConfig["proxy"]["host"];
            Proxy.Port = int.Parse(iniConfig["proxy"]["port"]);
            Proxy.Auth = iniConfig["proxy"]["auth"] == "yes";
            Proxy.Username = iniConfig["proxy"]["username"];
            Proxy.Password = iniConfig["proxy"]["password"];

            //telegram bot sections
            Bot.Token = iniConfig["bot"]["token"];
            // Bot.SendTo = iniConfig["bot"]["send_to"].Split(',').ToList();

            //web api server sections
            WebApi.Listen = iniConfig["web_api"]["listen"];
            WebApi.Port = iniConfig["web_api"]["port"];
            WebApi.Key = iniConfig["web_api"]["key"];
        }

        private static string GetAbsPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                if (OSInfoUtil.GetOperatingSystem() != OSPlatform.Windows)
                {
                    return Path.Combine("/etc/tgntf/config.ini");
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.ini");
                }
            }

            return path;
        }

        public static bool UseProxy { get; set; }

        public static class Proxy
        {
            public static string Type { get; set; }
            public static string Host { get; set; }
            public static int Port { get; set; }

            public static bool Auth { get; set; }
            public static string Username { get; set; }
            public static string Password { get; set; }
        }

        public static class Bot
        {
            public static string Token { get; set; }
            // public static List<string> SendTo { get; set; }
        }

        public static class WebApi
        {
            public static string Listen { get; set; }
            public static string Port { get; set; }
            public static string Key { get; set; }
        }
    }
}