
namespace app;

public class AppSettings
{

    public string fileFolder {

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

