namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("3AF24292-0C96-11CE-A0CF-00AA00600AB8"), ComConversionLoss, InterfaceType((short) 1)]
    public interface IViewObjectEx : IViewObject, IViewObject2
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetRect([In, ComAliasName("DSkin.OLE.DWORD")] uint dwAspect, [Out, ComAliasName("DSkin.OLE.RECTL"), MarshalAs(UnmanagedType.LPArray)] RECTL[] pRect);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetViewStatus([ComAliasName("DSkin.OLE.DWORD")] out uint pdwStatus);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void QueryHitPoint([In, ComAliasName("DSkin.OLE.DWORD")] uint dwAspect, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRectBounds, [In, ComAliasName("DSkin.OLE.POINT")] POINT ptlLoc, [In, ComAliasName("DSkin.OLE.LONG")] int lCloseHint, [ComAliasName("DSkin.OLE.DWORD")] out uint pHitResult);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void QueryHitRect([In, ComAliasName("DSkin.OLE.DWORD")] uint dwAspect, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRectBounds, [In, ComAliasName("DSkin.OLE.LPCRECT"), MarshalAs(UnmanagedType.LPArray)] RECT[] pRectLoc, [In, ComAliasName("DSkin.OLE.LONG")] int lCloseHint, [ComAliasName("DSkin.OLE.DWORD")] out uint pHitResult);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetNaturalExtent([In, ComAliasName("DSkin.OLE.DWORD")] uint dwAspect, [In, ComAliasName("DSkin.OLE.LONG")] int lindex, [In, ComAliasName("DSkin.OLE.DVTARGETDEVICE"), MarshalAs(UnmanagedType.LPArray)] DVTARGETDEVICE[] ptd, [In] IntPtr hicTargetDev, [In, ComAliasName("DSkin.OLE.DVEXTENTINFO"), MarshalAs(UnmanagedType.LPArray)] DVEXTENTINFO[] pExtentInfo, [Out, ComAliasName("DSkin.OLE.LPSIZEL"), MarshalAs(UnmanagedType.LPArray)] SIZEL[] pSizel);
    }
}

