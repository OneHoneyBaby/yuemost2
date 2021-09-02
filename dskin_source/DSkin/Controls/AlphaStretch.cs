namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class AlphaStretch : IDisposable
    {
        public AlphaStretch(IntPtr sourceDc, IntPtr destDc, Rectangle src, Rectangle dest, int depth, byte opacity)
        {
            Struct1 struct2 = new Struct1(0, 0, opacity, 0);
            GdiAlphaBlend(destDc, dest.Left, dest.Top, depth, dest.Height, sourceDc, src.Left, 0, depth, src.Height, struct2);
            GdiAlphaBlend(destDc, dest.Right - depth, dest.Top, depth, dest.Height, sourceDc, src.Right - depth, 0, depth, src.Height, struct2);
            GdiAlphaBlend(destDc, dest.Left + depth, dest.Top, dest.Width - (2 * depth), depth, sourceDc, src.Left + depth, 0, src.Width - (2 * depth), depth, struct2);
            GdiAlphaBlend(destDc, dest.Left + depth, dest.Bottom - depth, dest.Width - (2 * depth), depth, sourceDc, src.Left + depth, src.Bottom - depth, src.Width - (2 * depth), depth, struct2);
            GdiAlphaBlend(destDc, dest.Left + depth, dest.Top + depth, dest.Width - (2 * depth), dest.Height - (2 * depth), sourceDc, src.Left + depth, depth, src.Width - (2 * depth), src.Height - (2 * depth), struct2);
        }

        public void Dispose()
        {
        }

        [DllImport("gdi32.dll")]
        private static extern bool GdiAlphaBlend(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6, int int_7, Struct1 struct1_0);

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct1
        {
            private byte byte_0;
            private byte byte_1;
            private byte byte_2;
            private byte byte_3;
            internal Struct1(byte byte_4, byte byte_5, byte byte_6, byte byte_7)
            {
                this.byte_0 = byte_4;
                this.byte_1 = byte_5;
                this.byte_2 = byte_6;
                this.byte_3 = byte_7;
            }
        }
    }
}

