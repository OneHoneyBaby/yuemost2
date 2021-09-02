namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class DSkinWkeBrowser : DSkinBaseControl
    {
        private DuiWkeBrowser duiWkeBrowser_0;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.AlertBoxEventArgs> AlertBox;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.ConfirmBoxEventArgs> ConfirmBox;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.ConsoleMessageEventArgs> ConsoleMessage;

        [Category("Browser")]
        public event EventHandler DocumentReady;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.LoadingFinishEventArgs> LoadingFinish;

        [Category("Browser")]
        public event EventHandler<DuiWkeBrowser.NavigationEventArgs> Navigating;

        [Category("Browser")]
        public event EventHandler<DSkin.DirectUI.PromptBoxEventArgs> PromptBox;

        [Category("Browser")]
        public event EventHandler TitleChanged;

        [Category("Browser")]
        public event EventHandler UrlChanged;

        public DSkinWkeBrowser()
        {
            EventHandler handler = null;
            EventHandler<DuiWkeBrowser.NavigationEventArgs> handler2 = null;
            EventHandler handler3 = null;
            this.duiWkeBrowser_0 = (DuiWkeBrowser) base.InnerDuiControl;
            this.duiWkeBrowser_0.AutoChangedCursor = false;
            handler = new EventHandler(this.method_6);
            this.duiWkeBrowser_0.UrlChanged += handler;
            handler2 = new EventHandler<DuiWkeBrowser.NavigationEventArgs>(this.method_7);
            this.duiWkeBrowser_0.Navigating += handler2;
            handler3 = new EventHandler(this.method_8);
            this.duiWkeBrowser_0.DocumentReady += handler3;
        }

        public void EditorCopy()
        {
            this.duiWkeBrowser_0.EditorCopy();
        }

        public void EditorCut()
        {
            this.duiWkeBrowser_0.EditorCut();
        }

        public void EditorDelete()
        {
            this.duiWkeBrowser_0.EditorDelete();
        }

        public void EditorPaste()
        {
            this.duiWkeBrowser_0.EditorPaste();
        }

        public void EditorSelectAll()
        {
            this.duiWkeBrowser_0.EditorSelectAll();
        }

        public void GoBack()
        {
            this.duiWkeBrowser_0.GoBack();
        }

        public void GoForword()
        {
            this.duiWkeBrowser_0.GoForword();
        }

        public DuiWkeBrowser.JsValue InvokeJS(string js)
        {
            return this.duiWkeBrowser_0.InvokeJS(js);
        }

        public void JsBindFun(string name, DuiWkeBrowser.jsNativeFunction jsf, int argCount)
        {
            this.duiWkeBrowser_0.JsBindFun(name, jsf, argCount);
        }

        public void LoadFile(string fileName)
        {
            this.duiWkeBrowser_0.LoadFile(fileName);
        }

        public void LoadHTML(string html)
        {
            this.duiWkeBrowser_0.LoadHTML(html);
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            this.OnUrlChanged(EventArgs.Empty);
        }

        [CompilerGenerated]
        private void method_7(object sender, DuiWkeBrowser.NavigationEventArgs e)
        {
            this.OnNavigating(e);
        }

        [CompilerGenerated]
        private void method_8(object sender, EventArgs e)
        {
            this.OnDocumentReady(EventArgs.Empty);
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

        protected virtual void OnDocumentReady(EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnLoadingFinish(DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnNavigating(DuiWkeBrowser.NavigationEventArgs e)
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

        public void Reload()
        {
            this.duiWkeBrowser_0.Reload();
        }

        public void StopLoading()
        {
            this.duiWkeBrowser_0.StopLoading();
        }

        [Browsable(false)]
        public bool CanGoBack
        {
            get
            {
                return this.duiWkeBrowser_0.CanGoBack;
            }
        }

        [Browsable(false)]
        public bool CanGoForword
        {
            get
            {
                return this.duiWkeBrowser_0.CanGoForword;
            }
        }

        [Browsable(false)]
        public int ContentsHeight
        {
            get
            {
                return this.ContentsHeight;
            }
        }

        [Browsable(false)]
        public int ContentsWidth
        {
            get
            {
                return this.duiWkeBrowser_0.ContentsWidth;
            }
        }

        [Browsable(false)]
        public string Cookie
        {
            get
            {
                return this.duiWkeBrowser_0.Cookie;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiWkeBrowser();
            }
        }

        [Category("Browser"), DefaultValue(true), Description("是否启用Cookie")]
        public bool EnabledCookie
        {
            get
            {
                return this.duiWkeBrowser_0.EnabledCookie;
            }
            set
            {
                this.duiWkeBrowser_0.EnabledCookie = value;
            }
        }

        [Description("启用背景透明"), DefaultValue(true), Category("Browser")]
        public bool EnabledTransparent
        {
            get
            {
                return this.duiWkeBrowser_0.EnabledTransparent;
            }
            set
            {
                this.duiWkeBrowser_0.EnabledTransparent = value;
            }
        }

        [Browsable(false)]
        public bool IsDocumentReady
        {
            get
            {
                return this.duiWkeBrowser_0.IsDocumentReady;
            }
        }

        [DefaultValue((float) 1f), Category("Browser"), Description("获取或设置媒体音量 0-1")]
        public float MediaVolume
        {
            get
            {
                return this.duiWkeBrowser_0.MediaVolume;
            }
            set
            {
                this.duiWkeBrowser_0.MediaVolume = value;
            }
        }

        [Browsable(false)]
        public string Title
        {
            get
            {
                return this.duiWkeBrowser_0.Title;
            }
        }

        [Category("Browser"), Description("url"), DefaultValue("URL")]
        public string Url
        {
            get
            {
                return this.duiWkeBrowser_0.Url;
            }
            set
            {
                this.duiWkeBrowser_0.Url = value;
            }
        }

        [Browsable(false)]
        public IntPtr WkeCore
        {
            get
            {
                return this.duiWkeBrowser_0.WkeCore;
            }
        }

        [DefaultValue(1), Browsable(false)]
        public float ZoomFactor
        {
            get
            {
                return this.duiWkeBrowser_0.ZoomFactor;
            }
            set
            {
                this.duiWkeBrowser_0.ZoomFactor = value;
            }
        }
    }
}

