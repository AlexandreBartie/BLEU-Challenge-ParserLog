using app.util;
using app.log;
using app.data;

namespace app.total;

public class TotalBoard
{

    public DataView view;

    private RecordsLog _logs = new();
    public RecordsLog logs => _logs;

    public readonly TotalPlayerHealedPower totalPlayerHealedPower;
    public readonly TotalPlayerLostPowerByUnknown totalPlayerLostPowerByUnknown;
    public readonly TotalPlayerLostPowerByCreature totalPlayerLostPowerByCreature;
    public readonly TotalPlayerGainedExperience totalPlayerGainedExperience;
    public readonly TotalPlayerLootedByCreature totalPlayerLootedByCreature;
    public readonly TotalCreatureLostPower totalCreatureLostPower;

    public bool isNull => (_logs.Count == 0);

    public TotalBoard()
    {
        view = new DataView();

        totalPlayerHealedPower = new TotalPlayerHealedPower(this);
        totalPlayerLostPowerByUnknown = new TotalPlayerLostPowerByUnknown(this);
        totalPlayerLostPowerByCreature = new TotalPlayerLostPowerByCreature(this);
        totalPlayerLootedByCreature = new TotalPlayerLootedByCreature(this);
        totalPlayerGainedExperience = new TotalPlayerGainedExperience(this);
        totalCreatureLostPower = new TotalCreatureLostPower(this);
    }

    protected void SetLogs(RecordsLog logs)
    {
        this._logs = logs;

        SumDataAll();
    }

    private void SumDataAll()
    {
        totalPlayerHealedPower.SumData();
        totalPlayerLostPowerByUnknown.SumData();
        totalPlayerLostPowerByCreature.SumData();
        totalPlayerGainedExperience.SumData();
        totalPlayerLootedByCreature.SumData();
        totalCreatureLostPower.SumData();
    }

    public string log()
    {

        if (!isNull)
        {

            var memo = new Memo();

            memo.Add(                               log("         Total Logs"));
            memo.Add(   totalPlayerGainedExperience.log("         Experience"));
            memo.Add(        totalPlayerHealedPower.log("        HealedPower"));
            memo.Add( totalPlayerLostPowerByUnknown.log("          LostPower"));
            memo.Add( totalPlayerLostPowerByUnknown.log("           -unknown"));
            memo.Add(totalPlayerLostPowerByCreature.log("        -byCreature"));
            memo.Add(   totalPlayerLootedByCreature.log("   LootedByCreature"));
            memo.Add(        totalCreatureLostPower.log("  CreatureLostPower"));

            return (memo.txt);
        }

        return "";

    }
    private string log(string label)
    {
        return $"{label}: {logs.Count()}";
    }    

}