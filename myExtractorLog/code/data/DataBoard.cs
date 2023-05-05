using app.core;
using app.log;
using app.total;
using app.util;

namespace app.data;

public class DataBoard
{

    public DataView view;

    public SessionsLog sessions = new();

    public readonly TotalPlayerHealedPower totalPlayerHealedPower;
    public readonly TotalPlayerLostPower totalPlayerLostPower;
    public readonly TotalPlayerGainedExperience totalPlayerGainedExperience;
    public readonly TotalPlayerLootedByCreature totalPlayerLootedByCreature;
    public readonly TotalCreatureLostPower totalCreatureLostPower;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public DataBoard()
    {
        view = new DataView();

        totalPlayerHealedPower = new TotalPlayerHealedPower(this);
        totalPlayerLostPower = new TotalPlayerLostPower(this);
        totalPlayerLootedByCreature = new TotalPlayerLootedByCreature(this);
        totalPlayerGainedExperience = new TotalPlayerGainedExperience(this);
        totalCreatureLostPower = new TotalCreatureLostPower(this);

    }
    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        totalPlayerHealedPower.SumData();
        totalPlayerLostPower.SumData();
        totalPlayerGainedExperience.SumData();
        totalPlayerLootedByCreature.SumData();
        totalCreatureLostPower.SumData();
    }

    public string log()
    {

        if (!isNull)
        {

            var memo = new Memo();

            memo.Add(log("         Total Logs"));
            memo.Add(totalPlayerGainedExperience.log("         Experience"));
            memo.Add(totalPlayerHealedPower.log("        HealedPower"));
            memo.Add(totalPlayerLostPower.log("          LostPower"));
            memo.Add(totalPlayerLostPower.byUnknown.log("           -unknown"));
            memo.Add(totalPlayerLostPower.byCreature.log("        -byCreature"));
            memo.Add(totalPlayerLootedByCreature.log("   LootedByCreature"));
            memo.Add(totalCreatureLostPower.log("  CreatureLostPower"));

            return (memo.txt);
        }

        return "";

    }
    private string log(string label)
    {
        return $"{label}: {logs.Count()}";
    }

}