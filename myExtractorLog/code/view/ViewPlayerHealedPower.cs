using app.log;

namespace app.view;

public class ViewPlayerHealedPower : ViewModel
{
    public ViewPlayerHealedPower(ViewData view) : base(view, TypeLog.eLogGamePlayerHealedPower) { }

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
        return $"{label}: {totalHealed} points #{count}";
    }

}