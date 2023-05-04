using app.log;
using app.data;

namespace app.total;

public abstract class TotalModel
{
    private readonly TotalBoard total;

    private TypeLog type;

    public RecordsLog logs => total.logs.filter(type);

    public DataView view => total.view;

    public int count => logs.Count;

    public TotalModel(TotalBoard total, TypeLog type)
    {
        this.total = total;

        this.type = type;
    }

    public abstract void SumData();

    public abstract string log(string label);

}