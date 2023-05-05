using app.core;
using app.log;
using app.total;
using app.util;

namespace app.data;

public class DataView
{

    public SessionsLog sessions = new();

    public readonly ViewPlayerHealedPower viewPlayerHealedPower;
    public readonly ViewPlayerLostPower viewPlayerLostPower;
    public readonly ViewPlayerGainedExperience viewPlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature viewPlayerLootedByCreature;
    public readonly ViewCreatureLostPower viewCreatureLostPower;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public DataView()
    {

        viewPlayerHealedPower = new ViewPlayerHealedPower(this);
        viewPlayerLostPower = new ViewPlayerLostPower(this);
        viewPlayerLootedByCreature = new ViewPlayerLootedByCreature(this);
        viewPlayerGainedExperience = new ViewPlayerGainedExperience(this);
        viewCreatureLostPower = new ViewCreatureLostPower(this);

    }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        viewPlayerHealedPower.SumData();
        viewPlayerLostPower.SumData();
        viewPlayerGainedExperience.SumData();
        viewPlayerLootedByCreature.SumData();
        viewCreatureLostPower.SumData();
    }

    public string log()
    {

        if (!isNull)
        {

            var memo = new Memo();

            memo.Add(Importlog(SizePattern("Total")));
            memo.Add(viewPlayerGainedExperience.log(SizePattern("Experience")));
            memo.Add(viewPlayerHealedPower.log(SizePattern("HealedPower")));
            memo.Add(viewPlayerLostPower.log(SizePattern("LostPower")));
            memo.Add(viewPlayerLostPower.byUnknown.log(SizePattern("-unknown")));
            memo.Add(viewPlayerLostPower.byCreature.log(SizePattern("-byCreature")));
            memo.Add(viewPlayerLootedByCreature.log(SizePattern("LootedByCreature")));
            memo.Add(viewCreatureLostPower.log(SizePattern("CreatureLostPower")));

            return (memo.txt);
        }

        return "";

    }
    private string Importlog(string label)
    {
        return $"{label}: {logs.Count()} logs #{sessions.Count()}";
    }

    private string SizePattern(string label)
    {
        return label.PadLeft(25);
    }

}