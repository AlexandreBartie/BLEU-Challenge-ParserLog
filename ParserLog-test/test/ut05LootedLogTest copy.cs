using parser;

namespace myappxunit;

public class UT04_LootedLogTest
{
    string input = "PlayerLootedByCreature.txt";

    private ParserLog parser = new();

    [Theory]
    [InlineData("crossbow, cyclops toe, dragon ham, gold coins, green dragon leather, letter, meat, plate legs, small diamond, steel helmet, steel shield")]
    public void TST01_LootedList(string creatures)
    {

        parser.LoadFile(input);

        var list = parser.PlayerLootedByCreature.loot.items;

        Assert.Equal(creatures, list.txt);

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
    public void TST02_LootedItem(string item, int total, int count)
    {

        parser.LoadFile(input);

        var list = parser.PlayerLootedByCreature.loot.filter(item);

        Assert.Equal(total, list.total);
        Assert.Equal(count, list.count);

    }

    public void TSTXX_TotalExtraCreature(int damage, int qty)
    {

        input = "PlayerGainedExperience.txt";

        parser.LoadFile(input);

        Assert.Equal(damage, parser.PlayerGainedExperience.totalExperience);
        Assert.Equal(qty, parser.PlayerGainedExperience.count);

    }


}