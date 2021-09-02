namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000119-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface IOleInPlaceSite : IOleWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void CanInPlaceActivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnInPlaceActivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnUIActivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetWindowContext([MarshalAs(UnmanagedType.Interface)] out IOleInPlaceFrame ppFrame, [MarshalAs(UnmanagedType.Interface)] out GInterface0 ppDoc, [Out, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprcPosRect, [Out, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprcClipRect, [In, Out, ComAliasName("DSkin.OLE.OLEINPLACEFRAMEINFO"), MarshalAs(UnmanagedType.LPArray)] OLEINPLACEFRAMEINFO[] lpFrameInfo);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Scroll([In, ComAliasName("DSkin.OLE.SIZE")] SIZE scrollExtant);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnUIDeactivate([In, ComAliasName("DSkin.OLE.BOOL")] int fUndoable);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnInPlaceDeactivate();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void DiscardUndoState();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void DeactivateAndUndo();
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnPosRectChange([In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprcPosRect);
    }
}

