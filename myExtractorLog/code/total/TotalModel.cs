using app.log;
using app.data;

namespace app.total;

public abstract class TotalModel
{
    private readonly DataBoard board;

    private TypeLog type;

    public RecordsLog logs => board.logs.filter(type);

    public DataView view => board.view;

    public int count => logs.Count;

    public TotalModel(DataBoard board, TypeLog type)
    {
        this.board = board;

        this.type = type;
    }

    public abstract void SumData();

    public abstract string log(string label);

}