using app.log;
using app.view;

namespace app.core;

public class ParseView : ParseFormat
{

    public ParseSessions sessions = new();

    public readonly ViewPlayerHealedPower PlayerHealedPower;
    public readonly ViewPlayerLostPower PlayerLostPower;
    public readonly ViewPlayerGainedExperience PlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature PlayerLootedByCreature;

    public readonly ViewCreatureHealedPower CreatureHealedPower;  
    public readonly ViewCreatureLostPower CreatureLostPower;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ParseView()
    {

        PlayerHealedPower = new ViewPlayerHealedPower(this);
        PlayerLostPower = new ViewPlayerLostPower(this);
        PlayerLootedByCreature = new ViewPlayerLootedByCreature(this);
        PlayerGainedExperience = new ViewPlayerGainedExperience(this);
        CreatureHealedPower = new ViewCreatureHealedPower(this);
        CreatureLostPower = new ViewCreatureLostPower(this);

    }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        PlayerHealedPower.SumData();
        PlayerLostPower.SumData();
        PlayerGainedExperience.SumData();
        PlayerLootedByCreature.SumData();
        CreatureLostPower.SumData();
    }

}