namespace DSkin.OLE
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public class REOBJECT
    {
        public int cbStruct = Marshal.SizeOf(typeof(REOBJECT));
        public int posistion;
        public Guid clsid;
        public IntPtr poleobj;
        public IStorage pstg;
        public IOleClientSite polesite;
        public Size sizel;
        public uint dvAspect;
        public uint dwFlags;
        public uint dwUser;
        public override string ToString()
        {
            return string.Format("posistion:{0} ,tag:{1}", this.posistion, this.dwUser);
        }
    }
}

