using app.log;
using app.view;

namespace app.core;

public class ViewData : ParseFormat
{

    public ParseSessions sessions = new();

    public readonly ViewPlayerHealedPower PlayerHealedPower;
    public readonly ViewPlayerLostPower PlayerLostPower;
    public readonly ViewPlayerGainedExperience PlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature PlayerLootedByCreature;

    public readonly ViewCreatureHealedPower CreatureHealedPower;  
    public readonly ViewCreatureLostPower CreatureLostPower;
    public readonly ViewCreatureSpotLight CreatureSpotLight;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ViewData()
    {

        PlayerHealedPower = new ViewPlayerHealedPower(this);
        PlayerLostPower = new ViewPlayerLostPower(this);
        PlayerLootedByCreature = new ViewPlayerLootedByCreature(this);
        PlayerGainedExperience = new ViewPlayerGainedExperience(this);
        
        CreatureHealedPower = new ViewCreatureHealedPower(this);
        CreatureLostPower = new ViewCreatureLostPower(this);
        CreatureSpotLight = new ViewCreatureSpotLight(this);

    }

    public void SetSpotLight(string rules)
    {
        CreatureSpotLight.Setup(rules);
    }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        PlayerHealedPower.SumData();
        PlayerLostPower.SumData();
        PlayerGainedExperience.SumData();
        PlayerLootedByCreature.SumData();
        CreatureHealedPower.SumData();
        CreatureLostPower.SumData();
    }

}