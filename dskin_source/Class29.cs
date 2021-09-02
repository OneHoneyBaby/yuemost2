using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal sealed class Class29
{
    private bool bool_0;
    private CssBox cssBox_0;
    private CssBox cssBox_1;
    private CssBox cssBox_2;
    private double[] double_0;
    private double[] double_1;
    private int int_0;
    private readonly List<CssBox> list_0 = new List<CssBox>();
    private readonly List<CssBox> list_1 = new List<CssBox>();
    private readonly List<CssBox> list_2 = new List<CssBox>();
    private readonly object object_0;

    private Class29(CssBox cssBox_3)
    {
        this.object_0 = cssBox_3;
    }

    private void method_0(RGraphics rgraphics_0)
    {
        smethod_5((CssBox) this.object_0, rgraphics_0);
        this.method_1();
        this.method_2();
        double num = this.method_3();
        this.method_4(num);
        this.method_6();
        this.method_5();
        this.object_0.PaddingLeft = this.object_0.PaddingTop = this.object_0.PaddingRight = this.object_0.PaddingBottom = "0";
        this.method_7(rgraphics_0);
    }

    private void method_1()
    {
        foreach (CssBox box in this.object_0.Boxes)
        {
            int num2;
            int num3;
            switch (box.Display)
            {
                case "table-caption":
                {
                    this.cssBox_0 = box;
                    continue;
                }
                case "table-row":
                {
                    this.list_0.Add(box);
                    continue;
                }
                case "table-row-group":
                {
                    foreach (CssBox box2 in box.Boxes)
                    {
                        if (box2.Display == "table-row")
                        {
                            this.list_0.Add(box2);
                        }
                    }
                    continue;
                }
                case "table-header-group":
                {
                    if (this.cssBox_1 != null)
                    {
                        this.list_0.Add(box);
                    }
                    else
                    {
                        this.cssBox_1 = box;
                    }
                    continue;
                }
                case "table-footer-group":
                {
                    if (this.cssBox_2 == null)
                    {
                        break;
                    }
                    this.list_0.Add(box);
                    continue;
                }
                case "table-column":
                    num2 = 0;
                    goto Label_01AD;

                case "table-column-group":
                    if (box.Boxes.Count != 0)
                    {
                        goto Label_01FA;
                    }
                    num3 = smethod_6(box);
                    num2 = 0;
                    goto Label_01F0;

                default:
                {
                    continue;
                }
            }
            this.cssBox_2 = box;
            continue;
        Label_019B:
            this.list_1.Add(box);
            num2++;
        Label_01AD:
            if (num2 < smethod_6(box))
            {
                goto Label_019B;
            }
            continue;
        Label_01DE:
            this.list_1.Add(box);
            num2++;
        Label_01F0:
            if (num2 < num3)
            {
                goto Label_01DE;
            }
            continue;
        Label_01FA:
            foreach (CssBox box3 in box.Boxes)
            {
                int num4 = smethod_6(box3);
                for (num2 = 0; num2 < num4; num2++)
                {
                    this.list_1.Add(box3);
                }
            }
        }
        if (this.cssBox_1 != null)
        {
            this.list_2.AddRange(this.cssBox_1.Boxes);
        }
        this.list_2.AddRange(this.list_0);
        if (this.cssBox_2 != null)
        {
            this.list_2.AddRange(this.cssBox_2.Boxes);
        }
    }

    private bool method_10()
    {
        for (int i = 0; i < this.double_0.Length; i++)
        {
            if (this.method_11(i))
            {
                return true;
            }
        }
        return false;
    }

    private bool method_11(int int_1)
    {
        if ((this.double_0.Length >= int_1) || (this.method_17().Length >= int_1))
        {
            return false;
        }
        return (this.double_0[int_1] > this.method_17()[int_1]);
    }

    private double method_12()
    {
        Class30 class2 = new Class30(this.object_0.Width);
        if (class2.method_0() > 0.0)
        {
            this.bool_0 = true;
            return Class43.smethod_4(this.object_0.Width, this.object_0.ParentBox.AvailableWidth, (CssBoxProperties) this.object_0, false);
        }
        return this.object_0.ParentBox.AvailableWidth;
    }

    private double method_13()
    {
        Class30 class2 = new Class30(this.object_0.MaxWidth);
        if (class2.method_0() > 0.0)
        {
            this.bool_0 = true;
            return Class43.smethod_4(this.object_0.MaxWidth, this.object_0.ParentBox.AvailableWidth, (CssBoxProperties) this.object_0, false);
        }
        return 9999.0;
    }

    private void method_14(bool bool_1, out double[] double_2, out double[] double_3)
    {
        double_3 = new double[this.double_0.Length];
        double_2 = new double[this.double_0.Length];
        foreach (CssBox box in this.list_2)
        {
            for (int i = 0; i < box.Boxes.Count; i++)
            {
                int index = smethod_2(box, box.Boxes[i]);
                index = (this.double_0.Length > index) ? index : (this.double_0.Length - 1);
                if (!((!bool_1 || double.IsNaN(this.double_0[index])) ? (i >= box.Boxes.Count) : true))
                {
                    double num4;
                    double num5;
                    box.Boxes[i].method_5(out num4, out num5);
                    int num6 = smethod_3(box.Boxes[i]);
                    num4 /= (double) num6;
                    num5 /= (double) num6;
                    for (int j = 0; j < num6; j++)
                    {
                        double_2[index + j] = Math.Max(double_2[index + j], num4);
                        double_3[index + j] = Math.Max(double_3[index + j], num5);
                    }
                }
            }
        }
    }

    private double method_15()
    {
        return (((this.method_12() - (this.method_18() * (this.int_0 + 1))) - this.object_0.ActualBorderLeftWidth) - this.object_0.ActualBorderRightWidth);
    }

    private double method_16()
    {
        double num = 0.0;
        foreach (double num3 in this.double_0)
        {
            if (double.IsNaN(num3))
            {
                throw new Exception("CssTable Algorithm error: There's a NaN in column widths");
            }
            num += num3;
        }
        num += this.method_18() * (this.double_0.Length + 1);
        return (num + (this.object_0.ActualBorderLeftWidth + this.object_0.ActualBorderRightWidth));
    }

    private double[] method_17()
    {
        if (this.double_1 == null)
        {
            this.double_1 = new double[this.double_0.Length];
            foreach (CssBox box in this.list_2)
            {
                foreach (CssBox box2 in box.Boxes)
                {
                    int num = smethod_3(box2);
                    int num2 = smethod_2(box, box2);
                    int index = Math.Min(num2 + num, this.double_1.Length) - 1;
                    double num4 = this.method_8(box, box2, num2, num) + ((num - 1) * this.method_18());
                    this.double_1[index] = Math.Max(this.double_1[index], box2.method_3() - num4);
                }
            }
        }
        return this.double_1;
    }

    private double method_18()
    {
        return ((this.object_0.BorderCollapse == "collapse") ? -1.0 : this.object_0.ActualBorderSpacingHorizontal);
    }

    private double method_19()
    {
        return ((this.object_0.BorderCollapse == "collapse") ? -1.0 : this.object_0.ActualBorderSpacingVertical);
    }

    private void method_2()
    {
        if (!this.object_0.bool_0)
        {
            int num = 0;
            List<CssBox> list = this.list_0;
            foreach (CssBox box in list)
            {
                for (int i = 0; i < box.Boxes.Count; i++)
                {
                    CssBox box2 = box.Boxes[i];
                    int num4 = smethod_4(box2);
                    int num6 = smethod_2(box, box2);
                    for (int j = num + 1; j < (num + num4); j++)
                    {
                        int num7;
                        if (list.Count > j)
                        {
                            num7 = 0;
                            for (int k = 0; k < list[j].Boxes.Count; k++)
                            {
                                if (num7 == num6)
                                {
                                    goto Label_00CA;
                                }
                                num7++;
                                num6 -= smethod_3(list[j].Boxes[k]) - 1;
                            }
                        }
                        continue;
                    Label_00CA:
                        list[j].Boxes.Insert(num7, new Class27((CssBox) this.object_0, ref box2, num));
                    }
                }
                num++;
            }
            this.object_0.bool_0 = true;
        }
    }

    private double method_3()
    {
        int num;
        if (this.list_1.Count > 0)
        {
            this.int_0 = this.list_1.Count;
        }
        else
        {
            foreach (CssBox box in this.list_2)
            {
                this.int_0 = Math.Max(this.int_0, box.Boxes.Count);
            }
        }
        this.double_0 = new double[this.int_0];
        for (num = 0; num < this.double_0.Length; num++)
        {
            this.double_0[num] = double.NaN;
        }
        double num2 = this.method_15();
        if (this.list_1.Count > 0)
        {
            num = 0;
            while (num < this.list_1.Count)
            {
                Class30 class2 = new Class30(this.list_1[num].Width);
                if (class2.method_0() > 0.0)
                {
                    if (class2.method_2())
                    {
                        this.double_0[num] = Class43.smethod_3(this.list_1[num].Width, num2);
                    }
                    else if ((class2.method_4() == ((Enum4) 2)) || (class2.method_4() == ((Enum4) 0)))
                    {
                        this.double_0[num] = class2.method_0();
                    }
                }
                num++;
            }
            return num2;
        }
        foreach (CssBox box2 in this.list_2)
        {
            for (num = 0; num < this.int_0; num++)
            {
                if (((num < 20) || double.IsNaN(this.double_0[num])) && ((num < box2.Boxes.Count) && (box2.Boxes[num].Display == "table-cell")))
                {
                    double num4 = Class43.smethod_4(box2.Boxes[num].Width, num2, box2.Boxes[num], false);
                    if (num4 > 0.0)
                    {
                        int num5 = smethod_3(box2.Boxes[num]);
                        num4 /= (double) Convert.ToSingle(num5);
                        for (int i = num; i < (num + num5); i++)
                        {
                            this.double_0[i] = double.IsNaN(this.double_0[i]) ? num4 : Math.Max(this.double_0[i], num4);
                        }
                    }
                }
            }
        }
        return num2;
    }

    private void method_4(double double_2)
    {
        double[] numArray;
        int num3;
        double num5;
        double[] numArray3;
        int num13;
        double num = 0.0;
        if (!this.bool_0)
        {
            this.method_14(true, out numArray3, out numArray);
            double num2 = 0.0;
            for (num3 = 0; num3 < numArray.Length; num3++)
            {
                if (double.IsNaN(this.double_0[num3]))
                {
                    this.double_0[num3] = numArray3[num3];
                }
                num2 += numArray[num3];
                num += this.double_0[num3];
            }
            if (num2 != 0.0)
            {
                double num7 = 0.0;
                double num9 = 0.0;
                List<int> list = new List<int>();
                for (num3 = 0; num3 < numArray.Length; num3++)
                {
                    if (numArray[num3] <= numArray3[num3])
                    {
                        num7 += numArray3[num3];
                    }
                    else
                    {
                        list.Add(num3);
                        num9 += numArray[num3];
                    }
                }
                double num11 = double_2 - num;
                if (num11 > 0.0)
                {
                    foreach (int num14 in list)
                    {
                        if (numArray[num14] > this.double_0[num14])
                        {
                            double num15 = (num11 * numArray[num14]) / num9;
                            this.double_0[num14] = (num15 < numArray[num14]) ? num15 : numArray[num14];
                        }
                    }
                }
            }
            return;
        }
        int num4 = 0;
        foreach (double num6 in this.double_0)
        {
            if (double.IsNaN(num6))
            {
                num4++;
            }
            else
            {
                num += num6;
            }
        }
        int num10 = num4;
        double[] numArray2 = null;
        if (num4 < this.double_0.Length)
        {
            numArray2 = new double[this.double_0.Length];
            for (num3 = 0; num3 < this.double_0.Length; num3++)
            {
                numArray2[num3] = this.double_0[num3];
            }
        }
        if (num4 <= 0)
        {
            goto Label_0161;
        }
        this.method_14(true, out numArray3, out numArray);
    Label_0115:
        num13 = num4;
        num3 = 0;
        while (num3 < this.double_0.Length)
        {
            num5 = (double_2 - num) / ((double) num4);
            if (double.IsNaN(this.double_0[num3]) && (num5 > numArray[num3]))
            {
                this.double_0[num3] = numArray[num3];
                num4--;
                num += numArray[num3];
            }
            num3++;
        }
        if (num13 == num4)
        {
            if (num4 > 0)
            {
                num5 = (double_2 - num) / ((double) num4);
                for (num3 = 0; num3 < this.double_0.Length; num3++)
                {
                    if (double.IsNaN(this.double_0[num3]))
                    {
                        this.double_0[num3] = num5;
                    }
                }
            }
        }
        else
        {
            goto Label_0115;
        }
    Label_0161:
        if ((num4 == 0) && (num < double_2))
        {
            if (num10 > 0)
            {
                double num12 = (double_2 - num) / ((double) num10);
                for (num3 = 0; num3 < this.double_0.Length; num3++)
                {
                    if ((numArray2 == null) || double.IsNaN(numArray2[num3]))
                    {
                        this.double_0[num3] += num12;
                    }
                }
            }
            else
            {
                for (num3 = 0; num3 < this.double_0.Length; num3++)
                {
                    this.double_0[num3] += (double_2 - num) * (this.double_0[num3] / num);
                }
            }
        }
    }

    private void method_5()
    {
        // This item is obfuscated and can not be translated.
        int num = 0;
        double num2 = this.method_16();
        while (num2 <= this.method_12())
        {
            double[] numArray;
            double[] numArray2;
            int num7;
            int length;
        Label_000C:
            if (0 != 0)
            {
                goto Label_0014;
            }
            double num3 = this.method_13();
            if (num3 >= 90999.0)
            {
                return;
            }
            num2 = this.method_16();
            if (num3 >= num2)
            {
                return;
            }
            this.method_14(false, out numArray, out numArray2);
            int index = 0;
            while (index < this.double_0.Length)
            {
                this.double_0[index] = numArray[index];
                index++;
            }
            num2 = this.method_16();
            if (num3 >= num2)
            {
                num7 = 0;
                while (num7 >= 15)
                {
                Label_021D:
                    if (0 == 0)
                    {
                        return;
                    }
                    length = 0;
                    index = 0;
                    while (index < this.double_0.Length)
                    {
                        if ((this.double_0[index] + 1.0) < numArray2[index])
                        {
                            length++;
                        }
                        index++;
                    }
                    if (length == 0)
                    {
                        length = this.double_0.Length;
                    }
                    bool flag = false;
                    double num5 = (num3 - num2) / ((double) length);
                    index = 0;
                    while (index < this.double_0.Length)
                    {
                        if ((this.double_0[index] + 0.1) < numArray2[index])
                        {
                            num5 = Math.Min(num5, numArray2[index] - this.double_0[index]);
                            flag = true;
                        }
                        index++;
                    }
                    for (index = 0; index < this.double_0.Length; index++)
                    {
                        if (!(flag && ((this.double_0[index] + 1.0) >= numArray2[index])))
                        {
                            this.double_0[index] += num5;
                        }
                    }
                    num2 = this.method_16();
                    num7++;
                }
                goto Label_021D;
            }
            for (num7 = 0; num7 >= 15; num7++)
            {
            Label_00DF:
                if (0 == 0)
                {
                    return;
                }
                length = 0;
                double num6 = 0.0;
                double num8 = 0.0;
                index = 0;
                while (index < this.double_0.Length)
                {
                    if (this.double_0[index] > (num6 + 0.1))
                    {
                        num8 = num6;
                        num6 = this.double_0[index];
                        length = 1;
                    }
                    else if (this.double_0[index] > (num6 - 0.1))
                    {
                        length++;
                    }
                    index++;
                }
                double num9 = (num8 > 0.0) ? (num6 - num8) : ((num2 - num3) / ((double) this.double_0.Length));
                if ((num9 * length) > (num2 - num3))
                {
                    num9 = (num2 - num3) / ((double) length);
                }
                for (index = 0; index < this.double_0.Length; index++)
                {
                    if (this.double_0[index] > (num6 - 0.1))
                    {
                        this.double_0[index] -= num9;
                    }
                }
                num2 = this.method_16();
            }
            goto Label_00DF;
        Label_0010:
            num++;
        Label_0014:
            if (!this.method_11(num))
            {
                goto Label_0010;
            }
            this.double_0[num]--;
            num++;
            if (num >= this.double_0.Length)
            {
                num = 0;
            }
        }
        goto Label_000C;
    }

    private void method_6()
    {
        foreach (CssBox box in this.list_2)
        {
            foreach (CssBox box2 in box.Boxes)
            {
                int num = smethod_3(box2);
                int index = smethod_2(box, box2);
                int num3 = (index + num) - 1;
                if ((this.double_0.Length > index) && (this.double_0[index] < this.method_17()[index]))
                {
                    double num4 = this.method_17()[index] - this.double_0[index];
                    this.double_0[num3] = this.method_17()[num3];
                    if (index < (this.double_0.Length - 1))
                    {
                        this.double_0[index + 1] -= num4;
                    }
                }
            }
        }
    }

    private void method_7(RGraphics rgraphics_0)
    {
        double num = Math.Max((double) (this.object_0.ClientLeft + this.method_18()), (double) 0.0);
        double num2 = Math.Max((double) (this.object_0.ClientTop + this.method_19()), (double) 0.0);
        double y = num2;
        double num4 = num;
        double num5 = 0.0;
        int num6 = 0;
        if ((this.object_0.TextAlign == "center") || (this.object_0.TextAlign == "right"))
        {
            double num11 = this.method_16();
            num = (this.object_0.TextAlign == "right") ? (this.method_12() - num11) : (num + ((this.method_12() - num11) / 2.0));
            this.object_0.Location = new RPoint(((num - this.object_0.ActualBorderLeftWidth) - this.object_0.ActualPaddingLeft) - this.method_18(), this.object_0.Location.Y);
        }
        for (int i = 0; i < this.list_2.Count; i++)
        {
            CssBox box = this.list_2[i];
            double x = num;
            int num9 = 0;
            for (int j = 0; j < box.Boxes.Count; j++)
            {
                CssBox box2 = box.Boxes[j];
                if (num9 >= this.double_0.Length)
                {
                    break;
                }
                int num12 = smethod_4(box2);
                int num13 = smethod_2(box, box2);
                double width = this.method_9(num13, box2);
                box2.Location = new RPoint(x, y);
                box2.Size = new RSize(width, 0.0);
                box2.PerformLayout(rgraphics_0);
                Class27 class2 = box2 as Class27;
                if (class2 != null)
                {
                    if (class2.method_26() == num6)
                    {
                        num5 = Math.Max(num5, class2.method_24().ActualBottom);
                    }
                }
                else if (num12 == 1)
                {
                    num5 = Math.Max(num5, box2.ActualBottom);
                }
                num4 = Math.Max(num4, box2.ActualRight);
                num9++;
                x = box2.ActualRight + this.method_18();
            }
            foreach (CssBox box2 in box.Boxes)
            {
                Class27 class3 = box2 as Class27;
                if ((class3 == null) && (smethod_4(box2) == 1))
                {
                    box2.ActualBottom = num5;
                    Class28.smethod_2(rgraphics_0, box2);
                }
                else if ((class3 != null) && (class3.method_26() == num6))
                {
                    class3.method_24().ActualBottom = num5;
                    Class28.smethod_2(rgraphics_0, class3.method_24());
                }
            }
            y = num5 + this.method_19();
            num6++;
        }
        num4 = Math.Max(num4, this.object_0.Location.X + this.object_0.ActualWidth);
        this.object_0.ActualRight = (num4 + this.method_18()) + this.object_0.ActualBorderRightWidth;
        this.object_0.ActualBottom = (Math.Max(num5, num2) + this.method_19()) + this.object_0.ActualBorderBottomWidth;
    }

    private double method_8(CssBox cssBox_3, CssBox cssBox_4, int int_1, int int_2)
    {
        // This item is obfuscated and can not be translated.
        double num = 0.0;
        for (int i = int_1; i < cssBox_3.Boxes.Count; i++)
        {
        Label_000F:
            if (1 == 0)
            {
                return num;
            }
            if (i < this.method_17().Length)
            {
                num += this.method_17()[i];
            }
        }
        goto Label_000F;
    }

    private double method_9(int int_1, CssBox cssBox_3)
    {
        double num = Convert.ToSingle(smethod_3(cssBox_3));
        double num2 = 0.0;
        for (int i = int_1; i < (int_1 + num); i++)
        {
            if ((int_1 >= this.double_0.Length) || (this.double_0.Length <= i))
            {
                break;
            }
            num2 += this.double_0[i];
        }
        return (num2 + ((num - 1.0) * this.method_18()));
    }

    public static double smethod_0(CssBox cssBox_3)
    {
        int num = 0;
        int num2 = 0;
        foreach (CssBox box in cssBox_3.Boxes)
        {
            if (box.Display == "table-column")
            {
                num2 += smethod_6(box);
            }
            else if (box.Display == "table-row-group")
            {
                foreach (CssBox box2 in cssBox_3.Boxes)
                {
                    num++;
                    if (box2.Display == "table-row")
                    {
                        num2 = Math.Max(num2, box2.Boxes.Count);
                    }
                }
            }
            else if (box.Display == "table-row")
            {
                num++;
                num2 = Math.Max(num2, box.Boxes.Count);
            }
            if (num > 30)
            {
                break;
            }
        }
        return ((num2 + 1) * smethod_7(cssBox_3));
    }

    public static void smethod_1(RGraphics rgraphics_0, CssBox cssBox_3)
    {
        ArgChecker.AssertArgNotNull(rgraphics_0, "g");
        ArgChecker.AssertArgNotNull(cssBox_3, "tableBox");
        try
        {
            new Class29(cssBox_3).method_0(rgraphics_0);
        }
        catch (Exception exception)
        {
            cssBox_3.HtmlContainer.method_8(HtmlRenderErrorType.Layout, "Failed table layout", exception);
        }
    }

    private static int smethod_2(CssBox cssBox_3, object object_1)
    {
        int num = 0;
        foreach (CssBox box in cssBox_3.Boxes)
        {
            if (box.Equals(object_1))
            {
                return num;
            }
            num += smethod_3(box);
        }
        return num;
    }

    private static int smethod_3(CssBox cssBox_3)
    {
        int num;
        if (!int.TryParse(cssBox_3.GetAttribute("colspan", "1"), out num))
        {
            return 1;
        }
        return num;
    }

    private static int smethod_4(CssBox cssBox_3)
    {
        int num;
        if (!int.TryParse(cssBox_3.GetAttribute("rowspan", "1"), out num))
        {
            return 1;
        }
        return num;
    }

    private static void smethod_5(CssBox cssBox_3, RGraphics rgraphics_0)
    {
        if (cssBox_3 != null)
        {
            foreach (CssBox box in cssBox_3.Boxes)
            {
                box.vmethod_0(rgraphics_0);
                smethod_5(box, rgraphics_0);
            }
        }
    }

    private static int smethod_6(CssBox cssBox_3)
    {
        double num = Class43.smethod_3(cssBox_3.GetAttribute("span"), 1.0);
        return Math.Max(1, Convert.ToInt32(num));
    }

    private static double smethod_7(CssBoxProperties cssBoxProperties_0)
    {
        return ((cssBoxProperties_0.BorderCollapse == "collapse") ? -1.0 : cssBoxProperties_0.ActualBorderSpacingHorizontal);
    }
}

