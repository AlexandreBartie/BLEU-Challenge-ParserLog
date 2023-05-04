using app.log;

namespace app.total;

public class TotalPlayerLootedByCreature : TotalModel
{
    public TotalPlayerLootedByCreature(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLootedByCreature) { }

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            output.loot.AddList(log.dataPlayerLootedByCreature.list);
        }
    }

}