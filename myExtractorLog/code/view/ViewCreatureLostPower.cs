using app.log;
using app.data;

namespace app.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(ViewData view) : base(view, TypeLog.eLogGameCreatureLostPower) { }
}