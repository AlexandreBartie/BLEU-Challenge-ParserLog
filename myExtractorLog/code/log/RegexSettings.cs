
namespace app.log;

public enum TypeLog
{
    // Channel Server Log saved Wed Apr 12 15:48:26 2023
    eLogNoteSession = 0,

    // Boosted bosses contain more loot and count more kills for your Bosstiary.     
    eLogNoteMessage = 1,

    // XX:XX Today's boosted boss: Goshnar's Malice
    eLogMessage = 10,

    // XX:XX You healed yourself for 328 hitpoints.
    eLogPlayerHealedPower = 11,

    // XX:XX You lose 1 hitpoint.
    eLogPlayerLostPowerByUnknown = 12,

    // XX:XX You lose 31 hitpoints due to an attack by a cyclops.
    eLogPlayerLostPowerByCreature = 13,

    // XX:XX You gained 150 experience points.
    eLogPlayerGainedExperience = 14,

    // XX:XX Loot of a cyclops: 6 gold coins, a meet.
    eLogPlayerLootedByCreature = 15,

    // XX:XX A dragon healed itself for 60 hitpoints.
    eLogCreatureHealedPower = 16,

    // XX:XX A cyclops loses 260 hitpoints due to your attack.
    eLogCreatureLostPower = 17,

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
    private string tagLostPowerByUnknown = @"^You lose (\d+) hitpoint(s)?\.$";

    // variations of LostPowerByCreature
    // example: You lose 31 hitpoints due to an attack by a cyclops. 
    private string tagLostPowerByCreature = @"^You lose (\d+) hitpoint(s)? due to an attack by a (.*).$";

    // variations of GainedExperience
    // example: You gained 150 experience points.
    private string tagGainedExperience = @"^You gained (\d+) experience point(s)?.$";

    // variations of LootedByCreature
    // example: Loot of a cyclops: 6 gold coins, meat.
    private string tagLootedByCreature = @"^Loot of a (.*): (.*).$";

    // variations of CreatureHealedPower
    // example: A dragon healed itself for 60 hitpoints.
    private string tagCreatureHealedPower = @"^A (.*) healed itself for (\d+) hitpoint(s)?.$";

    // variations of CreatureLostPower
    // example: A cyclops loses 260 hitpoints due to your attack.
    private string tagCreatureLostPower = @"^A (.*) loses (\d+) hitpoint(s)? due to your attack.$";

    public string getPattern(TypeLog type)
    {

        return (type) switch
        {
            TypeLog.eLogNoteSession => tagSession,
            TypeLog.eLogPlayerHealedPower => tagHealedPower,
            TypeLog.eLogPlayerLostPowerByUnknown => tagLostPowerByUnknown,
            TypeLog.eLogPlayerLostPowerByCreature => tagLostPowerByCreature,
            TypeLog.eLogPlayerGainedExperience => tagGainedExperience,
            TypeLog.eLogPlayerLootedByCreature => tagLootedByCreature,
            TypeLog.eLogCreatureHealedPower => tagCreatureHealedPower,
            TypeLog.eLogCreatureLostPower => tagCreatureLostPower,
            _ => ""
        };

    }

}