using System;
using System.Globalization;

internal sealed class Class30
{
    private readonly bool bool_0;
    private readonly bool bool_1;
    private readonly bool bool_2;
    private readonly double double_0;
    private readonly Enum4 enum4_0;
    private readonly string string_0;

    public Class30(string string_1)
    {
        this.string_0 = string_1;
        this.double_0 = 0.0;
        this.enum4_0 = (Enum4) 0;
        this.bool_1 = false;
        if (!string.IsNullOrEmpty(string_1) && (string_1 != "0"))
        {
            if (string_1.EndsWith("%"))
            {
                this.double_0 = Class43.smethod_3(string_1, 1.0);
                this.bool_1 = true;
            }
            else if (string_1.Length < 3)
            {
                double.TryParse(string_1, out this.double_0);
                this.bool_2 = true;
            }
            else
            {
                string str = string_1.Substring(string_1.Length - 2, 2);
                string s = string_1.Substring(0, string_1.Length - 2);
                switch (str)
                {
                    case "em":
                        this.enum4_0 = (Enum4) 1;
                        this.bool_0 = true;
                        break;

                    case "ex":
                        this.enum4_0 = (Enum4) 3;
                        this.bool_0 = true;
                        break;

                    case "px":
                        this.enum4_0 = (Enum4) 2;
                        this.bool_0 = true;
                        break;

                    case "mm":
                        this.enum4_0 = (Enum4) 6;
                        break;

                    case "cm":
                        this.enum4_0 = (Enum4) 5;
                        break;

                    case "in":
                        this.enum4_0 = (Enum4) 4;
                        break;

                    case "pt":
                        this.enum4_0 = (Enum4) 7;
                        break;

                    case "pc":
                        this.enum4_0 = (Enum4) 8;
                        break;

                    default:
                        this.bool_2 = true;
                        return;
                }
                if (!double.TryParse(s, NumberStyles.Number, (IFormatProvider) NumberFormatInfo.InvariantInfo, out this.double_0))
                {
                    this.bool_2 = true;
                }
            }
        }
    }

    public double method_0()
    {
        return this.double_0;
    }

    public bool method_1()
    {
        return this.bool_2;
    }

    public bool method_2()
    {
        return this.bool_1;
    }

    public bool method_3()
    {
        return this.bool_0;
    }

    public Enum4 method_4()
    {
        return this.enum4_0;
    }

    public string method_5()
    {
        return this.string_0;
    }

    public Class30 method_6(double double_1)
    {
        if (this.method_1())
        {
            throw new InvalidOperationException("Invalid length");
        }
        if (this.method_4() != ((Enum4) 1))
        {
            throw new InvalidOperationException("Length is not in ems");
        }
        return new Class30(string.Format("{0}pt", Convert.ToSingle((double) (this.method_0() * double_1)).ToString("0.0", NumberFormatInfo.InvariantInfo)));
    }

    public Class30 method_7(double double_1)
    {
        if (this.method_1())
        {
            throw new InvalidOperationException("Invalid length");
        }
        if (this.method_4() != ((Enum4) 1))
        {
            throw new InvalidOperationException("Length is not in ems");
        }
        return new Class30(string.Format("{0}px", Convert.ToSingle((double) (this.method_0() * double_1)).ToString("0.0", NumberFormatInfo.InvariantInfo)));
    }

    public override string ToString()
    {
        if (this.method_1())
        {
            return string.Empty;
        }
        if (this.method_2())
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0}%", new object[] { this.method_0() });
        }
        string str = string.Empty;
        switch (this.method_4())
        {
            case ((Enum4) 1):
                str = "em";
                break;

            case ((Enum4) 2):
                str = "px";
                break;

            case ((Enum4) 3):
                str = "ex";
                break;

            case ((Enum4) 4):
                str = "in";
                break;

            case ((Enum4) 5):
                str = "cm";
                break;

            case ((Enum4) 6):
                str = "mm";
                break;

            case ((Enum4) 7):
                str = "pt";
                break;

            case ((Enum4) 8):
                str = "pc";
                break;
        }
        return string.Format(NumberFormatInfo.InvariantInfo, "{0}{1}", new object[] { this.method_0(), str });
    }
}

