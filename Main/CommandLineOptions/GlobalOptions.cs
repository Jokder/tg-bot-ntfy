using CommandLine;

namespace Main.CommandLineOptions
{
    public class GlobalOptions
    {
        [Option('c', "config", Required = true,HelpText = "config file location.")]
        public string Config { get; set; }
        
        [Option('m', "message", Required = true,HelpText = "message to send.")]
        public string Message { get; set; }
        
        [Option('b', "debug", Required = false,HelpText = "show debug info.")]
        public bool Debug { get; set; }
    }
}