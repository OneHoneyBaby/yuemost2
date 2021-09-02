namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000122-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface IDropTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void DragEnter([In, MarshalAs(UnmanagedType.Interface)] IDataObject pDataObj, [In, ComAliasName("DSkin.OLE.DWORD")] uint grfKeyState, [In, ComAliasName("DSkin.OLE.POINTL")] POINTL pt, [In, Out, ComAliasName("DSkin.OLE.DWORD")] ref uint pdwEffect);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void DragOver([In, ComAliasName("DSkin.OLE.DWORD")] uint grfKeyState, [In, ComAliasName("DSkin.OLE.POINTL")] POINTL pt, [In, Out, ComAliasName("DSkin.OLE.DWORD")] ref uint pdwEffect);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void DragLeave();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Drop([In, MarshalAs(UnmanagedType.Interface)] IDataObject pDataObj, [In, ComAliasName("DSkin.OLE.DWORD")] uint grfKeyState, [In, ComAliasName("DSkin.OLE.POINTL")] POINTL pt, [In, Out, ComAliasName("DSkin.OLE.DWORD")] ref uint pdwEffect);
    }
}

