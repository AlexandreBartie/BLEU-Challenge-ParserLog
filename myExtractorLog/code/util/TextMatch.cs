using System.Text.RegularExpressions;

namespace app.util;

public class TextMatch
{

    private Match match;
    public TextMatch(string text, string pattern)
    {
        match = Regex.Match(text, pattern);
    }

    public string GetParameter(int index)
    {
        return match.Groups[index].Value.Trim();
    }

}