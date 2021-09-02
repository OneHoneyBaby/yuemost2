namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [Description("封装ewe的浏览器控件，兼容大部分网站,支持一部分HTML5和CSS3，支持Flash播放，不支持WebGl，不适合做浏览器")]
    public class DSkinBrowser : DSkinBaseControl
    {
        private DuiBrowser duiBrowser_0;

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

        public DSkinBrowser()
        {
            EventHandler handler = null;
            EventHandler<DSkin.DirectUI.NavigationEventArgs> handler2 = null;
            EventHandler<DocumentReadyEventArgs> handler3 = null;
            EventHandler handler4 = null;
            EventHandler<DSkin.DirectUI.LoadingFinishEventArgs> handler5 = null;
            EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs> handler6 = null;
            EventHandler<DSkin.DirectUI.AlertBoxEventArgs> handler7 = null;
            EventHandler<DSkin.DirectUI.PromptBoxEventArgs> handler8 = null;
            EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs> handler9 = null;
            EventHandler<JsCallEventArgs> handler10 = null;
            this.duiBrowser_0 = (DuiBrowser) base.InnerDuiControl;
            this.duiBrowser_0.AutoChangedCursor = false;
            handler = new EventHandler(this.method_6);
            this.duiBrowser_0.UrlChanged += handler;
            handler2 = new EventHandler<DSkin.DirectUI.NavigationEventArgs>(this.method_7);
            this.duiBrowser_0.Navigating += handler2;
            handler3 = new EventHandler<DocumentReadyEventArgs>(this.method_8);
            this.duiBrowser_0.DocumentReady += handler3;
            handler4 = new EventHandler(this.method_9);
            this.duiBrowser_0.TitleChanged += handler4;
            handler5 = new EventHandler<DSkin.DirectUI.LoadingFinishEventArgs>(this.method_10);
            this.duiBrowser_0.LoadingFinish += handler5;
            handler6 = new EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs>(this.method_11);
            this.duiBrowser_0.ConsoleMessage += handler6;
            handler7 = new EventHandler<DSkin.DirectUI.AlertBoxEventArgs>(this.method_12);
            this.duiBrowser_0.AlertBox += handler7;
            handler8 = new EventHandler<DSkin.DirectUI.PromptBoxEventArgs>(this.method_13);
            this.duiBrowser_0.PromptBox += handler8;
            handler9 = new EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs>(this.method_14);
            this.duiBrowser_0.ConfirmBox += handler9;
            handler10 = new EventHandler<JsCallEventArgs>(this.method_15);
            this.duiBrowser_0.JsCall += handler10;
        }

        public void CreateWkeCore()
        {
            this.duiBrowser_0.CreateWkeCore();
        }

        public void EditorCopy()
        {
            this.duiBrowser_0.EditorCopy();
        }

        public void EditorCut()
        {
            this.duiBrowser_0.EditorCut();
        }

        public void EditorDelete()
        {
            this.duiBrowser_0.EditorDelete();
        }

        public void EditorPaste()
        {
            this.duiBrowser_0.EditorPaste();
        }

        public void EditorSelectAll()
        {
            this.duiBrowser_0.EditorSelectAll();
        }

        public void GoBack()
        {
            this.duiBrowser_0.GoBack();
        }

        public void GoForword()
        {
            this.duiBrowser_0.GoForword();
        }

        public DSkin.DirectUI.JsValue InvokeJS(string js)
        {
            return this.duiBrowser_0.InvokeJS(js);
        }

        public DSkin.DirectUI.JsValue InvokeJS(IntPtr es, string js)
        {
            return this.duiBrowser_0.InvokeJS(es, js);
        }

        public void JsBindFun(string name, DSkin.DirectUI.jsNativeFunction jsf)
        {
            this.duiBrowser_0.JsBindFun(name, jsf);
        }

        public IntPtr JSGlobalExec()
        {
            return this.duiBrowser_0.JSGlobalExec();
        }

        public void LoadFile(string fileName)
        {
            this.duiBrowser_0.LoadFile(fileName);
        }

        public void LoadHTML(string html)
        {
            this.duiBrowser_0.LoadHTML(html);
        }

        [CompilerGenerated]
        private void method_10(object sender, DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            this.OnLoadingFinish(e);
        }

        [CompilerGenerated]
        private void method_11(object sender, DSkin.DirectUI.ConsoleMessageEventArgs e)
        {
            this.OnConsoleMessage(e);
        }

        [CompilerGenerated]
        private void method_12(object sender, DSkin.DirectUI.AlertBoxEventArgs e)
        {
            this.OnAlertBox(e);
        }

        [CompilerGenerated]
        private void method_13(object sender, DSkin.DirectUI.PromptBoxEventArgs e)
        {
            this.OnPromptBox(e);
        }

        [CompilerGenerated]
        private void method_14(object sender, DSkin.DirectUI.ConfirmBoxEventArgs e)
        {
            this.OnConfirmBox(e);
        }

        [CompilerGenerated]
        private void method_15(object sender, JsCallEventArgs e)
        {
            this.OnJsCall(e);
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
        }

        [CompilerGenerated]
        private void method_9(object sender, EventArgs e)
        {
            this.OnTitleChanged(EventArgs.Empty);
        }

        protected virtual void OnAlertBox(DSkin.DirectUI.AlertBoxEventArgs e)
        {
            if (this.eventHandler_8 != null)
            {
                this.eventHandler_8(this, e);
            }
        }

        protected virtual void OnConfirmBox(DSkin.DirectUI.ConfirmBoxEventArgs e)
        {
            if (this.eventHandler_9 != null)
            {
                this.eventHandler_9(this, e);
            }
        }

        protected virtual void OnConsoleMessage(DSkin.DirectUI.ConsoleMessageEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnDocumentReady(DocumentReadyEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnJsCall(JsCallEventArgs e)
        {
            if (this.eventHandler_11 != null)
            {
                this.eventHandler_11(this, e);
            }
        }

        protected virtual void OnLoadingFinish(DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnNavigating(DSkin.DirectUI.NavigationEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnPromptBox(DSkin.DirectUI.PromptBoxEventArgs e)
        {
            if (this.eventHandler_10 != null)
            {
                this.eventHandler_10(this, e);
            }
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected virtual void OnUrlChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        public void PostURL(string url, byte[] data)
        {
            this.duiBrowser_0.PostURL(url, data);
        }

        public void Reload()
        {
            this.duiBrowser_0.Reload();
        }

        public void StopLoading()
        {
            this.duiBrowser_0.StopLoading();
        }

        [Browsable(false)]
        public bool CanGoBack
        {
            get
            {
                return this.duiBrowser_0.CanGoBack;
            }
        }

        [Browsable(false)]
        public bool CanGoForword
        {
            get
            {
                return this.duiBrowser_0.CanGoForword;
            }
        }

        [Browsable(false)]
        public int ContentsHeight
        {
            get
            {
                return this.duiBrowser_0.ContentsHeight;
            }
        }

        [Browsable(false)]
        public int ContentsWidth
        {
            get
            {
                return this.duiBrowser_0.ContentsWidth;
            }
        }

        [Browsable(false)]
        public string Cookie
        {
            get
            {
                return this.duiBrowser_0.Cookie;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiBrowser();
            }
        }

        [Description("是否启用Cookie"), Category("Browser"), DefaultValue(true)]
        public bool EnabledCookie
        {
            get
            {
                return this.duiBrowser_0.EnabledCookie;
            }
            set
            {
                this.duiBrowser_0.EnabledCookie = value;
            }
        }

        [Description("启用背景透明"), DefaultValue(true), Category("Browser")]
        public bool EnabledTransparent
        {
            get
            {
                return this.duiBrowser_0.EnabledTransparent;
            }
            set
            {
                this.duiBrowser_0.EnabledTransparent = value;
            }
        }

        [Browsable(false), DefaultValue((string) null)]
        public object GlobalObject
        {
            get
            {
                return this.duiBrowser_0.GlobalObject;
            }
            set
            {
                this.duiBrowser_0.GlobalObject = value;
            }
        }

        [Browsable(false)]
        public bool IsLoadComplete
        {
            get
            {
                return this.duiBrowser_0.IsLoadComplete;
            }
        }

        [Browsable(false)]
        public wkeLoadingStatus LoadingStatus
        {
            get
            {
                return this.duiBrowser_0.LoadingStatus;
            }
        }

        [Category("Browser"), Description("获取或设置媒体音量 0-1"), DefaultValue((float) 1f)]
        public float MediaVolume
        {
            get
            {
                return this.duiBrowser_0.MediaVolume;
            }
            set
            {
                this.duiBrowser_0.MediaVolume = value;
            }
        }

        [Browsable(false)]
        public string Title
        {
            get
            {
                return this.duiBrowser_0.Title;
            }
        }

        [Category("Browser"), Description("url"), DefaultValue("URL")]
        public string Url
        {
            get
            {
                return this.duiBrowser_0.Url;
            }
            set
            {
                this.duiBrowser_0.Url = value;
            }
        }

        [Description("获取设置浏览器的UserAgent"), DefaultValue(""), Category("Browser")]
        public string UserAgent
        {
            get
            {
                return this.duiBrowser_0.UserAgent;
            }
            set
            {
                this.duiBrowser_0.UserAgent = value;
            }
        }

        [Browsable(false)]
        public IntPtr WkeCore
        {
            get
            {
                return this.duiBrowser_0.WkeCore;
            }
        }

        [DefaultValue((float) 1f), Description("网页缩放比例"), Category("Browser")]
        public float ZoomFactor
        {
            get
            {
                return this.duiBrowser_0.ZoomFactor;
            }
            set
            {
                this.duiBrowser_0.ZoomFactor = value;
            }
        }
    }
}

