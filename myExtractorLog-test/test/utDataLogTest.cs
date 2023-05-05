using app.data;

namespace myappxunit;

public class DataLogTest
{

    const string PATH_FILE = "C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/file/";

    private string input = "";

    private DataLog data = new(PATH_FILE);

    [Theory]
    [InlineData(957, 5)]
    public void TST01_ViewPlayerHealedPower(int damage, int qty)
    {

        input = "ServerLog-PlayerHealedPower.txt";

        data.Load(input);

        Assert.Equal(damage, data.viewPlayerHealedPower.totalHealed);
        Assert.Equal(qty, data.viewPlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_ViewPlayerLostPower(int unknown, int total, int qty)
    {

        input = "ServerLog-PlayerLostPower.txt";

        data.Load(input);

        Assert.Equal(unknown, data.viewPlayerLostPower.byUnknown.totalDamage);
        Assert.Equal(total, data.viewPlayerLostPower.totalDamage);
        Assert.Equal(qty, data.viewPlayerLostPower.count);

    }

    [Theory]
    [InlineData(697, 6)]
    public void TST03_ViewPlayerGainedExperience(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        data.Load(input);

        Assert.Equal(damage, data.viewPlayerGainedExperience.totalExperience);
        Assert.Equal(qty, data.viewPlayerGainedExperience.count);

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

        data.Load(input);

        var listLog = data.viewPlayerLostPower.byCreature.list.filter(creature);

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

        data.Load(input);

        var creature = data.viewCreatureLostPower.list.filter(name);

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

        data.Load(input);

        var list = data.viewPlayerLootedByCreature.loot.filter(item);

        Assert.Equal(total, list.total);
        Assert.Equal(qty, list.count);

    }

    [Theory]
    [InlineData("ghoul, cyclops, cyclops smith, dragon, dwarf soldier", 8)]
    public void TST07_ViewCreatureList(string log, int qty)
    {

        string input = "ServerLog-PlayerLostPower.txt";

        data.Load(input);

        var list = data.viewPlayerLostPower.byCreature.list;

        Assert.Equal(qty, list.count);
        // Assert.Equal(log, list.log("... ").csv);


    }

    public void TSTXX_TotalExtraCreature(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        data.Load(input);

        Assert.Equal(damage, data.viewPlayerGainedExperience.totalExperience);
        Assert.Equal(qty, data.viewPlayerGainedExperience.count);

    }


}