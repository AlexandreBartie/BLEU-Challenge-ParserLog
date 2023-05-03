using app.extra;

namespace app.data;

public struct DataPlayerHealedPower {
    public int points;
}

public struct DataPlayerLostPower {
    public int points;
}

public struct DataPlayerLostPowerByCreature {
    public int points;
    public string creature;
}

public struct DataPlayerGainedExperience {
    public int points;
}

public struct DataPlayerLootedByCreature {
    public string creature;
    public LootedList list;

}

public struct DataCreatureLostPower {
    public string creature;
    public int points;

}