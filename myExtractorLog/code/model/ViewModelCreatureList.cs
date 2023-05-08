using app.core;
using app.log;
using app.group;
using app.util;

namespace app.model;

public abstract class ViewModelCreatureList : ViewModelGeneric
{

    public GroupCreatureList list;

    public ViewModelCreatureList(ViewData view, TypeLog type) : base(view, type)
    { list = new GroupCreatureList(view, type); }

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