namespace DSkin.DirectUI
{
    using DSkin;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiBrowser : DuiBaseControl
    {
        private AlertBoxCallback alertBoxCallback_0;
        private bool bool_27;
        private bool bool_28;
        private ConfirmBoxCallback confirmBoxCallback_0;
        private DSkin.DirectUI.wkeLoadingFinishCallback dbjnnjuAdT;
        private Dictionary<IntPtr, Class20> dictionary_1;
        private float float_1;
        private float float_2;
        private DSkin.DirectUI.wkeConsoleMessageCallback igqnRrShxy;
        private IntPtr intptr_0 = IntPtr.Zero;
        private IntPtr intptr_1;
        private JsCallCallback jsCallCallback_0;
        private object object_38;
        private PromptBoxCallback promptBoxCallback_0;
        private Size size_0;
        private string string_3;
        private string string_4;
        private System.Windows.Forms.Timer timer_0;
        private TitleChangedCallback titleChangedCallback_0;
        private UrlChangedCallback urlChangedCallback_0;
        private DSkin.DirectUI.wkeDocumentReadyCallback wkeDocumentReadyCallback_0;
        private DSkin.DirectUI.wkeNavigationCallback wkeNavigationCallback_0;

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

        public DuiBrowser()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = 0x19
            };
            this.timer_0 = timer;
            this.float_1 = 1f;
            this.string_3 = string.Empty;
            this.string_4 = string.Empty;
            this.dictionary_1 = new Dictionary<IntPtr, Class20>();
            this.bool_27 = true;
            this.float_2 = 1f;
            this.bool_28 = true;
            this.intptr_1 = IntPtr.Zero;
        }

        public void CreateWkeCore()
        {
            this.intptr_0 = EweCore.wkeCreateWebView();
            EweCore.wkeDisableWOFF(false);
            EweCore.wkeResize(this.intptr_0, base.Width, base.Height);
            EweCore.wkeLimitPlugins(this.intptr_0, true);
            this.EnabledTransparent = this.bool_28;
            this.EnabledCookie = this.bool_27;
            this.MediaVolume = this.float_2;
            this.ZoomFactor = this.float_1;
            this.UserAgent = this.string_4;
            EweCore.wkeEnableContextMenu(this.intptr_0, true);
            this.urlChangedCallback_0 = new UrlChangedCallback(this.method_32);
            EweCore.wkeOnURLChanged(this.intptr_0, this.urlChangedCallback_0);
            this.wkeNavigationCallback_0 = new DSkin.DirectUI.wkeNavigationCallback(this.method_33);
            EweCore.wkeOnNavigation(this.intptr_0, this.wkeNavigationCallback_0);
            this.wkeDocumentReadyCallback_0 = new DSkin.DirectUI.wkeDocumentReadyCallback(this.method_31);
            EweCore.wkeOnDocumentReady(this.intptr_0, this.wkeDocumentReadyCallback_0);
            this.dbjnnjuAdT = new DSkin.DirectUI.wkeLoadingFinishCallback(this.method_34);
            EweCore.wkeOnLoadingFinish(this.intptr_0, this.dbjnnjuAdT);
            this.titleChangedCallback_0 = new TitleChangedCallback(this.method_35);
            EweCore.wkeOnTitleChanged(this.intptr_0, this.titleChangedCallback_0);
            this.igqnRrShxy = new DSkin.DirectUI.wkeConsoleMessageCallback(this.method_30);
            EweCore.wkeOnConsoleMessage(this.intptr_0, this.igqnRrShxy);
            this.alertBoxCallback_0 = new AlertBoxCallback(this.method_36);
            EweCore.wkeOnAlertBox(this.intptr_0, this.alertBoxCallback_0);
            this.confirmBoxCallback_0 = new ConfirmBoxCallback(this.method_37);
            EweCore.wkeOnConfirmBox(this.intptr_0, this.confirmBoxCallback_0);
            this.promptBoxCallback_0 = new PromptBoxCallback(this.method_38);
            EweCore.wkeOnPromptBox(this.intptr_0, this.promptBoxCallback_0);
            this.jsCallCallback_0 = new JsCallCallback(this.method_39);
            EweCore.wkeOnJsCall(this.intptr_0, this.jsCallCallback_0);
            EweCore.wkeLoadURL(this.intptr_0, this.string_3);
            this.timer_0.Start();
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.intptr_1 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.intptr_1);
            }
            this.timer_0.Dispose();
            if (this.intptr_0 != IntPtr.Zero)
            {
                try
                {
                    EweCore.wkeDestroyWebView(this.intptr_0);
                }
                catch (Exception)
                {
                }
                this.intptr_0 = IntPtr.Zero;
            }
            EweCore.wkeJSCollectGarbge();
            this.dictionary_1.Clear();
            base.Dispose(disposing);
        }

        public void EditorCopy()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeExecCommand(this.intptr_0, "Copy", "");
            }
        }

        public void EditorCut()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeExecCommand(this.intptr_0, "Cut", "");
            }
        }

        public void EditorDelete()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeExecCommand(this.intptr_0, "Delete", "");
            }
        }

        public void EditorPaste()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeExecCommand(this.intptr_0, "Paste", "");
            }
        }

        public void EditorSelectAll()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeExecCommand(this.intptr_0, "SelectAll", "");
            }
        }

        public void GoBack()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeGoBack(this.intptr_0);
            }
        }

        public void GoForword()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeGoForward(this.intptr_0);
            }
        }

        public DSkin.DirectUI.JsValue InvokeJS(string js)
        {
            return new DSkin.DirectUI.JsValue(EweCore.wkeRunJSW(this.intptr_0, js), EweCore.wkeGlobalExec(this.intptr_0));
        }

        public DSkin.DirectUI.JsValue InvokeJS(IntPtr es, string js)
        {
            return new DSkin.DirectUI.JsValue(EweCore.wkeJSEval(es, js), es);
        }

        public void JsBindFun(string name, DSkin.DirectUI.jsNativeFunction jsf)
        {
            EweCore.wkeJSSimpleBind(EweCore.wkeGlobalExec(this.intptr_0), name, jsf);
        }

        public IntPtr JSGlobalExec()
        {
            return EweCore.wkeGlobalExec(this.intptr_0);
        }

        public void LoadFile(string fileName)
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                this.CreateWkeCore();
            }
            EweCore.wkeLoadFile(this.intptr_0, fileName);
        }

        public void LoadHTML(string html)
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                this.CreateWkeCore();
            }
            EweCore.wkeLoadHTML(this.intptr_0, html);
        }

        private void method_29(IntPtr intptr_2, object object_39)
        {
            if ((object_39 != null) && (this.intptr_0 != IntPtr.Zero))
            {
                Class20 class2;
                System.Type type = object_39.GetType();
                if (this.dictionary_1.TryGetValue(intptr_2, out class2))
                {
                    class2.method_2().Clear();
                }
                else
                {
                    Class20 class5 = new Class20();
                    class5.method_1(object_39);
                    class2 = class5;
                }
                foreach (MethodInfo info in type.GetMethods())
                {
                    foreach (Attribute attribute in info.GetCustomAttributes(true))
                    {
                        GAttribute0 attribute2 = attribute as GAttribute0;
                        if (null != attribute2)
                        {
                            Class21 class3 = new Class21();
                            class3.method_5(info);
                            class3.method_3(object_39);
                            Class21 item = class3;
                            class2.method_2().Add(item);
                            EweCore.wkeJSSimpleBind(intptr_2, info.Name, item.method_0());
                        }
                    }
                }
                if (!((class2.method_2().Count <= 0) || this.dictionary_1.ContainsKey(intptr_2)))
                {
                    this.dictionary_1.Add(intptr_2, class2);
                }
            }
            List<IntPtr> list = new List<IntPtr>();
            using (Dictionary<IntPtr, Class20>.Enumerator enumerator = this.dictionary_1.GetEnumerator())
            {
            Label_0135:
                if (!enumerator.MoveNext())
                {
                    goto Label_0192;
                }
                KeyValuePair<IntPtr, Class20> current = enumerator.Current;
                bool flag = false;
                try
                {
                    flag = EweCore.wkeJSGetWebView(current.Key) == IntPtr.Zero;
                }
                catch (Exception)
                {
                    flag = true;
                }
                goto Label_0179;
            Label_016A:
                list.Add(current.Key);
                goto Label_0135;
            Label_0179:
                if (!flag)
                {
                    goto Label_0135;
                }
                goto Label_016A;
            }
        Label_0192:
            foreach (IntPtr ptr in list)
            {
                this.dictionary_1.Remove(ptr);
            }
        }

        private void method_30(IntPtr intptr_2, ref DSkin.DirectUI.wkeConsoleMessage wkeConsoleMessage_0)
        {
            DSkin.DirectUI.ConsoleMessageEventArgs e = new DSkin.DirectUI.ConsoleMessageEventArgs {
                Level = wkeConsoleMessage_0.level,
                LineNumber = wkeConsoleMessage_0.lineNumber,
                Message = Marshal.PtrToStringUni(wkeConsoleMessage_0.message),
                Source = wkeConsoleMessage_0.source,
                Type = wkeConsoleMessage_0.type,
                Url = Marshal.PtrToStringUni(wkeConsoleMessage_0.url)
            };
            this.OnConsoleMessage(e);
        }

        private void method_31(IntPtr intptr_2, ref DSkin.DirectUI.wkeDocumentReadyInfo wkeDocumentReadyInfo_0)
        {
            DocumentReadyEventArgs e = new DocumentReadyEventArgs {
                Url = Marshal.PtrToStringUni(wkeDocumentReadyInfo_0.url),
                FrameJSState = wkeDocumentReadyInfo_0.frameJSState,
                MainFrameJSState = wkeDocumentReadyInfo_0.mainFrameJSState
            };
            this.OnDocumentReady(e);
            if (e.FrameObject != null)
            {
                this.method_29(wkeDocumentReadyInfo_0.frameJSState, e.FrameObject);
            }
            if (this.object_38 != null)
            {
                this.method_29(wkeDocumentReadyInfo_0.mainFrameJSState, this.object_38);
            }
        }

        [CompilerGenerated]
        private void method_32(IntPtr intptr_2, IntPtr intptr_3)
        {
            this.string_3 = Marshal.PtrToStringUni(intptr_3);
            this.OnUrlChanged(EventArgs.Empty);
            this.dictionary_1.Clear();
        }

        [CompilerGenerated]
        private wkeNavigationAction method_33(IntPtr intptr_2, DSkin.DirectUI.wkeNavigationType wkeNavigationType_0, IntPtr intptr_3)
        {
            DSkin.DirectUI.NavigationEventArgs e = new DSkin.DirectUI.NavigationEventArgs {
                NavigationAction = wkeNavigationAction.WKE_NAVIGATION_CONTINUE,
                NavigationType = wkeNavigationType_0,
                Url = Marshal.PtrToStringUni(intptr_3)
            };
            this.OnNavigating(e);
            return e.NavigationAction;
        }

        [CompilerGenerated]
        private void method_34(IntPtr intptr_2, IntPtr intptr_3, DSkin.DirectUI.wkeLoadingResult wkeLoadingResult_0, IntPtr intptr_4)
        {
            DSkin.DirectUI.LoadingFinishEventArgs e = new DSkin.DirectUI.LoadingFinishEventArgs {
                FailedReason = Marshal.PtrToStringUni(intptr_4),
                LoadingResult = wkeLoadingResult_0,
                Url = Marshal.PtrToStringUni(intptr_3)
            };
            this.OnLoadingFinish(e);
        }

        [CompilerGenerated]
        private void method_35(IntPtr intptr_2, IntPtr intptr_3)
        {
            this.OnTitleChanged(EventArgs.Empty);
        }

        [CompilerGenerated]
        private void method_36(IntPtr intptr_2, IntPtr intptr_3)
        {
            DSkin.DirectUI.AlertBoxEventArgs e = new DSkin.DirectUI.AlertBoxEventArgs {
                Message = Marshal.PtrToStringUni(intptr_3)
            };
            this.OnAlertBox(e);
        }

        [CompilerGenerated]
        private bool method_37(IntPtr intptr_2, IntPtr intptr_3)
        {
            DSkin.DirectUI.ConfirmBoxEventArgs e = new DSkin.DirectUI.ConfirmBoxEventArgs {
                Message = Marshal.PtrToStringUni(intptr_3)
            };
            this.OnConfirmBox(e);
            return e.Yes;
        }

        [CompilerGenerated]
        private bool method_38(IntPtr intptr_2, IntPtr intptr_3, IntPtr intptr_4, IntPtr intptr_5)
        {
            DSkin.DirectUI.PromptBoxEventArgs e = new DSkin.DirectUI.PromptBoxEventArgs {
                Message = Marshal.PtrToStringUni(intptr_3),
                DefaultResult = Marshal.PtrToStringUni(intptr_4),
                Result = Marshal.PtrToStringUni(EweCore.wkeGetWTFString(intptr_5))
            };
            this.OnPromptBox(e);
            EweCore.wkeSetWTFString(intptr_5, e.Result);
            return e.Yes;
        }

        [CompilerGenerated]
        private long method_39(IntPtr intptr_2)
        {
            JsCallEventArgs e = new JsCallEventArgs {
                IntPtr_0 = intptr_2,
                Result = DSkin.DirectUI.JsValue.JsUndefined(intptr_2)
            };
            this.OnJsCall(e);
            return e.Result;
        }

        protected virtual void OnAlertBox(DSkin.DirectUI.AlertBoxEventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected virtual void OnConfirmBox(DSkin.DirectUI.ConfirmBoxEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnConsoleMessage(DSkin.DirectUI.ConsoleMessageEventArgs e)
        {
            Console.WriteLine(string.Concat(new object[] { e.Url, " 在第", e.LineNumber, "行：", e.Message }));
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnDocumentReady(DocumentReadyEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override void OnFocusedChanged(EventArgs e)
        {
            base.OnFocusedChanged(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                if (this.Focused)
                {
                    EweCore.wkeSetFocus(this.intptr_0);
                }
                else
                {
                    EweCore.wkeKillFocus(this.intptr_0);
                }
            }
        }

        protected virtual void OnJsCall(JsCallEventArgs e)
        {
            if (this.eventHandler_9 != null)
            {
                this.eventHandler_9(this, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeFireKeyDownEvent(this.intptr_0, (uint) e.KeyValue, 0, false);
                if (this.HostControl != null)
                {
                    IntPtr handle = this.HostControl.Handle;
                    IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                    if (hIMC != IntPtr.Zero)
                    {
                        DSkin.DirectUI.wkeRect rect = new DSkin.DirectUI.wkeRect();
                        EweCore.wkeGetCaretRect(this.intptr_0, ref rect);
                        Point locationToControl = base.LocationToControl;
                        locationToControl.Offset(rect.x, rect.y + 2);
                        DSkin.NativeMethods.COMPOSITIONFORM lpCompForm = new DSkin.NativeMethods.COMPOSITIONFORM {
                            dwStyle = 2,
                            ptCurrentPos = new DSkin.POINT(locationToControl.X, locationToControl.Y)
                        };
                        DSkin.NativeMethods.ImmSetCompositionWindow(hIMC, ref lpCompForm);
                    }
                    DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                e.Handled = true;
                EweCore.wkeFireKeyPressEvent(this.intptr_0, e.KeyChar, 0, false);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeFireKeyUpEvent(this.intptr_0, (uint) e.KeyValue, 0, false);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.CanFocus = true;
            if (!(base.DesignMode || !(this.intptr_0 == IntPtr.Zero)))
            {
                this.CreateWkeCore();
            }
            base.OnLoad(e);
        }

        protected virtual void OnLoadingFinish(DSkin.DirectUI.LoadingFinishEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            uint message = 0;
            if (e.Button == MouseButtons.Left)
            {
                message = 0x201;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                message = 0x207;
            }
            else if (e.Button == MouseButtons.Right)
            {
                message = 0x204;
            }
            uint flags = smethod_0(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeFireMouseEvent(this.intptr_0, message, e.X, e.Y, flags);
            }
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                uint flags = smethod_0(e);
                EweCore.wkeFireMouseEvent(this.intptr_0, 0x200, e.X, e.Y, flags);
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            uint message = 0;
            if (e.Button == MouseButtons.Left)
            {
                message = 0x202;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                message = 520;
            }
            else if (e.Button == MouseButtons.Right)
            {
                message = 0x205;
            }
            uint flags = smethod_0(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeFireMouseEvent(this.intptr_0, message, e.X, e.Y, flags);
                if (e.Button == MouseButtons.Right)
                {
                    EweCore.wkeContextMenuEvent(this.intptr_0, e.X, e.Y, flags);
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                uint flags = smethod_0(e);
                EweCore.wkeFireMouseWheelEvent(this.intptr_0, e.X, e.Y, e.Delta, flags);
            }
        }

        protected virtual void OnNavigating(DSkin.DirectUI.NavigationEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            base.OnPrePaint(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                if ((this.intptr_1 == IntPtr.Zero) || (this.size_0 != this.Size))
                {
                    if (this.intptr_1 != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(this.intptr_1);
                    }
                    this.size_0 = this.Size;
                    this.intptr_1 = Marshal.AllocHGlobal((int) ((base.Width * base.Height) * 4));
                }
                EweCore.wkePaint(this.intptr_0, this.intptr_1, 0);
                using (Bitmap bitmap = new Bitmap(base.Width, base.Height, base.Width * 4, PixelFormat.Format32bppPArgb, this.intptr_1))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        IntPtr hdc = graphics.GetHdc();
                        EweCore.wkePaintDC(this.intptr_0, hdc);
                        graphics.ReleaseHdc(hdc);
                    }
                    e.Graphics.DrawImage(bitmap, 0, 0);
                }
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Tab:
                    e.IsInputKey = true;
                    break;
            }
        }

        protected virtual void OnPromptBox(DSkin.DirectUI.PromptBoxEventArgs e)
        {
            if (this.eventHandler_8 != null)
            {
                this.eventHandler_8(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeResize(this.intptr_0, base.Width, base.Height);
            }
        }

        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnUrlChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        public void PostURL(string url, byte[] data)
        {
            IntPtr destination = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, destination, data.Length);
            EweCore.wkePostURL(this.intptr_0, url, destination, data.Length);
        }

        public void Reload()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeReload(this.intptr_0);
            }
        }

        private static uint smethod_0(MouseEventArgs mouseEventArgs_0)
        {
            uint num = 0;
            if (mouseEventArgs_0.Button == MouseButtons.Left)
            {
                num |= 1;
            }
            if (mouseEventArgs_0.Button == MouseButtons.Middle)
            {
                num |= 0x10;
            }
            if (mouseEventArgs_0.Button == MouseButtons.Right)
            {
                num |= 2;
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                num |= 8;
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                num |= 4;
            }
            return num;
        }

        public void StopLoading()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                EweCore.wkeStopLoading(this.intptr_0);
            }
        }

        [CompilerGenerated]
        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (base.CanVisible && EweCore.wkeIsDirty(this.intptr_0))
            {
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public bool CanGoBack
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return false;
                }
                return EweCore.wkeCanGoBack(this.intptr_0);
            }
        }

        [Browsable(false)]
        public bool CanGoForword
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return false;
                }
                return EweCore.wkeCanGoForward(this.intptr_0);
            }
        }

        [Browsable(false)]
        public int ContentsHeight
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return 0;
                }
                return EweCore.wkeGetContentHeight(this.intptr_0);
            }
        }

        [Browsable(false)]
        public int ContentsWidth
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return 0;
                }
                return EweCore.wkeGetContentWidth(this.intptr_0);
            }
        }

        [Browsable(false)]
        public string Cookie
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return "";
                }
                return Marshal.PtrToStringUni(EweCore.wkeGetCookieW(this.intptr_0));
            }
        }

        [Category("Browser"), DefaultValue(true), Description("是否启用Cookie")]
        public bool EnabledCookie
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.bool_27;
                }
                return EweCore.wkeIsCookieEnabled(this.intptr_0);
            }
            set
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    this.bool_27 = value;
                }
                else
                {
                    EweCore.wkeSetCookieEnabled(this.intptr_0, value);
                }
            }
        }

        [Description("启用背景透明"), DefaultValue(true), Category("Browser")]
        public bool EnabledTransparent
        {
            get
            {
                return this.bool_28;
            }
            set
            {
                this.bool_28 = value;
                if (this.intptr_0 != IntPtr.Zero)
                {
                    EweCore.wkeSetTransparent(this.intptr_0, value);
                }
            }
        }

        [DefaultValue((string) null), Browsable(false)]
        public object GlobalObject
        {
            get
            {
                return this.object_38;
            }
            set
            {
                this.object_38 = value;
            }
        }

        [Browsable(false)]
        public bool IsLoadComplete
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return false;
                }
                return EweCore.wkeIsLoadComplete(this.intptr_0);
            }
        }

        [Browsable(false)]
        public wkeLoadingStatus LoadingStatus
        {
            get
            {
                if (this.intptr_0 != IntPtr.Zero)
                {
                    return EweCore.wkeGetLoadingStatus(this.intptr_0);
                }
                return wkeLoadingStatus.WKE_STATE_UNINITIALIZED;
            }
        }

        [DefaultValue((float) 1f), Description("获取或设置媒体音量 0-1"), Category("Browser")]
        public float MediaVolume
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.float_2;
                }
                return EweCore.wkeGetMediaVolume(this.intptr_0);
            }
            set
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    this.float_2 = value;
                }
                else
                {
                    EweCore.wkeSetMediaVolume(this.intptr_0, value);
                }
            }
        }

        [Browsable(false)]
        public string Title
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return "";
                }
                return Marshal.PtrToStringUni(EweCore.wkeTitleW(this.intptr_0));
            }
        }

        [DefaultValue("URL"), Description("url"), Category("Browser")]
        public string Url
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
                if (this.intptr_0 != IntPtr.Zero)
                {
                    EweCore.wkeLoadURL(this.intptr_0, value);
                }
            }
        }

        [Description("获取设置浏览器的UserAgent"), Category("Browser"), DefaultValue("")]
        public string UserAgent
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.string_4;
                }
                return Marshal.PtrToStringUni(EweCore.wkeGetUserAgent(this.intptr_0));
            }
            set
            {
                this.string_4 = value;
                EweCore.wkeSetUserAgent(this.intptr_0, value);
            }
        }

        [Browsable(false)]
        public IntPtr WkeCore
        {
            get
            {
                return this.intptr_0;
            }
        }

        [Browsable(false), DefaultValue(1)]
        public float ZoomFactor
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.float_1;
                }
                return EweCore.wkeGetZoomFactor(this.intptr_0);
            }
            set
            {
                this.float_1 = value;
                if (this.intptr_0 != IntPtr.Zero)
                {
                    EweCore.wkeSetZoomFactor(this.intptr_0, value);
                }
            }
        }
    }
}

