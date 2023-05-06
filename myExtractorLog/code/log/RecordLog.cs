using app.data;

namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) { }

    public ILogPlayerHealedPower dataPlayerHealedPower
    {
        get
        {

            ILogPlayerHealedPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }


    }
    public ILogPlayerLostPower dataPlayerLostPower
    {
        get
        {

            ILogPlayerLostPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }
    }
    public ILogPlayerLostPowerByCreature dataPlayerLostPowerByCreature
    {

        get
        {

            ILogPlayerLostPowerByCreature data = new();

            data.points = int.Parse(regex.GetParameter(1));
            data.creature = regex.GetParameter(3);

            return data;
        }
    }

    public ILogPlayerGainedExperience dataPlayerGainedExperience
    {
        get
        {
            ILogPlayerGainedExperience data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;
        }
    }

    public ILogPlayerLootedByCreature dataPlayerLootedByCreature
    {
        get
        {

            ILogPlayerLootedByCreature data = new();

            data.creature = regex.GetParameter(1);
            data.list = new DataLootList(regex.GetParameter(2));

            return data;
        }
    }

    public ILogCreatureLostPower dataCreatureLostPower
    {
        get
        {

            ILogCreatureLostPower data = new();

            data.creature = regex.GetParameter(1);
            data.points = int.Parse(regex.GetParameter(2));

            return data;

        }
    }

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