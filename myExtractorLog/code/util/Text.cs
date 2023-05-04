namespace app.util;

public static class Text
{

    public static bool IsMatch(string str1, string str2)
    {
        str1 = str1.Trim();
        str2 = str2.Trim();
        return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
    }

}

