namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class StretchImage : IDisposable
    {
        private IntPtr intptr_0 = IntPtr.Zero;
        private StretchModeEnum stretchModeEnum_0 = StretchModeEnum.STRETCH_ANDSCANS;

        public StretchImage(IntPtr sourceDc, IntPtr destDc, Rectangle src, Rectangle dest, int depth, StretchModeEnum eStretchMode)
        {
            this.stretchModeEnum_0 = (StretchModeEnum) GetStretchBltMode(sourceDc);
            this.intptr_0 = sourceDc;
            SetStretchBltMode(sourceDc, eStretchMode);
            StretchBlt(destDc, dest.Left, dest.Top, depth, dest.Height, sourceDc, src.Left, 0, depth, src.Height, 0xcc0020);
            StretchBlt(destDc, dest.Right - depth, dest.Top, depth, dest.Height, sourceDc, src.Right - depth, 0, depth, src.Height, 0xcc0020);
            StretchBlt(destDc, dest.Left + depth, dest.Top, dest.Width - (2 * depth), depth, sourceDc, src.Left + depth, 0, src.Width - (2 * depth), depth, 0xcc0020);
            StretchBlt(destDc, dest.Left + depth, dest.Bottom - depth, dest.Width - (2 * depth), depth, sourceDc, src.Left + depth, src.Bottom - depth, src.Width - (2 * depth), depth, 0xcc0020);
            StretchBlt(destDc, dest.Left + depth, dest.Top + depth, dest.Width - (2 * depth), dest.Height - (2 * depth), sourceDc, src.Left + depth, depth, src.Width - (2 * depth), src.Height - (2 * depth), 0xcc0020);
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
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll")]
        private static extern bool StretchBlt(IntPtr intptr_1, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_2, int int_4, int int_5, int int_6, int int_7, int int_8);
    }
}

