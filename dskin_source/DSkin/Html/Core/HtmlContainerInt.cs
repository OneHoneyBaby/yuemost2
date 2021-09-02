namespace DSkin.Html.Core
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Dom;
    using DSkin.Html.Core.Entities;
    using DSkin.Html.Core.Handlers;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public sealed class HtmlContainerInt : IDisposable
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private bool bool_4;
        private bool bool_5;
        private Class38 class38_0;
        private readonly Class42 class42_0;
        private CssBox cssBox_0;
        private DSkin.Html.Core.CssData cssData_0;
        private List<Class33> list_0;
        private DSkin.Html.Core.Handlers.SelectionHandler MyowpNrEap;
        private readonly RAdapter radapter_0;
        private RColor rcolor_0;
        private RColor rcolor_1;
        private RControl rcontrol_0;
        private RPoint rpoint_0;
        private RPoint rpoint_1;
        private RSize rsize_0;
        private RSize rsize_1;

        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad;

        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;

        public event EventHandler LoadComplete;

        public event EventHandler<HtmlRefreshEventArgs> Refresh;

        public event EventHandler<HtmlRenderErrorEventArgs> RenderError;

        public event EventHandler<HtmlScrollEventArgs> ScrollChange;

        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad;

        public HtmlContainerInt(RAdapter adapter)
        {
            this.bool_0 = true;
            this.bool_1 = true;
            ArgChecker.AssertArgNotNull(adapter, "global");
            this.radapter_0 = adapter;
            this.class42_0 = new Class42(adapter);
        }

        public HtmlContainerInt(RAdapter adapter, RControl control)
        {
            this.bool_0 = true;
            this.bool_1 = true;
            ArgChecker.AssertArgNotNull(adapter, "global");
            this.rcontrol_0 = control;
            this.radapter_0 = adapter;
            this.class42_0 = new Class42(adapter);
        }

        public void Clear()
        {
            if (this.cssBox_0 != null)
            {
                this.cssBox_0.Dispose();
                this.cssBox_0 = null;
                if (this.MyowpNrEap != null)
                {
                    this.MyowpNrEap.Dispose();
                }
                this.MyowpNrEap = null;
                if (this.class38_0 != null)
                {
                    this.class38_0.Dispose();
                }
                this.class38_0 = null;
                this.list_0 = null;
            }
        }

        public void ClearSelection()
        {
            if (this.MyowpNrEap != null)
            {
                this.MyowpNrEap.ClearSelection();
                this.RequestRefresh(false);
            }
        }

        public void Dispose()
        {
            this.method_14(true);
        }

        public string GetAttributeAt(RPoint location, string attribute)
        {
            ArgChecker.AssertArgNotNullOrEmpty(attribute, "attribute");
            CssBox box = Class50.smethod_8(this.cssBox_0, this.method_12(location), true);
            return ((box != null) ? Class50.smethod_7(box, attribute) : null);
        }

        public RRect? GetElementRectangle(string elementId)
        {
            ArgChecker.AssertArgNotNullOrEmpty(elementId, "elementId");
            CssBox box = Class50.smethod_11(this.cssBox_0, elementId.ToLower());
            return ((box != null) ? new RRect?(Class48.smethod_6<CssLineBox, RRect>(box.Rectangles, box.Bounds)) : null);
        }

        public string GetHtml(HtmlGenerationStyle styleGen = 1)
        {
            return Class50.smethod_17(this.cssBox_0, styleGen, false);
        }

        public string GetLinkAt(RPoint location)
        {
            CssBox box = Class50.smethod_10(this.cssBox_0, this.method_12(location));
            return ((box != null) ? box.HrefLink : null);
        }

        public List<LinkElementData<RRect>> GetLinks()
        {
            List<CssBox> list = new List<CssBox>();
            Class50.smethod_9(this.cssBox_0, list);
            List<LinkElementData<RRect>> list2 = new List<LinkElementData<RRect>>();
            foreach (CssBox box in list)
            {
                list2.Add(new LinkElementData<RRect>(box.GetAttribute("id"), box.GetAttribute("href"), Class48.smethod_6<CssLineBox, RRect>(box.Rectangles, box.Bounds)));
            }
            return list2;
        }

        public void HandleKeyDown(RKeyEvent e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            try
            {
                if (e.Control && (this.MyowpNrEap != null))
                {
                    if (e.AKeyCode)
                    {
                        this.MyowpNrEap.SelectAll(this.rcontrol_0);
                    }
                    if (e.CKeyCode)
                    {
                        this.MyowpNrEap.CopySelectedHtml();
                    }
                }
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed key down handle", exception);
            }
        }

        public void HandleMouseDoubleClick(RPoint location, RMouseEvent e)
        {
            try
            {
                if ((this.MyowpNrEap != null) && this.method_13(location))
                {
                    this.MyowpNrEap.SelectWord(this.rcontrol_0, this.method_12(location));
                }
                RPoint point = this.method_12(location);
                this.Root.method_19(new RMouseEvent(e.Button, e.Clicks, (int) point.X, (int) point.Y, e.Delta, false, this.Root));
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse double click handle", exception);
            }
        }

        public void HandleMouseDown(RPoint location, RMouseEvent e)
        {
            try
            {
                if (this.MyowpNrEap != null)
                {
                    this.MyowpNrEap.HandleMouseDown(this.rcontrol_0, this.method_12(location), this.method_13(location));
                }
                RPoint point = this.method_12(location);
                this.Root.method_18(new RMouseEvent(e.Button, e.Clicks, (int) point.X, (int) point.Y, e.Delta, false, this.Root));
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse down handle", exception);
            }
        }

        public void HandleMouseEnter()
        {
            try
            {
                this.Root.method_22(EventArgs.Empty);
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse enter handle", exception);
            }
        }

        public void HandleMouseLeave()
        {
            try
            {
                if (this.MyowpNrEap != null)
                {
                    this.MyowpNrEap.HandleMouseLeave(this.rcontrol_0);
                }
                this.Root.method_23(EventArgs.Empty);
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse leave handle", exception);
            }
        }

        public void HandleMouseMove(RPoint location, RMouseEvent e)
        {
            try
            {
                RPoint loc = this.method_12(location);
                if ((this.MyowpNrEap != null) && this.method_13(location))
                {
                    this.MyowpNrEap.HandleMouseMove(this.rcontrol_0, loc);
                }
                this.Root.method_20(new RMouseEvent(e.Button, e.Clicks, (int) loc.X, (int) loc.Y, e.Delta, false, this.Root));
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse move handle", exception);
            }
        }

        public void HandleMouseUp(RPoint location, RMouseEvent e)
        {
            try
            {
                if (((this.MyowpNrEap != null) && this.method_13(location)) && !(this.MyowpNrEap.HandleMouseUp(this.rcontrol_0, e.LeftButton) || !e.LeftButton))
                {
                    RPoint point = this.method_12(location);
                    CssBox box = Class50.smethod_10(this.cssBox_0, point);
                    if (box != null)
                    {
                        this.method_9(location, box);
                    }
                }
                RPoint point2 = this.method_12(location);
                this.Root.method_17(new RMouseEvent(e.Button, e.Clicks, (int) point2.X, (int) point2.Y, e.Delta, false, this.Root));
            }
            catch (HtmlLinkClickedException)
            {
                throw;
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.KeyboardMouse, "Failed mouse up handle", exception);
            }
        }

        internal RAdapter method_0()
        {
            return this.radapter_0;
        }

        internal Class42 method_1()
        {
            return this.class42_0;
        }

        internal void method_10(CssBox cssBox_1, CssBlock cssBlock_0)
        {
            ArgChecker.AssertArgNotNull(cssBox_1, "box");
            ArgChecker.AssertArgNotNull(cssBlock_0, "block");
            if (this.list_0 == null)
            {
                this.list_0 = new List<Class33>();
            }
            this.list_0.Add(new Class33(cssBox_1, cssBlock_0));
        }

        internal Class38 method_11()
        {
            return this.class38_0;
        }

        private RPoint method_12(RPoint rpoint_2)
        {
            return new RPoint(rpoint_2.X - this.ScrollOffset.X, rpoint_2.Y - this.ScrollOffset.Y);
        }

        private bool method_13(RPoint rpoint_2)
        {
            return ((((rpoint_2.X >= this.rpoint_0.X) && (rpoint_2.X <= (this.rpoint_0.X + this.rsize_1.Width))) && (rpoint_2.Y >= (this.rpoint_0.Y + this.ScrollOffset.Y))) && (rpoint_2.Y <= ((this.rpoint_0.Y + this.ScrollOffset.Y) + this.rsize_1.Height)));
        }

        private void method_14(bool bool_6)
        {
            try
            {
                if (bool_6)
                {
                    this.eventHandler_1 = null;
                    this.eventHandler_2 = null;
                    this.eventHandler_4 = null;
                    this.eventHandler_5 = null;
                    this.eventHandler_6 = null;
                }
                this.cssData_0 = null;
                if (this.cssBox_0 != null)
                {
                    this.cssBox_0.Dispose();
                }
                this.cssBox_0 = null;
                if (this.MyowpNrEap != null)
                {
                    this.MyowpNrEap.Dispose();
                }
                this.MyowpNrEap = null;
            }
            catch
            {
            }
        }

        internal RColor method_2()
        {
            return this.rcolor_0;
        }

        internal void method_3(RColor value)
        {
            this.rcolor_0 = value;
        }

        internal RColor method_4()
        {
            return this.rcolor_1;
        }

        internal void method_5(RColor value)
        {
            this.rcolor_1 = value;
        }

        internal void method_6(HtmlStylesheetLoadEventArgs htmlStylesheetLoadEventArgs_0)
        {
            try
            {
                EventHandler<HtmlStylesheetLoadEventArgs> handler = this.eventHandler_5;
                if (handler != null)
                {
                    handler(this, htmlStylesheetLoadEventArgs_0);
                }
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.CssParsing, "Failed stylesheet load event", exception);
            }
        }

        internal void method_7(HtmlImageLoadEventArgs htmlImageLoadEventArgs_0)
        {
            try
            {
                EventHandler<HtmlImageLoadEventArgs> handler = this.eventHandler_6;
                if (handler != null)
                {
                    handler(this, htmlImageLoadEventArgs_0);
                }
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.Image, "Failed image load event", exception);
            }
        }

        internal void method_8(HtmlRenderErrorType htmlRenderErrorType_0, string string_0, Exception exception_0 = null)
        {
            try
            {
                EventHandler<HtmlRenderErrorEventArgs> handler = this.eventHandler_4;
                if (handler != null)
                {
                    handler(this, new HtmlRenderErrorEventArgs(htmlRenderErrorType_0, string_0, exception_0));
                }
            }
            catch
            {
            }
        }

        internal void method_9(RPoint rpoint_2, CssBox cssBox_1)
        {
            EventHandler<HtmlLinkClickedEventArgs> handler = this.eventHandler_1;
            if (handler != null)
            {
                HtmlLinkClickedEventArgs e = new HtmlLinkClickedEventArgs(cssBox_1.HrefLink, cssBox_1.HtmlTag.Attributes);
                try
                {
                    handler(this, e);
                }
                catch (Exception exception)
                {
                    throw new HtmlLinkClickedException("Error in link clicked intercept", exception);
                }
                if (e.Handled)
                {
                    return;
                }
            }
            if (!string.IsNullOrEmpty(cssBox_1.HrefLink))
            {
                if (cssBox_1.HrefLink.StartsWith("#") && (cssBox_1.HrefLink.Length > 1))
                {
                    EventHandler<HtmlScrollEventArgs> handler2 = this.eventHandler_3;
                    if (handler2 != null)
                    {
                        RRect? elementRectangle = this.GetElementRectangle(cssBox_1.HrefLink.Substring(1));
                        if (elementRectangle.HasValue)
                        {
                            handler2(this, new HtmlScrollEventArgs(elementRectangle.Value.Location));
                            this.HandleMouseMove(rpoint_2, new RMouseEvent(MouseButtons.Left, 1, (int) rpoint_2.X, (int) rpoint_2.Y, 0, false, this.Root));
                        }
                    }
                }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(cssBox_1.HrefLink) {
                        UseShellExecute = true
                    };
                    Process.Start(startInfo);
                }
            }
        }

        public void PerformLayout(RGraphics g)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            this.rsize_1 = RSize.Empty;
            if (this.cssBox_0 != null)
            {
                this.cssBox_0.Size = new RSize((this.rsize_0.Width > 0.0) ? this.rsize_0.Width : 99999.0, 0.0);
                this.cssBox_0.Location = this.rpoint_0;
                this.cssBox_0.PerformLayout(g);
                if (this.rsize_0.Width <= 0.1)
                {
                    this.cssBox_0.Size = new RSize((double) ((int) Math.Ceiling(this.rsize_1.Width)), 0.0);
                    this.rsize_1 = RSize.Empty;
                    this.cssBox_0.PerformLayout(g);
                }
                if (!this.bool_5)
                {
                    this.bool_5 = true;
                    EventHandler handler = this.eventHandler_0;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void PerformPaint(RGraphics g)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            bool flag = false;
            if ((this.MaxSize.Height > 0.0) && (this.MaxSize.Width > 0.0))
            {
                flag = true;
            }
            if (this.cssBox_0 != null)
            {
                this.cssBox_0.Paint(g);
            }
            if (flag)
            {
                g.PopClip();
            }
        }

        public void RequestRefresh(bool layout)
        {
            try
            {
                EventHandler<HtmlRefreshEventArgs> handler = this.eventHandler_2;
                if (handler != null)
                {
                    handler(this, new HtmlRefreshEventArgs(layout));
                }
            }
            catch (Exception exception)
            {
                this.method_8(HtmlRenderErrorType.General, "Failed refresh request", exception);
            }
        }

        public void SetHtml(string htmlSource, DSkin.Html.Core.CssData baseCssData = null)
        {
            this.Clear();
            if (!string.IsNullOrEmpty(htmlSource))
            {
                this.bool_5 = false;
                this.cssData_0 = baseCssData ?? this.radapter_0.DefaultCssData;
                this.cssBox_0 = new Class44(this.class42_0).method_0(htmlSource, this, ref this.cssData_0);
                if (this.cssBox_0 != null)
                {
                    this.MyowpNrEap = new DSkin.Html.Core.Handlers.SelectionHandler(this.cssBox_0);
                    this.class38_0 = new Class38();
                }
            }
        }

        public RSize ActualSize
        {
            get
            {
                return this.rsize_1;
            }
            set
            {
                this.rsize_1 = value;
            }
        }

        public bool AvoidAsyncImagesLoading
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        public bool AvoidGeometryAntialias
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        public bool AvoidImagesLateLoading
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
            }
        }

        public RControl Control
        {
            get
            {
                return this.rcontrol_0;
            }
            set
            {
                this.rcontrol_0 = value;
            }
        }

        public DSkin.Html.Core.CssData CssData
        {
            get
            {
                return this.cssData_0;
            }
        }

        public bool IsContextMenuEnabled
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public bool IsSelectionEnabled
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public RPoint Location
        {
            get
            {
                return this.rpoint_0;
            }
            set
            {
                this.rpoint_0 = value;
            }
        }

        public RSize MaxSize
        {
            get
            {
                return this.rsize_0;
            }
            set
            {
                this.rsize_0 = value;
            }
        }

        public CssBox Root
        {
            get
            {
                return this.cssBox_0;
            }
        }

        public RPoint ScrollOffset
        {
            get
            {
                return this.rpoint_1;
            }
            set
            {
                this.rpoint_1 = value;
            }
        }

        public string SelectedHtml
        {
            get
            {
                return this.MyowpNrEap.GetSelectedHtml();
            }
        }

        public string SelectedText
        {
            get
            {
                return this.MyowpNrEap.GetSelectedText();
            }
        }

        public DSkin.Html.Core.Handlers.SelectionHandler SelectionHandler
        {
            get
            {
                return this.MyowpNrEap;
            }
        }
    }
}

