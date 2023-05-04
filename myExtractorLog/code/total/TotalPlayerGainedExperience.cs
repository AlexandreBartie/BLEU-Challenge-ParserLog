using app.log;

namespace app.total;

public class TotalPlayerGainedExperience : TotalModel
{
    public TotalPlayerGainedExperience(TotalBoard total) : base(total, TypeLog.eLogGamePlayerGainedExperience) { }

    public override void SumData()
    {

        view.experienceGained = 0;

        foreach (RecordLog log in logs)
        {
            view.experienceGained += log.dataPlayerGainedExperience.points;
        }
    }

    public override string log(string label)
    {
        return $"{label}: {view.experienceGained} points #{count}";
    }    

}