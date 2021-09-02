namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Threading;
    using System.Windows.Forms;

    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public class cTransition : NativeWindow, IDisposable
    {
        private Bitmap bitmap_0;
        private bool bool_0 = false;
        private bool bool_1 = false;
        private cStoreDc cStoreDc_0 = new cStoreDc();
        private cStoreDc cStoreDc_1 = new cStoreDc();
        private int int_0 = 0;
        private int int_1 = 0;
        private IntPtr intptr_0 = IntPtr.Zero;
        private IntPtr intptr_1 = IntPtr.Zero;
        private Rectangle rectangle_0;

        public event DisposingDelegate Disposing;

        public cTransition(IntPtr hWnd, IntPtr hParent, Bitmap mask, Rectangle area)
        {
            if (hWnd == IntPtr.Zero)
            {
                throw new Exception("The control handle is invalid.");
            }
            this.intptr_0 = hWnd;
            if (mask != null)
            {
                this.method_1(mask);
                this.rectangle_0 = area;
                if (hParent != IntPtr.Zero)
                {
                    this.intptr_1 = hParent;
                    base.AssignHandle(this.intptr_1);
                }
                else
                {
                    this.intptr_1 = this.intptr_0;
                    base.AssignHandle(this.intptr_0);
                }
                this.method_2();
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr intptr_2, ref Struct7 struct7_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr intptr_2, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_3, int int_6, int int_7, int int_8);
        public void Dispose()
        {
            this.ReleaseHandle();
            if (this.disposingDelegate_0 != null)
            {
                this.disposingDelegate_0();
            }
            this.method_3();
            if (this.cStoreDc_1 != null)
            {
                this.cStoreDc_1.Dispose();
            }
            if (this.cStoreDc_0 != null)
            {
                this.cStoreDc_0.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr intptr_2, ref Struct7 struct7_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point point_0);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr intptr_2);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr intptr_2, ref Struct6 struct6_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool KillTimer(IntPtr intptr_2, uint uint_0);
        private Bitmap method_0()
        {
            return this.bitmap_0;
        }

        private void method_1(Bitmap value)
        {
            this.bitmap_0 = value;
            if (this.cStoreDc_1.Hdc != IntPtr.Zero)
            {
                this.cStoreDc_1.Dispose();
                this.cStoreDc_1 = new cStoreDc();
            }
            this.cStoreDc_1.Width = this.bitmap_0.Width;
            this.cStoreDc_1.Height = this.bitmap_0.Height;
            SelectObject(this.cStoreDc_1.Hdc, this.bitmap_0.GetHbitmap());
        }

        private void method_2()
        {
            if (this.int_1 > 0)
            {
                this.method_3();
            }
            SetTimer(this.intptr_1, 0x42, 0x19, IntPtr.Zero);
        }

        private void method_3()
        {
            if (this.int_1 > 0)
            {
                KillTimer(this.intptr_1, 0x42);
                this.int_1 = 0;
            }
        }

        private void method_4()
        {
            if (!this.bool_1)
            {
                this.bool_1 = true;
                this.method_7();
            }
            if (this.int_0 < 10)
            {
                this.int_0++;
            }
            this.method_6();
        }

        private void method_5()
        {
            if (this.bool_1)
            {
                this.bool_1 = false;
            }
            if (this.int_0 > 1)
            {
                this.int_0--;
                this.method_6();
            }
            else
            {
                Control control = Control.FromHandle(this.intptr_1);
                if (control != null)
                {
                    control.Refresh();
                }
                this.Dispose();
            }
        }

        private void method_6()
        {
            byte opacity = 0;
            IntPtr zero = IntPtr.Zero;
            cStoreDc dc = new cStoreDc();
            Struct6 struct2 = new Struct6();
            GetWindowRect(this.intptr_0, ref struct2);
            OffsetRect(ref struct2, -struct2.bVoqGpjgoK, -struct2.int_0);
            Rectangle dest = new Rectangle(this.rectangle_0.Left, this.rectangle_0.Top, this.rectangle_0.Right - this.rectangle_0.Left, this.rectangle_0.Bottom - this.rectangle_0.Top);
            dc.Width = struct2.int_1;
            dc.Height = struct2.eqNqresVqa;
            opacity = (byte) (this.int_0 * 15);
            BitBlt(dc.Hdc, 0, 0, struct2.int_1, struct2.eqNqresVqa, this.cStoreDc_0.Hdc, 0, 0, 0xcc0020);
            using (new AlphaStretch(this.cStoreDc_1.Hdc, dc.Hdc, new Rectangle(0, 0, this.cStoreDc_1.Width, this.cStoreDc_1.Height), dest, 2, opacity))
            {
            }
            zero = GetDC(this.intptr_0);
            BitBlt(zero, 0, 0, struct2.int_1, struct2.eqNqresVqa, dc.Hdc, 0, 0, 0xcc0020);
            ReleaseDC(this.intptr_0, zero);
            dc.Dispose();
            ValidateRect(this.intptr_0, ref struct2);
        }

        private void method_7()
        {
            Struct6 struct2 = new Struct6();
            GetWindowRect(this.intptr_0, ref struct2);
            this.cStoreDc_0.Width = struct2.int_1 - struct2.bVoqGpjgoK;
            this.cStoreDc_0.Height = struct2.eqNqresVqa - struct2.int_0;
            if (this.cStoreDc_0.Hdc != IntPtr.Zero)
            {
                using (Graphics graphics = Graphics.FromHdc(this.cStoreDc_0.Hdc))
                {
                    graphics.CopyFromScreen(struct2.bVoqGpjgoK, struct2.int_0, 0, 0, new Size(this.cStoreDc_0.Width, this.cStoreDc_0.Height), CopyPixelOperation.SourceCopy);
                }
            }
        }

        private bool method_8()
        {
            Point point = new Point();
            Struct6 struct2 = new Struct6(this.rectangle_0.Left, this.rectangle_0.Top, this.rectangle_0.Right, this.rectangle_0.Bottom);
            GetCursorPos(ref point);
            ScreenToClient(this.intptr_1, ref point);
            return PtInRect(ref struct2, point);
        }

        [DllImport("user32.dll")]
        private static extern int OffsetRect(ref Struct6 struct6_0, int int_2, int int_3);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool PtInRect([In] ref Struct6 struct6_0, Point point_0);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr intptr_2, IntPtr intptr_3);
        [DllImport("user32.dll")]
        private static extern int ScreenToClient(IntPtr intptr_2, ref Point point_0);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr intptr_2, IntPtr intptr_3);
        [DllImport("user32.dll")]
        private static extern IntPtr SetTimer(IntPtr intptr_2, int int_2, uint uint_0, IntPtr intptr_3);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr intptr_2, ref Struct6 struct6_0);
        protected override void WndProc(ref Message m)
        {
            Struct7 struct2 = new Struct7();
            int msg = m.Msg;
            if (msg <= 0x113)
            {
                if (msg != 15)
                {
                    if (msg != 0x113)
                    {
                        goto Label_00EC;
                    }
                    if (!((this.int_1 <= 50) || this.method_8()))
                    {
                        this.method_3();
                    }
                    else if (this.bool_1)
                    {
                        this.method_4();
                    }
                    else
                    {
                        this.method_5();
                    }
                    this.int_1++;
                    base.WndProc(ref m);
                }
                else if (!(this.bool_0 || (this.int_0 <= 1)))
                {
                    this.bool_0 = true;
                    BeginPaint(m.HWnd, ref struct2);
                    this.method_6();
                    EndPaint(m.HWnd, ref struct2);
                    this.bool_0 = false;
                }
                else
                {
                    base.WndProc(ref m);
                }
                return;
            }
            switch (msg)
            {
                case 0x200:
                    if (!this.method_8())
                    {
                        this.method_5();
                    }
                    else
                    {
                        this.method_4();
                    }
                    base.WndProc(ref m);
                    return;

                case 0x201:
                    this.Dispose();
                    base.WndProc(ref m);
                    return;

                case 0x2a3:
                    this.method_5();
                    base.WndProc(ref m);
                    return;
            }
        Label_00EC:
            base.WndProc(ref m);
        }

        public delegate void DisposingDelegate();

        [StructLayout(LayoutKind.Sequential)]
        internal struct Struct6
        {
            internal int bVoqGpjgoK;
            internal int int_0;
            internal int int_1;
            internal int eqNqresVqa;
            internal Struct6(int int_2, int int_3, int int_4, int int_5)
            {
                this.bVoqGpjgoK = int_2;
                this.int_0 = int_3;
                this.int_1 = int_4;
                this.eqNqresVqa = int_5;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct7
        {
            internal IntPtr intptr_0;
            internal int int_0;
            internal cTransition.Struct6 struct6_0;
            internal int vBbqpnqIqe;
            internal int int_1;
            internal int int_2;
            internal int int_3;
            internal int int_4;
            internal int int_5;
            internal int int_6;
            internal int int_7;
            internal int int_8;
            internal int int_9;
        }
    }
}

