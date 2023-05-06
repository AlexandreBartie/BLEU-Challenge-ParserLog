using app.data;

namespace app.log;

public struct ILogPlayerHealedPower
{
    public int points;
}

public struct ILogPlayerLostPower
{
    public int points;
}

public struct ILogPlayerLostPowerByCreature
{
    public int points;
    public string creature;
}

public struct ILogPlayerGainedExperience
{
    public int points;
}

public struct ILogPlayerLootedByCreature
{
    public string creature;
    public DataLootList list;

}

public struct ILogCreatureLostPower
{
    public string creature;
    public int points;

}