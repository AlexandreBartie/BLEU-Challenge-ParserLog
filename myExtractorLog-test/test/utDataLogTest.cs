using app.data;

namespace myappxunit;

public class DataLogTest
{

    const string PATH_FILE = "C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/file/";

    private string input = "";

    private DataLog data = new(PATH_FILE);

    [Theory]
    [InlineData(957, 5)]
    public void TST01_TotalPlayerHealedPower(int damage, int qty)
    {

        input = "ServerLog-PlayerHealedPower.txt";

        data.Load(input);

        Assert.Equal(damage, data.output.hitpointsHealed);
        Assert.Equal(qty, data.totalPlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_TotalPlayerLostPower(int unknown, int total, int qty)
    {

       input = "ServerLog-PlayerLostPower.txt";
        
        data.Load(input);

        Assert.Equal(unknown, data.output.damageTaken.unknown);
        Assert.Equal(total, data.output.damageTaken.total);
        Assert.Equal(qty, data.totalPlayerLostPower.count + data.totalPlayerLostPowerByCreature.count);

    }

    [Theory]
    [InlineData(697, 6)]
    public void TST03_TotalPlayerGainedExperience(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        data.Load(input);

        Assert.Equal(damage, data.output.experienceGained);
        Assert.Equal(qty, data.totalPlayerGainedExperience.count);

    }

    [Theory]
    [InlineData("ghoul", 2, 1)]
    [InlineData("cyclops", 16, 2)]
    [InlineData("cyclops smith", 29, 1)]
    [InlineData("dragon", 264, 3)]
    [InlineData("dwarf soldier", 9, 1)]    
    public void TST04_TotalPlayerLostPowerByCreature(string creature, int totalDamage, int qty)
    {

        string input = "ServerLog-PlayerLostPower.txt";

        data.Load(input);

        var list = data.output.damageTaken.byCreature.filter(creature);

        Assert.Equal(totalDamage, list.totalDamage);
        Assert.Equal(qty, list.Count);

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
    public void TST05_TotalCreatureLostPower(string creature, int totalDamage, int qty)
    {

        string input = "ServerLog-CreatureLostPower.txt";

        data.Load(input);

        var list = data.output.creatures.lostPower.filter(creature);

        Assert.Equal(totalDamage, list.totalDamage);
        Assert.Equal(qty, list.Count);

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
    public void TST06_TotalPlayerLootedByCreature(string item, int total, int qty)
    {

        string input = "ServerLog-PlayerLootedByCreature.txt";

        data.Load(input);

        var list = data.output.loot.filter(item);

        Assert.Equal(total, list.total);
        Assert.Equal(qty, list.Count);

    }

    public void TSTXX_TotalExtraCreature(int damage, int qty)
    {

        input = "ServerLog-PlayerGainedExperience.txt";

        data.Load(input);

        Assert.Equal(damage, data.output.experienceGained);
        Assert.Equal(qty, data.totalPlayerGainedExperience.count);

    }


}