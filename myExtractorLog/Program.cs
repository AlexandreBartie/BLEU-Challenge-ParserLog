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
                fileName = AppDomain.CurrentDomain.BaseDirectory;
            #endif
            
            startApp(fileName);

        }

        private static void startApp(string name)
        {

            var extrator = new ExtratorLog();

            if (extrator.Load(name))
            {
                Console.WriteLine(extrator.log);
            }
            else
                Environment.Exit(-1);
        }

    }

}


