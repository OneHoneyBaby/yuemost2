namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ComConversionLoss, Guid("922EADA0-3424-11CF-B670-00AA004CD6D8"), InterfaceType((short) 1)]
    public interface IOleInPlaceSiteWindowless : IOleWindow, IOleInPlaceSite, IOleInPlaceSiteEx
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int CanWindowlessActivate();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int GetCapture();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int SetCapture([In, ComAliasName("DSkin.OLE.BOOL")] int fCapture);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int GetFocus();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int SetFocus([In, ComAliasName("DSkin.OLE.BOOL")] int fFocus);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetDC([In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRect, [In, ComAliasName("DSkin.OLE.DWORD")] uint grfFlags, out IntPtr phDC);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ReleaseDC([In] IntPtr hDC);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void InvalidateRect([In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRect, [In, ComAliasName("DSkin.OLE.BOOL")] int fErase);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void InvalidateRgn([In] IntPtr hRGN, [In, ComAliasName("DSkin.OLE.BOOL")] int fErase);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ScrollRect([In, ComAliasName("DSkin.OLE.INT")] int dx, [In, ComAliasName("DSkin.OLE.INT")] int dy, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRectScroll, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRectClip);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int AdjustRect([In, Out, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prc);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int OnDefWindowMessage([In, ComAliasName("DSkin.OLE.UINT")] uint MSG, [In, ComAliasName("DSkin.OLE.UINT_PTR")] IntPtr wParam, [In, ComAliasName("DSkin.OLE.LONG_PTR")] IntPtr lParam, [ComAliasName("DSkin.OLE.LONG_PTR")] out int plResult);
    }
}

