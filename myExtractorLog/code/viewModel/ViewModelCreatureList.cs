using app.core;
using app.log;
using app.data;

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
        return view.GetLogPoints(label, totalDamage, count);
    }

}