using app.log;
using app.data;

namespace app.total;

public class TotalPlayerLootedByCreature : TotalModel
{
    public TotalPlayerLootedByCreature(DataBoard board) : base(board, TypeLog.eLogGamePlayerLootedByCreature) { }

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