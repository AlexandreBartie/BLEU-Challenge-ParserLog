using app.core;
using app.log;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(ParseView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }
}