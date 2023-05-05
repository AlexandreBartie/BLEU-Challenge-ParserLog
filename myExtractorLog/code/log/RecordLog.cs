using app.data;
using app.list;

namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) { }

    public ParseLogPlayerHealedPower dataPlayerHealedPower
    {
        get
        {

            ParseLogPlayerHealedPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }


    }
    public ParseLogPlayerLostPower dataPlayerLostPower
    {
        get
        {

            ParseLogPlayerLostPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }
    }
    public ParseLogPlayerLostPowerByCreature dataPlayerLostPowerByCreature
    {

        get
        {

            ParseLogPlayerLostPowerByCreature data = new();

            data.points = int.Parse(regex.GetParameter(1));
            data.creature = regex.GetParameter(3);

            return data;
        }
    }

    public ParseLogPlayerGainedExperience dataPlayerGainedExperience
    {
        get
        {
            ParseLogPlayerGainedExperience data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;
        }
    }

    public ParseLogPlayerLootedByCreature dataPlayerLootedByCreature
    {
        get
        {

            ParseLogPlayerLootedByCreature data = new();

            data.creature = regex.GetParameter(1);
            data.list = new LootList(regex.GetParameter(2));

            return data;
        }
    }

    public ParseLogCreatureLostPower dataCreatureLostPower
    {
        get
        {

            ParseLogCreatureLostPower data = new();

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