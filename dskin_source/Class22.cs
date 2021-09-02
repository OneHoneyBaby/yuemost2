using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

internal static class Class22
{
    private static readonly char[] char_0 = new char[1];

    public static DataObject smethod_0(string string_0, object object_0)
    {
        string_0 = string_0 ?? string.Empty;
        string s = smethod_3(string_0);
        if ((Environment.Version.Major < 4) && (string_0.Length != Encoding.UTF8.GetByteCount(string_0)))
        {
            s = Encoding.Default.GetString(Encoding.UTF8.GetBytes(s));
        }
        DataObject obj2 = new DataObject();
        obj2.SetData(DataFormats.Html, s);
        obj2.SetData(DataFormats.Text, object_0);
        obj2.SetData(DataFormats.UnicodeText, object_0);
        return obj2;
    }

    public static void smethod_1(string string_0, object object_0)
    {
        Clipboard.SetDataObject(smethod_0(string_0, object_0), true);
    }

    public static void smethod_2(object object_0)
    {
        DataObject data = new DataObject();
        data.SetData(DataFormats.Text, object_0);
        data.SetData(DataFormats.UnicodeText, object_0);
        Clipboard.SetDataObject(data, true);
    }

    private static string smethod_3(string string_0)
    {
        int num7;
        int num8;
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4");
        builder.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
        int index = string_0.IndexOf("<!--StartFragment-->", StringComparison.OrdinalIgnoreCase);
        int num2 = string_0.LastIndexOf("<!--EndFragment-->", StringComparison.OrdinalIgnoreCase);
        int startIndex = string_0.IndexOf("<html", StringComparison.OrdinalIgnoreCase);
        int count = (startIndex > -1) ? (string_0.IndexOf('>', startIndex) + 1) : -1;
        int num6 = string_0.LastIndexOf("</html", StringComparison.OrdinalIgnoreCase);
        if ((index < 0) && (num2 < 0))
        {
            int num9 = string_0.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
            int num5 = (num9 > -1) ? (string_0.IndexOf('>', num9) + 1) : -1;
            if ((count < 0) && (num5 < 0))
            {
                builder.Append("<html><body>");
                builder.Append("<!--StartFragment-->");
                num7 = smethod_4(builder, 0, -1);
                builder.Append(string_0);
                num8 = smethod_4(builder, 0, -1);
                builder.Append("<!--EndFragment-->");
                builder.Append("</body></html>");
            }
            else
            {
                int num12 = string_0.LastIndexOf("</body", StringComparison.OrdinalIgnoreCase);
                if (count < 0)
                {
                    builder.Append("<html>");
                }
                else
                {
                    builder.Append(string_0, 0, count);
                }
                if (num5 > -1)
                {
                    builder.Append(string_0, (count > -1) ? count : 0, num5 - ((count > -1) ? count : 0));
                }
                builder.Append("<!--StartFragment-->");
                num7 = smethod_4(builder, 0, -1);
                int num14 = (num5 > -1) ? num5 : ((count > -1) ? count : 0);
                int num13 = (num12 > -1) ? num12 : ((num6 > -1) ? num6 : string_0.Length);
                builder.Append(string_0, num14, num13 - num14);
                num8 = smethod_4(builder, 0, -1);
                builder.Append("<!--EndFragment-->");
                if (num13 < string_0.Length)
                {
                    builder.Append(string_0, num13, string_0.Length - num13);
                }
                if (num6 < 0)
                {
                    builder.Append("</html>");
                }
            }
        }
        else
        {
            if (count < 0)
            {
                builder.Append("<html>");
            }
            int num11 = smethod_4(builder, 0, -1);
            builder.Append(string_0);
            num7 = (num11 + smethod_4(builder, num11, num11 + index)) + "<!--StartFragment-->".Length;
            num8 = num11 + smethod_4(builder, num11, num11 + num2);
            if (num6 < 0)
            {
                builder.Append("</html>");
            }
        }
        builder.Replace("<<<<<<<<1", "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
        builder.Replace("<<<<<<<<2", smethod_4(builder, 0, -1).ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
        builder.Replace("<<<<<<<<3", num7.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
        builder.Replace("<<<<<<<<4", num8.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
        return builder.ToString();
    }

    private static int smethod_4(StringBuilder stringBuilder_0, int int_0 = 0, int int_1 = -1)
    {
        int num = 0;
        int_1 = (int_1 > -1) ? int_1 : stringBuilder_0.Length;
        for (int i = int_0; i < int_1; i++)
        {
            char_0[0] = stringBuilder_0[i];
            num += Encoding.UTF8.GetByteCount(char_0);
        }
        return num;
    }
}

