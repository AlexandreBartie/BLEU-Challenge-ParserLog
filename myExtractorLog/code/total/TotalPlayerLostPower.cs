
using app.data;
namespace app.total;

public class TotalPlayerLostPower
{

    public readonly TotalPlayerLostPowerByUnknown byUnknown;
    public readonly TotalPlayerLostPowerByCreature byCreature;

    public int count => byUnknown.count + byCreature.count;

    public int totalDamage => byUnknown.totalDamage + byCreature.totalDamage;

    public TotalPlayerLostPower(DataBoard board)
    {
        byUnknown = new TotalPlayerLostPowerByUnknown(board);
        byCreature = new TotalPlayerLostPowerByCreature(board);
    }

    public void SumData()
    {

        byUnknown.SumData();
        byCreature.SumData();
    }

    public string log(string label)
    {
        return $"{label}: {totalDamage} points #{count}";
    }


}