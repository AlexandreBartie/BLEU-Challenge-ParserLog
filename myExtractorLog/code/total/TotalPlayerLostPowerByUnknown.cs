using app.log;

namespace app.total;

public class TotalPlayerLostPowerByUnknown : TotalModel
{
    public TotalPlayerLostPowerByUnknown(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLostPowerByUnknown) { }

    public override void SumData()
    {

        view.damageTaken.unknown = 0;

        foreach (RecordLog log in logs)
        {
            view.damageTaken.unknown += log.dataPlayerLostPower.points;
        }

    }

    public override string log(string label)
    {
        return $"{label}: {view.damageTaken.unknown} points #{count}";
    }

}