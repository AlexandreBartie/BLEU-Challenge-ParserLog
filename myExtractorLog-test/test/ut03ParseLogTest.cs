using app.core;

namespace myappxunit;

public class ParseLogTest
{

    const string PATH_FILE = "C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/file/";

    private string input = "";

    private ParseLog parse = new(PATH_FILE);

    [Theory]
    [InlineData(957, 5)]
    public void TST01_ViewPlayerHealedPower(int damage, int qty)
    {

        input = "ServerLog-PlayerHealedPower.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.viewPlayerHealedPower.totalHealed);
        Assert.Equal(qty, parse.viewPlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_ViewPlayerLostPower(int unknown, int total, int qty)
    {

        input = "ServerLog-PlayerLostPower.txt";

        parse.LoadFile(input);

        Assert.Equal(unknown, parse.viewPlayerLostPower.byUnknown.totalDamage);
        Assert.Equal(total, parse.viewPlayerLostPower.totalDamage);
        Assert.Equal(qty, parse.viewPlayerLostPower.count);

    }

    [Theory]
    [InlineData(697, 6)]
    public void TST03_ViewPlayerGainedExperience(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.viewPlayerGainedExperience.totalExperience);
        Assert.Equal(qty, parse.viewPlayerGainedExperience.count);

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

        var listLog = parse.viewPlayerLostPower.byCreature.list.filter(creature);

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

        var creature = parse.viewCreatureLostPower.list.filter(name);

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

        var list = parse.viewPlayerLootedByCreature.loot.filter(item);

        Assert.Equal(total, list.total);
        Assert.Equal(qty, list.count);

    }

    [Theory]
    [InlineData("ghoul, cyclops, cyclops smith, dragon, dwarf soldier", 8)]
    public void TST07_ViewCreatureList(string log, int qty)
    {

        string input = "ServerLog-PlayerLostPower.txt";

        parse.LoadFile(input);

        var list = parse.viewPlayerLostPower.byCreature.list;

        Assert.Equal(qty, list.count);
        // Assert.Equal(log, list.log("... ").csv);


    }

    public void TSTXX_TotalExtraCreature(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.viewPlayerGainedExperience.totalExperience);
        Assert.Equal(qty, parse.viewPlayerGainedExperience.count);

    }


}