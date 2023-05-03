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
            GetTypeLogByGame();
        else
            GetTypeLogByPlayer();

    }

    public string GetParameter(int index)
    {     
        if (match != null)
            return match.Groups[index].Value;
        return "" ;
    }

    private void GetTypeLogByGame()
    {

        _type = TypeLog.eLogGameMessage;

        if (MatchTypeLog(TypeLog.eLogGameSession))
            return;

    }

    private void GetTypeLogByPlayer()
    {

        _type = TypeLog.eLogPlayerMessage;

        if (MatchTypeLog(TypeLog.eLogPlayerHealedPower))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLostPower))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLostPowerByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerGainedExperience))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLootedByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogCreatureLostPower))
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