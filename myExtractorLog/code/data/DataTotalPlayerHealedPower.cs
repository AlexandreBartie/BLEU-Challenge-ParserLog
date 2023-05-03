using app.core;
using app.log;
namespace app.data;

public class DataTotalPlayerHealedPower : DataTotalModel
{
    public DataPlayerHealedPower board;

    public DataTotalPlayerHealedPower(TotalLog total) : base(total, TypeLog.eLogPlayerHealedPower) {}

    public void SumData()
    {

        board.points = 0;

        foreach (RecordLog log in logs)
        {
            board.points = board.points + log.GetPlayerHealedPower().points;
        }
    }

}