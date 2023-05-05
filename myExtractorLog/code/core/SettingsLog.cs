
namespace app;

public class AppSettings : AppDataSettings
{

    public string GetFileFolder(string path)
    {
        if (path == "")
            return fileFolder;
        return path;
    }


}

public class AppDataSettings
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

