namespace app.data;

public struct DataOutput
{

    public int hitpointsHealed;
    public TotalBoardDamageTaken damageTaken;

    public int experienceGained;

    public List<TotalBoardLootItem> loot;

}

public struct TotalBoardDamageTaken
{

    public int total;
    public List<TotalBoardDamageTakenByCreature> byCreatureKind;

}

public struct TotalBoardDamageTakenByCreature
{

    public string creature;
    public int damage;

}

public struct TotalBoardLootItem
{

    public string item;
    public int qty;

}