namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr wkeCreateViewCallback(IntPtr webView, IntPtr param, ref DSkin.DirectUI.wkeNewViewInfo info);
}

