namespace DSkin.Forms
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ComVisible(true)]
    public class DSkinWindowForm : Form
    {
        private bool bool_0 = false;
        private bool bool_1 = true;
        private bool bool_2 = false;
        private DSkin.NativeMethods.DWM_BLURBEHIND dwm_BLURBEHIND_0 = new DSkin.NativeMethods.DWM_BLURBEHIND();
        private IntPtr intptr_0 = IntPtr.Zero;
        private Size size_0;

        public void CloseDwm()
        {
            if ((Environment.OSVersion.Version.Major >= 6) && DSkin.NativeMethods.DwmIsCompositionEnabled())
            {
                this.dwm_BLURBEHIND_0.fEnable = false;
                DSkin.NativeMethods.DwmEnableBlurBehindWindow(base.Handle.ToInt32(), ref this.dwm_BLURBEHIND_0);
                this.bool_2 = false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (this.intptr_0 != IntPtr.Zero)
            {
                DSkin.NativeMethods.DeleteObject(this.intptr_0);
            }
        }

        public void EnabledDwm()
        {
            if ((Environment.OSVersion.Version.Major >= 6) && DSkin.NativeMethods.DwmIsCompositionEnabled())
            {
                this.dwm_BLURBEHIND_0.dwFlags = 3;
                this.dwm_BLURBEHIND_0.fEnable = true;
                this.dwm_BLURBEHIND_0.hRegionBlur = IntPtr.Zero;
                DSkin.NativeMethods.DwmEnableBlurBehindWindow(base.Handle.ToInt32(), ref this.dwm_BLURBEHIND_0);
                this.bool_2 = true;
            }
        }

        private IntPtr method_0(Bitmap bitmap_0)
        {
            DSkin.BITMAP bitmap = new DSkin.BITMAP();
            Rectangle rect = new Rectangle();
            BitmapData bitmapdata = new BitmapData();
            rect.Y = 0;
            rect.X = 0;
            rect.Width = bitmap_0.Width;
            rect.Height = bitmap_0.Height;
            bitmapdata = bitmap_0.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            bitmap.bmType = 0;
            bitmap.bmWidth = bitmapdata.Width;
            bitmap.bmHeight = bitmapdata.Height;
            bitmap.bmWidthBytes = bitmapdata.Stride;
            bitmap.bmPlanes = 1;
            bitmap.bmBitsPixel = 0x20;
            bitmap.bmBits = bitmapdata.Scan0;
            IntPtr ptr = DSkin.NativeMethods.CreateBitmapIndirect(ref bitmap);
            bitmap_0.UnlockBits(bitmapdata);
            return ptr;
        }

        private IntPtr method_1(IntPtr intptr_1, Size size_1)
        {
            DSkin.BITMAP bitmap = new DSkin.BITMAP();
            Rectangle rectangle = new Rectangle {
                Y = 0,
                X = 0,
                Width = size_1.Width,
                Height = size_1.Height
            };
            bitmap.bmType = 0;
            bitmap.bmWidth = size_1.Width;
            bitmap.bmHeight = size_1.Height;
            bitmap.bmWidthBytes = size_1.Width * 4;
            bitmap.bmPlanes = 1;
            bitmap.bmBitsPixel = 0x20;
            bitmap.bmBits = intptr_1;
            return DSkin.NativeMethods.CreateBitmapIndirect(ref bitmap);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!(!base.DesignMode || Class13.smethod_0()))
            {
                base.Controls.Remove(e.Control);
                base.Close();
                base.Dispose();
            }
        }

        protected override void OnCreateControl()
        {
            if (!base.DesignMode)
            {
                Class13.smethod_5();
            }
            else
            {
                Class13.smethod_2();
                if (!Class13.smethod_0())
                {
                    base.Close();
                    base.Dispose();
                    return;
                }
            }
            base.OnCreateControl();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.bool_2)
            {
                this.EnabledDwm();
            }
            this.bool_0 = true;
        }

        public virtual void UpdateLayeredWindow(Bitmap bitmap)
        {
            this.UpdateLayeredWindow(bitmap, 1.0);
        }

        public virtual void UpdateLayeredWindow(double opacity, Action<Graphics> action)
        {
            if ((base.Width > 0) && (base.Height > 0))
            {
                IntPtr zero = IntPtr.Zero;
                IntPtr dC = DSkin.NativeMethods.GetDC(IntPtr.Zero);
                IntPtr hdc = DSkin.NativeMethods.CreateCompatibleDC(dC);
                if (this.size_0 != base.Size)
                {
                    DSkin.NativeMethods.BITMAPINFO_FLAT bitmapinfo_flat;
                    this.size_0 = base.Size;
                    if (this.intptr_0 != IntPtr.Zero)
                    {
                        DSkin.NativeMethods.DeleteObject(this.intptr_0);
                    }
                    bitmapinfo_flat = new DSkin.NativeMethods.BITMAPINFO_FLAT {
                        bmiHeader_biSize = Marshal.SizeOf(typeof(DSkin.NativeMethods.BITMAPINFOHEADER)),
                        bmiHeader_biBitCount = 0x20,
                        bmiHeader_biHeight = base.Height,
                        bmiHeader_biWidth = base.Width,
                        bmiHeader_biPlanes = 1,
                        bmiHeader_biCompression = 0,
                        bmiHeader_biXPelsPerMeter = 0,
                        bmiHeader_biYPelsPerMeter = 0,
                        bmiHeader_biClrUsed = 0,
                        bmiHeader_biClrImportant = 0,
                        bmiHeader_biSizeImage = ((bitmapinfo_flat.bmiHeader_biWidth * bitmapinfo_flat.bmiHeader_biHeight) * bitmapinfo_flat.bmiHeader_biBitCount) / 8
                    };
                    int ppvBits = 0;
                    this.intptr_0 = DSkin.NativeMethods.CreateDIBSection(hdc, ref bitmapinfo_flat, 0, ref ppvBits, IntPtr.Zero, 0);
                }
                try
                {
                    Point pptDst = new Point(base.Left, base.Top);
                    Size psize = new Size(base.Width, base.Height);
                    Point pptSrc = new Point(0, 0);
                    zero = DSkin.NativeMethods.SelectObject(hdc, this.intptr_0);
                    using (Graphics graphics = Graphics.FromHdc(hdc))
                    {
                        action(graphics);
                    }
                    DSkin.NativeMethods.BLENDFUNCTION pblend = new DSkin.NativeMethods.BLENDFUNCTION {
                        BlendOp = 0,
                        SourceConstantAlpha = (byte) ((int) (255.0 * opacity)),
                        AlphaFormat = 1,
                        BlendFlags = 0
                    };
                    DSkin.NativeMethods.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, hdc, ref pptSrc, 0, ref pblend, 2);
                }
                finally
                {
                    if (this.intptr_0 != IntPtr.Zero)
                    {
                        DSkin.NativeMethods.SelectObject(hdc, zero);
                    }
                    DSkin.NativeMethods.ReleaseDC(IntPtr.Zero, dC);
                    DSkin.NativeMethods.DeleteDC(hdc);
                }
            }
        }

        public virtual void UpdateLayeredWindow(Bitmap bitmap, double opacity)
        {
            if (!(Image.IsCanonicalPixelFormat(bitmap.PixelFormat) && Image.IsAlphaPixelFormat(bitmap.PixelFormat)))
            {
                throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
            }
            IntPtr zero = IntPtr.Zero;
            IntPtr dC = DSkin.NativeMethods.GetDC(IntPtr.Zero);
            IntPtr hObject = IntPtr.Zero;
            IntPtr hDC = DSkin.NativeMethods.CreateCompatibleDC(dC);
            try
            {
                Point pptDst = new Point(base.Left, base.Top);
                Size psize = new Size(bitmap.Width, bitmap.Height);
                DSkin.NativeMethods.BLENDFUNCTION pblend = new DSkin.NativeMethods.BLENDFUNCTION();
                Point pptSrc = new Point(0, 0);
                hObject = this.method_0(bitmap);
                zero = DSkin.NativeMethods.SelectObject(hDC, hObject);
                pblend.BlendOp = 0;
                pblend.SourceConstantAlpha = (byte) ((int) (255.0 * opacity));
                pblend.AlphaFormat = 1;
                pblend.BlendFlags = 0;
                DSkin.NativeMethods.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, hDC, ref pptSrc, 0, ref pblend, 2);
            }
            finally
            {
                if (hObject != IntPtr.Zero)
                {
                    DSkin.NativeMethods.SelectObject(hDC, zero);
                    DSkin.NativeMethods.DeleteObject(hObject);
                }
                DSkin.NativeMethods.ReleaseDC(IntPtr.Zero, dC);
                DSkin.NativeMethods.DeleteDC(hDC);
            }
        }

        public virtual void UpdateLayeredWindow(IntPtr bitmap, Size size, double opacity)
        {
            IntPtr zero = IntPtr.Zero;
            IntPtr dC = DSkin.NativeMethods.GetDC(IntPtr.Zero);
            IntPtr hObject = IntPtr.Zero;
            IntPtr hDC = DSkin.NativeMethods.CreateCompatibleDC(dC);
            try
            {
                Point pptDst = new Point(base.Left, base.Top);
                Size psize = new Size(size.Width, size.Height);
                DSkin.NativeMethods.BLENDFUNCTION pblend = new DSkin.NativeMethods.BLENDFUNCTION();
                Point pptSrc = new Point(0, 0);
                hObject = this.method_1(bitmap, size);
                zero = DSkin.NativeMethods.SelectObject(hDC, hObject);
                pblend.BlendOp = 0;
                pblend.SourceConstantAlpha = (byte) ((int) (255.0 * opacity));
                pblend.AlphaFormat = 1;
                pblend.BlendFlags = 0;
                DSkin.NativeMethods.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, hDC, ref pptSrc, 0, ref pblend, 2);
            }
            finally
            {
                if (hObject != IntPtr.Zero)
                {
                    DSkin.NativeMethods.SelectObject(hDC, zero);
                    DSkin.NativeMethods.DeleteObject(hObject);
                }
                DSkin.NativeMethods.ReleaseDC(IntPtr.Zero, dC);
                DSkin.NativeMethods.DeleteDC(hDC);
            }
        }

        [Description("启用AeroGlass毛玻璃效果，需要系统支持并且需要将背景色设置为半透明色"), DefaultValue(false), Category("DSkin")]
        public bool Boolean_0
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                if (value)
                {
                    if (this.bool_0)
                    {
                        this.EnabledDwm();
                    }
                    this.bool_2 = true;
                }
                else
                {
                    if (this.bool_0)
                    {
                        this.CloseDwm();
                    }
                    this.bool_2 = false;
                }
            }
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.Style |= 0x20000;
                if (!(base.DesignMode || !this.bool_1))
                {
                    createParams.ExStyle |= 0x80000;
                }
                return createParams;
            }
        }

        [Category("DSkin"), Description("是否为LayeredWindow层窗体，为true时，可实现任意透明，动态特效，并且提供高效不闪烁的图像渲染")]
        public virtual bool IsLayeredWindowForm
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }
    }
}

