namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Reflection;

    public class RawBitmap : IDisposable
    {
        private Bitmap bitmap_0;
        private BitmapData bitmapData_0;
        private unsafe byte* pByte_0;

        public unsafe RawBitmap(Bitmap originBitmap)
        {
            this.bitmap_0 = originBitmap;
            this.bitmapData_0 = this.bitmap_0.LockBits(new Rectangle(0, 0, this.bitmap_0.Width, this.bitmap_0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            this.pByte_0 = (byte*) this.bitmapData_0.Scan0;
        }

        public void Dispose()
        {
            this.bitmap_0.UnlockBits(this.bitmapData_0);
        }

        public int GetOffset()
        {
            return (this.bitmapData_0.Stride - (this.bitmapData_0.Width * 4));
        }

        public unsafe void SetColor(int x, int y, Color color)
        {
            byte* numPtr = this[x, y];
            numPtr[0] = color.B;
            numPtr[1] = color.G;
            numPtr[2] = color.R;
            numPtr[3] = color.A;
        }

        public unsafe void SetColor(int x, int y, int color)
        {
            *((int*) ((this.pByte_0 + (y * this.bitmapData_0.Stride)) + (x * 4))) = color;
        }

        public byte* Begin
        {
            get
            {
                return this.pByte_0;
            }
        }

        public int Height
        {
            get
            {
                return this.bitmapData_0.Height;
            }
        }

        public byte* this[int x, int y]
        {
            get
            {
                return ((this.pByte_0 + (y * this.bitmapData_0.Stride)) + (x * 4));
            }
        }

        public byte* this[int x, int y, int offset]
        {
            get
            {
                return (((this.pByte_0 + (y * this.bitmapData_0.Stride)) + (x * 4)) + offset);
            }
        }

        public Bitmap OriginBitmap
        {
            get
            {
                return this.bitmap_0;
            }
        }

        public int Stride
        {
            get
            {
                return this.bitmapData_0.Stride;
            }
        }

        public int Width
        {
            get
            {
                return this.bitmapData_0.Width;
            }
        }
    }
}

