using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Utils;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

internal sealed class Class43
{
    private readonly RAdapter radapter_0;

    public Class43(RAdapter radapter_1)
    {
        ArgChecker.AssertArgNotNull(radapter_1, "global");
        this.radapter_0 = radapter_1;
    }

    public bool method_0(string string_0)
    {
        RColor color;
        return this.method_2(string_0, 0, string_0.Length, out color);
    }

    public RColor method_1(string string_0)
    {
        RColor color;
        this.method_2(string_0, 0, string_0.Length, out color);
        return color;
    }

    public bool method_2(string string_0, int int_0, int int_1, out RColor rcolor_0)
    {
        try
        {
            if (!string.IsNullOrEmpty(string_0))
            {
                if ((int_1 > 1) && (string_0[int_0] == '#'))
                {
                    return smethod_9(string_0, int_0, int_1, out rcolor_0);
                }
                if (((int_1 > 10) && Class48.smethod_11(string_0, int_0, 4, "rgb(")) && (string_0[int_1 - 1] == ')'))
                {
                    return smethod_10(string_0, int_0, int_1, out rcolor_0);
                }
                if (((int_1 > 13) && Class48.smethod_11(string_0, int_0, 5, "rgba(")) && (string_0[int_1 - 1] == ')'))
                {
                    return smethod_11(string_0, int_0, int_1, out rcolor_0);
                }
                return this.method_3(string_0, int_0, int_1, out rcolor_0);
            }
        }
        catch
        {
        }
        rcolor_0 = RColor.Black;
        return false;
    }

    private bool method_3(string string_0, int int_0, int int_1, out RColor rcolor_0)
    {
        rcolor_0 = this.radapter_0.GetColor(string_0.Substring(int_0, int_1));
        return (rcolor_0.A > 0);
    }

    public static bool smethod_0(string string_0, int int_0, int int_1)
    {
        if (int_1 < 1)
        {
            return false;
        }
        bool flag2 = false;
        for (int i = 0; i < int_1; i++)
        {
            if (string_0[int_0 + i] == '.')
            {
                if (flag2)
                {
                    return false;
                }
                flag2 = true;
            }
            else if (!char.IsDigit(string_0[int_0 + i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool smethod_1(string string_0, int int_0, int int_1)
    {
        if (int_1 < 1)
        {
            return false;
        }
        for (int i = 0; i < int_1; i++)
        {
            if (!char.IsDigit(string_0[int_0 + i]))
            {
                return false;
            }
        }
        return true;
    }

    private static bool smethod_10(string string_0, int int_0, int int_1, out RColor rcolor_0)
    {
        int red = -1;
        int green = -1;
        int blue = -1;
        if (int_1 > 10)
        {
            int num4 = int_0 + 4;
            red = smethod_12(string_0, ref num4);
            if (num4 < (int_0 + int_1))
            {
                green = smethod_12(string_0, ref num4);
            }
            if (num4 < (int_0 + int_1))
            {
                blue = smethod_12(string_0, ref num4);
            }
        }
        if (((red > -1) && (green > -1)) && (blue > -1))
        {
            rcolor_0 = RColor.FromArgb(red, green, blue);
            return true;
        }
        rcolor_0 = RColor.Empty;
        return false;
    }

    private static bool smethod_11(string string_0, int int_0, int int_1, out RColor rcolor_0)
    {
        int red = -1;
        int green = -1;
        int blue = -1;
        int alpha = -1;
        if (int_1 > 13)
        {
            int num5 = int_0 + 5;
            red = smethod_12(string_0, ref num5);
            if (num5 < (int_0 + int_1))
            {
                green = smethod_12(string_0, ref num5);
            }
            if (num5 < (int_0 + int_1))
            {
                blue = smethod_12(string_0, ref num5);
            }
            if (num5 < (int_0 + int_1))
            {
                alpha = smethod_12(string_0, ref num5);
            }
        }
        if ((((red > -1) && (green > -1)) && (blue > -1)) && (alpha > -1))
        {
            rcolor_0 = RColor.FromArgb(alpha, red, green, blue);
            return true;
        }
        rcolor_0 = RColor.Empty;
        return false;
    }

    private static int smethod_12(string string_0, ref int int_0)
    {
        int num = 0;
        while (char.IsWhiteSpace(string_0, int_0))
        {
            int_0++;
        }
        while (char.IsDigit(string_0, int_0 + num))
        {
            num++;
        }
        int num2 = smethod_13(string_0, int_0, num);
        int_0 = (int_0 + num) + 1;
        return num2;
    }

    private static int smethod_13(string string_0, int int_0, int int_1)
    {
        if (int_1 < 1)
        {
            return -1;
        }
        int num4 = 0;
        for (int i = 0; i < int_1; i++)
        {
            int num3 = string_0[int_0 + i];
            if ((num3 < 0x30) || (num3 > 0x39))
            {
                return -1;
            }
            num4 = ((num4 * 10) + num3) - 0x30;
        }
        return num4;
    }

    private static int smethod_14(string string_0, int int_0, int int_1)
    {
        if (int_1 < 1)
        {
            return -1;
        }
        int num4 = 0;
        for (int i = 0; i < int_1; i++)
        {
            int num2 = string_0[int_0 + i];
            if (!((((num2 < 0x30) || (num2 > 0x39)) && ((num2 < 0x41) || (num2 > 70))) ? ((num2 >= 0x61) && (num2 <= 0x66)) : true))
            {
                return -1;
            }
            num4 = (num4 * 0x10) + ((num2 <= 0x39) ? (num2 - 0x30) : ((10 + num2) - ((num2 <= 70) ? 0x41 : 0x61)));
        }
        return num4;
    }

    public static bool smethod_2(string string_0)
    {
        if (string_0.Length > 1)
        {
            double num;
            string s = string.Empty;
            if (string_0.EndsWith("%"))
            {
                s = string_0.Substring(0, string_0.Length - 1);
            }
            else if (string_0.Length > 2)
            {
                s = string_0.Substring(0, string_0.Length - 2);
            }
            return double.TryParse(s, out num);
        }
        return false;
    }

    public static double smethod_3(string string_0, double double_0)
    {
        double num2;
        bool flag;
        if (string.IsNullOrEmpty(string_0))
        {
            return 0.0;
        }
        string s = string_0;
        if (flag = string_0.EndsWith("%"))
        {
            s = string_0.Substring(0, string_0.Length - 1);
        }
        if (!double.TryParse(s, NumberStyles.Number, (IFormatProvider) NumberFormatInfo.InvariantInfo, out num2))
        {
            return 0.0;
        }
        if (flag)
        {
            num2 = (num2 / 100.0) * double_0;
        }
        return num2;
    }

    public static double smethod_4(string string_0, double double_0, CssBoxProperties cssBoxProperties_0, bool bool_0 = false)
    {
        return smethod_6(string_0, double_0, cssBoxProperties_0.GetEmHeight(), null, bool_0, false);
    }

    public static double smethod_5(string string_0, double double_0, CssBoxProperties cssBoxProperties_0, object object_0)
    {
        return smethod_6(string_0, double_0, cssBoxProperties_0.GetEmHeight(), object_0, false, false);
    }

    public static double smethod_6(string string_0, double double_0, double double_1, object object_0, bool bool_0, bool bool_1)
    {
        double num;
        bool flag;
        if (string.IsNullOrEmpty(string_0) || (string_0 == "0"))
        {
            return 0.0;
        }
        if (string_0.EndsWith("%"))
        {
            return smethod_3(string_0, double_0);
        }
        string str3 = smethod_7(string_0, object_0, out flag);
        string str = flag ? string_0.Substring(0, string_0.Length - 2) : string_0;
        switch (str3)
        {
            case "em":
                num = double_1;
                break;

            case "ex":
                num = double_1 / 2.0;
                break;

            case "px":
                num = bool_0 ? ((double) 0.75f) : ((double) 1f);
                break;

            case "mm":
                num = 3.7795276641845703;
                break;

            case "cm":
                num = 37.7952766418457;
                break;

            case "in":
                num = 96.0;
                break;

            case "pt":
                num = 1.3333333333333333;
                if (!bool_1)
                {
                    break;
                }
                return smethod_3(str, double_0);

            case "pc":
                num = 16.0;
                break;

            default:
                num = 0.0;
                break;
        }
        return (num * smethod_3(str, double_0));
    }

    private static string smethod_7(string string_0, object object_0, out bool bool_0)
    {
        string str = (string_0.Length >= 3) ? string_0.Substring(string_0.Length - 2, 2) : string.Empty;
        switch (str)
        {
            case "em":
            case "ex":
            case "px":
            case "mm":
            case "cm":
            case "in":
            case "pt":
            case "pc":
                bool_0 = true;
                return str;
        }
        bool_0 = false;
        return (object_0 ?? string.Empty);
    }

    public static double smethod_8(string string_0, CssBoxProperties cssBoxProperties_0)
    {
        if (string.IsNullOrEmpty(string_0))
        {
            return smethod_8("medium", cssBoxProperties_0);
        }
        string str = string_0;
        switch (str)
        {
            case null:
                break;

            case "thin":
                return 1.0;

            default:
                if (!(str == "medium"))
                {
                    if (str == "thick")
                    {
                        return 4.0;
                    }
                }
                else
                {
                    return 2.0;
                }
                break;
        }
        return Math.Abs(smethod_4(string_0, 1.0, cssBoxProperties_0, false));
    }

    private static bool smethod_9(string string_0, int int_0, int int_1, out RColor rcolor_0)
    {
        int red = -1;
        int green = -1;
        int blue = -1;
        if (int_1 == 7)
        {
            red = smethod_14(string_0, int_0 + 1, 2);
            green = smethod_14(string_0, int_0 + 3, 2);
            blue = smethod_14(string_0, int_0 + 5, 2);
        }
        else if (int_1 == 4)
        {
            red = smethod_14(string_0, int_0 + 1, 1);
            red = (red * 0x10) + red;
            green = smethod_14(string_0, int_0 + 2, 1);
            green = (green * 0x10) + green;
            blue = smethod_14(string_0, int_0 + 3, 1);
            blue = (blue * 0x10) + blue;
        }
        if (((red > -1) && (green > -1)) && (blue > -1))
        {
            rcolor_0 = RColor.FromArgb(red, green, blue);
            return true;
        }
        rcolor_0 = RColor.Empty;
        return false;
    }
}

