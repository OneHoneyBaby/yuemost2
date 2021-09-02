namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000117-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface IOleInPlaceActiveObject : IOleWindow
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int TranslateAccelerator([In, MarshalAs(UnmanagedType.LPArray)] MSG[] lpmsg);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnFrameWindowActivate([In, ComAliasName("DSkin.OLE.BOOL")] int fActivate);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnDocWindowActivate([In, ComAliasName("DSkin.OLE.BOOL")] int fActivate);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ResizeBorder([In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prcBorder, [In, ComAliasName("DSkin.OLE.REFIID")] ref Guid riid, [In, MarshalAs(UnmanagedType.Interface)] GInterface0 ginterface0_0, [In, ComAliasName("DSkin.OLE.BOOL")] int fFrameWindow);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void EnableModeless([In, ComAliasName("DSkin.OLE.BOOL")] int fEnable);
    }
}

