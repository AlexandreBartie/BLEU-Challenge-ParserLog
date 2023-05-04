using app.core;
using app.log;

namespace app.total;

public class DataTotalPlayerLostPower : DataTotalModel
{
    public DataTotalPlayerLostPower(TotalLog total) : base(total, TypeLog.eLogGamePlayerLostPower) { }

    public override void SumData()
    {

        output.damageTaken.unknown = 0;

        foreach (RecordLog log in logs)
        {
            output.damageTaken.unknown += log.dataPlayerLostPower.points;
        }

    }

}