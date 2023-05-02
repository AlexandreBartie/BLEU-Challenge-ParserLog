using app.extra;

namespace app.log;

public struct PlayerHealedPower {
    public int points;
}

public struct PlayerLostPower {
    public int points;
}

public struct PlayerLostPowerByCreature {
    public int points;
    public string creature;
}

public struct PlayerGainedExperience {
    public int points;
}

public struct PlayerLootedByCreature {
    public string creature;
    public LootedList list;

}

public struct CreatureLostPower {
    public string creature;
    public int points;

}

public class BaseLog
{
    public readonly string msg;
    public readonly string time;

    public readonly RegexLog regex;

    public TypeLog type
    {
        get  { return regex.type; }
    }

    public BaseLog(string info)
    {
        TagLog tag = new(info);

        this.msg = tag.msg;
        this.time = tag.time;
        this.regex = new RegexLog(msg, time);

    }

}

