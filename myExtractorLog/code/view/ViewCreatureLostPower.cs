using app.core;
using app.log;
using app.view.model;

namespace app.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(ParseView view) : base(view, TypeLog.eLogGameCreatureLostPower) { }
}