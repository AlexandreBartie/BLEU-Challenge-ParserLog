using app.log;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(ViewData view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }
}