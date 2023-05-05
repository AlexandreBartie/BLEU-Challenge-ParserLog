using app.log;
using app.data;
namespace app.total;

public class TotalPlayerLostPowerByUnknown : TotalModel
{
    public TotalPlayerLostPowerByUnknown(DataBoard board) : base(board, TypeLog.eLogGamePlayerLostPowerByUnknown) { }

    public int totalDamage => view.damageTaken.unknown;

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
        return $"{label}: {totalDamage} points #{count}";
    }

}