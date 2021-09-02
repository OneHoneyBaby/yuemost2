using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;

internal static class Class28
{
    public static void smethod_0(object object_0)
    {
        ArgChecker.AssertArgNotNull(object_0, "imageWord");
        ArgChecker.AssertArgNotNull(object_0.OwnerBox, "imageWord.OwnerBox");
        Class30 class2 = new Class30(object_0.OwnerBox.Width);
        Class30 class3 = new Class30(object_0.OwnerBox.Height);
        bool flag3 = (class2.method_0() > 0.0) && (class2.method_4() == ((Enum4) 2));
        bool flag = (class3.method_0() > 0.0) && (class3.method_4() == ((Enum4) 2));
        bool flag2 = false;
        if (flag3)
        {
            object_0.Width = class2.method_0();
        }
        else if ((class2.method_0() > 0.0) && class2.method_2())
        {
            object_0.Width = class2.method_0() * object_0.OwnerBox.ContainingBlock.Size.Width;
            flag2 = true;
        }
        else if (object_0.Image != null)
        {
            object_0.Width = (object_0.method_1() == RRect.Empty) ? object_0.Image.Width : object_0.method_1().Width;
        }
        else
        {
            object_0.Width = flag ? (class3.method_0() / 1.1399999856948853) : 20.0;
        }
        Class30 class4 = new Class30(object_0.OwnerBox.MaxWidth);
        if (class4.method_0() > 0.0)
        {
            double num = -1.0;
            if (class4.method_4() == ((Enum4) 2))
            {
                num = class4.method_0();
            }
            else if (class4.method_2())
            {
                num = class4.method_0() * object_0.OwnerBox.ContainingBlock.Size.Width;
            }
            if ((num > -1.0) && (object_0.Width > num))
            {
                object_0.Width = num;
                flag2 = !flag;
            }
        }
        if (flag)
        {
            object_0.Height = class3.method_0();
        }
        else if (object_0.Image != null)
        {
            object_0.Height = (object_0.method_1() == RRect.Empty) ? object_0.Image.Height : object_0.method_1().Height;
        }
        else
        {
            object_0.Height = (object_0.Width > 0.0) ? (object_0.Width * 1.1399999856948853) : 22.799999237060547;
        }
        if (object_0.Image != null)
        {
            double num2;
            if (!((!flag3 || flag) ? !flag2 : false))
            {
                num2 = object_0.Width / object_0.Image.Width;
                object_0.Height = object_0.Image.Height * num2;
            }
            else if (!(!flag || flag3))
            {
                num2 = object_0.Height / object_0.Image.Height;
                object_0.Width = object_0.Image.Width * num2;
            }
        }
        object_0.Height += ((object_0.OwnerBox.ActualBorderBottomWidth + object_0.OwnerBox.ActualBorderTopWidth) + object_0.OwnerBox.ActualPaddingTop) + object_0.OwnerBox.ActualPaddingBottom;
    }

    public static void smethod_1(RGraphics rgraphics_0, object object_0)
    {
        ArgChecker.AssertArgNotNull(rgraphics_0, "g");
        ArgChecker.AssertArgNotNull(object_0, "blockBox");
        object_0.LineBoxes.Clear();
        double num = (object_0.ActualRight - object_0.ActualPaddingRight) - object_0.ActualBorderRightWidth;
        double num2 = ((object_0.Location.X + object_0.ActualPaddingLeft) - 0.0) + object_0.ActualBorderLeftWidth;
        double num3 = ((object_0.Location.Y + object_0.ActualPaddingTop) - 0.0) + object_0.ActualBorderTopWidth;
        double num4 = num2 + object_0.ActualTextIndent;
        double num5 = num3;
        double num6 = num2;
        double num7 = num3;
        CssLineBox box = new CssLineBox((CssBox) object_0);
        smethod_3(rgraphics_0, (CssBox) object_0, object_0, num, 0.0, num2, ref box, ref num4, ref num5, ref num6, ref num7);
        if (object_0.ActualRight >= 90999.0)
        {
            object_0.ActualRight = (num6 + object_0.ActualPaddingRight) + object_0.ActualBorderRightWidth;
        }
        foreach (CssLineBox box2 in object_0.LineBoxes)
        {
            smethod_6(rgraphics_0, box2);
            smethod_7((CssBoxProperties) object_0, box2);
            smethod_5((CssBox) object_0, box2);
            smethod_10(rgraphics_0, box2);
            box2.method_3();
        }
        object_0.ActualBottom = (num7 + object_0.ActualPaddingBottom) + object_0.ActualBorderBottomWidth;
        if ((((object_0.Height != null) && (object_0.Height != "auto")) && (object_0.Overflow == "hidden")) && ((object_0.ActualBottom - object_0.Location.Y) > object_0.ActualHeight))
        {
            object_0.ActualBottom = object_0.Location.Y + object_0.ActualHeight;
        }
    }

    private static void smethod_10(RGraphics rgraphics_0, CssLineBox cssLineBox_0)
    {
        RRect rect;
        double num = -3.4028234663852886E+38;
        foreach (CssBox box in cssLineBox_0.Rectangles.Keys)
        {
            rect = cssLineBox_0.Rectangles[box];
            num = Math.Max(num, rect.Top);
        }
        List<CssBox> list = new List<CssBox>(cssLineBox_0.Rectangles.Keys);
        foreach (CssBox box in list)
        {
            switch (box.VerticalAlign)
            {
                case "sub":
                    rect = cssLineBox_0.Rectangles[box];
                    cssLineBox_0.method_4(rgraphics_0, box, num + (rect.Height * 0.5));
                    break;

                case "super":
                    rect = cssLineBox_0.Rectangles[box];
                    cssLineBox_0.method_4(rgraphics_0, box, num - (rect.Height * 0.20000000298023224));
                    break;

                case "text-top":
                case "text-bottom":
                case "top":
                case "bottom":
                case "middle":
                    break;

                default:
                    cssLineBox_0.method_4(rgraphics_0, box, num);
                    break;
            }
        }
    }

    private static void smethod_11(object object_0, CssLineBox cssLineBox_0)
    {
        if (!cssLineBox_0.Equals(cssLineBox_0.OwnerBox.LineBoxes[cssLineBox_0.OwnerBox.LineBoxes.Count - 1]))
        {
            double num3 = cssLineBox_0.Equals(cssLineBox_0.OwnerBox.LineBoxes[0]) ? cssLineBox_0.OwnerBox.ActualTextIndent : 0.0;
            double num = 0.0;
            double num2 = 0.0;
            double num4 = cssLineBox_0.OwnerBox.ClientRectangle.Width - num3;
            foreach (CssRect rect in cssLineBox_0.Words)
            {
                num += rect.Width;
                num2++;
            }
            if (num2 > 0.0)
            {
                double num5 = (num4 - num) / num2;
                double num6 = cssLineBox_0.OwnerBox.ClientLeft + num3;
                foreach (CssRect rect3 in cssLineBox_0.Words)
                {
                    rect3.Left = num6;
                    num6 = rect3.Right + num5;
                    if (rect3 == cssLineBox_0.Words[cssLineBox_0.Words.Count - 1])
                    {
                        rect3.Left = cssLineBox_0.OwnerBox.ClientRight - rect3.Width;
                    }
                }
            }
        }
    }

    private static void smethod_12(object object_0, CssLineBox cssLineBox_0)
    {
        if (cssLineBox_0.Words.Count != 0)
        {
            CssRect rect2 = cssLineBox_0.Words[cssLineBox_0.Words.Count - 1];
            double num2 = (cssLineBox_0.OwnerBox.ActualRight - cssLineBox_0.OwnerBox.ActualPaddingRight) - cssLineBox_0.OwnerBox.ActualBorderRightWidth;
            double num = ((num2 - rect2.Right) - rect2.OwnerBox.ActualBorderRightWidth) - rect2.OwnerBox.ActualPaddingRight;
            num /= 2.0;
            if (num > 0.0)
            {
                foreach (CssRect rect in cssLineBox_0.Words)
                {
                    rect.Left += num;
                }
                if (cssLineBox_0.Rectangles.Count > 0)
                {
                    foreach (CssBox box in smethod_15<CssBox>(cssLineBox_0.Rectangles.Keys))
                    {
                        RRect rect3 = cssLineBox_0.Rectangles[box];
                        cssLineBox_0.Rectangles[box] = new RRect(rect3.X + num, rect3.Y, rect3.Width, rect3.Height);
                    }
                }
            }
        }
    }

    private static void smethod_13(object object_0, CssLineBox cssLineBox_0)
    {
        if (cssLineBox_0.Words.Count != 0)
        {
            CssRect rect = cssLineBox_0.Words[cssLineBox_0.Words.Count - 1];
            double num = (cssLineBox_0.OwnerBox.ActualRight - cssLineBox_0.OwnerBox.ActualPaddingRight) - cssLineBox_0.OwnerBox.ActualBorderRightWidth;
            double num2 = ((num - rect.Right) - rect.OwnerBox.ActualBorderRightWidth) - rect.OwnerBox.ActualPaddingRight;
            if (num2 > 0.0)
            {
                foreach (CssRect rect2 in cssLineBox_0.Words)
                {
                    rect2.Left += num2;
                }
                if (cssLineBox_0.Rectangles.Count > 0)
                {
                    foreach (CssBox box in smethod_15<CssBox>(cssLineBox_0.Rectangles.Keys))
                    {
                        RRect rect3 = cssLineBox_0.Rectangles[box];
                        cssLineBox_0.Rectangles[box] = new RRect(rect3.X + num2, rect3.Y, rect3.Width, rect3.Height);
                    }
                }
            }
        }
    }

    private static void smethod_14(object object_0, object object_1)
    {
    }

    private static List<baUrRtClKSE1mdcwlkb> smethod_15<baUrRtClKSE1mdcwlkb>(IEnumerable<baUrRtClKSE1mdcwlkb> ienumerable_0)
    {
        List<baUrRtClKSE1mdcwlkb> list = new List<baUrRtClKSE1mdcwlkb>();
        foreach (baUrRtClKSE1mdcwlkb local in ienumerable_0)
        {
            list.Add(local);
        }
        return list;
    }

    public static void smethod_2(object object_0, object object_1)
    {
        ArgChecker.AssertArgNotNull(object_0, "g");
        ArgChecker.AssertArgNotNull(object_1, "cell");
        if ((object_1.VerticalAlign != "top") && (object_1.VerticalAlign != "baseline"))
        {
            double clientBottom = object_1.ClientBottom;
            double num2 = object_1.method_4((CssBox) object_1, 0.0);
            double num3 = 0.0;
            if (object_1.VerticalAlign == "bottom")
            {
                num3 = clientBottom - num2;
            }
            else if (object_1.VerticalAlign == "middle")
            {
                num3 = (clientBottom - num2) / 2.0;
            }
            foreach (CssBox box in object_1.Boxes)
            {
                box.method_10(num3);
            }
        }
    }

    private static void smethod_3(RGraphics rgraphics_0, CssBox cssBox_0, object object_0, double double_0, double double_1, double double_2, ref CssLineBox cssLineBox_0, ref double double_3, ref double double_4, ref double double_5, ref double double_6)
    {
        double x = double_3;
        double y = double_4;
        object_0.FirstHostingLineBox = cssLineBox_0;
        double num3 = double_3;
        double num4 = double_5;
        double num5 = double_6;
        foreach (CssBox box in object_0.Boxes)
        {
            double num6 = (box.Position != "absolute") ? ((box.ActualMarginLeft + box.ActualBorderLeftWidth) + box.ActualPaddingLeft) : 0.0;
            double num7 = (box.Position != "absolute") ? ((box.ActualMarginRight + box.ActualBorderRightWidth) + box.ActualPaddingRight) : 0.0;
            box.method_13();
            box.vmethod_0(rgraphics_0);
            double_3 += num6;
            if (box.Words.Count > 0)
            {
                bool flag = false;
                if ((box.WhiteSpace == "nowrap") && (double_3 > double_2))
                {
                    double num8 = double_3;
                    foreach (CssRect rect in box.Words)
                    {
                        num8 += rect.FullWidth;
                    }
                    if (num8 > double_0)
                    {
                        flag = true;
                    }
                }
                if (Class50.smethod_5(box))
                {
                    double_3 += object_0.ActualWordSpacing;
                }
                foreach (CssRect rect in box.Words)
                {
                    if ((double_6 - double_4) < object_0.ActualLineHeight)
                    {
                        double_6 += object_0.ActualLineHeight - (double_6 - double_4);
                    }
                    if (((((box.WhiteSpace != "nowrap") && (box.WhiteSpace != "pre")) && ((((double_3 + rect.Width) + num7) > double_0) && ((box.WhiteSpace != "pre-wrap") || !rect.IsSpaces))) || rect.IsLineBreak) || flag)
                    {
                        flag = false;
                        double_3 = double_2;
                        if (((box == object_0.Boxes[0]) && !rect.IsLineBreak) && ((rect == box.Words[0]) || ((object_0.ParentBox != null) && object_0.ParentBox.IsBlock)))
                        {
                            double_3 += (object_0.ActualMarginLeft + object_0.ActualBorderLeftWidth) + object_0.ActualPaddingLeft;
                        }
                        double_4 = double_6 + double_1;
                        cssLineBox_0 = new CssLineBox(cssBox_0);
                        if (rect.IsImage || rect.Equals(box.FirstWord))
                        {
                            double_3 += num6;
                        }
                    }
                    cssLineBox_0.method_0(rect);
                    rect.Left = double_3;
                    rect.Top = double_4;
                    double_3 = rect.Left + rect.FullWidth;
                    double_5 = Math.Max(double_5, rect.Right);
                    double_6 = Math.Max(double_6, rect.Bottom);
                    if (box.Position == "absolute")
                    {
                        rect.Left += object_0.ActualMarginLeft;
                        rect.Top += object_0.ActualMarginTop;
                    }
                }
            }
            else
            {
                smethod_3(rgraphics_0, cssBox_0, box, double_0, double_1, double_2, ref cssLineBox_0, ref double_3, ref double_4, ref double_5, ref double_6);
            }
            double_3 += num7;
        }
        if ((double_6 - y) < object_0.ActualHeight)
        {
            double_6 += object_0.ActualHeight - (double_6 - y);
        }
        if ((object_0.IsInline && (0.0 <= (double_3 - x))) && ((double_3 - x) < object_0.ActualWidth))
        {
            double_3 += object_0.ActualWidth - (double_3 - x);
            cssLineBox_0.Rectangles.Add((CssBox) object_0, new RRect(x, y, object_0.ActualWidth, object_0.ActualHeight));
        }
        if (((((object_0.Text != null) && object_0.Text.IsWhitespace()) && (!object_0.IsImage && object_0.IsInline)) && (object_0.Boxes.Count == 0)) && (object_0.Words.Count == 0))
        {
            double_3 += object_0.ActualWordSpacing;
        }
        if (object_0.Position == "absolute")
        {
            double_3 = num3;
            double_5 = num4;
            double_6 = num5;
            smethod_4(object_0, 0.0, 0.0);
        }
        object_0.LastHostingLineBox = cssLineBox_0;
    }

    private static void smethod_4(object object_0, double double_0, double double_1)
    {
        double_0 += object_0.ActualMarginLeft;
        double_1 += object_0.ActualMarginTop;
        if (object_0.Words.Count > 0)
        {
            foreach (CssRect rect in object_0.Words)
            {
                rect.Left += double_0;
                rect.Top += double_1;
            }
        }
        else
        {
            foreach (CssBox box in object_0.Boxes)
            {
                smethod_4(box, double_0, double_1);
            }
        }
    }

    private static void smethod_5(CssBox cssBox_0, CssLineBox cssLineBox_0)
    {
        if (cssBox_0.Words.Count > 0)
        {
            double num2 = 3.4028234663852886E+38;
            double num4 = 3.4028234663852886E+38;
            double num3 = -3.4028234663852886E+38;
            double num5 = -3.4028234663852886E+38;
            List<CssRect> list = cssLineBox_0.method_1(cssBox_0);
            if (list.Count > 0)
            {
                foreach (CssRect rect in list)
                {
                    double left = rect.Left;
                    if (!((((cssBox_0 != cssBox_0.ParentBox.Boxes[0]) || (rect != cssBox_0.Words[0])) || ((rect != cssLineBox_0.Words[0]) || (cssLineBox_0 == cssLineBox_0.OwnerBox.LineBoxes[0]))) || rect.IsLineBreak))
                    {
                        left -= (cssBox_0.ParentBox.ActualMarginLeft + cssBox_0.ParentBox.ActualBorderLeftWidth) + cssBox_0.ParentBox.ActualPaddingLeft;
                    }
                    num2 = Math.Min(num2, left);
                    num3 = Math.Max(num3, rect.Right);
                    num4 = Math.Min(num4, rect.Top);
                    num5 = Math.Max(num5, rect.Bottom);
                }
                cssLineBox_0.method_2(cssBox_0, num2, num4, num3, num5);
            }
        }
        else
        {
            foreach (CssBox box in cssBox_0.Boxes)
            {
                smethod_5(box, cssLineBox_0);
            }
        }
    }

    private static void smethod_6(object object_0, CssLineBox cssLineBox_0)
    {
        string textAlign = cssLineBox_0.OwnerBox.TextAlign;
        switch (textAlign)
        {
            case null:
                break;

            case "right":
                smethod_13(object_0, cssLineBox_0);
                return;

            default:
                if (!(textAlign == "center"))
                {
                    if (!(textAlign == "justify"))
                    {
                        break;
                    }
                    smethod_11(object_0, cssLineBox_0);
                }
                else
                {
                    smethod_12(object_0, cssLineBox_0);
                }
                return;
        }
        smethod_14(object_0, cssLineBox_0);
    }

    private static void smethod_7(CssBoxProperties cssBoxProperties_0, CssLineBox cssLineBox_0)
    {
        if (cssBoxProperties_0.Direction == "rtl")
        {
            smethod_8(cssLineBox_0);
        }
        else
        {
            foreach (CssBox box in cssLineBox_0.RelatedBoxes)
            {
                if (box.Direction == "rtl")
                {
                    smethod_9(cssLineBox_0, box);
                }
            }
        }
    }

    private static void smethod_8(CssLineBox cssLineBox_0)
    {
        if (cssLineBox_0.Words.Count > 0)
        {
            double left = cssLineBox_0.Words[0].Left;
            double right = cssLineBox_0.Words[cssLineBox_0.Words.Count - 1].Right;
            foreach (CssRect rect in cssLineBox_0.Words)
            {
                double num3 = rect.Left - left;
                double num4 = right - num3;
                rect.Left = num4 - rect.Width;
            }
        }
    }

    private static void smethod_9(CssLineBox cssLineBox_0, object object_0)
    {
        int num3;
        int num = -1;
        int num2 = -1;
        for (num3 = 0; num3 < cssLineBox_0.Words.Count; num3++)
        {
            if (cssLineBox_0.Words[num3].OwnerBox == object_0)
            {
                if (num < 0)
                {
                    num = num3;
                }
                num2 = num3;
            }
        }
        if ((num > -1) && (num2 > num))
        {
            double left = cssLineBox_0.Words[num].Left;
            double right = cssLineBox_0.Words[num2].Right;
            for (num3 = num; num3 <= num2; num3++)
            {
                double num5 = cssLineBox_0.Words[num3].Left - left;
                double num7 = right - num5;
                cssLineBox_0.Words[num3].Left = num7 - cssLineBox_0.Words[num3].Width;
            }
        }
    }
}

