using app.core;
using app.util;

namespace app.format;

public class ParserOutput
{

    private ParserLog parser;

    public string txt => getTXT();

    public ParserOutput(ParserLog parser)
    {
        this.parser = parser;
    }
    private string getTXT()
    {

        var memo = new Memo();

        if (!parser.isNull)
        {

            memo.add(parser.logTitle("Statistics Player", '=', '-'));
            memo.add(parser.PlayerGainedExperience.log("Experience"));
            memo.add(parser.PlayerHealedPower.log("HealedPower"));
            memo.add(parser.PlayerLostPower.log("LostPower"));
            memo.add(parser.PlayerLostPower.byUnknown.log("unknown"));
            memo.add(parser.PlayerLostPower.byCreature.log("byCreature"));
            memo.add(parser.PlayerLootedByCreature.log("LootedByCreature"));
            memo.add(parser.logTitle("Statistics Creature", '-', '-'));
            memo.add(parser.CreatureHealedPower.log("HealedPower"));
            memo.add(parser.CreatureLostPower.log("LostPower"));
            if (parser.CreatureSpotlight.HasCreatures)
            {
                memo.add(parser.logSubTitle("Creatures Spotlight", parser.CreatureSpotlight.wildcard));
                memo.add(parser.logColumns());
                memo.add(parser.CreatureSpotlight.log());
            }
            memo.add(parser.logTitle("Statistics based by file log extracted", '-', '='));

        }

        return (memo.txt);

    }


}