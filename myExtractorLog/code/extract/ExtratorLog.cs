using app.log;
using app.util;

namespace app.extract;

public class ExtratorLog
{

    private DataLog data = new();

    public string result => getResult();

    public bool Load(string path, string name)
    {
        return data.Load(path, name);
    }

    private string getResult()
    {

        var memo = new Memo();

        memo.Add($"               Logs: {data.logs.Count()}");
        memo.Add($"           Sessions: {data.logs.filter(TypeLog.eLogGameSession).Count}");
        memo.Add($"        HealedPower: {data.logs.filter(TypeLog.eLogPlayerHealedPower).Count}");
        memo.Add($"          LostPower: {data.logs.filter(TypeLog.eLogPlayerLostPower).Count}");
        memo.Add($"LostPowerByCreature: {data.logs.filter(TypeLog.eLogPlayerLostPowerByCreature).Count}");
        memo.Add($"   GainedExperience: {data.logs.filter(TypeLog.eLogPlayerGainedExperience).Count}");
        memo.Add($"   LootedByCreature: {data.logs.filter(TypeLog.eLogPlayerLootedByCreature).Count}");
        memo.Add($"  CreatureLostPower: {data.logs.filter(TypeLog.eLogCreatureLostPower).Count}");

        return (memo.txt);
    }

}
