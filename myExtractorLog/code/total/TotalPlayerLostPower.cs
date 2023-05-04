namespace app.total;

public class TotalPlayerLostPower
{
    
    public readonly TotalPlayerLostPowerByUnknown byUnknown;
    public readonly TotalPlayerLostPowerByCreature byCreature;

    public int count => byUnknown.count + byCreature.count;

    public int totalDamage => byUnknown.totalDamage + byCreature.totalDamage;

    public TotalPlayerLostPower(TotalBoard total)
    {
        byUnknown = new TotalPlayerLostPowerByUnknown(total);
        byCreature = new TotalPlayerLostPowerByCreature(total);
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