using app.core;
using app.log;

namespace app.view.model;

public abstract class ViewModel
{
    public readonly ParseView view;

    public readonly TypeLog type;

    public ViewModel(ParseView view, TypeLog type)
    {
        this.view = view;

        this.type = type;
    }

}