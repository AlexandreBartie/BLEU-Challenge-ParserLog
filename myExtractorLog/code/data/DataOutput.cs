namespace app.data;

public class DataOutput
{

    public int experienceGained;

    public int hitpointsHealed;

    public DataOutputDamageTaken damageTaken = new();

    public DataLootList loot = new();

    public DataOutputCreaturesBoard creatures = new();

}

public class DataOutputCreaturesBoard
{
    public int total => lostPower.totalDamage;

    public DataCreatureList lostPower = new();
}

public class DataOutputDamageTaken
{
    public int unknown;

    public int total => unknown + byCreature.totalDamage;
    
    public DataCreatureList byCreature = new();

}