using app.core;

namespace myappxunit;

public class UT04_CreatureLogTest
{
    private string input = "";

    private ParseLog parse = new();

    [Theory]
    [InlineData("rat", 20, 1)]
    [InlineData("cyclops", 520, 2)]
    [InlineData("cyclops smith", 435, 2)]
    [InlineData("skeleton", 50, 1)]
    [InlineData("spider", 20, 1)]
    [InlineData("dragon", 1018, 3)]
    [InlineData("dwarf", 90, 1)]
    [InlineData("dwarf soldier", 135, 1)]
    public void TST01_CreatureHealedPower(string name, int total, int qty)
    {

        string input = "CreatureLostPower.txt";

        parse.LoadFile(input);

        var creature = parse.CreatureLostPower.group.filter(name);

        Assert.Equal(total, creature.total);
        Assert.Equal(qty, creature.Count);

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
    public void TST01_CreatureLostPower(string name, int totalDamage, int qty)
    {

        string input = "CreatureLostPower.txt";

        parse.LoadFile(input);

        var creature = parse.CreatureLostPower.group.filter(name);

        Assert.Equal(totalDamage, creature.total);
        Assert.Equal(qty, creature.Count);

    }

    [Theory]
    [InlineData("cyclops, cyclops smith, dragon, dwarf soldier, ghoul")]
    public void TST02_CreatureGroup_ByPlayerLostPower(string creatures)
    {

        string input = "PlayerLostPower.txt";

        parse.LoadFile(input);

        var group = parse.PlayerLostPower.byCreature.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

    [Theory]
    [InlineData("dragon, dragon lord")]
    public void TST03_CreatureGroup_ByCreatureHealedPower(string creatures)
    {

        string input = "CreatureHealedPower.txt";

        parse.LoadFile(input);

        var group = parse.CreatureHealedPower.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

    [Theory]
    [InlineData("cyclops, cyclops smith, dragon, dwarf, dwarf soldier, rat, skeleton, spider")]
    public void TST04_CreatureGroup_ByCreatureLostPower(string creatures)
    {

        string input = "CreatureLostPower.txt";

        parse.LoadFile(input);

        var group = parse.CreatureLostPower.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

    [Theory]
    [InlineData("*cyclo*", "cyclops, cyclops smith")]
    [InlineData("*black*", "Black Knight")]
    [InlineData("dragon*, dwarf", "dragon, dragon lord, dwarf, dwarf soldier")]
    public void TST05_CreatureGroup_ByCreatureSpotlight(string rules, string creatures)
    {


        string input = "CreatureSpotlight.txt";

        parse.SetSpotlight(rules);

        parse.LoadFile(input);

        var list = parse.CreatureSpotlight.creatures;

        Assert.Equal(creatures, list.txt);

    }


}