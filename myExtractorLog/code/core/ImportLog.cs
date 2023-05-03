using app.log;
using app.util;

namespace app.core;

public class ImportLog
{

    private FileTXT file = new();

    private ParseLog parse = new();

    public RecordsLog logs => parse.sessions.logs;

    public bool Load(string path, string name)
    {
        
        parse = new();

        if (file.Open(path, name))
        {

            parse.Apply(file.lines);
            
            return true;

        }

        return false;

    }

}