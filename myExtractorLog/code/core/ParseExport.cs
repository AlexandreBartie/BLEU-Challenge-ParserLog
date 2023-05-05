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

            memo.add(totalLog("Total"));
            memo.add(parse.PlayerGainedExperience.log("Experience"));
            memo.add(parse.PlayerHealedPower.log("HealedPower"));
            memo.add(parse.PlayerLostPower.log("LostPower"));
            memo.add(parse.PlayerLostPower.byUnknown.log("-unknown"));
            memo.add(parse.PlayerLostPower.byCreature.log("-byCreature"));
            memo.add(parse.PlayerLootedByCreature.log("LootedByCreature"));
            memo.add(parse.CreatureLostPower.log("CreatureLostPower"));

            return (memo.txt);
        }

        return "";

    }

    private string totalLog(string label)
    {
        return parse.GetLogRecords(label, parse.logs.Count(), parse.sessions.Count());
    }


}