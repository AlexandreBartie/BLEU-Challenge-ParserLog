using app.data;
using app.log;
using app.list;

namespace app.view;

public class ViewPlayerLootedByCreature : ViewModel
{
    public ViewPlayerLootedByCreature(DataView view) : base(view, TypeLog.eLogGamePlayerLootedByCreature) { }

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
        return $"{label}: {loot.total} points #{count}";
    }

}