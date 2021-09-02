namespace DSkin.Common
{
    using DSkin;
    using System;
    using System.Security.Permissions;

    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public class ImageDc : IDisposable
    {
        private int int_0;
        private int int_1;
        private IntPtr intptr_0;
        private IntPtr intptr_1;
        private IntPtr intptr_2;

        public ImageDc(int width, int height)
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.intptr_0 = IntPtr.Zero;
            this.intptr_1 = IntPtr.Zero;
            this.intptr_2 = IntPtr.Zero;
            this.method_0(width, height, IntPtr.Zero);
        }

        public ImageDc(int width, int height, IntPtr hBmp)
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.intptr_0 = IntPtr.Zero;
            this.intptr_1 = IntPtr.Zero;
            this.intptr_2 = IntPtr.Zero;
            this.method_0(width, height, hBmp);
        }

        public void Dispose()
        {
            this.method_1();
        }

        private void method_0(int int_2, int int_3, IntPtr intptr_3)
        {
            IntPtr zero = IntPtr.Zero;
            zero = NativeMethods.CreateDCA("DISPLAY", "", "", 0);
            this.intptr_0 = NativeMethods.CreateCompatibleDC(zero);
            if (intptr_3 != IntPtr.Zero)
            {
                this.intptr_1 = intptr_3;
            }
            else
            {
                this.intptr_1 = NativeMethods.CreateCompatibleBitmap(zero, int_2, int_3);
            }
            this.intptr_2 = NativeMethods.SelectObject(this.intptr_0, this.intptr_1);
            if (this.intptr_2 == IntPtr.Zero)
            {
                this.method_1();
            }
            else
            {
                this.int_1 = int_2;
                this.int_0 = int_3;
            }
            NativeMethods.DeleteDC(zero);
            zero = IntPtr.Zero;
        }

        private void method_1()
        {
            if (this.intptr_2 != IntPtr.Zero)
            {
                NativeMethods.SelectObject(this.intptr_0, this.intptr_2);
                this.intptr_2 = IntPtr.Zero;
            }
            if (this.intptr_1 != IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.intptr_1);
                this.intptr_1 = IntPtr.Zero;
            }
            if (this.intptr_0 != IntPtr.Zero)
            {
                NativeMethods.DeleteDC(this.intptr_0);
                this.intptr_0 = IntPtr.Zero;
            }
        }

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
    }
}

