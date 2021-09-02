using DSkin.Html.Core.Dom;
using System;
using System.Collections.Generic;

internal sealed class Class27 : CssBox
{
    private readonly int int_0;
    private readonly int int_1;
    private readonly object object_0;

    public Class27(CssBox cssBox_2, ref CssBox cssBox_3, int int_2) : base(cssBox_2, new HtmlTag("none", false, dictionary))
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("colspan", "1");
        this.object_0 = cssBox_3;
        base.Display = "none";
        this.int_0 = int_2;
        this.int_1 = (int_2 + int.Parse(cssBox_3.GetAttribute("rowspan", "1"))) - 1;
    }

    public CssBox method_24()
    {
        return (CssBox) this.object_0;
    }

    public int method_25()
    {
        return this.int_0;
    }

    public int method_26()
    {
        return this.int_1;
    }
}

