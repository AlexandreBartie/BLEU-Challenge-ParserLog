using app.view;

namespace app.core;

public class ParseLog : ViewData
{

    private ParseSettings settings = new();

    private string path;
    private ParseImport import;
    private ParseExport export;

    public string output => export.output;


    public ParseLog(string path = "")
    {
        this.path = path;

        import = new ParseImport(this);
        export = new ParseExport(this);

    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}

