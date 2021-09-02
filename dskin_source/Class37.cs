using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;

internal sealed class Class37
{
    private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    private readonly Dictionary<string, RFontFamily> dictionary_1 = new Dictionary<string, RFontFamily>(StringComparer.InvariantCultureIgnoreCase);
    private readonly Dictionary<string, Dictionary<double, Dictionary<RFontStyle, RFont>>> dictionary_2 = new Dictionary<string, Dictionary<double, Dictionary<RFontStyle, RFont>>>(StringComparer.InvariantCultureIgnoreCase);
    private readonly RAdapter radapter_0;

    public Class37(RAdapter radapter_1)
    {
        ArgChecker.AssertArgNotNull(radapter_1, "global");
        this.radapter_0 = radapter_1;
    }

    private RFont jjuNoAgoed(string string_0, double double_0, RFontStyle rfontStyle_0)
    {
        RFont font = null;
        if (this.dictionary_2.ContainsKey(string_0))
        {
            Dictionary<double, Dictionary<RFontStyle, RFont>> dictionary2 = this.dictionary_2[string_0];
            if (dictionary2.ContainsKey(double_0))
            {
                Dictionary<RFontStyle, RFont> dictionary = dictionary2[double_0];
                if (dictionary.ContainsKey(rfontStyle_0))
                {
                    font = dictionary[rfontStyle_0];
                }
                return font;
            }
            this.dictionary_2[string_0][double_0] = new Dictionary<RFontStyle, RFont>();
            return font;
        }
        this.dictionary_2[string_0] = new Dictionary<double, Dictionary<RFontStyle, RFont>>();
        this.dictionary_2[string_0][double_0] = new Dictionary<RFontStyle, RFont>();
        return font;
    }

    public bool method_0(string string_0)
    {
        bool flag;
        string str;
        if (!(flag = this.dictionary_1.ContainsKey(string_0)) && this.dictionary_0.TryGetValue(string_0, out str))
        {
            flag = this.dictionary_1.ContainsKey(str);
        }
        return flag;
    }

    public void method_1(RFontFamily rfontFamily_0)
    {
        ArgChecker.AssertArgNotNull(rfontFamily_0, "family");
        this.dictionary_1[rfontFamily_0.Name] = rfontFamily_0;
    }

    public void method_2(string string_0, string string_1)
    {
        ArgChecker.AssertArgNotNullOrEmpty(string_0, "fromFamily");
        ArgChecker.AssertArgNotNullOrEmpty(string_1, "toFamily");
        this.dictionary_0[string_0] = string_1;
    }

    public RFont method_3(string string_0, double double_0, RFontStyle rfontStyle_0)
    {
        RFont font = this.jjuNoAgoed(string_0, double_0, rfontStyle_0);
        if (font == null)
        {
            string str;
            if (!this.dictionary_1.ContainsKey(string_0) && this.dictionary_0.TryGetValue(string_0, out str))
            {
                font = this.jjuNoAgoed(str, double_0, rfontStyle_0);
                if (font == null)
                {
                    font = this.method_4(str, double_0, rfontStyle_0);
                    this.dictionary_2[str][double_0][rfontStyle_0] = font;
                }
            }
            if (font == null)
            {
                font = this.method_4(string_0, double_0, rfontStyle_0);
            }
            this.dictionary_2[string_0][double_0][rfontStyle_0] = font;
        }
        return font;
    }

    private RFont method_4(string string_0, double double_0, RFontStyle rfontStyle_0)
    {
        RFontFamily family;
        try
        {
            return (this.dictionary_1.TryGetValue(string_0, out family) ? this.radapter_0.method_1(family, double_0, rfontStyle_0) : this.radapter_0.method_0(string_0, double_0, rfontStyle_0));
        }
        catch
        {
            return (this.dictionary_1.TryGetValue(string_0, out family) ? this.radapter_0.method_1(family, double_0, RFontStyle.Regular) : this.radapter_0.method_0(string_0, double_0, RFontStyle.Regular));
        }
    }
}

