namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SetDataCallback(IntPtr _caller, IntPtr data, uint length);
}

