using app.data;

namespace myappxunit;

public class DataLogTest
{

    const string PATH_FILE = "C:/DEVOPS/CHALLENGE/BLEU/ExtractorLog/myExtractorLog/code/file/";

    private string input = "";

    private DataLog data = new(PATH_FILE);

    [Theory]
    [InlineData(957, 5)]
    public void TST01_TotalPlayerHealedPower(int damage, int qty)
    {

        input = "ServerLog-TotalPlayerHealedPower.txt";

        data.Load(input);

        Assert.Equal(damage, data.output.hitpointsHealed);
        Assert.Equal(qty, data.totalPlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_TotalPlayerLostPower(int unknown, int total, int qty)
    {

       input = "ServerLog-TotalPlayerLostPower.txt";
        
        data.Load(input);

        Assert.Equal(unknown, data.output.damageTaken.unknown);
        Assert.Equal(total, data.output.damageTaken.total);
        Assert.Equal(qty, data.totalPlayerLostPower.count + data.totalPlayerLostPowerByCreature.count);

    }
    [Theory]
    [InlineData(697, 6)]
    public void TST03_TotalPlayerGainedExperience(int damage, int qty)
    {

        input = "ServerLog-TotalPlayerGainedExperience.txt";

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

        string input = "ServerLog-TotalPlayerLostPower.txt";

        data.Load(input);

        var list = data.output.damageTaken.filter(creature);

        Assert.Equal(totalDamage, list.totalDamage);
        Assert.Equal(qty, list.Count);

    }


}