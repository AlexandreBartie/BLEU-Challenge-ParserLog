using app.data;
using app.extra;

namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader => type == TypeLog.eLogNoteSession;

    public RecordLog(string info) : base(info) {}

    public DataPlayerHealedPower dataPlayerHealedPower
    {
        get {

            DataPlayerHealedPower data = new();
            
            data.points = int.Parse(regex.GetParameter(1));
            
            return data; 

        }
        

    }
    public DataPlayerLostPower dataPlayerLostPower
    {
        get {
        
            DataPlayerLostPower data = new();
            
            data.points = int.Parse(regex.GetParameter(1));
            
            return data;

        } 
    }
    public DataPlayerLostPowerByCreature dataPlayerLostPowerByCreature
    {
        
        get {

            DataPlayerLostPowerByCreature data = new();
            
            data.points = int.Parse(regex.GetParameter(1));
            data.creature = regex.GetParameter(3);
            
            return data;
        }  
    }

    public DataPlayerGainedExperience dataPlayerGainedExperience
    {
        get {
            DataPlayerGainedExperience data = new();
            
            data.points = int.Parse(regex.GetParameter(1));
            
            return data;
        }  
    }

    public DataPlayerLootedByCreature dataPlayerLootedByCreature
    {
        get {

            DataPlayerLootedByCreature data = new();
            
            data.creature = regex.GetParameter(1);
            data.list = new LootedList(regex.GetParameter(2));
            
            return data;
        }
    }

    public DataCreatureLostPower dataCreatureLostPower
    {
        get {

            DataCreatureLostPower data = new();
            
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