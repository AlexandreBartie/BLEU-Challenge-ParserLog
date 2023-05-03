using app.core;
using app.log;
using app.data;

namespace app.total;

public abstract class DataTotalModel
{
    private readonly TotalLog total;

    private TypeLog type;

    public RecordsLog logs => total.logs.filter(type);

    public DataOutput output => total.output;

    public int count => logs.Count;

    public DataTotalModel(TotalLog total, TypeLog type)
    {
        this.total = total;

        this.type = type;
    }

    public abstract void SumData();

}