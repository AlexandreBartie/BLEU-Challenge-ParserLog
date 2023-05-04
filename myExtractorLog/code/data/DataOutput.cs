using app.util;

namespace app.data;

public class DataOutput
{

    public int hitpointsHealed;
    public DataOutputDamageTaken damageTaken = new();

    public int experienceGained;

    public List<DataOutputLootItem> loot = new();

}

public class DataOutputDamageTaken
{
    public int unknown;

    public int total => unknown + byCreatureKind.totalDamage;
    public DataOutputDamageTakenByCreatureList byCreatureKind = new();

    public void AddDamage(DataPlayerLostPowerByCreature data)
    {     
        byCreatureKind.Add(new DataOutputDamageTakenByCreature(data.creature, data.points));
    }

    public DataOutputDamageTakenByCreatureList filter(string creature)
    {
        return byCreatureKind.filter(creature);
    }

}

public class DataOutputDamageTakenByCreatureList : List<DataOutputDamageTakenByCreature>
{
    public int totalDamage => GetTotalDamage();
    public DataOutputDamageTakenByCreatureList filter(string creature)
    {

        var list = new DataOutputDamageTakenByCreatureList();

        foreach (DataOutputDamageTakenByCreature item in this)
        {
            if (Text.IsMatch(item.creature, creature))
                list.Add(item);
        }

        return list;
    }

    private int GetTotalDamage()
    {
        var total = 0;

        foreach (DataOutputDamageTakenByCreature item in this)
        {
            total += item.damage;
        }

        return total;
    }


}

public class DataOutputDamageTakenByCreature
{

    public string creature;
    public int damage;

    public DataOutputDamageTakenByCreature(string creature, int damage)
    {
        this.creature = creature;
        this.damage = damage;
    }

}

public class DataOutputLootItem
{

    public string item = "";
    public int qty;

}