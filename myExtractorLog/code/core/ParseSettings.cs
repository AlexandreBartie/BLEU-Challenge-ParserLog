
namespace app.core;

public class ParseSettings : ParseDataSettings
{

    public string GetInputFileFolder(string path)
    {
        if (path == "")
            path = fileFolder;

        return path + "input/";;
    }

    public string GetOutputFileFolder(string path)
    {
        if (path == "")
            path = fileFolder;

        return path + "output/";
    }


}

public class ParseDataSettings
{

    protected string fileFolder {

        get {

            var fileFolder = "";

            #if DEBUG
                fileFolder ="C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/file/";
            #else
                fileFolder = AppDomain.CurrentDomain.BaseDirectory;
            #endif

            return fileFolder;
        }

    }
}

