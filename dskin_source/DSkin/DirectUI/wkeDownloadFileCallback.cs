namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public delegate bool wkeDownloadFileCallback(IntPtr handle, [In, MarshalAs(UnmanagedType.LPStr)] string url, [In, MarshalAs(UnmanagedType.LPStr)] string mimeType);
}

