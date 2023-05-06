using app.core;
using app.log;
using app.view.model;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(ParseView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }
}