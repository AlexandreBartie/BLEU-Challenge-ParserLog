using app.log;
using app.data;
using app.util;

using System.Text.Json;
using app.total;

namespace app.core;

public class TotalLog
{

    public RecordsLog logs = new();

    public DataOutput output = new();

    private DataTotalPlayerHealedPower? totalPlayerHealedPower;
    private DataTotalPlayerLostPower? totalPlayerLostPower;

    public bool isNull => (logs == null);

    // public TotalLog()
    // {
    //     // totalPlayerHealedPower = new DataTotalPlayerHealedPower(this);
    //     // totalPlayerLostPower = new DataTotalPlayerLostPower(this);
    // }

    private void SumDataAll()
    {
        totalPlayerHealedPower = new DataTotalPlayerHealedPower(this);
        totalPlayerLostPower = new DataTotalPlayerLostPower(this);
    }

    public string txt()
    {
        SumDataAll();

        return JsonSerializer.Serialize(output);
    }

    public string log()
    {

        if (!isNull)
        {

            SumDataAll();

            var memo = new Memo();

            memo.Add($"               Logs: {logs.Count()}");
            memo.Add($"           Sessions: {logs.filter(TypeLog.eLogGameSession).Count}");
            memo.Add($"        HealedPower: {output.hitpointsHealed} points #{totalPlayerHealedPower?.count}");
            memo.Add($"          LostPower: {output.damageTaken.total} points #{totalPlayerLostPower?.count}");
            memo.Add($"LostPowerByCreature: {logs.filter(TypeLog.eLogPlayerLostPowerByCreature).Count}");
            memo.Add($"   GainedExperience: {logs.filter(TypeLog.eLogPlayerGainedExperience).Count}");
            memo.Add($"   LootedByCreature: {logs.filter(TypeLog.eLogPlayerLootedByCreature).Count}");
            memo.Add($"  CreatureLostPower: {logs.filter(TypeLog.eLogCreatureLostPower).Count}");

            return (memo.txt);
        }

        return "";

    } 

}