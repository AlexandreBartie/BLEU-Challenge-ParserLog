using app.log;
using app.data;

namespace app.total;

public class TotalCreatureLostPower : TotalModel
{
    public TotalCreatureLostPower(DataBoard board) : base(board, TypeLog.eLogGameCreatureLostPower) { }

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            view.creatures.lostPower.AddCreatureDamage(log.dataCreatureLostPower);
        }

    }

    public override string log(string label)
    {
        return $"{label}: {view.creatures.lostPower.totalDamage} points #{count}";
    }

}