using app.core;
using app.log;
using app.model;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{

    public int totalDamage => group.total;

    public ViewPlayerLostPowerByCreature(ViewData view) : base(view, TypeLog.eLogPlayerLostPowerByCreature) { }

}