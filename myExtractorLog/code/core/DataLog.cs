        
using app.log;

namespace app.core;

public class DataLog
{
    
    private ImportLog import = new();

    public RecordsLog logs
    {
        get { return import.logs; }
    }
    
    public bool Load(string path, string name) 
    {
        return import.Load(path, name);
    } 

}

