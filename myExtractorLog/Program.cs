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

            // string path = AppDomain.CurrentDomain.BaseDirectory; 
            
            string path = "C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/myExtractorLog/code/file/input/";
            string name = "ServerLog-One.txt";

            startApp(path, name);

        }

        private static void startApp(string path, string name)
        {

            var extrator = new ExtratorLog(path);

            if (extrator.Load(name))
            {
                Console.WriteLine("<<< OUTPUT >>>");
                Console.WriteLine(extrator.output);
                Console.WriteLine("<<< LOG >>>");
                Console.WriteLine(extrator.log);
            }
            else
                Environment.Exit(-1);
            

        }

    }

}


