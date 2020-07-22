using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Main.CommandLineOptions;
using Main.Config;
using SocksSharp;
using SocksSharp.Proxy;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Main.Bot
{
    public class BotHelper
    {
        static BotHelper()
        {
            Init();
        }
        private static TelegramBotClient _bot;

        public static void LaunchBotCommandLine(CliOptions options)
        {
            if (string.IsNullOrEmpty(options.SendTo))
            {
                Console.WriteLine("please specify a account for sending to.");
                return;
            }
            var sendToes=options.SendTo.Split(',');
            foreach (var to in sendToes)
            {
                SendMessage(options.SendTo,options.Message);
            }
        }

        private static void Init()
        {
            if (AppConfiguration.UseProxy)
            {
                const string strSocks5 = "socks5";
                const string strHttp = "http";
                if (AppConfiguration.Proxy.Type == strSocks5)
                {
                    var proxyClientHandler = new ProxyClientHandler<Socks5>(new ProxySettings()
                    {
                        Host = AppConfiguration.Proxy.Host,
                        Port = AppConfiguration.Proxy.Port,
                        Credentials = AppConfiguration.Proxy.Auth
                            ? new NetworkCredential(AppConfiguration.Proxy.Username, AppConfiguration.Proxy.Password)
                            : null
                    });
                    var httpClient = new HttpClient(proxyClientHandler);
                    _bot = new TelegramBotClient(AppConfiguration.Bot.Token, httpClient);
                }
                else if (AppConfiguration.Proxy.Type == strHttp)
                {
                    var proxy = new WebProxy(AppConfiguration.Proxy.Host, AppConfiguration.Proxy.Port)
                    {
                        UseDefaultCredentials = true
                    };
                    _bot = new TelegramBotClient(AppConfiguration.Bot.Token, proxy);
                }
                else
                {
                    Console.WriteLine("no suitable proxy setting found,use os default setting.");
                    _bot = new TelegramBotClient(AppConfiguration.Bot.Token);
                }
            }
            else
            {
                _bot = new TelegramBotClient(AppConfiguration.Bot.Token);
            }
        }

        public static void SendMessage(string to, string message)
        {
            try
            {
                Message response;
                if (long.TryParse(to, out var id))
                {
                    response=_bot.SendTextMessageAsync(id, message).Result;
                }
                else
                {
                    response=_bot.SendTextMessageAsync(to, message).Result;
                }

                Console.WriteLine($"send message to {to} success.");
                if (AppConfiguration.Debug)
                {
                    Console.WriteLine(response.Chat.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"send message to {to} failed.");
                if (AppConfiguration.Debug)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}