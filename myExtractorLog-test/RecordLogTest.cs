using Xunit;

using app.log;


namespace myappxunit;

public class RecordLogTest
{

    private RecordLog? log;

    [Theory]
    [InlineData("22:22 You healed yourself for 1 hitpoint.", 1)]
    [InlineData("15:42 You healed yourself for 328 hitpoints.", 328)]
    public void XUNIT01_PlayerHealedPower(string info, int points, TypeLog type = TypeLog.eLogPlayerHealedPower)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(points, log.GetPlayerHealedPower().points);

    }

    [Theory]
    [InlineData("15:41 You lose 1 hitpoint.", 1)]
    [InlineData("15:47 You lose 29 hitpoints.", 29)]
    public void XUNIT02_PlayerLostPower(string info, int points, TypeLog type = TypeLog.eLogPlayerLostPower)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(points, log.GetPlayerLostPower().points);

    }

    [Theory]
    [InlineData("18:41 You lose 1 hitpoint due to an attack by a scorpion.", 1, "scorpion")]
    [InlineData("15:47 You lose 75 hitpoints due to an attack by a dragon.", 75, "dragon")]
    [InlineData("18:38 You lose 20 hitpoints due to an attack by a dragon lord.", 20, "dragon lord")]

    public void XUNIT03_PlayerLostPowerByCreature(string info, int points, string creature, TypeLog type = TypeLog.eLogPlayerLostPowerByCreature)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(points, log.GetPlayerLostPowerByCreature().points);
        Assert.Equal(creature, log.GetPlayerLostPowerByCreature().creature);

    }

    [Theory]
    [InlineData("22:22 You gained 1 experience point.", 1)]
    [InlineData("15:47 You gained 700 experience points.", 700)]

    public void XUNIT04_PlayerGainedExperience(string info, int points, TypeLog type = TypeLog.eLogPlayerGainedExperience)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(points, log.GetPlayerGainedExperience().points);

    }

    [Theory]
    [InlineData("15:43 Loot of a rat: a gold coin.", "rat", "1 gold coin")]
    [InlineData("18:37 Loot of a dragon: 2 dragon ham, 66 gold coins.", "dragon", "2 dragon ham, 66 gold coins")]
    [InlineData("15:43 Loot of a cyclops: a cyclops trophy, 29 gold coins.", "cyclops", "1 cyclops trophy, 29 gold coins")]
    [InlineData("15:44 Loot of a cyclops smith: a cyclops toe, 13 gold coins, meat.", "cyclops smith", "1 cyclops toe, 13 gold coins, 1 meat")]
    [InlineData("15:47 Loot of a dragon: a crossbow, 2 dragon ham, green dragon leather, plate legs, a steel shield.", "dragon", "1 crossbow, 2 dragon ham, 1 green dragon leather, 1 plate legs, 1 steel shield")]
    [InlineData("18:33 Loot of a dwarf soldier: 5 bolts, a soldier helmet, 2 white mushrooms.", "dwarf soldier", "5 bolts, 1 soldier helmet, 2 white mushrooms")]
    [InlineData("15:43 Loot of a ghoul: nothing.", "ghoul", "")]
    public void XUNIT08_PlayerLootedByCreature(string info, string creature, string listLooted, TypeLog type = TypeLog.eLogPlayerLootedByCreature)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(creature, log.GetPlayerLootedByCreature().creature);
       // Assert.Equal(listLooted, log.GetPlayerLootedByCreature().listLooted);

    }


    [Theory]
    [InlineData("15:43 A cyclops loses 260 hitpoints due to your attack.", "cyclops", 260)]
    [InlineData("15:46 A dwarf soldier loses 135 hitpoints due to your attack. ", "dwarf soldier", 135)]
    public void XUNIT09_CreatureLostPower(string info, string creature, int points, TypeLog type = TypeLog.eLogCreatureLostPower)
    {

        log = new(info);

        Assert.Equal(type, log.type);
        Assert.Equal(creature, log.GetCreatureLostPower().creature);
        Assert.Equal(points, log.GetCreatureLostPower().points);

    }




}