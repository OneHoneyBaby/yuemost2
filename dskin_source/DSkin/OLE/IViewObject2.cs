namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("00000127-0000-0000-C000-000000000046"), InterfaceType((short) 1)]
    public interface IViewObject2 : IViewObject
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Draw([In, ComAliasName("DSkin.OLE.DWORD")] uint dwDrawAspect, [In, ComAliasName("DSkin.OLE.LONG")] int lindex, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint pvAspect, [In, ComAliasName("DSkin.OLE.DVTARGETDEVICE"), MarshalAs(UnmanagedType.LPArray)] DVTARGETDEVICE[] ptd, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint hdcTargetDev, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint hdcDraw, [In, ComAliasName("DSkin.OLE.LPCRECTL"), MarshalAs(UnmanagedType.LPArray)] RECTL[] lprcBounds, [In, ComAliasName("DSkin.OLE.LPCRECTL"), MarshalAs(UnmanagedType.LPArray)] RECTL[] rectl_0, [In, MarshalAs(UnmanagedType.Interface)] IContinue pContinue);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetColorSet([In, ComAliasName("DSkin.OLE.DWORD")] uint dwDrawAspect, [In, ComAliasName("DSkin.OLE.LONG")] int lindex, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint pvAspect, [In, ComAliasName("DSkin.OLE.DVTARGETDEVICE"), MarshalAs(UnmanagedType.LPArray)] DVTARGETDEVICE[] ptd, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint hicTargetDev, [ComAliasName("DSkin.OLE.LOGPALETTE")] out IntPtr ppColorSet);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Freeze([In, ComAliasName("DSkin.OLE.DWORD")] uint dwDrawAspect, [In, ComAliasName("DSkin.OLE.LONG")] int lindex, [In, ComAliasName("DSkin.OLE.ULONG_PTR")] uint pvAspect, [ComAliasName("DSkin.OLE.DWORD")] out uint pdwFreeze);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Unfreeze([In, ComAliasName("DSkin.OLE.DWORD")] uint dwFreeze);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetAdvise([In, ComAliasName("DSkin.OLE.DWORD")] uint aspects, [In, ComAliasName("DSkin.OLE.DWORD")] uint ADVF, [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetAdvise([ComAliasName("DSkin.OLE.DWORD")] out uint pAspects, [ComAliasName("DSkin.OLE.DWORD")] out uint pAdvf, [MarshalAs(UnmanagedType.Interface)] out IAdviseSink ppAdvSink);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetExtent([In, ComAliasName("DSkin.OLE.DWORD")] uint dwDrawAspect, [In, ComAliasName("DSkin.OLE.LONG")] int lindex, [In, ComAliasName("DSkin.OLE.DVTARGETDEVICE"), MarshalAs(UnmanagedType.LPArray)] DVTARGETDEVICE[] ptd, [Out, ComAliasName("DSkin.OLE.LPSIZEL"), MarshalAs(UnmanagedType.LPArray)] SIZEL[] LPSIZEL);
    }
}

