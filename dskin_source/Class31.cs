using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal sealed class Class31 : CssRect
{
    private RImage rimage_0;
    private RRect rrect_1;

    public Class31(CssBox cssBox_1) : base(cssBox_1)
    {
    }

    public RRect method_1()
    {
        return this.rrect_1;
    }

    public void method_2(RRect rrect_2)
    {
        this.rrect_1 = rrect_2;
    }

    public override string ToString()
    {
        return "Image";
    }

    public override RImage Image
    {
        get
        {
            return this.rimage_0;
        }
        set
        {
            this.rimage_0 = value;
        }
    }

    public override bool IsImage
    {
        get
        {
            return true;
        }
    }
}

