using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Main.Bot;
using Main.CommandLineOptions;
using Main.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var debug = false;
            if (args == null || !args.Any())
            {
                args = new[] {"cli"};
            }

            debug = args.Any(x => x == "--debug");
            AppConfiguration.Debug = debug;

            AppDomain.CurrentDomain.UnhandledException += (o, eventArgs) =>
            {
                Console.WriteLine(eventArgs.ExceptionObject);
            };

            Parser.Default
                .ParseArguments<ServeOptions, CliOptions>(args)
                .WithParsed<ServeOptions>(options =>
                {
                    AppConfiguration.LoadConfig(options.Config);
                    CreateHostBuilder(args).Build().Run();
                })
                .WithParsed<CliOptions>(options =>
                {
                    AppConfiguration.LoadConfig(options.Config);
                    BotHelper.LaunchBotCommandLine(options);
                })
                .WithNotParsed(errors =>
                {
                    Console.WriteLine("invalid args.");
                    if (debug)
                    {
                        foreach (var error in errors)
                        {
                            Console.WriteLine(error.Tag);
                            Console.WriteLine(error.StopsProcessing);
                        }
                    }
                });
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}