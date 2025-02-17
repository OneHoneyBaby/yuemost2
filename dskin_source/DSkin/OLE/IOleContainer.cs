﻿namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [Guid("0000011B-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
    public interface IOleContainer
    {
        void ParseDisplayName([In, MarshalAs(UnmanagedType.Interface)] object pbc, [In, MarshalAs(UnmanagedType.BStr)] string pszDisplayName, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten, [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);
        void EnumObjects([In, MarshalAs(UnmanagedType.U4)] int grfFlags, [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppenum);
        void LockContainer([In, MarshalAs(UnmanagedType.I4)] int fLock);
    }
}

