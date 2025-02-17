﻿namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    [ComImport, Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream : ISequentialStream
    {
        int Seek(ulong dlibMove, uint dwOrigin, out ulong plibNewPosition);
        int SetSize(ulong libNewSize);
        int CopyTo([In] DSkin.OLE.IStream pstm, ulong cb, out ulong pcbRead, out ulong pcbWritten);
        int Commit(uint grfCommitFlags);
        int Revert();
        int LockRegion(ulong libOffset, ulong cb, uint dwLockType);
        int UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);
        int Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, uint grfStatFlag);
        int Clone(out DSkin.OLE.IStream ppstm);
    }
}

