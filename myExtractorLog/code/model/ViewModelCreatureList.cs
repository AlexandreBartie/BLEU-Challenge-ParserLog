using app.core;
using app.log;
using app.data;
using app.util;

namespace app.model;

public abstract class ViewModelListCreature : ViewModelGeneric
{

    public DataListCreature list;

    public ViewModelListCreature(ParseView view, TypeLog type) : base(view, type)
    { list = new DataListCreature(view, type); }

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            list.AddItem(log);
        }

    }

    public override string log(string label)
    {

        var memo = new Memo();

        memo.add(view.GetLogPoints(label, list.total, count, 2));

        memo.add(list.log());

        return memo.txt;
    }

}