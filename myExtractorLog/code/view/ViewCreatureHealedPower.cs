using app.core;
using app.log;
using app.model;

namespace app.view;

public class ViewCreatureHealedPower : ViewModelCreatureList
{
    public ViewCreatureHealedPower(ParseView view) : base(view, TypeLog.eLogCreatureHealedPower) { }
}