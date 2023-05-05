using app.core;

namespace app.data;

public class DataLog : DataBoard
{

    private string path;
    private ImportLog import;

    public DataLog(string path)
    {
        this.path = path;

        import = new ImportLog(this);
    }

    public bool Load(string name)
    {
        return import.Load(path, name);
    }

}

