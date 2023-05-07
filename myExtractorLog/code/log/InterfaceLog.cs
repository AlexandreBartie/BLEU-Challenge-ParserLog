using app.data;

namespace app.log;

public struct ILogPlayerPoints
{
    public int points;
}

public struct ILogPlayerLooted
{
    public string creature;
    public DataListLoot list;

}

public struct ILogCreaturePoints
{
    public string creature;
    public int points;

}
