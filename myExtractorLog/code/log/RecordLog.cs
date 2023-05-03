using app.data;
using app.extra;

namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogGameSession;

    public RecordLog(string info) : base(info) {}

    public DataPlayerHealedPower GetPlayerHealedPower()
    {
        
        DataPlayerHealedPower data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data; 
    }
    public DataPlayerLostPower GetPlayerLostPower()
    {
        DataPlayerLostPower data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data;  
    }
    public DataPlayerLostPowerByCreature GetPlayerLostPowerByCreature()
    {
        DataPlayerLostPowerByCreature data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        data.creature = regex.GetParameter(3);
        
        return data;  
    }

    public DataPlayerGainedExperience GetPlayerGainedExperience()
    {
        DataPlayerGainedExperience data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data;  
    }

    public DataPlayerLootedByCreature GetPlayerLootedByCreature()
    {
        DataPlayerLootedByCreature data = new();
        
        data.creature = regex.GetParameter(1);
        data.list = new LootedList(regex.GetParameter(2));
        
        return data;  
    }

        public DataCreatureLostPower GetCreatureLostPower()
    {
        DataCreatureLostPower data = new();
        
        data.creature = regex.GetParameter(1);
        data.points = int.Parse(regex.GetParameter(2));
        
        return data;  
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