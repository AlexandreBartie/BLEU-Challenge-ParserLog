using app.data;
using app.list;

namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) { }

    public DataLogPlayerHealedPower dataPlayerHealedPower
    {
        get
        {

            DataLogPlayerHealedPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }


    }
    public DataLogPlayerLostPower dataPlayerLostPower
    {
        get
        {

            DataLogPlayerLostPower data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;

        }
    }
    public DataLogPlayerLostPowerByCreature dataPlayerLostPowerByCreature
    {

        get
        {

            DataLogPlayerLostPowerByCreature data = new();

            data.points = int.Parse(regex.GetParameter(1));
            data.creature = regex.GetParameter(3);

            return data;
        }
    }

    public DataLogPlayerGainedExperience dataPlayerGainedExperience
    {
        get
        {
            DataLogPlayerGainedExperience data = new();

            data.points = int.Parse(regex.GetParameter(1));

            return data;
        }
    }

    public DataLogPlayerLootedByCreature dataPlayerLootedByCreature
    {
        get
        {

            DataLogPlayerLootedByCreature data = new();

            data.creature = regex.GetParameter(1);
            data.list = new LootList(regex.GetParameter(2));

            return data;
        }
    }

    public DataLogCreatureLostPower dataCreatureLostPower
    {
        get
        {

            DataLogCreatureLostPower data = new();

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