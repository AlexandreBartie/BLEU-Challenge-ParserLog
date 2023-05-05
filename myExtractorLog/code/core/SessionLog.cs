using app.log;

namespace app.core;

public class SessionLog
{

    public RecordsLog logs = new();

}


public class SessionsLog : List<SessionLog>
{

    private SessionLog? current;

    public RecordsLog logs => getLogs();

    public bool isNull => (logs.Count == 0);

    public void Populate(string[] lines)
    {
        RecordLog log;

        foreach (string line in lines)
        {

            log = new RecordLog(line);

            if (log.isHeader)
                addHeader();
            
            addRecord(log);

        }

    } 

    private void addHeader()
    {
        current = new SessionLog();

        Add(current);
    }

    private void addRecord(RecordLog record)
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