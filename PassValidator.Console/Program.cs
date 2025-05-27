using System.CommandLine;
using PassValidator.Console;

var rootCommand = new RootCommand("A minimal console app with command line parsing");

var pathArgument = new Argument<string>("path", "Path to the pkpass file");
rootCommand.AddArgument(pathArgument);

var verboseFlag = new Option<bool>( "--verbose", description: "Enable verbose output");
rootCommand.AddOption(verboseFlag);

rootCommand.SetHandler((path, isVerbose) =>
{
    Environment.ExitCode = ConsoleValidator.ValidatePass(path, isVerbose);
}, pathArgument, verboseFlag);

await rootCommand.InvokeAsync(args);