namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B722BCC8-4E68-101B-A2BC-00AA00404770"), InterfaceType((short) 1)]
    public interface IEnumOleDocumentViews
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int Next([In, ComAliasName("DSkin.OLE.ULONG")] uint cViews, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Interface)] IOleDocumentView[] rgpView, [ComAliasName("DSkin.OLE.ULONG")] out uint pcFetched);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int Skip([In, ComAliasName("DSkin.OLE.ULONG")] uint cViews);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int Reset();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumOleDocumentViews ppEnum);
    }
}

