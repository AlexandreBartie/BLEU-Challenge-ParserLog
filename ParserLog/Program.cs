namespace parser;

class Program
{

    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Please, add a file name as a parameter.");
            Console.WriteLine(" -The file needs to be in the same path of the executable.");
            Console.WriteLine(" -Use a second optional parameter to focus data of creatures!");
            Console.WriteLine("");
            Console.WriteLine("""** Sintaxe: Parserlog {FileName} {Creatures wildcard}""");
            Console.WriteLine("""** Example: Parserlog "Session-Full.txt" *Knight*,cyclops*""");

            Environment.Exit(-1);
        }

        var app = new StartApp();

#if DEBUG
        app.fileName = "Session-Full.txt"; 
        app.creatureRules = "*Knight*";
#else
        app.fileName = args[0];
        app.creatureRules = (args.Length >= 2) ? args[1] : "";
#endif

        app.Run();

    }

}

class StartApp
{
    public string fileName = "";
    public string creatureRules = "";

    public readonly ParserLog parser = new();
    
    public ParserShow show => parser.settings.show;

    public StartApp()
    {
        show.PlayerStatistics = false;
        show.CreatureStatistics = false;
        show.LootedItems = false;
        show.CreatureSpotlight = true; // Extra Challenge
    }

    public void Run()
    {

        parser.SetSpotlight(creatureRules);
      
        if (parser.LoadFile(fileName))
        {
            Console.WriteLine(parser.txt);
        }
        else
            Environment.Exit(-1);
    }

}




