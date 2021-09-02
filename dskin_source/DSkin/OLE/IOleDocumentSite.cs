namespace DSkin.OLE
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("B722BCC7-4E68-101B-A2BC-00AA00404770")]
    public interface IOleDocumentSite
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void ActivateMe([In, MarshalAs(UnmanagedType.Interface)] IOleDocumentView pViewToActivate);
    }
}

