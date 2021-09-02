using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

internal static class Class47
{
    private static readonly Dictionary<string, Regex> dictionary_0 = new Dictionary<string, Regex>();

    public static string smethod_0(string string_0, ref int int_0)
    {
        // This item is obfuscated and can not be translated.
        int_0 = string_0.IndexOf('@', int_0);
        if (int_0 > -1)
        {
            int num2 = 1;
            int index = string_0.IndexOf('{', int_0);
            if (index > -1)
            {
                while (num2 <= 0)
                {
                Label_0032:
                    if (0 == 0)
                    {
                        if (index < string_0.Length)
                        {
                            string str = string_0.Substring(int_0, (index - int_0) + 1);
                            int_0 = index;
                            return str;
                        }
                        goto Label_0099;
                    }
                    index++;
                    if (string_0[index] == '{')
                    {
                        num2++;
                    }
                    else
                    {
                        if (string_0[index] == '}')
                        {
                            num2--;
                        }
                        continue;
                    }
                }
                goto Label_0032;
            }
        }
    Label_0099:
        return null;
    }

    public static MatchCollection smethod_1(string string_0, string string_1)
    {
        return smethod_4(string_0).Matches(string_1);
    }

    public static string smethod_2(string string_0, string string_1)
    {
        int num;
        return smethod_3(string_0, string_1, out num);
    }

    public static string smethod_3(string string_0, string string_1, out int int_0)
    {
        MatchCollection matchs = smethod_1(string_0, string_1);
        if (matchs.Count > 0)
        {
            int_0 = matchs[0].Index;
            return matchs[0].Value;
        }
        int_0 = -1;
        return null;
    }

    private static Regex smethod_4(string string_0)
    {
        Regex regex;
        if (!dictionary_0.TryGetValue(string_0, out regex))
        {
            regex = new Regex(string_0, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            dictionary_0[string_0] = regex;
        }
        return regex;
    }
}

