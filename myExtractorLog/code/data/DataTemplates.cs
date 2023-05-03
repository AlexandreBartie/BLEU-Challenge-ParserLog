using app.extra;

namespace app.data;

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