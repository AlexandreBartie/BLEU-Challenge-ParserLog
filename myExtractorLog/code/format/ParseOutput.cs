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

        var memo = new Memo();

        if (!parse.isNull)
        {

            memo.add(parse.logTitle("Statistics Player",'=', '-'));
            memo.add(parse.PlayerGainedExperience.log("Experience"));
            memo.add(parse.PlayerHealedPower.log("HealedPower"));
            memo.add(parse.PlayerLostPower.log("LostPower"));
            memo.add(parse.PlayerLostPower.byUnknown.log("unknown"));
            memo.add(parse.PlayerLostPower.byCreature.log("byCreature"));
            memo.add(parse.PlayerLootedByCreature.log("LootedByCreature"));
            memo.add(parse.logTitle("Statistics Creature",'-', '-'));
            memo.add(parse.CreatureHealedPower.log("HealedPower"));
            memo.add(parse.CreatureLostPower.log("LostPower"));
            if (parse.CreatureSpotlight.HasCreatures)
            {
                memo.add(parse.logTitle("Creatures Spotlight",'-', '-'));
                memo.add(parse.CreatureSpotlight.log());
            }
            memo.add(parse.logTitle("Statistics based by file log extracted",'-', '='));

        }

        return (memo.txt);

    }


}