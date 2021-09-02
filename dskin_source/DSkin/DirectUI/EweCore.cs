namespace DSkin.DirectUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class EweCore
    {
        private static Dictionary<string, Assembly> dictionary_0 = new Dictionary<string, Assembly>();
        private static DidDownloadCallback didDownloadCallback_0;
        [CompilerGenerated]
        private static DidDownloadCallback didDownloadCallback_2;
        public const string Ewedll = "ewe.dll";
        private static ReadFileCallback readFileCallback_0;

        public static  event DidDownloadCallback DidDownload;

        public static  event Func<string, byte[]> OnSetData;

        static EweCore()
        {
            if (File.Exists("ewe.dll"))
            {
                wkeInitialize();
                readFileCallback_0 = new ReadFileCallback(EweCore.smethod_0);
                wkeOnReadFile(readFileCallback_0);
                if (didDownloadCallback_2 == null)
                {
                    didDownloadCallback_2 = new DidDownloadCallback(EweCore.smethod_1);
                }
                didDownloadCallback_0 = didDownloadCallback_2;
                wkeOnDidDownloadCallback(didDownloadCallback_0);
            }
        }

        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void PaintLayeredWindow(IntPtr targetHwnd, IntPtr targetHwndDc, IntPtr bitmapDc);
        private static void smethod_0(IntPtr intptr_0, string string_0, SetDataCallback setDataCallback_0)
        {
            byte[] buffer;
            IntPtr ptr;
            string str = string_0;
            if (func_0 != null)
            {
                buffer = func_0.Invoke(string_0);
                if ((buffer != null) && (buffer.Length > 0))
                {
                    ptr = Marshal.AllocHGlobal(buffer.Length);
                    Marshal.Copy(buffer, 0, ptr, buffer.Length);
                    setDataCallback_0(intptr_0, ptr, (uint) buffer.Length);
                    return;
                }
            }
            if ((dictionary_0.Count != 0) && (string_0.IndexOf(':') < 0))
            {
                try
                {
                    Assembly assembly;
                    string_0 = string_0.TrimStart(new char[] { '\\', '/' });
                    string_0 = string_0.Replace('/', '.');
                    string_0 = string_0.Replace('\\', '.');
                    string key = string_0.Substring(0, string_0.IndexOf('.'));
                    if (dictionary_0.TryGetValue(key, out assembly))
                    {
                        Stream manifestResourceStream = assembly.GetManifestResourceStream(string_0);
                        if (manifestResourceStream != null)
                        {
                            using (manifestResourceStream)
                            {
                                if (manifestResourceStream.Length > 0L)
                                {
                                    buffer = new byte[manifestResourceStream.Length];
                                    manifestResourceStream.Read(buffer, 0, (int) manifestResourceStream.Length);
                                    ptr = Marshal.AllocHGlobal(buffer.Length);
                                    Marshal.Copy(buffer, 0, ptr, buffer.Length);
                                    setDataCallback_0(intptr_0, ptr, (uint) buffer.Length);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message + " ：" + str + "路径有错，无法读取文件数据");
                }
            }
        }

        [CompilerGenerated]
        private static void smethod_1(string string_0, IntPtr intptr_0, uint uint_0)
        {
            if (didDownloadCallback_1 != null)
            {
                didDownloadCallback_1(string_0, intptr_0, uint_0);
            }
        }

        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr Utf8StringToWkeChar([In, MarshalAs(UnmanagedType.LPStr)] string param0);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeCallOnMainThread(EweCallBack _callback, IntPtr context);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeCallOnMainThreadAndWait(EweCallBack _callback, IntPtr context);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeCanGoBack(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeCanGoForward(IntPtr webView);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr WkeCharToUtf8String([In, MarshalAs(UnmanagedType.LPWStr)] string param0);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeContextMenuEvent(IntPtr webView, int x, int y, uint flags);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeCreateWebView();
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr wkeCreateWindow(IntPtr hParent);
        [DllImport("ewe.dll")]
        public static extern void wkeDestroyWebView(IntPtr webView);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeDisableWOFF([MarshalAs(UnmanagedType.I1)] bool isDisable);
        [DllImport("ewe.dll")]
        public static extern void wkeEnableContextMenu(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool enable);
        [DllImport("ewe.dll")]
        public static extern void wkeExecCommand(IntPtr handle, [In, MarshalAs(UnmanagedType.LPWStr)] string command, [In, MarshalAs(UnmanagedType.LPWStr)] string args);
        [DllImport("ewe.dll")]
        public static extern void wkeFinalize();
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeFireKeyDownEvent(IntPtr webView, uint virtualKeyCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeFireKeyPressEvent(IntPtr webView, uint charCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeFireKeyUpEvent(IntPtr webView, uint virtualKeyCode, uint flags, [MarshalAs(UnmanagedType.I1)] bool systemKey);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeFireMouseEvent(IntPtr webView, uint message, int x, int y, uint flags);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeFireMouseWheelEvent(IntPtr webView, int x, int y, int delta, uint flags);
        [DllImport("ewe.dll")]
        public static extern void wkeFree(IntPtr ptr);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeGetCaretRect(IntPtr webView, ref DSkin.DirectUI.wkeRect rect);
        [DllImport("ewe.dll")]
        public static extern int wkeGetContentHeight(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern int wkeGetContentWidth(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeGetCookieW(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern int wkeGetHeight(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern wkeLoadingStatus wkeGetLoadingStatus(IntPtr handle);
        [DllImport("ewe.dll")]
        public static extern float wkeGetMediaVolume(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeGetUserAgent(IntPtr handle);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr wkeGetViewDC(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern int wkeGetWidth(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeGetWTFString(IntPtr wtfstr);
        [DllImport("ewe.dll")]
        public static extern float wkeGetZoomFactor(IntPtr webView);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr wkeGlobalExec(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeGoBack(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeGoForward(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern void wkeInitialize();
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsCookieEnabled(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsDirty(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern bool wkeIsLoadComplete(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsLoading(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsLoadingCompleted(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsLoadingFailed(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsLoadingSucceeded(IntPtr webView);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeIsTransparent(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern long wkeJSBool(IntPtr es, [MarshalAs(UnmanagedType.I1)] bool b);
        [DllImport("ewe.dll")]
        public static extern void wkeJSCollectGarbge();
        [DllImport("ewe.dll")]
        public static extern void wkeJSContextCreateCallback(ContextCreateCallback cb);
        [DllImport("ewe.dll")]
        public static extern long wkeJSDouble(IntPtr es, double d);
        [DllImport("ewe.dll")]
        public static extern long wkeJSEmptyArray(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern long wkeJSEmptyObject(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern long wkeJSEval(IntPtr es, [In, MarshalAs(UnmanagedType.LPWStr)] string js);
        [DllImport("ewe.dll")]
        public static extern long wkeJSFalse(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern long wkeJSFloat(IntPtr es, float f);
        [DllImport("ewe.dll")]
        public static extern long wkeJSGet(IntPtr es, long jsValue, [In, MarshalAs(UnmanagedType.LPWStr)] string proName);
        [DllImport("ewe.dll")]
        public static extern long wkeJSGetAt(IntPtr es, long jsValue, int index);
        [DllImport("ewe.dll")]
        public static extern wkeJSData wkeJSGetData(IntPtr es, long jsValue);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeJSGetWebView(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern long wkeJSInt(IntPtr es, int n);
        [DllImport("ewe.dll")]
        public static extern long wkeJSNull(IntPtr es);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern long wkeJSParam(IntPtr es, int argIdx);
        [DllImport("ewe.dll")]
        public static extern int wkeJSParamCount(IntPtr intptr_0);
        [DllImport("ewe.dll")]
        public static extern void wkeJSSimpleBind(IntPtr es, [In, MarshalAs(UnmanagedType.LPWStr)] string name, DSkin.DirectUI.jsNativeFunction fn);
        [DllImport("ewe.dll")]
        public static extern long wkeJSString(IntPtr es, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("ewe.dll")]
        public static extern bool wkeJSToBool(IntPtr es, long v);
        [DllImport("ewe.dll")]
        public static extern double wkeJSToDouble(IntPtr es, long v);
        [DllImport("ewe.dll")]
        public static extern float wkeJSToFloat(IntPtr es, long v);
        [DllImport("ewe.dll")]
        public static extern int wkeJSToInt(IntPtr es, long v);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr wkeJSToString(IntPtr es, long v);
        [DllImport("ewe.dll")]
        public static extern long wkeJSTrue(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern wkeJSType wkeJSTypeOf(IntPtr es, long v);
        [DllImport("ewe.dll")]
        public static extern long wkeJSUndefined(IntPtr es);
        [DllImport("ewe.dll")]
        public static extern void wkeKillFocus(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern void wkeLimitPlugins(IntPtr handle, [MarshalAs(UnmanagedType.I1)] bool b);
        [DllImport("ewe.dll")]
        public static extern void wkeLoadFile(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string filename);
        [DllImport("ewe.dll")]
        public static extern void wkeLoadHTML(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string html);
        [DllImport("ewe.dll")]
        public static extern void wkeLoadURL(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string url);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeMalloc(int size);
        [DllImport("ewe.dll")]
        public static extern void wkeOnAlertBox(IntPtr webView, AlertBoxCallback callback);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnConfirmBox(IntPtr webView, ConfirmBoxCallback callback);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnConsoleMessage(IntPtr webView, DSkin.DirectUI.wkeConsoleMessageCallback callback);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnCreateView(IntPtr webView, DSkin.DirectUI.wkeCreateViewCallback callback, IntPtr param);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnDidDownloadCallback(DidDownloadCallback callback_);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnDocumentReady(IntPtr webView, DSkin.DirectUI.wkeDocumentReadyCallback callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnDownloadFile(IntPtr handle, wkeDownloadFileCallback callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnJsCall(IntPtr handle, JsCallCallback js);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnLoadingFinish(IntPtr webView, DSkin.DirectUI.wkeLoadingFinishCallback callback);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeOnNavigation(IntPtr webView, DSkin.DirectUI.wkeNavigationCallback callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnPaintUpdated(IntPtr webView, DSkin.DirectUI.wkePaintUpdatedCallback callback, IntPtr callbackParam);
        [DllImport("ewe.dll")]
        public static extern void wkeOnPromptBox(IntPtr webView, PromptBoxCallback callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnReadFile(ReadFileCallback _callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnTitleChanged(IntPtr webView, TitleChangedCallback callback);
        [DllImport("ewe.dll")]
        public static extern void wkeOnURLChanged(IntPtr webView, UrlChangedCallback callback);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkePaint(IntPtr webView, IntPtr bits, int pitch);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkePaintDC(IntPtr handle, IntPtr hdc);
        [DllImport("ewe.dll")]
        public static extern void wkePostURL(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr data, int dataBytes);
        [DllImport("ewe.dll")]
        public static extern void wkeReload(IntPtr webView);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeResize(IntPtr webView, int w, int h);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern long wkeRunJSW(IntPtr webView, [In, MarshalAs(UnmanagedType.LPWStr)] string script);
        [DllImport("ewe.dll")]
        public static extern void wkeSetCookieEnabled(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool enable);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeSetFocus(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern void wkeSetMediaVolume(IntPtr webView, float volume);
        [DllImport("ewe.dll")]
        public static extern void wkeSetMenuItemText([In, MarshalAs(UnmanagedType.LPWStr)] string item, [In, MarshalAs(UnmanagedType.LPWStr)] string text);
        [DllImport("ewe.dll")]
        public static extern void wkeSetMenuItemVisible([In, MarshalAs(UnmanagedType.LPWStr)] string item, [MarshalAs(UnmanagedType.I1)] bool enable);
        [DllImport("ewe.dll")]
        public static extern void wkeSetTransparent(IntPtr webView, [MarshalAs(UnmanagedType.I1)] bool transparent);
        [DllImport("ewe.dll")]
        public static extern void wkeSetUserAgent(IntPtr handle, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport("ewe.dll")]
        public static extern void wkeSetWTFString(IntPtr wtfstr, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport("ewe.dll")]
        public static extern void wkeSetZoomFactor(IntPtr webView, float factor);
        [DllImport("ewe.dll")]
        public static extern void wkeStopLoading(IntPtr webView);
        [DllImport("ewe.dll")]
        public static extern IntPtr wkeTitleW(IntPtr webView);
        [DllImport("ewe.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern void wkeWindowOnPaint(IntPtr webView, IntPtr bits, int pitch);

        public static Dictionary<string, Assembly> ResourceAssemblys
        {
            get
            {
                return dictionary_0;
            }
        }
    }
}

