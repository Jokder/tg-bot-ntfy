using CommandLine;

namespace Main.CommandLineOptions
{
    [Verb("cli", HelpText = "run bot with command line interface")]
    public class CliOptions:GlobalOptions
    {
        [Option('o', "to", Required = true,HelpText = @"
        telegram accounts that message will send to.if there are multiple accounts to send to,please separate with ';'.")]
        public string SendTo { get; set; }
    }
}