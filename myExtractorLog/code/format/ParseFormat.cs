namespace app.core;

public class ParseFormat
{
        private string GetLog(string label, int value, int count, string unit)
    {
        return $"{FormatLabel(label)}: {FormatValue(value)} {FormatUnit(unit)} {FormatCount(count)}";
    }

    public string GetLogRecords(string label, int value, int count)
    {
        return GetLog(label, value, count, "logs");
    }

    public string GetLogPoints(string title, int value, int count)
    {
        return GetLog(title, value, count, "points");
    }

    private string FormatLabel(string title) => title.PadLeft(20);
    private string FormatUnit(string label) => label.PadRight(8);
    private string FormatValue(int value) => value.ToString("##,###,##0").PadLeft(10);
    private string FormatCount(int value) => "[" + value.ToString("#,##0").PadLeft(5) + "]"; 
    
}