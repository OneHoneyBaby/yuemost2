namespace DSkin.Html.Core.Handlers
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Dom;
    using DSkin.Html.Core.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Runtime.InteropServices;

    public sealed class SelectionHandler : IDisposable
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private bool bool_4;
        private bool bool_5;
        private readonly Class36 class36_0;
        private readonly CssBox cssBox_0;
        private CssRect cssRect_0;
        private CssRect cssRect_1;
        private DateTime dateTime_0;
        private double double_0 = -1.0;
        private double double_1 = -1.0;
        private int int_0 = -1;
        private int int_1 = -1;
        private object object_0;
        private RPoint rpoint_0;

        public SelectionHandler(CssBox root)
        {
            ArgChecker.AssertArgNotNull(root, "root");
            this.cssBox_0 = root;
            this.class36_0 = new Class36(this, root.HtmlContainer);
        }

        public void ClearSelection()
        {
            this.object_0 = null;
            smethod_0(this.cssBox_0);
            this.double_0 = -1.0;
            this.int_0 = -1;
            this.double_1 = -1.0;
            this.int_1 = -1;
            this.rpoint_0 = RPoint.Empty;
            this.cssRect_0 = null;
            this.cssRect_1 = null;
        }

        public void CopySelectedHtml()
        {
            if (this.cssBox_0.HtmlContainer.IsSelectionEnabled)
            {
                string html = Class50.smethod_17(this.cssBox_0, HtmlGenerationStyle.Inline, true);
                string str2 = Class50.smethod_16(this.cssBox_0);
                if (!string.IsNullOrEmpty(str2))
                {
                    this.cssBox_0.HtmlContainer.method_0().SetToClipboard(html, str2);
                }
            }
        }

        public void Dispose()
        {
            this.class36_0.Dispose();
        }

        public int GetSelectedEndIndexOffset(CssRect word)
        {
            return ((word == (this.bool_0 ? this.cssRect_0 : this.cssRect_1)) ? (this.bool_0 ? this.int_0 : this.int_1) : -1);
        }

        public double GetSelectedEndOffset(CssRect word)
        {
            return ((word == (this.bool_0 ? this.cssRect_0 : this.cssRect_1)) ? (this.bool_0 ? this.double_0 : this.double_1) : -1.0);
        }

        public string GetSelectedHtml()
        {
            return (this.cssBox_0.HtmlContainer.IsSelectionEnabled ? Class50.smethod_17(this.cssBox_0, HtmlGenerationStyle.Inline, true) : null);
        }

        public double GetSelectedStartOffset(CssRect word)
        {
            return ((word == (this.bool_0 ? this.cssRect_1 : this.cssRect_0)) ? (this.bool_0 ? this.double_1 : this.double_0) : -1.0);
        }

        public string GetSelectedText()
        {
            return (this.cssBox_0.HtmlContainer.IsSelectionEnabled ? Class50.smethod_16(this.cssBox_0) : null);
        }

        public int GetSelectingStartIndex(CssRect word)
        {
            return ((word == (this.bool_0 ? this.cssRect_1 : this.cssRect_0)) ? (this.bool_0 ? this.int_1 : this.int_0) : -1);
        }

        public void HandleMouseDown(RControl parent, RPoint loc, bool isMouseInContainer)
        {
            bool flag = !isMouseInContainer;
            if (isMouseInContainer)
            {
                this.bool_3 = true;
                TimeSpan span = (TimeSpan) (DateTime.Now - this.dateTime_0);
                this.bool_2 = span.TotalMilliseconds < 400.0;
                this.dateTime_0 = DateTime.Now;
                this.bool_4 = false;
                if (this.cssBox_0.HtmlContainer.IsSelectionEnabled && parent.LeftMouseButton)
                {
                    CssRect rect2 = Class50.smethod_13(this.cssBox_0, loc);
                    if ((rect2 != null) && rect2.Selected)
                    {
                        this.bool_4 = true;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (parent.RightMouseButton)
                {
                    CssRect rect = Class50.smethod_13(this.cssBox_0, loc);
                    CssBox box = Class50.smethod_10(this.cssBox_0, loc);
                    if (this.cssBox_0.HtmlContainer.IsContextMenuEnabled)
                    {
                        this.class36_0.method_0(parent, rect, box);
                    }
                    flag = (rect == null) || !rect.Selected;
                }
            }
            if (flag)
            {
                this.ClearSelection();
                parent.Invalidate();
            }
        }

        public void HandleMouseLeave(RControl parent)
        {
            if (this.bool_5)
            {
                this.bool_5 = false;
                parent.SetCursorDefault();
            }
        }

        public void HandleMouseMove(RControl parent, RPoint loc)
        {
            if ((this.cssBox_0.HtmlContainer.IsSelectionEnabled && this.bool_3) && parent.LeftMouseButton)
            {
                if (this.bool_4)
                {
                    TimeSpan span = (TimeSpan) (DateTime.Now - this.dateTime_0);
                    if (span.TotalMilliseconds > 200.0)
                    {
                        this.method_1(parent);
                    }
                }
                else
                {
                    this.method_0(parent, loc, !this.bool_2);
                    this.bool_1 = ((this.cssRect_0 != null) && (this.cssRect_1 != null)) && ((this.cssRect_0 != this.cssRect_1) || (this.int_0 != this.int_1));
                }
            }
            else if (Class50.smethod_10(this.cssBox_0, loc) != null)
            {
                this.bool_5 = true;
                parent.SetCursorHand();
            }
            else if (this.cssBox_0.HtmlContainer.IsSelectionEnabled)
            {
                CssRect rect = Class50.smethod_13(this.cssBox_0, loc);
                this.bool_5 = ((rect != null) && !rect.IsImage) && ((!rect.Selected || ((rect.SelectedStartIndex >= 0) && ((rect.Left + rect.SelectedStartOffset) > loc.X))) || ((rect.SelectedEndOffset >= 0.0) && ((rect.Left + rect.SelectedEndOffset) < loc.X)));
                if (this.bool_5)
                {
                    parent.SetCursorIBeam();
                }
                else
                {
                    parent.SetCursorDefault();
                }
            }
            else if (this.bool_5)
            {
                parent.SetCursorDefault();
            }
        }

        public bool HandleMouseUp(RControl parent, bool leftMouseButton)
        {
            bool flag = false;
            this.bool_3 = false;
            if (this.cssBox_0.HtmlContainer.IsSelectionEnabled)
            {
                flag = this.bool_1;
                if ((!this.bool_1 && leftMouseButton) && this.bool_4)
                {
                    this.ClearSelection();
                    parent.Invalidate();
                }
                this.bool_4 = false;
                this.bool_1 = false;
            }
            return (flag = flag || ((DateTime.Now - this.dateTime_0) > TimeSpan.FromSeconds(1.0)));
        }

        private void method_0(RControl rcontrol_0, RPoint rpoint_1, bool bool_6)
        {
            CssLineBox box = Class50.smethod_12(this.cssBox_0, rpoint_1);
            if (box != null)
            {
                CssRect rect = Class50.smethod_14(box, rpoint_1);
                if ((rect == null) && (box.Words.Count > 0))
                {
                    if (rpoint_1.Y > box.LineBottom)
                    {
                        rect = box.Words[box.Words.Count - 1];
                    }
                    else if (rpoint_1.X < box.Words[0].Left)
                    {
                        rect = box.Words[0];
                    }
                    else if (rpoint_1.X > box.Words[box.Words.Count - 1].Right)
                    {
                        rect = box.Words[box.Words.Count - 1];
                    }
                }
                if (rect != null)
                {
                    if (this.cssRect_0 == null)
                    {
                        this.rpoint_0 = rpoint_1;
                        this.cssRect_0 = rect;
                        if (bool_6)
                        {
                            this.method_5(rcontrol_0, rect, rpoint_1, true);
                        }
                    }
                    this.cssRect_1 = rect;
                    if (bool_6)
                    {
                        this.method_5(rcontrol_0, rect, rpoint_1, false);
                    }
                    smethod_0(this.cssBox_0);
                    if (this.method_2(rpoint_1, bool_6))
                    {
                        this.method_6();
                        this.method_3(this.cssBox_0, this.bool_0 ? this.cssRect_1 : this.cssRect_0, this.bool_0 ? this.cssRect_0 : this.cssRect_1);
                    }
                    else
                    {
                        this.cssRect_1 = null;
                    }
                    this.bool_5 = true;
                    rcontrol_0.SetCursorIBeam();
                    rcontrol_0.Invalidate();
                }
            }
        }

        private void method_1(RControl rcontrol_0)
        {
            if (this.object_0 == null)
            {
                string html = Class50.smethod_17(this.cssBox_0, HtmlGenerationStyle.Inline, true);
                string plainText = Class50.smethod_16(this.cssBox_0);
                this.object_0 = rcontrol_0.Adapter.GetClipboardDataObject(html, plainText);
            }
            rcontrol_0.DoDragDropCopy(this.object_0);
        }

        private bool method_2(RPoint rpoint_1, bool bool_6)
        {
            if (!bool_6)
            {
                return true;
            }
            if ((Math.Abs((double) (this.rpoint_0.X - rpoint_1.X)) <= 1.0) && (Math.Abs((double) (this.rpoint_0.Y - rpoint_1.Y)) < 5.0))
            {
                return false;
            }
            return ((this.cssRect_0 != this.cssRect_1) || (this.int_0 != this.int_1));
        }

        private void method_3(CssBox cssBox_1, CssRect cssRect_2, CssRect cssRect_3)
        {
            bool flag = false;
            this.method_4(cssBox_1, cssRect_2, cssRect_3, ref flag);
        }

        private bool method_4(CssBox cssBox_1, CssRect cssRect_2, CssRect cssRect_3, ref bool bool_6)
        {
            foreach (CssRect rect in cssBox_1.Words)
            {
                if (!(bool_6 || (rect != cssRect_2)))
                {
                    bool_6 = true;
                }
                if (bool_6)
                {
                    rect.Selection = this;
                    if ((cssRect_2 == cssRect_3) || (rect == cssRect_3))
                    {
                        return true;
                    }
                }
            }
            foreach (CssBox box in cssBox_1.Boxes)
            {
                if (this.method_4(box, cssRect_2, cssRect_3, ref bool_6))
                {
                    return true;
                }
            }
            return false;
        }

        private void method_5(RControl rcontrol_0, CssRect cssRect_2, RPoint rpoint_1, bool bool_6)
        {
            int num;
            double num2;
            smethod_1(rcontrol_0, cssRect_2, rpoint_1, bool_6, out num, out num2);
            if (bool_6)
            {
                this.int_0 = num;
                this.double_0 = num2;
            }
            else
            {
                this.int_1 = num;
                this.double_1 = num2;
            }
        }

        private void method_6()
        {
            if (this.cssRect_0 == this.cssRect_1)
            {
                this.bool_0 = this.int_0 > this.int_1;
            }
            else if (Class50.smethod_15(this.cssRect_0) == Class50.smethod_15(this.cssRect_1))
            {
                this.bool_0 = this.cssRect_0.Left > this.cssRect_1.Left;
            }
            else
            {
                this.bool_0 = this.cssRect_0.Top >= this.cssRect_1.Bottom;
            }
        }

        public void SelectAll(RControl control)
        {
            if (this.cssBox_0.HtmlContainer.IsSelectionEnabled)
            {
                this.ClearSelection();
                this.SelectAllWords(this.cssBox_0);
                if (control != null)
                {
                    control.Invalidate();
                }
            }
        }

        public void SelectAllWords(CssBox box)
        {
            foreach (CssRect rect in box.Words)
            {
                rect.Selection = this;
            }
            foreach (CssBox box2 in box.Boxes)
            {
                this.SelectAllWords(box2);
            }
        }

        public void SelectWord(RControl control, RPoint loc)
        {
            if (this.cssBox_0.HtmlContainer.IsSelectionEnabled)
            {
                CssRect rect = Class50.smethod_13(this.cssBox_0, loc);
                if (rect != null)
                {
                    rect.Selection = this;
                    this.rpoint_0 = loc;
                    this.cssRect_0 = this.cssRect_1 = rect;
                    control.Invalidate();
                }
            }
        }

        private static void smethod_0(CssBox cssBox_1)
        {
            foreach (CssRect rect in cssBox_1.Words)
            {
                rect.Selection = null;
            }
            foreach (CssBox box in cssBox_1.Boxes)
            {
                smethod_0(box);
            }
        }

        private static void smethod_1(RControl rcontrol_0, CssRect cssRect_2, RPoint rpoint_1, bool bool_6, out int int_2, out double double_2)
        {
            int_2 = 0;
            double_2 = 0.0;
            double num = rpoint_1.X - cssRect_2.Left;
            if (cssRect_2.Text == null)
            {
                int_2 = -1;
                double_2 = -1.0;
            }
            else if ((num > (cssRect_2.Width - cssRect_2.OwnerBox.ActualWordSpacing)) || (rpoint_1.Y > Class50.smethod_15(cssRect_2).LineBottom))
            {
                int_2 = cssRect_2.Text.Length;
                double_2 = cssRect_2.Width;
            }
            else if (num > 0.0)
            {
                int num3;
                double num4;
                double maxWidth = num + (bool_6 ? 0.0 : (1.5 * cssRect_2.method_0()));
                rcontrol_0.MeasureString(cssRect_2.Text, cssRect_2.OwnerBox.ActualFont, maxWidth, out num3, out num4);
                int_2 = num3;
                double_2 = num4;
            }
        }
    }
}

