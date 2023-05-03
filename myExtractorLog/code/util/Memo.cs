namespace app.util;

public class Memo : List<string>
{

    public string txt => string.Join(Environment.NewLine, this);
    
    public void addList(string[] list)
    {

        foreach (string item in list)
        {
            Add(item);
        }

    }

}