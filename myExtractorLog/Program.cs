using app.core;

namespace app
{
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

            string fileName;

            #if DEBUG
                fileName = "ServerLog-Session-One.txt";
            #else
                fileName = args[0];
            #endif
            
            startApp(fileName);

        }

        private static void startApp(string name)
        {

            var parse = new ParseLog();

            if (parse.LoadFile(name))
            {
                Console.WriteLine(parse.output);
            }
            else
                Environment.Exit(-1);
        }

    }

}


