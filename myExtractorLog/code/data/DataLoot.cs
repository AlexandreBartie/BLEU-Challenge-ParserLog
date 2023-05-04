using System.Text.RegularExpressions;
using app.util;

namespace app.data;

public class DataLootList : List<DataLootItem>
{

    const string LOOT_DELIMITER = ", ";

    public string txt 
    {
        get { return string.Join(LOOT_DELIMITER, this); }
    } 

    public DataLootList(string list = "")
    {
        
        if (list != "")
            setup(list);
    }

    public void AddList(DataLootList list)
    {
        
        foreach (DataLootItem loot in list)
        {
            Add(loot);
        }
    }

    private void setup(string list)
    {

        string[] items = list.Split(LOOT_DELIMITER);

        foreach (string item in items)
        {
            Add(new DataLootItem(item));
        }

    }

}

public class DataLootItem
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

    public DataLootItem(string item)
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


