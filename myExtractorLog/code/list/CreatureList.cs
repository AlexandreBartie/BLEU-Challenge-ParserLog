using app.util;

namespace app.list;

public class CreatureList : List<Creature>
{

    public void AddItem(string name)
    {

        foreach (Creature item in this)
        {
            if (!Text.IsMatch(item.name, name))
                Add(new Creature(name));
        }

    }

}

public class Creature
{
    public readonly string name;

    public Creature(string name)
    { this.name = name;}

}

