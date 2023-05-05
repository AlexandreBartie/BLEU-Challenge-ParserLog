using app.data;
using app.util;

namespace app.core;

public class ImportLog
{

    private DataLog data;

    public ImportLog(DataLog data)
    {
        this.data = data;
    }

    public bool Load(string path, string name)
    {
        
        var file = new FileTXT();

        if (file.Open(path, name))
        {
            data.Populate(file.lines);

            return true;            
        }

        return false;

    }

  

}