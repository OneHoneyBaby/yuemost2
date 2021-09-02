namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeJSData
    {
        public IntPtr userdata;
        public wkeJSGetPropertyCallback propertyGet;
        public wkeJSSetPropertyCallback propertySet;
        public wkeJSFinalizeCallback finalize;
        public wkeJSCallAsFunctionCallback callAsFunction;
    }
}

