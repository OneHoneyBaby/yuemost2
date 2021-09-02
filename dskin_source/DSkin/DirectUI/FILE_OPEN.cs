namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public delegate IntPtr FILE_OPEN([In, MarshalAs(UnmanagedType.LPStr)] string path);
}

