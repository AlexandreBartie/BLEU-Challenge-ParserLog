using app.core;
using app.log;
using app.util;

namespace app.view;

public abstract class ViewModelCreatureList : ViewModel
{
    public ViewModelCreatureList(ParseView view, TypeLog type) : base(view, type)
    { list = new ViewCreatureList(type); }

    public ViewCreatureList list;

    public int totalDamage => list.totalDamage;

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            list.AddDamage(log);
        }

    }

    public override string log(string label)
    {

        var memo = new Memo();

        memo.add($"{label}: {totalDamage} points #{count}");

        return memo.txt;
    }

}