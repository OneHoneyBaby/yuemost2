using DSkin;
using DSkin.Controls;
using DSkin.OLE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class Class54
{
    private IRichEditOle irichEditOle_0;
    private object object_0;

    public Class54(GClass4 gclass4_0)
    {
        this.object_0 = gclass4_0;
    }

    public IRichEditOle method_0()
    {
        if (this.irichEditOle_0 == null)
        {
            this.irichEditOle_0 = DSkin.NativeMethods.SendMessage(this.object_0.Handle, 0x43c, 0);
        }
        return this.irichEditOle_0;
    }

    public void method_1(Control control_0)
    {
        this.method_2(control_0, this.object_0.TextLength, 1);
    }

    public void method_10(REOBJECT reobject_0)
    {
        Point positionFromCharIndex = this.object_0.GetPositionFromCharIndex(reobject_0.posistion);
        Size size = this.method_11(reobject_0);
        Rectangle rc = new Rectangle(positionFromCharIndex, size);
        this.object_0.Invalidate(rc, false);
    }

    private Size method_11(REOBJECT reobject_0)
    {
        using (Graphics graphics = Graphics.FromHwnd(this.object_0.Handle))
        {
            Point[] pts = new Point[1];
            graphics.PageUnit = GraphicsUnit.Millimeter;
            pts[0] = new Point(reobject_0.sizel.Width / 100, reobject_0.sizel.Height / 100);
            graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, pts);
            return new Size(pts[0]);
        }
    }

    public void method_2(Control control_0, int int_0, uint uint_0)
    {
        if (control_0 != null)
        {
            DSkin.OLE.ILockBytes bytes;
            DSkin.OLE.IStorage storage;
            DSkin.OLE.IOleClientSite site;
            Guid guid = Marshal.GenerateGuidForType(control_0.GetType());
            DSkin.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
            DSkin.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
            this.method_0().GetClientSite(out site);
            REOBJECT lpreobject = new REOBJECT {
                posistion = int_0,
                clsid = guid,
                pstg = storage,
                poleobj = Marshal.GetIUnknownForObject(control_0),
                polesite = site,
                dvAspect = 1,
                dwFlags = 2,
                dwUser = uint_0
            };
            this.method_0().InsertObject(lpreobject);
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
        }
    }

    public bool method_3(string string_0)
    {
        return this.method_4(string_0, this.object_0.TextLength);
    }

    public bool method_4(string string_0, int int_0)
    {
        DSkin.OLE.ILockBytes bytes;
        DSkin.OLE.IStorage storage;
        DSkin.OLE.IOleClientSite site;
        object obj2;
        DSkin.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
        DSkin.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
        this.method_0().GetClientSite(out site);
        FORMATETC pFormatEtc = new FORMATETC {
            cfFormat = (CLIPFORMAT) 0,
            ptd = IntPtr.Zero,
            dwAspect = DVASPECT.DVASPECT_CONTENT,
            lindex = -1,
            tymed = TYMED.TYMED_NULL
        };
        Guid riid = new Guid("{00000112-0000-0000-C000-000000000046}");
        Guid rclsid = new Guid("{00000000-0000-0000-0000-000000000000}");
        DSkin.NativeMethods.OleCreateFromFile(ref rclsid, string_0, ref riid, 1, ref pFormatEtc, site, storage, out obj2);
        if (obj2 == null)
        {
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
            return false;
        }
        DSkin.OLE.IOleObject pUnk = (DSkin.OLE.IOleObject) obj2;
        Guid pClsid = new Guid();
        pUnk.GetUserClassID(ref pClsid);
        DSkin.NativeMethods.OleSetContainedObject(pUnk, true);
        REOBJECT lpreobject = new REOBJECT {
            posistion = int_0,
            clsid = pClsid,
            pstg = storage,
            poleobj = Marshal.GetIUnknownForObject(pUnk),
            polesite = site,
            dvAspect = 1,
            dwFlags = 2,
            dwUser = 0
        };
        this.method_0().InsertObject(lpreobject);
        Marshal.ReleaseComObject(bytes);
        Marshal.ReleaseComObject(site);
        Marshal.ReleaseComObject(storage);
        Marshal.ReleaseComObject(pUnk);
        return true;
    }

    public REOBJECT method_5(DSkin.OLE.IOleObject ioleObject_0, int int_0)
    {
        return this.method_6(ioleObject_0, int_0, this.object_0.TextLength);
    }

    public REOBJECT method_6(DSkin.OLE.IOleObject ioleObject_0, int int_0, int int_1)
    {
        DSkin.OLE.ILockBytes bytes;
        DSkin.OLE.IStorage storage;
        DSkin.OLE.IOleClientSite site;
        if (ioleObject_0 == null)
        {
            return null;
        }
        DSkin.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
        DSkin.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
        this.method_0().GetClientSite(out site);
        Guid pClsid = new Guid();
        ioleObject_0.GetUserClassID(ref pClsid);
        DSkin.NativeMethods.OleSetContainedObject(ioleObject_0, true);
        REOBJECT lpreobject = new REOBJECT {
            posistion = int_1,
            clsid = pClsid,
            pstg = storage,
            poleobj = Marshal.GetIUnknownForObject(ioleObject_0),
            polesite = site,
            dvAspect = 1,
            dwFlags = 2,
            dwUser = (uint) int_0
        };
        this.method_0().InsertObject(lpreobject);
        Marshal.ReleaseComObject(bytes);
        Marshal.ReleaseComObject(site);
        Marshal.ReleaseComObject(storage);
        return lpreobject;
    }

    public void method_7()
    {
        int objectCount = this.method_0().GetObjectCount();
        for (int i = 0; i < objectCount; i++)
        {
            REOBJECT lpreobject = new REOBJECT();
            this.method_0().GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
            Point positionFromCharIndex = this.object_0.GetPositionFromCharIndex(lpreobject.posistion);
            Rectangle rc = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, 50, 50);
            this.object_0.Invalidate(rc, false);
        }
    }

    public List<REOBJECT> method_8()
    {
        List<REOBJECT> list = new List<REOBJECT>();
        int objectCount = this.method_0().GetObjectCount();
        for (int i = 0; i < objectCount; i++)
        {
            REOBJECT lpreobject = new REOBJECT();
            this.method_0().GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
            list.Add(lpreobject);
        }
        return list;
    }

    public void method_9(int int_0)
    {
        REOBJECT lpreobject = new REOBJECT();
        this.method_0().GetObject(int_0, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
        this.method_10(lpreobject);
    }
}

