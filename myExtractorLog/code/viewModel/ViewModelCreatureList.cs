using app.core;
using app.log;
using app.data;
using app.util;

namespace app.view.model;

public abstract class ViewModelCreatureList : ViewModelGeneric
{

    public DataCreatureList list;

    public int totalDamage => list.totalDamage;

    public ViewModelCreatureList(ParseView view, TypeLog type) : base(view, type)
    { list = new DataCreatureList(view, type); }

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

        memo.add(view.GetLogPoints(label, totalDamage, count, 2));

        memo.add(list.log());
        
        return memo.txt;
    }

}