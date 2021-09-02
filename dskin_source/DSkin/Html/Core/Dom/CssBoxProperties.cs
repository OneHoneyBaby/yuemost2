namespace DSkin.Html.Core.Dom
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public abstract class CssBoxProperties
    {
        private double adxjhywlwJ = double.NaN;
        private double aemjdAbuhO = double.NaN;
        private double double_0 = double.NaN;
        private double double_1 = double.NaN;
        private double double_10 = double.NaN;
        private double double_11 = double.NaN;
        private double double_12 = double.NaN;
        private double double_13 = double.NaN;
        private double double_14 = double.NaN;
        private double double_15 = double.NaN;
        private double double_16 = double.NaN;
        private double double_17 = double.NaN;
        private double double_18 = double.NaN;
        private double double_19 = double.NaN;
        private double double_2 = double.NaN;
        private double double_20 = double.NaN;
        private double double_21 = double.NaN;
        private double double_3 = double.NaN;
        private double double_4 = double.NaN;
        private double double_5 = double.NaN;
        private double double_6 = double.NaN;
        private double double_7 = double.NaN;
        private double double_8 = double.NaN;
        private double double_9 = double.NaN;
        private string gnNjtxdkeT;
        private double PcUjsaoUbR = double.NaN;
        private RColor rcolor_0 = RColor.Empty;
        private RColor rcolor_1 = RColor.Empty;
        private RColor rcolor_2 = RColor.Empty;
        private RColor rcolor_3 = RColor.Empty;
        private RColor rcolor_4 = RColor.Empty;
        private RColor rcolor_5 = RColor.Empty;
        private RColor rcolor_6 = RColor.Empty;
        private RFont rfont_0;
        private RPoint rpoint_0;
        private RSize rsize_0;
        private string string_0 = "transparent";
        private string string_1 = "none";
        private string string_10 = "black";
        private string string_11 = "black";
        private string string_12 = "black";
        private string string_13 = "black";
        private string string_14 = "none";
        private string string_15 = "none";
        private string string_16 = "none";
        private string string_17 = "none";
        private string string_18 = "0";
        private string string_19 = "separate";
        private string string_2 = "90";
        private string string_20;
        private string string_21 = "black";
        private string string_22 = "0";
        private string string_23 = "0";
        private string string_24 = "0";
        private string string_25 = "0";
        private string string_26 = "0";
        private string string_27 = "show";
        private string string_28 = "ltr";
        private string string_29 = "inline";
        private string string_3 = "none";
        private string string_30 = "medium";
        private string string_31 = "normal";
        private string string_32 = "normal";
        private string string_33 = "normal";
        private string string_34 = "none";
        private string string_35 = "auto";
        private string string_36 = "0";
        private string string_37 = "0";
        private string string_38 = "0";
        private string string_39 = "0";
        private string string_4 = "0% 0%";
        private string string_40 = "auto";
        private string string_41 = "normal";
        private string string_42 = "disc";
        private string string_43 = string.Empty;
        private string string_44 = "outside";
        private string string_45 = string.Empty;
        private string string_46 = "visible";
        private string string_47 = "0";
        private string string_48 = "0";
        private string string_49 = "0";
        private string string_5 = "repeat";
        private string string_50 = "0";
        private string string_51;
        private string string_52 = string.Empty;
        private string string_53 = string.Empty;
        private string string_54 = "0";
        private string string_55 = "auto";
        private string string_56 = "static";
        private string string_57 = "baseline";
        private string string_58 = "auto";
        private string string_59 = "none";
        private string string_6 = "medium";
        private string string_60 = "normal";
        private string string_61 = "normal";
        private string string_62 = "normal";
        private string string_63 = "visible";
        private string string_7 = "medium";
        private string string_8 = "medium";
        private string string_9 = "medium";

        protected CssBoxProperties()
        {
        }

        protected abstract RColor GetActualColor(string colorStr);
        protected abstract RFont GetCachedFont(string fontFamily, double fsize, RFontStyle st);
        public double GetEmHeight()
        {
            return this.ActualFont.Height;
        }

        protected abstract CssBoxProperties GetParent();
        protected void InheritStyle(CssBox p, bool everything)
        {
            if (p != null)
            {
                this.string_18 = p.string_18;
                this.string_19 = p.string_19;
                this.string_21 = p.string_21;
                this.string_27 = p.string_27;
                this.string_62 = p.string_62;
                this.string_63 = p.string_63;
                this.string_54 = p.string_54;
                this.string_52 = p.string_52;
                this.string_57 = p.string_57;
                this.gnNjtxdkeT = p.gnNjtxdkeT;
                this.string_30 = p.string_30;
                this.string_31 = p.string_31;
                this.string_32 = p.string_32;
                this.string_33 = p.string_33;
                this.string_43 = p.string_43;
                this.string_44 = p.string_44;
                this.string_42 = p.string_42;
                this.string_45 = p.string_45;
                this.string_41 = p.string_41;
                this.string_61 = p.WordBreak;
                this.string_28 = p.string_28;
                if (everything)
                {
                    this.string_0 = p.string_0;
                    this.string_1 = p.string_1;
                    this.string_2 = p.string_2;
                    this.string_3 = p.string_3;
                    this.string_4 = p.string_4;
                    this.string_5 = p.string_5;
                    this.string_6 = p.string_6;
                    this.string_7 = p.string_7;
                    this.string_8 = p.string_8;
                    this.string_9 = p.string_9;
                    this.string_10 = p.string_10;
                    this.string_11 = p.string_11;
                    this.string_12 = p.string_12;
                    this.string_13 = p.string_13;
                    this.string_14 = p.string_14;
                    this.string_15 = p.string_15;
                    this.string_16 = p.string_16;
                    this.string_17 = p.string_17;
                    this.string_20 = p.string_20;
                    this.string_22 = p.string_22;
                    this.string_23 = p.string_23;
                    this.string_24 = p.string_24;
                    this.string_25 = p.string_25;
                    this.string_26 = p.string_26;
                    this.string_29 = p.string_29;
                    this.string_34 = p.string_34;
                    this.string_35 = p.string_35;
                    this.string_36 = p.string_36;
                    this.string_37 = p.string_37;
                    this.string_38 = p.string_38;
                    this.string_39 = p.string_39;
                    this.string_40 = p.string_40;
                    this.string_41 = p.string_41;
                    this.string_46 = p.string_46;
                    this.string_47 = p.string_47;
                    this.string_48 = p.string_48;
                    this.string_49 = p.string_49;
                    this.string_50 = p.string_50;
                    this.string_51 = p.string_51;
                    this.string_53 = p.string_53;
                    this.string_55 = p.string_55;
                    this.string_56 = p.string_56;
                    this.string_58 = p.string_58;
                    this.string_59 = p.string_59;
                    this.string_60 = p.string_60;
                }
            }
        }

        protected void MeasureWordSpacing(RGraphics g)
        {
            if (double.IsNaN(this.ActualWordSpacing))
            {
                this.double_18 = Class49.smethod_1(g, this);
                if (this.WordSpacing != "normal")
                {
                    string str = Class47.smethod_2(@"([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.WordSpacing);
                    this.double_18 += Class43.smethod_4(str, 1.0, this, false);
                }
            }
        }

        protected string NoEms(string length)
        {
            Class30 class2 = new Class30(length);
            if (class2.method_4() == ((Enum4) 1))
            {
                length = class2.method_7(this.GetEmHeight()).ToString();
            }
            return length;
        }

        protected void SetAllBorders(string style = null, string width = null, string color = null)
        {
            string str;
            if (style != null)
            {
                this.BorderBottomStyle = str = style;
                this.BorderRightStyle = str = str;
                this.BorderLeftStyle = this.BorderTopStyle = str;
            }
            if (width != null)
            {
                this.BorderBottomWidth = str = width;
                this.BorderRightWidth = str = str;
                this.BorderLeftWidth = this.BorderTopWidth = str;
            }
            if (color != null)
            {
                this.BorderBottomColor = str = color;
                this.BorderRightColor = str = str;
                this.BorderLeftColor = this.BorderTopColor = str;
            }
        }

        public RColor ActualBackgroundColor
        {
            get
            {
                if (this.rcolor_6.IsEmpty)
                {
                    this.rcolor_6 = this.GetActualColor(this.BackgroundColor);
                }
                return this.rcolor_6;
            }
        }

        public RColor ActualBackgroundGradient
        {
            get
            {
                if (this.rcolor_1.IsEmpty)
                {
                    this.rcolor_1 = this.GetActualColor(this.BackgroundGradient);
                }
                return this.rcolor_1;
            }
        }

        public double ActualBackgroundGradientAngle
        {
            get
            {
                if (double.IsNaN(this.PcUjsaoUbR))
                {
                    this.PcUjsaoUbR = Class43.smethod_3(this.BackgroundGradientAngle, 360.0);
                }
                return this.PcUjsaoUbR;
            }
        }

        public RColor ActualBorderBottomColor
        {
            get
            {
                if (this.rcolor_4.IsEmpty)
                {
                    this.rcolor_4 = this.GetActualColor(this.BorderBottomColor);
                }
                return this.rcolor_4;
            }
        }

        public double ActualBorderBottomWidth
        {
            get
            {
                if (double.IsNaN(this.double_15))
                {
                    this.double_15 = Class43.smethod_8(this.BorderBottomWidth, this);
                    if (string.IsNullOrEmpty(this.BorderBottomStyle) || (this.BorderBottomStyle == "none"))
                    {
                        this.double_15 = 0.0;
                    }
                }
                return this.double_15;
            }
        }

        public RColor ActualBorderLeftColor
        {
            get
            {
                if (this.rcolor_3.IsEmpty)
                {
                    this.rcolor_3 = this.GetActualColor(this.BorderLeftColor);
                }
                return this.rcolor_3;
            }
        }

        public double ActualBorderLeftWidth
        {
            get
            {
                if (double.IsNaN(this.double_14))
                {
                    this.double_14 = Class43.smethod_8(this.BorderLeftWidth, this);
                    if (string.IsNullOrEmpty(this.BorderLeftStyle) || (this.BorderLeftStyle == "none"))
                    {
                        this.double_14 = 0.0;
                    }
                }
                return this.double_14;
            }
        }

        public RColor ActualBorderRightColor
        {
            get
            {
                if (this.rcolor_5.IsEmpty)
                {
                    this.rcolor_5 = this.GetActualColor(this.BorderRightColor);
                }
                return this.rcolor_5;
            }
        }

        public double ActualBorderRightWidth
        {
            get
            {
                if (double.IsNaN(this.double_16))
                {
                    this.double_16 = Class43.smethod_8(this.BorderRightWidth, this);
                    if (string.IsNullOrEmpty(this.BorderRightStyle) || (this.BorderRightStyle == "none"))
                    {
                        this.double_16 = 0.0;
                    }
                }
                return this.double_16;
            }
        }

        public double ActualBorderSpacingHorizontal
        {
            get
            {
                if (double.IsNaN(this.double_20))
                {
                    MatchCollection matchs = Class47.smethod_1(@"([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.BorderSpacing);
                    if (matchs.Count == 0)
                    {
                        this.double_20 = 0.0;
                    }
                    else if (matchs.Count > 0)
                    {
                        this.double_20 = Class43.smethod_4(matchs[0].Value, 1.0, this, false);
                    }
                }
                return this.double_20;
            }
        }

        public double ActualBorderSpacingVertical
        {
            get
            {
                if (double.IsNaN(this.double_21))
                {
                    MatchCollection matchs = Class47.smethod_1(@"([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.BorderSpacing);
                    if (matchs.Count == 0)
                    {
                        this.double_21 = 0.0;
                    }
                    else if (matchs.Count == 1)
                    {
                        this.double_21 = Class43.smethod_4(matchs[0].Value, 1.0, this, false);
                    }
                    else
                    {
                        this.double_21 = Class43.smethod_4(matchs[1].Value, 1.0, this, false);
                    }
                }
                return this.double_21;
            }
        }

        public RColor ActualBorderTopColor
        {
            get
            {
                if (this.rcolor_2.IsEmpty)
                {
                    this.rcolor_2 = this.GetActualColor(this.BorderTopColor);
                }
                return this.rcolor_2;
            }
        }

        public double ActualBorderTopWidth
        {
            get
            {
                if (double.IsNaN(this.double_13))
                {
                    this.double_13 = Class43.smethod_8(this.BorderTopWidth, this);
                    if (string.IsNullOrEmpty(this.BorderTopStyle) || (this.BorderTopStyle == "none"))
                    {
                        this.double_13 = 0.0;
                    }
                }
                return this.double_13;
            }
        }

        public double ActualBottom
        {
            get
            {
                return (this.Location.Y + this.Size.Height);
            }
            set
            {
                this.Size = new RSize(this.Size.Width, value - this.Location.Y);
            }
        }

        public RColor ActualColor
        {
            get
            {
                if (this.rcolor_0.IsEmpty)
                {
                    this.rcolor_0 = this.GetActualColor(this.Color);
                }
                return this.rcolor_0;
            }
        }

        public double ActualCornerNe
        {
            get
            {
                if (double.IsNaN(this.double_1))
                {
                    this.double_1 = Class43.smethod_4(this.CornerNeRadius, 0.0, this, false);
                }
                return this.double_1;
            }
        }

        public double ActualCornerNw
        {
            get
            {
                if (double.IsNaN(this.double_0))
                {
                    this.double_0 = Class43.smethod_4(this.CornerNwRadius, 0.0, this, false);
                }
                return this.double_0;
            }
        }

        public double ActualCornerSe
        {
            get
            {
                if (double.IsNaN(this.double_3))
                {
                    this.double_3 = Class43.smethod_4(this.CornerSeRadius, 0.0, this, false);
                }
                return this.double_3;
            }
        }

        public double ActualCornerSw
        {
            get
            {
                if (double.IsNaN(this.double_2))
                {
                    this.double_2 = Class43.smethod_4(this.CornerSwRadius, 0.0, this, false);
                }
                return this.double_2;
            }
        }

        public RFont ActualFont
        {
            get
            {
                if (this.rfont_0 == null)
                {
                    double num;
                    if (string.IsNullOrEmpty(this.FontFamily))
                    {
                        this.FontFamily = "Segoe UI";
                    }
                    if (string.IsNullOrEmpty(this.FontSize))
                    {
                        this.FontSize = 11.0.ToString(CultureInfo.InvariantCulture) + "pt";
                    }
                    RFontStyle regular = RFontStyle.Regular;
                    if ((this.FontStyle == "italic") || (this.FontStyle == "oblique"))
                    {
                        regular |= RFontStyle.Italic;
                    }
                    if ((((this.FontWeight != "normal") && (this.FontWeight != "lighter")) && !string.IsNullOrEmpty(this.FontWeight)) && (this.FontWeight != "inherit"))
                    {
                        regular |= RFontStyle.Bold;
                    }
                    double size = 11.0;
                    if (this.GetParent() != null)
                    {
                        size = this.GetParent().ActualFont.Size;
                    }
                    switch (this.FontSize)
                    {
                        case "medium":
                            num = 11.0;
                            break;

                        case "xx-small":
                            num = 7.0;
                            break;

                        case "x-small":
                            num = 8.0;
                            break;

                        case "small":
                            num = 9.0;
                            break;

                        case "large":
                            num = 13.0;
                            break;

                        case "x-large":
                            num = 14.0;
                            break;

                        case "xx-large":
                            num = 15.0;
                            break;

                        case "smaller":
                            num = size - 2.0;
                            break;

                        case "larger":
                            num = size + 2.0;
                            break;

                        default:
                            num = Class43.smethod_6(this.FontSize, size, size, null, true, true);
                            break;
                    }
                    if (num <= 1.0)
                    {
                        num = 11.0;
                    }
                    this.rfont_0 = this.GetCachedFont(this.FontFamily, num, regular);
                }
                return this.rfont_0;
            }
        }

        public double ActualHeight
        {
            get
            {
                if (double.IsNaN(this.double_4))
                {
                    this.double_4 = Class43.smethod_4(this.Height, this.Size.Height, this, false);
                }
                return this.double_4;
            }
        }

        public double ActualLineHeight
        {
            get
            {
                if (double.IsNaN(this.double_17))
                {
                    this.double_17 = 0.89999997615814209 * Class43.smethod_4(this.LineHeight, this.Size.Height, this, false);
                }
                return this.double_17;
            }
        }

        public double ActualMarginBottom
        {
            get
            {
                if (double.IsNaN(this.double_10))
                {
                    if (this.MarginBottom == "auto")
                    {
                        this.MarginBottom = "0";
                    }
                    double num = Class43.smethod_4(this.MarginBottom, this.Size.Width, this, false);
                    if (this.MarginLeft.EndsWith("%"))
                    {
                        return num;
                    }
                    this.double_10 = num;
                }
                return this.double_10;
            }
        }

        public double ActualMarginLeft
        {
            get
            {
                if (double.IsNaN(this.double_12))
                {
                    if (this.MarginLeft == "auto")
                    {
                        this.MarginLeft = "0";
                    }
                    double num2 = Class43.smethod_4(this.MarginLeft, this.Size.Width, this, false);
                    if (this.MarginLeft.EndsWith("%"))
                    {
                        return num2;
                    }
                    this.double_12 = num2;
                }
                return this.double_12;
            }
        }

        public double ActualMarginRight
        {
            get
            {
                if (double.IsNaN(this.double_11))
                {
                    if (this.MarginRight == "auto")
                    {
                        this.MarginRight = "0";
                    }
                    double num2 = Class43.smethod_4(this.MarginRight, this.Size.Width, this, false);
                    if (this.MarginLeft.EndsWith("%"))
                    {
                        return num2;
                    }
                    this.double_11 = num2;
                }
                return this.double_11;
            }
        }

        public double ActualMarginTop
        {
            get
            {
                if (double.IsNaN(this.double_8))
                {
                    if (this.MarginTop == "auto")
                    {
                        this.MarginTop = "0";
                    }
                    double num = Class43.smethod_4(this.MarginTop, this.Size.Width, this, false);
                    if (this.MarginLeft.EndsWith("%"))
                    {
                        return num;
                    }
                    this.double_8 = num;
                }
                return this.double_8;
            }
        }

        public double ActualPaddingBottom
        {
            get
            {
                if (double.IsNaN(this.double_5))
                {
                    this.double_5 = Class43.smethod_4(this.PaddingBottom, this.Size.Width, this, false);
                }
                return this.double_5;
            }
        }

        public double ActualPaddingLeft
        {
            get
            {
                if (double.IsNaN(this.double_7))
                {
                    this.double_7 = Class43.smethod_4(this.PaddingLeft, this.Size.Width, this, false);
                }
                return this.double_7;
            }
        }

        public double ActualPaddingRight
        {
            get
            {
                if (double.IsNaN(this.double_6))
                {
                    this.double_6 = Class43.smethod_4(this.PaddingRight, this.Size.Width, this, false);
                }
                return this.double_6;
            }
        }

        public double ActualPaddingTop
        {
            get
            {
                if (double.IsNaN(this.adxjhywlwJ))
                {
                    this.adxjhywlwJ = Class43.smethod_4(this.PaddingTop, this.Size.Width, this, false);
                }
                return this.adxjhywlwJ;
            }
        }

        public RFont ActualParentFont
        {
            get
            {
                return ((this.GetParent() == null) ? this.ActualFont : this.GetParent().ActualFont);
            }
        }

        public double ActualRight
        {
            get
            {
                return (this.Location.X + this.Size.Width);
            }
            set
            {
                this.Size = new RSize(value - this.Location.X, this.Size.Height);
            }
        }

        public double ActualTextIndent
        {
            get
            {
                if (double.IsNaN(this.double_19))
                {
                    this.double_19 = Class43.smethod_4(this.TextIndent, this.Size.Width, this, false);
                }
                return this.double_19;
            }
        }

        public double ActualWidth
        {
            get
            {
                if (double.IsNaN(this.aemjdAbuhO))
                {
                    this.aemjdAbuhO = Class43.smethod_4(this.Width, this.Size.Width, this, false);
                }
                return this.aemjdAbuhO;
            }
        }

        public double ActualWordSpacing
        {
            get
            {
                return this.double_18;
            }
        }

        public double AvailableWidth
        {
            get
            {
                return ((((this.Size.Width - this.ActualBorderLeftWidth) - this.ActualPaddingLeft) - this.ActualPaddingRight) - this.ActualBorderRightWidth);
            }
        }

        public string BackgroundColor
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public string BackgroundGradient
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        public string BackgroundGradientAngle
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        public string BackgroundImage
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
            }
        }

        public string BackgroundPosition
        {
            get
            {
                return this.string_4;
            }
            set
            {
                this.string_4 = value;
            }
        }

        public string BackgroundRepeat
        {
            get
            {
                return this.string_5;
            }
            set
            {
                this.string_5 = value;
            }
        }

        public string BorderBottomColor
        {
            get
            {
                return this.string_12;
            }
            set
            {
                this.string_12 = value;
                this.rcolor_4 = RColor.Empty;
            }
        }

        public string BorderBottomStyle
        {
            get
            {
                return this.string_16;
            }
            set
            {
                this.string_16 = value;
            }
        }

        public string BorderBottomWidth
        {
            get
            {
                return this.string_8;
            }
            set
            {
                this.string_8 = value;
                this.double_15 = double.NaN;
            }
        }

        public string BorderCollapse
        {
            get
            {
                return this.string_19;
            }
            set
            {
                this.string_19 = value;
            }
        }

        public string BorderLeftColor
        {
            get
            {
                return this.string_13;
            }
            set
            {
                this.string_13 = value;
                this.rcolor_3 = RColor.Empty;
            }
        }

        public string BorderLeftStyle
        {
            get
            {
                return this.string_17;
            }
            set
            {
                this.string_17 = value;
            }
        }

        public string BorderLeftWidth
        {
            get
            {
                return this.string_9;
            }
            set
            {
                this.string_9 = value;
                this.double_14 = double.NaN;
            }
        }

        public string BorderRightColor
        {
            get
            {
                return this.string_11;
            }
            set
            {
                this.string_11 = value;
                this.rcolor_5 = RColor.Empty;
            }
        }

        public string BorderRightStyle
        {
            get
            {
                return this.string_15;
            }
            set
            {
                this.string_15 = value;
            }
        }

        public string BorderRightWidth
        {
            get
            {
                return this.string_7;
            }
            set
            {
                this.string_7 = value;
                this.double_16 = double.NaN;
            }
        }

        public string BorderSpacing
        {
            get
            {
                return this.string_18;
            }
            set
            {
                this.string_18 = value;
            }
        }

        public string BorderTopColor
        {
            get
            {
                return this.string_10;
            }
            set
            {
                this.string_10 = value;
                this.rcolor_2 = RColor.Empty;
            }
        }

        public string BorderTopStyle
        {
            get
            {
                return this.string_14;
            }
            set
            {
                this.string_14 = value;
            }
        }

        public string BorderTopWidth
        {
            get
            {
                return this.string_6;
            }
            set
            {
                this.string_6 = value;
                this.double_13 = double.NaN;
            }
        }

        public RRect Bounds
        {
            get
            {
                return new RRect(this.Location, this.Size);
            }
        }

        public double ClientBottom
        {
            get
            {
                return ((this.ActualBottom - this.ActualPaddingBottom) - this.ActualBorderBottomWidth);
            }
        }

        public double ClientLeft
        {
            get
            {
                return ((this.Location.X + this.ActualBorderLeftWidth) + this.ActualPaddingLeft);
            }
        }

        public RRect ClientRectangle
        {
            get
            {
                return RRect.FromLTRB(this.ClientLeft, this.ClientTop, this.ClientRight, this.ClientBottom);
            }
        }

        public double ClientRight
        {
            get
            {
                return ((this.ActualRight - this.ActualPaddingRight) - this.ActualBorderRightWidth);
            }
        }

        public double ClientTop
        {
            get
            {
                return ((this.Location.Y + this.ActualBorderTopWidth) + this.ActualPaddingTop);
            }
        }

        public double CollapsedMarginTop
        {
            get
            {
                return (double.IsNaN(this.double_9) ? 0.0 : this.double_9);
            }
            set
            {
                this.double_9 = value;
            }
        }

        public string Color
        {
            get
            {
                return this.string_21;
            }
            set
            {
                this.string_21 = value;
                this.rcolor_0 = RColor.Empty;
            }
        }

        public string CornerNeRadius
        {
            get
            {
                return this.string_23;
            }
            set
            {
                this.string_23 = value;
            }
        }

        public string CornerNwRadius
        {
            get
            {
                return this.string_22;
            }
            set
            {
                this.string_22 = value;
            }
        }

        public string CornerRadius
        {
            get
            {
                return this.string_26;
            }
            set
            {
                MatchCollection matchs = Class47.smethod_1(@"([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", value);
                switch (matchs.Count)
                {
                    case 1:
                        this.CornerNeRadius = matchs[0].Value;
                        this.CornerNwRadius = matchs[0].Value;
                        this.CornerSeRadius = matchs[0].Value;
                        this.CornerSwRadius = matchs[0].Value;
                        break;

                    case 2:
                        this.CornerNeRadius = matchs[0].Value;
                        this.CornerNwRadius = matchs[0].Value;
                        this.CornerSeRadius = matchs[1].Value;
                        this.CornerSwRadius = matchs[1].Value;
                        break;

                    case 3:
                        this.CornerNeRadius = matchs[0].Value;
                        this.CornerNwRadius = matchs[1].Value;
                        this.CornerSeRadius = matchs[2].Value;
                        break;

                    case 4:
                        this.CornerNeRadius = matchs[0].Value;
                        this.CornerNwRadius = matchs[1].Value;
                        this.CornerSeRadius = matchs[2].Value;
                        this.CornerSwRadius = matchs[3].Value;
                        break;
                }
                this.string_26 = value;
            }
        }

        public string CornerSeRadius
        {
            get
            {
                return this.string_24;
            }
            set
            {
                this.string_24 = value;
            }
        }

        public string CornerSwRadius
        {
            get
            {
                return this.string_25;
            }
            set
            {
                this.string_25 = value;
            }
        }

        public string Direction
        {
            get
            {
                return this.string_28;
            }
            set
            {
                this.string_28 = value;
            }
        }

        public string Display
        {
            get
            {
                return this.string_29;
            }
            set
            {
                this.string_29 = value;
            }
        }

        public string EmptyCells
        {
            get
            {
                return this.string_27;
            }
            set
            {
                this.string_27 = value;
            }
        }

        public string Float
        {
            get
            {
                return this.string_34;
            }
            set
            {
                this.string_34 = value;
            }
        }

        public string FontFamily
        {
            get
            {
                return this.gnNjtxdkeT;
            }
            set
            {
                this.gnNjtxdkeT = value;
            }
        }

        public string FontSize
        {
            get
            {
                return this.string_30;
            }
            set
            {
                string str = Class47.smethod_2(@"([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", value);
                if (str != null)
                {
                    string str2;
                    Class30 class2 = new Class30(str);
                    if (class2.method_1())
                    {
                        str2 = "medium";
                    }
                    else if ((class2.method_4() == ((Enum4) 1)) && (this.GetParent() != null))
                    {
                        str2 = class2.method_6(this.GetParent().ActualFont.Size).ToString();
                    }
                    else
                    {
                        str2 = class2.ToString();
                    }
                    this.string_30 = str2;
                }
                else
                {
                    this.string_30 = value;
                }
            }
        }

        public string FontStyle
        {
            get
            {
                return this.string_31;
            }
            set
            {
                this.string_31 = value;
            }
        }

        public string FontVariant
        {
            get
            {
                return this.string_32;
            }
            set
            {
                this.string_32 = value;
            }
        }

        public string FontWeight
        {
            get
            {
                return this.string_33;
            }
            set
            {
                this.string_33 = value;
            }
        }

        public string Height
        {
            get
            {
                return this.string_35;
            }
            set
            {
                this.string_35 = value;
            }
        }

        public bool IsRounded
        {
            get
            {
                return ((((this.ActualCornerNe > 0.0) || (this.ActualCornerNw > 0.0)) || (this.ActualCornerSe > 0.0)) || (this.ActualCornerSw > 0.0));
            }
        }

        public string Left
        {
            get
            {
                return this.string_40;
            }
            set
            {
                this.string_40 = value;
            }
        }

        public string LineHeight
        {
            get
            {
                return this.string_41;
            }
            set
            {
                this.string_41 = string.Format(NumberFormatInfo.InvariantInfo, "{0}px", new object[] { Class43.smethod_5(value, this.Size.Height, this, "em") });
            }
        }

        public string ListStyle
        {
            get
            {
                return this.string_45;
            }
            set
            {
                this.string_45 = value;
            }
        }

        public string ListStyleImage
        {
            get
            {
                return this.string_43;
            }
            set
            {
                this.string_43 = value;
            }
        }

        public string ListStylePosition
        {
            get
            {
                return this.string_44;
            }
            set
            {
                this.string_44 = value;
            }
        }

        public string ListStyleType
        {
            get
            {
                return this.string_42;
            }
            set
            {
                this.string_42 = value;
            }
        }

        public RPoint Location
        {
            get
            {
                return this.rpoint_0;
            }
            set
            {
                this.rpoint_0 = value;
            }
        }

        public string MarginBottom
        {
            get
            {
                return this.string_36;
            }
            set
            {
                this.string_36 = value;
            }
        }

        public string MarginLeft
        {
            get
            {
                return this.string_37;
            }
            set
            {
                this.string_37 = value;
            }
        }

        public string MarginRight
        {
            get
            {
                return this.string_38;
            }
            set
            {
                this.string_38 = value;
            }
        }

        public string MarginTop
        {
            get
            {
                return this.string_39;
            }
            set
            {
                this.string_39 = value;
            }
        }

        public string MaxWidth
        {
            get
            {
                return this.string_59;
            }
            set
            {
                this.string_59 = value;
            }
        }

        public string Overflow
        {
            get
            {
                return this.string_46;
            }
            set
            {
                this.string_46 = value;
            }
        }

        public string PaddingBottom
        {
            get
            {
                return this.string_48;
            }
            set
            {
                this.string_48 = value;
                this.double_5 = double.NaN;
            }
        }

        public string PaddingLeft
        {
            get
            {
                return this.string_47;
            }
            set
            {
                this.string_47 = value;
                this.double_7 = double.NaN;
            }
        }

        public string PaddingRight
        {
            get
            {
                return this.string_49;
            }
            set
            {
                this.string_49 = value;
                this.double_6 = double.NaN;
            }
        }

        public string PaddingTop
        {
            get
            {
                return this.string_50;
            }
            set
            {
                this.string_50 = value;
                this.adxjhywlwJ = double.NaN;
            }
        }

        public string Position
        {
            get
            {
                return this.string_56;
            }
            set
            {
                this.string_56 = value;
            }
        }

        public RSize Size
        {
            get
            {
                return this.rsize_0;
            }
            set
            {
                this.rsize_0 = value;
            }
        }

        public string TextAlign
        {
            get
            {
                return this.string_52;
            }
            set
            {
                this.string_52 = value;
            }
        }

        public string TextDecoration
        {
            get
            {
                return this.string_53;
            }
            set
            {
                this.string_53 = value;
            }
        }

        public string TextIndent
        {
            get
            {
                return this.string_54;
            }
            set
            {
                this.string_54 = this.NoEms(value);
            }
        }

        public string Top
        {
            get
            {
                return this.string_55;
            }
            set
            {
                this.string_55 = value;
            }
        }

        public string VerticalAlign
        {
            get
            {
                return this.string_57;
            }
            set
            {
                this.string_57 = value;
            }
        }

        public string Visibility
        {
            get
            {
                return this.string_63;
            }
            set
            {
                this.string_63 = value;
            }
        }

        public string WhiteSpace
        {
            get
            {
                return this.string_62;
            }
            set
            {
                this.string_62 = value;
            }
        }

        public string Width
        {
            get
            {
                return this.string_58;
            }
            set
            {
                this.string_58 = value;
            }
        }

        public string WordBreak
        {
            get
            {
                return this.string_61;
            }
            set
            {
                this.string_61 = value;
            }
        }

        public string WordSpacing
        {
            get
            {
                return this.string_60;
            }
            set
            {
                this.string_60 = this.NoEms(value);
            }
        }
    }
}

