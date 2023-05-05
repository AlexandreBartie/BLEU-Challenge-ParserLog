using app.data;
using app.list;
using app.log;
using app.util;

namespace app.view;

public class ViewCreatureList : List<ViewCreatureItem>
{

    private TypeLog type;

    public CreatureList creatures => GetCreatures();

    public int totalDamage => GetTotalDamage();

    public int count => this.Count;

    public ViewCreatureList(TypeLog type)
    { this.type = type; }

    public void AddDamage(RecordLog log)
    {
        if (type == TypeLog.eLogGamePlayerLostPowerByCreature)
            AddDamage(log.dataPlayerLostPowerByCreature);

        if (type == TypeLog.eLogGameCreatureLostPower)
            AddDamage(log.dataCreatureLostPower);

    }

    private void AddDamage(ParseLogPlayerLostPowerByCreature data)
    {
        Add(new ViewCreatureItem(data.creature, data.points));
    }

    private void AddDamage(ParseLogCreatureLostPower data)
    {
        Add(new ViewCreatureItem(data.creature, data.points));
    }

    public ViewCreatureList filter(string creature)
    {

        var list = new ViewCreatureList(type);

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

    public string log(int tab)
    {

        var memo = new Memo();

        foreach (Creature item in creatures)
        {
            var creature = item.name;

            var list = filter(creature);

            memo.Add($"{Text.Tab(tab)}{creature}: {list.totalDamage} points #{list.count}");
        }

        return memo.txt;

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