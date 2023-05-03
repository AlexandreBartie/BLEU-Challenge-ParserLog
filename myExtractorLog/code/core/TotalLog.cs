using app.log;
using app.data;
using app.util;

namespace app.core;

public class TotalLog
{

    public RecordsLog logs = new();

    public TotalPlayerHealedPower totalPlayerHealedPower;

    public bool isNull => (logs == null);

    public TotalLog()
    {
        totalPlayerHealedPower = new TotalPlayerHealedPower(this);
    }

    public string output()
    {

        if (!isNull)
        {
            var memo = new Memo();

            memo.Add($"               Logs: {logs.Count()}");
            memo.Add($"           Sessions: {logs.filter(TypeLog.eLogGameSession).Count}");
            memo.Add($"        HealedPower: {totalPlayerHealedPower.board.points} points #{totalPlayerHealedPower.count}");
            memo.Add($"          LostPower: {logs.filter(TypeLog.eLogPlayerLostPower).Count}");
            memo.Add($"LostPowerByCreature: {logs.filter(TypeLog.eLogPlayerLostPowerByCreature).Count}");
            memo.Add($"   GainedExperience: {logs.filter(TypeLog.eLogPlayerGainedExperience).Count}");
            memo.Add($"   LootedByCreature: {logs.filter(TypeLog.eLogPlayerLootedByCreature).Count}");
            memo.Add($"  CreatureLostPower: {logs.filter(TypeLog.eLogCreatureLostPower).Count}");

            return (memo.txt);
        }

        return "";

    } 

}