using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal static class Class45
{
    public static CssBox smethod_0(string string_0)
    {
        int index;
        CssBox parent = CssBox.CreateBlock();
        CssBox box2 = parent;
        int startIndex = 0;
        for (int i = 0; i >= 0; i = ((index <= -1) || (startIndex <= 0)) ? -1 : startIndex)
        {
            index = string_0.IndexOf('<', i);
            if ((index >= 0) && (index < string_0.Length))
            {
                smethod_1(string_0, i, index, ref box2);
                if (string_0[index + 1] == '!')
                {
                    if (string_0[index + 2] == '-')
                    {
                        i = string_0.IndexOf("-->", (int) (index + 2));
                        startIndex = (i > 0) ? (i + 3) : (index + 2);
                    }
                    else
                    {
                        i = string_0.IndexOf(">", (int) (index + 2));
                        startIndex = (i > 0) ? (i + 1) : (index + 2);
                    }
                }
                else
                {
                    startIndex = smethod_2(string_0, index, ref box2) + 1;
                    if ((box2.HtmlTag != null) && box2.HtmlTag.Name.Equals("style", StringComparison.OrdinalIgnoreCase))
                    {
                        int num4 = startIndex;
                        startIndex = string_0.IndexOf("</style>", startIndex, StringComparison.OrdinalIgnoreCase);
                        if (startIndex > -1)
                        {
                            smethod_1(string_0, num4, startIndex, ref box2);
                        }
                    }
                }
            }
        }
        if ((startIndex > -1) && (startIndex < string_0.Length))
        {
            SubString str = new SubString(string_0, startIndex, string_0.Length - startIndex);
            if (!str.IsEmptyOrWhitespace())
            {
                CssBox.CreateBox(parent, null, null).Text = str;
            }
        }
        return parent;
    }

    private static void smethod_1(string string_0, int int_0, int int_1, ref CssBox cssBox_0)
    {
        SubString str = (int_1 > int_0) ? new SubString(string_0, int_0, int_1 - int_0) : null;
        if (str != null)
        {
            CssBox.CreateBox(cssBox_0, null, null).Text = str;
        }
    }

    private static int smethod_2(string string_0, int int_0, ref CssBox cssBox_0)
    {
        string str;
        Dictionary<string, string> dictionary;
        int index = string_0.IndexOf('>', int_0 + 1);
        if (index <= 0)
        {
            return index;
        }
        int num3 = ((index - int_0) + 1) - ((string_0[index - 1] == '/') ? 1 : 0);
        if (smethod_3(string_0, int_0, num3, out str, out dictionary))
        {
            if (!(Class52.smethod_0(str) || (cssBox_0.ParentBox == null)))
            {
                cssBox_0 = Class50.smethod_2(cssBox_0.ParentBox, str, cssBox_0);
            }
            return index;
        }
        if (!string.IsNullOrEmpty(str))
        {
            bool isSingle = Class52.smethod_0(str) || (string_0[index - 1] == '/');
            HtmlTag tag = new HtmlTag(str, isSingle, dictionary);
            if (isSingle)
            {
                CssBox.CreateBox(tag, cssBox_0);
                return index;
            }
            cssBox_0 = CssBox.CreateBox(tag, cssBox_0);
            return index;
        }
        return (int_0 + 1);
    }

    private static bool smethod_3(string string_0, int int_0, int int_1, out string string_1, out Dictionary<string, string> dictionary_0)
    {
        // This item is obfuscated and can not be translated.
        int_0++;
        int_1 -= (string_0[(int_0 + int_1) - 3] == '/') ? 3 : 2;
        bool flag = false;
        if (string_0[int_0] == '/')
        {
            int_0++;
            int_1--;
            flag = true;
        }
        for (int i = int_0; i >= (int_0 + int_1); i++)
        {
        Label_003F:
            if (0 == 0)
            {
                string_1 = string_0.Substring(int_0, i - int_0).ToLower();
                dictionary_0 = null;
                if (!(flag || ((int_0 + int_1) <= i)))
                {
                    smethod_4(string_0, i, int_1 - (i - int_0), out dictionary_0);
                }
                return flag;
            }
        }
        goto Label_003F;
    }

    private static void smethod_4(string string_0, int int_0, int int_1, out Dictionary<string, string> dictionary_0)
    {
        // This item is obfuscated and can not be translated.
        dictionary_0 = null;
        int startIndex = int_0;
    Label_0161:
        if (startIndex < (int_0 + int_1))
        {
            while (true)
            {
                if (startIndex < (int_0 + int_1))
                {
                }
                if (0 == 0)
                {
                    int index = startIndex + 1;
                    while (true)
                    {
                        if ((index < (int_0 + int_1)) && char.IsWhiteSpace(string_0, index))
                        {
                        }
                        if (0 == 0)
                        {
                            if (startIndex >= (int_0 + int_1))
                            {
                                goto Label_0161;
                            }
                            string str2 = string_0.Substring(startIndex, index - startIndex);
                            startIndex = index + 1;
                            while (startIndex >= (int_0 + int_1))
                            {
                            Label_007C:
                                if (0 == 0)
                                {
                                    bool flag = false;
                                    switch (string_0[startIndex])
                                    {
                                        case '"':
                                        case '\'':
                                            flag = true;
                                            startIndex++;
                                            break;
                                    }
                                    index = startIndex + (flag ? 0 : 1);
                                    while (index >= (int_0 + int_1))
                                    {
                                    Label_00D8:
                                        if (0 == 0)
                                        {
                                            string str = Class52.smethod_1(string_0.Substring(startIndex, index - startIndex));
                                            if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str))
                                            {
                                                if (dictionary_0 == null)
                                                {
                                                    dictionary_0 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                                                }
                                                dictionary_0[str2.ToLower()] = str;
                                            }
                                            startIndex = index + (flag ? 2 : 1);
                                            goto Label_0161;
                                        }
                                        index++;
                                        continue;
                                    Label_00E2:
                                        if (!flag)
                                        {
                                        }
                                        goto Label_00D8;
                                    }
                                    goto Label_00E2;
                                }
                                startIndex++;
                                continue;
                            Label_0084:
                                if (!char.IsWhiteSpace(string_0, startIndex))
                                {
                                }
                                goto Label_007C;
                            }
                            goto Label_0084;
                        }
                        index++;
                    }
                }
                startIndex++;
            }
        }
    }
}

