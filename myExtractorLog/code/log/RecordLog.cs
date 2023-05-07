namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) { }

    public ILogPlayerPoints dataPlayerGainedExperience => regex.data.GetPlayerPoints();
    public ILogPlayerPoints dataPlayerHealedPower => regex.data.GetPlayerPoints();
    public ILogPlayerPoints dataPlayerLostPower => regex.data.GetPlayerPoints();
    public ILogCreaturePoints dataPlayerLostPowerByCreature => regex.data.GetCreaturePoints(TypeLog.eLogPlayerLostPowerByCreature);
    public ILogPlayerLooted dataPlayerLootedByCreature => regex.data.GetPlayerLooted();
    public ILogCreaturePoints GroupCreatureHealedPower => regex.data.GetCreaturePoints(TypeLog.eLogCreatureHealedPower);
    public ILogCreaturePoints GroupCreatureLostPower => regex.data.GetCreaturePoints(TypeLog.eLogCreatureLostPower);
}

public class RecordsLog : List<RecordLog>
{

    public RecordsLog filter(TypeLog type)
    {

        var logs = new RecordsLog();

        foreach (RecordLog log in this)
        {
            if (log.type == type)
                logs.Add(log);
        }

        return logs;
    }

}