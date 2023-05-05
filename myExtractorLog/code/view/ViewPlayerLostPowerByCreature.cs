using app.log;
using app.data;
using app.util;

namespace app.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{
    public ViewPlayerLostPowerByCreature(DataView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) {}
}

// public class ViewPlayerLostPowerByCreature : ViewModel
// {
//     public ViewPlayerLostPowerByCreature(DataView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }

//     public ViewCreatureList list = new();

//     public int totalDamage => list.totalDamage;

//     public override void SumData()
//     {
//         list = new ViewCreatureList();

//         foreach (RecordLog log in logs)
//         {
//             list.AddPlayerDamage(log.dataPlayerLostPowerByCreature);
//         }
//     }

//     public override string log(string label)
//     {

//         var memo = new Memo();

//         memo.add($"{label}: {totalDamage} points #{count}");

//         memo.add(list.log(label.Length));

//         return memo.txt;

//     }

// }