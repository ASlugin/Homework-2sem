if (args.Length < 2)
{
    throw new ArgumentException();
}
var pathToInputFile = args[0].ToString();
var pathToOutputFile = args[1].ToString();

if (!Routers.RoutersUtility.GenerateConfiguration(pathToInputFile, pathToOutputFile))
{
    Console.Error.WriteLine("Network was initially not connected");
    Environment.Exit(-1);
}
Console.WriteLine("Configuration was generated successfully");