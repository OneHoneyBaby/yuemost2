namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void wkeConsoleMessageCallback(IntPtr webView, ref DSkin.DirectUI.wkeConsoleMessage message);
}

