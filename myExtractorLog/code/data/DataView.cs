namespace app.data;

public class DataView
{

    public int experienceGained;

    public int hitpointsHealed;

    public DataViewDamageTaken damageTaken = new();

    public DataLootList loot = new();

    public DataViewCreaturesBoard creatures = new();

}

public class DataViewCreaturesBoard
{
    public int total => lostPower.totalDamage;

    public DataCreatureList lostPower = new();
}

public class DataViewDamageTaken
{
    public int unknown;

    public int total => unknown + byCreature.totalDamage;

    public DataCreatureList byCreature = new();

}