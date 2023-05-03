using app.core;
using app.log;

namespace app.data;

public abstract class DataTotalModel
{
    public readonly TotalLog total;

    private TypeLog type;

    public RecordsLog logs => total.logs.filter(type);

    public int count => logs.Count;

    public DataTotalModel(TotalLog total, TypeLog type)
    {
        this.total = total;

        this.type = type;
    }

}