using app.log;
using app.data;
using app.total;
using app.util;

using System.Text.Json;


namespace app.total;

public class TotalLog
{

    public DataOutput output;

    private RecordsLog _logs = new();
    public RecordsLog logs => _logs;

    public readonly DataTotalPlayerHealedPower totalPlayerHealedPower;
    public readonly DataTotalPlayerLostPower totalPlayerLostPower;
    public readonly DataTotalPlayerLostPowerByCreature totalPlayerLostPowerByCreature;

    public bool isNull => (_logs == null);

    public TotalLog()
    {
        output = new DataOutput();

        totalPlayerHealedPower = new DataTotalPlayerHealedPower(this);
        totalPlayerLostPower = new DataTotalPlayerLostPower(this);
        totalPlayerLostPowerByCreature = new DataTotalPlayerLostPowerByCreature(this);
    }

    protected void SetLogs(RecordsLog logs)
    {
        this._logs = logs;

        SumDataAll();
    }

    private void SumDataAll()
    {
        totalPlayerHealedPower.SumData();
        totalPlayerLostPower.SumData();
        totalPlayerLostPowerByCreature.SumData();
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
            memo.Add($"           Sessions: {logs.filter(TypeLog.eLogNoteSession).Count}");
            memo.Add($"        HealedPower: {output.hitpointsHealed} points #{totalPlayerHealedPower?.count}");
            memo.Add($"          LostPower: {output.damageTaken.total} points #{totalPlayerLostPower?.count}");
            memo.Add($"LostPowerByCreature: {logs.filter(TypeLog.eLogGamePlayerLostPowerByCreature).Count}");
            memo.Add($"   GainedExperience: {logs.filter(TypeLog.eLogGamePlayerGainedExperience).Count}");
            memo.Add($"   LootedByCreature: {logs.filter(TypeLog.eLogGamePlayerLootedByCreature).Count}");
            memo.Add($"  CreatureLostPower: {logs.filter(TypeLog.eLogGameCreatureLostPower).Count}");

            return (memo.txt);
        }

        return "";

    }

}