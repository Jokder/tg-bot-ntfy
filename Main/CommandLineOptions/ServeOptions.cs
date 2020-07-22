using CommandLine;

namespace Main.CommandLineOptions
{
    [Verb("serve", HelpText = @"
    serve a simple web api server for notifying.
    call <api-host:port>/bot/notify?key=<key>&to=<accounts>&content=<message> to send message.
    ")]
    public class ServeOptions:GlobalOptions
    {
        
    }
}