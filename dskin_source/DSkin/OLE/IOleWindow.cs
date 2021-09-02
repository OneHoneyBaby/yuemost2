namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ComConversionLoss, InterfaceType((short) 1), Guid("00000114-0000-0000-C000-000000000046")]
    public interface IOleWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetWindow(out IntPtr phwnd);
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ContextSensitiveHelp([In, ComAliasName("DSkin.OLE.BOOL")] int fEnterMode);
    }
}

