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
            memo.add(parse.PlayerGainedExperience.log(SizePattern("Experience")));
            memo.add(parse.PlayerHealedPower.log(SizePattern("HealedPower")));
            memo.add(parse.PlayerLostPower.log(SizePattern("LostPower")));
            memo.add(parse.PlayerLostPower.byUnknown.log(SizePattern("-unknown")));
            memo.add(parse.PlayerLostPower.byCreature.log(SizePattern("-byCreature")));
            memo.add(parse.PlayerLootedByCreature.log(SizePattern("LootedByCreature")));
            memo.add(parse.CreatureLostPower.log(SizePattern("CreatureLostPower")));

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