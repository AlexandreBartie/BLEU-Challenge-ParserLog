using app.log;
using app.util;

namespace app.core;

public class ImportLog
{

    private FileTXT file = new();

    private ParseLog parse = new();

    public RecordsLog Load(string path, string name)
    {
        
        parse = new();

        if (file.Open(path, name))
        {

            return parse.Apply(file.lines).logs;
            
        }

        return new RecordsLog();

    }

}