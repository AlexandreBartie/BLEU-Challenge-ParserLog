using app.log;
using app.data;

namespace app.total;

public class TotalPlayerGainedExperience : TotalModel
{
    public TotalPlayerGainedExperience(DataBoard board) : base(board, TypeLog.eLogGamePlayerGainedExperience) { }

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