namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("1C2056CC-5EF4-101B-8BC8-00AA003E3B29")]
    public interface IOleInPlaceObjectWindowless : IOleWindow, IOleInPlaceObject
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int OnWindowMessage([In, ComAliasName("DSkin.OLE.UINT")] uint MSG, [In, ComAliasName("DSkin.OLE.UINT_PTR")] IntPtr wParam, [In, ComAliasName("DSkin.OLE.LONG_PTR")] IntPtr lParam, [ComAliasName("DSkin.OLE.LONG_PTR")] out int plResult);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetDropTarget([MarshalAs(UnmanagedType.Interface)] out IDropTarget ppDropTarget);
    }
}

