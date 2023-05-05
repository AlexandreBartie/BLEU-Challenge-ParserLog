using app.data;
using app.log;

namespace app.total;

public class ViewPlayerGainedExperience : ViewModel
{
    public ViewPlayerGainedExperience(DataView view) : base(view, TypeLog.eLogGamePlayerGainedExperience) { }

    public int totalExperience;

    public override void SumData()
    {

        totalExperience = 0;

        foreach (RecordLog log in logs)
        {
            totalExperience += log.dataPlayerGainedExperience.points;
        }
    }

    public override string log(string label)
    {
        return $"{label}: {totalExperience} points #{count}";
    }

}