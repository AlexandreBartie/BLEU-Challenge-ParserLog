using System.Text.RegularExpressions;

namespace app.extra;

public class LootedList : List<LootedItem>
{

    public string txt 
    {
        get { return string.Join(" + ", this); }
    } 

    public LootedList(string list)
    {
        setup(list);
    }

    private void setup(string list)
    {

        string[] items = list.Split(',');

        foreach (string item in items)
        {
            Add(new LootedItem(item));
        }

    }

}

public class LootedItem
{

    const string LOOTED_ITEM = @"^\s*(\d*)\s*(.*)$";

    private string _qty = "";
    private string _name = "";

    public int qty
    {
        get { 
            
            if (_qty == "")
                return 1;
            
            return int.Parse(_qty); }
    }

    public string name
    {
        get { return _name; }
    }

    public string label
    {
        get { return qty + " " + name; }
    }

    public LootedItem(string item)
    {
        setup(item);
    }

    private void setup(string item)
    {
        Match match = Regex.Match(item, LOOTED_ITEM);

        string _qty = match.Groups[1].Value.Trim();
        string _description = match.Groups[2].Value.Trim();
    }

}


