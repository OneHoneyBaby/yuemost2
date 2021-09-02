namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public delegate bool wkeJSSetPropertyCallback(IntPtr es, long @object, [In, MarshalAs(UnmanagedType.LPWStr)] string propertyName, long value);
}

