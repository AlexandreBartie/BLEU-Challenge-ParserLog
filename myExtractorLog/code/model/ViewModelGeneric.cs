using app.core;
using app.log;

namespace app.model;

public abstract class ViewModelGeneric : ViewModel
{
    public RecordsLog logs => view.logs.filter(type);

    public int count => logs.Count;

    public ViewModelGeneric(ViewData view, TypeLog type) : base(view, type) { }

    public abstract void GroupData();

    public abstract string log(string label);

}