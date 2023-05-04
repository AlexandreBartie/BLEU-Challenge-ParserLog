using app.log;

namespace app.total;

public class TotalPlayerGainedExperience : TotalModel
{
    public TotalPlayerGainedExperience(TotalBoard total) : base(total, TypeLog.eLogGamePlayerGainedExperience) { }

    public override void SumData()
    {

        output.experienceGained = 0;

        foreach (RecordLog log in logs)
        {
            output.experienceGained += log.dataPlayerGainedExperience.points;
        }
    }

}