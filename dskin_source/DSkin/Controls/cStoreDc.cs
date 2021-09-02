namespace DSkin.Controls
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public class cStoreDc
    {
        private int int_0 = 0;
        private int int_1 = 0;
        private IntPtr intptr_0 = IntPtr.Zero;
        private IntPtr intptr_1 = IntPtr.Zero;
        private IntPtr intptr_2 = IntPtr.Zero;

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_3, int int_2, int int_3);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr intptr_3);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(string string_0, string string_1, string string_2, int int_2);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)] string string_0, [MarshalAs(UnmanagedType.LPStr)] string string_1, [MarshalAs(UnmanagedType.LPStr)] string string_2, int int_2);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)] string string_0, [MarshalAs(UnmanagedType.LPWStr)] string string_1, [MarshalAs(UnmanagedType.LPWStr)] string string_2, int int_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr intptr_3);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr intptr_3);
        public void Dispose()
        {
            this.method_1();
        }

        private void method_0(int int_2, int int_3)
        {
            IntPtr zero = IntPtr.Zero;
            this.method_1();
            zero = CreateDCA("DISPLAY", "", "", 0);
            this.intptr_0 = CreateCompatibleDC(zero);
            this.intptr_1 = CreateCompatibleBitmap(zero, this.int_1, this.int_0);
            this.intptr_2 = SelectObject(this.intptr_0, this.intptr_1);
            if (this.intptr_2 == IntPtr.Zero)
            {
                this.method_1();
            }
            else
            {
                this.int_1 = int_2;
                this.int_0 = int_3;
            }
            DeleteDC(zero);
            zero = IntPtr.Zero;
        }

        private void method_1()
        {
            if (this.intptr_2 != IntPtr.Zero)
            {
                SelectObject(this.intptr_0, this.intptr_2);
                this.intptr_2 = IntPtr.Zero;
            }
            if (this.intptr_1 != IntPtr.Zero)
            {
                DeleteObject(this.intptr_1);
                this.intptr_1 = IntPtr.Zero;
            }
            if (this.intptr_0 != IntPtr.Zero)
            {
                DeleteDC(this.intptr_0);
                this.intptr_0 = IntPtr.Zero;
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr intptr_3, IntPtr intptr_4);

        public IntPtr HBmp
        {
            get
            {
                return this.intptr_1;
            }
        }

        public IntPtr Hdc
        {
            get
            {
                return this.intptr_0;
            }
        }

        public int Height
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    this.method_0(this.int_1, this.int_0);
                }
            }
        }

        public int Width
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    this.method_0(this.int_1, this.int_0);
                }
            }
        }
    }
}

