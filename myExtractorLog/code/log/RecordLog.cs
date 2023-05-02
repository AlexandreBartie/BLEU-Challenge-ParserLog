namespace app.log;

public class RecordLog : BaseLog
{
    public bool isHeader
    {
        get { return type == TypeLog.eLogGameSession; }
    }

    public RecordLog(string info) : base(info) {}

    public PlayerHealedPower GetPlayerHealedPower()
    {
        
        PlayerHealedPower data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data; 
    }
    public PlayerLostPower GetPlayerLostPower()
    {
        PlayerLostPower data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data;  
    }
    public PlayerLostPowerByCreature GetPlayerLostPowerByCreature()
    {
        PlayerLostPowerByCreature data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        data.creature = regex.GetParameter(3);
        
        return data;  
    }

    public PlayerGainedExperience GetPlayerGainedExperience()
    {
        PlayerGainedExperience data = new();
        
        data.points = int.Parse(regex.GetParameter(1));
        
        return data;  
    }

    public PlayerLootedByCreature GetPlayerLootedByCreature()
    {
        PlayerLootedByCreature data = new();
        
        data.creature = regex.GetParameter(1);
        data.listLooted = regex.GetParameter(2);
        
        return data;  
    }

        public CreatureLostPower GetCreatureLostPower()
    {
        CreatureLostPower data = new();
        
        data.creature = regex.GetParameter(1);
        data.points = int.Parse(regex.GetParameter(2));
        
        return data;  
    }
        
}

public class RecordsLog : List<RecordLog>{

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