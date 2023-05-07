using app.core;

namespace myappxunit;

public class UT03_PlayerLogTest
{

    private string input = "";

    private ParseLog parse = new();

    [Theory]
    [InlineData(957, 5)]
    public void TST01_PlayerHealedPower(int damage, int qty)
    {

        input = "PlayerHealedPower.txt";

        parse.LoadFile(input);

        Assert.Equal(damage, parse.PlayerHealedPower.totalHealed);
        Assert.Equal(qty, parse.PlayerHealedPower.count);

    }

    [Theory]
    [InlineData(12, 332, 12)]
    public void TST02_PlayerLostPower(int unknown, int total, int qty)
    {

        input = "PlayerLostPower.txt";

        parse.LoadFile(input);

        Assert.Equal(unknown, parse.PlayerLostPower.byUnknown.totalDamage);
        Assert.Equal(total, parse.PlayerLostPower.totalDamage);
        Assert.Equal(qty, parse.PlayerLostPower.count);

    }

    [Theory]
    [InlineData(697, 6)]
    public void TST03_PlayerGainedExperience(int damage, int qty)
    {

        input = "PlayerGainedExperience.txt";

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
    public void TST04_PlayerLostPowerByCreature(string creature, int totalDamage, int qty)
    {

        string input = "PlayerLostPower.txt";

        parse.LoadFile(input);

        var listLog = parse.PlayerLostPower.byCreature.list.filter(creature);

        Assert.Equal(totalDamage, listLog.totalDamage);
        Assert.Equal(qty, listLog.count);

    }

}