using app.log;
using app.data;

namespace app.total;

public abstract class ViewModel
{
    public readonly DataView view;

    private TypeLog type;

    public RecordsLog logs => view.logs.filter(type);

    public int count => logs.Count;

    public ViewModel(DataView view, TypeLog type)
    {
        this.view = view;

        this.type = type;
    }

    public abstract void SumData();

    public abstract string log(string label);

}