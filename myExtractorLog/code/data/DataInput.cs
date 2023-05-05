using app.list;

namespace app.data;

public struct ParseLogPlayerHealedPower
{
    public int points;
}

public struct ParseLogPlayerLostPower
{
    public int points;
}

public struct ParseLogPlayerLostPowerByCreature
{
    public int points;
    public string creature;
}

public struct ParseLogPlayerGainedExperience
{
    public int points;
}

public struct ParseLogPlayerLootedByCreature
{
    public string creature;
    public LootList list;

}

public struct ParseLogCreatureLostPower
{
    public string creature;
    public int points;

}