namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000115-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface GInterface0 : IOleWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetBorder([Out, ComAliasName("DSkin.OLE.LPRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] lprectBorder);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void RequestBorderSpace([In, ComAliasName("DSkin.OLE.LPCBORDERWIDTHS"), MarshalAs(UnmanagedType.LPArray)] RECT[] pborderwidths);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetBorderSpace([In, ComAliasName("DSkin.OLE.LPCBORDERWIDTHS"), MarshalAs(UnmanagedType.LPArray)] RECT[] pborderwidths);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetActiveObject([In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceActiveObject pActiveObject, [In, ComAliasName("DSkin.OLE.LPCOLESTR"), MarshalAs(UnmanagedType.LPWStr)] string pszObjName);
    }
}

