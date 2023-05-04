using app.log;

namespace app.total;

public class TotalPlayerLostPower : TotalModel
{
    public TotalPlayerLostPower(TotalBoard total) : base(total, TypeLog.eLogGamePlayerLostPower) { }

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