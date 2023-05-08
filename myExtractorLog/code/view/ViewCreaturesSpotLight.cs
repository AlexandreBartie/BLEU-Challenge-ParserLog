using app.core;
namespace app.view;


public class ViewCreaturesSpotLight
{
    private ViewData view;

    private string? rules;

    public ViewCreaturesSpotLight(ViewData view)
    {
        this.view = view;
    }

    public void Setup(string rules)
    {
        this.rules = rules;
    }

    public void SumData()
    {


    }

    public string log()
    {
        return " need to fill this line"; //view.GetLogPoints(label, totalDamage, count);
    }


}