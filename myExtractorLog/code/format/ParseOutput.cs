using app.core;
using app.util;

namespace app.format;

public class ParseOutput
{

    private ParseLog parse;

    public string txt => getTXT();

    public ParseOutput(ParseLog parse)
    {
        this.parse = parse;
    }
    private string getTXT()
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