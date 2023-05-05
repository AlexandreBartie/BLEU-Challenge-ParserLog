using app.log;
using app.data;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(DataView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }
}