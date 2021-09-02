namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void ReadFileCallback(IntPtr _caller, [In, MarshalAs(UnmanagedType.LPStr)] string szFile, SetDataCallback setData);
}

