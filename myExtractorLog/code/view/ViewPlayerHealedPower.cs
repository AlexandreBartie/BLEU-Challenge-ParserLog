using app.core;
using app.log;
using app.view.model;

namespace app.view;

public class ViewPlayerHealedPower : ViewModelGeneric
{
    public ViewPlayerHealedPower(ParseView view) : base(view, TypeLog.eLogGamePlayerHealedPower) { }

    public int totalHealed;

    public override void SumData()
    {

        totalHealed = 0;

        foreach (RecordLog log in logs)
        {
            totalHealed += log.dataPlayerHealedPower.points;
        }
    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, totalHealed, count);
    }

}