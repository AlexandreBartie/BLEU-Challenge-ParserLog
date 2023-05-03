using System.Text.RegularExpressions;
using app.util;

namespace app.extra;

public class LootedList : List<LootedItem>
{

    const string LOOTED_DELIMITER = ", ";

    public string txt 
    {
        get { return string.Join(LOOTED_DELIMITER, this); }
    } 

    public LootedList(string list)
    {
        setup(list);
    }

    private void setup(string list)
    {

        string[] items = list.Split(LOOTED_DELIMITER);

        foreach (string item in items)
        {
            Add(new LootedItem(item));
        }

    }

}

public class LootedItem
{

    const string LOOTED_NULL = "nothing";
    const string LOOTED_ITEM = @"^\s*(\d*)\s*(.*)$";

    private string _qty = "";
    private string _name = "";

    private bool isNull;

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

    public override string ToString() => isNull ? String.Format("{0} {1}", qty, _name) : "";   

    public LootedItem(string item)
    {
        
        isNull = (item != LOOTED_NULL);

        if (!isNull)
        {
            var match = new TextMatch(item, LOOTED_ITEM);
            
            _qty = match.GetParameter(1);
            _name = GetNameTreatment(match.GetParameter(2));
        }
        
    }

    private string GetNameTreatment(string input)
    {

        string pattern = @"^(an? )";
        string result = Regex.Replace(input, pattern, "");

        return result;

    }

}


