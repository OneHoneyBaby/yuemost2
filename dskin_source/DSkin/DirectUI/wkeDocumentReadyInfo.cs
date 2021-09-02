namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeDocumentReadyInfo
    {
        public IntPtr url;
        public IntPtr frameJSState;
        public IntPtr mainFrameJSState;
    }
}

