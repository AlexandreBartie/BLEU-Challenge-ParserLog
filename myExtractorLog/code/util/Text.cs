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

    
    public static string Repeat(string text, int times)
    { return string.Concat(Enumerable.Repeat(text, times)); }
    
    public static string Repeat(char text, int times)
    { return new string(text, times); }

    public static string Tab(int index, int size = 2)
    { return Repeat(' ', index * size); }

    public static string TabLevel(string text, int level, int max)
    { 

        var tab = level - 1;
        
        var prefix = Repeat('-', tab);

        var start = Tab(level).Substring(tab);
        var end = Tab(max - level);
       
        return start + prefix + text + end; 
    }

    public static string TabCentralize(string text, int size)
    {
        return text.PadLeft((size - text.Length) / 2 + text.Length).PadRight(size);
    }


}

