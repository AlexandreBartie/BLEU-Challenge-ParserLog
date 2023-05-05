using app.log;
using app.view;

namespace app.core;

public class ParseView
{

    public ParseSessions sessions = new();

    public readonly ViewPlayerHealedPower PlayerHealedPower;
    public readonly ViewPlayerLostPower PlayerLostPower;
    public readonly ViewPlayerGainedExperience PlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature PlayerLootedByCreature;
    public readonly ViewCreatureLostPower CreatureLostPower;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ParseView()
    {

        PlayerHealedPower = new ViewPlayerHealedPower(this);
        PlayerLostPower = new ViewPlayerLostPower(this);
        PlayerLootedByCreature = new ViewPlayerLootedByCreature(this);
        PlayerGainedExperience = new ViewPlayerGainedExperience(this);
        CreatureLostPower = new ViewCreatureLostPower(this);

    }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        PlayerHealedPower.SumData();
        PlayerLostPower.SumData();
        PlayerGainedExperience.SumData();
        PlayerLootedByCreature.SumData();
        CreatureLostPower.SumData();
    }

    private string GetLog(string title, int value, int count, string unit)
    {
        return $"{FormatTitle(title)}: {FormatValue(value)} {FormatLabel(unit)} #{FormatCount(count)}";
    }

    public string GetLogRecords(string title, int value, int count)
    {
        return GetLog(title, value, count, "logs");
    }

    public string GetLogPoints(string title, int value, int count)
    {
        return GetLog(title, value, count, "points");
    }

    private string FormatTitle(string title) => title.PadLeft(25);
    private string FormatLabel(string label) => label.PadLeft(10);
    private string FormatValue(int value) => value.ToString("###,###,##0");
    private string FormatCount(int value) => value.ToString("###,##0");

}