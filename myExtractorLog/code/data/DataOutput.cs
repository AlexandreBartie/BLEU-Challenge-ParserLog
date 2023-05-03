namespace app.data;

public class DataOutput
{

    public int hitpointsHealed;
    public TotalBoardDamageTaken damageTaken = new();

    public int experienceGained;

    public List<TotalBoardLootItem> loot = new();

}

public class TotalBoardDamageTaken
{

    public int total;
    public List<TotalBoardDamageTakenByCreature> byCreatureKind = new();

}

public class TotalBoardDamageTakenByCreature
{

    public string creature = "";
    public int damage;

}

public class TotalBoardLootItem
{

    public string item = "";
    public int qty;

}