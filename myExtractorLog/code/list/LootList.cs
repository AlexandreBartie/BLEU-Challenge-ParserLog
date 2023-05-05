using System.Text.RegularExpressions;
using app.util;

namespace app.list;

public class LootList : List<LootItem>
{

    const string LOOT_DELIMITER = ", ";


    public int total => GetTotalDamage();

    public int count => this.Count;

    public string txt => string.Join(LOOT_DELIMITER, this);

    public LootList(string list = "")
    {

        if (list != "")
            setup(list);
    }

    public void AddList(LootList list)
    {

        foreach (LootItem loot in list)
        {
            Add(loot);
        }
    }

    public LootList filter(string name)
    {

        var list = new LootList();

        foreach (LootItem loot in this)
        {
            if (Text.IsMatch(loot.name, name, true))
                list.Add(loot);
        }

        return list;
    }
    private void setup(string list)
    {

        string[] items = list.Split(LOOT_DELIMITER);

        foreach (string item in items)
        {
            Add(new LootItem(item));
        }

    }
    private int GetTotalDamage()
    {
        var total = 0;

        foreach (LootItem loot in this)
        {
            total += loot.qty;
        }

        return total;
    }

}

public class LootItem
{

    const string LOOTED_NULL = "nothing";
    const string LOOTED_ITEM = @"^\s*(\d*)\s*(.*)$";
    const string LOOTED_ITEM_NAME = @"^(an? )";

    private string item;

    private string paramQTY = "";
    private string paramName = "";

    private bool isNull
    {
        get { return (item == LOOTED_NULL); }
    }

    public int qty
    {
        get
        {

            if (isNull)
                return 0;

            if (paramQTY == "")
                return 1;

            return int.Parse(paramQTY);
        }
    }

    public string name
    {
        get { return paramName; }
    }

    public override string ToString() => isNull ? "" : String.Format("{0} {1}", qty, paramName);

    public LootItem(string item)
    {

        this.item = item;

        if (!isNull)
        {
            var match = new TextMatch(item, LOOTED_ITEM);

            paramQTY = match.GetParameter(1);
            paramName = GetNameTreatment(match.GetParameter(2));

        }

    }

    private string GetNameTreatment(string input)
    {
        return Regex.Replace(input, LOOTED_ITEM_NAME, "");
    }

}


