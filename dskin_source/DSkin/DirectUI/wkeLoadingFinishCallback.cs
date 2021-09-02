namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void wkeLoadingFinishCallback(IntPtr webView, IntPtr url, DSkin.DirectUI.wkeLoadingResult result, IntPtr failedReason);
}

