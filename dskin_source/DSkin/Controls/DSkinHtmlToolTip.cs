namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Html;
    using DSkin.Html.Adapters;
    using DSkin.Html.Core;
    using DSkin.Html.Core.Entities;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class DSkinHtmlToolTip : ToolTip
    {
        protected CssData _baseCssData;
        protected string _baseRawCssData;
        protected HtmlContainer _htmlContainer;
        protected System.Drawing.Text.TextRenderingHint _textRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        private bool bool_0 = true;
        private Control control_0;
        private IntPtr intptr_0;
        private string string_0 = "htmltooltip";
        private System.Windows.Forms.Timer timer_0;

        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad;

        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;

        public event EventHandler<HtmlRenderErrorEventArgs> RenderError;

        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad;

        public DSkinHtmlToolTip()
        {
            base.OwnerDraw = true;
            this._htmlContainer = new HtmlContainer();
            this._htmlContainer.IsSelectionEnabled = false;
            this._htmlContainer.IsContextMenuEnabled = false;
            this._htmlContainer.AvoidGeometryAntialias = true;
            this._htmlContainer.AvoidImagesLateLoading = true;
            this._htmlContainer.RenderError += new EventHandler<HtmlRenderErrorEventArgs>(this.method_0);
            this._htmlContainer.StylesheetLoad += new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_1);
            this._htmlContainer.ImageLoad += new EventHandler<HtmlImageLoadEventArgs>(this.method_2);
            base.Popup += new PopupEventHandler(this.DSkinHtmlToolTip_Popup);
            base.Draw += new DrawToolTipEventHandler(this.DSkinHtmlToolTip_Draw);
            base.Disposed += new EventHandler(this.EwUxXoIqis);
            this.timer_0 = new System.Windows.Forms.Timer();
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            this.timer_0.Interval = 40;
            this._htmlContainer.LinkClicked += new EventHandler<HtmlLinkClickedEventArgs>(this.method_3);
        }

        protected virtual void AdjustTooltipPosition(Control associatedControl, Size size)
        {
            Point mousePosition = Control.MousePosition;
            Rectangle workingArea = Screen.FromControl(associatedControl).WorkingArea;
            if ((mousePosition.X + size.Width) > workingArea.Right)
            {
                mousePosition.X = Math.Max((int) ((workingArea.Right - size.Width) - 5), (int) (workingArea.Left + 3));
            }
            if (((mousePosition.Y + size.Height) + 20) > workingArea.Bottom)
            {
                mousePosition.Y = Math.Max((int) (((workingArea.Bottom - size.Height) - 20) - 3), (int) (workingArea.Top + 2));
            }
            DSkin.NativeMethods.MoveWindow(this.intptr_0, mousePosition.X, mousePosition.Y + 20, size.Width, size.Height, false);
        }

        private void DSkinHtmlToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            this.OnToolTipDraw(e);
        }

        private void DSkinHtmlToolTip_Popup(object sender, PopupEventArgs e)
        {
            this.OnToolTipPopup(e);
        }

        private void EwUxXoIqis(object sender, EventArgs e)
        {
            this.OnToolTipDisposed(e);
        }

        private void method_0(object sender, HtmlRenderErrorEventArgs e)
        {
            this.OnRenderError(e);
        }

        private void method_1(object sender, HtmlStylesheetLoadEventArgs e)
        {
            this.OnStylesheetLoad(e);
        }

        private void method_2(object sender, HtmlImageLoadEventArgs e)
        {
            this.OnImageLoad(e);
        }

        private void method_3(object sender, HtmlLinkClickedEventArgs e)
        {
            this.OnLinkClicked(e);
        }

        protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
        {
            EventHandler<HtmlImageLoadEventArgs> handler = this.eventHandler_3;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
        {
            EventHandler<HtmlLinkClickedEventArgs> handler = this.eventHandler_0;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLinkHandlingTimerTick(EventArgs e)
        {
            try
            {
                Point mousePosition;
                MouseButtons mouseButtons;
                Rectangle windowRectangle;
                IntPtr hWnd = this.intptr_0;
                if ((hWnd != IntPtr.Zero) && DSkin.NativeMethods.IsWindowVisible(hWnd))
                {
                    mousePosition = Control.MousePosition;
                    mouseButtons = Control.MouseButtons;
                    windowRectangle = DSkin.NativeMethods.GetWindowRectangle(hWnd);
                    if (windowRectangle.Contains(mousePosition))
                    {
                        this._htmlContainer.HandleMouseMove(new MouseEventArgs(mouseButtons, 0, mousePosition.X - windowRectangle.X, mousePosition.Y - windowRectangle.Y, 0));
                    }
                }
                else
                {
                    this.timer_0.Stop();
                    this.intptr_0 = IntPtr.Zero;
                    mousePosition = Control.MousePosition;
                    mouseButtons = Control.MouseButtons;
                    windowRectangle = DSkin.NativeMethods.GetWindowRectangle(hWnd);
                    if (windowRectangle.Contains(mousePosition) && (mouseButtons == MouseButtons.Left))
                    {
                        MouseEventArgs args = new MouseEventArgs(mouseButtons, 1, mousePosition.X - windowRectangle.X, mousePosition.Y - windowRectangle.Y, 0);
                        this._htmlContainer.HandleMouseDown(args);
                        this._htmlContainer.HandleMouseUp(args);
                    }
                }
            }
            catch (Exception exception)
            {
                this.method_0(this, new HtmlRenderErrorEventArgs(HtmlRenderErrorType.General, "Error in link handling for tooltip", exception));
            }
        }

        protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
        {
            EventHandler<HtmlRenderErrorEventArgs> handler = this.eventHandler_1;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
        {
            EventHandler<HtmlStylesheetLoadEventArgs> handler = this.eventHandler_2;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnToolTipDisposed(EventArgs e)
        {
            base.Popup -= new PopupEventHandler(this.DSkinHtmlToolTip_Popup);
            base.Draw -= new DrawToolTipEventHandler(this.DSkinHtmlToolTip_Draw);
            base.Disposed -= new EventHandler(this.EwUxXoIqis);
            if (this._htmlContainer != null)
            {
                this._htmlContainer.RenderError -= new EventHandler<HtmlRenderErrorEventArgs>(this.method_0);
                this._htmlContainer.StylesheetLoad -= new EventHandler<HtmlStylesheetLoadEventArgs>(this.method_1);
                this._htmlContainer.ImageLoad -= new EventHandler<HtmlImageLoadEventArgs>(this.method_2);
                this._htmlContainer.Dispose();
                this._htmlContainer = null;
            }
            if (this.timer_0 != null)
            {
                this.timer_0.Dispose();
                this.timer_0 = null;
                if (this._htmlContainer != null)
                {
                    this._htmlContainer.LinkClicked -= new EventHandler<HtmlLinkClickedEventArgs>(this.method_3);
                }
            }
        }

        protected virtual void OnToolTipDraw(DrawToolTipEventArgs e)
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                IntPtr hdc = e.Graphics.GetHdc();
                this.intptr_0 = DSkin.NativeMethods.WindowFromDC(hdc);
                e.Graphics.ReleaseHdc(hdc);
                this.AdjustTooltipPosition(e.AssociatedControl, e.Bounds.Size);
            }
            e.Graphics.Clear(Color.White);
            e.Graphics.TextRenderingHint = this._textRenderingHint;
            this._htmlContainer.PerformPaint(e.Graphics, new Rectangle?(e.Bounds));
        }

        protected virtual void OnToolTipPopup(PopupEventArgs e)
        {
            string str = string.IsNullOrEmpty(this.string_0) ? null : string.Format(" class=\"{0}\"", this.string_0);
            string htmlSource = string.Format("<div{0}>{1}</div>", str, base.GetToolTip(e.AssociatedControl));
            this._htmlContainer.SetHtml(htmlSource, this._baseCssData);
            this._htmlContainer.MaxSize = (SizeF) this.MaximumSize;
            using (Graphics graphics = e.AssociatedControl.CreateGraphics())
            {
                graphics.TextRenderingHint = this._textRenderingHint;
                this._htmlContainer.PerformLayout(graphics);
            }
            int width = (int) Math.Ceiling((this.MaximumSize.Width > 0) ? ((double) Math.Min(this._htmlContainer.ActualSize.Width, (float) this.MaximumSize.Width)) : ((double) this._htmlContainer.ActualSize.Width));
            int height = (int) Math.Ceiling((this.MaximumSize.Height > 0) ? ((double) Math.Min(this._htmlContainer.ActualSize.Height, (float) this.MaximumSize.Height)) : ((double) this._htmlContainer.ActualSize.Height));
            e.ToolTipSize = new Size(width, height);
            if (this.bool_0)
            {
                this.control_0 = e.AssociatedControl;
                this._htmlContainer.method_0().Control = new ControlAdapter(this.control_0, false);
                this.timer_0.Start();
            }
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            this.OnLinkHandlingTimerTick(e);
        }

        [Category("行为"), DefaultValue(false), Browsable(true), Description("是否要处理在工具提示中的链接")]
        public virtual bool AllowLinksHandling
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

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Browsable(true), Description("基础样式"), Category("外观")]
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
            }
        }

        [Description("获取和设置最大尺寸 (0 为不受限制)"), Browsable(true), Category("Layout")]
        public virtual Size MaximumSize
        {
            get
            {
                return Size.Round(this._htmlContainer.MaxSize);
            }
            set
            {
                this._htmlContainer.MaxSize = (SizeF) value;
            }
        }

        [Category("DSkin"), Description("文本渲染模式"), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this._textRenderingHint;
            }
            set
            {
                this._textRenderingHint = value;
            }
        }

        [Browsable(true), Category("外观"), Description("用于工具提示 html 根 div 的 CSS 类 (默认: htmltooltip)")]
        public virtual string TooltipCssClass
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

