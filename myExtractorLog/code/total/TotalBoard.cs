using app.util;
using app.log;
using app.data;


using System.Text.Json;


namespace app.total;

public class TotalBoard
{

    public DataOutput output;

    private RecordsLog _logs = new();
    public RecordsLog logs => _logs;

    public readonly TotalPlayerHealedPower totalPlayerHealedPower;
    public readonly TotalPlayerLostPower totalPlayerLostPower;
    public readonly TotalPlayerLostPowerByCreature totalPlayerLostPowerByCreature;
    public readonly TotalPlayerGainedExperience totalPlayerGainedExperience;
    public readonly TotalPlayerLootedByCreature totalPlayerLootedByCreature;
    public readonly TotalCreatureLostPower totalCreatureLostPower;

    public bool isNull => (_logs == null);

    public TotalBoard()
    {
        output = new DataOutput();

        totalPlayerHealedPower = new TotalPlayerHealedPower(this);
        totalPlayerLostPower = new TotalPlayerLostPower(this);
        totalPlayerLostPowerByCreature = new TotalPlayerLostPowerByCreature(this);
        totalPlayerLootedByCreature = new TotalPlayerLootedByCreature(this);
        totalPlayerGainedExperience = new TotalPlayerGainedExperience(this); totalCreatureLostPower = new TotalCreatureLostPower(this);
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
        totalPlayerGainedExperience.SumData();
        totalPlayerLootedByCreature.SumData();
        totalCreatureLostPower.SumData();
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