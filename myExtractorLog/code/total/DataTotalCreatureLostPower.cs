using app.core;
using app.log;

namespace app.total;

public class DataTotalCreatureLostPower : DataTotalModel
{
    public DataTotalCreatureLostPower(TotalLog total) : base(total, TypeLog.eLogGameCreatureLostPower) { }

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            output.creaturesBoard.lostPower.AddCreatureDamage(log.dataCreatureLostPower);
        }

    }

}