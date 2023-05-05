using app.view;

namespace app.core;

public class ParseLog : ViewData
{

    private AppSettings settings = new();

    private string path;
    private ImportLog import;

    public ParseLog(string path = "")
    {
        this.path = path;

        import = new ImportLog(this);

    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetFileFolder(path), name);
    }

}

