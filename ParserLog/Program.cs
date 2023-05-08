﻿using app.core;
namespace app;
class Program
{

    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Please, add the text as parameter!");
            Console.WriteLine("Example: dotnet run <<your text>>");

            Environment.Exit(-1);
        }

        var app = new StartApp();

        #if DEBUG
            app.fileName = "Session-Full.txt"; 
            app.creatureRules = "cyclop*, dragon*";
        #else
            app.fileName = arg[0];
            app.creatureRules = (args.Length >= 2) ? args[1]  : "";
        #endif

        app.Run();

    }

}

class StartApp
{
    public string fileName = "";
    public string creatureRules = "";
    public void Run()
    {

        var parse = new ParseLog();

        parse.SetSpotlight(creatureRules);

        if (parse.LoadFile(fileName))
        {
            Console.WriteLine(parse.txt);
        }
        else
            Environment.Exit(-1);
    }

}



