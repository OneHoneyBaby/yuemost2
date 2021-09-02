namespace DSkin.DirectUI
{
    using DSkin.Html;
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core;
    using DSkin.Html.Core.Entities;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiHtmlLabel : DuiBaseControl
    {
        protected bool _autoSizeHight;
        protected CssData _baseCssData;
        protected string _baseRawCssData;
        protected string _text;
        private bool bool_27;
        private DuiScrollBar duiScrollBar_0;
        private DuiScrollBar duiScrollBar_1;
        private DSkin.Html.HtmlContainer htmlContainer_0;
        private int int_1;
        protected TextRenderingHint textRenderMode;

        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad;

        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;

        public event EventHandler LoadComplete;

        public event EventHandler<HtmlRenderErrorEventArgs> RenderError;

        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad;

        public DuiHtmlLabel()
        {
            EventHandler<HtmlScrollEventArgs> handler = null;
            EventHandler handler2 = null;
            EventHandler<InvalidateEventArgs> handler3 = null;
            EventHandler handler4 = null;
            EventHandler<InvalidateEventArgs> handler5 = null;
            this.textRenderMode = TextRenderingHint.SystemDefault;
            this.bool_27 = false;
            DuiScrollBar bar = new DuiScrollBar {
                Orientation = Orientation.Vertical,
                Visible = false,
                DesignModeCanSelect = false
            };
            this.duiScrollBar_0 = bar;
            DuiScrollBar bar2 = new DuiScrollBar {
                Orientation = Orientation.Horizontal,
                Visible = false,
                DesignModeCanSelect = false
            };
            this.duiScrollBar_1 = bar2;
            this.int_1 = 30;
            this.CanFocus = true;
            this.AutoSize = true;
            this.htmlContainer_0 = new DSkin.Html.HtmlContainer(this);
            this.htmlContainer_0.method_2(true);
            this.htmlContainer_0.AvoidImagesLateLoading = true;
            this.htmlContainer_0.LoadComplete += new EventHandler(this.htmlContainer_0_LoadComplete);
            this.htmlContainer_0.LinkClicked += new EventHandler<HtmlLinkClickedEventArgs>(this.method_30);
            this.htmlContainer_0.RenderError += new EventHandler<HtmlRenderErrorEventArgs>(this.method_31);
            this.htmlContainer_0.Refresh += new EventHandler<HtmlRefreshEventArgs>(this.method_34);
            this.htmlContainer_0.StylesheetLoad += new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_32);
            this.htmlContainer_0.ImageLoad += new EventHandler<HtmlImageLoadEventArgs>(this.method_33);
            handler = new EventHandler<HtmlScrollEventArgs>(this.method_35);
            this.htmlContainer_0.ScrollChange += handler;
            this.duiScrollBar_0.Parent = this;
            handler2 = new EventHandler(this.method_36);
            this.duiScrollBar_0.ValueChanged += handler2;
            handler3 = new EventHandler<InvalidateEventArgs>(this.method_37);
            this.duiScrollBar_0.Invalidated += handler3;
            this.duiScrollBar_1.Parent = this;
            handler4 = new EventHandler(this.method_38);
            this.duiScrollBar_1.ValueChanged += handler4;
            handler5 = new EventHandler<InvalidateEventArgs>(this.method_39);
            this.duiScrollBar_1.Invalidated += handler5;
        }

        public void ClearSelection()
        {
            if (this.htmlContainer_0 != null)
            {
                this.htmlContainer_0.ClearSelection();
            }
        }

        public void CopySelectedHtml()
        {
            this.htmlContainer_0.CopySelectedHtml();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.htmlContainer_0 != null)
            {
                this.htmlContainer_0.LoadComplete -= new EventHandler(this.htmlContainer_0_LoadComplete);
                this.htmlContainer_0.LinkClicked -= new EventHandler<HtmlLinkClickedEventArgs>(this.method_30);
                this.htmlContainer_0.RenderError -= new EventHandler<HtmlRenderErrorEventArgs>(this.method_31);
                this.htmlContainer_0.Refresh -= new EventHandler<HtmlRefreshEventArgs>(this.method_34);
                this.htmlContainer_0.StylesheetLoad -= new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_32);
                this.htmlContainer_0.ImageLoad -= new EventHandler<HtmlImageLoadEventArgs>(this.method_33);
                this.htmlContainer_0.Dispose();
                this.htmlContainer_0 = null;
            }
            base.Dispose(disposing);
        }

        public virtual RectangleF? GetElementRectangle(string elementId)
        {
            return ((this.htmlContainer_0 != null) ? this.htmlContainer_0.GetElementRectangle(elementId) : null);
        }

        public virtual string GetHtml()
        {
            return ((this.htmlContainer_0 != null) ? this.htmlContainer_0.GetHtml(HtmlGenerationStyle.Inline) : null);
        }

        private void htmlContainer_0_LoadComplete(object sender, EventArgs e)
        {
            this.OnLoadComplete(e);
        }

        private void method_29()
        {
            int num;
            this.duiScrollBar_0.Visible = ((this.bool_27 && !this.AutoSize) && !this.AutoSizeHeightOnly) && (this.htmlContainer_0.ActualSize.Height > base.Height);
            this.duiScrollBar_1.Visible = (this.bool_27 && !this.AutoSize) && (this.htmlContainer_0.ActualSize.Width > base.Width);
            Point scrollOffset = this.htmlContainer_0.ScrollOffset;
            if (this.duiScrollBar_0.Visible)
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.duiScrollBar_0.Width) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.duiScrollBar_0.Width, (base.Height - this.duiScrollBar_0.Margin.Vertical) - (this.duiScrollBar_1.Visible ? (this.duiScrollBar_1.Height + this.duiScrollBar_1.Margin.Bottom) : 0));
                this.duiScrollBar_0.Maximum = ((int) this.htmlContainer_0.ActualSize.Height) - base.Height;
                num = (int) ((this.duiScrollBar_0.Height - (this.duiScrollBar_0.ArrowHeight * 2)) * ((1.0 * base.Height) / ((double) this.htmlContainer_0.ActualSize.Height)));
                num = (num < 20) ? 20 : num;
                this.duiScrollBar_0.ScrollBarLenght = num;
            }
            else
            {
                scrollOffset.Y = 0;
            }
            if (this.duiScrollBar_1.Visible)
            {
                this.duiScrollBar_1.ClientRectangle = new Rectangle(this.duiScrollBar_1.Margin.Left, (base.Height - this.duiScrollBar_1.Height) - this.duiScrollBar_1.Margin.Bottom, (base.Width - this.duiScrollBar_1.Margin.Horizontal) - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Width + this.duiScrollBar_0.Margin.Right) : 0), this.duiScrollBar_1.Height);
                this.duiScrollBar_1.Maximum = ((int) this.htmlContainer_0.ActualSize.Width) - base.Width;
                num = (int) ((this.duiScrollBar_1.Width - (this.duiScrollBar_1.ArrowHeight * 2)) * ((1.0 * base.Width) / ((double) this.htmlContainer_0.ActualSize.Width)));
                num = (num < 20) ? 20 : num;
                this.duiScrollBar_1.ScrollBarLenght = num;
            }
            else
            {
                scrollOffset.X = 0;
            }
            if ((scrollOffset.X == 0) || (scrollOffset.Y == 0))
            {
                this.htmlContainer_0.ScrollOffset = scrollOffset;
            }
        }

        private void method_30(object sender, HtmlLinkClickedEventArgs e)
        {
            this.OnLinkClicked(e);
        }

        private void method_31(object sender, HtmlRenderErrorEventArgs e)
        {
            this.OnRenderError(e);
        }

        private void method_32(object sender, HtmlStylesheetLoadEventArgs e)
        {
            this.OnStylesheetLoad(e);
        }

        private void method_33(object sender, HtmlImageLoadEventArgs e)
        {
            this.OnImageLoad(e);
        }

        private void method_34(object sender, HtmlRefreshEventArgs e)
        {
            <>c__DisplayClass11 class2;
            base.Invoke(new MethodInvoker(class2.<OnRefresh>b__10));
        }

        [CompilerGenerated]
        private void method_35(object sender, HtmlScrollEventArgs e)
        {
            this.Invalidate();
        }

        [CompilerGenerated]
        private void method_36(object sender, EventArgs e)
        {
            MethodInvoker method = null;
            Control hostControl = this.HostControl;
            if (hostControl != null)
            {
                if (method == null)
                {
                    method = new MethodInvoker(this.method_40);
                }
                hostControl.BeginInvoke(method);
            }
        }

        [CompilerGenerated]
        private void method_37(object sender, InvalidateEventArgs e)
        {
            this.Invalidate();
        }

        [CompilerGenerated]
        private void method_38(object sender, EventArgs e)
        {
            MethodInvoker method = null;
            Control hostControl = this.HostControl;
            if (hostControl != null)
            {
                if (method == null)
                {
                    method = new MethodInvoker(this.method_41);
                }
                hostControl.BeginInvoke(method);
            }
        }

        [CompilerGenerated]
        private void method_39(object sender, InvalidateEventArgs e)
        {
            this.Invalidate();
        }

        [CompilerGenerated]
        private void method_40()
        {
            this.htmlContainer_0.ScrollOffset = new Point(-this.duiScrollBar_1.Value, -this.duiScrollBar_0.Value);
        }

        [CompilerGenerated]
        private void method_41()
        {
            this.htmlContainer_0.ScrollOffset = new Point(-this.duiScrollBar_1.Value, -this.duiScrollBar_0.Value);
        }

        protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
        {
            EventHandler<HtmlImageLoadEventArgs> handler = this.eventHandler_4;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnLayout(EventArgs levent)
        {
            if (this.htmlContainer_0 != null)
            {
                Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                if (g != null)
                {
                    using (g)
                    {
                        using (GraphicsAdapter adapter = new GraphicsAdapter(g, this.htmlContainer_0.method_1(), false))
                        {
                            RSize size = HtmlRendererUtils.Layout(adapter, this.htmlContainer_0.method_0(), new RSize((double) base.Width, (double) base.Height), new RSize(0.0, 0.0), new RSize(0.0, 0.0), this.AutoSize, this.AutoSizeHeightOnly);
                            this.Size = Utils.ConvertRound(new RSize(size.Width, size.Height));
                        }
                    }
                    this.method_29();
                }
            }
            base.OnLayout(levent);
        }

        protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
        {
            EventHandler<HtmlLinkClickedEventArgs> handler = this.eventHandler_1;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLoadComplete(EventArgs e)
        {
            EventHandler handler = this.eventHandler_0;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnMouseDoubleClick(DuiMouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseDoubleClick(e);
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseDown(e);
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.htmlContainer_0 != null)
            {
                this.htmlContainer_0.HandleMouseEnter();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.htmlContainer_0 != null)
            {
                this.htmlContainer_0.HandleMouseLeave();
            }
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseMove(e);
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseUp(e);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.duiScrollBar_0.Visible)
            {
                this.duiScrollBar_0.Value += (e.Delta > 0) ? -this.int_1 : this.int_1;
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            base.OnPrePaint(e);
            if (this.htmlContainer_0 != null)
            {
                e.Graphics.TextRenderingHint = this.textRenderMode;
                this.htmlContainer_0.Location = new PointF(0f, 0f);
                this.htmlContainer_0.PerformPaint(e.Graphics, new Rectangle?(e.ClipRectangle));
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Control && (e.KeyCode == Keys.C))
            {
                this.CopySelectedHtml();
            }
        }

        protected virtual void OnRefresh(HtmlRefreshEventArgs e)
        {
            if (e.Layout)
            {
                base.PerformLayout();
            }
            this.Invalidate();
        }

        protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
        {
            EventHandler<HtmlRenderErrorEventArgs> handler = this.eventHandler_2;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
        {
            EventHandler<HtmlStylesheetLoadEventArgs> handler = this.eventHandler_3;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SelectAll()
        {
            this.htmlContainer_0.SelectAll();
            this.Invalidate();
        }

        [Description("自适应内容大小"), Browsable(true), DefaultValue(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (value)
                {
                    this._autoSizeHight = false;
                    base.PerformLayout();
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(false), Description("根据内容自动设置标签的高度 (不影响宽度)。"), Category("Layout")]
        public virtual bool AutoSizeHeightOnly
        {
            get
            {
                return this._autoSizeHight;
            }
            set
            {
                this._autoSizeHight = value;
                if (value)
                {
                    this.AutoSize = false;
                    base.PerformLayout();
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(false), Category("Behavior"), Description("获取或设置一个值，该值指示是否抗锯齿比如背景和边框 (默认值为 false)。")]
        public virtual bool AvoidGeometryAntialias
        {
            get
            {
                return this.htmlContainer_0.AvoidGeometryAntialias;
            }
            set
            {
                this.htmlContainer_0.AvoidGeometryAntialias = value;
            }
        }

        [Category("Appearance"), Description("设置基本样式"), Editor("System.ComponentModel.Design.MultilineStringEditor", "System.Drawing.Design.UITypeEditor"), Browsable(true)]
        public virtual string BaseStylesheet
        {
            get
            {
                return this._baseRawCssData;
            }
            set
            {
                this._baseRawCssData = value;
                this._baseCssData = HtmlRender.ParseStyleSheet(value, true);
                this.htmlContainer_0.SetHtml(this._text, this._baseCssData);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                return this.duiScrollBar_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return this.duiScrollBar_1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DSkin.Html.HtmlContainer HtmlContainer
        {
            get
            {
                return this.htmlContainer_0;
            }
        }

        [Browsable(true), Description("是否启用内置右键菜单"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(true), Category("Behavior")]
        public virtual bool IsContextMenuEnabled
        {
            get
            {
                return this.htmlContainer_0.IsContextMenuEnabled;
            }
            set
            {
                this.htmlContainer_0.IsContextMenuEnabled = value;
            }
        }

        [DefaultValue(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Behavior"), Description("是否启用内容选择 (默认值为 true)。"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public virtual bool IsSelectionEnabled
        {
            get
            {
                return this.htmlContainer_0.IsSelectionEnabled;
            }
            set
            {
                this.htmlContainer_0.IsSelectionEnabled = value;
            }
        }

        [DefaultValue(30), Description("鼠标滚轮滚动页面大小")]
        public int ScrollSize
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        [Browsable(false)]
        public virtual string SelectedHtml
        {
            get
            {
                return this.htmlContainer_0.SelectedHtml;
            }
        }

        [Browsable(false)]
        public virtual string SelectedText
        {
            get
            {
                return this.htmlContainer_0.SelectedText;
            }
        }

        [Description("是否显示滚动条"), DefaultValue(false)]
        public bool ShowScrollBar
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                if (this.bool_27 != value)
                {
                    this.bool_27 = value;
                    this.method_29();
                }
            }
        }

        [Description("HTML内容")]
        public override string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                base.Text = value;
                if (!base.IsDisposed)
                {
                    this.htmlContainer_0.SetHtml(this._text, this._baseCssData);
                    base.PerformLayout();
                    this.Invalidate();
                }
            }
        }

        [Category("外观"), DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Description("文本渲染模式")]
        public virtual TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderMode;
            }
            set
            {
                if (this.textRenderMode != value)
                {
                    this.textRenderMode = value;
                    this.Invalidate();
                }
            }
        }
    }
}

