using System.Text.RegularExpressions;
using app.util;

namespace app.log;

public class RegexLog : RegexSettings
{

    private string text = "";

    private TypeLog _type;
    private Match? _match;

    public TypeLog type => _type;

    public Match? match => _match;

    public RegexLog(string msg, string time)
    {

        text = msg;

        if (time == "")
            GetTypeLogByNote();
        else
            GetTypeLogByGame();

    }

    public string GetParameter(int index)
    {     
        if (match != null)
            return match.Groups[index].Value;
        return "" ;
    }

    private void GetTypeLogByNote()
    {

        _type = TypeLog.eLogNoteMessage;

        if (MatchTypeLog(TypeLog.eLogNoteSession))
            return;

    }

    private void GetTypeLogByGame()
    {

        _type = TypeLog.eLogGameMessage;

        if (MatchTypeLog(TypeLog.eLogGamePlayerHealedPower))
            return;

        if (MatchTypeLog(TypeLog.eLogGamePlayerLostPowerByUnknown))
            return;

        if (MatchTypeLog(TypeLog.eLogGamePlayerLostPowerByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogGamePlayerGainedExperience))
            return;

        if (MatchTypeLog(TypeLog.eLogGamePlayerLootedByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogGameCreatureLostPower))
            return;

    }

    private bool MatchTypeLog(TypeLog item)
    {

        var pattern = getPattern(item);
        
        var check = Regex.Match(text, pattern);
        
        if (check.Success)
        {
            _type = item;

            _match = check;

            return true;
        }

        return false;
    }

}