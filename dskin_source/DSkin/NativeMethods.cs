namespace DSkin
{
    using DSkin.Controls;
    using DSkin.OLE;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class NativeMethods
    {
        public static uint BI_BITFIELDS = 3;
        public static uint BI_JPEG = 4;
        public static uint BI_PNG = 5;
        public static uint BI_RGB = 0;
        public static uint BI_RLE4 = 2;
        public static uint BI_RLE8 = 1;
        public static Guid BlurEffectGuid = new Guid("{633C80A4-1843-482B-9EF2-BE2834C5FDD4}");
        public const int CWP_All = 0;
        public const int CWP_SKIPDISABLED = 2;
        public const int CWP_SKIPINVISIBL = 1;
        public static uint DIB_PAL_COLORS = 1;
        public static uint DIB_RGB_COLORS = 0;
        public const int ICC_BAR_CLASSES = 4;
        public const int ICC_DATE_CLASSES = 0x100;
        public const int ICC_LISTVIEW_CLASSES = 1;
        public const int ICC_PROGRESS_CLASS = 0x20;
        public const int ICC_TAB_CLASSES = 8;
        public const int ICC_TREEVIEW_CLASSES = 2;
        public const int ICON_BIG = 1;
        public const int ICON_SMALL = 0;
        public const int IDC_APPSTARTING = 0x7f8a;
        public const int IDC_ARROW = 0x7f00;
        public const int IDC_CROSS = 0x7f03;
        public const int IDC_HELP = 0x7f8b;
        public const int IDC_IBEAM = 0x7f01;
        public const int IDC_NO = 0x7f88;
        public const int IDC_SIZEALL = 0x7f86;
        public const int IDC_SIZENESW = 0x7f83;
        public const int IDC_SIZENS = 0x7f85;
        public const int IDC_SIZENWSE = 0x7f82;
        public const int IDC_SIZEWE = 0x7f84;
        public const int IDC_UPARROW = 0x7f04;
        public const int IDC_WAIT = 0x7f02;
        public static Guid IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");
        public static Guid IID_IViewObject = new Guid("{0000010d-0000-0000-C000-000000000046}");
        public const int ILC_COLOR = 0;
        public const int ILC_COLOR16 = 0x10;
        public const int ILC_COLOR24 = 0x18;
        public const int ILC_COLOR32 = 0x20;
        public const int ILC_COLOR4 = 4;
        public const int ILC_COLOR8 = 8;
        public const int ILC_MASK = 1;
        public const int ILC_MIRROR = 0x2000;
        public const int ILD_MASK = 0x10;
        public const int ILD_NORMAL = 0;
        public const int ILD_ROP = 0x40;
        public const int ILD_TRANSPARENT = 1;
        public const int IMAGE_CURSOR = 2;
        public const int IMAGE_ICON = 1;
        public const int IME_CMODE_FULLSHAPE = 8;
        public const int IME_CMODE_KATAKANA = 2;
        public const int IME_CMODE_NATIVE = 1;
        public const int INPLACE_E_NOTOOLSPACE = -2147221087;
        public const uint PFD_DOUBLEBUFFER = 1;
        public const uint PFD_DRAW_TO_BITMAP = 8;
        public const uint PFD_DRAW_TO_WINDOW = 4;
        public const uint PFD_GENERIC_ACCELERATED = 0x1000;
        public const uint PFD_GENERIC_FORMAT = 0x40;
        public const sbyte PFD_MAIN_PLANE = 0;
        public const uint PFD_NEED_PALETTE = 0x80;
        public const uint PFD_NEED_SYSTEM_PALETTE = 0x100;
        public const sbyte PFD_OVERLAY_PLANE = 1;
        public const uint PFD_STEREO = 2;
        public const uint PFD_SUPPORT_DIRECTDRAW = 0x2000;
        public const uint PFD_SUPPORT_GDI = 0x10;
        public const uint PFD_SUPPORT_OPENGL = 0x20;
        public const uint PFD_SWAP_COPY = 0x400;
        public const uint PFD_SWAP_EXCHANGE = 0x200;
        public const uint PFD_SWAP_LAYER_BUFFERS = 0x800;
        public const byte PFD_TYPE_COLORINDEX = 1;
        public const byte PFD_TYPE_RGBA = 0;
        public const sbyte PFD_UNDERLAY_PLANE = -1;
        public static Guid UsmSharpenEffectGuid = new Guid("{63CBF3EE-C526-402C-8F71-62C540BF5142}");
        public const int WS_SHOWNORMAL = 1;

        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);
        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref DSkin.PAINTSTRUCT ps);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int CallNextHookEx(IntPtr hookHandle, int code, IntPtr wparam, ref CWPSTRUCT cwp);
        [DllImport("user32.dll")]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr pHwnd, DSkin.POINT pt, uint uFlgs);
        [DllImport("gdi32.dll", SetLastError=true)]
        public static extern int ChoosePixelFormat(IntPtr hDC, [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);
        [return: MarshalAs(UnmanagedType.Interface)]
        [DllImport("ole32.dll", ExactSpelling=true, PreserveSig=false)]
        public static extern object CoCreateInstance([In] ref Guid clsid, [MarshalAs(UnmanagedType.Interface)] object punkOuter, int context, [In] ref Guid iid);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateBitmapIndirect(ref DSkin.BITMAP bitmap);
        [DllImport("user32.dll")]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)] string lpszDriver, [MarshalAs(UnmanagedType.LPStr)] string lpszDevice, [MarshalAs(UnmanagedType.LPStr)] string lpszOutput, int lpInitData);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)] string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)] string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)] string lpszOutput, int lpInitData);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, IntPtr pBitmapInfo, int un, IntPtr lplpVoid, IntPtr handle, int dw);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref BitMapInfo pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi, int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi, int iUsage, IntPtr ppvBits, IntPtr hSection, int dwOffset);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreateHatchBrush(int Style, int crColor);
        [DllImport("ole32.dll")]
        public static extern int CreateILockBytesOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out DSkin.OLE.ILockBytes ppLkbyt);
        public static IntPtr CreateMemoryHdc(IntPtr hdc, int width, int height, out IntPtr dib)
        {
            BitMapInfo info;
            IntPtr ptr2;
            IntPtr hDC = CreateCompatibleDC(hdc);
            SetBkMode(hDC, 1);
            info = new BitMapInfo {
                biSize = Marshal.SizeOf(info),
                biWidth = width,
                biHeight = -height,
                biPlanes = 1,
                biBitCount = 0x20,
                biCompression = 0
            };
            dib = CreateDIBSection(hdc, ref info, 0, out ptr2, IntPtr.Zero, 0);
            SelectObject(hDC, dib);
            return hDC;
        }

        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreatePatternBrush(IntPtr hBMP);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreatePen(int nPenStyle, int nWidth, int crColor);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
        public static extern IntPtr CreateRectRgn(int x1, int y1, int x2, int y2);
        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr CreateSolidBrush(int crColor);
        [DllImport("user32.dll", SetLastError=true)]
        public static extern IntPtr CreateWindowEx(int exstyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hwndParent, IntPtr Menu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr DeleteObject(IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern bool DestroyCaret();
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableBlurBehindWindow(int hWnd, ref DWM_BLURBEHIND pBlurBehind);
        [DllImport("dwmapi.dll", PreserveSig=false)]
        public static extern int DwmEnableComposition(bool fEnable);
        [DllImport("dwmapi.dll", PreserveSig=false)]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);
        [DllImport("dwmapi.dll", PreserveSig=false)]
        public static extern bool DwmIsCompositionEnabled();
        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, ref DSkin.PAINTSTRUCT ps);
        [DllImport("gdi32.dll", SetLastError=true, ExactSpelling=true)]
        public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);
        [DllImport("user32.dll", CharSet=CharSet.Ansi)]
        public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet=CharSet.Ansi)]
        public static extern IntPtr FindWindowExA(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("gdi32.dll")]
        public static extern bool GdiAlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int int_0, int int_1, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GdiFlush();
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipBitmapApplyEffect(IntPtr bitmap, IntPtr effect, ref System.Drawing.Rectangle rectOfInterest, bool useAuxData, IntPtr auxData, int auxDataSize);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipBitmapConvertFormat(IntPtr bitmap, int pixelFormat, int dithertype, int palettetype, IntPtr palette, float alphaThresholdPercent);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipBitmapCreateApplyEffect(ref IntPtr SrcBitmap, int numInputs, IntPtr effect, ref System.Drawing.Rectangle rectOfInterest, ref System.Drawing.Rectangle outputRect, out IntPtr outputBitmap, bool useAuxData, IntPtr auxData, int auxDataSize);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipCreateEffect(Guid guid, out IntPtr effect);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipDeleteEffect(IntPtr effect);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipGetEffectParameters(IntPtr effect, ref uint size, IntPtr parameters);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipGetEffectParameterSize(IntPtr effect, out uint size);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipInitializePalette(IntPtr palette, int palettetype, int optimalColors, int useTransparentColor, int bitmap);
        [DllImport("gdiplus.dll", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        public static extern int GdipSetEffectParameters(IntPtr effect, IntPtr parameters, uint size);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetBkColor(IntPtr hDC);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetBkMode(IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern uint GetCaretBlinkTime();
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, ref DSkin.RECT r);
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out PCURSORINFO pci);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("gdi32.dll")]
        public static extern int GetDIBits([In] IntPtr hdc, [In] IntPtr hbmp, uint uStartScan, uint cScanLines, [Out] byte[] lpvBits, ref BITMAPINFO lpbi, DIB_Color_Mode uUsage);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        [DllImport("Kernel32", CharSet=CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string modName);
        [DllImport("gdi32.dll")]
        public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, IntPtr lpvObject);
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int GetPixel(IntPtr hdc, int x, int y);
        [DllImport("user32.dll")]
        public static extern int GetScrollBarInfo(IntPtr hWnd, uint idObject, ref SCROLLBARINFO psbi);
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern bool GetScrollInfo(HandleRef hWnd, int fnBar, [In, Out] ref DSkin.SCROLLINFO si);
        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("Kernel32", CharSet=CharSet.Auto)]
        public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(SYSTEM_METRICS smIndex);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetTextColor(IntPtr hDC);
        [DllImport("gdi32.dll", CharSet=CharSet.Unicode)]
        public static extern bool GetTextExtentExPointW(IntPtr hDc, [MarshalAs(UnmanagedType.LPWStr)] string str, int nLength, int nMaxExtent, int[] lpnFit, int[] alpDx, ref Size size);
        [DllImport("gdi32.dll", CharSet=CharSet.Unicode)]
        public static extern int GetTextExtentPoint32W(IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)] string str, int len, ref Size size);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetTextFace(IntPtr hDC, int nCount, string lpFacename);
        [DllImport("gdi32.dll", CharSet=CharSet.Unicode)]
        public static extern bool GetTextMetrics(IntPtr hdc, out TextMetric lptm);
        [DllImport("kernel32.dll")]
        public static extern int GetVersionExA(ref OSVERSIONINFO 系统信息);
        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32")]
        public static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll")]
        public static extern long GetWindowLongA(int hWnd, int nIndex);
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
            {
                return GetWindowLongPtrW(hWnd, nIndex);
            }
            return new IntPtr(GetWindowLongW(hWnd, nIndex));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLongPtrW(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        public static extern int GetWindowLongW(IntPtr hWnd, int nIndex);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref DSkin.RECT lpRect);
        public static System.Drawing.Rectangle GetWindowRectangle(IntPtr handle)
        {
            DSkin.RECT lpRect = new DSkin.RECT();
            GetWindowRect(handle, ref lpRect);
            return new System.Drawing.Rectangle(lpRect.Left, lpRect.Top, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, int ID);
        [DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);
        public static int HIWORD(int value)
        {
            return (value >> 0x10);
        }

        [DllImport("Imm32.dll")]
        public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);
        [DllImport("Imm32.dll")]
        public static extern bool ImmAssociateContextEx(IntPtr hWnd, IntPtr hIMC, int dwFlags);
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr ImmCreateContext();
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern bool ImmDestroyContext(IntPtr hIMC);
        [DllImport("Imm32.dll")]
        public static extern unsafe int ImmGetCompositionString(IntPtr hIMC, int dwIndex, sbyte* lpBuf, int dwBufLen);
        [DllImport("Imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern bool ImmGetConversionStatus(IntPtr hIMC, ref int conversion, ref int sentence);
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern bool ImmGetOpenStatus(IntPtr hIMC);
        [DllImport("Imm32.dll")]
        public static extern int ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);
        [DllImport("Imm32.dll")]
        public static extern bool ImmSetCompositionWindow(IntPtr hIMC, ref COMPOSITIONFORM lpCompForm);
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern bool ImmSetConversionStatus(IntPtr hIMC, int conversion, int sentence);
        [DllImport("Imm32.dll", CharSet=CharSet.Auto)]
        public static extern bool ImmSetOpenStatus(IntPtr hIMC, bool open);
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern bool InvalidateRect(IntPtr hWnd, DSkin.OLE.COMRECT rect, bool erase);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("uxtheme.dll")]
        public static extern bool IsAppThemed();
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr LineTo(IntPtr hDC, int x, int y);
        [DllImport("user32.dll")]
        public static extern int LoadCursor(int hInstance, int lpCursorName);
        [DllImport("Kernel32", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr LoadLibrary(string libname);
        public static int LOWORD(int value)
        {
            return (value & 0xffff);
        }

        public static int MAKELONG(int low, int high)
        {
            return ((high << 0x10) | (low & 0xffff));
        }

        public static IntPtr MAKELPARAM(int low, int high)
        {
            return (IntPtr) ((high << 0x10) | (low & 0xffff));
        }

        [DllImport("winmm.dll")]
        public static extern int mciSendString(string m_strCmd, StringBuilder m_strReceive, int m_v1, int m_v2);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int MessageBox(HandleRef hWnd, string text, string caption, int type);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public static void MouseToMoveControl(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, 0x112, 0xf012, 0);
        }

        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr MoveToEx(IntPtr hDC, int x, int y, ref DSkin.POINT lpPoint);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, int bRepaint);
        [DllImport("user32.dll")]
        public static extern int OffsetRect(ref DSkin.RECT lpRect, int x, int y);
        [DllImport("ole32.dll")]
        public static extern int OleCreateFromFile([In] ref Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, [In] ref Guid riid, uint renderopt, ref FORMATETC pFormatEtc, DSkin.OLE.IOleClientSite pClientSite, DSkin.OLE.IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport("ole32.dll")]
        public static extern int OleDraw(IntPtr pUnk, int dwAspect, IntPtr hdcDraw, ref System.Drawing.Rectangle lprcBounds);
        [DllImport("ole32.dll")]
        public static extern int OleSetContainedObject([MarshalAs(UnmanagedType.IUnknown)] object pUnk, bool fContained);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern bool PatBlt(IntPtr hDC, int x, int y, int width, int height, uint flags);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool PtInRect(ref DSkin.RECT lprc, Point pt);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int Rectangle(IntPtr hDC, int left, int top, int right, int bottom);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern bool RedrawWindow(HandleRef hwnd, ref DSkin.RECT rcUpdate, HandleRef hrgnUpdate, int flags);
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern bool RedrawWindow(HandleRef hwnd, DSkin.OLE.COMRECT rcUpdate, HandleRef hrgnUpdate, int flags);
        [return: MarshalAs(UnmanagedType.U2)]
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll", ExactSpelling=true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        public static void ReleaseMemoryHdc(IntPtr memoryHdc, IntPtr dib)
        {
            DeleteObject(dib);
            DeleteDC(memoryHdc);
        }

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref DSkin.POINT lpPoint);
        [DllImport("user32.dll")]
        public static extern int ScreenToClient(IntPtr hwnd, ref Point lpPoint);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("user32.dll", CharSet=CharSet.Auto, PreserveSig=false)]
        public static extern IRichEditOle SendMessage(IntPtr hWnd, int message, int wParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, ref int lParam);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr handle);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int SetBkColor(IntPtr hDC, int crColor);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int SetBkMode(IntPtr hDC, int Mode);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int SetBrushOrgEx(IntPtr hDC, int x, int y, ref DSkin.POINT p);
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool SetCaretPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern int SetCursor(int hCursor);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("gdi32.dll")]
        public static extern int SetDIBits(IntPtr hdc, IntPtr hBitmap, int nStartScan, int nNumScans, IntPtr lpBits, IntPtr lpBI, int wUsage);
        [DllImport("gdi32.dll")]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int x, int y, int dx, int dy, int SrcX, int SrcY, int Scan, int NumScans, IntPtr Bits, IntPtr BitsInfo, int wUsage);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        public static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);
        [DllImport("user32.dll", CharSet=CharSet.Ansi)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int SetPixel(IntPtr hdc, int x, int y, int crColor);
        [DllImport("gdi32.dll", SetLastError=true)]
        public static extern int SetPixelFormat(IntPtr hDC, int iPixelFormat, [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("gdi32.dll")]
        public static extern int SetTextAlign(IntPtr hdc, uint fMode);
        [DllImport("gdi32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int SetTextColor(IntPtr hDC, int crColor);
        public static IntPtr SetWindowLong(IntPtr hWnd, short nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLong_1(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr_1(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32")]
        public static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        [DllImport("user32", EntryPoint="SetWindowLong")]
        public static extern IntPtr SetWindowLong_1(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        public static extern int SetWindowLongA(int hWnd, int nIndex, long dwNewLong);
        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
            {
                return SetWindowLongPtr_1(hWnd, nIndex, dwNewLong);
            }
            return new IntPtr(SetWindowLongW(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        [DllImport("user32", EntryPoint="SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr_1(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        public static extern int SetWindowLongW(IntPtr hWnd, int nIndex, int dwNewLong);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, bool bRedraw);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int type, HookProc hook, IntPtr instance, int threadID);
        [DllImport("uxtheme.dll", CharSet=CharSet.Unicode, ExactSpelling=true)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
        [DllImport("user32.dll")]
        public static extern bool ShowCaret(IntPtr hWnd);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("ole32.dll")]
        public static extern int StgCreateDocfileOnILockBytes(DSkin.OLE.ILockBytes plkbyt, uint grfMode, uint reserved, out DSkin.OLE.IStorage ppstgOpen);
        [DllImport("gdi32.dll", SetLastError=true)]
        public static extern int SwapBuffers(IntPtr hDC);
        [DllImport("gdi32.dll", CharSet=CharSet.Unicode)]
        public static extern bool TextOutW(IntPtr hdc, int x, int y, [MarshalAs(UnmanagedType.LPWStr)] string str, int len);
        [DllImport("user32.dll")]
        public static extern IntPtr TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr par);
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool TrackPopupMenuEx(IntPtr hMenu, uint uFlags, int x, int y, IntPtr hWnd, IntPtr tpmParams);
        [DllImport("msimg32.dll")]
        public static extern bool TransparentBlt(IntPtr hdc, int nXOriginDest, int nYOriginDest, int nWidthDest, int hHeightDest, IntPtr hdcSrc, int int_0, int int_1, int nWidthSrc, int nHeightSrc, uint crTransparent);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool UnhookWindowsHookEx(IntPtr hookHandle);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
        public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromDC(IntPtr hdc);

        [StructLayout(LayoutKind.Sequential)]
        public struct BitMapInfo
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
            public byte bmiColors_rgbBlue;
            public byte bmiColors_rgbGreen;
            public byte bmiColors_rgbRed;
            public byte bmiColors_rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO
        {
            public DSkin.NativeMethods.BITMAPINFOHEADER bmiHeader = new DSkin.NativeMethods.BITMAPINFOHEADER();
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
            public byte[] bmiColors;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO_FLAT
        {
            public int bmiHeader_biSize;
            public int bmiHeader_biWidth;
            public int bmiHeader_biHeight;
            public short bmiHeader_biPlanes;
            public short bmiHeader_biBitCount;
            public int bmiHeader_biCompression;
            public int bmiHeader_biSizeImage;
            public int bmiHeader_biXPelsPerMeter;
            public int bmiHeader_biYPelsPerMeter;
            public int bmiHeader_biClrUsed;
            public int bmiHeader_biClrImportant;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
            public byte[] bmiColors;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFOHEADER
        {
            public int biSize = Marshal.SizeOf(typeof(DSkin.NativeMethods.BITMAPINFOHEADER));
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
            public BLENDFUNCTION(byte alpha)
            {
                this.BlendOp = 0;
                this.BlendFlags = 0;
                this.AlphaFormat = 0;
                this.SourceConstantAlpha = alpha;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BlurParameters
        {
            public float Radius;
            public bool ExpandEdges;
        }

        public enum ComboBoxButtonState
        {
            STATE_SYSTEM_INVISIBLE = 0x8000,
            STATE_SYSTEM_NONE = 0,
            STATE_SYSTEM_PRESSED = 8
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ComboBoxInfo
        {
            public int cbSize;
            public DSkin.RECT rcItem;
            public DSkin.RECT rcButton;
            public DSkin.NativeMethods.ComboBoxButtonState stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMPOSITIONFORM
        {
            public uint dwStyle;
            public DSkin.POINT ptCurrentPos;
            public DSkin.RECT rcArea;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPSTRUCT
        {
            public IntPtr lparam;
            public IntPtr wparam;
            public int message;
            public IntPtr hwnd;
        }

        public enum DitherType
        {
            DitherTypeNone,
            DitherTypeSolid,
            DitherTypeOrdered4x4,
            DitherTypeOrdered8x8,
            DitherTypeOrdered16x16,
            DitherTypeOrdered91x91,
            DitherTypeSpiral4x4,
            DitherTypeSpiral8x8,
            DitherTypeDualSpiral4x4,
            DitherTypeDualSpiral8x8,
            DitherTypeErrorDiffusion
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            public uint dwFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fEnable;
            public IntPtr hRegionBlur;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fTransitionOnMaximized;
        }

        public delegate int HookProc(int code, IntPtr wparam, ref DSkin.NativeMethods.CWPSTRUCT cwp);

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OSVERSIONINFO
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
        }

        public enum PaletteType
        {
            PaletteTypeCustom,
            PaletteTypeOptimal,
            PaletteTypeFixedBW,
            PaletteTypeFixedHalftone8,
            PaletteTypeFixedHalftone27,
            PaletteTypeFixedHalftone64,
            PaletteTypeFixedHalftone125,
            PaletteTypeFixedHalftone216,
            PaletteTypeFixedHalftone252,
            PaletteTypeFixedHalftone256
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SharpenParams
        {
            public float Radius;
            public float Amount;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        public struct TextMetric
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public char tmFirstChar;
            public char tmLastChar;
            public char tmDefaultChar;
            public char tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }

        public static class WindowsLong
        {
            public const int GWL_EXSTYLE = -20;
            public const int GWL_HINSTANCE = -6;
            public const int GWL_HWNDPARENT = -8;
            public const int GWL_ID = -12;
            public const int GWL_STYLE = -16;
            public const int GWL_USERDATA = -21;
            public const int GWL_WNDPROC = -4;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        public struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint style;
            public DSkin.NativeMethods.WndProcDelegate lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
            public IntPtr hIconSm;
            public void Init()
            {
                this.cbSize = (uint) Marshal.SizeOf(this);
            }
        }

        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}

