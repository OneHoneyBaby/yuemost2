namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("00000116-0000-0000-C000-000000000046"), ComConversionLoss]
    public interface IOleInPlaceFrame : IOleWindow, GInterface0
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void InsertMenus([In] IntPtr hmenuShared, [In, Out, ComAliasName("DSkin.OLE.OLEMENUGROUPWIDTHS"), MarshalAs(UnmanagedType.LPArray)] OLEMENUGROUPWIDTHS[] lpMenuWidths);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetMenu([In] IntPtr hmenuShared, [In, ComAliasName("DSkin.OLE.HOLEMENU")] IntPtr HOLEMENU, [In] IntPtr hwndActiveObject);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void RemoveMenus([In] IntPtr hmenuShared);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetStatusText([In, ComAliasName("DSkin.OLE.LPCOLESTR"), MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void EnableModeless([In, ComAliasName("DSkin.OLE.BOOL")] int fEnable);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall)]
        int TranslateAccelerator([In, ComAliasName("DSkin.OLE.MSG"), MarshalAs(UnmanagedType.LPArray)] MSG[] lpmsg, [In, ComAliasName("DSkin.OLE.WORD")] ushort wID);
    }
}

