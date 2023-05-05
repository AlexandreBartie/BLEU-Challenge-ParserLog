using app.core;
using app.log;
using app.util;

namespace app.view;

public class ViewData
{

    public ParseSessions sessions = new();

    public readonly ViewPlayerHealedPower viewPlayerHealedPower;
    public readonly ViewPlayerLostPower viewPlayerLostPower;
    public readonly ViewPlayerGainedExperience viewPlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature viewPlayerLootedByCreature;
    public readonly ViewCreatureLostPower viewCreatureLostPower;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ViewData()
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

}