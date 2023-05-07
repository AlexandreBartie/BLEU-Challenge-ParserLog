using app.core;
using app.log;
using app.model;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelListCreature
{

    public int totalDamage => list.total;

    public ViewPlayerLostPowerByCreature(ParseView view) : base(view, TypeLog.eLogPlayerLostPowerByCreature) { }

}