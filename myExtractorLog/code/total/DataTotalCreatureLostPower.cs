using app.core;
using app.log;

namespace app.total;

public class DataTotalCreatureLostPower : DataTotalModel
{
    public DataTotalCreatureLostPower(TotalLog total) : base(total, TypeLog.eLogGameCreatureLostPower) { }

    public override void SumData()
    {

        output. = 0;

        foreach (RecordLog log in logs)
        {
            output.damageTaken.unknown += log.dataCreatureLostPower.points;
        }

    }

}