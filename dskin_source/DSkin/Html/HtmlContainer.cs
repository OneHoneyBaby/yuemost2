namespace DSkin.Html
{
    using DSkin.DirectUI;
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core;
    using DSkin.Html.Core.Dom;
    using DSkin.Html.Core.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class HtmlContainer : IDisposable
    {
        private bool bool_0;
        private readonly HtmlContainerInt htmlContainerInt_0;
        private RControl rcontrol_0;

        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad
        {
            add
            {
                this.htmlContainerInt_0.ImageLoad += value;
            }
            remove
            {
                this.htmlContainerInt_0.ImageLoad -= value;
            }
        }

        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked
        {
            add
            {
                this.htmlContainerInt_0.LinkClicked += value;
            }
            remove
            {
                this.htmlContainerInt_0.LinkClicked -= value;
            }
        }

        public event EventHandler LoadComplete
        {
            add
            {
                this.method_0().LoadComplete += value;
            }
            remove
            {
                this.method_0().LoadComplete -= value;
            }
        }

        public event EventHandler<HtmlRefreshEventArgs> Refresh
        {
            add
            {
                this.htmlContainerInt_0.Refresh += value;
            }
            remove
            {
                this.htmlContainerInt_0.Refresh -= value;
            }
        }

        public event EventHandler<HtmlRenderErrorEventArgs> RenderError
        {
            add
            {
                this.htmlContainerInt_0.RenderError += value;
            }
            remove
            {
                this.htmlContainerInt_0.RenderError -= value;
            }
        }

        public event EventHandler<HtmlScrollEventArgs> ScrollChange
        {
            add
            {
                this.htmlContainerInt_0.ScrollChange += value;
            }
            remove
            {
                this.htmlContainerInt_0.ScrollChange -= value;
            }
        }

        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad
        {
            add
            {
                this.htmlContainerInt_0.StylesheetLoad += value;
            }
            remove
            {
                this.htmlContainerInt_0.StylesheetLoad -= value;
            }
        }

        public HtmlContainer()
        {
            this.htmlContainerInt_0 = new HtmlContainerInt(WinFormsAdapter.Instance);
        }

        public HtmlContainer(object parent)
        {
            if (parent is Control)
            {
                this.rcontrol_0 = new ControlAdapter((Control) parent, this.bool_0);
            }
            else
            {
                this.rcontrol_0 = new DuiControlAdapter((DuiBaseControl) parent, this.bool_0);
            }
            this.htmlContainerInt_0 = new HtmlContainerInt(WinFormsAdapter.Instance, this.rcontrol_0);
        }

        public void ClearSelection()
        {
            this.method_0().ClearSelection();
        }

        public void CopySelectedHtml()
        {
            this.htmlContainerInt_0.SelectionHandler.CopySelectedHtml();
        }

        public void Dispose()
        {
            this.htmlContainerInt_0.Dispose();
        }

        public string GetAttributeAt(Point location, string attribute)
        {
            return this.htmlContainerInt_0.GetAttributeAt(Utils.Convert((PointF) location), attribute);
        }

        public RectangleF? GetElementRectangle(string elementId)
        {
            RRect? elementRectangle = this.htmlContainerInt_0.GetElementRectangle(elementId);
            return (elementRectangle.HasValue ? new RectangleF?(Utils.Convert(elementRectangle.Value)) : null);
        }

        public string GetHtml(HtmlGenerationStyle styleGen = 1)
        {
            return this.htmlContainerInt_0.GetHtml(styleGen);
        }

        public string GetLinkAt(Point location)
        {
            return this.htmlContainerInt_0.GetLinkAt(Utils.Convert((PointF) location));
        }

        public List<LinkElementData<RectangleF>> GetLinks()
        {
            List<LinkElementData<RectangleF>> list = new List<LinkElementData<RectangleF>>();
            foreach (LinkElementData<RRect> data in this.method_0().GetLinks())
            {
                list.Add(new LinkElementData<RectangleF>(data.Id, data.Href, Utils.Convert(data.Rectangle)));
            }
            return list;
        }

        public void HandleKeyDown(KeyEventArgs e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            this.htmlContainerInt_0.HandleKeyDown(smethod_1(e));
        }

        public void HandleMouseDoubleClick(MouseEventArgs e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            this.htmlContainerInt_0.HandleMouseDoubleClick(Utils.Convert((PointF) e.Location), smethod_0(e));
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            this.htmlContainerInt_0.HandleMouseDown(Utils.Convert((PointF) e.Location), smethod_0(e));
        }

        public void HandleMouseEnter()
        {
            this.htmlContainerInt_0.HandleMouseEnter();
        }

        public void HandleMouseLeave()
        {
            this.htmlContainerInt_0.HandleMouseLeave();
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            this.htmlContainerInt_0.HandleMouseMove(Utils.Convert((PointF) e.Location), smethod_0(e));
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            ArgChecker.AssertArgNotNull(e, "e");
            this.htmlContainerInt_0.HandleMouseUp(Utils.Convert((PointF) e.Location), smethod_0(e));
        }

        internal HtmlContainerInt method_0()
        {
            return this.htmlContainerInt_0;
        }

        internal bool method_1()
        {
            return this.bool_0;
        }

        internal void method_2(bool value)
        {
            if (this.bool_0 != value)
            {
                this.bool_0 = value;
                this.htmlContainerInt_0.RequestRefresh(true);
            }
        }

        public void PerformLayout(Graphics g)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            using (GraphicsAdapter adapter = new GraphicsAdapter(g, this.bool_0, false))
            {
                this.htmlContainerInt_0.PerformLayout(adapter);
            }
        }

        public void PerformPaint(Graphics g, Rectangle? rect)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            using (GraphicsAdapter adapter = new GraphicsAdapter(g, this.bool_0, false))
            {
                if (rect.HasValue)
                {
                    adapter.PushClip(new RRect((double) rect.Value.X, (double) rect.Value.Y, (double) rect.Value.Width, (double) rect.Value.Height));
                }
                this.htmlContainerInt_0.PerformPaint(adapter);
            }
        }

        public void SelectAll()
        {
            this.htmlContainerInt_0.SelectionHandler.SelectAll(null);
        }

        public void SetHtml(string htmlSource, DSkin.Html.Core.CssData baseCssData = null)
        {
            this.htmlContainerInt_0.SetHtml(htmlSource, baseCssData);
        }

        private static RMouseEvent smethod_0(MouseEventArgs mouseEventArgs_0)
        {
            return new RMouseEvent(mouseEventArgs_0.Button, mouseEventArgs_0.Clicks, mouseEventArgs_0.X, mouseEventArgs_0.Y, mouseEventArgs_0.Delta, false, null);
        }

        private static RKeyEvent smethod_1(KeyEventArgs keyEventArgs_0)
        {
            return new RKeyEvent(keyEventArgs_0.Control, keyEventArgs_0.KeyCode == Keys.A, keyEventArgs_0.KeyCode == Keys.C);
        }

        public SizeF ActualSize
        {
            get
            {
                return Utils.Convert(this.htmlContainerInt_0.ActualSize);
            }
            internal set
            {
                this.htmlContainerInt_0.ActualSize = Utils.Convert(value);
            }
        }

        public bool AvoidAsyncImagesLoading
        {
            get
            {
                return this.htmlContainerInt_0.AvoidAsyncImagesLoading;
            }
            set
            {
                this.htmlContainerInt_0.AvoidAsyncImagesLoading = value;
            }
        }

        public bool AvoidGeometryAntialias
        {
            get
            {
                return this.htmlContainerInt_0.AvoidGeometryAntialias;
            }
            set
            {
                this.htmlContainerInt_0.AvoidGeometryAntialias = value;
            }
        }

        public bool AvoidImagesLateLoading
        {
            get
            {
                return this.htmlContainerInt_0.AvoidImagesLateLoading;
            }
            set
            {
                this.htmlContainerInt_0.AvoidImagesLateLoading = value;
            }
        }

        public DSkin.Html.Core.CssData CssData
        {
            get
            {
                return this.htmlContainerInt_0.CssData;
            }
        }

        public bool IsContextMenuEnabled
        {
            get
            {
                return this.htmlContainerInt_0.IsContextMenuEnabled;
            }
            set
            {
                this.htmlContainerInt_0.IsContextMenuEnabled = value;
            }
        }

        public bool IsSelectionEnabled
        {
            get
            {
                return this.htmlContainerInt_0.IsSelectionEnabled;
            }
            set
            {
                this.htmlContainerInt_0.IsSelectionEnabled = value;
            }
        }

        public PointF Location
        {
            get
            {
                return Utils.Convert(this.htmlContainerInt_0.Location);
            }
            set
            {
                this.htmlContainerInt_0.Location = Utils.Convert(value);
            }
        }

        public SizeF MaxSize
        {
            get
            {
                return Utils.Convert(this.htmlContainerInt_0.MaxSize);
            }
            set
            {
                this.htmlContainerInt_0.MaxSize = Utils.Convert(value);
            }
        }

        public CssBox Root
        {
            get
            {
                return this.htmlContainerInt_0.Root;
            }
        }

        public Point ScrollOffset
        {
            get
            {
                return Utils.ConvertRound(this.htmlContainerInt_0.ScrollOffset);
            }
            set
            {
                this.htmlContainerInt_0.ScrollOffset = Utils.Convert((PointF) value);
            }
        }

        public string SelectedHtml
        {
            get
            {
                return this.htmlContainerInt_0.SelectedHtml;
            }
        }

        public string SelectedText
        {
            get
            {
                return this.htmlContainerInt_0.SelectedText;
            }
        }
    }
}

