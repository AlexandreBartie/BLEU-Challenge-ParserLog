using app.util;

namespace app.list;

public class CreatureList : List<Creature>
{

    public void AddItem(string name)
    {
        if (name.Trim() == "")
            return;

        if(!Found(name))
            Add(new Creature(name));

    }

    public bool Found(string name)
    {

        foreach (Creature item in this)
        {
            if (Text.IsMatch(item.name, name))
                return true;
        }

        return false;

    }


}

public class Creature
{
    public readonly string name;

    public Creature(string name)
    { this.name = name;}

}

