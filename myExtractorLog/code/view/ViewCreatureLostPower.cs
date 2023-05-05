using app.log;
using app.data;

namespace app.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(DataView view) : base(view, TypeLog.eLogGameCreatureLostPower) { }
}