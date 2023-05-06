using app.core;
using app.model;
namespace app.view;


public class ViewPlayerLostPower
{
    private ParseView view;

    public readonly ViewPlayerLostPowerByUnknown byUnknown;
    public readonly ViewPlayerLostPowerByCreature byCreature;

    public int count => byUnknown.count + byCreature.count;

    public int totalDamage => byUnknown.totalDamage + byCreature.totalDamage;

    public ViewPlayerLostPower(ParseView view)
    {
        this.view = view;
        
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
        return view.GetLogPoints(label, totalDamage, count);
    }


}