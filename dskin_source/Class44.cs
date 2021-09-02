using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

internal sealed class Class44
{
    private readonly Class42 class42_0;

    public Class44(Class42 class42_1)
    {
        ArgChecker.AssertArgNotNull(class42_1, "cssParser");
        this.class42_0 = class42_1;
    }

    public CssBox method_0(string string_0, HtmlContainerInt htmlContainerInt_0, ref CssData cssData_0)
    {
        CssBox box = Class45.smethod_0(string_0);
        if (box != null)
        {
            box.HtmlContainer = htmlContainerInt_0;
            bool flag = false;
            this.method_1(box, htmlContainerInt_0, ref cssData_0, ref flag);
            this.method_2(box, cssData_0);
            this.method_3(htmlContainerInt_0, cssData_0);
            smethod_10(box);
            smethod_11(box);
            bool flag2 = true;
            smethod_12(box, ref flag2);
            smethod_16(box);
            smethod_13(box);
            smethod_16(box);
        }
        return box;
    }

    private void method_1(CssBox cssBox_0, HtmlContainerInt htmlContainerInt_0, ref CssData cssData_0, ref bool bool_0)
    {
        if (cssBox_0.HtmlTag != null)
        {
            if (cssBox_0.HtmlTag.Name.Equals("link", StringComparison.CurrentCultureIgnoreCase) && cssBox_0.GetAttribute("rel", string.Empty).Equals("stylesheet", StringComparison.CurrentCultureIgnoreCase))
            {
                string str;
                CssData data;
                smethod_5(ref cssData_0, ref bool_0);
                Class41.smethod_0(htmlContainerInt_0, cssBox_0.GetAttribute("href", string.Empty), cssBox_0.HtmlTag.Attributes, out str, out data);
                if (str != null)
                {
                    this.class42_0.method_1(cssData_0, str);
                }
                else if (data != null)
                {
                    cssData_0.Combine(data);
                }
            }
            if (cssBox_0.HtmlTag.Name.Equals("style", StringComparison.CurrentCultureIgnoreCase) && (cssBox_0.Boxes.Count > 0))
            {
                smethod_5(ref cssData_0, ref bool_0);
                foreach (CssBox box in cssBox_0.Boxes)
                {
                    this.class42_0.method_1(cssData_0, box.Text.CutSubstring());
                }
            }
        }
        foreach (CssBox box2 in cssBox_0.Boxes)
        {
            this.method_1(box2, htmlContainerInt_0, ref cssData_0, ref bool_0);
        }
    }

    public void method_2(CssBox cssBox_0, CssData cssData_0)
    {
        cssBox_0.method_7(null, false);
        if (cssBox_0.HtmlTag != null)
        {
            smethod_1(cssBox_0, cssData_0, "*");
            smethod_1(cssBox_0, cssData_0, cssBox_0.HtmlTag.Name);
            if (cssBox_0.HtmlTag.HasAttribute("class"))
            {
                smethod_0(cssBox_0, cssData_0);
            }
            if (cssBox_0.HtmlTag.HasAttribute("id"))
            {
                smethod_1(cssBox_0, cssData_0, "#" + cssBox_0.HtmlTag.TryGetAttribute("id", null));
            }
            this.method_4(cssBox_0.HtmlTag, cssBox_0);
            if (cssBox_0.HtmlTag.HasAttribute("style"))
            {
                CssBlock block = this.class42_0.method_2(cssBox_0.HtmlTag.Name, cssBox_0.HtmlTag.TryGetAttribute("style", null));
                if (block != null)
                {
                    smethod_4(cssBox_0, block);
                }
            }
        }
        if ((cssBox_0.TextDecoration != string.Empty) && (cssBox_0.Text == null))
        {
            foreach (CssBox box in cssBox_0.Boxes)
            {
                box.TextDecoration = cssBox_0.TextDecoration;
            }
            cssBox_0.TextDecoration = string.Empty;
        }
        foreach (CssBox box in cssBox_0.Boxes)
        {
            this.method_2(box, cssData_0);
        }
    }

    private void method_3(HtmlContainerInt htmlContainerInt_0, CssData cssData_0)
    {
        htmlContainerInt_0.method_3(RColor.Empty);
        htmlContainerInt_0.method_5(RColor.Empty);
        if (cssData_0.ContainsCssBlock("::selection", "all"))
        {
            foreach (CssBlock block in cssData_0.GetCssBlock("::selection", "all"))
            {
                if (block.Properties.ContainsKey("color"))
                {
                    htmlContainerInt_0.method_3(this.class42_0.method_4(block.Properties["color"]));
                }
                if (block.Properties.ContainsKey("background-color"))
                {
                    htmlContainerInt_0.method_5(this.class42_0.method_4(block.Properties["background-color"]));
                }
            }
        }
    }

    private void method_4(HtmlTag htmlTag_0, CssBox cssBox_0)
    {
        if (htmlTag_0.HasAttributes())
        {
            foreach (string str in htmlTag_0.Attributes.Keys)
            {
                string str2 = htmlTag_0.Attributes[str];
                switch (str)
                {
                    case "align":
                    {
                        if ((((str2 != "left") && (str2 != "center")) && (str2 != "right")) && !(str2 == "justify"))
                        {
                            break;
                        }
                        cssBox_0.TextAlign = str2.ToLower();
                        continue;
                    }
                    case "background":
                    {
                        cssBox_0.BackgroundImage = str2.ToLower();
                        continue;
                    }
                    case "bgcolor":
                    {
                        cssBox_0.BackgroundColor = str2.ToLower();
                        continue;
                    }
                    case "border":
                    {
                        if (!(string.IsNullOrEmpty(str2) || !(str2 != "0")))
                        {
                            cssBox_0.BorderLeftStyle = cssBox_0.BorderTopStyle = cssBox_0.BorderRightStyle = cssBox_0.BorderBottomStyle = "solid";
                        }
                        cssBox_0.BorderLeftWidth = cssBox_0.BorderTopWidth = cssBox_0.BorderRightWidth = cssBox_0.BorderBottomWidth = smethod_6(str2);
                        if (htmlTag_0.Name == "table")
                        {
                            if (str2 != "0")
                            {
                                smethod_7(cssBox_0, "1px");
                            }
                        }
                        else
                        {
                            cssBox_0.BorderTopStyle = cssBox_0.BorderLeftStyle = cssBox_0.BorderRightStyle = cssBox_0.BorderBottomStyle = "solid";
                        }
                        continue;
                    }
                    case "bordercolor":
                    {
                        cssBox_0.BorderLeftColor = cssBox_0.BorderTopColor = cssBox_0.BorderRightColor = cssBox_0.BorderBottomColor = str2.ToLower();
                        continue;
                    }
                    case "cellspacing":
                    {
                        cssBox_0.BorderSpacing = smethod_6(str2);
                        continue;
                    }
                    case "cellpadding":
                    {
                        smethod_8(cssBox_0, str2);
                        continue;
                    }
                    case "color":
                    {
                        cssBox_0.Color = str2.ToLower();
                        continue;
                    }
                    case "dir":
                    {
                        cssBox_0.Direction = str2.ToLower();
                        continue;
                    }
                    case "face":
                    {
                        cssBox_0.FontFamily = this.class42_0.method_3(str2);
                        continue;
                    }
                    case "height":
                    {
                        cssBox_0.Height = smethod_6(str2);
                        continue;
                    }
                    case "hspace":
                    {
                        cssBox_0.MarginRight = cssBox_0.MarginLeft = smethod_6(str2);
                        continue;
                    }
                    case "nowrap":
                    {
                        cssBox_0.WhiteSpace = "nowrap";
                        continue;
                    }
                    case "size":
                    {
                        if (!htmlTag_0.Name.Equals("hr", StringComparison.OrdinalIgnoreCase))
                        {
                            goto Label_03D5;
                        }
                        cssBox_0.Height = smethod_6(str2);
                        continue;
                    }
                    case "valign":
                    {
                        cssBox_0.VerticalAlign = str2.ToLower();
                        continue;
                    }
                    case "vspace":
                    {
                        cssBox_0.MarginTop = cssBox_0.MarginBottom = smethod_6(str2);
                        continue;
                    }
                    case "width":
                    {
                        cssBox_0.Width = smethod_6(str2);
                        continue;
                    }
                    default:
                    {
                        continue;
                    }
                }
                cssBox_0.VerticalAlign = str2.ToLower();
                continue;
            Label_03D5:
                if (htmlTag_0.Name.Equals("font", StringComparison.OrdinalIgnoreCase))
                {
                    cssBox_0.FontSize = str2;
                }
            }
        }
    }

    private static bool pxKgIljAqx(CssBox cssBox_0, string string_0, string string_1)
    {
        if ((cssBox_0.HtmlTag != null) && (string_0 == "display"))
        {
            switch (cssBox_0.HtmlTag.Name)
            {
                case "table":
                    return (string_1 == "table");

                case "tr":
                    return (string_1 == "table-row");

                case "tbody":
                    return (string_1 == "table-row-group");

                case "thead":
                    return (string_1 == "table-header-group");

                case "tfoot":
                    return (string_1 == "table-footer-group");

                case "col":
                    return (string_1 == "table-column");

                case "colgroup":
                    return (string_1 == "table-column-group");

                case "td":
                case "th":
                    return (string_1 == "table-cell");

                case "caption":
                    return (string_1 == "table-caption");
            }
        }
        return true;
    }

    private static void smethod_0(CssBox cssBox_0, CssData cssData_0)
    {
        // This item is obfuscated and can not be translated.
        string str = cssBox_0.HtmlTag.TryGetAttribute("class", null);
        int startIndex = 0;
        while (startIndex < str.Length)
        {
        Label_002F:
            if (startIndex < str.Length)
            {
            }
            if (0 == 0)
            {
                if (startIndex < str.Length)
                {
                    int index = str.IndexOf(' ', startIndex);
                    if (index < 0)
                    {
                        index = str.Length;
                    }
                    string str2 = "." + str.Substring(startIndex, index - startIndex);
                    smethod_1(cssBox_0, cssData_0, str2);
                    smethod_1(cssBox_0, cssData_0, cssBox_0.HtmlTag.Name + str2);
                    startIndex = index + 1;
                }
            }
            else
            {
                startIndex++;
                goto Label_002F;
            }
        }
    }

    private static void smethod_1(CssBox cssBox_0, CssData cssData_0, string string_0)
    {
        foreach (CssBlock block in cssData_0.GetCssBlock(string_0, "all"))
        {
            if (smethod_2(cssBox_0, block))
            {
                smethod_4(cssBox_0, block);
            }
        }
    }

    private static void smethod_10(CssBox cssBox_0)
    {
        for (int i = cssBox_0.Boxes.Count - 1; i >= 0; i--)
        {
            CssBox box = cssBox_0.Boxes[i];
            if (box.Text != null)
            {
                if ((((((!box.Text.IsEmptyOrWhitespace() || (box.WhiteSpace == "pre")) || (box.WhiteSpace == "pre-wrap")) || (cssBox_0.Boxes.Count == 1)) || ((((i > 0) && (i < (cssBox_0.Boxes.Count - 1))) && cssBox_0.Boxes[i - 1].IsInline) && cssBox_0.Boxes[i + 1].IsInline)) || (((i == 0) && (cssBox_0.Boxes.Count > 1)) && (cssBox_0.Boxes[1].IsInline && cssBox_0.IsInline))) || ((((i == (cssBox_0.Boxes.Count - 1)) && (cssBox_0.Boxes.Count > 1)) && cssBox_0.Boxes[i - 1].IsInline) && cssBox_0.IsInline))
                {
                    box.ParseToWords();
                }
                else
                {
                    box.ParentBox.Boxes.RemoveAt(i);
                }
            }
            else
            {
                smethod_10(box);
            }
        }
    }

    private static void smethod_11(CssBox cssBox_0)
    {
        for (int i = cssBox_0.Boxes.Count - 1; i >= 0; i--)
        {
            CssBox before = cssBox_0.Boxes[i];
            if ((before is Class26) && (before.Display == "block"))
            {
                CssBox box2 = CssBox.CreateBlock(before.ParentBox, null, before);
                before.ParentBox = box2;
                before.Display = "inline";
            }
            else
            {
                smethod_11(before);
            }
        }
    }

    private static void smethod_12(CssBox cssBox_0, ref bool bool_0)
    {
        // This item is obfuscated and can not be translated.
        CssBox box;
        bool_0 = bool_0 || cssBox_0.IsBlock;
        foreach (CssBox box2 in cssBox_0.Boxes)
        {
            smethod_12(box2, ref bool_0);
            bool_0 = (box2.Words.Count == 0) && (bool_0 || box2.IsBlock);
        }
        int num2 = -1;
    Label_012B:
        box = null;
        int num = 0;
    Label_00EC:
        if (num < cssBox_0.Boxes.Count)
        {
        }
        if (0 == 0)
        {
            if (box != null)
            {
                box.Display = "block";
                if (bool_0)
                {
                    box.Height = ".95em";
                }
            }
            if (box == null)
            {
                return;
            }
        }
        else
        {
            if ((num > num2) && cssBox_0.Boxes[num].IsBrElement)
            {
                box = cssBox_0.Boxes[num];
                num2 = num;
            }
            else if (cssBox_0.Boxes[num].Words.Count > 0)
            {
                bool_0 = false;
            }
            else if (cssBox_0.Boxes[num].IsBlock)
            {
                bool_0 = true;
            }
            num++;
            goto Label_00EC;
        }
        goto Label_012B;
    }

    private static void smethod_13(CssBox cssBox_0)
    {
        try
        {
            if (Class50.smethod_1(cssBox_0) && !smethod_17(cssBox_0))
            {
                CssBox box2;
                for (CssBox box = smethod_14(cssBox_0); box != null; box = box2)
                {
                    box2 = null;
                    if (!(!Class50.smethod_1(box) || smethod_17(box)))
                    {
                        box2 = smethod_14(box);
                    }
                    box.ParentBox.SetAllBoxes(box);
                    box.ParentBox = null;
                }
            }
            if (!Class50.smethod_1(cssBox_0))
            {
                foreach (CssBox box3 in cssBox_0.Boxes)
                {
                    smethod_13(box3);
                }
            }
        }
        catch (Exception exception)
        {
            cssBox_0.HtmlContainer.method_8(HtmlRenderErrorType.HtmlParsing, "Failed in block inside inline box correction", exception);
        }
    }

    private static CssBox smethod_14(object object_0)
    {
        if (object_0.Display == "inline")
        {
            object_0.Display = "block";
        }
        if ((object_0.Boxes.Count > 1) || (object_0.Boxes[0].Boxes.Count > 1))
        {
            CssBox box2 = CssBox.CreateBlock((CssBox) object_0, null, null);
            while (smethod_17(object_0.Boxes[0]))
            {
                object_0.Boxes[0].ParentBox = box2;
            }
            box2.SetBeforeBox(object_0.Boxes[0]);
            CssBox box4 = object_0.Boxes[1];
            box4.ParentBox = null;
            smethod_15((CssBox) object_0, box4, box2);
            if (box2.Boxes.Count < 1)
            {
                box2.ParentBox = null;
            }
            int num = (box2.ParentBox != null) ? 2 : 1;
            if (object_0.Boxes.Count > num)
            {
                CssBox box = CssBox.CreateBox((CssBox) object_0, null, object_0.Boxes[num]);
                while (object_0.Boxes.Count > (num + 1))
                {
                    object_0.Boxes[num + 1].ParentBox = box;
                }
                return box;
            }
        }
        else if (object_0.Boxes[0].Display == "inline")
        {
            object_0.Boxes[0].Display = "block";
        }
        return null;
    }

    private static void smethod_15(CssBox cssBox_0, CssBox cssBox_1, CssBox cssBox_2)
    {
        // This item is obfuscated and can not be translated.
        CssBox box = null;
        while (!cssBox_1.Boxes[0].IsInline)
        {
        Label_0005:
            if (0 == 0)
            {
                CssBox box3 = cssBox_1.Boxes[0];
                if (!smethod_17(box3))
                {
                    smethod_15(cssBox_0, box3, cssBox_2);
                    box3.ParentBox = null;
                }
                else
                {
                    box3.ParentBox = cssBox_0;
                }
                if (cssBox_1.Boxes.Count > 0)
                {
                    CssBox box2;
                    if ((box3.ParentBox != null) || (cssBox_0.Boxes.Count < 3))
                    {
                        box2 = CssBox.CreateBox(cssBox_0, cssBox_1.HtmlTag, null);
                        box2.method_7(cssBox_1, true);
                        if (cssBox_0.Boxes.Count > 2)
                        {
                            box2.SetBeforeBox(cssBox_0.Boxes[1]);
                        }
                        if (box3.ParentBox != null)
                        {
                            box3.SetBeforeBox(box2);
                        }
                    }
                    else
                    {
                        box2 = cssBox_0.Boxes[2];
                    }
                    box2.SetAllBoxes(cssBox_1);
                }
                else if ((box3.ParentBox != null) && (cssBox_0.Boxes.Count > 1))
                {
                    box3.SetBeforeBox(cssBox_0.Boxes[1]);
                    if (((box3.HtmlTag != null) && (box3.HtmlTag.Name == "br")) && ((box != null) || (cssBox_2.Boxes.Count > 1)))
                    {
                        box3.Display = "inline";
                    }
                }
                return;
            }
            if (box == null)
            {
                box = CssBox.CreateBox(cssBox_2, cssBox_1.HtmlTag, null);
                box.method_7(cssBox_1, true);
            }
            cssBox_1.Boxes[0].ParentBox = box;
        }
        goto Label_0005;
    }

    private static void smethod_16(CssBox cssBox_0)
    {
        if (smethod_18(cssBox_0))
        {
            for (int i = 0; i < cssBox_0.Boxes.Count; i++)
            {
                if (!cssBox_0.Boxes[i].IsInline)
                {
                    continue;
                }
                CssBox box = CssBox.CreateBlock(cssBox_0, null, cssBox_0.Boxes[i++]);
                while (i >= cssBox_0.Boxes.Count)
                {
                Label_0043:
                    if (0 == 0)
                    {
                        continue;
                    }
                    cssBox_0.Boxes[i].ParentBox = box;
                }
                goto Label_0043;
            }
        }
        if (!Class50.smethod_1(cssBox_0))
        {
            foreach (CssBox box2 in cssBox_0.Boxes)
            {
                smethod_16(box2);
            }
        }
    }

    private static bool smethod_17(CssBox cssBox_0)
    {
        foreach (CssBox box in cssBox_0.Boxes)
        {
            if (!(box.IsInline && smethod_17(box)))
            {
                return false;
            }
        }
        return true;
    }

    private static bool smethod_18(CssBox cssBox_0)
    {
        // This item is obfuscated and can not be translated.
        bool flag = false;
        bool flag2 = false;
        int num = 0;
        while (num >= cssBox_0.Boxes.Count)
        {
        Label_0009:
            if (0 == 0)
            {
                return (flag && flag2);
            }
            bool flag3 = !cssBox_0.Boxes[num].IsInline;
            flag = flag || flag3;
            flag2 = flag2 || !flag3;
            num++;
            continue;
        Label_0039:
            if (flag)
            {
            }
            goto Label_0009;
        }
        goto Label_0039;
    }

    private static bool smethod_2(CssBox cssBox_0, CssBlock cssBlock_0)
    {
        bool flag = true;
        if (cssBlock_0.Selectors != null)
        {
            flag = smethod_3(cssBox_0, cssBlock_0);
        }
        else if (!((!cssBox_0.HtmlTag.Name.Equals("a", StringComparison.OrdinalIgnoreCase) || !cssBlock_0.Class.Equals("a", StringComparison.OrdinalIgnoreCase)) || cssBox_0.HtmlTag.HasAttribute("href")))
        {
            flag = false;
        }
        if (flag && cssBlock_0.Hover)
        {
            cssBox_0.HtmlContainer.method_10(cssBox_0, cssBlock_0);
            flag = false;
        }
        return flag;
    }

    private static bool smethod_3(CssBox cssBox_0, CssBlock cssBlock_0)
    {
        foreach (CssBlockSelectorItem item in cssBlock_0.Selectors)
        {
            bool flag = false;
            while (!flag)
            {
                cssBox_0 = cssBox_0.ParentBox;
                while (cssBox_0 == null)
                {
                Label_002C:
                    if (0 == 0)
                    {
                        goto Label_0048;
                    }
                    cssBox_0 = cssBox_0.ParentBox;
                }
                goto Label_002C;
            Label_0048:
                if (cssBox_0 == null)
                {
                    return false;
                }
                if (cssBox_0.HtmlTag.Name.Equals(item.Class, StringComparison.InvariantCultureIgnoreCase))
                {
                    flag = true;
                }
                if (!(flag || !cssBox_0.HtmlTag.HasAttribute("class")))
                {
                    string str2 = cssBox_0.HtmlTag.TryGetAttribute("class", null);
                    if (item.Class.Equals("." + str2, StringComparison.InvariantCultureIgnoreCase) || item.Class.Equals(cssBox_0.HtmlTag.Name + "." + str2, StringComparison.InvariantCultureIgnoreCase))
                    {
                        flag = true;
                    }
                }
                if (!(flag || !cssBox_0.HtmlTag.HasAttribute("id")))
                {
                    string str = cssBox_0.HtmlTag.TryGetAttribute("id", null);
                    if (item.Class.Equals("#" + str, StringComparison.InvariantCultureIgnoreCase))
                    {
                        flag = true;
                    }
                }
                if (!(flag || !item.DirectParent))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void smethod_4(CssBox cssBox_0, CssBlock cssBlock_0)
    {
        foreach (KeyValuePair<string, string> pair in cssBlock_0.Properties)
        {
            string str = pair.Value;
            if ((pair.Value == "inherit") && (cssBox_0.ParentBox != null))
            {
                str = Class49.smethod_2(cssBox_0.ParentBox, pair.Key);
            }
            if (pxKgIljAqx(cssBox_0, pair.Key, str))
            {
                Class49.smethod_3(cssBox_0, pair.Key, str);
            }
        }
    }

    private static void smethod_5(ref CssData cssData_0, ref bool bool_0)
    {
        if (!bool_0)
        {
            bool_0 = true;
            cssData_0 = cssData_0.Clone();
        }
    }

    private static string smethod_6(string string_0)
    {
        Class30 class2 = new Class30(string_0);
        if (class2.method_1())
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0}px", new object[] { string_0 });
        }
        return string_0;
    }

    private static void smethod_7(CssBox cssBox_0, string string_0)
    {
        <>c__DisplayClass1 class2;
        string border = string_0;
        smethod_9(cssBox_0, new Delegate1<CssBox>(class2.<ApplyTableBorder>b__0));
    }

    private static void smethod_8(CssBox cssBox_0, string string_0)
    {
        <>c__DisplayClass4 class2;
        string length = smethod_6(string_0);
        smethod_9(cssBox_0, new Delegate1<CssBox>(class2.<ApplyTablePadding>b__3));
    }

    private static void smethod_9(CssBox cssBox_0, Delegate1<CssBox> delegate1_0)
    {
        foreach (CssBox box in cssBox_0.Boxes)
        {
            foreach (CssBox box2 in box.Boxes)
            {
                if ((box2.HtmlTag != null) && (box2.HtmlTag.Name == "td"))
                {
                    delegate1_0(box2);
                }
                else
                {
                    foreach (CssBox box3 in box2.Boxes)
                    {
                        delegate1_0(box3);
                    }
                }
            }
        }
    }
}

