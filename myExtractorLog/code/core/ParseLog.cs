using app.format;
namespace app.core;

public class ParseLog : ViewData
{

    private ParseSettings settings = new();

    private string path = "";
    private ParseImport import;
    private ParseOutput output;

    public string txt => output.txt;


    public ParseLog()
    {
        import = new ParseImport(this);
        output = new ParseOutput(this);
    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}

