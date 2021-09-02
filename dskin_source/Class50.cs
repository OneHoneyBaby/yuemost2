using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

internal sealed class Class50
{
    public static bool smethod_0(CssBox cssBox_0, RPoint rpoint_0)
    {
        foreach (KeyValuePair<CssLineBox, RRect> pair in cssBox_0.Rectangles)
        {
            if (pair.Value.Contains(rpoint_0))
            {
                return true;
            }
        }
        foreach (CssBox box in cssBox_0.Boxes)
        {
            if (smethod_0(box, rpoint_0))
            {
                return true;
            }
        }
        return false;
    }

    public static bool smethod_1(CssBox cssBox_0)
    {
        foreach (CssBox box in cssBox_0.Boxes)
        {
            if (!box.IsInline)
            {
                return false;
            }
        }
        return true;
    }

    public static CssBox smethod_10(object object_0, RPoint rpoint_0)
    {
        if (object_0 != null)
        {
            if ((object_0.IsClickable && (object_0.Visibility == "visible")) && smethod_0((CssBox) object_0, rpoint_0))
            {
                return (CssBox) object_0;
            }
            if (object_0.ClientRectangle.IsEmpty || object_0.ClientRectangle.Contains(rpoint_0))
            {
                foreach (CssBox box2 in object_0.Boxes)
                {
                    CssBox box3 = smethod_10(box2, rpoint_0);
                    if (box3 != null)
                    {
                        return box3;
                    }
                }
            }
        }
        return null;
    }

    public static CssBox smethod_11(CssBox cssBox_0, string string_0)
    {
        if ((cssBox_0 != null) && !string.IsNullOrEmpty(string_0))
        {
            if ((cssBox_0.HtmlTag != null) && string_0.Equals(cssBox_0.HtmlTag.TryGetAttribute("id", null), StringComparison.OrdinalIgnoreCase))
            {
                return cssBox_0;
            }
            foreach (CssBox box in cssBox_0.Boxes)
            {
                CssBox box2 = smethod_11(box, string_0);
                if (box2 != null)
                {
                    return box2;
                }
            }
        }
        return null;
    }

    public static CssLineBox smethod_12(object object_0, RPoint rpoint_0)
    {
        CssLineBox box = null;
        if (object_0 != null)
        {
            if ((object_0.LineBoxes.Count > 0) && (((object_0.HtmlTag == null) || (object_0.HtmlTag.Name != "td")) || object_0.Bounds.Contains(rpoint_0)))
            {
                foreach (CssLineBox box4 in object_0.LineBoxes)
                {
                    foreach (KeyValuePair<CssBox, RRect> pair in box4.Rectangles)
                    {
                        if (pair.Value.Top <= rpoint_0.Y)
                        {
                            box = box4;
                        }
                        if (pair.Value.Top > rpoint_0.Y)
                        {
                            return box;
                        }
                    }
                }
            }
            foreach (CssBox box2 in object_0.Boxes)
            {
                box = smethod_12(box2, rpoint_0) ?? box;
            }
        }
        return box;
    }

    public static CssRect smethod_13(object object_0, RPoint rpoint_0)
    {
        if ((object_0 != null) && (object_0.Visibility == "visible"))
        {
            if (object_0.LineBoxes.Count > 0)
            {
                foreach (CssLineBox box in object_0.LineBoxes)
                {
                    CssRect rect2 = smethod_14(box, rpoint_0);
                    if (rect2 != null)
                    {
                        return rect2;
                    }
                }
            }
            if (object_0.ClientRectangle.IsEmpty || object_0.ClientRectangle.Contains(rpoint_0))
            {
                foreach (CssBox box2 in object_0.Boxes)
                {
                    CssRect rect4 = smethod_13(box2, rpoint_0);
                    if (rect4 != null)
                    {
                        return rect4;
                    }
                }
            }
        }
        return null;
    }

    public static CssRect smethod_14(CssLineBox cssLineBox_0, RPoint rpoint_0)
    {
        foreach (KeyValuePair<CssBox, RRect> pair in cssLineBox_0.Rectangles)
        {
            foreach (CssRect rect in pair.Key.Words)
            {
                RRect rectangle = rect.Rectangle;
                rectangle.Width += rect.OwnerBox.ActualWordSpacing;
                if (rectangle.Contains(rpoint_0))
                {
                    return rect;
                }
            }
        }
        return null;
    }

    public static CssLineBox smethod_15(CssRect cssRect_0)
    {
        CssBox ownerBox = cssRect_0.OwnerBox;
        while (ownerBox.LineBoxes.Count == 0)
        {
            ownerBox = ownerBox.ParentBox;
        }
        foreach (CssLineBox box2 in ownerBox.LineBoxes)
        {
            foreach (CssRect rect in box2.Words)
            {
                if (rect == cssRect_0)
                {
                    return box2;
                }
            }
        }
        return ownerBox.LineBoxes[0];
    }

    public static string smethod_16(object object_0)
    {
        StringBuilder builder = new StringBuilder();
        int length = smethod_19(builder, object_0);
        return builder.ToString(0, length).Trim();
    }

    public static string smethod_17(CssBox cssBox_0, HtmlGenerationStyle htmlGenerationStyle_0 = 1, bool bool_0 = false)
    {
        StringBuilder builder = new StringBuilder();
        if (cssBox_0 != null)
        {
            Dictionary<CssBox, bool> dictionary = bool_0 ? smethod_20(cssBox_0) : null;
            CssBox box = bool_0 ? smethod_22(cssBox_0, dictionary) : null;
            smethod_24(cssBox_0.HtmlContainer.method_1(), builder, cssBox_0, htmlGenerationStyle_0, dictionary, box);
        }
        return builder.ToString();
    }

    public static string smethod_18(object object_0)
    {
        StringBuilder builder = new StringBuilder();
        smethod_29(object_0, builder, 0);
        return builder.ToString();
    }

    private static int smethod_19(StringBuilder stringBuilder_0, object object_0)
    {
        // This item is obfuscated and can not be translated.
        int length = 0;
        foreach (CssRect rect in object_0.Words)
        {
            if (rect.Selected)
            {
                stringBuilder_0.Append(smethod_28(rect, true));
                length = stringBuilder_0.Length;
            }
        }
        if (((object_0.Boxes.Count < 1) && (object_0.Text != null)) && object_0.Text.IsWhitespace())
        {
            stringBuilder_0.Append(' ');
        }
        if ((object_0.Visibility != "hidden") && (object_0.Display != "none"))
        {
            foreach (CssBox box in object_0.Boxes)
            {
                int num5 = smethod_19(stringBuilder_0, box);
                length = Math.Max(length, num5);
            }
        }
        if (stringBuilder_0.Length <= 0)
        {
            return length;
        }
        if ((object_0.HtmlTag != null) && (object_0.HtmlTag.Name == "hr"))
        {
            if ((stringBuilder_0.Length > 1) && (stringBuilder_0[stringBuilder_0.Length - 1] != '\n'))
            {
                stringBuilder_0.AppendLine();
            }
            stringBuilder_0.AppendLine(new string('-', 80));
        }
        if ((((object_0.Display == "block") || (object_0.Display == "list-item")) || (object_0.Display == "table-row")) && ((!object_0.IsBrElement || (stringBuilder_0.Length <= 1)) || (stringBuilder_0[stringBuilder_0.Length - 1] != '\n')))
        {
            stringBuilder_0.AppendLine();
        }
        if (object_0.Display == "table-cell")
        {
            stringBuilder_0.Append(' ');
        }
        if ((object_0.HtmlTag == null) || !(object_0.HtmlTag.Name == "p"))
        {
            return length;
        }
        int num3 = 0;
        for (int i = stringBuilder_0.Length - 1; i < 0; i--)
        {
        Label_021D:
            if (0 == 0)
            {
                if (num3 < 2)
                {
                    stringBuilder_0.AppendLine();
                }
                return length;
            }
            num3 += (stringBuilder_0[i] == '\n') ? 1 : 0;
        }
        goto Label_021D;
    }

    public static CssBox smethod_2(CssBox cssBox_0, string string_0, CssBox cssBox_1)
    {
        if (cssBox_1 == null)
        {
            return cssBox_0;
        }
        if ((cssBox_1.HtmlTag != null) && cssBox_1.HtmlTag.Name.Equals(string_0, StringComparison.CurrentCultureIgnoreCase))
        {
            return (cssBox_1.ParentBox ?? cssBox_0);
        }
        return smethod_2(cssBox_0, string_0, cssBox_1.ParentBox);
    }

    private static Dictionary<CssBox, bool> smethod_20(CssBox cssBox_0)
    {
        Dictionary<CssBox, bool> dictionary = new Dictionary<CssBox, bool>();
        Dictionary<CssBox, bool> dictionary2 = new Dictionary<CssBox, bool>();
        smethod_21(cssBox_0, dictionary, dictionary2);
        return dictionary;
    }

    private static bool smethod_21(CssBox cssBox_0, Dictionary<CssBox, bool> dictionary_0, Dictionary<CssBox, bool> dictionary_1)
    {
        bool flag = false;
        foreach (CssRect rect in cssBox_0.Words)
        {
            if (rect.Selected)
            {
                dictionary_0[cssBox_0] = true;
                foreach (KeyValuePair<CssBox, bool> pair in dictionary_1)
                {
                    dictionary_0[pair.Key] = pair.Value;
                }
                dictionary_1.Clear();
                flag = true;
            }
        }
        foreach (CssBox box in cssBox_0.Boxes)
        {
            if (smethod_21(box, dictionary_0, dictionary_1))
            {
                dictionary_0[cssBox_0] = true;
                flag = true;
            }
        }
        if ((cssBox_0.HtmlTag != null) && (dictionary_0.Count > 0))
        {
            dictionary_1[cssBox_0] = true;
        }
        return flag;
    }

    private static CssBox smethod_22(CssBox cssBox_0, Dictionary<CssBox, bool> dictionary_0)
    {
        // This item is obfuscated and can not be translated.
        CssBox box4;
        bool flag;
        CssBox box = cssBox_0;
        CssBox box2 = cssBox_0;
        goto Label_0066;
    Label_0045:
        if (flag || (box4 == null))
        {
            if (smethod_23(box))
            {
                return box;
            }
            for (box2 = box.ParentBox; box2.ParentBox == null; box2 = box2.ParentBox)
            {
            Label_008C:
                if (0 == 0)
                {
                    if (box2.HtmlTag != null)
                    {
                        box = box2;
                    }
                    return box;
                }
            }
            goto Label_008C;
        }
        box2 = box4;
        if (box2.HtmlTag != null)
        {
            box = box2;
        }
    Label_0066:
        flag = false;
        box4 = null;
        using (List<CssBox>.Enumerator enumerator = box2.Boxes.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                CssBox current = enumerator.Current;
                if (dictionary_0.ContainsKey(current))
                {
                    if (box4 != null)
                    {
                        goto Label_0032;
                    }
                    box4 = current;
                }
            }
            goto Label_0045;
        Label_0032:
            flag = true;
        }
        goto Label_0045;
    }

    private static bool smethod_23(CssBox cssBox_0)
    {
        foreach (CssBox box in cssBox_0.Boxes)
        {
            if ((box.HtmlTag != null) || smethod_23(box))
            {
                return true;
            }
        }
        return false;
    }

    private static void smethod_24(Class42 class42_0, StringBuilder stringBuilder_0, CssBox cssBox_0, HtmlGenerationStyle htmlGenerationStyle_0, Dictionary<CssBox, bool> dictionary_0, object object_0)
    {
        if (((cssBox_0.HtmlTag == null) || (dictionary_0 == null)) || dictionary_0.ContainsKey(cssBox_0))
        {
            if (cssBox_0.HtmlTag != null)
            {
                if (((cssBox_0.HtmlTag.Name != "link") || !cssBox_0.HtmlTag.Attributes.ContainsKey("href")) || (!cssBox_0.HtmlTag.Attributes["href"].StartsWith("property") && !cssBox_0.HtmlTag.Attributes["href"].StartsWith("method")))
                {
                    smethod_25(class42_0, stringBuilder_0, cssBox_0, htmlGenerationStyle_0);
                    if (cssBox_0 == object_0)
                    {
                        stringBuilder_0.Append("<!--StartFragment-->");
                    }
                }
                if (((htmlGenerationStyle_0 == HtmlGenerationStyle.InHeader) && (cssBox_0.HtmlTag.Name == "html")) && (cssBox_0.HtmlContainer.CssData != null))
                {
                    stringBuilder_0.AppendLine("<head>");
                    smethod_27(stringBuilder_0, cssBox_0.HtmlContainer.CssData);
                    stringBuilder_0.AppendLine("</head>");
                }
            }
            if (cssBox_0.Words.Count > 0)
            {
                foreach (CssRect rect in cssBox_0.Words)
                {
                    if ((dictionary_0 == null) || rect.Selected)
                    {
                        string str = smethod_28(rect, dictionary_0 != null);
                        stringBuilder_0.Append(Class52.smethod_2(str));
                    }
                }
            }
            foreach (CssBox box in cssBox_0.Boxes)
            {
                smethod_24(class42_0, stringBuilder_0, box, htmlGenerationStyle_0, dictionary_0, object_0);
            }
            if ((cssBox_0.HtmlTag != null) && !cssBox_0.HtmlTag.IsSingle)
            {
                if (cssBox_0 == object_0)
                {
                    stringBuilder_0.Append("<!--EndFragment-->");
                }
                stringBuilder_0.AppendFormat("</{0}>", cssBox_0.HtmlTag.Name);
            }
        }
    }

    private static void smethod_25(Class42 class42_0, StringBuilder stringBuilder_0, CssBox cssBox_0, HtmlGenerationStyle htmlGenerationStyle_0)
    {
        stringBuilder_0.AppendFormat("<{0}", cssBox_0.HtmlTag.Name);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        IEnumerable<CssBlock> cssBlock = cssBox_0.HtmlContainer.CssData.GetCssBlock(cssBox_0.HtmlTag.Name, "all");
        if (cssBlock != null)
        {
            foreach (CssBlock block in cssBlock)
            {
                foreach (KeyValuePair<string, string> pair2 in block.Properties)
                {
                    dictionary[pair2.Key] = pair2.Value;
                }
            }
        }
        if (cssBox_0.HtmlTag.HasAttributes())
        {
            stringBuilder_0.Append(" ");
            foreach (KeyValuePair<string, string> pair3 in cssBox_0.HtmlTag.Attributes)
            {
                if ((htmlGenerationStyle_0 == HtmlGenerationStyle.Inline) && (pair3.Key == "style"))
                {
                    foreach (KeyValuePair<string, string> pair2 in class42_0.method_2(cssBox_0.HtmlTag.Name, cssBox_0.HtmlTag.TryGetAttribute("style", null)).Properties)
                    {
                        dictionary[pair2.Key] = pair2.Value;
                    }
                }
                else if ((htmlGenerationStyle_0 == HtmlGenerationStyle.Inline) && (pair3.Key == "class"))
                {
                    IEnumerable<CssBlock> enumerable2 = cssBox_0.HtmlContainer.CssData.GetCssBlock("." + pair3.Value, "all");
                    if (enumerable2 != null)
                    {
                        foreach (CssBlock block in enumerable2)
                        {
                            foreach (KeyValuePair<string, string> pair2 in block.Properties)
                            {
                                dictionary[pair2.Key] = pair2.Value;
                            }
                        }
                    }
                }
                else
                {
                    stringBuilder_0.AppendFormat("{0}=\"{1}\" ", pair3.Key, pair3.Value);
                }
            }
            stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
        }
        if ((htmlGenerationStyle_0 == HtmlGenerationStyle.Inline) && (dictionary.Count > 0))
        {
            Dictionary<string, string> dictionary2 = smethod_26(cssBox_0, dictionary);
            if (dictionary2.Count > 0)
            {
                stringBuilder_0.Append(" style=\"");
                foreach (KeyValuePair<string, string> pair in dictionary2)
                {
                    stringBuilder_0.AppendFormat("{0}: {1}; ", pair.Key, pair.Value);
                }
                stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
                stringBuilder_0.Append("\"");
            }
        }
        stringBuilder_0.AppendFormat("{0}>", cssBox_0.HtmlTag.IsSingle ? "/" : "");
    }

    private static Dictionary<string, string> smethod_26(CssBox cssBox_0, Dictionary<string, string> dictionary_0)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        IEnumerable<CssBlock> cssBlock = cssBox_0.HtmlContainer.method_0().DefaultCssData.GetCssBlock(cssBox_0.HtmlTag.Name, "all");
        foreach (KeyValuePair<string, string> pair in dictionary_0)
        {
            bool flag = false;
            using (IEnumerator<CssBlock> enumerator2 = cssBlock.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    string str;
                    CssBlock current = enumerator2.Current;
                    if (current.Properties.TryGetValue(pair.Key, out str) && str.Equals(pair.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        goto Label_0091;
                    }
                }
                goto Label_00A5;
            Label_0091:
                flag = true;
            }
        Label_00A5:
            if (!flag)
            {
                dictionary[pair.Key] = pair.Value;
            }
        }
        return dictionary;
    }

    private static void smethod_27(StringBuilder stringBuilder_0, CssData cssData_0)
    {
        stringBuilder_0.AppendLine("<style type=\"text/css\">");
        foreach (KeyValuePair<string, List<CssBlock>> pair in cssData_0.method_0()["all"])
        {
            stringBuilder_0.Append(pair.Key);
            stringBuilder_0.Append(" { ");
            foreach (CssBlock block in pair.Value)
            {
                foreach (KeyValuePair<string, string> pair2 in block.Properties)
                {
                    stringBuilder_0.AppendFormat("{0}: {1};", pair2.Key, pair2.Value);
                }
            }
            stringBuilder_0.Append(" }");
            stringBuilder_0.AppendLine();
        }
        stringBuilder_0.AppendLine("</style>");
    }

    private static string smethod_28(CssRect cssRect_0, bool bool_0)
    {
        if ((bool_0 && (cssRect_0.SelectedStartIndex > -1)) && (cssRect_0.SelectedEndIndexOffset > -1))
        {
            return cssRect_0.Text.Substring(cssRect_0.SelectedStartIndex, cssRect_0.SelectedEndIndexOffset - cssRect_0.SelectedStartIndex);
        }
        if (bool_0 && (cssRect_0.SelectedStartIndex > -1))
        {
            return (cssRect_0.Text.Substring(cssRect_0.SelectedStartIndex) + (cssRect_0.HasSpaceAfter ? " " : ""));
        }
        if (bool_0 && (cssRect_0.SelectedEndIndexOffset > -1))
        {
            return cssRect_0.Text.Substring(0, cssRect_0.SelectedEndIndexOffset);
        }
        return ((((cssRect_0.OwnerBox.Words[0] == cssRect_0) ? ((string) smethod_5(cssRect_0.OwnerBox)) : ((string) cssRect_0.HasSpaceBefore)) ? " " : "") + cssRect_0.Text + (cssRect_0.HasSpaceAfter ? " " : ""));
    }

    private static void smethod_29(object object_0, StringBuilder stringBuilder_0, int int_0)
    {
        stringBuilder_0.AppendFormat("{0}<{1}", new string(' ', 2 * int_0), object_0.Display);
        if (object_0.HtmlTag != null)
        {
            stringBuilder_0.AppendFormat(" element=\"{0}\"", (object_0.HtmlTag != null) ? object_0.HtmlTag.Name : string.Empty);
        }
        if (object_0.Words.Count > 0)
        {
            stringBuilder_0.AppendFormat(" words=\"{0}\"", object_0.Words.Count);
        }
        stringBuilder_0.AppendFormat("{0}>\r\n", (object_0.Boxes.Count > 0) ? "" : "/");
        if (object_0.Boxes.Count > 0)
        {
            foreach (CssBox box in object_0.Boxes)
            {
                smethod_29(box, stringBuilder_0, int_0 + 1);
            }
            stringBuilder_0.AppendFormat("{0}</{1}>\r\n", new string(' ', 2 * int_0), object_0.Display);
        }
    }

    public static CssBox smethod_3(CssBox cssBox_0)
    {
        // This item is obfuscated and can not be translated.
        if (cssBox_0.ParentBox != null)
        {
            int index = cssBox_0.ParentBox.Boxes.IndexOf(cssBox_0);
            if (index > 0)
            {
                int num2 = 1;
                CssBox box = cssBox_0.ParentBox.Boxes[index - 1];
                while (true)
                {
                    if ((box.Display != "none") && (box.Position == "absolute"))
                    {
                    }
                    if (((index - num2) - 1) < 0)
                    {
                        return ((box.Display == "none") ? null : box);
                    }
                    box = cssBox_0.ParentBox.Boxes[index - ++num2];
                }
            }
        }
        return null;
    }

    public static CssBox smethod_4(CssBox cssBox_0)
    {
        // This item is obfuscated and can not be translated.
        CssBox box2;
        int num2;
        CssBox item = cssBox_0;
        int index = item.ParentBox.Boxes.IndexOf(item);
        while (true)
        {
            if ((item.ParentBox != null) && (((index >= 1) || !(item.Display != "block")) || (!(item.Display != "table") || !(item.Display != "table-cell"))))
            {
            }
            if (0 == 0)
            {
                item = item.ParentBox;
                if ((item == null) || (index <= 0))
                {
                    return null;
                }
                num2 = 1;
                box2 = item.Boxes[index - 1];
                break;
            }
            item = item.ParentBox;
            index = (item.ParentBox != null) ? item.ParentBox.Boxes.IndexOf(item) : -1;
        }
        while (true)
        {
            if ((box2.Display != "none") && (box2.Position == "absolute"))
            {
            }
            if (((index - num2) - 1) < 0)
            {
                return ((box2.Display == "none") ? null : box2);
            }
            box2 = item.Boxes[index - ++num2];
        }
    }

    public static bool smethod_5(CssBox cssBox_0)
    {
        if ((!cssBox_0.Words[0].IsImage && cssBox_0.Words[0].HasSpaceBefore) && cssBox_0.IsInline)
        {
            CssBox box = smethod_4(cssBox_0);
            if ((box != null) && box.IsInline)
            {
                return true;
            }
        }
        return false;
    }

    public static CssBox smethod_6(CssBox cssBox_0)
    {
        if (cssBox_0.ParentBox != null)
        {
            for (int i = cssBox_0.ParentBox.Boxes.IndexOf(cssBox_0) + 1; i <= (cssBox_0.ParentBox.Boxes.Count - 1); i++)
            {
                CssBox box3 = cssBox_0.ParentBox.Boxes[i];
                if ((box3.Display != "none") && (box3.Position != "absolute"))
                {
                    return box3;
                }
            }
        }
        return null;
    }

    public static string smethod_7(CssBox cssBox_0, string string_0)
    {
        // This item is obfuscated and can not be translated.
        string attribute = null;
        while (cssBox_0 == null)
        {
        Label_0005:
            if (0 == 0)
            {
                return attribute;
            }
            attribute = cssBox_0.GetAttribute(string_0, null);
            cssBox_0 = cssBox_0.ParentBox;
        }
        goto Label_0005;
    }

    public static CssBox smethod_8(object object_0, RPoint rpoint_0, bool bool_0 = true)
    {
        if ((object_0 != null) && !((!bool_0 || (object_0.Visibility == "visible")) ? (!object_0.Bounds.IsEmpty && !object_0.Bounds.Contains(rpoint_0)) : true))
        {
            using (List<CssBox>.Enumerator enumerator = object_0.Boxes.GetEnumerator())
            {
                CssBox current;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (Class48.smethod_6<CssLineBox, RRect>(object_0.Rectangles, object_0.Bounds).Contains(rpoint_0))
                    {
                        goto Label_0089;
                    }
                }
                goto Label_00A7;
            Label_0089:;
                return (smethod_8(current, rpoint_0, true) ?? current);
            }
        }
    Label_00A7:
        return null;
    }

    public static void smethod_9(object object_0, List<CssBox> list_0)
    {
        if (object_0 != null)
        {
            if (object_0.IsClickable && (object_0.Visibility == "visible"))
            {
                list_0.Add((CssBox) object_0);
            }
            foreach (CssBox box in object_0.Boxes)
            {
                smethod_9(box, list_0);
            }
        }
    }
}

