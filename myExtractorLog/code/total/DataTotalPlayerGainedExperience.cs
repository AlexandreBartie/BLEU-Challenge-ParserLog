using app.core;
using app.log;

namespace app.total;

public class DataTotalPlayerGainedExperience : DataTotalModel
{
    public DataTotalPlayerGainedExperience(TotalLog total) : base(total, TypeLog.eLogGamePlayerGainedExperience) { }

    public override void SumData()
    {

        output.experienceGained = 0;

        foreach (RecordLog log in logs)
        {
            output.experienceGained += log.dataPlayerGainedExperience.points;
        }
    }

}