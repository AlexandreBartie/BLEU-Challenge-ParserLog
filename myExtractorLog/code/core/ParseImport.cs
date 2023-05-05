using app.util;

namespace app.core;

public class ParseImport
{

    private ParseLog parse;

    public ParseImport(ParseLog parse)
    {
        this.parse = parse;
    }

    public bool Load(string path, string name)
    {

        var file = new FileTXT();

        if (file.Open(path, name))
        {
            parse.Populate(file.lines);

            return true;
        }

        return false;

    }



}