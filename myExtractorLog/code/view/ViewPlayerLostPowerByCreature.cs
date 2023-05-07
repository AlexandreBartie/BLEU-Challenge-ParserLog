using app.core;
using app.log;
using app.model;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(ParseView view) : base(view, TypeLog.eLogPlayerLostPowerByCreature) { }
}