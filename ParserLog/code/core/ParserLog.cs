using app.format;
namespace app.core;

public class ParserLog : ViewData
{

    public readonly ParserSettings settings = new();

    private string path = "";
    private ParserImport import;
    private ParserOutput output;

    public string txt => output.txt;


    public ParserLog()
    {
        import = new ParserImport(this);
        output = new ParserOutput(this);
    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}

