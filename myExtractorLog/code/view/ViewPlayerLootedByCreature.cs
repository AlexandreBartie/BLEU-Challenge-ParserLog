using app.core;
using app.log;
using app.list;
using app.view.model;

namespace app.view;

public class ViewPlayerLootedByCreature : ViewModelGeneric
{
    public ViewPlayerLootedByCreature(ParseView view) : base(view, TypeLog.eLogGamePlayerLootedByCreature) { }

    public LootList loot = new();

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            loot.AddList(log.dataPlayerLootedByCreature.list);
        }
    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, loot.total, count);
    }

}