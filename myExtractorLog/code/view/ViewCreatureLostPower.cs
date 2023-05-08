using app.core;
using app.log;
using app.model;

namespace app.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(ViewData view) : base(view, TypeLog.eLogCreatureLostPower) { }
}