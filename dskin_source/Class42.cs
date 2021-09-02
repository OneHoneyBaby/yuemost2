using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

internal sealed class Class42
{
    private static readonly char[] char_0 = new char[] { '}', ';' };
    private static readonly char[] char_1 = new char[] { '\r', '\n', '\t', ' ', '-', '!', '<', '>' };
    private readonly Class43 class43_0;
    private readonly RAdapter radapter_0;

    public Class42(RAdapter radapter_1)
    {
        ArgChecker.AssertArgNotNull(radapter_1, "global");
        this.class43_0 = new Class43(radapter_1);
        this.radapter_0 = radapter_1;
    }

    private static string DbeEalRkUL(string string_0, int int_0, int int_1)
    {
        if (Class48.smethod_11(string_0, int_0, int_1, "none"))
        {
            return "none";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "solid"))
        {
            return "solid";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "hidden"))
        {
            return "hidden";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "dotted"))
        {
            return "dotted";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "dashed"))
        {
            return "dashed";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "double"))
        {
            return "double";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "groove"))
        {
            return "groove";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "ridge"))
        {
            return "ridge";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "inset"))
        {
            return "inset";
        }
        if (Class48.smethod_11(string_0, int_0, int_1, "outset"))
        {
            return "outset";
        }
        return null;
    }

    public CssData method_0(string string_0, bool bool_0)
    {
        CssData data = bool_0 ? this.radapter_0.DefaultCssData.Clone() : new CssData();
        if (!string.IsNullOrEmpty(string_0))
        {
            this.method_1(data, string_0);
        }
        return data;
    }

    public void method_1(CssData cssData_0, string string_0)
    {
        if (!string.IsNullOrEmpty(string_0))
        {
            string_0 = smethod_0(string_0);
            this.method_5(cssData_0, string_0);
            this.method_6(cssData_0, string_0);
        }
    }

    private void method_10(string string_0, string string_1, Dictionary<string, string> dictionary_0)
    {
        string_1 = string_1.Replace("!important", string.Empty).Trim();
        if (((string_0 == "width") || (string_0 == "height")) || (string_0 == "lineheight"))
        {
            smethod_2(string_0, string_1, dictionary_0);
        }
        else if (((((string_0 == "color") || (string_0 == "backgroundcolor")) || ((string_0 == "bordertopcolor") || (string_0 == "borderbottomcolor"))) || (string_0 == "borderleftcolor")) || (string_0 == "borderrightcolor"))
        {
            this.method_11(string_0, string_1, dictionary_0);
        }
        else if (string_0 == "font")
        {
            this.method_12(string_1, dictionary_0);
        }
        else if (string_0 == "border")
        {
            this.method_14(string_1, null, dictionary_0);
        }
        else if (string_0 == "border-left")
        {
            this.method_14(string_1, "-left", dictionary_0);
        }
        else if (string_0 == "border-top")
        {
            this.method_14(string_1, "-top", dictionary_0);
        }
        else if (string_0 == "border-right")
        {
            this.method_14(string_1, "-right", dictionary_0);
        }
        else if (string_0 == "border-bottom")
        {
            this.method_14(string_1, "-bottom", dictionary_0);
        }
        else if (string_0 == "margin")
        {
            smethod_4(string_1, dictionary_0);
        }
        else if (string_0 == "border-style")
        {
            smethod_5(string_1, dictionary_0);
        }
        else if (string_0 == "border-width")
        {
            smethod_6(string_1, dictionary_0);
        }
        else if (string_0 == "border-color")
        {
            smethod_7(string_1, dictionary_0);
        }
        else if (string_0 == "padding")
        {
            smethod_8(string_1, dictionary_0);
        }
        else if (string_0 == "background-image")
        {
            dictionary_0["background-image"] = smethod_3(string_1);
        }
        else if (string_0 == "font-family")
        {
            dictionary_0["font-family"] = this.method_13(string_1);
        }
        else
        {
            dictionary_0[string_0] = string_1;
        }
    }

    private void method_11(string string_0, string string_1, Dictionary<string, string> dictionary_0)
    {
        if (this.class43_0.method_0(string_1))
        {
            dictionary_0[string_0] = string_1;
        }
    }

    private void method_12(string string_0, Dictionary<string, string> dictionary_0)
    {
        int num;
        string str = Class47.smethod_3(@"(([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\.[0-9]+)\%|xx-small|x-small|small|medium|large|x-large|xx-large|larger|smaller)(\/(normal|{[0-9]+|[0-9]*\.[0-9]+}|([0-9]+|[0-9]*\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\.[0-9]+)\%))?(\s|$)", string_0, out num);
        if (!string.IsNullOrEmpty(str))
        {
            str = str.Trim();
            string str2 = string_0.Substring(0, num);
            string str3 = Class47.smethod_2("(normal|italic|oblique)", str2);
            string str4 = Class47.smethod_2("(normal|small-caps)", str2);
            string str5 = Class47.smethod_2("(normal|bold|bolder|lighter|100|200|300|400|500|600|700|800|900)", str2);
            string str7 = string_0.Substring(num + str.Length).Trim();
            string str8 = str;
            string str9 = string.Empty;
            if (str.Contains("/") && (str.Length > (str.IndexOf("/", StringComparison.Ordinal) + 1)))
            {
                int index = str.IndexOf("/", StringComparison.Ordinal);
                str8 = str.Substring(0, index);
                str9 = str.Substring(index + 1);
            }
            if (!string.IsNullOrEmpty(str7))
            {
                dictionary_0["font-family"] = this.method_13(str7);
            }
            if (!string.IsNullOrEmpty(str3))
            {
                dictionary_0["font-style"] = str3;
            }
            if (!string.IsNullOrEmpty(str4))
            {
                dictionary_0["font-variant"] = str4;
            }
            if (!string.IsNullOrEmpty(str5))
            {
                dictionary_0["font-weight"] = str5;
            }
            if (!string.IsNullOrEmpty(str8))
            {
                dictionary_0["font-size"] = str8;
            }
            if (!string.IsNullOrEmpty(str9))
            {
                dictionary_0["line-height"] = str9;
            }
        }
    }

    private string method_13(string string_0)
    {
        // This item is obfuscated and can not be translated.
        int length;
        for (int i = 0; i <= -1; i = length)
        {
            string str2;
        Label_0008:
            if (0 != 0)
            {
                goto Label_003B;
            }
            return "inherit";
        Label_0010:
            if (1 == 0)
            {
                goto Label_004B;
            }
            i++;
            goto Label_003B;
        Label_0018:
            if ((string_0[i] == ',') || (string_0[i] == '\''))
            {
            }
            goto Label_0010;
        Label_003B:
            if (char.IsWhiteSpace(string_0[i]))
            {
                goto Label_0010;
            }
            goto Label_0018;
        Label_004B:
            length = string_0.IndexOf(',', i);
            if (length < 0)
            {
                length = string_0.Length;
            }
            int num2 = length - 1;
            goto Label_008C;
        Label_006C:
            if (1 == 0)
            {
                goto Label_009C;
            }
            num2--;
            goto Label_008C;
        Label_0074:
            if (string_0[num2] == '\'')
            {
            }
            goto Label_006C;
        Label_008C:
            if (char.IsWhiteSpace(string_0[num2]))
            {
                goto Label_006C;
            }
            goto Label_0074;
        Label_009C:
            str2 = string_0.Substring(i, (num2 - i) + 1);
            if (this.radapter_0.IsFontExists(str2))
            {
                return str2;
            }
        }
        goto Label_0008;
    }

    private void method_14(string string_0, string string_1, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        this.method_15(string_0, out str, out str2, out str3);
        if (string_1 != null)
        {
            if (str != null)
            {
                dictionary_0["border" + string_1 + "-width"] = str;
            }
            if (str2 != null)
            {
                dictionary_0["border" + string_1 + "-style"] = str2;
            }
            if (str3 != null)
            {
                dictionary_0["border" + string_1 + "-color"] = str3;
            }
        }
        else
        {
            if (str != null)
            {
                smethod_6(str, dictionary_0);
            }
            if (str2 != null)
            {
                smethod_5(str2, dictionary_0);
            }
            if (str3 != null)
            {
                smethod_7(str3, dictionary_0);
            }
        }
    }

    public void method_15(string string_0, out string string_1, out string string_2, out string string_3)
    {
        string str;
        string_3 = (string) (str = null);
        string_1 = string_2 = str;
        if (!string.IsNullOrEmpty(string_0))
        {
            int num2;
            for (int i = 0; (i = Class48.smethod_10(string_0, i, out num2)) > -1; i = (i + num2) + 1)
            {
                if (string_1 == null)
                {
                    string_1 = smethod_11(string_0, i, num2);
                }
                if (string_2 == null)
                {
                    string_2 = DbeEalRkUL(string_0, i, num2);
                }
                if (string_3 == null)
                {
                    string_3 = this.method_16(string_0, i, num2);
                }
            }
        }
    }

    private string method_16(string string_0, int int_0, int int_1)
    {
        RColor color;
        return (this.class43_0.method_2(string_0, int_0, int_1, out color) ? string_0.Substring(int_0, int_1) : null);
    }

    public CssBlock method_2(string string_0, string string_1)
    {
        return this.method_8(string_0, string_1);
    }

    public string method_3(string string_0)
    {
        return this.method_13(string_0);
    }

    public RColor method_4(string string_0)
    {
        return this.class43_0.method_1(string_0);
    }

    private void method_5(CssData cssData_0, string string_0)
    {
        // This item is obfuscated and can not be translated.
        int startIndex = 0;
        int num2 = 0;
        while (startIndex >= string_0.Length)
        {
        Label_000A:
            if (0 == 0)
            {
                return;
            }
            num2 = startIndex;
            while ((num2 + 1) < string_0.Length)
            {
                num2++;
                if (string_0[num2] == '}')
                {
                    startIndex = num2 + 1;
                }
                if (string_0[num2] == '{')
                {
                    break;
                }
            }
            int num3 = num2 + 1;
            if (num2 > -1)
            {
                num2++;
                while (num2 < string_0.Length)
                {
                    if (string_0[num2] == '{')
                    {
                        startIndex = num3 + 1;
                    }
                    if (string_0[num2] == '}')
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 < string_0.Length)
                {
                    while (char.IsWhiteSpace(string_0[startIndex]))
                    {
                        startIndex++;
                    }
                    string str = string_0.Substring(startIndex, (num2 - startIndex) + 1);
                    this.method_7(cssData_0, str, "all");
                }
                startIndex = num2 + 1;
            }
        }
        goto Label_000A;
    }

    private void method_6(CssData cssData_0, string string_0)
    {
        string str2;
        int num = 0;
        while ((str2 = Class47.smethod_0(string_0, ref num)) != null)
        {
            if (str2.StartsWith("@media", StringComparison.InvariantCultureIgnoreCase))
            {
                MatchCollection matchs = Class47.smethod_1(@"@media[^\{\}]*\{", str2);
                if (matchs.Count == 1)
                {
                    string str = matchs[0].Value;
                    if (str.StartsWith("@media", StringComparison.InvariantCultureIgnoreCase) && str.EndsWith("{"))
                    {
                        foreach (string str3 in str.Substring(6, str.Length - 7).Split(new char[] { ' ' }))
                        {
                            if (!string.IsNullOrEmpty(str3.Trim()))
                            {
                                foreach (Match match in Class47.smethod_1(@"[^\{\}]*\{[^\{\}]*\}", str2))
                                {
                                    this.method_7(cssData_0, match.Value, str3.Trim());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void method_7(CssData cssData_0, string string_0, string string_1 = "all")
    {
        int index = string_0.IndexOf("{", StringComparison.Ordinal);
        int num3 = (index > -1) ? string_0.IndexOf("}", index) : -1;
        if ((index > -1) && (num3 > -1))
        {
            string str3 = string_0.Substring(index + 1, (num3 - index) - 1);
            foreach (string str in string_0.Substring(0, index).Split(new char[] { ',' }))
            {
                string str2 = str.Trim(char_1);
                if (!string.IsNullOrEmpty(str2))
                {
                    CssBlock cssBlock = this.method_8(str2, str3);
                    if (cssBlock != null)
                    {
                        cssData_0.AddCssBlock(string_1, cssBlock);
                    }
                }
            }
        }
    }

    private CssBlock method_8(string string_0, string string_1)
    {
        string_0 = string_0.ToLower();
        string str = null;
        int index = string_0.IndexOf(":", StringComparison.Ordinal);
        if (!((index <= -1) || string_0.StartsWith("::")))
        {
            str = (index < (string_0.Length - 1)) ? string_0.Substring(index + 1).Trim() : null;
            string_0 = string_0.Substring(0, index).Trim();
        }
        if (!(string.IsNullOrEmpty(string_0) || (((str != null) && (str != "link")) && !(str == "hover"))))
        {
            string str2;
            List<CssBlockSelectorItem> selectors = smethod_1(string_0, out str2);
            return new CssBlock(str2, this.method_9(string_1), selectors, str == "hover");
        }
        return null;
    }

    private Dictionary<string, string> method_9(string string_0)
    {
        int num2;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        for (int i = 0; i < string_0.Length; i = num2 + 1)
        {
            num2 = string_0.IndexOfAny(char_0, i);
            if (num2 < 0)
            {
                num2 = string_0.Length - 1;
            }
            int startIndex = string_0.IndexOf(':', i, num2 - i);
            if (startIndex > -1)
            {
                i += (string_0[i] == ' ') ? 1 : 0;
                int num4 = num2 - (((string_0[num2] == ' ') || (string_0[num2] == ';')) ? 1 : 0);
                string str = string_0.Substring(i, startIndex - i).Trim().ToLower();
                startIndex += (string_0[startIndex + 1] == ' ') ? 2 : 1;
                if (num4 >= startIndex)
                {
                    string str2 = string_0.Substring(startIndex, (num4 - startIndex) + 1).Trim();
                    if (!str2.StartsWith("url", StringComparison.InvariantCultureIgnoreCase))
                    {
                        str2 = str2.ToLower();
                    }
                    this.method_10(str, str2, dictionary);
                }
            }
        }
        return dictionary;
    }

    private static string smethod_0(string string_0)
    {
        // This item is obfuscated and can not be translated.
        StringBuilder builder = null;
        int startIndex = 0;
        int index = 0;
        while (index <= -1)
        {
        Label_000C:
            if (0 == 0)
            {
                return ((builder != null) ? builder.ToString() : string_0);
            }
            index = string_0.IndexOf("/*", index);
            if (index > -1)
            {
                if (builder == null)
                {
                    builder = new StringBuilder(string_0.Length);
                }
                builder.Append(string_0.Substring(startIndex, index - startIndex));
                int length = string_0.IndexOf("*/", (int) (index + 2));
                if (length < 0)
                {
                    length = string_0.Length;
                }
                startIndex = index = length + 2;
            }
            else
            {
                if (builder != null)
                {
                    builder.Append(string_0.Substring(startIndex));
                }
                continue;
            }
        }
        goto Label_000C;
    }

    private static List<CssBlockSelectorItem> smethod_1(string string_0, out string string_1)
    {
        // This item is obfuscated and can not be translated.
        int num2;
        List<CssBlockSelectorItem> list = null;
        string_1 = null;
        for (int i = string_0.Length - 1; i > -1; i = num2)
        {
            bool directParent = false;
            while (char.IsWhiteSpace(string_0[i]))
            {
            Label_0018:
                if (1 == 0)
                {
                    goto Label_004F;
                }
                directParent = directParent || (string_0[i] == '>');
                i--;
            }
            goto Label_0018;
        Label_004F:
            num2 = i;
            goto Label_007A;
        Label_0054:
            if (0 == 0)
            {
                goto Label_0080;
            }
            num2--;
            goto Label_007A;
        Label_005C:
            if (char.IsWhiteSpace(string_0[num2]))
            {
            }
            goto Label_0054;
        Label_007A:
            if (num2 <= -1)
            {
                goto Label_0054;
            }
            goto Label_005C;
        Label_0080:
            if (num2 <= -1)
            {
                goto Label_00EC;
            }
            if (list == null)
            {
                list = new List<CssBlockSelectorItem>();
            }
            string str = string_0.Substring(num2 + 1, i - num2);
            if (string_1 != null)
            {
                goto Label_00CC;
            }
            string_1 = str;
            continue;
        Label_00B7:
            if (1 == 0)
            {
                goto Label_00DC;
            }
            num2--;
        Label_00CC:
            if (!char.IsWhiteSpace(string_0[num2]))
            {
            }
            goto Label_00B7;
        Label_00DC:
            list.Add(new CssBlockSelectorItem(str, directParent));
            continue;
        Label_00EC:
            if (string_1 != null)
            {
                list.Add(new CssBlockSelectorItem(string_0.Substring(0, i + 1), directParent));
            }
        }
        string_1 = string_1 ?? string_0;
        return list;
    }

    private static string[] smethod_10(string string_0, char char_2 = ' ')
    {
        if (!string.IsNullOrEmpty(string_0))
        {
            string[] strArray = string_0.Split(new char[] { char_2 });
            List<string> list = new List<string>();
            foreach (string str in strArray)
            {
                string str2 = str.Trim();
                if (!string.IsNullOrEmpty(str2))
                {
                    list.Add(str2);
                }
            }
            return list.ToArray();
        }
        return new string[0];
    }

    private static string smethod_11(string string_0, int int_0, int int_1)
    {
        if (!(((int_1 <= 2) || !char.IsDigit(string_0[int_0])) ? ((int_1 <= 3) || (string_0[int_0] != '.')) : false))
        {
            string str2 = null;
            if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "px"))
            {
                str2 = "px";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "pt"))
            {
                str2 = "pt";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "em"))
            {
                str2 = "em";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "ex"))
            {
                str2 = "ex";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "in"))
            {
                str2 = "in";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "cm"))
            {
                str2 = "cm";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "mm"))
            {
                str2 = "mm";
            }
            else if (Class48.smethod_11(string_0, (int_0 + int_1) - 2, 2, "pc"))
            {
                str2 = "pc";
            }
            if ((str2 != null) && Class43.smethod_0(string_0, int_0, int_1 - 2))
            {
                return string_0.Substring(int_0, int_1);
            }
        }
        else
        {
            if (Class48.smethod_11(string_0, int_0, int_1, "thin"))
            {
                return "thin";
            }
            if (Class48.smethod_11(string_0, int_0, int_1, "medium"))
            {
                return "medium";
            }
            if (Class48.smethod_11(string_0, int_0, int_1, "thick"))
            {
                return "thick";
            }
        }
        return null;
    }

    private static void smethod_2(object object_0, string string_0, Dictionary<string, string> dictionary_0)
    {
        if (Class43.smethod_2(string_0) || string_0.Equals("auto", StringComparison.OrdinalIgnoreCase))
        {
            dictionary_0[(string) object_0] = string_0;
        }
    }

    private static string smethod_3(string string_0)
    {
        // This item is obfuscated and can not be translated.
        int index = string_0.IndexOf("url(", StringComparison.InvariantCultureIgnoreCase);
        if (index <= -1)
        {
            return string_0;
        }
        index += 4;
        int num2 = string_0.IndexOf(')', index);
        if (num2 <= -1)
        {
            return string_0;
        }
        num2--;
        while (index >= num2)
        {
        Label_003A:
            if (0 == 0)
            {
                goto Label_00A3;
            }
            index++;
            continue;
        Label_0042:
            if (!char.IsWhiteSpace(string_0[index]) && (string_0[index] != '\''))
            {
            }
            goto Label_003A;
        }
        goto Label_0042;
    Label_00A3:
        if ((index < num2) && (!char.IsWhiteSpace(string_0[num2]) && (string_0[num2] != '\'')))
        {
        }
        if (0 == 0)
        {
            if (index <= num2)
            {
                return string_0.Substring(index, (num2 - index) + 1);
            }
            return string_0;
        }
        num2--;
        goto Label_00A3;
    }

    private static void smethod_4(string string_0, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        string str4;
        smethod_9(string_0, out str, out str2, out str3, out str4);
        if (str != null)
        {
            dictionary_0["margin-left"] = str;
        }
        if (str2 != null)
        {
            dictionary_0["margin-top"] = str2;
        }
        if (str3 != null)
        {
            dictionary_0["margin-right"] = str3;
        }
        if (str4 != null)
        {
            dictionary_0["margin-bottom"] = str4;
        }
    }

    private static void smethod_5(string string_0, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        string str4;
        smethod_9(string_0, out str, out str2, out str3, out str4);
        if (str != null)
        {
            dictionary_0["border-left-style"] = str;
        }
        if (str2 != null)
        {
            dictionary_0["border-top-style"] = str2;
        }
        if (str3 != null)
        {
            dictionary_0["border-right-style"] = str3;
        }
        if (str4 != null)
        {
            dictionary_0["border-bottom-style"] = str4;
        }
    }

    private static void smethod_6(string string_0, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        string str4;
        smethod_9(string_0, out str, out str2, out str3, out str4);
        if (str != null)
        {
            dictionary_0["border-left-width"] = str;
        }
        if (str2 != null)
        {
            dictionary_0["border-top-width"] = str2;
        }
        if (str3 != null)
        {
            dictionary_0["border-right-width"] = str3;
        }
        if (str4 != null)
        {
            dictionary_0["border-bottom-width"] = str4;
        }
    }

    private static void smethod_7(string string_0, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        string str4;
        smethod_9(string_0, out str, out str2, out str3, out str4);
        if (str != null)
        {
            dictionary_0["border-left-color"] = str;
        }
        if (str2 != null)
        {
            dictionary_0["border-top-color"] = str2;
        }
        if (str3 != null)
        {
            dictionary_0["border-right-color"] = str3;
        }
        if (str4 != null)
        {
            dictionary_0["border-bottom-color"] = str4;
        }
    }

    private static void smethod_8(string string_0, Dictionary<string, string> dictionary_0)
    {
        string str;
        string str2;
        string str3;
        string str4;
        smethod_9(string_0, out str, out str2, out str3, out str4);
        if (str != null)
        {
            dictionary_0["padding-left"] = str;
        }
        if (str2 != null)
        {
            dictionary_0["padding-top"] = str2;
        }
        if (str3 != null)
        {
            dictionary_0["padding-right"] = str3;
        }
        if (str4 != null)
        {
            dictionary_0["padding-bottom"] = str4;
        }
    }

    private static void smethod_9(string string_0, out string string_1, out string string_2, out string string_3, out string string_4)
    {
        string_2 = null;
        string_1 = null;
        string_3 = null;
        string_4 = null;
        string[] strArray = smethod_10(string_0, ' ');
        switch (strArray.Length)
        {
            case 1:
                string str;
                string_4 = str = strArray[0];
                string_3 = str = str;
                string_2 = string_1 = str;
                break;

            case 2:
                string_2 = string_4 = strArray[0];
                string_1 = string_3 = strArray[1];
                break;

            case 3:
                string_2 = strArray[0];
                string_1 = string_3 = strArray[1];
                string_4 = strArray[2];
                break;

            case 4:
                string_2 = strArray[0];
                string_3 = strArray[1];
                string_4 = strArray[2];
                string_1 = strArray[3];
                break;
        }
    }
}

