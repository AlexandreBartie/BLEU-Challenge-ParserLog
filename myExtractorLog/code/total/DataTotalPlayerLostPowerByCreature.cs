using app.core;
using app.log;

namespace app.total;

public class DataTotalPlayerLostPowerByCreature : DataTotalModel
{
    public DataTotalPlayerLostPowerByCreature(TotalLog total) : base(total, TypeLog.eLogGamePlayerLostPowerByCreature) { }

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            output.damageTaken.AddDamage(log.dataPlayerLostPowerByCreature);
        }
    }

}