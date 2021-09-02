namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public class cScrollBar : NativeWindow, IDisposable
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private Bitmap bitmap_2;
        private Bitmap BkloujmvOE;
        private bool bool_0;
        private cStoreDc cStoreDc_0;
        private cStoreDc cStoreDc_1;
        private cStoreDc cStoreDc_2;
        private int int_0;
        private int int_1;
        private static readonly IntPtr intptr_0 = new IntPtr(-2);
        private static readonly IntPtr intptr_1 = new IntPtr(-1);
        private static readonly IntPtr intptr_2 = new IntPtr(0);
        private static readonly IntPtr intptr_3 = new IntPtr(1);
        private static IntPtr intptr_4 = new IntPtr(1);
        private IntPtr intptr_5;
        private IntPtr intptr_6;
        private Orientation orientation_0;

        public cScrollBar(IntPtr hWnd, Orientation orientation)
        {
            this.bool_0 = false;
            this.intptr_5 = IntPtr.Zero;
            this.int_0 = 14;
            this.int_1 = 14;
            this.intptr_6 = IntPtr.Zero;
            this.cStoreDc_0 = new cStoreDc();
            this.cStoreDc_1 = new cStoreDc();
            this.cStoreDc_2 = new cStoreDc();
            if (hWnd == IntPtr.Zero)
            {
                throw new Exception("The scrollbar handle is invalid.");
            }
            this.intptr_6 = hWnd;
            this.method_12(orientation);
            this.method_29();
            if ((Environment.OSVersion.Version.Major > 5) && IsAppThemed())
            {
                SetWindowTheme(this.intptr_6, "", "");
            }
            this.method_18();
            base.AssignHandle(hWnd);
            this.method_17();
        }

        public cScrollBar(IntPtr hWnd, Orientation orientation, Bitmap thumb, Bitmap track, Bitmap arrow, Bitmap fader)
        {
            this.bool_0 = false;
            this.intptr_5 = IntPtr.Zero;
            this.int_0 = 14;
            this.int_1 = 14;
            this.intptr_6 = IntPtr.Zero;
            this.cStoreDc_0 = new cStoreDc();
            this.cStoreDc_1 = new cStoreDc();
            this.cStoreDc_2 = new cStoreDc();
            if (hWnd == IntPtr.Zero)
            {
                throw new Exception("The scrollbar handle is invalid.");
            }
            this.method_4(arrow);
            this.method_6(thumb);
            this.method_8(track);
            this.intptr_6 = hWnd;
            this.method_12(orientation);
            this.method_29();
            if ((Environment.OSVersion.Version.Major > 5) && IsAppThemed())
            {
                SetWindowTheme(this.intptr_6, "", "");
            }
            this.method_18();
            base.AssignHandle(hWnd);
            if (fader != null)
            {
                this.method_10(fader);
            }
            this.method_17();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr intptr_7, ref Struct2 struct2_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr intptr_7, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_8, int int_6, int int_7, int int_8);
        private void BYDSYDZIRG()
        {
            if (this.method_28() == ((Enum1) 5))
            {
                Point point = this.method_24();
                if (this.method_9() != null)
                {
                    Struct3 struct2 = new Struct3();
                    if (this.method_11() == Orientation.Horizontal)
                    {
                        GetWindowRect(this.intptr_6, ref struct2);
                        new cTransition(this.intptr_5, this.intptr_6, this.method_9(), new Rectangle(point.X, 0, point.Y - point.X, struct2.hmCoaVwown));
                    }
                    else
                    {
                        new cTransition(this.intptr_5, this.intptr_6, this.method_9(), new Rectangle(0, point.X, this.int_0, point.Y - point.X));
                    }
                }
            }
        }

        [DllImport("user32.dll", SetLastError=true)]
        private static extern IntPtr CreateWindowEx(int int_2, string string_0, string string_1, int int_3, int int_4, int int_5, int int_6, int int_7, IntPtr intptr_7, IntPtr intptr_8, IntPtr intptr_9, IntPtr intptr_10);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool DestroyWindow(IntPtr intptr_7);
        public void Dispose()
        {
            try
            {
                this.ReleaseHandle();
                if (this.bitmap_0 != null)
                {
                    this.bitmap_0.Dispose();
                }
                if (this.cStoreDc_0 != null)
                {
                    this.cStoreDc_0.Dispose();
                }
                if (this.bitmap_1 != null)
                {
                    this.bitmap_1.Dispose();
                }
                if (this.cStoreDc_1 != null)
                {
                    this.cStoreDc_1.Dispose();
                }
                if (this.BkloujmvOE != null)
                {
                    this.BkloujmvOE.Dispose();
                }
                if (this.cStoreDc_2 != null)
                {
                    this.cStoreDc_2.Dispose();
                }
                if (this.intptr_5 != IntPtr.Zero)
                {
                    DestroyWindow(this.intptr_5);
                }
            }
            catch
            {
            }
            GC.SuppressFinalize(this);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr intptr_7, ref Struct2 struct2_0);
        [DllImport("user32.dll")]
        private static extern bool EqualRect([In] ref Struct3 struct3_0, [In] ref Struct3 struct3_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point point_0);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr intptr_7);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int int_2);
        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr intptr_7);
        [DllImport("user32.dll")]
        private static extern int GetScrollPos(IntPtr intptr_7, int int_2);
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(Enum2 enum2_0);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr intptr_7, int int_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr intptr_7, ref Struct3 struct3_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("uxtheme.dll")]
        private static extern bool IsAppThemed();
        private void method_0(object sender, EventArgs e)
        {
            this.BYDSYDZIRG();
        }

        private void method_1(object sender, PaintEventArgs e)
        {
            this.method_25(false);
        }

        private void method_10(Bitmap value)
        {
            this.bitmap_2 = value;
        }

        private Orientation method_11()
        {
            return this.orientation_0;
        }

        private void method_12(Orientation value)
        {
            this.orientation_0 = value;
        }

        private int method_13()
        {
            return GetScrollPos(base.Handle, 0);
        }

        private void method_14(int value)
        {
            SetScrollPos(base.Handle, 0, value, true);
        }

        private int method_15()
        {
            return GetScrollPos(base.Handle, 1);
        }

        private void method_16(int value)
        {
            SetScrollPos(base.Handle, 1, value, true);
        }

        private void method_17()
        {
            if ((GetWindowLong(this.intptr_6, -16) & 0x10000000) == 0x10000000)
            {
                ShowWindow(this.intptr_5, 1);
            }
            else
            {
                ShowWindow(this.intptr_5, 0);
            }
        }

        private void method_18()
        {
            System.Type type = typeof(cScrollBar);
            IntPtr hINSTANCE = Marshal.GetHINSTANCE(type.Module);
            IntPtr parent = GetParent(this.intptr_6);
            Struct3 struct2 = new Struct3();
            Point point = new Point();
            GetWindowRect(this.intptr_6, ref struct2);
            point.X = struct2.int_0;
            point.Y = struct2.TdJogAmfOW;
            ScreenToClient(parent, ref point);
            this.intptr_5 = CreateWindowEx(0x88, "STATIC", "", 0x5400000d, point.X, point.Y, struct2.int_1 - struct2.int_0, struct2.hmCoaVwown - struct2.TdJogAmfOW, parent, IntPtr.Zero, hINSTANCE, IntPtr.Zero);
            SetWindowPos(this.intptr_5, intptr_2, 0, 0, 0, 0, 0x213);
        }

        private void method_19()
        {
            if (((this.method_5() != null) && (this.method_7() != null)) && (this.method_3() != null))
            {
                this.method_20();
            }
        }

        private void method_2(object sender, ScrollEventArgs e)
        {
            this.method_25(false);
        }

        private void method_20()
        {
            StretchImage image;
            IntPtr ptr;
            Point point;
            Struct5 structure = new Struct5();
            Struct3 struct3 = new Struct3();
            cStoreDc dc = new cStoreDc();
            int num = 0;
            int width = 0;
            GetWindowRect(this.intptr_6, ref struct3);
            OffsetRect(ref struct3, -struct3.int_0, -struct3.TdJogAmfOW);
            dc.Width = struct3.int_1;
            dc.Height = struct3.hmCoaVwown;
            Enum1 enum2 = this.method_28();
            structure.int_0 = Marshal.SizeOf(structure);
            SendMessage_1(this.intptr_6, 0xeb, 0, ref structure);
            if (this.method_11() == Orientation.Horizontal)
            {
                using (image = new StretchImage(this.cStoreDc_2.Hdc, dc.Hdc, new Rectangle(0, 0, this.cStoreDc_2.Width, this.cStoreDc_2.Height), new Rectangle(this.int_0, 0, struct3.int_1 - (2 * this.int_0), struct3.hmCoaVwown), 2, StretchModeEnum.STRETCH_HALFTONE))
                {
                }
                width = this.cStoreDc_0.Width / 7;
                if (enum2 == ((Enum1) 3))
                {
                    if (this.method_26())
                    {
                        num = 2;
                    }
                    else
                    {
                        num = 1;
                    }
                }
                else
                {
                    num = 0;
                }
                using (image = new StretchImage(this.cStoreDc_0.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_0.Height), new Rectangle(0, 0, this.int_0, struct3.hmCoaVwown), 2, StretchModeEnum.STRETCH_HALFTONE))
                {
                }
                if (enum2 == ((Enum1) 4))
                {
                    if (this.method_26())
                    {
                        num = 5;
                    }
                    else
                    {
                        num = 4;
                    }
                }
                else
                {
                    num = 3;
                }
                using (image = new StretchImage(this.cStoreDc_0.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_0.Height), new Rectangle(struct3.int_1 - this.int_0, 0, this.int_0, struct3.hmCoaVwown), 2, StretchModeEnum.STRETCH_HALFTONE))
                {
                }
                width = this.cStoreDc_1.Width / 3;
                if (enum2 == ((Enum1) 5))
                {
                    if (this.method_26())
                    {
                        num = 2;
                    }
                    else
                    {
                        num = 1;
                    }
                }
                else
                {
                    num = 0;
                }
                point = this.method_24();
                using (image = new StretchImage(this.cStoreDc_1.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_1.Height), new Rectangle(point.X, 0, point.Y - point.X, struct3.hmCoaVwown), 2, StretchModeEnum.STRETCH_HALFTONE))
                {
                    goto Label_04B4;
                }
            }
            using (image = new StretchImage(this.cStoreDc_2.Hdc, dc.Hdc, new Rectangle(0, 0, this.cStoreDc_2.Width, this.cStoreDc_2.Height), new Rectangle(0, this.int_1, struct3.int_1, struct3.hmCoaVwown - (2 * this.int_1)), 2, StretchModeEnum.STRETCH_HALFTONE))
            {
            }
            width = this.cStoreDc_0.Width / 6;
            if (enum2 == ((Enum1) 1))
            {
                if (this.method_26())
                {
                    num = 2;
                }
                else
                {
                    num = 1;
                }
            }
            else
            {
                num = 0;
            }
            using (image = new StretchImage(this.cStoreDc_0.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_0.Height), new Rectangle(0, 0, struct3.int_1, this.int_1), 2, StretchModeEnum.STRETCH_HALFTONE))
            {
            }
            if (enum2 == ((Enum1) 2))
            {
                if (this.method_26())
                {
                    num = 5;
                }
                else
                {
                    num = 4;
                }
            }
            else
            {
                num = 3;
            }
            using (image = new StretchImage(this.cStoreDc_0.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_0.Height), new Rectangle(0, struct3.hmCoaVwown - this.int_1, struct3.int_1, this.int_1), 2, StretchModeEnum.STRETCH_HALFTONE))
            {
            }
            width = this.cStoreDc_1.Width / 3;
            if (enum2 == ((Enum1) 5))
            {
                if (this.method_26())
                {
                    num = 2;
                }
                else
                {
                    num = 1;
                }
            }
            else
            {
                num = 0;
            }
            point = this.method_24();
            using (image = new StretchImage(this.cStoreDc_1.Hdc, dc.Hdc, new Rectangle(num * width, 0, width, this.cStoreDc_1.Height), new Rectangle(0, point.X, this.int_0, point.Y - point.X), 2, StretchModeEnum.STRETCH_HALFTONE))
            {
            }
        Label_04B4:
            ptr = GetDC(this.intptr_5);
            BitBlt(ptr, 0, 0, struct3.int_1, struct3.hmCoaVwown, dc.Hdc, 0, 0, 0xcc0020);
            ReleaseDC(this.intptr_5, ptr);
            dc.Dispose();
        }

        private Struct3 method_21()
        {
            Struct3 struct2 = new Struct3();
            GetWindowRect(this.intptr_6, ref struct2);
            OffsetRect(ref struct2, -struct2.int_0, -struct2.TdJogAmfOW);
            switch (this.method_28())
            {
                case ((Enum1) 1):
                    return new Struct3(0, 0, struct2.int_1, this.int_1);

                case ((Enum1) 2):
                    return new Struct3(0, struct2.hmCoaVwown - this.int_1, struct2.int_1, this.int_1);

                case ((Enum1) 3):
                    return new Struct3(0, 0, this.int_0, struct2.hmCoaVwown);

                case ((Enum1) 4):
                    return new Struct3(struct2.int_1 - this.int_0, 0, struct2.int_1, struct2.hmCoaVwown);

                case ((Enum1) 5):
                {
                    Point point = this.method_24();
                    if (this.method_11() != Orientation.Horizontal)
                    {
                        return new Struct3(0, point.X, this.int_0, point.Y - point.X);
                    }
                    return new Struct3(point.X, 2, point.Y - point.X, struct2.hmCoaVwown);
                }
            }
            return struct2;
        }

        private Struct3 method_22()
        {
            Struct5 struct2;
            struct2 = new Struct5 {
                int_0 = Marshal.SizeOf(struct2)
            };
            SendMessage_1(this.intptr_6, 0xeb, 0, ref struct2);
            return struct2.struct3_0;
        }

        private void method_23()
        {
            Struct3 struct2 = new Struct3();
            Struct3 struct3 = new Struct3();
            GetWindowRect(this.intptr_5, ref struct3);
            GetWindowRect(this.intptr_6, ref struct2);
            uint num = 0x214;
            if (!EqualRect(ref struct2, ref struct3))
            {
                Point point = new Point(struct2.int_0, struct2.TdJogAmfOW);
                ScreenToClient(GetParent(this.intptr_5), ref point);
                SetWindowPos(this.intptr_5, IntPtr.Zero, point.X, point.Y, struct2.int_1 - struct2.int_0, struct2.hmCoaVwown - struct2.TdJogAmfOW, num);
            }
        }

        private Point method_24()
        {
            int num4;
            Struct3 struct2 = new Struct3();
            GetWindowRect(this.intptr_6, ref struct2);
            OffsetRect(ref struct2, -struct2.int_0, -struct2.TdJogAmfOW);
            Rectangle rectangle = new Rectangle(struct2.int_0, struct2.TdJogAmfOW, struct2.int_1 - struct2.int_0, struct2.hmCoaVwown - struct2.TdJogAmfOW);
            int num = this.int_0;
            bool flag = this.method_11() == Orientation.Horizontal;
            ScrollBar bar = (ScrollBar) Control.FromHandle(this.intptr_6);
            Point point = new Point();
            if (flag)
            {
                num4 = rectangle.Width - (num * 2);
            }
            else
            {
                num4 = rectangle.Height - (num * 2);
            }
            int num2 = ((bar.Maximum - bar.Minimum) - bar.LargeChange) + 1;
            float num5 = ((float) num4) / ((((float) num2) / ((float) bar.LargeChange)) + 1f);
            if (num5 < 8f)
            {
                num5 = 8f;
            }
            if (num2 != 0)
            {
                int num3 = bar.Value - bar.Minimum;
                if (num3 > num2)
                {
                    num3 = num2;
                }
                point.X = (int) (num3 * ((num4 - num5) / ((float) num2)));
            }
            point.X += num;
            point.Y = point.X + ((int) Math.Ceiling((double) num5));
            if (flag && (bar.RightToLeft == RightToLeft.Yes))
            {
                point.X = bar.Width - point.X;
                point.Y = bar.Width - point.Y;
            }
            return point;
        }

        private void method_25(bool bool_1)
        {
            if (bool_1)
            {
                RedrawWindow(this.intptr_6, IntPtr.Zero, IntPtr.Zero, 2);
            }
            else
            {
                RedrawWindow(this.intptr_6, IntPtr.Zero, IntPtr.Zero, 0x101);
            }
        }

        private bool method_26()
        {
            if (this.method_27())
            {
                return (GetKeyState(2) < 0);
            }
            return (GetKeyState(1) < 0);
        }

        private bool method_27()
        {
            return (GetSystemMetrics((Enum2) 0x17) != 0);
        }

        private Enum1 method_28()
        {
            Point point2;
            Point point = new Point();
            Struct3 struct2 = new Struct3();
            GetWindowRect(this.intptr_6, ref struct2);
            OffsetRect(ref struct2, -struct2.int_0, -struct2.TdJogAmfOW);
            Struct3 struct3 = struct2;
            GetCursorPos(ref point);
            ScreenToClient(this.intptr_6, ref point);
            if (this.method_11() == Orientation.Horizontal)
            {
                if (PtInRect(ref struct2, point))
                {
                    struct3.int_1 = this.int_0;
                    if (PtInRect(ref struct3, point))
                    {
                        return (Enum1) 3;
                    }
                    struct3.int_0 = struct2.int_1 - this.int_0;
                    struct3.int_1 = struct2.int_1;
                    if (PtInRect(ref struct3, point))
                    {
                        return (Enum1) 4;
                    }
                    point2 = this.method_24();
                    struct3.int_0 = point2.X;
                    struct3.int_1 = point2.Y;
                    if (PtInRect(ref struct3, point))
                    {
                        return (Enum1) 5;
                    }
                    return (Enum1) 6;
                }
            }
            else if (PtInRect(ref struct2, point))
            {
                struct3.hmCoaVwown = this.int_1;
                if (PtInRect(ref struct3, point))
                {
                    return (Enum1) 1;
                }
                struct3.TdJogAmfOW = struct2.hmCoaVwown - this.int_1;
                struct3.hmCoaVwown = struct2.hmCoaVwown;
                if (PtInRect(ref struct3, point))
                {
                    return (Enum1) 2;
                }
                point2 = this.method_24();
                struct3.TdJogAmfOW = point2.X;
                struct3.hmCoaVwown = point2.Y;
                if (PtInRect(ref struct3, point))
                {
                    return (Enum1) 5;
                }
                return (Enum1) 6;
            }
            return (Enum1) 0;
        }

        private void method_29()
        {
            if (this.method_11() == Orientation.Horizontal)
            {
                this.int_0 = GetSystemMetrics((Enum2) 0x15);
                this.int_1 = GetSystemMetrics((Enum2) 3);
            }
            else
            {
                this.int_0 = GetSystemMetrics((Enum2) 2);
                this.int_1 = GetSystemMetrics((Enum2) 20);
            }
        }

        private Bitmap method_3()
        {
            return this.bitmap_0;
        }

        private void method_30(bool bool_1)
        {
            if (bool_1)
            {
                SendMessage(this.intptr_6, 0x114, 1, 0);
            }
            else
            {
                SendMessage(this.intptr_6, 0x114, 0, 0);
            }
        }

        private void method_31(bool bool_1)
        {
            if (bool_1)
            {
                SendMessage(this.intptr_6, 0x115, 1, 0);
            }
            else
            {
                SendMessage(this.intptr_6, 0x115, 0, 0);
            }
        }

        private void method_4(Bitmap value)
        {
            this.bitmap_0 = value;
            if (this.cStoreDc_0.Hdc != IntPtr.Zero)
            {
                this.cStoreDc_0.Dispose();
                this.cStoreDc_0 = new cStoreDc();
            }
            this.cStoreDc_0.Width = this.bitmap_0.Width;
            this.cStoreDc_0.Height = this.bitmap_0.Height;
            SelectObject(this.cStoreDc_0.Hdc, this.bitmap_0.GetHbitmap());
        }

        private Bitmap method_5()
        {
            return this.bitmap_1;
        }

        private void method_6(Bitmap value)
        {
            this.bitmap_1 = value;
            if (this.cStoreDc_1.Hdc != IntPtr.Zero)
            {
                this.cStoreDc_1.Dispose();
                this.cStoreDc_1 = new cStoreDc();
            }
            this.cStoreDc_1.Width = this.bitmap_1.Width;
            this.cStoreDc_1.Height = this.bitmap_1.Height;
            SelectObject(this.cStoreDc_1.Hdc, this.bitmap_1.GetHbitmap());
        }

        private Bitmap method_7()
        {
            return this.BkloujmvOE;
        }

        private void method_8(Bitmap value)
        {
            this.BkloujmvOE = value;
            if (this.cStoreDc_2.Hdc != IntPtr.Zero)
            {
                this.cStoreDc_2.Dispose();
                this.cStoreDc_2 = new cStoreDc();
            }
            this.cStoreDc_2.Width = this.BkloujmvOE.Width;
            this.cStoreDc_2.Height = this.BkloujmvOE.Height;
            SelectObject(this.cStoreDc_2.Hdc, this.BkloujmvOE.GetHbitmap());
        }

        private Bitmap method_9()
        {
            return this.bitmap_2;
        }

        [DllImport("user32.dll")]
        private static extern int OffsetRect(ref Struct3 struct3_0, int int_2, int int_3);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool PtInRect([In] ref Struct3 struct3_0, Point point_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool RedrawWindow(IntPtr intptr_7, IntPtr intptr_8, IntPtr intptr_9, uint uint_0);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr intptr_7, IntPtr intptr_8);
        [DllImport("user32.dll")]
        private static extern int ScreenToClient(IntPtr intptr_7, ref Point point_0);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr intptr_7, IntPtr intptr_8);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr intptr_7, int int_2, int int_3, int int_4);
        [DllImport("user32.dll", EntryPoint="SendMessage")]
        private static extern int SendMessage_1(IntPtr intptr_7, int int_2, int int_3, ref Struct5 struct5_0);
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr intptr_7, int int_2, int int_3, bool bool_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr intptr_7, IntPtr intptr_8, int int_2, int int_3, int int_4, int int_5, uint uint_0);
        [DllImport("uxtheme.dll", CharSet=CharSet.Unicode, ExactSpelling=true)]
        private static extern int SetWindowTheme(IntPtr intptr_7, string string_0, string string_1);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr intptr_7, int int_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool StretchBlt(IntPtr intptr_7, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_8, int int_6, int int_7, int int_8, int int_9, int int_10);
        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr intptr_7, ref Struct3 struct3_0);
        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case 15:
                        if (!this.bool_0)
                        {
                            Struct2 struct2 = new Struct2();
                            this.bool_0 = true;
                            BeginPaint(m.HWnd, ref struct2);
                            this.method_19();
                            ValidateRect(m.HWnd, ref struct2.struct3_0);
                            EndPaint(m.HWnd, ref struct2);
                            this.bool_0 = false;
                            m.Result = intptr_4;
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        return;

                    case 0x47:
                        this.method_17();
                        this.method_23();
                        base.WndProc(ref m);
                        return;

                    case 0x7d:
                        this.method_19();
                        base.WndProc(ref m);
                        return;

                    case 0x200:
                    case 0x202:
                        this.method_19();
                        base.WndProc(ref m);
                        return;

                    case 0x201:
                        this.method_19();
                        base.WndProc(ref m);
                        return;

                    case 0x2a3:
                        this.method_19();
                        base.WndProc(ref m);
                        return;

                    case 0xe9:
                        break;

                    default:
                        base.WndProc(ref m);
                        return;
                }
                this.method_19();
                base.WndProc(ref m);
            }
            catch
            {
            }
        }

        private enum Enum1
        {
        }

        private enum Enum2
        {
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct2
        {
            internal IntPtr intptr_0;
            internal int int_0;
            internal cScrollBar.Struct3 struct3_0;
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

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct3
        {
            internal int int_0;
            internal int TdJogAmfOW;
            internal int int_1;
            internal int hmCoaVwown;
            internal Struct3(int int_2, int int_3, int int_4, int int_5)
            {
                this.int_0 = int_2;
                this.TdJogAmfOW = int_3;
                this.int_1 = int_4;
                this.hmCoaVwown = int_5;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct4
        {
            internal uint uint_0;
            internal uint uint_1;
            internal int int_0;
            internal int raPoGqWsSh;
            internal uint uint_2;
            internal int int_1;
            internal int int_2;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct5
        {
            internal int int_0;
            internal cScrollBar.Struct3 struct3_0;
            internal int int_1;
            internal int int_2;
            internal int int_3;
            internal int int_4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            internal int[] int_5;
        }
    }
}

