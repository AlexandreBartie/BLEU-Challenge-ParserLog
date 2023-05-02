using System.Text.RegularExpressions;
using app.util;

namespace app.log;

public class TagLog
{

    const string TAG_TIME = "HH:mm";
    const string REGEX_TIME = @"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$";
    
    private string info = ""; 

    public string time
    {
        get { return (hasTime) ? getTime() : ""; }
    }

    public string msg
    {
        get { return (hasTime) ? getMsg() : info; }
    }
    
    //check if represent a valid time
    public bool hasTime
    {
        get { return (Regex.IsMatch(getTime(), REGEX_TIME));   }
    }

    public TagLog(string info)
    {
        this.info = info;
    }

    // extract time in string info
    private string getTime()
    {
        return info.Substring(0, TAG_TIME.Length);
    }

    // extract time in string info
    private string getMsg()
    {
        return info.Substring(TAG_TIME.Length + 1).Trim();
    }

}