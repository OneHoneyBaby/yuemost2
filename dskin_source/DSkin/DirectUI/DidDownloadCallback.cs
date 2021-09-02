namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DidDownloadCallback([In, MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr data, uint size);
}

