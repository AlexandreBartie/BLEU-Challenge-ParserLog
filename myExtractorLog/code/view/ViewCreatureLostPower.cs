using app.log;
using app.data;
using app.view;

namespace app.total;

public class ViewCreatureLostPower : ViewModel
{
    public ViewCreatureLostPower(DataView view) : base(view, TypeLog.eLogGameCreatureLostPower) { }

    public ViewCreatureList list = new();

    public override void SumData()
    {

        foreach (RecordLog log in logs)
        {
            list.AddCreatureDamage(log.dataCreatureLostPower);
        }

    }

    public override string log(string label)
    {
        return $"{label}: {list.totalDamage} points #{count}";
    }

}