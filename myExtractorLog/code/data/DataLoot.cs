using System.Text.RegularExpressions;
using app.util;

namespace app.data;

public class DataLootList : List<DataLoot>
{

    const string LOOT_DELIMITER = ", ";

    
    public int total => GetTotalDamage();

    public string txt => string.Join(LOOT_DELIMITER, this);

    public DataLootList(string list = "")
    {
        
        if (list != "")
            setup(list);
    }

    public void AddList(DataLootList list)
    {
        
        foreach (DataLoot loot in list)
        {
            Add(loot);
        }
    }

    public DataLootList filter(string name)
    {

        var list = new DataLootList();

        foreach (DataLoot loot in this)
        {
            if (Text.IsMatch(loot.name, name))
                list.Add(loot);
        }

        return list;
    }
    private void setup(string list)
    {

        string[] items = list.Split(LOOT_DELIMITER);

        foreach (string item in items)
        {
            Add(new DataLoot(item));
        }

    }
    private int GetTotalDamage()
    {
        var total = 0;

        foreach (DataLoot loot in this)
        {
            total += loot.qty;
        }

        return total;
    }

}

public class DataLoot
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
        get { 
            
            if (isNull )
                return 0;

            if (paramQTY == "")
                return 1;
            
            return int.Parse(paramQTY); }
    }

    public string name
    {
        get { return paramName; }
    }

    public override string ToString() => isNull ? "" : String.Format("{0} {1}", qty, paramName);   

    public DataLoot(string item)
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


