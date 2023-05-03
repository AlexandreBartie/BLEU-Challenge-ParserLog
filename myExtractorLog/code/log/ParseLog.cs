using app.core;
namespace app.log;

public class ParseLog
{

    public SessionsLog Apply(string[] lines)
    {

        var sessions = new SessionsLog();

        RecordLog log;

        foreach (string line in lines)
        {

            log = new RecordLog(line);

            if (log.isHeader)
                sessions.addHeader();
            
            sessions.addRecord(log);

        }

        return sessions;

    }             

}
