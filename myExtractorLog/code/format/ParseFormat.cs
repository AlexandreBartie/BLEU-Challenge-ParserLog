using app.util;

namespace app.core;

public class ParseFormat
{

    private const int SIZE_LINE = 56;
    private const int COLUMN_LABEL = 18;
    private const int COLUMN_UNIT = 8;

    private const int COLUMN_VALUE = 10;
    private const int COLUMN_COUNT = 5;

    private const string FORMAT_NUMBER = "##,###,##0";

    private const string LABEL_POINTS = "points";
    private const string LABEL_ITEMS = "items";

    public string logTitle(string title)
    {
        var memo = new Memo();

        memo.add(logLine());
        memo.add(Text.TabCentralize(title, SIZE_LINE));
        memo.add(logLine());
        
         return memo.txt;
    }

    private string logLine()
    {
        return Text.Repeat('=', SIZE_LINE);
    }

    public string GetLogPoints(string title, int value, int count, int tab = 1)
    {
        return GetLog(title, value, count, LABEL_POINTS, tab);
    }

    public string GetLogItems(string title, int value, int count, int tab = 1)
    {
        return GetLog(title, value, count, LABEL_ITEMS, tab);
    }

    private string GetLog(string label, int value, int count, string unit, int level)
    {
        return $"{FormatLabel(label, level)}: {FormatValue(value)} {FormatUnit(unit)} {FormatCount(count)}";
    }

    private string FormatLabel(string label, int level) => Text.TabLevel(label.PadRight(COLUMN_LABEL), level, 3);
    private string FormatUnit(string unit) => unit.PadRight(COLUMN_UNIT);
    private string FormatValue(int value) => value.ToString(FORMAT_NUMBER).PadLeft(COLUMN_VALUE);
    private string FormatCount(int count) => count.ToString(FORMAT_NUMBER).PadLeft(COLUMN_COUNT); 
    
}