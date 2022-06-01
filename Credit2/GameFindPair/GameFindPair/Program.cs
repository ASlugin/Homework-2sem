namespace GameFindPair;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length == 1 && int.TryParse(args[0], out int size))
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormGame(size));
        }
    }
}