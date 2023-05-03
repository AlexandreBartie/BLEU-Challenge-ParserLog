using app.data;
using app.log;
using app.util;

namespace app.core;

public class ExtratorLog
{

    private DataLog data = new();

    public string log => data.log();

    public string output => data.txt();

    public bool Load(string path, string name)
    {
        return data.Load(path, name);
    }

}
