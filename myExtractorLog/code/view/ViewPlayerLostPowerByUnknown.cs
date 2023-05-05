using app.data;
using app.log;

namespace app.view;

public class ViewPlayerLostPowerByUnknown : ViewModel
{
    public ViewPlayerLostPowerByUnknown(DataView view) : base(view, TypeLog.eLogGamePlayerLostPowerByUnknown) { }

    public int totalDamage = 0;

    public override void SumData()
    {

        totalDamage = 0;

        foreach (RecordLog log in logs)
        {
            totalDamage += log.dataPlayerLostPower.points;
        }

    }

    public override string log(string label)
    {
        return $"{label}: {totalDamage} points #{count}";
    }

}