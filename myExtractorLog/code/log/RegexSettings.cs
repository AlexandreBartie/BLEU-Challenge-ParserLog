
namespace app.log;

public enum TypeLog
{
    // Channel Server Log saved Wed Apr 12 15:48:26 2023
    eLogNoteSession = 0,

    // Boosted bosses contain more loot and count more kills for your Bosstiary.     
    eLogNoteMessage = 1,

    // XX:XX Today's boosted boss: Goshnar's Malice
    eLogGameMessage = 10,

    // XX:XX You healed yourself for 328 hitpoints.
    eLogGamePlayerHealedPower = 11,

    // XX:XX You lose 1 hitpoint.
    eLogGamePlayerLostPower = 12,

    // XX:XX You lose 31 hitpoints due to an attack by a cyclops.
    eLogGamePlayerLostPowerByCreature = 13,

    // XX:XX You gained 150 experience points.
    eLogGamePlayerGainedExperience = 14,

    // XX:XX Loot of a cyclops: 6 gold coins, a meet.
    eLogGamePlayerLootedByCreature = 15,

    // XX:XX A cyclops loses 260 hitpoints due to your attack.
    eLogGameCreatureLostPower = 16,

}

public class RegexSettings
{
    // variations of gameSession
    // example: Channel Server Log saved Wed Apr 12 15:48:26 2023
    private string tagSession = "^Channel Server Log saved .+$";

    // variations of HealedPower
    // example: You healed yourself for 328 hitpoints.
    private string tagHealedPower = @"^You healed yourself for (\d+) hitpoint(s)?.$";

    // variations of LostPower
    // example: You lose 9 hitpoints. 
    private string tagLostPower = @"^You lose (\d+) hitpoint(s)?\.$";

    // variations of LostPowerByCreature
    // example: You lose 31 hitpoints due to an attack by a cyclops. 
    private string tagLostPowerByCreature = @"^You lose (\d+) hitpoint(s)? due to an attack by a (.*).$";

    // variations of GainedExperience
    // example: You gained 150 experience points.
    private string tagGainedExperience = @"^You gained (\d+) experience point(s)?.$";

    // variations of LootedByCreature
    // example: Loot of a cyclops: 6 gold coins, meat.
    private string tagLootedByCreature = @"^Loot of a (.*): (.*).$";

    // variations of CreatureLostPower
    // example: A cyclops loses 260 hitpoints due to your attack.
    private string tagCreatureLostPower = @"^A (.*) loses (\d+) hitpoint(s)? due to your attack.$";

    public string getPattern(TypeLog type)
    {

        return (type) switch
        {
            TypeLog.eLogNoteSession => tagSession,
            TypeLog.eLogGamePlayerHealedPower => tagHealedPower,
            TypeLog.eLogGamePlayerLostPower => tagLostPower,
            TypeLog.eLogGamePlayerLostPowerByCreature => tagLostPowerByCreature,
            TypeLog.eLogGamePlayerGainedExperience => tagGainedExperience,
            TypeLog.eLogGamePlayerLootedByCreature => tagLootedByCreature,
            TypeLog.eLogGameCreatureLostPower => tagCreatureLostPower,
            _ => ""
        };

    }

}