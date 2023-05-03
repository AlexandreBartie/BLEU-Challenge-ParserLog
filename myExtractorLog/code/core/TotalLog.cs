using app.log;
using app.data;
using app.util;

using System.Text.Json;

namespace app.core;

public class TotalLog
{

    public RecordsLog logs = new();

    public DataOutput output;

    public DataTotalPlayerHealedPower totalPlayerHealedPower;

    public bool isNull => (logs == null);

    public TotalLog()
    {
        totalPlayerHealedPower = new DataTotalPlayerHealedPower(this);
    }

    public string txt()
    {
        return JsonSerializer.Serialize(output);
    }

    public string log()
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