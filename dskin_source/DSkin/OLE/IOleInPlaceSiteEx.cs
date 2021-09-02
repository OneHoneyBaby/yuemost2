namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("9C2CAD80-3424-11CF-B670-00AA004CD6D8"), InterfaceType((short) 1)]
    public interface IOleInPlaceSiteEx : IOleWindow, IOleInPlaceSite
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnInPlaceActivateEx([ComAliasName("DSkin.OLE.BOOL")] out int pfNoRedraw, [In, ComAliasName("DSkin.OLE.DWORD")] uint dwFlags);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnInPlaceDeactivateEx([In, ComAliasName("DSkin.OLE.BOOL")] int fNoRedraw);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int RequestUIActivate();
    }
}

