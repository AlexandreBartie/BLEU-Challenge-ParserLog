using app.log;

namespace app.total;

public class TotalPlayerLostPowerByCreature : TotalModel
{
    public TotalPlayerLostPowerByCreature(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLostPowerByCreature) { }

    public int totalDamage => view.damageTaken.byCreature.totalDamage;

    public override void SumData()
    {
        foreach (RecordLog log in logs)
        {
            view.damageTaken.byCreature.AddPlayerDamage(log.dataPlayerLostPowerByCreature);
        }
    }

    public override string log(string label)
    {
        return $"{label}: {totalDamage} points #{count}";
    }

}