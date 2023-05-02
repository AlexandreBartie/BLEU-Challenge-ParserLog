
namespace app.log;

public enum TypeLog
{
    // Channel Server Log saved Wed Apr 12 15:48:26 2023
    eLogGameSession = 0,

    // Boosted bosses contain more loot and count more kills for your Bosstiary.     
    eLogGameMessage = 1,

    // XX:XX Today's boosted boss: Goshnar's Malice
    eLogPlayerMessage = 10,

    // XX:XX You healed yourself for 328 hitpoints.
    eLogPlayerHealedPower = 11,

    // XX:XX You lose 1 hitpoint.
    eLogPlayerLostPower = 12,

    // XX:XX You lose 31 hitpoints due to an attack by a cyclops.
    eLogPlayerLostPowerByCreature = 13,

    // XX:XX You gained 150 experience points.
    eLogPlayerGainedExperience = 14,

    // XX:XX Loot of a cyclops: 6 gold coins, a meet.
    eLogPlayerLootedByCreature = 15,

    // XX:XX A cyclops loses 260 hitpoints due to your attack.
    eLogCreatureLostPower = 16,

}

public class RegexSettings
{
    // variations of gameSession
    // example: Channel Server Log saved Wed Apr 12 15:48:26 2023
    private string gameSession = "^Channel Server Log saved .+$";

    // variations of HealedPower
    // example: You healed yourself for 328 hitpoints.
    private string HealedPower = @"^You healed yourself for (\d+) hitpoint(s)?.$";

    // variations of LostPower
    // example: You lose 9 hitpoints. 
    private string lostPower = @"^You lose (\d+) hitpoint(s)?\.$";

    // variations of LostPowerByCreature
    // example: You lose 31 hitpoints due to an attack by a cyclops. 
    private string lostPowerByCreature = @"^You lose (\d+) hitpoint(s)? due to an attack by a (.*).$";

    // variations of GainedExperience
    // example: You gained 150 experience points.
    private string gainedExperience = @"^You gained (\d+) experience point(s)?.$";

    // variations of LootedByCreature
    // example: Loot of a cyclops: 6 gold coins, meat.
    private string lootedByCreature = @"^Loot of a (.*): (.*).$";

    // variations of CreatureLostPower
    // example: A cyclops loses 260 hitpoints due to your attack.
    private string creatureLostPower = @"^A (.*) loses (\d+) hitpoint(s)? due to your attack.$";

    public string getPattern(TypeLog type)
    {

        return (type) switch
        {
            TypeLog.eLogGameSession => gameSession,
            TypeLog.eLogPlayerHealedPower => HealedPower,
            TypeLog.eLogPlayerLostPower => lostPower,
            TypeLog.eLogPlayerLostPowerByCreature => lostPowerByCreature,
            TypeLog.eLogPlayerGainedExperience => gainedExperience,
            TypeLog.eLogPlayerLootedByCreature => lootedByCreature,
            TypeLog.eLogCreatureLostPower => creatureLostPower,
            _ => ""
        };

    }

}