namespace DSkin.DirectUI
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiWkeBrowser : DuiBaseControl
    {
        private bool bool_27;
        private bool bool_28;
        private float float_1;
        private IntPtr intptr_0 = IntPtr.Zero;
        private string string_3;
        private System.Windows.Forms.Timer timer_0;
        private wkeAlertBoxCallback wkeAlertBoxCallback_0;
        private wkeConfirmBoxCallback wkeConfirmBoxCallback_0;
        private wkeConsoleMessageCallback wkeConsoleMessageCallback_0;
        private wkeDocumentReadyCallback wkeDocumentReadyCallback_0;
        private wkeLoadingFinishCallback wkeLoadingFinishCallback_0;
        private wkeNavigationCallback wkeNavigationCallback_0;
        private wkePromptBoxCallback wkePromptBoxCallback_0;
        private wkeTitleChangedCallback wkeTitleChangedCallback_0;
        private wkeURLChangedCallback wkeURLChangedCallback_0;

        [Category("Browser")]
        public event EventHandler<AlertBoxEventArgs> AlertBox;

        [Category("Browser")]
        public event EventHandler<ConfirmBoxEventArgs> ConfirmBox;

        [Category("Browser")]
        public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;

        [Category("Browser")]
        public event EventHandler DocumentReady;

        [Category("Browser")]
        public event EventHandler<LoadingFinishEventArgs> LoadingFinish;

        [Category("Browser")]
        public event EventHandler<NavigationEventArgs> Navigating;

        [Category("Browser")]
        public event EventHandler<PromptBoxEventArgs> PromptBox;

        [Category("Browser")]
        public event EventHandler TitleChanged;

        [Category("Browser")]
        public event EventHandler UrlChanged;

        static DuiWkeBrowser()
        {
            if (File.Exists("wke.dll"))
            {
                wkeInitialize();
            }
        }

        public DuiWkeBrowser()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = 0x19
            };
            this.timer_0 = timer;
            this.string_3 = string.Empty;
            this.bool_27 = true;
            this.float_1 = 1f;
            this.bool_28 = true;
        }

        public void CreateWkeCore()
        {
            this.intptr_0 = wkeCreateWebView();
            wkeResize(this.intptr_0, base.Width, base.Height);
            wkeSetTransparent(this.intptr_0, this.bool_28);
            this.EnabledCookie = this.bool_27;
            this.MediaVolume = this.float_1;
            this.wkeURLChangedCallback_0 = new wkeURLChangedCallback(this.method_31);
            wkeOnURLChanged(this.intptr_0, this.wkeURLChangedCallback_0, IntPtr.Zero);
            this.wkeNavigationCallback_0 = new wkeNavigationCallback(this.method_32);
            wkeOnNavigation(this.intptr_0, this.wkeNavigationCallback_0, IntPtr.Zero);
            this.wkeDocumentReadyCallback_0 = new wkeDocumentReadyCallback(this.method_30);
            wkeOnDocumentReady(this.intptr_0, this.wkeDocumentReadyCallback_0, IntPtr.Zero);
            this.wkeLoadingFinishCallback_0 = new wkeLoadingFinishCallback(this.method_33);
            wkeOnLoadingFinish(this.intptr_0, this.wkeLoadingFinishCallback_0, IntPtr.Zero);
            this.wkeTitleChangedCallback_0 = new wkeTitleChangedCallback(this.method_34);
            wkeOnTitleChanged(this.intptr_0, this.wkeTitleChangedCallback_0, IntPtr.Zero);
            this.wkeConsoleMessageCallback_0 = new wkeConsoleMessageCallback(this.method_29);
            wkeOnConsoleMessage(this.intptr_0, this.wkeConsoleMessageCallback_0, IntPtr.Zero);
            this.wkeAlertBoxCallback_0 = new wkeAlertBoxCallback(this.method_35);
            wkeOnAlertBox(this.intptr_0, this.wkeAlertBoxCallback_0, IntPtr.Zero);
            this.wkeConfirmBoxCallback_0 = new wkeConfirmBoxCallback(this.method_36);
            wkeOnConfirmBox(this.intptr_0, this.wkeConfirmBoxCallback_0, IntPtr.Zero);
            this.wkePromptBoxCallback_0 = new wkePromptBoxCallback(this.method_37);
            wkeOnPromptBox(this.intptr_0, this.wkePromptBoxCallback_0, IntPtr.Zero);
            wkeLoadURL(this.intptr_0, this.string_3);
            this.timer_0.Start();
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        protected override void Dispose(bool disposing)
        {
            this.timer_0.Dispose();
            if (this.intptr_0 != IntPtr.Zero)
            {
                try
                {
                    wkeDestroyWebView(this.intptr_0);
                }
                catch (Exception)
                {
                }
                this.intptr_0 = IntPtr.Zero;
            }
            base.Dispose(disposing);
        }

        public void EditorCopy()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeEditorCopy(this.intptr_0);
            }
        }

        public void EditorCut()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeEditorCut(this.intptr_0);
            }
        }

        public void EditorDelete()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeEditorDelete(this.intptr_0);
            }
        }

        public void EditorPaste()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeEditorPaste(this.intptr_0);
            }
        }

        public void EditorSelectAll()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeEditorSelectAll(this.intptr_0);
            }
        }

        public void GoBack()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeGoBack(this.intptr_0);
            }
        }

        public void GoForword()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeGoForward(this.intptr_0);
            }
        }

        public JsValue InvokeJS(string js)
        {
            return new JsValue(wkeRunJSW(this.intptr_0, js), wkeGlobalExec(this.intptr_0));
        }

        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsArg(IntPtr es, int argIdx);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int jsArgCount(IntPtr es);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern jsType jsArgType(IntPtr es, int argIdx);
        public void JsBindFun(string name, jsNativeFunction jsf, int argCount)
        {
            jsBindFunction(name, jsf, (uint) argCount);
        }

        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsBindFunction(string name, jsNativeFunction fn, uint argCount);
        [DllImport("wke.dll")]
        public static extern void jsBindGetter(string name, jsNativeFunction fn);
        [DllImport("wke.dll")]
        public static extern void jsBindSetter(string name, jsNativeFunction fn);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsBoolean([MarshalAs(UnmanagedType.I1)] bool b);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsCall(IntPtr es, long func, long thisObject, ref long args, int argCount);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsCallGlobal(IntPtr es, long func, ref long args, int argCount);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsDouble(double d);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsEmptyArray(IntPtr es);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsEmptyObject(IntPtr es);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsEval(IntPtr es, [In, MarshalAs(UnmanagedType.LPStr)] string str);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsEvalW(IntPtr es, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsFalse();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsFloat(float f);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsFunction(IntPtr es, ref tagjsData obj);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsGC();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsGet(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPStr)] string prop);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsGetAt(IntPtr es, long @object, int index);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr jsGetData(IntPtr es, long @object);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsGetGlobal(IntPtr es, [In, MarshalAs(UnmanagedType.LPStr)] string prop);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int jsGetLength(IntPtr es, long @object);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr jsGetWebView(IntPtr es);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsGlobalObject(IntPtr es);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsInt(int n);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsArray(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsBoolean(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsFalse(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsFunction(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsNull(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsNumber(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsObject(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsString(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsTrue(long v);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsIsUndefined(long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsNull();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsObject(IntPtr es, ref tagjsData obj);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsSet(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPStr)] string prop, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsSetAt(IntPtr es, long @object, int index, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsSetGlobal(IntPtr es, [In, MarshalAs(UnmanagedType.LPStr)] string prop, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void jsSetLength(IntPtr es, long @object, int length);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsString(IntPtr es, [In, MarshalAs(UnmanagedType.LPStr)] string str);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsStringW(IntPtr es, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool jsToBoolean(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern double jsToDouble(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern float jsToFloat(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int jsToInt(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr jsToTempString(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr jsToTempStringW(IntPtr es, long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsTrue();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern jsType jsTypeOf(long v);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long jsUndefined();
        public void LoadFile(string fileName)
        {
            wkeLoadFileW(this.intptr_0, fileName);
        }

        public void LoadHTML(string html)
        {
            wkeLoadHTMLW(this.intptr_0, html);
        }

        private void method_29(IntPtr intptr_1, IntPtr intptr_2, ref wkeConsoleMessage wkeConsoleMessage_0)
        {
            ConsoleMessageEventArgs e = new ConsoleMessageEventArgs {
                Level = wkeConsoleMessage_0.level,
                LineNumber = wkeConsoleMessage_0.lineNumber,
                Message = Marshal.PtrToStringUni(wkeGetStringW(wkeConsoleMessage_0.message)),
                Source = wkeConsoleMessage_0.source,
                Type = wkeConsoleMessage_0.type,
                Url = Marshal.PtrToStringUni(wkeGetStringW(wkeConsoleMessage_0.url))
            };
            this.OnConsoleMessage(e);
        }

        private void method_30(IntPtr intptr_1, IntPtr intptr_2, ref wkeDocumentReadyInfo wkeDocumentReadyInfo_0)
        {
            this.OnDocumentReady(EventArgs.Empty);
        }

        [CompilerGenerated]
        private void method_31(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3)
        {
            this.string_3 = Marshal.PtrToStringUni(wkeGetStringW(intptr_3));
            this.OnUrlChanged(EventArgs.Empty);
        }

        [CompilerGenerated]
        private bool method_32(IntPtr intptr_1, IntPtr intptr_2, wkeNavigationType wkeNavigationType_0, IntPtr intptr_3)
        {
            NavigationEventArgs e = new NavigationEventArgs {
                Cancel = false,
                NavigationType = wkeNavigationType_0,
                Url = Marshal.PtrToStringUni(wkeGetStringW(intptr_3))
            };
            this.OnNavigating(e);
            return !e.Cancel;
        }

        [CompilerGenerated]
        private void method_33(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, wkeLoadingResult wkeLoadingResult_0, IntPtr intptr_4)
        {
            LoadingFinishEventArgs e = new LoadingFinishEventArgs {
                FailedReason = Marshal.PtrToStringUni(wkeGetStringW(intptr_4)),
                LoadingResult = wkeLoadingResult_0,
                Url = Marshal.PtrToStringUni(wkeGetStringW(intptr_3))
            };
            this.OnLoadingFinish(e);
        }

        [CompilerGenerated]
        private void method_34(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3)
        {
            this.OnTitleChanged(EventArgs.Empty);
        }

        [CompilerGenerated]
        private void method_35(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3)
        {
            AlertBoxEventArgs e = new AlertBoxEventArgs {
                Message = Marshal.PtrToStringUni(wkeGetStringW(intptr_3))
            };
            this.OnAlertBox(e);
        }

        [CompilerGenerated]
        private bool method_36(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3)
        {
            ConfirmBoxEventArgs e = new ConfirmBoxEventArgs {
                Message = Marshal.PtrToStringUni(wkeGetStringW(intptr_3))
            };
            this.OnConfirmBox(e);
            return e.Yes;
        }

        [CompilerGenerated]
        private bool method_37(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, IntPtr intptr_4, IntPtr intptr_5)
        {
            PromptBoxEventArgs e = new PromptBoxEventArgs {
                Message = Marshal.PtrToStringUni(wkeGetStringW(intptr_3)),
                DefaultResult = Marshal.PtrToStringUni(wkeGetStringW(intptr_4)),
                Result = Marshal.PtrToStringUni(wkeGetStringW(intptr_5))
            };
            this.OnPromptBox(e);
            return e.Yes;
        }

        protected virtual void OnAlertBox(AlertBoxEventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected virtual void OnConfirmBox(ConfirmBoxEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnConsoleMessage(ConsoleMessageEventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnDocumentReady(EventArgs e)
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
                    wkeSetFocus(this.intptr_0);
                }
                else
                {
                    wkeKillFocus(this.intptr_0);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeFireKeyDownEvent(this.intptr_0, (uint) e.KeyValue, 0, false);
                if (this.HostControl != null)
                {
                    IntPtr handle = this.HostControl.Handle;
                    IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                    if (hIMC != IntPtr.Zero)
                    {
                        wkeRect rect = wkeGetCaretRect(this.intptr_0);
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
                wkeFireKeyPressEvent(this.intptr_0, e.KeyChar, 0, false);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeFireKeyUpEvent(this.intptr_0, (uint) e.KeyValue, 0, false);
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

        protected virtual void OnLoadingFinish(LoadingFinishEventArgs e)
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
                wkeFireMouseEvent(this.intptr_0, message, e.X, e.Y, flags);
            }
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                uint flags = smethod_0(e);
                wkeFireMouseEvent(this.intptr_0, 0x200, e.X, e.Y, flags);
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
                wkeFireMouseEvent(this.intptr_0, message, e.X, e.Y, flags);
                if (e.Button == MouseButtons.Right)
                {
                    wkeFireContextMenuEvent(this.intptr_0, e.X, e.Y, flags);
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.intptr_0 != IntPtr.Zero)
            {
                uint flags = smethod_0(e);
                wkeFireMouseWheelEvent(this.intptr_0, e.X, e.Y, e.Delta, flags);
            }
        }

        protected virtual void OnNavigating(NavigationEventArgs e)
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
                int nXOriginDest = ((int) e.Graphics.Transform.OffsetX) + e.ClipRectangle.X;
                int nYOriginDest = ((int) e.Graphics.Transform.OffsetY) + e.ClipRectangle.Y;
                IntPtr hdc = e.Graphics.GetHdc();
                DSkin.NativeMethods.BLENDFUNCTION blendFunction = new DSkin.NativeMethods.BLENDFUNCTION {
                    BlendOp = 0,
                    BlendFlags = 0,
                    SourceConstantAlpha = 0xff,
                    AlphaFormat = 1
                };
                DSkin.NativeMethods.GdiAlphaBlend(hdc, nXOriginDest, nYOriginDest, e.ClipRectangle.Width, e.ClipRectangle.Height, wkeGetViewDC(this.intptr_0), e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height, blendFunction);
                e.Graphics.ReleaseHdc(hdc);
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

        protected virtual void OnPromptBox(PromptBoxEventArgs e)
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
                wkeResize(this.intptr_0, base.Width, base.Height);
                wkeRepaintIfNeeded(this.intptr_0);
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

        public void Reload()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                wkeReload(this.intptr_0);
            }
        }

        private static uint smethod_0(MouseEventArgs mouseEventArgs_0)
        {
            uint num = 0;
            if (mouseEventArgs_0.Button == MouseButtons.Left)
            {
                num = 1;
            }
            else if (mouseEventArgs_0.Button == MouseButtons.Middle)
            {
                num = 0x10;
            }
            else if (mouseEventArgs_0.Button == MouseButtons.Right)
            {
                num = 2;
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
                wkeStopLoading(this.intptr_0);
            }
        }

        [CompilerGenerated]
        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (!(!base.CanVisible || wkeRepaintIfNeeded(this.intptr_0)))
            {
                this.Invalidate();
            }
        }

        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeAddDirtyArea(IntPtr webView, int x, int y, int w, int h);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeCanGoBack(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeCanGoForward(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeConfigure(ref wkeSettings settings);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeCreateWebView();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeCreateWebWindow(wkeWindowType type, IntPtr parent, int x, int y, int width, int height);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeDestroyWebView(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeDestroyWebWindow(IntPtr webWindow);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEditorCopy(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEditorCut(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEditorDelete(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEditorPaste(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEditorSelectAll(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeEnableWindow(IntPtr webWindow, [MarshalAs(UnmanagedType.I1)] bool enable);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeFinalize();
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireContextMenuEvent(IntPtr webView, int x, int y, uint flags);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireKeyDownEvent(IntPtr webView, uint virtualKeyCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireKeyPressEvent(IntPtr webView, uint charCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireKeyUpEvent(IntPtr webView, uint virtualKeyCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireMouseEvent(IntPtr webView, uint message, int x, int y, uint flags);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeFireMouseWheelEvent(IntPtr webView, int x, int y, int delta, uint flags);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern wkeRect wkeGetCaretRect(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int wkeGetContentHeight(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int wkeGetContentWidth(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetCookie(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetCookieW(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int wkeGetHeight(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetHostWindow(IntPtr webWindow);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern float wkeGetMediaVolume(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetName(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetString(IntPtr @string);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetStringW(IntPtr @string);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetTitle(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetTitleW(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern uint wkeGetVersion();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetVersionString();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetViewDC(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetWebView([In, MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern int wkeGetWidth(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGetWindowHandle(IntPtr webWindow);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern float wkeGetZoomFactor(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr wkeGlobalExec(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeGoBack(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeGoForward(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeInitialize();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeInitializeEx(ref wkeSettings settings);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsAwake(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsCookieEnabled(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsDirty(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsDocumentReady(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsLoading(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsLoadingCompleted(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsLoadingFailed(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsLoadingSucceeded(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeIsTransparent(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeKillFocus(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLayoutIfNeeded(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoad(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string str);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadFile(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadFileW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string filename);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadHTML(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string html);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadHTMLW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string html);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadURL(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string url);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadURLW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string url);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeLoadW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeMoveToCenter(IntPtr webWindow);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeMoveWindow(IntPtr webWindow, int x, int y, int width, int height);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnAlertBox(IntPtr webView, wkeAlertBoxCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnConfirmBox(IntPtr webView, wkeConfirmBoxCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnConsoleMessage(IntPtr webView, wkeConsoleMessageCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnCreateView(IntPtr webView, wkeCreateViewCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnDocumentReady(IntPtr webView, wkeDocumentReadyCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnLoadingFinish(IntPtr webView, wkeLoadingFinishCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnNavigation(IntPtr webView, wkeNavigationCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnPaintUpdated(IntPtr webView, wkePaintUpdatedCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnPromptBox(IntPtr webView, wkePromptBoxCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnTitleChanged(IntPtr webView, wkeTitleChangedCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnURLChanged(IntPtr webView, wkeURLChangedCallback callback, IntPtr callbackParam);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnWindowClosing(IntPtr webWindow, wkeWindowClosingCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeOnWindowDestroy(IntPtr webWindow, wkeWindowDestroyCallback callback, IntPtr param);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkePaint(IntPtr webView, IntPtr bits, int bufWid, int bufHei, int xDst, int yDst, int w, int h, int xSrc, int ySrc, [MarshalAs(UnmanagedType.I1)] bool bCopyAlpha);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkePaint2(IntPtr webView, IntPtr bits, int pitch);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkePostURL(IntPtr wkeView, [In, MarshalAs(UnmanagedType.LPStr)] string url, [In, MarshalAs(UnmanagedType.LPStr)] string postData, int postLen);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkePostURLW(IntPtr wkeView, [In, MarshalAs(UnmanagedType.LPWStr)] string url, [In, MarshalAs(UnmanagedType.LPStr)] string postData, int postLen);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeReload(IntPtr webView);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern bool wkeRepaintIfNeeded(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeResize(IntPtr webView, int w, int h);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeResizeWindow(IntPtr webWindow, int width, int height);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long wkeRunJS(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string script);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern long wkeRunJSW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string script);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetCookieEnabled(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool enable);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetDirty(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool dirty);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetEditable(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool editable);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetFileSystem(FILE_OPEN pfn_open, FILE_CLOSE pfn_close, FILE_SIZE pfn_size, FILE_READ pfn_read, FILE_SEEK pfn_seek);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetFocus(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetHostWindow(IntPtr webWindow, IntPtr hostWindow);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetMediaVolume(IntPtr webView, float volume);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetName(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetString(IntPtr @string, [In, MarshalAs(UnmanagedType.LPStr)] string str, [MarshalAs(UnmanagedType.SysUInt)] uint len);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetStringW(IntPtr @string, [In, MarshalAs(UnmanagedType.LPWStr)] string str, [MarshalAs(UnmanagedType.SysUInt)] uint len);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetTransparent(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool transparent);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetUserAgent(IntPtr webView, [In, MarshalAs(UnmanagedType.LPStr)] string userAgent);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetUserAgentW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string userAgent);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetWindowTitle(IntPtr webWindow, [In, MarshalAs(UnmanagedType.LPStr)] string title);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetWindowTitleW(IntPtr webWindow, [In, MarshalAs(UnmanagedType.LPWStr)] string title);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSetZoomFactor(IntPtr webView, float factor);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeShowWindow(IntPtr webWindow, [MarshalAs(UnmanagedType.I1)] bool show);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeSleep(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeStopLoading(IntPtr webView);
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeUpdate();
        [DllImport("wke.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void wkeWake(IntPtr webView);

        [Browsable(false)]
        public bool CanGoBack
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return false;
                }
                return wkeCanGoBack(this.intptr_0);
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
                return wkeCanGoForward(this.intptr_0);
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
                return wkeGetContentHeight(this.intptr_0);
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
                return wkeGetContentWidth(this.intptr_0);
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
                return Marshal.PtrToStringUni(wkeGetCookieW(this.intptr_0));
            }
        }

        [Description("是否启用Cookie"), Category("Browser"), DefaultValue(true)]
        public bool EnabledCookie
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.bool_27;
                }
                return wkeIsCookieEnabled(this.intptr_0);
            }
            set
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    this.bool_27 = value;
                }
                else
                {
                    wkeSetCookieEnabled(this.intptr_0, value);
                }
            }
        }

        [Description("启用背景透明"), Category("Browser"), DefaultValue(true)]
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
                    wkeSetTransparent(this.intptr_0, value);
                }
            }
        }

        [Browsable(false)]
        public bool IsDocumentReady
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return false;
                }
                return wkeIsDocumentReady(this.intptr_0);
            }
        }

        [Description("获取或设置媒体音量 0-1"), Category("Browser"), DefaultValue((float) 1f)]
        public float MediaVolume
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return this.float_1;
                }
                return wkeGetMediaVolume(this.intptr_0);
            }
            set
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    this.float_1 = value;
                }
                else
                {
                    wkeSetMediaVolume(this.intptr_0, value);
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
                return Marshal.PtrToStringUni(wkeGetTitleW(this.intptr_0));
            }
        }

        [Description("url"), DefaultValue("URL"), Category("Browser")]
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
                    wkeLoadURLW(this.intptr_0, value);
                }
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
                    return 1f;
                }
                return wkeGetZoomFactor(this.intptr_0);
            }
            set
            {
                if (this.intptr_0 != IntPtr.Zero)
                {
                    wkeSetZoomFactor(this.intptr_0, value);
                }
            }
        }

        public class AlertBoxEventArgs : EventArgs
        {
            [CompilerGenerated]
            private string string_0;

            public string Message
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }
        }

        public class ConfirmBoxEventArgs : EventArgs
        {
            [CompilerGenerated]
            private bool bool_0;
            [CompilerGenerated]
            private string string_0;

            public string Message
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }

            public bool Yes
            {
                [CompilerGenerated]
                get
                {
                    return this.bool_0;
                }
                [CompilerGenerated]
                set
                {
                    this.bool_0 = value;
                }
            }
        }

        public class ConsoleMessageEventArgs : EventArgs
        {
            [CompilerGenerated]
            private string string_0;
            [CompilerGenerated]
            private string string_1;
            [CompilerGenerated]
            private uint uint_0;
            [CompilerGenerated]
            private DuiWkeBrowser.wkeMessageLevel wkeMessageLevel_0;
            [CompilerGenerated]
            private DuiWkeBrowser.wkeMessageSource wkeMessageSource_0;
            [CompilerGenerated]
            private DuiWkeBrowser.wkeMessageType wkeMessageType_0;

            public DuiWkeBrowser.wkeMessageLevel Level
            {
                [CompilerGenerated]
                get
                {
                    return this.wkeMessageLevel_0;
                }
                [CompilerGenerated]
                set
                {
                    this.wkeMessageLevel_0 = value;
                }
            }

            public uint LineNumber
            {
                [CompilerGenerated]
                get
                {
                    return this.uint_0;
                }
                [CompilerGenerated]
                set
                {
                    this.uint_0 = value;
                }
            }

            public string Message
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }

            public DuiWkeBrowser.wkeMessageSource Source
            {
                [CompilerGenerated]
                get
                {
                    return this.wkeMessageSource_0;
                }
                [CompilerGenerated]
                set
                {
                    this.wkeMessageSource_0 = value;
                }
            }

            public DuiWkeBrowser.wkeMessageType Type
            {
                [CompilerGenerated]
                get
                {
                    return this.wkeMessageType_0;
                }
                [CompilerGenerated]
                set
                {
                    this.wkeMessageType_0 = value;
                }
            }

            public string Url
            {
                [CompilerGenerated]
                get
                {
                    return this.string_1;
                }
                [CompilerGenerated]
                set
                {
                    this.string_1 = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FILE_CLOSE(IntPtr handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr FILE_OPEN([In, MarshalAs(UnmanagedType.LPStr)] string path);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int FILE_READ(IntPtr handle, IntPtr buffer, IntPtr size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int FILE_SEEK(IntPtr handle, int offset, int origin);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint FILE_SIZE(IntPtr handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long jsCallAsFunctionCallback(IntPtr es, long @object, ref long args, int argCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void jsFinalizeCallback(ref DuiWkeBrowser.tagjsData data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long jsGetPropertyCallback(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPStr)] string propertyName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate long jsNativeFunction(IntPtr es);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool jsSetPropertyCallback(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPStr)] string propertyName, long value);

        public enum jsType
        {
            JSTYPE_NUMBER,
            JSTYPE_STRING,
            JSTYPE_BOOLEAN,
            JSTYPE_OBJECT,
            JSTYPE_FUNCTION,
            JSTYPE_UNDEFINED
        }

        public class JsValue
        {
            private IntPtr intptr_0;
            private long long_0;

            public JsValue(long value, IntPtr jsExecState)
            {
                this.long_0 = value;
                this.intptr_0 = jsExecState;
            }

            public JsValue(IntPtr jsExecState, int argIndex)
            {
                this.intptr_0 = jsExecState;
                this.long_0 = DuiWkeBrowser.jsArg(this.intptr_0, argIndex);
            }

            public static int ArgCount(IntPtr jsExecState)
            {
                return DuiWkeBrowser.jsArgCount(jsExecState);
            }

            public static long JsDouble(double d)
            {
                return DuiWkeBrowser.jsDouble(d);
            }

            public static long JsFalse()
            {
                return DuiWkeBrowser.jsFalse();
            }

            public static long JsFloat(float f)
            {
                return DuiWkeBrowser.jsFloat(f);
            }

            public static long JsInt(int n)
            {
                return DuiWkeBrowser.jsInt(n);
            }

            public static long JsNull()
            {
                return DuiWkeBrowser.jsNull();
            }

            public static long JsString(IntPtr jsExecState, string str)
            {
                return DuiWkeBrowser.jsStringW(jsExecState, str);
            }

            public static long JsTrue()
            {
                return DuiWkeBrowser.jsTrue();
            }

            public static long JsUndefined()
            {
                return DuiWkeBrowser.jsUndefined();
            }

            public bool ToBool()
            {
                return DuiWkeBrowser.jsToBoolean(this.intptr_0, this.long_0);
            }

            public double ToDouble()
            {
                return DuiWkeBrowser.jsToDouble(this.intptr_0, this.long_0);
            }

            public float ToFloat()
            {
                return DuiWkeBrowser.jsToFloat(this.intptr_0, this.long_0);
            }

            public int ToInt()
            {
                return DuiWkeBrowser.jsToInt(this.intptr_0, this.long_0);
            }

            public override string ToString()
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    return string.Empty;
                }
                return Marshal.PtrToStringUni(DuiWkeBrowser.jsToTempStringW(this.intptr_0, this.long_0));
            }

            public DuiWkeBrowser.jsType JsType
            {
                get
                {
                    return DuiWkeBrowser.jsTypeOf(this.long_0);
                }
            }

            public long Value
            {
                get
                {
                    return this.long_0;
                }
            }
        }

        public class LoadingFinishEventArgs : EventArgs
        {
            [CompilerGenerated]
            private string string_0;
            [CompilerGenerated]
            private string string_1;
            [CompilerGenerated]
            private DuiWkeBrowser.wkeLoadingResult wkeLoadingResult_0;

            public string FailedReason
            {
                [CompilerGenerated]
                get
                {
                    return this.string_1;
                }
                [CompilerGenerated]
                set
                {
                    this.string_1 = value;
                }
            }

            public DuiWkeBrowser.wkeLoadingResult LoadingResult
            {
                [CompilerGenerated]
                get
                {
                    return this.wkeLoadingResult_0;
                }
                [CompilerGenerated]
                set
                {
                    this.wkeLoadingResult_0 = value;
                }
            }

            public string Url
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }
        }

        public class NavigationEventArgs : EventArgs
        {
            [CompilerGenerated]
            private bool bool_0;
            [CompilerGenerated]
            private string string_0;
            [CompilerGenerated]
            private DuiWkeBrowser.wkeNavigationType wkeNavigationType_0;

            public bool Cancel
            {
                [CompilerGenerated]
                get
                {
                    return this.bool_0;
                }
                [CompilerGenerated]
                set
                {
                    this.bool_0 = value;
                }
            }

            public DuiWkeBrowser.wkeNavigationType NavigationType
            {
                [CompilerGenerated]
                get
                {
                    return this.wkeNavigationType_0;
                }
                [CompilerGenerated]
                set
                {
                    this.wkeNavigationType_0 = value;
                }
            }

            public string Url
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }
        }

        public class PromptBoxEventArgs : EventArgs
        {
            [CompilerGenerated]
            private bool bool_0;
            [CompilerGenerated]
            private string string_0;
            [CompilerGenerated]
            private string string_1;
            [CompilerGenerated]
            private string string_2;

            public string DefaultResult
            {
                [CompilerGenerated]
                get
                {
                    return this.string_2;
                }
                [CompilerGenerated]
                set
                {
                    this.string_2 = value;
                }
            }

            public string Message
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }

            public string Result
            {
                [CompilerGenerated]
                get
                {
                    return this.string_1;
                }
                [CompilerGenerated]
                set
                {
                    this.string_1 = value;
                }
            }

            public bool Yes
            {
                [CompilerGenerated]
                get
                {
                    return this.bool_0;
                }
                [CompilerGenerated]
                set
                {
                    this.bool_0 = value;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagjsData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=100)]
            public string typeName;
            public DuiWkeBrowser.jsGetPropertyCallback propertyGet;
            public DuiWkeBrowser.jsSetPropertyCallback propertySet;
            public DuiWkeBrowser.jsFinalizeCallback finalize;
            public DuiWkeBrowser.jsCallAsFunctionCallback callAsFunction;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeAlertBoxCallback(IntPtr webView, IntPtr param, IntPtr msg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool wkeConfirmBoxCallback(IntPtr webView, IntPtr param, IntPtr msg);

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeConsoleMessage
        {
            public DuiWkeBrowser.wkeMessageSource source;
            public DuiWkeBrowser.wkeMessageType type;
            public DuiWkeBrowser.wkeMessageLevel level;
            public IntPtr message;
            public IntPtr url;
            public uint lineNumber;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeConsoleMessageCallback(IntPtr webView, IntPtr param, ref DuiWkeBrowser.wkeConsoleMessage message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr wkeCreateViewCallback(IntPtr webView, IntPtr param, ref DuiWkeBrowser.wkeNewViewInfo info);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeDocumentReadyCallback(IntPtr webView, IntPtr param, ref DuiWkeBrowser.wkeDocumentReadyInfo info);

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeDocumentReadyInfo
        {
            public IntPtr url;
            public IntPtr frameJSState;
            public IntPtr mainFrameJSState;
        }

        public enum wkeKeyFlags
        {
            WKE_EXTENDED = 0x100,
            WKE_REPEAT = 0x4000
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeLoadingFinishCallback(IntPtr webView, IntPtr param, IntPtr url, DuiWkeBrowser.wkeLoadingResult result, IntPtr failedReason);

        public enum wkeLoadingResult
        {
            WKE_LOADING_SUCCEEDED,
            WKE_LOADING_FAILED,
            WKE_LOADING_CANCELED
        }

        public enum wkeMessageLevel
        {
            WKE_MESSAGE_LEVEL_TIP,
            WKE_MESSAGE_LEVEL_LOG,
            WKE_MESSAGE_LEVEL_WARNING,
            WKE_MESSAGE_LEVEL_ERROR,
            WKE_MESSAGE_LEVEL_DEBUG
        }

        public enum wkeMessageSource
        {
            WKE_MESSAGE_SOURCE_HTML,
            WKE_MESSAGE_SOURCE_XML,
            WKE_MESSAGE_SOURCE_JS,
            WKE_MESSAGE_SOURCE_NETWORK,
            WKE_MESSAGE_SOURCE_CONSOLE_API,
            WKE_MESSAGE_SOURCE_OTHER
        }

        public enum wkeMessageType
        {
            WKE_MESSAGE_TYPE_LOG,
            WKE_MESSAGE_TYPE_DIR,
            WKE_MESSAGE_TYPE_DIR_XML,
            WKE_MESSAGE_TYPE_TRACE,
            WKE_MESSAGE_TYPE_START_GROUP,
            WKE_MESSAGE_TYPE_START_GROUP_COLLAPSED,
            WKE_MESSAGE_TYPE_END_GROUP,
            WKE_MESSAGE_TYPE_ASSERT
        }

        public enum wkeMouseFlags
        {
            WKE_CONTROL = 8,
            WKE_LBUTTON = 1,
            WKE_MBUTTON = 0x10,
            WKE_RBUTTON = 2,
            WKE_SHIFT = 4
        }

        public enum wkeMouseMsg
        {
            WKE_MSG_LBUTTONDBLCLK = 0x203,
            WKE_MSG_LBUTTONDOWN = 0x201,
            WKE_MSG_LBUTTONUP = 0x202,
            WKE_MSG_MBUTTONDBLCLK = 0x209,
            WKE_MSG_MBUTTONDOWN = 0x207,
            WKE_MSG_MBUTTONUP = 520,
            WKE_MSG_MOUSEMOVE = 0x200,
            WKE_MSG_MOUSEWHEEL = 0x20a,
            WKE_MSG_RBUTTONDBLCLK = 0x206,
            WKE_MSG_RBUTTONDOWN = 0x204,
            WKE_MSG_RBUTTONUP = 0x205
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool wkeNavigationCallback(IntPtr webView, IntPtr param, DuiWkeBrowser.wkeNavigationType navigationType, IntPtr url);

        public enum wkeNavigationType
        {
            WKE_NAVIGATION_TYPE_LINKCLICK,
            WKE_NAVIGATION_TYPE_FORMSUBMITTE,
            WKE_NAVIGATION_TYPE_BACKFORWARD,
            WKE_NAVIGATION_TYPE_RELOAD,
            WKE_NAVIGATION_TYPE_FORMRESUBMITT,
            WKE_NAVIGATION_TYPE_OTHER
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeNewViewInfo
        {
            public DuiWkeBrowser.wkeNavigationType navigationType;
            public IntPtr url;
            public IntPtr target;
            public int x;
            public int y;
            public int width;
            public int height;
            [MarshalAs(UnmanagedType.I1)]
            public bool menuBarVisible;
            [MarshalAs(UnmanagedType.I1)]
            public bool statusBarVisible;
            [MarshalAs(UnmanagedType.I1)]
            public bool toolBarVisible;
            [MarshalAs(UnmanagedType.I1)]
            public bool locationBarVisible;
            [MarshalAs(UnmanagedType.I1)]
            public bool scrollbarsVisible;
            [MarshalAs(UnmanagedType.I1)]
            public bool resizable;
            [MarshalAs(UnmanagedType.I1)]
            public bool fullscreen;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkePaintUpdatedCallback(IntPtr webView, IntPtr param, IntPtr hdc, int x, int y, int cx, int cy);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool wkePromptBoxCallback(IntPtr webView, IntPtr param, IntPtr msg, IntPtr defaultResult, IntPtr result);

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeProxy
        {
            public DuiWkeBrowser.wkeProxyType type;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=100)]
            public string hostname;
            public ushort port;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=50)]
            public string username;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=50)]
            public string password;
        }

        public enum wkeProxyType
        {
            WKE_PROXY_NONE,
            WKE_PROXY_HTTP,
            WKE_PROXY_SOCKS4,
            WKE_PROXY_SOCKS4A,
            WKE_PROXY_SOCKS5,
            WKE_PROXY_SOCKS5HOSTNAME
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeRect
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public Rectangle ToRectangle()
            {
                return new Rectangle(this.x, this.y, this.w, this.h);
            }
        }

        public enum wkeSettingMask
        {
            WKE_SETTING_PROXY = 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct wkeSettings
        {
            public DuiWkeBrowser.wkeProxy proxy;
            public uint mask;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeTitleChangedCallback(IntPtr webView, IntPtr param, IntPtr title);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeURLChangedCallback(IntPtr webView, IntPtr param, IntPtr url);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool wkeWindowClosingCallback(IntPtr webWindow, IntPtr param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wkeWindowDestroyCallback(IntPtr webWindow, IntPtr param);

        public enum wkeWindowType
        {
            WKE_WINDOW_TYPE_POPUP,
            WKE_WINDOW_TYPE_TRANSPARENT,
            WKE_WINDOW_TYPE_CONTROL
        }
    }
}

