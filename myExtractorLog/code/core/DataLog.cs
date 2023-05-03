namespace app.core;

public class DataLog : TotalLog
{
    
    private ImportLog import = new();

    public bool Load(string path, string name) 
    {
        logs = import.Load(path, name);

        return !isNull;
    }

}

