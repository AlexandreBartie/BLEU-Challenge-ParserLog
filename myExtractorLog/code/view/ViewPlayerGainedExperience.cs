using app.core;
using app.log;
using app.view.model;

namespace app.view;

public class ViewPlayerGainedExperience : ViewModelGeneric
{
    public ViewPlayerGainedExperience(ParseView view) : base(view, TypeLog.eLogGamePlayerGainedExperience) { }

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
        return view.GetLogPoints(label, totalExperience, count);
    }

}