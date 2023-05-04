using app.data;

namespace app.core;

public class ExtratorLog
{

    private DataLog data;

    public string log => data.log();

    public string output => data.txt();

    public ExtratorLog(string path)
    {
        data = new DataLog(path);
    }

    public bool Load(string name)
    {
        return data.Load(name);
    }

}
