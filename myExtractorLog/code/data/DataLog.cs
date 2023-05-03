using app.core;

namespace app.data;

public class DataLog : TotalLog
{
    
    private string path;
    private ImportLog import = new();

    public DataLog(string path)
    {
        this.path = path;
    }

    public bool Load(string name) 
    {
        logs = import.Load(path, name);

        return !isNull;
    }

}

