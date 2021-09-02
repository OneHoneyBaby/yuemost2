namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("0000012A-0000-0000-C000-000000000046")]
    public interface IContinue
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void imethod_0();
    }
}

