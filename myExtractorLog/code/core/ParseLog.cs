using app.view;

namespace app.core;

public class ParseLog : ViewData
{

    private ParseSettings settings = new();

    private string path;
    private ParseImport import;


    public ParseLog(string path = "")
    {
        this.path = path;

        import = new ParseImport(this);

    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}

