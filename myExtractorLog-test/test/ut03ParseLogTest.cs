using app.core;

namespace myappxunit;

public class UT03_ParseLogTest
{

    private string input = "";

    private ParseLog parse = new();

    [Theory]
    [InlineData(957, 5)]
    public void TST01_ViewPlayerHealedPower(int damage, int qty)
    {

        input = "ServerLog-PlayerHealedPower.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.PlayerHealedPower.totalHealed);
        Assert.Equal(qty, parse.PlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_ViewPlayerLostPower(int unknown, int total, int qty)
    {

        input = "ServerLog-PlayerLostPower.txt";

        parse.LoadFile(input);

        Assert.Equal(unknown, parse.PlayerLostPower.byUnknown.totalDamage);
        Assert.Equal(total, parse.PlayerLostPower.totalDamage);
        Assert.Equal(qty, parse.PlayerLostPower.count);

    }

    [Theory]
    [InlineData(697, 6)]
    public void TST03_ViewPlayerGainedExperience(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.PlayerGainedExperience.totalExperience);
        Assert.Equal(qty, parse.PlayerGainedExperience.count);

    }

    [Theory]
    [InlineData("ghoul", 2, 1)]
    [InlineData("cyclops", 16, 2)]
    [InlineData("cyclops smith", 29, 1)]
    [InlineData("dragon", 264, 3)]
    [InlineData("dwarf soldier", 9, 1)]
    public void TST04_ViewPlayerLostPowerByCreature(string creature, int totalDamage, int qty)
    {

        string input = "ServerLog-PlayerLostPower.txt";

        parse.LoadFile(input);

        var listLog = parse.PlayerLostPower.byCreature.list.filter(creature);

        Assert.Equal(totalDamage, listLog.totalDamage);
        Assert.Equal(qty, listLog.count);

    }

    [Theory]
    [InlineData("rat", 20, 1)]
    [InlineData("cyclops", 520, 2)]
    [InlineData("cyclops smith", 435, 2)]
    [InlineData("skeleton", 50, 1)]
    [InlineData("spider", 20, 1)]
    [InlineData("dragon", 1018, 3)]
    [InlineData("dwarf", 90, 1)]
    [InlineData("dwarf soldier", 135, 1)]
    public void TST05_ViewCreatureLostPower(string name, int totalDamage, int qty)
    {

        string input = "ServerLog-CreatureLostPower.txt";

        parse.LoadFile(input);

        var creature = parse.CreatureLostPower.list.filter(name);

        Assert.Equal(totalDamage, creature.totalDamage);
        Assert.Equal(qty, creature.Count);

    }

    [Theory]
    [InlineData("gold coins", 203, 11)]
    [InlineData("gold coin", 203, 11)]
    [InlineData("cyclops toe", 1, 1)]
    [InlineData("dragon ham", 5, 3)]
    [InlineData("meat", 1, 1)]
    [InlineData("plate legs", 2, 2)]
    [InlineData("green dragon leather", 1, 1)]
    [InlineData("steel shield", 1, 1)]
    [InlineData("steel helmet", 1, 1)]
    [InlineData("small diamond", 1, 1)]
    public void TST06_ViewPlayerLootedByCreature(string item, int total, int qty)
    {

        string input = "ServerLog-PlayerLootedByCreature.txt";

        parse.LoadFile(input);

        var list = parse.PlayerLootedByCreature.loot.filter(item);

        Assert.Equal(total, list.total);
        Assert.Equal(qty, list.count);

    }

    [Theory]
    [InlineData("cyclops, cyclops smith, dragon, dwarf soldier, ghoul")]
    public void TST07_ViewCreatureList(string creatures)
    {

        string input = "ServerLog-PlayerLostPower.txt";

        parse.LoadFile(input);

        var list = parse.PlayerLostPower.byCreature.list;

        Assert.Equal(creatures, list.creatures.txt);

    }

    [Theory]
    [InlineData("crossbow, cyclops toe, dragon ham, gold coins, green dragon leather, letter, meat, plate legs, small diamond, steel helmet, steel shield")]
    public void TST08_ViewLootList(string creatures)
    {

        string input = "ServerLog-PlayerLootedByCreature.txt";

        parse.LoadFile(input);

        var list = parse.PlayerLootedByCreature.loot.items;

        Assert.Equal(creatures, list.txt);

    }

    public void TSTXX_TotalExtraCreature(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.PlayerGainedExperience.totalExperience);
        Assert.Equal(qty, parse.PlayerGainedExperience.count);

    }


}