using app.util;

namespace app.core;

public class ParseExport
{

    private ParseLog parse;

    public string output => getOutput();

    public ParseExport(ParseLog parse)
    {
        this.parse = parse;
    }
    private string getOutput()
    {

        if (!parse.isNull)
        {

            var memo = new Memo();

            memo.add(totalLog(SizePattern("Total")));
            memo.add(parse.viewPlayerGainedExperience.log(SizePattern("Experience")));
            memo.add(parse.viewPlayerHealedPower.log(SizePattern("HealedPower")));
            memo.add(parse.viewPlayerLostPower.log(SizePattern("LostPower")));
            memo.add(parse.viewPlayerLostPower.byUnknown.log(SizePattern("-unknown")));
            memo.add(parse.viewPlayerLostPower.byCreature.log(SizePattern("-byCreature")));
            memo.add(parse.viewPlayerLootedByCreature.log(SizePattern("LootedByCreature")));
            memo.add(parse.viewCreatureLostPower.log(SizePattern("CreatureLostPower")));

            return (memo.txt);
        }

        return "";

    }
    private string totalLog(string label)
    {
        return $"{label}: {parse.logs.Count()} logs #{parse.sessions.Count()}";
    }

    private string SizePattern(string label)
    {
        return label.PadLeft(25);
    }

}