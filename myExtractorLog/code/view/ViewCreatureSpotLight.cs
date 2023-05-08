using app.core;
using app.list;

namespace app.view;
public class ViewCreatureSpotLight
{
    private ViewData view;

    private string rules = "";

    public CreatureList creatures => GetCreatures();


    public ViewCreatureSpotLight(ViewData view)
    {
        this.view = view;
    }

    public void Setup(string rules)
    {
        this.rules = rules;
    }

    public CreatureList GetCreatures()
    {

        var list = new CreatureList();

        list.AddList(view.CreatureHealedPower.creatures.Filter(rules));
        list.AddList(view.CreatureLostPower.creatures.Filter(rules));
        list.AddList(view.PlayerLostPower.byCreature.creatures.Filter(rules));

        return list;

    }

    public string log()
    {
        return " need to fill this line"; //view.GetLogPoints(label, totalDamage, count);
    }


}