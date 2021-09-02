using DSkin.Html.Adapters.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

internal static class Class48
{
    private static readonly string[,] string_0 = new string[,] { { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" }, { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" }, { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" }, { "", "M", "MM", "MMM", "M(V)", "(V)", "(V)M", "(V)MM", "(V)MMM", "M(X)" } };
    private static readonly string[,] string_1 = new string[,] { { "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט" }, { "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ" }, { "ק", "ר", "ש", "ת", "תק", "תר", "תש", "תת", "תתק" } };
    private static readonly string[,] string_2 = new string[,] { { "ა", "ბ", "გ", "დ", "ე", "ვ", "ზ", "ჱ", "თ" }, { "ი", "პ", "ლ", "მ", "ნ", "ჲ", "ო", "პ", "ჟ" }, { "რ", "ს", "ტ", "ჳ", "ფ", "ქ", "ღ", "ყ", "შ" } };
    private static readonly string[,] string_3 = new string[,] { { "Ա", "Բ", "Գ", "Դ", "Ե", "Զ", "Է", "Ը", "Թ" }, { "Ժ", "Ի", "Լ", "Խ", "Ծ", "Կ", "Հ", "Ձ", "Ղ" }, { "Ճ", "Մ", "Յ", "Ն", "Շ", "Ո", "Չ", "Պ", "Ջ" } };
    private static readonly string[] string_4 = new string[] { 
        "あ", "ぃ", "ぅ", "ぇ", "ぉ", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", 
        "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", 
        "む", "め", "も", "ゃ", "ゅ", "ょ", "ら", "り", "る", "れ", "ろ", "ゎ", "ゐ", "ゑ", "を", "ん"
     };
    private static readonly string[] string_5 = new string[] { 
        "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", 
        "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", 
        "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", "ヰ", "ヱ", "ヲ", "ン"
     };
    public static string string_6;

    public static bool smethod_0(char char_0)
    {
        return ((char_0 >= '一') && (char_0 <= 0xfa2d));
    }

    public static bool smethod_1(char char_0, bool bool_0 = false)
    {
        return (((char_0 < '0') || (char_0 > '9')) ? (bool_0 && (((char_0 < 'a') || (char_0 > 'f')) ? ((char_0 >= 'A') && (char_0 <= 'F')) : true)) : true);
    }

    public static int smethod_10(string string_7, int int_0, out int int_1)
    {
        // This item is obfuscated and can not be translated.
        while (int_0 >= string_7.Length)
        {
        Label_0004:
            if (0 == 0)
            {
                if (int_0 >= string_7.Length)
                {
                    int_1 = 0;
                    return -1;
                }
                for (int i = int_0 + 1; i >= string_7.Length; i++)
                {
                Label_003B:
                    if (0 == 0)
                    {
                        int_1 = i - int_0;
                        return int_0;
                    }
                }
                goto Label_003B;
            }
            int_0++;
        }
        goto Label_0004;
    }

    public static bool smethod_11(string string_7, int int_0, int int_1, string string_8)
    {
        if ((int_1 == string_8.Length) && ((int_0 + int_1) <= string_7.Length))
        {
            for (int i = 0; i < int_1; i++)
            {
                if (char.ToLowerInvariant(string_7[int_0 + i]) != char.ToLowerInvariant(string_8[i]))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private static string smethod_12(string string_7)
    {
        string str = string_7;
        foreach (char ch in Path.GetInvalidFileNameChars())
        {
            str = str.Replace(ch, '_');
        }
        return str;
    }

    public static string smethod_13(int int_0, string string_7 = "upper-alpha")
    {
        if (int_0 == 0)
        {
            return string.Empty;
        }
        if (string_7.Equals("lower-greek", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_15(int_0);
        }
        if (string_7.Equals("lower-roman", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_16(int_0, true);
        }
        if (string_7.Equals("upper-roman", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_16(int_0, false);
        }
        if (string_7.Equals("armenian", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_17(int_0, string_3);
        }
        if (string_7.Equals("georgian", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_17(int_0, string_2);
        }
        if (string_7.Equals("hebrew", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_17(int_0, string_1);
        }
        if (string_7.Equals("hiragana", StringComparison.InvariantCultureIgnoreCase) || string_7.Equals("hiragana-iroha", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_18(int_0, string_4);
        }
        if (string_7.Equals("katakana", StringComparison.InvariantCultureIgnoreCase) || string_7.Equals("katakana-iroha", StringComparison.InvariantCultureIgnoreCase))
        {
            return smethod_18(int_0, string_5);
        }
        bool flag = string_7.Equals("lower-alpha", StringComparison.InvariantCultureIgnoreCase) || string_7.Equals("lower-latin", StringComparison.InvariantCultureIgnoreCase);
        return smethod_14(int_0, flag);
    }

    private static string smethod_14(int int_0, bool bool_0)
    {
        string str = string.Empty;
        int num = bool_0 ? 0x61 : 0x41;
        while (int_0 > 0)
        {
            int num2 = (int_0 % 0x1a) - 1;
            if (num2 >= 0)
            {
                str = ((char) (num + num2)) + str;
                int_0 /= 0x1a;
            }
            else
            {
                str = ((char) (num + 0x19)) + str;
                int_0 = (int_0 - 1) / 0x1a;
            }
        }
        return str;
    }

    private static string smethod_15(int int_0)
    {
        string str = string.Empty;
        while (int_0 > 0)
        {
            int num = (int_0 % 0x18) - 1;
            if (num > 0x10)
            {
                num++;
            }
            if (num >= 0)
            {
                str = ((char) (0x3b1 + num)) + str;
                int_0 /= 0x18;
            }
            else
            {
                str = 'ω' + str;
                int_0 = (int_0 - 1) / 0x19;
            }
        }
        return str;
    }

    private static string smethod_16(int int_0, bool bool_0)
    {
        string str = string.Empty;
        int num = 0x3e8;
        for (int i = 3; num > 0; i--)
        {
            int num3 = int_0 / num;
            str = str + string.Format(string_0[i, num3], new object[0]);
            int_0 -= num3 * num;
            num /= 10;
        }
        return (bool_0 ? str.ToLower() : str);
    }

    private static string smethod_17(int int_0, object object_0)
    {
        // This item is obfuscated and can not be translated.
        int num = 0;
        string str = string.Empty;
        while (int_0 <= 0)
        {
        Label_000B:
            if (0 == 0)
            {
                return str;
            }
            int num2 = int_0 % 10;
            if (num2 > 0)
            {
                str = object_0[num, (int_0 % 10) - 1].ToString(CultureInfo.InvariantCulture) + str;
            }
            int_0 /= 10;
            num++;
        }
        goto Label_000B;
    }

    private static string smethod_18(int int_0, object object_0)
    {
        for (int i = 20; i > 0; i--)
        {
            if (int_0 > (((0x31 * i) - i) + 1))
            {
                int_0++;
            }
        }
        string str = string.Empty;
        while (int_0 > 0)
        {
            str = object_0[Math.Max(0, (int_0 % 0x31) - 1)].ToString(CultureInfo.InvariantCulture) + str;
            int_0 /= 0x31;
        }
        return str;
    }

    public static bool smethod_2(char char_0)
    {
        return (((char_0 < 'a') || (char_0 > 'z')) ? ((char_0 >= 'A') && (char_0 <= 'Z')) : true);
    }

    public static int smethod_3(char char_0, bool bool_0 = false)
    {
        if ((char_0 >= '0') && (char_0 <= '9'))
        {
            return (char_0 - '0');
        }
        if (bool_0)
        {
            if ((char_0 >= 'a') && (char_0 <= 'f'))
            {
                return ((char_0 - 'a') + 10);
            }
            if ((char_0 >= 'A') && (char_0 <= 'F'))
            {
                return ((char_0 - 'A') + 10);
            }
        }
        return 0;
    }

    public static RSize smethod_4(RSize rsize_0, RSize rsize_1)
    {
        return new RSize(Math.Max(rsize_0.Width, rsize_1.Width), Math.Max(rsize_0.Height, rsize_1.Height));
    }

    public static Uri smethod_5(string string_7)
    {
        try
        {
            if (Uri.IsWellFormedUriString(string_7, UriKind.RelativeOrAbsolute))
            {
                return new Uri(string_7);
            }
        }
        catch
        {
        }
        return null;
    }

    public static wp2E3PWtCXHIOM97P8Q smethod_6<IyhhRIWDxoHUdP3wyhS, wp2E3PWtCXHIOM97P8Q>(IDictionary<IyhhRIWDxoHUdP3wyhS, wp2E3PWtCXHIOM97P8Q> idictionary_0, wp2E3PWtCXHIOM97P8Q WF2huRWjeBtlXY3aUVf = null)
    {
        if (idictionary_0 != null)
        {
            using (IEnumerator<KeyValuePair<IyhhRIWDxoHUdP3wyhS, wp2E3PWtCXHIOM97P8Q>> enumerator = idictionary_0.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    KeyValuePair<IyhhRIWDxoHUdP3wyhS, wp2E3PWtCXHIOM97P8Q> current = enumerator.Current;
                    return current.Value;
                }
            }
        }
        return WF2huRWjeBtlXY3aUVf;
    }

    public static FileInfo smethod_7(string string_7)
    {
        try
        {
            return new FileInfo(string_7);
        }
        catch
        {
        }
        return null;
    }

    public static string smethod_8(WebClient webClient_0)
    {
        foreach (string str in webClient_0.ResponseHeaders)
        {
            if (str.Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
            {
                return webClient_0.ResponseHeaders[str];
            }
        }
        return null;
    }

    public static FileInfo smethod_9(Uri uri_0)
    {
        int num2;
        StringBuilder builder = new StringBuilder();
        string absoluteUri = uri_0.AbsoluteUri;
        int length = absoluteUri.LastIndexOf('/');
        if (length == -1)
        {
            return null;
        }
        string str4 = absoluteUri.Substring(0, length);
        builder.Append(str4.GetHashCode().ToString());
        builder.Append('_');
        string str2 = absoluteUri.Substring(length + 1);
        int index = str2.IndexOf('?');
        if (index == -1)
        {
            string str3 = ".png";
            num2 = str2.IndexOf('.');
            if (num2 > -1)
            {
                str3 = str2.Substring(num2);
                str2 = str2.Substring(0, num2);
            }
            builder.Append(str2);
            builder.Append(str3);
        }
        else
        {
            num2 = str2.IndexOf('.');
            if ((num2 == -1) || (num2 > index))
            {
                builder.Append(str2);
                builder.Append(".png");
            }
            else if (index > num2)
            {
                builder.Append(str2, 0, num2);
                builder.Append(str2, index, str2.Length - index);
                builder.Append(str2, num2, index - num2);
            }
        }
        string path = smethod_12(builder.ToString());
        if (path.Length > 0x19)
        {
            path = path.Substring(0, 0x18) + path.Substring(0x18).GetHashCode() + Path.GetExtension(path);
        }
        if (string_6 == null)
        {
            string_6 = Path.Combine(Path.GetTempPath(), "HtmlRenderer");
            if (!Directory.Exists(string_6))
            {
                Directory.CreateDirectory(string_6);
            }
        }
        return new FileInfo(Path.Combine(string_6, path));
    }
}

