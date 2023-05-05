using app.log;
using app.data;
using app.view;
using app.util;
using app.list;

namespace app.total;

public class ViewPlayerLostPowerByCreature : ViewModel
{
    public ViewPlayerLostPowerByCreature(DataView view) : base(view, TypeLog.eLogGamePlayerLostPowerByCreature) { }

    public ViewCreatureList list = new();

    public int totalDamage => list.totalDamage;

    public override void SumData()
    {
        list = new ViewCreatureList();

        foreach (RecordLog log in logs)
        {
            list.AddPlayerDamage(log.dataPlayerLostPowerByCreature);
        }
    }

    public override string log(string label)
    {
        
        var memo = new Memo();
        
        memo.Add($"{label}: {totalDamage} points #{count}");

        foreach (Creature item in list.creatures)
        {
            var creature = item.name;
            
            var logs = list.filter(creature);
            
            memo.Add( $"{creature}: {logs.totalDamage} points #{logs.count}");
        }

        return memo.txt;

    }

}