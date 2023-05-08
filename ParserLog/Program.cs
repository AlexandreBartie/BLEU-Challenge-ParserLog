﻿using app.core;
namespace app;
class Program
{

    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Please, add a file name as a parameter and !");
            Console.WriteLine("Example: parserlog  run <<your text>>");

            Environment.Exit(-1);
        }

        var app = new StartApp();

#if DEBUG
        app.fileName = "Session-Full.txt"; 
        app.creatureRules = "cyclop*, dragon*";
#else
        app.fileName = arg[0];
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
        show.LootedByCreature = false;
        show.CreatureSpotlight = true;
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




