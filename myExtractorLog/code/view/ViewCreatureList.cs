using app.data;
using app.list;
using app.util;

namespace app.view;

public class ViewCreatureList : List<ViewCreatureItem>
{

    public CreatureList creatures => GetCreatures();

    public int totalDamage => GetTotalDamage();

    public int count => this.Count;

    public void AddPlayerDamage(DataPlayerLostPowerByCreature data)
    {
        Add(new ViewCreatureItem(data.creature, data.points));
    }

    public void AddCreatureDamage(DataCreatureLostPower data)
    {
        Add(new ViewCreatureItem(data.creature, data.points));
    }

    public ViewCreatureList filter(string creature)
    {

        var list = new ViewCreatureList();

        foreach (ViewCreatureItem item in this)
        {
            if (Text.IsMatch(item.creature, creature))
                list.Add(item);
        }

        return list;
    }

    private CreatureList GetCreatures()
    {

        var list = new CreatureList();

        foreach (ViewCreatureItem item in this)
        {
            list.AddItem(item.creature);
        }

        return list;

    }

    private int GetTotalDamage()
    {
        var total = 0;

        foreach (ViewCreatureItem item in this)
        {
            total += item.damage;
        }

        return total;
    }

}
public class ViewCreatureItem
{

    public string creature;
    public int damage;

    public ViewCreatureItem(string creature, int damage)
    {
        this.creature = creature;
        this.damage = damage;
    }

}