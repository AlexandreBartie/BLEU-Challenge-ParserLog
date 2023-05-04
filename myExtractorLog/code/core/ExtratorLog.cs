using app.data;

namespace app.core;

public class ExtratorLog
{

    private DataLog data;

    private AppSettings settings = new();

    public string log => data.log();

    public ExtratorLog()
    {
        data = new DataLog(settings.fileFolder);
    }

    public bool Load(string name)
    {
        return data.Load(name);
    }

}
