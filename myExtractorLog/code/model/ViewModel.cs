using app.core;
using app.log;

namespace app.model;

public abstract class ViewModel
{
    public readonly ViewData view;

    public readonly TypeLog type;

    public ViewModel(ViewData view, TypeLog type)
    {
        this.view = view;

        this.type = type;
    }

}