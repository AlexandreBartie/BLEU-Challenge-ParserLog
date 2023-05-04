using app.log;

namespace app.total;

public class TotalPlayerLootedByCreature : TotalModel
{
    public TotalPlayerLootedByCreature(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLootedByCreature) { }

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            view.loot.AddList(log.dataPlayerLootedByCreature.list);
        }
    }

    public override string log(string label)
    {
        return $"{label}: {view.loot.total} points #{count}";
    }

}