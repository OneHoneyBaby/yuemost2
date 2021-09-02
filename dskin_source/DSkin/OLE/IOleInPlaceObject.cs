namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000113-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface IOleInPlaceObject : IOleWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void InPlaceDeactivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void UIDeactivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetObjectRects([In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprcPosRect, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprcClipRect);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ReactivateAndUndo();
    }
}

