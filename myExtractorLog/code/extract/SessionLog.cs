using app.log;

namespace app.extract;

public class SessionLog
{

    public RecordsLog logs = new();

}


public class SessionsLog : List<SessionLog>
{

    private SessionLog? current;

    public RecordsLog logs 
    {
        get { return getLogs(); }

    }

    public void addHeader()
    {
        current = new SessionLog();

        Add(current);
    }

    public void addRecord(RecordLog record)
    {
        current?.logs.Add(record);
    }

    private RecordsLog getLogs()
    {
        
        var logs = new RecordsLog();
        foreach (SessionLog session in this)
        {
            logs.AddRange(session.logs);
        }

        return logs;

    }

}