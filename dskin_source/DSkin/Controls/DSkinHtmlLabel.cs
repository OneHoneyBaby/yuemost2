namespace DSkin.Controls
{
    using DSkin.DirectUI;
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

    public class DSkinHtmlLabel : DSkinBaseControl
    {
        protected bool _autoSizeHight;
        protected CssData _baseCssData;
        protected string _baseRawCssData;
        protected string _text;
        private bool bool_0;
        private DuiScrollBar duiScrollBar_0;
        private DuiScrollBar duiScrollBar_1;
        private DSkin.Html.HtmlContainer htmlContainer_0;
        private int int_0;
        protected TextRenderingHint textRenderMode;

        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad;

        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;

        public event EventHandler LoadComplete;

        public event EventHandler<HtmlRenderErrorEventArgs> RenderError;

        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad;

        public DSkinHtmlLabel()
        {
            EventHandler handler = null;
            EventHandler<InvalidateEventArgs> handler2 = null;
            EventHandler handler3 = null;
            EventHandler<InvalidateEventArgs> handler4 = null;
            this.textRenderMode = TextRenderingHint.SystemDefault;
            this.bool_0 = false;
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
            this.int_0 = 30;
            this.htmlContainer_0 = new DSkin.Html.HtmlContainer(this);
            this.htmlContainer_0.method_2(true);
            this.htmlContainer_0.AvoidImagesLateLoading = true;
            this.htmlContainer_0.MaxSize = (SizeF) this.MaximumSize;
            this.htmlContainer_0.LoadComplete += new EventHandler(this.htmlContainer_0_LoadComplete);
            this.htmlContainer_0.LinkClicked += new EventHandler<HtmlLinkClickedEventArgs>(this.method_7);
            this.htmlContainer_0.RenderError += new EventHandler<HtmlRenderErrorEventArgs>(this.method_8);
            this.htmlContainer_0.Refresh += new EventHandler<HtmlRefreshEventArgs>(this.method_11);
            this.htmlContainer_0.StylesheetLoad += new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_9);
            this.htmlContainer_0.ImageLoad += new EventHandler<HtmlImageLoadEventArgs>(this.method_10);
            this.htmlContainer_0.ScrollChange += new EventHandler<HtmlScrollEventArgs>(this.aplaiwijYN);
            this.duiScrollBar_0.Parent = base.InnerDuiControl;
            handler = new EventHandler(this.method_12);
            this.duiScrollBar_0.ValueChanged += handler;
            handler2 = new EventHandler<InvalidateEventArgs>(this.method_13);
            this.duiScrollBar_0.Invalidated += handler2;
            this.duiScrollBar_1.Parent = base.InnerDuiControl;
            handler3 = new EventHandler(this.CigauodmQb);
            this.duiScrollBar_1.ValueChanged += handler3;
            handler4 = new EventHandler<InvalidateEventArgs>(this.method_14);
            this.duiScrollBar_1.Invalidated += handler4;
            base.InnerDuiControl.AutoChangedCursor = false;
        }

        private void aplaiwijYN(object sender, HtmlScrollEventArgs e)
        {
            base.Invalidate();
        }

        [CompilerGenerated]
        private void CigauodmQb(object sender, EventArgs e)
        {
            base.BeginInvoke(new MethodInvoker(this.method_16));
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
                this.htmlContainer_0.LinkClicked -= new EventHandler<HtmlLinkClickedEventArgs>(this.method_7);
                this.htmlContainer_0.RenderError -= new EventHandler<HtmlRenderErrorEventArgs>(this.method_8);
                this.htmlContainer_0.Refresh -= new EventHandler<HtmlRefreshEventArgs>(this.method_11);
                this.htmlContainer_0.StylesheetLoad -= new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_9);
                this.htmlContainer_0.ImageLoad -= new EventHandler<HtmlImageLoadEventArgs>(this.method_10);
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

        private void method_10(object sender, HtmlImageLoadEventArgs e)
        {
            this.OnImageLoad(e);
        }

        private void method_11(object sender, HtmlRefreshEventArgs e)
        {
            if (base.InvokeRequired)
            {
                <>c__DisplayClass10 class2;
                base.Invoke(new MethodInvoker(class2.<OnRefresh>b__f));
            }
            else
            {
                this.OnRefresh(e);
            }
        }

        [CompilerGenerated]
        private void method_12(object sender, EventArgs e)
        {
            base.BeginInvoke(new MethodInvoker(this.method_15));
        }

        [CompilerGenerated]
        private void method_13(object sender, InvalidateEventArgs e)
        {
            base.Invalidate();
        }

        [CompilerGenerated]
        private void method_14(object sender, InvalidateEventArgs e)
        {
            base.Invalidate();
        }

        [CompilerGenerated]
        private void method_15()
        {
            this.htmlContainer_0.ScrollOffset = new Point(-this.duiScrollBar_1.Value, -this.duiScrollBar_0.Value);
        }

        [CompilerGenerated]
        private void method_16()
        {
            this.htmlContainer_0.ScrollOffset = new Point(-this.duiScrollBar_1.Value, -this.duiScrollBar_0.Value);
        }

        private void method_6()
        {
            int num;
            this.duiScrollBar_0.Visible = ((this.bool_0 && !this.AutoSize) && !this.AutoSizeHeightOnly) && (this.htmlContainer_0.ActualSize.Height > base.Height);
            this.duiScrollBar_1.Visible = (this.bool_0 && !this.AutoSize) && (this.htmlContainer_0.ActualSize.Width > base.Width);
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

        private void method_7(object sender, HtmlLinkClickedEventArgs e)
        {
            this.OnLinkClicked(e);
        }

        private void method_8(object sender, HtmlRenderErrorEventArgs e)
        {
            if (base.InvokeRequired)
            {
                <>c__DisplayClassd classd;
                base.Invoke(new MethodInvoker(classd.<OnRenderError>b__c));
            }
            else
            {
                this.OnRenderError(e);
            }
        }

        private void method_9(object sender, HtmlStylesheetLoadEventArgs e)
        {
            this.OnStylesheetLoad(e);
        }

        protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
        {
            EventHandler<HtmlImageLoadEventArgs> handler = this.eventHandler_6;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            base.OnLayeredPaint(e);
            if (this.htmlContainer_0 != null)
            {
                e.Graphics.TextRenderingHint = this.textRenderMode;
                this.htmlContainer_0.Location = new PointF((float) base.Padding.Left, (float) base.Padding.Top);
                this.htmlContainer_0.PerformPaint(e.Graphics, new Rectangle?(e.ClipRectangle));
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (this.htmlContainer_0 != null)
            {
                Graphics g = Utils.CreateGraphics(this);
                if (g != null)
                {
                    using (g)
                    {
                        using (GraphicsAdapter adapter = new GraphicsAdapter(g, this.htmlContainer_0.method_1(), false))
                        {
                            RSize size2 = HtmlRendererUtils.Layout(adapter, this.htmlContainer_0.method_0(), new RSize((double) (base.ClientSize.Width - base.Padding.Horizontal), (double) (base.ClientSize.Height - base.Padding.Vertical)), new RSize((double) (this.MinimumSize.Width - base.Padding.Horizontal), (double) (this.MinimumSize.Height - base.Padding.Vertical)), new RSize((double) (this.MaximumSize.Width - base.Padding.Horizontal), (double) (this.MaximumSize.Height - base.Padding.Vertical)), this.AutoSize, this.AutoSizeHeightOnly);
                            base.ClientSize = Utils.ConvertRound(new RSize(size2.Width + base.Padding.Horizontal, size2.Height + base.Padding.Vertical));
                        }
                    }
                    this.method_6();
                }
            }
            base.OnLayout(levent);
        }

        protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
        {
            EventHandler<HtmlLinkClickedEventArgs> handler = this.eventHandler_3;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLoadComplete(EventArgs e)
        {
            EventHandler handler = this.eventHandler_2;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseDoubleClick(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseDown(e);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!(((this.htmlContainer_0 == null) || this.duiScrollBar_0.IsMouseEnter) || this.duiScrollBar_1.IsMouseEnter))
            {
                this.htmlContainer_0.HandleMouseMove(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
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
                this.duiScrollBar_0.Value += (e.Delta > 0) ? -this.int_0 : this.int_0;
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
            base.Invalidate();
        }

        protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
        {
            EventHandler<HtmlRenderErrorEventArgs> handler = this.eventHandler_4;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
        {
            EventHandler<HtmlStylesheetLoadEventArgs> handler = this.eventHandler_5;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SelectAll()
        {
            this.htmlContainer_0.SelectAll();
            base.Invalidate();
        }

        [Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        [Browsable(true), Description("自适应内容大小"), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
                    base.Invalidate();
                }
            }
        }

        [Category("Layout"), Description("根据内容自动设置标签的高度 (不影响宽度)。"), Browsable(true), DefaultValue(false)]
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
                    base.Invalidate();
                }
            }
        }

        [Description("获取或设置一个值，该值指示是否抗锯齿，比如背景和边框等图形"), Category("Behavior"), DefaultValue(false)]
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

        [Browsable(true), Category("Appearance"), Description("设置基本样式"), Editor("System.ComponentModel.Design.MultilineStringEditor", "System.Drawing.Design.UITypeEditor")]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                return this.duiScrollBar_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return this.duiScrollBar_1;
            }
        }

        [Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
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

        [Browsable(true), DefaultValue(true), EditorBrowsable(EditorBrowsableState.Always), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Description("是否启用内置右键菜单")]
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

        [Category("Behavior"), DefaultValue(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), Description("是否启用内容选择 (默认值为 true)。")]
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

        [Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the max size of the control (0 is not restricted)")]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
                if (this.htmlContainer_0 != null)
                {
                    this.htmlContainer_0.MaxSize = (SizeF) value;
                    base.PerformLayout();
                    base.Invalidate();
                }
            }
        }

        [Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the min size of the control (0 is not restricted)")]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable(false)]
        public override System.Windows.Forms.RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [DefaultValue(30), Description("鼠标滚轮滚动页面大小")]
        public int ScrollSize
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
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

        [DefaultValue(false), Description("是否显示滚动条")]
        public bool ShowScrollBar
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                    this.method_6();
                }
            }
        }

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
                    base.Invalidate();
                }
            }
        }

        [Category("外观"), Description("文本渲染模式"), DefaultValue(typeof(TextRenderingHint), "SystemDefault")]
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
                    base.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public bool UseWaitCursor
        {
            get
            {
                return base.UseWaitCursor;
            }
            set
            {
                base.UseWaitCursor = value;
            }
        }
    }
}

