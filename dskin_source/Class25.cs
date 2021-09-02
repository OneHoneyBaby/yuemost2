using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal sealed class Class25 : CssBox
{
    public Class25(CssBox cssBox_2, HtmlTag htmlTag_1) : base(cssBox_2, htmlTag_1)
    {
        base.Display = "block";
    }

    protected override void PaintImp(RGraphics g)
    {
        RPoint point = (base.HtmlContainer != null) ? base.HtmlContainer.ScrollOffset : RPoint.Empty;
        RRect rect = new RRect(base.Bounds.X + point.X, base.Bounds.Y + point.Y, base.Bounds.Width, base.Bounds.Height);
        if ((rect.Height > 2.0) && Class53.XqRamjooQr(base.ActualBackgroundColor))
        {
            g.DrawRectangle(g.GetSolidBrush(base.ActualBackgroundColor), rect.X, rect.Y, rect.Width, rect.Height);
        }
        RBrush solidBrush = g.GetSolidBrush(base.ActualBorderTopColor);
        Class35.smethod_1((Enum3) 0, g, this, solidBrush, rect);
        if (rect.Height > 1.0)
        {
            RBrush brush2 = g.GetSolidBrush(base.ActualBorderLeftColor);
            Class35.smethod_1((Enum3) 3, g, this, brush2, rect);
            RBrush brush3 = g.GetSolidBrush(base.ActualBorderRightColor);
            Class35.smethod_1((Enum3) 1, g, this, brush3, rect);
            RBrush brush4 = g.GetSolidBrush(base.ActualBorderBottomColor);
            Class35.smethod_1((Enum3) 2, g, this, brush4, rect);
        }
    }

    protected override void PerformLayoutImp(RGraphics g)
    {
        if (base.Display != "none")
        {
            base.method_13();
            CssBox prevSibling = Class50.smethod_3(this);
            double x = ((base.ContainingBlock.Location.X + base.ContainingBlock.ActualPaddingLeft) + base.ActualMarginLeft) + base.ContainingBlock.ActualBorderLeftWidth;
            double y = ((((prevSibling != null) || (base.ParentBox == null)) ? ((base.ParentBox == null) ? base.Location.Y : 0.0) : base.ParentBox.ClientTop) + base.MarginTopCollapse(prevSibling)) + ((prevSibling != null) ? (prevSibling.ActualBottom + prevSibling.ActualBorderBottomWidth) : 0.0);
            base.Location = new RPoint(x, y);
            base.ActualBottom = y;
            double num4 = base.method_3();
            double num2 = (((((((base.ContainingBlock.Size.Width - base.ContainingBlock.ActualPaddingLeft) - base.ContainingBlock.ActualPaddingRight) - base.ContainingBlock.ActualBorderLeftWidth) - base.ContainingBlock.ActualBorderRightWidth) - base.ActualMarginLeft) - base.ActualMarginRight) - base.ActualBorderLeftWidth) - base.ActualBorderRightWidth;
            if (!(!(base.Width != "auto") || string.IsNullOrEmpty(base.Width)))
            {
                num2 = Class43.smethod_4(base.Width, num2, this, false);
            }
            if ((num2 < num4) || (num2 >= 9999.0))
            {
                num2 = num4;
            }
            double actualHeight = base.ActualHeight;
            if (actualHeight < 1.0)
            {
                actualHeight = (base.Size.Height + base.ActualBorderTopWidth) + base.ActualBorderBottomWidth;
            }
            if (actualHeight < 1.0)
            {
                actualHeight = 2.0;
            }
            if (((actualHeight <= 2.0) && (base.ActualBorderTopWidth < 1.0)) && (base.ActualBorderBottomWidth < 1.0))
            {
                base.BorderTopStyle = base.BorderBottomStyle = "solid";
                base.BorderTopWidth = "1px";
                base.BorderBottomWidth = "1px";
            }
            base.Size = new RSize(num2, actualHeight);
            base.ActualBottom = ((base.Location.Y + base.ActualPaddingTop) + base.ActualPaddingBottom) + actualHeight;
        }
    }
}

