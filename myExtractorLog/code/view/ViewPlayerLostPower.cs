using app.data;

namespace app.total;

public class ViewPlayerLostPower
{
    public readonly ViewPlayerLostPowerByUnknown byUnknown;
    public readonly ViewPlayerLostPowerByCreature byCreature;

    public int count => byUnknown.count + byCreature.count;

    public int totalDamage => byUnknown.totalDamage + byCreature.totalDamage;

    public ViewPlayerLostPower(DataView view)
    {
        byUnknown = new ViewPlayerLostPowerByUnknown(view);
        byCreature = new ViewPlayerLostPowerByCreature(view);
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