using app.list;

namespace app.data;

public struct DataLogPlayerHealedPower
{
    public int points;
}

public struct DataLogPlayerLostPower
{
    public int points;
}

public struct DataLogPlayerLostPowerByCreature
{
    public int points;
    public string creature;
}

public struct DataLogPlayerGainedExperience
{
    public int points;
}

public struct DataLogPlayerLootedByCreature
{
    public string creature;
    public LootList list;

}

public struct DataLogCreatureLostPower
{
    public string creature;
    public int points;

}