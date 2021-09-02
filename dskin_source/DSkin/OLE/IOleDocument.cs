namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("B722BCC5-4E68-101B-A2BC-00AA00404770")]
    public interface IOleDocument
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void CreateView([In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceSite pIPSite, [In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, ComAliasName("DSkin.OLE.DWORD")] uint dwReserved, [MarshalAs(UnmanagedType.Interface)] out IOleDocumentView ppView);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetDocMiscStatus([ComAliasName("DSkin.OLE.DWORD")] out uint pdwStatus);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void EnumViews([MarshalAs(UnmanagedType.Interface)] out IEnumOleDocumentViews ppEnum, [MarshalAs(UnmanagedType.Interface)] out IOleDocumentView ppView);
    }
}

