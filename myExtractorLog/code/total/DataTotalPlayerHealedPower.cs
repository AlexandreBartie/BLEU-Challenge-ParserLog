using app.core;
using app.log;

namespace app.total;

public class DataTotalPlayerHealedPower : DataTotalModel
{
    public DataTotalPlayerHealedPower(TotalLog total) : base(total, TypeLog.eLogGamePlayerHealedPower) { }

    public override void SumData()
    {

        output.hitpointsHealed = 0;

        foreach (RecordLog log in logs)
        {
            output.hitpointsHealed += log.dataPlayerHealedPower.points;
        }
    }

}