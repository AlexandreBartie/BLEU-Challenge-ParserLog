using app.core;
using app.log;

namespace app.total;

public class DataTotalPlayerLostPower : DataTotalModel
{
    public DataTotalPlayerLostPower(TotalLog total) : base(total, TypeLog.eLogPlayerLostPower) {}

    public override void SumData()
    {

        output.damageTaken.total = 0;

        foreach (RecordLog log in logs)
        {
            output.damageTaken.total += output.damageTaken.total + log.dataPlayerLostPower.points;
        }
    }

}