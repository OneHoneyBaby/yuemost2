namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B722BCC6-4E68-101B-A2BC-00AA00404770"), InterfaceType((short) 1)]
    public interface IOleDocumentView
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetInPlaceSite([In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceSite pIPSite);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetInPlaceSite([MarshalAs(UnmanagedType.Interface)] out IOleInPlaceSite ppIPSite);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetDocument([MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetRect([In, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prcView);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetRect([Out, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prcView);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetRectComplex([In, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prcView, [In, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] rect_0, [In, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] rect_1, [In, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] prcSizeBox);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Show([In, ComAliasName("DSkin.OLE.BOOL")] int fShow);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void imethod_0([In, ComAliasName("DSkin.OLE.BOOL")] int int_0);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Open();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void CloseView([ComAliasName("DSkin.OLE.DWORD")] uint dwReserved);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SaveViewState([In, ComAliasName("DSkin.OLE.LPSTREAM"), MarshalAs(UnmanagedType.Interface)] IStream pstm);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ApplyViewState([In, ComAliasName("DSkin.OLE.LPSTREAM"), MarshalAs(UnmanagedType.Interface)] IStream pstm);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Clone([In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceSite ioleInPlaceSite_0, [MarshalAs(UnmanagedType.Interface)] out IOleDocumentView ppViewNew);
    }
}

