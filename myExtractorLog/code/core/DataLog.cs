        
using app.core;
using app.log;
using app.util;

namespace app.core;

public class DataLog
{
    
    private ImportLog import = new();

    public RecordsLog logs => import.logs;   
    
    public bool Load(string path, string name) 
    {
        return import.Load(path, name);
    }
    public string output()
    {

        var memo = new Memo();

        memo.Add($"               Logs: {logs.Count()}");
        memo.Add($"           Sessions: {logs.filter(TypeLog.eLogGameSession).Count}");
        memo.Add($"        HealedPower: {logs.filter(TypeLog.eLogPlayerHealedPower).Count}");
        memo.Add($"          LostPower: {logs.filter(TypeLog.eLogPlayerLostPower).Count}");
        memo.Add($"LostPowerByCreature: {logs.filter(TypeLog.eLogPlayerLostPowerByCreature).Count}");
        memo.Add($"   GainedExperience: {logs.filter(TypeLog.eLogPlayerGainedExperience).Count}");
        memo.Add($"   LootedByCreature: {logs.filter(TypeLog.eLogPlayerLootedByCreature).Count}");
        memo.Add($"  CreatureLostPower: {logs.filter(TypeLog.eLogCreatureLostPower).Count}");

        return (memo.txt);
    } 

}

