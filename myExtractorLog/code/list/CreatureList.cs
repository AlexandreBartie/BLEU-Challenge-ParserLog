using app.util;

namespace app.list;

public class CreatureList : List<Creature>
{  
    public string txt => string.Join(", ", this.OrderBy(item => item.name));

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

    private string GetTXT()
    {

        var memo = new Memo();

        foreach (Creature item in this)
            memo.Add(item.name);

        return memo.txt;

    }

}

public class Creature
{
    public readonly string name;

    public Creature(string name)
    { this.name = name;}

    public override string ToString() => name;

}

