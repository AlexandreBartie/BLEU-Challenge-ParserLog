using app.log;

namespace app.total;

public class TotalCreatureLostPower : TotalModel
{
    public TotalCreatureLostPower(TotalBoard total) : base(total, TypeLog.eLogGameCreatureLostPower) { }

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            output.creatures.lostPower.AddCreatureDamage(log.dataCreatureLostPower);
        }

    }

}