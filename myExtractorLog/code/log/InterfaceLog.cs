using app.data;

namespace app.log;

public struct ILogPlayerPoints
{
    public int points;
}

public struct ILogPlayerLooted
{
    public string creature;
    public DataLootList list;

}

public struct ILogCreaturePoints
{
    public string creature;
    public int points;

}
