using app.core;
using app.list;
using app.util;

namespace app.view;
public class ViewCreatureSpotlight
{
    private ViewData view;

    private string rules = "";

    private CreatureList _creatures = new();

    public bool HasCreatures => (creatures.Count > 0);

    public CreatureList creatures => _creatures;


    public ViewCreatureSpotlight(ViewData view)
    {
        this.view = view;
    }

    public void Setup(string rules)
    {
        this.rules = rules;
    }

    public void GroupData()
    {

        var list = new CreatureList();

        list.AddList(view.CreatureHealedPower.creatures.Match(rules));
        list.AddList(view.CreatureLostPower.creatures.Match(rules));
        list.AddList(view.PlayerLostPower.byCreature.creatures.Match(rules));

        _creatures = list;

    }

    public string log()
    {

        var memo = new Memo();
        
        foreach (Creature item in creatures.OrderBy(item => item.name))
        {
            var creature = item.name;

            var healedPower = view.CreatureHealedPower.group.filter(creature).total;
            var lostPower = view.CreatureLostPower.group.filter(creature).total;

            var damagePlayer = view.PlayerLostPower.byCreature.group.filter(creature).total;

            var log = view.GetSpotlight(creature, healedPower, lostPower, damagePlayer);

            memo.Add(log);
        }

        return memo.txt;
    }


}