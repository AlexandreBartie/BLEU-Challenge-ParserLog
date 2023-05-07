using app.core;
using app.list;
using app.log;
using app.util;

namespace app.data;

public class DataCreatureList : List<DataCreature>
{

    public readonly ParseView view;

    public readonly TypeLog type;

    public CreatureList creatures => GetCreatures();

    public int totalDamage => GetTotalDamage();

    public int count => this.Count;

    public DataCreatureList(ParseView view, TypeLog type)
    {
        this.view = view;
        this.type = type;
    }

    public void AddDamage(RecordLog log)
    {
        if (type == TypeLog.eLogPlayerLostPowerByCreature)
            AddDamage(log.dataPlayerLostPowerByCreature);

        if (type == TypeLog.eLogCreatureLostPower)
            AddDamage(log.dataCreatureLostPower);

    }

    private void AddDamage(ILogCreaturePoints data)
    {
        Add(new DataCreature(data.creature, data.points));
    }

    public DataCreatureList filter(string creature)
    {

        var list = new DataCreatureList(view, type);

        foreach (DataCreature item in this)
        {
            if (Text.IsMatch(item.creature, creature))
                list.Add(item);
        }

        return list;
    }

    private CreatureList GetCreatures()
    {

        var list = new CreatureList();

        foreach (DataCreature item in this)
        {
            list.AddItem(item.creature);
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

    public string log()
    {

        var memo = new Memo();

        foreach (Creature item in creatures.OrderBy(item => item.name))
        {
            var creature = item.name;

            var list = filter(creature);

            var log = view.GetLogPoints(creature, list.totalDamage, list.count, 3);

            memo.Add(log);
        }

        return memo.txt;

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