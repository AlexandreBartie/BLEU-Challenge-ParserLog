using app.log;
using app.data;
using app.util;

namespace app.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(DataView view) : base(view, TypeLog.eLogGameCreatureLostPower) {}
}

// public class ViewCreatureLostPower : ViewModel
// {
//     public ViewCreatureLostPower(DataView view, TypeLog type) : base(view, type) { }

//     public ViewCreatureList list = new();

//     public int totalDamage => list.totalDamage;

//     public override void SumData()
//     {

//         foreach (RecordLog log in logs)
//         {
//             list.AddCreatureDamage(log.dataCreatureLostPower);
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