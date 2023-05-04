using app.util;

namespace app.data;

public class DataCreatureList : List<DataCreature>
{

    public int totalDamage => GetTotalDamage();

    public void AddPlayerDamage(DataPlayerLostPowerByCreature data)
    {     
        Add(new DataCreature(data.creature, data.points));
    }

    public void AddCreatureDamage(DataCreatureLostPower data)
    {     
        Add(new DataCreature(data.creature, data.points));
    }

    public DataCreatureList filter(string creature)
    {

        var list = new DataCreatureList();

        foreach (DataCreature item in this)
        {
            if (Text.IsMatch(item.creature, creature))
                list.Add(item);
        }

        return list;
    }

    private int GetTotalDamage()
    {
        var total = 0;

        foreach (DataCreature item in this)
        {
            total += item.damage;
        }

        return total;
    }

}
public class DataCreature
{

    public string creature;
    public int damage;

    public DataCreature(string creature, int damage)
    {
        this.creature = creature;
        this.damage = damage;
    }

}