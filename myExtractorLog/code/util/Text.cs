namespace app.util;

public static class Text
{

    public static bool IsMatch(string str1, string str2, bool ignorePlural = false)
    {
        str1 = str1.Trim();
        str2 = str2.Trim();

        if (ignorePlural)
        {
            str1 = str1.TrimEnd('s');
            str2 = str2.TrimEnd('s');
        }

        return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
    }

    public static string Tab(int size)
    { return new string(' ', size); }

}

