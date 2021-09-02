namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public delegate long wkeJSGetPropertyCallback(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPWStr)] string propertyName);
}

