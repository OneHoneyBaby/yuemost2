namespace DSkin.Html.Core.Dom
{
    using DSkin.DirectUI;
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core;
    using DSkin.Html.Core.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class CssBox : CssBoxProperties, IDisposable, IEnumerable
    {
        protected HtmlContainerInt _htmlContainer;
        protected bool _wordsSizeMeasured;
        internal bool bool_0;
        private bool bool_1 = false;
        private Class40 class40_0;
        private CssBox cssBox_0;
        private CssBox cssBox_1;
        private CssLineBox cssLineBox_0;
        private CssLineBox cssLineBox_1;
        private readonly Dictionary<CssLineBox, RRect> dictionary_0 = new Dictionary<CssLineBox, RRect>();
        private readonly DSkin.Html.Core.Dom.HtmlTag htmlTag_0;
        private readonly List<CssRect> list_0 = new List<CssRect>();
        private readonly List<CssBox> list_1 = new List<CssBox>();
        private readonly List<CssLineBox> list_2 = new List<CssLineBox>();
        private readonly List<CssLineBox> list_3 = new List<CssLineBox>();
        private SubString subString_0;

        public event EventHandler<RMouseEvent> MouseDoubleClick;

        public event EventHandler<RMouseEvent> MouseDown;

        public event EventHandler MouseEnter;

        public event EventHandler MouseLeave;

        public event EventHandler<RMouseEvent> MouseMove;

        public event EventHandler<RMouseEvent> MouseUp;

        public CssBox(CssBox parentBox, DSkin.Html.Core.Dom.HtmlTag tag)
        {
            if (parentBox != null)
            {
                this.cssBox_0 = parentBox;
                this.cssBox_0.Boxes.Add(this);
            }
            this.htmlTag_0 = tag;
        }

        public static CssBox CreateBlock()
        {
            return new CssBox(null, null) { Display = "block" };
        }

        public static CssBox CreateBlock(CssBox parent, DSkin.Html.Core.Dom.HtmlTag tag = null, CssBox before = null)
        {
            ArgChecker.AssertArgNotNull(parent, "parent");
            CssBox box = CreateBox(parent, tag, before);
            box.Display = "block";
            return box;
        }

        public static CssBox CreateBox(DSkin.Html.Core.Dom.HtmlTag tag, CssBox parent = null)
        {
            ArgChecker.AssertArgNotNull(tag, "tag");
            if (tag.Name == "img")
            {
                return new Class26(parent, tag);
            }
            if (tag.Name == "iframe")
            {
                return new Class24(parent, tag);
            }
            if (tag.Name == "hr")
            {
                return new Class25(parent, tag);
            }
            return new CssBox(parent, tag);
        }

        public static CssBox CreateBox(CssBox parent, DSkin.Html.Core.Dom.HtmlTag tag = null, CssBox before = null)
        {
            ArgChecker.AssertArgNotNull(parent, "parent");
            CssBox box = new CssBox(parent, tag);
            box.method_7(null, false);
            if (before != null)
            {
                box.SetBeforeBox(before);
            }
            return box;
        }

        public virtual void Dispose()
        {
            if (this.class40_0 != null)
            {
                this.class40_0.Dispose();
            }
            foreach (CssBox box in this.Boxes)
            {
                box.Dispose();
            }
        }

        protected override RColor GetActualColor(string colorStr)
        {
            return this.HtmlContainer.method_1().method_4(colorStr);
        }

        public string GetAttribute(string attribute)
        {
            return this.GetAttribute(attribute, string.Empty);
        }

        public string GetAttribute(string attribute, string defaultValue)
        {
            return ((this.HtmlTag != null) ? this.HtmlTag.TryGetAttribute(attribute, defaultValue) : defaultValue);
        }

        protected override RFont GetCachedFont(string fontFamily, double fsize, RFontStyle st)
        {
            return this.HtmlContainer.method_0().GetFont(fontFamily, fsize, st);
        }

        public IEnumerator GetEnumerator()
        {
            return this.Boxes.GetEnumerator();
        }

        protected sealed override CssBoxProperties GetParent()
        {
            return this.cssBox_0;
        }

        protected RBrush GetSelectionBackBrush(RGraphics g, bool forceAlpha)
        {
            RColor color = this.HtmlContainer.method_4();
            if (color != RColor.Empty)
            {
                if (forceAlpha && (color.A > 180))
                {
                    return g.GetSolidBrush(RColor.FromArgb(180, color.R, color.G, color.B));
                }
                return g.GetSolidBrush(color);
            }
            return g.GetSolidBrush(Class49.smethod_0());
        }

        protected RColor GetSelectionForeBrush()
        {
            return ((this.HtmlContainer.method_2() != RColor.Empty) ? this.HtmlContainer.method_2() : base.ActualColor);
        }

        protected double MarginTopCollapse(CssBoxProperties prevSibling)
        {
            double actualMarginTop;
            if (prevSibling != null)
            {
                actualMarginTop = Math.Max(prevSibling.ActualMarginBottom, base.ActualMarginTop);
                base.CollapsedMarginTop = actualMarginTop;
            }
            else if ((((this.cssBox_0 != null) && (base.ActualPaddingTop < 0.1)) && ((base.ActualPaddingBottom < 0.1) && (this.cssBox_0.ActualPaddingTop < 0.1))) && (this.cssBox_0.ActualPaddingBottom < 0.1))
            {
                actualMarginTop = Math.Max((double) 0.0, (double) (base.ActualMarginTop - Math.Max(this.cssBox_0.ActualMarginTop, this.cssBox_0.CollapsedMarginTop)));
            }
            else
            {
                actualMarginTop = base.ActualMarginTop;
            }
            if (((actualMarginTop < 0.1) && (this.HtmlTag != null)) && (this.HtmlTag.Name == "hr"))
            {
                actualMarginTop = base.GetEmHeight() * 1.1000000238418579;
            }
            return actualMarginTop;
        }

        private int method_0()
        {
            int num;
            bool flag = !string.IsNullOrEmpty(this.ParentBox.GetAttribute("reversed"));
            if (!int.TryParse(this.ParentBox.GetAttribute("start"), out num))
            {
                if (flag)
                {
                    num = 0;
                    foreach (CssBox box in this.ParentBox.Boxes)
                    {
                        if (box.Display == "list-item")
                        {
                            num++;
                        }
                    }
                }
                else
                {
                    num = 1;
                }
            }
            foreach (CssBox box in this.ParentBox.Boxes)
            {
                if (box.Equals(this))
                {
                    return num;
                }
                if (box.Display == "list-item")
                {
                    num += flag ? -1 : 1;
                }
            }
            return num;
        }

        private void method_1(RGraphics rgraphics_0)
        {
            if ((base.Display == "list-item") && (base.ListStyleType != "none"))
            {
                if (this.cssBox_1 == null)
                {
                    this.cssBox_1 = new CssBox(null, null);
                    this.cssBox_1.method_7(this, false);
                    this.cssBox_1.Display = "inline";
                    this.cssBox_1.HtmlContainer = this.HtmlContainer;
                    if (base.ListStyleType.Equals("disc", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.cssBox_1.Text = new SubString("•");
                    }
                    else if (base.ListStyleType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.cssBox_1.Text = new SubString("o");
                    }
                    else if (base.ListStyleType.Equals("square", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.cssBox_1.Text = new SubString("♠");
                    }
                    else if (base.ListStyleType.Equals("decimal", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.cssBox_1.Text = new SubString(this.method_0().ToString(CultureInfo.InvariantCulture) + ".");
                    }
                    else if (base.ListStyleType.Equals("decimal-leading-zero", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.cssBox_1.Text = new SubString(this.method_0().ToString("00", CultureInfo.InvariantCulture) + ".");
                    }
                    else
                    {
                        this.cssBox_1.Text = new SubString(Class48.smethod_13(this.method_0(), base.ListStyleType) + ".");
                    }
                    this.cssBox_1.ParseToWords();
                    this.cssBox_1.PerformLayoutImp(rgraphics_0);
                    this.cssBox_1.Size = new RSize(this.cssBox_1.Words[0].Width, this.cssBox_1.Words[0].Height);
                }
                this.cssBox_1.Words[0].Left = (base.Location.X - this.cssBox_1.Size.Width) - 5.0;
                this.cssBox_1.Words[0].Top = base.Location.Y + base.ActualPaddingTop;
            }
        }

        internal void method_10(double double_22)
        {
            List<CssLineBox> list = new List<CssLineBox>();
            foreach (CssLineBox box in this.Rectangles.Keys)
            {
                list.Add(box);
            }
            foreach (CssLineBox box in list)
            {
                RRect rect2 = this.Rectangles[box];
                this.Rectangles[box] = new RRect(rect2.X, rect2.Y + double_22, rect2.Width, rect2.Height);
            }
            foreach (CssRect rect in this.Words)
            {
                rect.Top += double_22;
            }
            foreach (CssBox box2 in this.Boxes)
            {
                box2.method_10(double_22);
            }
            if (this.cssBox_1 != null)
            {
                this.cssBox_1.method_10(double_22);
            }
            base.Location = new RPoint(base.Location.X, base.Location.Y + double_22);
        }

        private void method_11(RGraphics rgraphics_0, RPoint rpoint_1)
        {
            if (base.Width.Length > 0)
            {
                bool rtl = base.Direction == "rtl";
                foreach (CssRect rect in this.Words)
                {
                    if (!rect.IsLineBreak)
                    {
                        RPoint point = new RPoint(rect.Left + rpoint_1.X, rect.Top + rpoint_1.Y);
                        if (rect.Selected)
                        {
                            CssLineBox box = Class50.smethod_15(rect);
                            double num2 = (rect.SelectedStartOffset > -1.0) ? rect.SelectedStartOffset : (((box.Words[0] == rect) || !rect.HasSpaceBefore) ? 0.0 : -base.ActualWordSpacing);
                            bool flag2 = rect.HasSpaceAfter && !box.IsLastSelectedWord(rect);
                            double num = (rect.SelectedEndOffset > -1.0) ? rect.SelectedEndOffset : (rect.Width + (flag2 ? base.ActualWordSpacing : 0.0));
                            RRect rect2 = new RRect((rect.Left + rpoint_1.X) + num2, rect.Top + rpoint_1.Y, num - num2, box.LineHeight);
                            rgraphics_0.DrawRectangle(this.GetSelectionBackBrush(rgraphics_0, false), rect2.X, rect2.Y, rect2.Width, rect2.Height);
                            if ((this.HtmlContainer.method_2() != RColor.Empty) && ((rect.SelectedStartOffset > 0.0) || (rect.SelectedEndIndexOffset > -1)))
                            {
                                rgraphics_0.PushClipExclude(rect2);
                                rgraphics_0.DrawString(rect.Text, base.ActualFont, base.ActualColor, point, new RSize(rect.Width, rect.Height), rtl);
                                rgraphics_0.PopClip();
                                rgraphics_0.PushClip(rect2);
                                rgraphics_0.DrawString(rect.Text, base.ActualFont, this.GetSelectionForeBrush(), point, new RSize(rect.Width, rect.Height), rtl);
                                rgraphics_0.PopClip();
                            }
                            else
                            {
                                rgraphics_0.DrawString(rect.Text, base.ActualFont, this.GetSelectionForeBrush(), point, new RSize(rect.Width, rect.Height), rtl);
                            }
                        }
                        else
                        {
                            rgraphics_0.DrawString(rect.Text, base.ActualFont, base.ActualColor, point, new RSize(rect.Width, rect.Height), rtl);
                        }
                    }
                }
            }
        }

        internal void method_12(CssLineBox cssLineBox_2, double double_22)
        {
            if (this.Rectangles.ContainsKey(cssLineBox_2))
            {
                RRect rect = this.Rectangles[cssLineBox_2];
                this.Rectangles[cssLineBox_2] = new RRect(rect.X, rect.Y + double_22, rect.Width, rect.Height);
            }
        }

        internal void method_13()
        {
            this.dictionary_0.Clear();
        }

        private void method_14(RImage rimage_0, RRect rrect_0, bool bool_2)
        {
            if ((rimage_0 != null) && bool_2)
            {
                this.HtmlContainer.RequestRefresh(false);
            }
        }

        private void method_15(CssBox cssBox_2, StringBuilder stringBuilder_0)
        {
            foreach (CssBox box in cssBox_2)
            {
                if (box.Text != null)
                {
                    stringBuilder_0.Append(box.Text.CutSubstring());
                }
                this.method_15(box, stringBuilder_0);
            }
        }

        private IEnumerable<CssBox> method_16(CssBox cssBox_2, Func<CssBox, bool> func_0)
        {
            IEnumerator<CssBox> iteratorVariable4;
            IEnumerator enumerator = cssBox_2.GetEnumerator();
        Label_0060:
            if (!enumerator.MoveNext())
            {
                goto Label_00E9;
            }
            CssBox current = (CssBox) enumerator.Current;
            if (!((func_0 == null) ? false : !func_0.Invoke(current)))
            {
                goto Label_00E9;
            }
        Label_00A4:
            iteratorVariable4 = this.method_16(current, func_0).GetEnumerator();
            while (iteratorVariable4.MoveNext())
            {
                CssBox iteratorVariable1 = iteratorVariable4.Current;
                yield return iteratorVariable1;
            }
            goto Label_0060;
        Label_00E9:
            yield return current;
            goto Label_00A4;
        }

        internal void method_17(RMouseEvent rmouseEvent_0)
        {
            if (this.Boxes.Count > 0)
            {
                for (int i = this.Boxes.Count - 1; i >= 0; i--)
                {
                    CssBox box = this.Boxes[i];
                    if (box.ClientRectangle.Contains(new RPoint((double) rmouseEvent_0.X, (double) rmouseEvent_0.Y)))
                    {
                        RMouseEvent event2 = new RMouseEvent(rmouseEvent_0.Button, rmouseEvent_0.Clicks, rmouseEvent_0.X, rmouseEvent_0.Y, rmouseEvent_0.Delta, false, null);
                        box.method_17(event2);
                        rmouseEvent_0.Handled = event2.Handled;
                        break;
                    }
                }
            }
            if (!rmouseEvent_0.Handled)
            {
                this.OnMouseUp(rmouseEvent_0);
            }
        }

        internal void method_18(RMouseEvent rmouseEvent_0)
        {
            if (this.Boxes.Count > 0)
            {
                for (int i = this.Boxes.Count - 1; i >= 0; i--)
                {
                    CssBox box = this.Boxes[i];
                    if (box.ClientRectangle.Contains(new RPoint((double) rmouseEvent_0.X, (double) rmouseEvent_0.Y)))
                    {
                        RMouseEvent event2 = new RMouseEvent(rmouseEvent_0.Button, rmouseEvent_0.Clicks, rmouseEvent_0.X, rmouseEvent_0.Y, rmouseEvent_0.Delta, false, null);
                        box.method_18(event2);
                        rmouseEvent_0.Handled = event2.Handled;
                        break;
                    }
                }
            }
            if (!rmouseEvent_0.Handled)
            {
                this.OnMouseDown(rmouseEvent_0);
            }
        }

        internal void method_19(RMouseEvent rmouseEvent_0)
        {
            if (this.Boxes.Count > 0)
            {
                for (int i = this.Boxes.Count - 1; i >= 0; i--)
                {
                    CssBox box = this.Boxes[i];
                    if (box.ClientRectangle.Contains(new RPoint((double) rmouseEvent_0.X, (double) rmouseEvent_0.Y)))
                    {
                        RMouseEvent event2 = new RMouseEvent(rmouseEvent_0.Button, rmouseEvent_0.Clicks, rmouseEvent_0.X, rmouseEvent_0.Y, rmouseEvent_0.Delta, false, null);
                        box.method_19(event2);
                        rmouseEvent_0.Handled = event2.Handled;
                        break;
                    }
                }
            }
            if (!rmouseEvent_0.Handled)
            {
                this.OnMouseDoubleClick(rmouseEvent_0);
            }
        }

        internal CssRect method_2(CssBox cssBox_2, CssLineBox cssLineBox_2)
        {
            if ((cssBox_2.Words.Count != 0) || (cssBox_2.Boxes.Count != 0))
            {
                if (cssBox_2.Words.Count > 0)
                {
                    foreach (CssRect rect3 in cssBox_2.Words)
                    {
                        if (cssLineBox_2.Words.Contains(rect3))
                        {
                            return rect3;
                        }
                    }
                    return null;
                }
                foreach (CssBox box in cssBox_2.Boxes)
                {
                    CssRect rect = this.method_2(box, cssLineBox_2);
                    if (rect != null)
                    {
                        return rect;
                    }
                }
            }
            return null;
        }

        internal void method_20(RMouseEvent rmouseEvent_0)
        {
            if (this.Boxes.Count > 0)
            {
                for (int i = this.Boxes.Count - 1; i >= 0; i--)
                {
                    CssBox box2 = this.Boxes[i];
                    if (box2.ClientRectangle.Contains(new RPoint((double) rmouseEvent_0.X, (double) rmouseEvent_0.Y)))
                    {
                        if (!box2.bool_1)
                        {
                            foreach (CssBox box in this.Boxes)
                            {
                                if ((box2 != box) && box.bool_1)
                                {
                                    box.method_23(rmouseEvent_0);
                                }
                            }
                            box2.method_22(rmouseEvent_0);
                        }
                        RMouseEvent event2 = new RMouseEvent(rmouseEvent_0.Button, rmouseEvent_0.Clicks, rmouseEvent_0.X, rmouseEvent_0.Y, rmouseEvent_0.Delta, false, null);
                        box2.method_20(event2);
                        rmouseEvent_0.Handled = event2.Handled;
                        break;
                    }
                    if (box2.bool_1)
                    {
                        box2.method_23(rmouseEvent_0);
                    }
                }
            }
            if (!rmouseEvent_0.Handled)
            {
                this.OnMouseMove(rmouseEvent_0);
            }
        }

        internal bool method_21()
        {
            return this.bool_1;
        }

        internal void method_22(EventArgs eventArgs_0)
        {
            this.bool_1 = true;
            string attribute = this.GetAttribute("title");
            if (!string.IsNullOrEmpty(attribute) && ((this._htmlContainer != null) && (this._htmlContainer.Control != null)))
            {
                Control hostControl = null;
                if (this._htmlContainer.Control is ControlAdapter)
                {
                    hostControl = ((ControlAdapter) this._htmlContainer.Control).Control;
                }
                if (this._htmlContainer.Control is DuiControlAdapter)
                {
                    hostControl = ((DuiControlAdapter) this._htmlContainer.Control).DuiControl.HostControl;
                }
                if (hostControl != null)
                {
                    DuiBaseControl.DuiToolTip.SetToolTip(hostControl, attribute);
                }
            }
            this.OnMouseEnter(eventArgs_0);
        }

        internal void method_23(EventArgs eventArgs_0)
        {
            this.bool_1 = false;
            foreach (CssBox box in this.Boxes)
            {
                if (box.bool_1)
                {
                    box.method_23(eventArgs_0);
                }
            }
            if (!string.IsNullOrEmpty(this.GetAttribute("title")))
            {
                DuiBaseControl.DuiToolTip.RemoveAll();
            }
            this.OnMouseLeave(eventArgs_0);
        }

        internal double method_3()
        {
            double num = 0.0;
            CssRect rect = null;
            smethod_0(this, ref num, ref rect);
            double num2 = 0.0;
            if (rect != null)
            {
                for (CssBox box = rect.OwnerBox; box != null; box = (box != this) ? box.ParentBox : null)
                {
                    num2 += ((box.ActualBorderRightWidth + box.ActualPaddingRight) + box.ActualBorderLeftWidth) + box.ActualPaddingLeft;
                }
            }
            return (num + num2);
        }

        internal double method_4(CssBox cssBox_2, double double_22)
        {
            foreach (CssLineBox box in cssBox_2.Rectangles.Keys)
            {
                RRect rect = cssBox_2.Rectangles[box];
                double_22 = Math.Max(double_22, rect.Bottom);
            }
            foreach (CssBox box2 in cssBox_2.Boxes)
            {
                double_22 = Math.Max(double_22, this.method_4(box2, double_22));
            }
            return double_22;
        }

        internal void method_5(out double double_22, out double double_23)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            smethod_2(this, ref num, ref num2, ref num3, ref num4);
            double_23 = num3 + num2;
            double_22 = num3 + ((num < 90999.0) ? num : 0.0);
        }

        internal bool method_6()
        {
            return ((this.ParentBox != null) && Class50.smethod_1(this.ParentBox));
        }

        internal void method_7(CssBox cssBox_2 = null, bool bool_2 = false)
        {
            base.InheritStyle(cssBox_2 ?? this.ParentBox, bool_2);
        }

        private double method_8()
        {
            if (base.ActualRight > 90999.0)
            {
                double num = 0.0;
                foreach (CssBox box in this.Boxes)
                {
                    num = Math.Max(num, box.ActualRight + box.ActualMarginRight);
                }
                return (((num + base.ActualPaddingRight) + base.ActualMarginRight) + base.ActualBorderRightWidth);
            }
            return base.ActualRight;
        }

        private double method_9()
        {
            double num = 0.0;
            if (((this.ParentBox != null) && (this.ParentBox.Boxes.IndexOf(this) == (this.ParentBox.Boxes.Count - 1))) && (this.cssBox_0.ActualMarginBottom < 0.1))
            {
                double actualMarginBottom = this.list_1[this.list_1.Count - 1].ActualMarginBottom;
                num = (base.Height == "auto") ? Math.Max(base.ActualMarginBottom, actualMarginBottom) : actualMarginBottom;
            }
            return Math.Max(base.ActualBottom, ((this.list_1[this.list_1.Count - 1].ActualBottom + num) + base.ActualPaddingBottom) + base.ActualBorderBottomWidth);
        }

        protected virtual void OnMouseDoubleClick(RMouseEvent e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnMouseDown(RMouseEvent e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnMouseEnter(EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnMouseLeave(EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnMouseMove(RMouseEvent e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnMouseUp(RMouseEvent e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        public void Paint(RGraphics g)
        {
            try
            {
                if ((base.Display != "none") && (base.Visibility == "visible"))
                {
                    bool flag;
                    if (!(flag = this.Rectangles.Count == 0))
                    {
                        RRect clip = g.GetClip();
                        RRect clientRectangle = this.ContainingBlock.ClientRectangle;
                        clientRectangle.X -= 2.0;
                        clientRectangle.Width += 2.0;
                        clientRectangle.Offset(new RPoint(-this.HtmlContainer.Location.X, -this.HtmlContainer.Location.Y));
                        clientRectangle.Offset(this.HtmlContainer.ScrollOffset);
                        clip.Intersect(clientRectangle);
                        if ((clip.Width >= 1.0) && (clip.Height >= 1.0))
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        this.PaintImp(g);
                    }
                }
            }
            catch (Exception exception)
            {
                this.HtmlContainer.method_8(HtmlRenderErrorType.Paint, "Exception in box paint", exception);
            }
        }

        protected void PaintBackground(RGraphics g, RRect rect, bool isFirst, bool isLast)
        {
            if ((rect.Width > 0.0) && (rect.Height > 0.0))
            {
                RBrush solidBrush = null;
                if (base.BackgroundGradient != "none")
                {
                    solidBrush = g.GetLinearGradientBrush(rect, base.ActualBackgroundColor, base.ActualBackgroundGradient, base.ActualBackgroundGradientAngle);
                }
                else if (Class53.XqRamjooQr(base.ActualBackgroundColor))
                {
                    solidBrush = g.GetSolidBrush(base.ActualBackgroundColor);
                }
                if (solidBrush != null)
                {
                    RGraphicsPath path = null;
                    if (base.IsRounded)
                    {
                        path = Class53.smethod_3(g, rect, base.ActualCornerNw, base.ActualCornerNe, base.ActualCornerSe, base.ActualCornerSw);
                    }
                    object prevMode = null;
                    if (((this.HtmlContainer != null) && !this.HtmlContainer.AvoidGeometryAntialias) && base.IsRounded)
                    {
                        prevMode = g.SetAntiAliasSmoothingMode();
                    }
                    if (path != null)
                    {
                        g.DrawPath(solidBrush, path);
                    }
                    else
                    {
                        g.DrawRectangle(solidBrush, Math.Ceiling(rect.X), Math.Ceiling(rect.Y), rect.Width, rect.Height);
                    }
                    g.ReturnPreviousSmoothingMode(prevMode);
                    if (path != null)
                    {
                        path.Dispose();
                    }
                    solidBrush.Dispose();
                }
                if (((this.class40_0 != null) && (this.class40_0.Image != null)) && isFirst)
                {
                    Class34.smethod_0(g, this, this.class40_0, rect);
                }
            }
        }

        protected void PaintDecoration(RGraphics g, RRect rectangle, bool isFirst, bool isLast)
        {
            if (!string.IsNullOrEmpty(base.TextDecoration) && (base.TextDecoration != "none"))
            {
                double top = 0.0;
                if (base.TextDecoration == "underline")
                {
                    top = Math.Round((double) (rectangle.Top + base.ActualFont.UnderlineOffset));
                }
                else if (base.TextDecoration == "line-through")
                {
                    top = rectangle.Top + (rectangle.Height / 2.0);
                }
                else if (base.TextDecoration == "overline")
                {
                    top = rectangle.Top;
                }
                top -= base.ActualPaddingBottom - base.ActualBorderBottomWidth;
                double x = rectangle.X;
                if (isFirst)
                {
                    x += base.ActualPaddingLeft + base.ActualBorderLeftWidth;
                }
                double right = rectangle.Right;
                if (isLast)
                {
                    right -= base.ActualPaddingRight + base.ActualBorderRightWidth;
                }
                RPen pen = g.GetPen(base.ActualColor);
                pen.Width = 1.0;
                pen.DashStyle = RDashStyle.Solid;
                g.DrawLine(pen, x, top, right, top);
            }
        }

        protected virtual void PaintImp(RGraphics g)
        {
            if ((base.Display != "none") && (((base.Display != "table-cell") || (base.EmptyCells != "hide")) || !this.IsSpaceOrEmpty))
            {
                int num;
                RRect rect;
                bool flag = Class53.smethod_0(g, this);
                RRect[] rectArray = ((this.Rectangles.Count == 0) ? new List<RRect>(new RRect[1]) : new List<RRect>(this.Rectangles.Values)).ToArray();
                RPoint scrollOffset = this.HtmlContainer.ScrollOffset;
                for (num = 0; num < rectArray.Length; num++)
                {
                    rect = rectArray[num];
                    rect.Offset(scrollOffset);
                    this.PaintBackground(g, rect, num == 0, num == (rectArray.Length - 1));
                    Class35.smethod_0(g, this, rect, num == 0, num == (rectArray.Length - 1));
                }
                this.method_11(g, scrollOffset);
                for (num = 0; num < rectArray.Length; num++)
                {
                    rect = rectArray[num];
                    rect.Offset(scrollOffset);
                    this.PaintDecoration(g, rect, num == 0, num == (rectArray.Length - 1));
                }
                foreach (CssBox box in this.Boxes)
                {
                    if (box.Position != "absolute")
                    {
                        box.Paint(g);
                    }
                }
                foreach (CssBox box in this.Boxes)
                {
                    if (box.Position == "absolute")
                    {
                        box.Paint(g);
                    }
                }
                if (flag)
                {
                    g.PopClip();
                }
                if (this.cssBox_1 != null)
                {
                    this.cssBox_1.Paint(g);
                }
            }
        }

        public void ParseToWords()
        {
            // This item is obfuscated and can not be translated.
            bool flag2;
            this.list_0.Clear();
            int startIdx = 0;
            bool flag4 = (flag2 = (base.WhiteSpace == "pre") || (base.WhiteSpace == "pre-wrap")) || (base.WhiteSpace == "pre-line");
        Label_02A3:
            if (startIdx < this.subString_0.Length)
            {
                while (true)
                {
                    if (startIdx < this.subString_0.Length)
                    {
                    }
                    if (0 == 0)
                    {
                        if (startIdx >= this.subString_0.Length)
                        {
                            goto Label_02A3;
                        }
                        int num2 = startIdx;
                    Label_00C6:
                        if ((num2 < this.subString_0.Length) && !char.IsWhiteSpace(this.subString_0[num2]))
                        {
                        }
                        if (0 == 0)
                        {
                            if (num2 > startIdx)
                            {
                                if (flag2)
                                {
                                    this.list_0.Add(new Class32(this, Class52.smethod_1(this.subString_0.Substring(startIdx, num2 - startIdx)), false, false));
                                }
                            }
                            else
                            {
                                num2 = startIdx;
                            Label_016C:
                                if ((num2 < this.subString_0.Length) && ((char.IsWhiteSpace(this.subString_0[num2]) || (this.subString_0[num2] == '-')) || !(base.WordBreak != "break-all")))
                                {
                                }
                                if (0 == 0)
                                {
                                    if ((num2 < this.subString_0.Length) && (((this.subString_0[num2] == '-') || (base.WordBreak == "break-all")) || Class48.smethod_0(this.subString_0[num2])))
                                    {
                                        num2++;
                                    }
                                    if (num2 > startIdx)
                                    {
                                        bool flag = !flag2 && (((startIdx > 0) && (this.list_0.Count == 0)) && char.IsWhiteSpace(this.subString_0[startIdx - 1]));
                                        bool flag3 = !flag2 && ((num2 < this.subString_0.Length) && char.IsWhiteSpace(this.subString_0[num2]));
                                        this.list_0.Add(new Class32(this, Class52.smethod_1(this.subString_0.Substring(startIdx, num2 - startIdx)), flag, flag3));
                                    }
                                }
                                else
                                {
                                    num2++;
                                    goto Label_016C;
                                }
                            }
                        }
                        else
                        {
                            num2++;
                            goto Label_00C6;
                        }
                        if ((num2 < this.subString_0.Length) && (this.subString_0[num2] == '\n'))
                        {
                            num2++;
                            if (flag4)
                            {
                                this.list_0.Add(new Class32(this, "\n", false, false));
                            }
                        }
                        startIdx = num2;
                        goto Label_02A3;
                    }
                    startIdx++;
                }
            }
        }

        public void PerformLayout(RGraphics g)
        {
            try
            {
                this.PerformLayoutImp(g);
            }
            catch (Exception exception)
            {
                this.HtmlContainer.method_8(HtmlRenderErrorType.Layout, "Exception in box layout", exception);
            }
        }

        protected virtual void PerformLayoutImp(RGraphics g)
        {
            CssBox box;
            if (base.Display != "none")
            {
                this.method_13();
                this.vmethod_0(g);
            }
            if (((this.IsBlock || (base.Display == "list-item")) || ((base.Display == "table") || (base.Display == "inline-table"))) || (base.Display == "table-cell"))
            {
                if ((base.Display != "table-cell") && (base.Display != "table"))
                {
                    double num2 = (((this.ContainingBlock.Size.Width - this.ContainingBlock.ActualPaddingLeft) - this.ContainingBlock.ActualPaddingRight) - this.ContainingBlock.ActualBorderLeftWidth) - this.ContainingBlock.ActualBorderRightWidth;
                    if (!(!(base.Width != "auto") || string.IsNullOrEmpty(base.Width)))
                    {
                        num2 = Class43.smethod_4(base.Width, num2, this, false);
                    }
                    base.Size = new RSize(num2, base.Size.Height);
                    base.Size = new RSize((num2 - base.ActualMarginLeft) - base.ActualMarginRight, base.Size.Height);
                }
                if (base.Display != "table-cell")
                {
                    box = Class50.smethod_3(this);
                    double x = ((this.ContainingBlock.Location.X + this.ContainingBlock.ActualPaddingLeft) + base.ActualMarginLeft) + this.ContainingBlock.ActualBorderLeftWidth;
                    double y = ((((box != null) || (this.ParentBox == null)) ? ((this.ParentBox == null) ? base.Location.Y : 0.0) : this.ParentBox.ClientTop) + this.MarginTopCollapse(box)) + ((box != null) ? (box.ActualBottom + box.ActualBorderBottomWidth) : 0.0);
                    base.Location = new RPoint(x, y);
                    base.ActualBottom = y;
                }
                if ((base.Display == "table") || (base.Display == "inline-table"))
                {
                    Class29.smethod_1(g, this);
                }
                else if (Class50.smethod_1(this))
                {
                    base.ActualBottom = base.Location.Y;
                    Class28.smethod_1(g, this);
                }
                else if (this.list_1.Count > 0)
                {
                    foreach (CssBox box2 in this.Boxes)
                    {
                        box2.PerformLayout(g);
                    }
                    base.ActualRight = this.method_8();
                    base.ActualBottom = this.method_9();
                }
            }
            else
            {
                box = Class50.smethod_3(this);
                if (box != null)
                {
                    if (base.Location == RPoint.Empty)
                    {
                        base.Location = box.Location;
                    }
                    base.ActualBottom = box.ActualBottom;
                }
            }
            base.ActualBottom = Math.Max(base.ActualBottom, base.Location.Y + base.ActualHeight);
            this.method_1(g);
            double width = Math.Max(this.method_3() + smethod_1(this), (base.Size.Width < 90999.0) ? (base.ActualRight - this.HtmlContainer.Root.Location.X) : 0.0);
            this.HtmlContainer.ActualSize = Class48.smethod_4(this.HtmlContainer.ActualSize, new RSize(width, base.ActualBottom - this.HtmlContainer.Root.Location.Y));
        }

        public IEnumerable<CssBox> Query(Func<CssBox, bool> filter)
        {
            return this.method_16(this, filter);
        }

        public void SetAllBoxes(CssBox fromBox)
        {
            foreach (CssBox box in fromBox.list_1)
            {
                box.cssBox_0 = this;
            }
            this.list_1.AddRange(fromBox.list_1);
            fromBox.list_1.Clear();
        }

        public void SetBeforeBox(CssBox before)
        {
            int index = this.cssBox_0.Boxes.IndexOf(before);
            if (index < 0)
            {
                throw new Exception("before box doesn't exist on parent");
            }
            this.cssBox_0.Boxes.Remove(this);
            this.cssBox_0.Boxes.Insert(index, this);
        }

        public void SetInlineStyle(string style)
        {
            if (this.htmlTag_0 != null)
            {
                HtmlContainerInt htmlContainer;
                string str = this.htmlTag_0.TryGetAttribute("style", null);
                if (!string.IsNullOrEmpty(str))
                {
                    htmlContainer = this.HtmlContainer;
                    if (htmlContainer != null)
                    {
                        CssBlock block2 = htmlContainer.method_1().method_2(this.TagName, str);
                        foreach (KeyValuePair<string, string> pair in htmlContainer.method_1().method_2(this.TagName, style).Properties)
                        {
                            if (block2.Properties.ContainsKey(pair.Key))
                            {
                                block2.Properties[pair.Key] = pair.Value;
                            }
                            else
                            {
                                block2.Properties.Add(pair);
                            }
                        }
                        StringBuilder builder = new StringBuilder();
                        foreach (KeyValuePair<string, string> pair in block2.Properties)
                        {
                            builder.Append(pair.Key + ":" + pair.Value + ";");
                        }
                        this.htmlTag_0.Attributes["style"] = builder.ToString();
                        this._htmlContainer.SetHtml(this._htmlContainer.GetHtml(HtmlGenerationStyle.Inline), null);
                    }
                }
                else
                {
                    if (this.htmlTag_0.Attributes == null)
                    {
                        this.htmlTag_0.Attributes = new Dictionary<string, string>();
                    }
                    this.htmlTag_0.Attributes.Add("style", style);
                    htmlContainer = this.HtmlContainer;
                    if (htmlContainer != null)
                    {
                        CssBlock block = htmlContainer.method_1().method_2(this.TagName, style);
                        this._htmlContainer.SetHtml(this._htmlContainer.GetHtml(HtmlGenerationStyle.Inline), null);
                    }
                }
            }
        }

        private static void smethod_0(CssBox cssBox_2, ref double double_22, ref CssRect cssRect_0)
        {
            if (cssBox_2.Words.Count > 0)
            {
                foreach (CssRect rect in cssBox_2.Words)
                {
                    if (rect.Width > double_22)
                    {
                        double_22 = rect.Width;
                        cssRect_0 = rect;
                    }
                }
            }
            else
            {
                foreach (CssBox box in cssBox_2.Boxes)
                {
                    smethod_0(box, ref double_22, ref cssRect_0);
                }
            }
        }

        private static double smethod_1(object object_0)
        {
            double num = 0.0;
            if ((object_0.Size.Width > 90999.0) || ((object_0.ParentBox != null) && (object_0.ParentBox.Size.Width > 90999.0)))
            {
                while (object_0 != null)
                {
                    num += object_0.ActualMarginLeft + object_0.ActualMarginRight;
                    object_0 = object_0.ParentBox;
                }
            }
            return num;
        }

        private static void smethod_2(object object_0, ref double double_22, ref double double_23, ref double double_24, ref double double_25)
        {
            double? nullable = null;
            if (((object_0.Display != "inline") && (object_0.Display != "table-cell")) && (object_0.WhiteSpace != "nowrap"))
            {
                nullable = new double?(double_23);
                double_23 = double_25;
            }
            double_24 += ((object_0.ActualBorderLeftWidth + object_0.ActualBorderRightWidth) + object_0.ActualPaddingRight) + object_0.ActualPaddingLeft;
            if (object_0.Display == "table")
            {
                double_24 += Class29.smethod_0((CssBox) object_0);
            }
            if (object_0.Words.Count > 0)
            {
                foreach (CssRect rect in object_0.Words)
                {
                    double_23 += rect.FullWidth + (rect.HasSpaceBefore ? rect.OwnerBox.ActualWordSpacing : 0.0);
                    double_22 = Math.Max(double_22, rect.Width);
                }
                if (!((object_0.Words.Count <= 0) || object_0.Words[object_0.Words.Count - 1].HasSpaceAfter))
                {
                    double_23 -= object_0.Words[object_0.Words.Count - 1].ActualWordSpacing;
                }
            }
            else
            {
                for (int i = 0; i < object_0.Boxes.Count; i++)
                {
                    CssBox box = object_0.Boxes[i];
                    double_25 += box.ActualMarginLeft + box.ActualMarginRight;
                    smethod_2(box, ref double_22, ref double_23, ref double_24, ref double_25);
                    double_25 -= box.ActualMarginLeft + box.ActualMarginRight;
                }
            }
            if (nullable.HasValue)
            {
                double_23 = Math.Max(double_23, nullable.Value);
            }
        }

        public override string ToString()
        {
            string str = (this.HtmlTag != null) ? string.Format("<{0}>", this.HtmlTag.Name) : "anon";
            if (this.IsBlock)
            {
                return string.Format("{0}{1} Block {2}, Children:{3}", new object[] { (this.ParentBox == null) ? "Root: " : string.Empty, str, base.FontSize, this.Boxes.Count });
            }
            if (base.Display == "none")
            {
                return string.Format("{0}{1} None", (this.ParentBox == null) ? "Root: " : string.Empty, str);
            }
            return string.Format("{0}{1} {2}: {3}", new object[] { (this.ParentBox == null) ? "Root: " : string.Empty, str, base.Display, this.Text });
        }

        internal virtual void vmethod_0(RGraphics g)
        {
            if (!this._wordsSizeMeasured)
            {
                if ((base.BackgroundImage != "none") && (this.class40_0 == null))
                {
                    this.class40_0 = new Class40(this.HtmlContainer, new Delegate3<RImage, RRect, bool>(this.method_14));
                    this.class40_0.method_1(base.BackgroundImage, (this.HtmlTag != null) ? this.HtmlTag.Attributes : null);
                }
                base.MeasureWordSpacing(g);
                if (this.Words.Count > 0)
                {
                    foreach (CssRect rect in this.Words)
                    {
                        rect.Width = (rect.Text != "\n") ? g.MeasureString(rect.Text, base.ActualFont).Width : 0.0;
                        rect.Height = base.ActualFont.Height;
                    }
                }
                this._wordsSizeMeasured = true;
            }
        }

        public List<CssBox> Boxes
        {
            get
            {
                return this.list_1;
            }
        }

        public CssBox ContainingBlock
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.ParentBox == null)
                {
                    return this;
                }
                CssBox parentBox = this.ParentBox;
                while (true)
                {
                    if (!parentBox.IsBlock && ((!(parentBox.Display != "list-item") || !(parentBox.Display != "table")) || !(parentBox.Display != "table-cell")))
                    {
                    }
                    if (0 == 0)
                    {
                        if (parentBox == null)
                        {
                            throw new Exception("There's no containing block on the chain");
                        }
                        return parentBox;
                    }
                    parentBox = parentBox.ParentBox;
                }
            }
        }

        public CssLineBox FirstHostingLineBox
        {
            get
            {
                return this.cssLineBox_0;
            }
            set
            {
                this.cssLineBox_0 = value;
            }
        }

        public CssRect FirstWord
        {
            get
            {
                return this.Words[0];
            }
        }

        public virtual string HrefLink
        {
            get
            {
                return this.GetAttribute("href");
            }
        }

        public HtmlContainerInt HtmlContainer
        {
            get
            {
                return (this._htmlContainer ?? (this._htmlContainer = (this.cssBox_0 != null) ? this.cssBox_0.HtmlContainer : null));
            }
            set
            {
                this._htmlContainer = value;
            }
        }

        public DSkin.Html.Core.Dom.HtmlTag HtmlTag
        {
            get
            {
                return this.htmlTag_0;
            }
        }

        public string InnerText
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                this.method_15(this, builder);
                return builder.ToString();
            }
        }

        public bool IsBlock
        {
            get
            {
                return (base.Display == "block");
            }
        }

        public bool IsBrElement
        {
            get
            {
                return ((this.htmlTag_0 != null) && this.htmlTag_0.Name.Equals("br", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public virtual bool IsClickable
        {
            get
            {
                return (((this.HtmlTag != null) && (this.HtmlTag.Name == "a")) && !this.HtmlTag.HasAttribute("id"));
            }
        }

        public bool IsImage
        {
            get
            {
                return ((this.Words.Count == 1) && this.Words[0].IsImage);
            }
        }

        public bool IsInline
        {
            get
            {
                return (((base.Display == "inline") || (base.Display == "inline-block")) ? !this.IsBrElement : false);
            }
        }

        public bool IsSpaceOrEmpty
        {
            get
            {
                if (!(((this.Words.Count != 0) || (this.Boxes.Count != 0)) ? ((this.Words.Count == 1) && this.Words[0].IsSpaces) : true))
                {
                    foreach (CssRect rect in this.Words)
                    {
                        if (!rect.IsSpaces)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public CssLineBox LastHostingLineBox
        {
            get
            {
                return this.cssLineBox_1;
            }
            set
            {
                this.cssLineBox_1 = value;
            }
        }

        public List<CssLineBox> LineBoxes
        {
            get
            {
                return this.list_2;
            }
        }

        public CssBox ParentBox
        {
            get
            {
                return this.cssBox_0;
            }
            set
            {
                if (this.cssBox_0 != null)
                {
                    this.cssBox_0.Boxes.Remove(this);
                }
                this.cssBox_0 = value;
                if (value != null)
                {
                    this.cssBox_0.Boxes.Add(this);
                }
            }
        }

        public List<CssLineBox> ParentLineBoxes
        {
            get
            {
                return this.list_3;
            }
        }

        public Dictionary<CssLineBox, RRect> Rectangles
        {
            get
            {
                return this.dictionary_0;
            }
        }

        public string TagName
        {
            get
            {
                return ((this.htmlTag_0 == null) ? string.Empty : this.htmlTag_0.Name);
            }
        }

        public SubString Text
        {
            get
            {
                return this.subString_0;
            }
            set
            {
                this.subString_0 = value;
                this.list_0.Clear();
            }
        }

        public List<CssRect> Words
        {
            get
            {
                return this.list_0;
            }
        }

    }
}

