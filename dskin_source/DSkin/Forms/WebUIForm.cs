namespace DSkin.Forms
{
    using DSkin;
    using DSkin.Controls;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class WebUIForm : DSkinWindowForm
    {
        [CompilerGenerated]
        private bool bool_3;
        private DSkinBrowser dskinBrowser_0;
        private FormWindowState formWindowState_0;
        private System.Windows.Forms.Timer tqbfUuducg;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.AlertBoxEventArgs> AlertBox;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs> ConfirmBox;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs> ConsoleMessage;

        [Category("Browser")]
        public event EventHandler<DocumentReadyEventArgs> DocumentReady;

        [Category("Browser"), Description("当网页中的JS调用JsCall方法的时候触发")]
        public event EventHandler<JsCallEventArgs> JsCall;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.LoadingFinishEventArgs> LoadingFinish;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.NavigationEventArgs> Navigating;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.PromptBoxEventArgs> PromptBox;

        [Category("Browser")]
        public event EventHandler TitleChanged;

        [Category("Browser")]
        public event EventHandler UrlChanged;

        public WebUIForm() : this("")
        {
        }

        public WebUIForm(string url = "")
        {
            EventHandler handler = null;
            EventHandler handler2 = null;
            EventHandler<DSkin.DirectUI.NavigationEventArgs> handler3 = null;
            EventHandler<DocumentReadyEventArgs> handler4 = null;
            EventHandler<DSkin.DirectUI.LoadingFinishEventArgs> handler5 = null;
            EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs> handler6 = null;
            EventHandler<DSkin.DirectUI.AlertBoxEventArgs> handler7 = null;
            EventHandler<DSkin.DirectUI.PromptBoxEventArgs> handler8 = null;
            EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs> handler9 = null;
            EventHandler<JsCallEventArgs> handler10 = null;
            EventHandler handler11 = null;
            EventHandler handler12 = null;
            this.dskinBrowser_0 = new DSkinBrowser();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = 20
            };
            this.tqbfUuducg = timer;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                this.dskinBrowser_0.ZoomFactor = graphics.DpiX / 96f;
            }
            this.formWindowState_0 = base.WindowState;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.FormBorderStyle = FormBorderStyle.None;
            this.dskinBrowser_0.GlobalObject = this;
            this.dskinBrowser_0.Dock = DockStyle.Fill;
            this.dskinBrowser_0.Url = url;
            if (handler == null)
            {
                handler = new EventHandler(this.method_5);
            }
            this.dskinBrowser_0.TitleChanged += handler;
            if (handler2 == null)
            {
                handler2 = new EventHandler(this.method_6);
            }
            this.dskinBrowser_0.UrlChanged += handler2;
            if (handler3 == null)
            {
                handler3 = new EventHandler<DSkin.DirectUI.NavigationEventArgs>(this.method_7);
            }
            this.dskinBrowser_0.Navigating += handler3;
            if (handler4 == null)
            {
                handler4 = new EventHandler<DocumentReadyEventArgs>(this.method_8);
            }
            this.dskinBrowser_0.DocumentReady += handler4;
            if (handler5 == null)
            {
                handler5 = new EventHandler<DSkin.DirectUI.LoadingFinishEventArgs>(this.method_9);
            }
            this.dskinBrowser_0.LoadingFinish += handler5;
            if (handler6 == null)
            {
                handler6 = new EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs>(this.method_10);
            }
            this.dskinBrowser_0.ConsoleMessage += handler6;
            if (handler7 == null)
            {
                handler7 = new EventHandler<DSkin.DirectUI.AlertBoxEventArgs>(this.method_11);
            }
            this.dskinBrowser_0.AlertBox += handler7;
            if (handler8 == null)
            {
                handler8 = new EventHandler<DSkin.DirectUI.PromptBoxEventArgs>(this.method_12);
            }
            this.dskinBrowser_0.PromptBox += handler8;
            if (handler9 == null)
            {
                handler9 = new EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs>(this.method_13);
            }
            this.dskinBrowser_0.ConfirmBox += handler9;
            if (handler10 == null)
            {
                handler10 = new EventHandler<JsCallEventArgs>(this.method_14);
            }
            this.dskinBrowser_0.JsCall += handler10;
            if (handler11 == null)
            {
                handler11 = new EventHandler(this.method_15);
            }
            this.dskinBrowser_0.MouseEnter += handler11;
            if (handler12 == null)
            {
                handler12 = new EventHandler(this.method_16);
            }
            this.dskinBrowser_0.MouseLeave += handler12;
            base.Size = new Size(400, 400);
        }

        [GAttribute0]
        public void Command_Close()
        {
            base.Close();
        }

        [GAttribute0]
        public void Command_MaxOrNor()
        {
            if (base.WindowState == FormWindowState.Maximized)
            {
                base.WindowState = FormWindowState.Normal;
            }
            else
            {
                base.WindowState = FormWindowState.Maximized;
            }
            if (this.formWindowState_0 != base.WindowState)
            {
                switch (base.WindowState)
                {
                    case FormWindowState.Normal:
                        this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('nor')");
                        break;

                    case FormWindowState.Minimized:
                        this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('min')");
                        break;

                    case FormWindowState.Maximized:
                        this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('max')");
                        break;
                }
                this.formWindowState_0 = base.WindowState;
            }
            EweCore.wkeFireMouseEvent(this.dskinBrowser_0.WkeCore, 0x200, 0, 0, 0);
        }

        [GAttribute0]
        public void Command_Min()
        {
            base.WindowState = FormWindowState.Minimized;
            EweCore.wkeFireMouseEvent(this.dskinBrowser_0.WkeCore, 0x200, 0, 0, 0);
        }

        [GAttribute0]
        public void Console_WriteLine(string msg)
        {
            Console.WriteLine("控制台输出：" + msg);
        }

        public void CreateWkeCore()
        {
            this.dskinBrowser_0.CreateWkeCore();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.tqbfUuducg.Dispose();
            if (!this.dskinBrowser_0.IsDisposed)
            {
                this.dskinBrowser_0.Dispose();
            }
        }

        public void EditorCopy()
        {
            this.dskinBrowser_0.EditorCopy();
        }

        public void EditorCut()
        {
            this.dskinBrowser_0.EditorCut();
        }

        public void EditorDelete()
        {
            this.dskinBrowser_0.EditorDelete();
        }

        public void EditorPaste()
        {
            this.dskinBrowser_0.EditorPaste();
        }

        public void EditorSelectAll()
        {
            this.dskinBrowser_0.EditorSelectAll();
        }

        [GAttribute0]
        public string GetWindowState()
        {
            switch (base.WindowState)
            {
                case FormWindowState.Normal:
                    return "nor";

                case FormWindowState.Minimized:
                    return "min";

                case FormWindowState.Maximized:
                    return "max";
            }
            return "nor";
        }

        public void GoBack()
        {
            this.dskinBrowser_0.GoBack();
        }

        public void GoForword()
        {
            this.dskinBrowser_0.GoForword();
        }

        public DSkin.DirectUI.JsValue InvokeJS(string js)
        {
            return this.dskinBrowser_0.InvokeJS(js);
        }

        public DSkin.DirectUI.JsValue InvokeJS(IntPtr es, string js)
        {
            return this.dskinBrowser_0.InvokeJS(es, js);
        }

        public void JsBindFun(string name, DSkin.DirectUI.jsNativeFunction jsf)
        {
            this.dskinBrowser_0.JsBindFun(name, jsf);
        }

        public IntPtr JSGlobalExec()
        {
            return this.dskinBrowser_0.JSGlobalExec();
        }

        public void LoadFile(string fileName)
        {
            this.dskinBrowser_0.LoadFile(fileName);
        }

        public void LoadHtml(string html)
        {
            this.dskinBrowser_0.LoadHTML(html);
        }

        [CompilerGenerated]
        private void method_10(object sender, DSkin.DirectUI.ConsoleMessageEventArgs e)
        {
            this.OnConsoleMessage(e);
        }

        [CompilerGenerated]
        private void method_11(object sender, DSkin.DirectUI.AlertBoxEventArgs e)
        {
            this.OnAlertBox(e);
        }

        [CompilerGenerated]
        private void method_12(object sender, DSkin.DirectUI.PromptBoxEventArgs e)
        {
            this.OnPromptBox(e);
        }

        [CompilerGenerated]
        private void method_13(object sender, DSkin.DirectUI.ConfirmBoxEventArgs e)
        {
            this.OnConfirmBox(e);
        }

        [CompilerGenerated]
        private void method_14(object sender, JsCallEventArgs e)
        {
            this.OnJsCall(e);
        }

        [CompilerGenerated]
        private void method_15(object sender, EventArgs e)
        {
            this.dskinBrowser_0.InvokeJS("OnWindowMouseEnter()");
        }

        [CompilerGenerated]
        private void method_16(object sender, EventArgs e)
        {
            this.dskinBrowser_0.InvokeJS("OnWindowMouseLeave()");
        }

        [CompilerGenerated]
        private void method_17()
        {
            this.dskinBrowser_0.InvokeJS("OnDocumentReady()");
        }

        [CompilerGenerated]
        private void method_18(Graphics graphics_0)
        {
            graphics_0.Clear(Color.Transparent);
            this.dskinBrowser_0.PaintControl(graphics_0, new Rectangle(0, 0, base.Width, base.Height));
        }

        private void method_2(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaint(e);
        }

        [CompilerGenerated]
        private string method_3()
        {
            return base.Text;
        }

        [CompilerGenerated]
        private void method_4(string string_0)
        {
            base.Text = string_0;
        }

        [CompilerGenerated]
        private void method_5(object sender, EventArgs e)
        {
            this.OnTitleChanged(EventArgs.Empty);
            if (this.method_3() != this.dskinBrowser_0.Title)
            {
                this.method_4(this.dskinBrowser_0.Title);
            }
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            this.OnUrlChanged(EventArgs.Empty);
        }

        [CompilerGenerated]
        private void method_7(object sender, DSkin.DirectUI.NavigationEventArgs e)
        {
            this.OnNavigating(e);
        }

        [CompilerGenerated]
        private void method_8(object sender, DocumentReadyEventArgs e)
        {
            this.OnDocumentReady(e);
            base.BeginInvoke(new Action(this, (IntPtr) this.method_17));
        }

        [CompilerGenerated]
        private void method_9(object sender, DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            this.OnLoadingFinish(e);
        }

        [GAttribute0]
        public void MoveWindow()
        {
            DSkin.NativeMethods.MouseToMoveControl(base.Handle);
        }

        protected virtual void OnAlertBox(DSkin.DirectUI.AlertBoxEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnConfirmBox(DSkin.DirectUI.ConfirmBoxEventArgs e)
        {
            if (this.eventHandler_8 != null)
            {
                this.eventHandler_8(this, e);
            }
        }

        protected virtual void OnConsoleMessage(DSkin.DirectUI.ConsoleMessageEventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected virtual void OnDocumentReady(DocumentReadyEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = this.dskinBrowser_0.InvokeJS("OnWindowClosing()").ToBool();
            base.OnFormClosing(e);
        }

        protected virtual void OnJsCall(JsCallEventArgs e)
        {
            if (this.UvBfSniesG != null)
            {
                this.UvBfSniesG(this, e);
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.tqbfUuducg.Tick += new EventHandler(this.tqbfUuducg_Tick);
            if (!base.DesignMode)
            {
                this.dskinBrowser_0.Parent = this;
                this.tqbfUuducg.Start();
            }
            base.OnLoad(e);
        }

        protected virtual void OnLoadingFinish(DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnNavigating(DSkin.DirectUI.NavigationEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("请勿添加控件！窗体呈现效果请用Html定义，不要设置窗体的属性！", this.Font, Brushes.Red, base.ClientRectangle);
        }

        protected virtual void OnPromptBox(DSkin.DirectUI.PromptBoxEventArgs e)
        {
            if (this.oDefylLcyO != null)
            {
                this.oDefylLcyO(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!base.DesignMode)
            {
                if (this.formWindowState_0 != base.WindowState)
                {
                    switch (base.WindowState)
                    {
                        case FormWindowState.Normal:
                            this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('nor')");
                            break;

                        case FormWindowState.Minimized:
                            this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('min')");
                            break;

                        case FormWindowState.Maximized:
                            this.dskinBrowser_0.InvokeJS("OnWindowStateChanged('max')");
                            break;
                    }
                    this.formWindowState_0 = base.WindowState;
                }
                if (this.dskinBrowser_0.IsHandleCreated)
                {
                    this.dskinBrowser_0.InvokeJS("OnWindowSizeChanged()");
                }
            }
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnUrlChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        public void PostURL(string url, byte[] data)
        {
            this.dskinBrowser_0.PostURL(url, data);
        }

        public void Reload()
        {
            this.dskinBrowser_0.Reload();
        }

        [GAttribute0]
        public void ResizeWindow(string direction)
        {
            DSkin.NativeMethods.ReleaseCapture();
            if (direction == "top")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf003, 0);
            }
            else if (direction == "bottom")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf006, 0);
            }
            else if (direction == "left")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf001, 0);
            }
            else if (direction == "right")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf002, 0);
            }
            else if (direction == "lefttop")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf004, 0);
            }
            else if (direction == "righttop")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf005, 0);
            }
            else if (direction == "rightbottom")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf008, 0);
            }
            else if (direction == "leftbottom")
            {
                DSkin.NativeMethods.SendMessage(base.Handle, 0x112, 0xf007, 0);
            }
        }

        public void StopLoading()
        {
            this.dskinBrowser_0.StopLoading();
        }

        private void tqbfUuducg_Tick(object sender, EventArgs e)
        {
            Action<Graphics> action = null;
            if (((base.Visible && (base.WindowState != FormWindowState.Minimized)) && (this.dskinBrowser_0.InnerDuiControl.method_0().Width > 0)) && (this.dskinBrowser_0.InnerDuiControl.method_0().Height > 0))
            {
                if (action == null)
                {
                    action = new Action<Graphics>(this.method_18);
                }
                this.UpdateLayeredWindow(1.0, action);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x24) && !this.IsFullScreenMax)
            {
                DSkin.NativeMethods.MINMAXINFO structure = (DSkin.NativeMethods.MINMAXINFO) Marshal.PtrToStructure(m.LParam, typeof(DSkin.NativeMethods.MINMAXINFO));
                if (this.MaximumSize != Size.Empty)
                {
                    structure.maxTrackSize = this.MaximumSize;
                }
                else
                {
                    Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                    Rectangle rectangle = Screen.GetWorkingArea(this);
                    if (workingArea.Equals(rectangle))
                    {
                        structure.maxPosition = new Point(rectangle.X, rectangle.Y);
                    }
                    else
                    {
                        structure.maxPosition = new Point(0, 0);
                    }
                    structure.maxTrackSize = new Size(rectangle.Width, rectangle.Height);
                }
                if (this.MinimumSize != Size.Empty)
                {
                    structure.minTrackSize = this.MinimumSize;
                }
                Marshal.StructureToPtr(structure, m.LParam, false);
            }
            if (m.Msg != 0x20)
            {
                base.WndProc(ref m);
            }
        }

        [Browsable(false)]
        public bool CanGoBack
        {
            get
            {
                return this.dskinBrowser_0.CanGoBack;
            }
        }

        [Browsable(false)]
        public bool CanGoForword
        {
            get
            {
                return this.dskinBrowser_0.CanGoForword;
            }
        }

        [Browsable(false)]
        public int ContentsHeight
        {
            get
            {
                return this.dskinBrowser_0.ContentsHeight;
            }
        }

        [Browsable(false)]
        public int ContentsWidth
        {
            get
            {
                return this.dskinBrowser_0.ContentsWidth;
            }
        }

        [Browsable(false)]
        public string Cookie
        {
            get
            {
                return this.dskinBrowser_0.Cookie;
            }
        }

        [Description("是否启用Cookie"), Category("Browser"), DefaultValue(true)]
        public bool EnabledCookie
        {
            get
            {
                return this.dskinBrowser_0.EnabledCookie;
            }
            set
            {
                this.dskinBrowser_0.EnabledCookie = value;
            }
        }

        [Category("Browser"), Description("启用背景透明"), DefaultValue(true)]
        public bool EnabledTransparent
        {
            get
            {
                return this.dskinBrowser_0.EnabledTransparent;
            }
            set
            {
                this.dskinBrowser_0.EnabledTransparent = value;
            }
        }

        [Category("WebUI"), Description("最大化是否全屏"), DefaultValue(false)]
        public bool IsFullScreenMax
        {
            [CompilerGenerated]
            get
            {
                return this.bool_3;
            }
            [CompilerGenerated]
            set
            {
                this.bool_3 = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsLayeredWindowForm
        {
            get
            {
                return base.IsLayeredWindowForm;
            }
            set
            {
                base.IsLayeredWindowForm = value;
            }
        }

        [Browsable(false)]
        public bool IsLoadComplete
        {
            get
            {
                return this.dskinBrowser_0.IsLoadComplete;
            }
        }

        [Browsable(false)]
        public wkeLoadingStatus LoadingStatus
        {
            get
            {
                return this.dskinBrowser_0.LoadingStatus;
            }
        }

        [Category("Browser"), DefaultValue((float) 1f), Description("获取或设置媒体音量 0-1")]
        public float MediaVolume
        {
            get
            {
                return this.dskinBrowser_0.MediaVolume;
            }
            set
            {
                this.dskinBrowser_0.MediaVolume = value;
            }
        }

        [ReadOnly(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Category("WebUI")]
        public string Url
        {
            get
            {
                return this.dskinBrowser_0.Url;
            }
            set
            {
                this.dskinBrowser_0.Url = value;
            }
        }

        [Description("获取设置浏览器的UserAgent"), Category("Browser"), DefaultValue("")]
        public string UserAgent
        {
            get
            {
                return this.dskinBrowser_0.UserAgent;
            }
            set
            {
                this.dskinBrowser_0.UserAgent = value;
            }
        }

        [Browsable(false)]
        public IntPtr WkeCore
        {
            get
            {
                return this.dskinBrowser_0.WkeCore;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), ReadOnly(true)]
        public float ZoomFactor
        {
            get
            {
                return this.dskinBrowser_0.ZoomFactor;
            }
            set
            {
                this.dskinBrowser_0.ZoomFactor = value;
            }
        }
    }
}

