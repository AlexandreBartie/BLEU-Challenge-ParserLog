using app.log;

namespace app.total;

public class TotalPlayerHealedPower : TotalModel
{
    public TotalPlayerHealedPower(TotalBoard total) : base(total, TypeLog.eLogGamePlayerHealedPower) { }

    public override void SumData()
    {

        output.hitpointsHealed = 0;

        foreach (RecordLog log in logs)
        {
            output.hitpointsHealed += log.dataPlayerHealedPower.points;
        }
    }

}