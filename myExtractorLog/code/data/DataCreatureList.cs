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

    public int total => GetTotal();

    public int count => this.Count;

    public DataCreatureList(ParseView view, TypeLog type)
    {
        this.view = view;
        this.type = type;
    }

    public void AddItem(RecordLog log)
    {
        if (type == TypeLog.eLogPlayerLostPowerByCreature)
            AddItem(log.dataPlayerLostPowerByCreature);

        if (type == TypeLog.eLogCreatureHealedPower)
            AddItem(log.dataCreatureHealedPower);

        if (type == TypeLog.eLogCreatureLostPower)
            AddItem(log.dataCreatureLostPower);

    }

    private void AddItem(ILogCreaturePoints data)
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

    private int GetTotal()
    {
        var total = 0;

        foreach (DataCreature item in this)
        {
            total += item.points;
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

            var log = view.GetLogPoints(creature, list.total, list.count, 3);

            memo.Add(log);
        }

        return memo.txt;

    }

}

public class DataCreature
{

    public string creature;
    public int points;

    public DataCreature(string creature, int points)
    {
        this.creature = creature;
        this.points = points;
    }

}