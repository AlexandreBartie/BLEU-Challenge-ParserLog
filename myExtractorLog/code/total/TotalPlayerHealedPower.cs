using app.log;
using app.data;

namespace app.total;

public class TotalPlayerHealedPower : TotalModel
{
    public TotalPlayerHealedPower(DataBoard board) : base(board, TypeLog.eLogGamePlayerHealedPower) { }

    public override void SumData()
    {

        view.hitpointsHealed = 0;

        foreach (RecordLog log in logs)
        {
            view.hitpointsHealed += log.dataPlayerHealedPower.points;
        }
    }

    public override string log(string label)
    {
        return $"{label}: {view.hitpointsHealed} points #{count}";
    }

}