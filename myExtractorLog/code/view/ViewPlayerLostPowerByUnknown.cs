using app.core;
using app.log;
using app.view.model;

namespace app.view;

public class ViewPlayerLostPowerByUnknown : ViewModelGeneric
{
    public ViewPlayerLostPowerByUnknown(ParseView view) : base(view, TypeLog.eLogGamePlayerLostPowerByUnknown) { }

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
        return view.GetLogPoints(label, totalDamage, count);
    }

}