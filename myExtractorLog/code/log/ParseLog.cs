using app.core;
namespace app.log;

public class ParseLog
{

    public SessionsLog sessions = new();

    public void Apply(string[] lines)
    {

        RecordLog log;

        foreach (string line in lines)
        {

            log = new RecordLog(line);

            if (log.isHeader)
                sessions.addHeader();
            
            sessions.addRecord(log);

        }

    }             

}
