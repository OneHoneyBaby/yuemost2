namespace DSkin.Controls
{
    using System;
    using System.Runtime.InteropServices;

    public class StretchMode : IDisposable
    {
        private IntPtr intptr_0 = IntPtr.Zero;
        private StretchModeEnum stretchModeEnum_0 = StretchModeEnum.STRETCH_ANDSCANS;

        public StretchMode(IntPtr hdc, StretchModeEnum mode)
        {
            this.stretchModeEnum_0 = (StretchModeEnum) GetStretchBltMode(hdc);
            this.intptr_0 = hdc;
            SetStretchBltMode(hdc, mode);
        }

        public void Dispose()
        {
            SetStretchBltMode(this.intptr_0, this.stretchModeEnum_0);
        }

        [DllImport("gdi32.dll")]
        private static extern int GetStretchBltMode(IntPtr intptr_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool SetStretchBltMode(IntPtr intptr_1, StretchModeEnum stretchModeEnum_1);
    }
}

