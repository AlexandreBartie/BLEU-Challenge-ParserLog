using app.core;
using app.total;

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
        SetLogs(import.Load(path, name));

        return !isNull;
    }

}

