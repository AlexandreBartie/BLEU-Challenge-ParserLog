using app.log;

namespace app.total;

public class TotalPlayerLostPowerByCreature : TotalModel
{
    public TotalPlayerLostPowerByCreature(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLostPowerByCreature) { }

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            output.damageTaken.byCreature.AddPlayerDamage(log.dataPlayerLostPowerByCreature);
        }
    }

}