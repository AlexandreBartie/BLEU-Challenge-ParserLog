using app.log;

namespace app.view;

public abstract class ViewModel
{
    public readonly ViewData view;

    public readonly TypeLog type;

    public RecordsLog logs => view.logs.filter(type);

    public int count => logs.Count;

    public ViewModel(ViewData view, TypeLog type)
    {
        this.view = view;

        this.type = type;
    }

    public abstract void SumData();

    public abstract string log(string label);

}