using app.core;
using app.log;
using app.view;
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

            memo.add(Importlog(SizePattern("Total")));
            memo.add(viewPlayerGainedExperience.log(SizePattern("Experience")));
            memo.add(viewPlayerHealedPower.log(SizePattern("HealedPower")));
            memo.add(viewPlayerLostPower.log(SizePattern("LostPower")));
            memo.add(viewPlayerLostPower.byUnknown.log(SizePattern("-unknown")));
            memo.add(viewPlayerLostPower.byCreature.log(SizePattern("-byCreature")));
            memo.add(viewPlayerLootedByCreature.log(SizePattern("LootedByCreature")));
            memo.add(viewCreatureLostPower.log(SizePattern("CreatureLostPower")));

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