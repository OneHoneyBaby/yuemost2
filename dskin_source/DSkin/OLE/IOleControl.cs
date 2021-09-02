namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B196B288-BAB4-101A-B69C-00AA00341D07"), InterfaceType((short) 1)]
    public interface IOleControl
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetControlInfo([Out, ComAliasName("DSkin.OLE.CONTROLINFO"), MarshalAs(UnmanagedType.LPArray)] CONTROLINFO[] pCI);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnMnemonic([In, ComAliasName("DSkin.OLE.MSG"), MarshalAs(UnmanagedType.LPArray)] MSG[] pMsg);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnAmbientPropertyChange([In, ComAliasName("DSkin.OLE.DISPID")] int DISPID);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void FreezeEvents([In, ComAliasName("DSkin.OLE.BOOL")] int bFreeze);
    }
}

