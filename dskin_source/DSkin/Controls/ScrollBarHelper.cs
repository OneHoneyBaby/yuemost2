namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ScrollBarHelper : NativeWindow, IDisposable
    {
        private Control control_0;
        private DSkinScrollBar dskinScrollBar_0;
        private DSkinScrollBar dskinScrollBar_1;
        private Image ifpTjeqac5;
        private int int_0 = 0;
        private int int_1 = 0;
        private static readonly IntPtr intptr_0 = new IntPtr(-2);
        private static readonly IntPtr intptr_1 = new IntPtr(-1);
        private static readonly IntPtr intptr_2 = new IntPtr(0);
        private static readonly IntPtr intptr_3 = new IntPtr(1);
        private static IntPtr intptr_4 = new IntPtr(1);
        private IntPtr intptr_5 = IntPtr.Zero;
        private IntPtr intptr_6 = IntPtr.Zero;

        public ScrollBarHelper(Control control)
        {
            DSkinScrollBar bar = new DSkinScrollBar {
                Orientation = Orientation.Vertical,
                Width = 0x11,
                ArrowHeight = 0x11,
                ArrowScrollBarGap = 7,
                BitmapCache = true,
                BackColor = Color.White
            };
            this.dskinScrollBar_0 = bar;
            DSkinScrollBar bar2 = new DSkinScrollBar {
                Orientation = Orientation.Horizontal,
                Height = 0x11,
                ArrowHeight = 0x11,
                ArrowScrollBarGap = 7,
                BitmapCache = true,
                BackColor = Color.White
            };
            this.dskinScrollBar_1 = bar2;
            this.method_11();
            this.intptr_6 = control.Handle;
            this.control_0 = control;
            this.method_5();
            base.AssignHandle(this.intptr_6);
            this.dskinScrollBar_0.ValueChanged += new EventHandler(this.dskinScrollBar_0_ValueChanged);
            if (control is TextBox)
            {
                this.dskinScrollBar_0.MouseDown += new MouseEventHandler(this.dskinScrollBar_0_MouseDown);
                this.dskinScrollBar_0.MouseUp += new MouseEventHandler(this.dskinScrollBar_0_MouseUp);
                this.dskinScrollBar_0.MouseMove += new MouseEventHandler(this.dskinScrollBar_0_MouseMove);
            }
            this.dskinScrollBar_1.ValueChanged += new EventHandler(this.dskinScrollBar_1_ValueChanged);
        }

        public void Dispose()
        {
            this.ReleaseHandle();
            if (this.intptr_5 != IntPtr.Zero)
            {
                DSkin.NativeMethods.DestroyWindow(this.intptr_5);
            }
            if (this.dskinScrollBar_0 != null)
            {
                this.dskinScrollBar_0.Dispose();
                this.dskinScrollBar_0 = null;
            }
            if (this.dskinScrollBar_1 != null)
            {
                this.dskinScrollBar_1.Dispose();
                this.dskinScrollBar_1 = null;
            }
            GC.SuppressFinalize(this);
        }

        public void drawScrollBar()
        {
            SCROLLBARINFO scrollbarinfo;
            DSkin.SCROLLINFO scrollinfo;
            DSkin.RECT lpRect = new DSkin.RECT();
            IntPtr zero = IntPtr.Zero;
            scrollbarinfo = new SCROLLBARINFO {
                cbSize = Marshal.SizeOf(scrollbarinfo)
            };
            if (this.HasHorizontal())
            {
                scrollinfo = new DSkin.SCROLLINFO {
                    fMask = 0x17
                };
                DSkin.NativeMethods.GetScrollInfo(new HandleRef(this, base.Handle), 0, ref scrollinfo);
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffa, ref scrollbarinfo);
                lpRect = scrollbarinfo.rcScrollBar;
                DSkin.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
                this.dskinScrollBar_1.ScrollBarLenght = scrollbarinfo.xyThumbBottom - scrollbarinfo.xyThumbTop;
                this.dskinScrollBar_1.Maximum = ((int) (scrollinfo.nMax * (1.0 - ((1.0 * this.dskinScrollBar_1.ScrollBarLenght) / ((double) (lpRect.Right - (this.int_0 * 2))))))) + 1;
                this.dskinScrollBar_1.Minimum = 0;
                this.dskinScrollBar_1.Value = scrollinfo.nPos;
                this.dskinScrollBar_1.ArrowHeight = this.int_0;
                this.dskinScrollBar_1.Size = new Size(lpRect.Right, lpRect.Bottom);
            }
            if (this.method_6() && (this.ifpTjeqac5 != null))
            {
                zero = DSkin.NativeMethods.GetDC(this.intptr_5);
                using (Graphics graphics = Graphics.FromHdc(zero))
                {
                    graphics.DrawImage(this.ifpTjeqac5, 0, 0, this.ifpTjeqac5.Width, this.ifpTjeqac5.Height);
                    DSkin.NativeMethods.ReleaseDC(this.intptr_5, zero);
                }
            }
            if (this.HasVertical())
            {
                scrollinfo = new DSkin.SCROLLINFO {
                    fMask = 0x17
                };
                DSkin.NativeMethods.GetScrollInfo(new HandleRef(this, base.Handle), 1, ref scrollinfo);
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffb, ref scrollbarinfo);
                lpRect = scrollbarinfo.rcScrollBar;
                DSkin.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
                this.dskinScrollBar_0.ScrollBarLenght = scrollbarinfo.xyThumbBottom - scrollbarinfo.xyThumbTop;
                this.dskinScrollBar_0.Maximum = ((int) (scrollinfo.nMax * (1.0 - ((1.0 * this.dskinScrollBar_0.ScrollBarLenght) / ((double) (lpRect.Bottom - (this.int_1 * 2))))))) + 1;
                this.dskinScrollBar_0.Minimum = 0;
                this.dskinScrollBar_0.Value = scrollinfo.nPos;
                this.dskinScrollBar_0.ArrowHeight = this.int_1;
                this.dskinScrollBar_0.Size = new Size(lpRect.Right, lpRect.Bottom);
            }
        }

        private void dskinScrollBar_0_MouseDown(object sender, MouseEventArgs e)
        {
            this.dskinScrollBar_0.InnerDuiControl.TriggerMouseUp(e);
            DSkin.NativeMethods.PostMessage(base.Handle, 0x201, IntPtr.Zero, DSkin.NativeMethods.MAKELPARAM((e.X + this.dskinScrollBar_0.Left) - this.control_0.Left, (e.Y + this.dskinScrollBar_0.Top) - this.control_0.Top));
        }

        private void dskinScrollBar_0_MouseMove(object sender, MouseEventArgs e)
        {
            DSkin.NativeMethods.PostMessage(base.Handle, 0x200, IntPtr.Zero, DSkin.NativeMethods.MAKELPARAM((e.X + this.dskinScrollBar_0.Left) - this.control_0.Left, (e.Y + this.dskinScrollBar_0.Top) - this.control_0.Top));
        }

        private void dskinScrollBar_0_MouseUp(object sender, MouseEventArgs e)
        {
            DSkin.NativeMethods.PostMessage(base.Handle, 0x202, IntPtr.Zero, DSkin.NativeMethods.MAKELPARAM((e.X + this.dskinScrollBar_0.Left) - this.control_0.Left, (e.Y + this.dskinScrollBar_0.Top) - this.control_0.Top));
        }

        private void dskinScrollBar_0_ValueChanged(object sender, EventArgs e)
        {
            if (!(this.dskinScrollBar_0.IsDisposed || !this.dskinScrollBar_0.InnerDuiControl.IsMouseDown) && !(this.control_0 is TextBox))
            {
                this.method_3(this.dskinScrollBar_0.Value);
                DSkin.NativeMethods.PostMessage(base.Handle, 0x115, (IntPtr) 4L, IntPtr.Zero);
            }
        }

        private void dskinScrollBar_1_ValueChanged(object sender, EventArgs e)
        {
            if (this.dskinScrollBar_1.InnerDuiControl.IsMouseDown)
            {
                this.method_1(this.dskinScrollBar_1.Value);
                DSkin.NativeMethods.PostMessage(base.Handle, 0x114, (IntPtr) 4L, IntPtr.Zero);
            }
        }

        public bool HasHorizontal()
        {
            return ((DSkin.NativeMethods.GetWindowLong(this.intptr_6, -16) & 0x100000) == 0x100000);
        }

        public bool HasVertical()
        {
            return ((DSkin.NativeMethods.GetWindowLong(this.intptr_6, -16) & 0x200000) == 0x200000);
        }

        private int method_0()
        {
            return DSkin.NativeMethods.GetScrollPos(base.Handle, 0);
        }

        private void method_1(int value)
        {
            DSkin.NativeMethods.SetScrollPos(base.Handle, 0, value, true);
        }

        private void method_10()
        {
            SCROLLBARINFO scrollbarinfo;
            DSkin.RECT rcScrollBar = new DSkin.RECT();
            scrollbarinfo = new SCROLLBARINFO {
                cbSize = Marshal.SizeOf(scrollbarinfo)
            };
            IntPtr parent = DSkin.NativeMethods.GetParent(this.intptr_6);
            Point lpPoint = new Point();
            if (this.HasVertical())
            {
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffb, ref scrollbarinfo);
                rcScrollBar = scrollbarinfo.rcScrollBar;
                lpPoint.X = rcScrollBar.Left;
                lpPoint.Y = rcScrollBar.Top;
                DSkin.NativeMethods.ScreenToClient(parent, ref lpPoint);
                DSkin.NativeMethods.SetWindowPos(this.dskinScrollBar_0.Handle, IntPtr.Zero, lpPoint.X, lpPoint.Y, rcScrollBar.Right - rcScrollBar.Left, rcScrollBar.Bottom - rcScrollBar.Top, 0x254);
            }
            if (this.HasHorizontal())
            {
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffa, ref scrollbarinfo);
                rcScrollBar = scrollbarinfo.rcScrollBar;
                lpPoint.X = rcScrollBar.Left;
                lpPoint.Y = rcScrollBar.Top;
                DSkin.NativeMethods.ScreenToClient(parent, ref lpPoint);
                DSkin.NativeMethods.SetWindowPos(this.dskinScrollBar_1.Handle, IntPtr.Zero, lpPoint.X, lpPoint.Y, rcScrollBar.Right - rcScrollBar.Left, rcScrollBar.Bottom - rcScrollBar.Top, 0x254);
            }
            if (this.method_6())
            {
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffa, ref scrollbarinfo);
                rcScrollBar = new DSkin.RECT(scrollbarinfo.rcScrollBar.Right, scrollbarinfo.rcScrollBar.Top, scrollbarinfo.rcScrollBar.Right + this.int_0, scrollbarinfo.rcScrollBar.Bottom);
                lpPoint.X = rcScrollBar.Left;
                lpPoint.Y = rcScrollBar.Top;
                DSkin.NativeMethods.ScreenToClient(parent, ref lpPoint);
                DSkin.NativeMethods.SetWindowPos(this.intptr_5, IntPtr.Zero, lpPoint.X, lpPoint.Y, rcScrollBar.Right - rcScrollBar.Left, rcScrollBar.Bottom - rcScrollBar.Top, 0x254);
            }
        }

        private void method_11()
        {
            this.int_0 = DSkin.NativeMethods.GetSystemMetrics(SYSTEM_METRICS.SM_CXVSCROLL);
            this.int_1 = DSkin.NativeMethods.GetSystemMetrics(SYSTEM_METRICS.SM_CYVSCROLL);
        }

        private int method_2()
        {
            return DSkin.NativeMethods.GetScrollPos(base.Handle, 1);
        }

        private void method_3(int value)
        {
            DSkin.NativeMethods.SetScrollPos(base.Handle, 1, value, true);
        }

        private void method_4()
        {
            if ((DSkin.NativeMethods.GetWindowLong(this.intptr_6, -16) & 0x10000000) == 0x10000000)
            {
                this.dskinScrollBar_1.Visible = this.HasHorizontal();
                this.dskinScrollBar_0.Visible = this.HasVertical();
                if (this.method_6())
                {
                    DSkin.NativeMethods.ShowWindow(this.intptr_5, 1);
                }
                else
                {
                    DSkin.NativeMethods.ShowWindow(this.intptr_5, 0);
                }
            }
            else
            {
                this.dskinScrollBar_1.Visible = false;
                this.dskinScrollBar_0.Visible = false;
                DSkin.NativeMethods.ShowWindow(this.intptr_5, 0);
            }
        }

        private void method_5()
        {
            if (this.control_0.Parent != null)
            {
                SCROLLBARINFO scrollbarinfo;
                System.Type type = typeof(cScrollBar);
                IntPtr hINSTANCE = Marshal.GetHINSTANCE(type.Module);
                IntPtr handle = this.control_0.Parent.Handle;
                DSkin.RECT rcScrollBar = new DSkin.RECT();
                Point lpPoint = new Point();
                scrollbarinfo = new SCROLLBARINFO {
                    cbSize = Marshal.SizeOf(scrollbarinfo)
                };
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffb, ref scrollbarinfo);
                rcScrollBar = scrollbarinfo.rcScrollBar;
                lpPoint.X = rcScrollBar.Left;
                lpPoint.Y = rcScrollBar.Top;
                DSkin.NativeMethods.ScreenToClient(handle, ref lpPoint);
                this.control_0.Parent.Controls.Add(this.dskinScrollBar_0);
                DSkin.NativeMethods.SetWindowPos(this.dskinScrollBar_0.Handle, intptr_2, 0, 0, 0, 0, 0x213);
                DSkin.NativeMethods.GetScrollBarInfo(this.intptr_6, 0xfffffffa, ref scrollbarinfo);
                rcScrollBar = scrollbarinfo.rcScrollBar;
                lpPoint.X = rcScrollBar.Left;
                lpPoint.Y = rcScrollBar.Top;
                DSkin.NativeMethods.ScreenToClient(handle, ref lpPoint);
                this.control_0.Parent.Controls.Add(this.dskinScrollBar_1);
                DSkin.NativeMethods.SetWindowPos(this.dskinScrollBar_1.Handle, intptr_2, 0, 0, 0, 0, 0x213);
                this.intptr_5 = DSkin.NativeMethods.CreateWindowEx(0x88, "STATIC", "", 0x5400000d, lpPoint.X + (rcScrollBar.Right - rcScrollBar.Left), lpPoint.Y, this.int_0, this.int_1, handle, IntPtr.Zero, hINSTANCE, IntPtr.Zero);
                DSkin.NativeMethods.SetWindowPos(this.intptr_5, intptr_2, 0, 0, 0, 0, 0x213);
                this.method_10();
            }
        }

        private bool method_6()
        {
            return (this.HasHorizontal() && this.HasVertical());
        }

        private void method_7(bool bool_0)
        {
            if (bool_0)
            {
                DSkin.NativeMethods.RedrawWindow(this.intptr_6, IntPtr.Zero, IntPtr.Zero, 2);
            }
            else
            {
                DSkin.NativeMethods.RedrawWindow(this.intptr_6, IntPtr.Zero, IntPtr.Zero, 0x101);
            }
        }

        private bool method_8()
        {
            if (this.method_9())
            {
                return (DSkin.NativeMethods.GetKeyState(2) < 0);
            }
            return (DSkin.NativeMethods.GetKeyState(1) < 0);
        }

        private bool method_9()
        {
            return (DSkin.NativeMethods.GetSystemMetrics(SYSTEM_METRICS.SM_SWAPBUTTON) != 0);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 3:
                case 5:
                    this.method_10();
                    break;

                case 15:
                case 0x85:
                case 0x114:
                case 0x115:
                case 160:
                case 0x200:
                case 0x2a3:
                    break;

                default:
                    this.method_4();
                    this.drawScrollBar();
                    break;
            }
            base.WndProc(ref m);
        }

        [Browsable(false)]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                return (DuiScrollBar) this.dskinScrollBar_0.InnerDuiControl;
            }
        }

        [Browsable(false)]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return (DuiScrollBar) this.dskinScrollBar_1.InnerDuiControl;
            }
        }

        public Image RightBottom
        {
            get
            {
                return this.ifpTjeqac5;
            }
            set
            {
                this.ifpTjeqac5 = value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct8
        {
            internal IntPtr intptr_0;
            internal int int_0;
            internal DSkin.RECT rect_0;
            internal int int_1;
            internal int int_2;
            internal int int_3;
            internal int int_4;
            internal int int_5;
            internal int int_6;
            internal int int_7;
            internal int int_8;
            internal int int_9;
            internal int int_10;
        }
    }
}

