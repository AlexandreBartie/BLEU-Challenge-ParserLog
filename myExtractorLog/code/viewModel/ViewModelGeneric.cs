using app.core;
using app.log;

namespace app.view.model;

public abstract class ViewModelGeneric : ViewModel
{
    public RecordsLog logs => view.logs.filter(type);

    public int count => logs.Count;

    public ViewModelGeneric(ParseView view, TypeLog type) : base(view, type) {}

    public abstract void SumData();

    public abstract string log(string label);

}