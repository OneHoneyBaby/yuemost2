namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B196B289-BAB4-101A-B69C-00AA00341D07"), InterfaceType((short) 1)]
    public interface IOleControlSite
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnControlInfoChanged();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void LockInPlaceActive([In, ComAliasName("DSkin.OLE.BOOL")] int fLock);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetExtendedControl([MarshalAs(UnmanagedType.IDispatch)] out object ppDisp);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void TransformCoords([In, Out, ComAliasName("DSkin.OLE.POINTL"), MarshalAs(UnmanagedType.LPArray)] POINTL[] pPtlHimetric, [In, Out, ComAliasName("DSkin.OLE.POINTF"), MarshalAs(UnmanagedType.LPArray)] POINTF[] pPtfContainer, [In, ComAliasName("DSkin.OLE.DWORD")] uint dwFlags);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int TranslateAccelerator([In, ComAliasName("DSkin.OLE.MSG"), MarshalAs(UnmanagedType.LPArray)] MSG[] pMsg, [In, ComAliasName("DSkin.OLE.DWORD")] uint grfModifiers);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnFocus([In, ComAliasName("DSkin.OLE.BOOL")] int fGotFocus);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ShowPropertyFrame();
    }
}

