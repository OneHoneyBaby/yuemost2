using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal sealed class Class26 : CssBox
{
    private bool bool_2;
    private readonly Class31 class31_0;
    private Class40 class40_1;

    public Class26(CssBox cssBox_2, HtmlTag htmlTag_1) : base(cssBox_2, htmlTag_1)
    {
        this.class31_0 = new Class31(this);
        base.Words.Add(this.class31_0);
    }

    public override void Dispose()
    {
        if (this.class40_1 != null)
        {
            this.class40_1.Dispose();
        }
        base.Dispose();
    }

    private void method_24()
    {
        base.SetAllBorders("solid", "2px", "#A0A0A0");
        base.BorderRightColor = base.BorderBottomColor = "#E3E3E3";
    }

    private void method_25(RImage rimage_0, RRect rrect_0, bool bool_3)
    {
        this.class31_0.Image = rimage_0;
        this.class31_0.method_2(rrect_0);
        this.bool_2 = true;
        base._wordsSizeMeasured = false;
        if (this.bool_2 && (rimage_0 == null))
        {
            this.method_24();
        }
        if (!(base.HtmlContainer.AvoidImagesLateLoading && !bool_3))
        {
            Class30 class2 = new Class30(base.Width);
            Class30 class3 = new Class30(base.Height);
            bool layout = ((class2.method_0() <= 0.0) || (class2.method_4() != ((Enum4) 2))) || ((class3.method_0() <= 0.0) || (class3.method_4() != ((Enum4) 2)));
            base.HtmlContainer.RequestRefresh(layout);
        }
    }

    protected override void PaintImp(RGraphics g)
    {
        if (this.class40_1 == null)
        {
            this.class40_1 = new Class40(base.HtmlContainer, new Delegate3<RImage, RRect, bool>(this.method_25));
            this.class40_1.method_1(base.GetAttribute("src"), (base.HtmlTag != null) ? base.HtmlTag.Attributes : null);
        }
        RRect rect3 = Class48.smethod_6<CssLineBox, RRect>(base.Rectangles, new RRect());
        RPoint scrollOffset = base.HtmlContainer.ScrollOffset;
        rect3.Offset(scrollOffset);
        bool flag = Class53.smethod_0(g, this);
        base.PaintBackground(g, rect3, true, true);
        Class35.smethod_0(g, this, rect3, true, true);
        RRect rectangle = this.class31_0.Rectangle;
        rectangle.Offset(scrollOffset);
        rectangle.Height -= ((base.ActualBorderTopWidth + base.ActualBorderBottomWidth) + base.ActualPaddingTop) + base.ActualPaddingBottom;
        rectangle.Y += base.ActualBorderTopWidth + base.ActualPaddingTop;
        rectangle.X = Math.Floor(rectangle.X);
        rectangle.Y = Math.Floor(rectangle.Y);
        if (this.class31_0.Image != null)
        {
            if ((rectangle.Width > 0.0) && (rectangle.Height > 0.0))
            {
                if (this.class31_0.method_1() == RRect.Empty)
                {
                    g.DrawImage(this.class31_0.Image, rectangle);
                }
                else
                {
                    g.DrawImage(this.class31_0.Image, rectangle, this.class31_0.method_1());
                }
                if (this.class31_0.Selected)
                {
                    g.DrawRectangle(base.GetSelectionBackBrush(g, true), this.class31_0.Left + scrollOffset.X, this.class31_0.Top + scrollOffset.Y, this.class31_0.Width + 2.0, Class50.smethod_15(this.class31_0).LineHeight);
                }
            }
        }
        else if (this.bool_2)
        {
            if ((this.bool_2 && (rectangle.Width > 19.0)) && (rectangle.Height > 19.0))
            {
                Class53.smethod_2(g, base.HtmlContainer, rectangle);
            }
        }
        else
        {
            Class53.smethod_1(g, base.HtmlContainer, rectangle);
            if ((rectangle.Width > 19.0) && (rectangle.Height > 19.0))
            {
                g.DrawRectangle(g.GetPen(RColor.LightGray), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }
        }
        if (flag)
        {
            g.PopClip();
        }
    }

    internal override void vmethod_0(RGraphics g)
    {
        if (!base._wordsSizeMeasured)
        {
            if ((this.class40_1 == null) && (base.HtmlContainer.AvoidAsyncImagesLoading || base.HtmlContainer.AvoidImagesLateLoading))
            {
                this.class40_1 = new Class40(base.HtmlContainer, new Delegate3<RImage, RRect, bool>(this.method_25));
                this.class40_1.method_1(base.GetAttribute("src"), (base.HtmlTag != null) ? base.HtmlTag.Attributes : null);
            }
            base.MeasureWordSpacing(g);
            base._wordsSizeMeasured = true;
        }
        Class28.smethod_0(this.class31_0);
    }

    public RImage Image
    {
        get
        {
            return this.class31_0.Image;
        }
    }
}

