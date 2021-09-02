namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class FastBitmap : IDisposable, ICloneable
    {
        private System.Drawing.Bitmap bitmap_0;
        internal BitmapData bitmapData_0;

        private FastBitmap()
        {
        }

        public FastBitmap(System.Drawing.Bitmap bitmap)
        {
            this.bitmap_0 = bitmap;
        }

        public FastBitmap(int width, int height, PixelFormat format)
        {
            this.bitmap_0 = new System.Drawing.Bitmap(width, height, format);
        }

        public object Clone()
        {
            return new FastBitmap { bitmap_0 = (System.Drawing.Bitmap) this.bitmap_0.Clone() };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Unlock();
            if (disposing)
            {
                this.bitmap_0.Dispose();
            }
        }

        ~FastBitmap()
        {
            this.Dispose(false);
        }

        public byte GetIntensity(int x, int y)
        {
            Color pixel = this.GetPixel(x, y);
            return (byte) ((((pixel.R * 0.3) + (pixel.G * 0.59)) + (pixel.B * 0.11)) + 0.5);
        }

        public unsafe Color GetPixel(int x, int y)
        {
            if (this.bitmapData_0.PixelFormat == PixelFormat.Format32bppArgb)
            {
                byte* numPtr = (byte*) ((((int) this.bitmapData_0.Scan0) + (y * this.bitmapData_0.Stride)) + (x * 4));
                return Color.FromArgb(numPtr[3], numPtr[2], numPtr[1], numPtr[0]);
            }
            if (this.bitmapData_0.PixelFormat == PixelFormat.Format24bppRgb)
            {
                byte* numPtr2 = (byte*) ((((int) this.bitmapData_0.Scan0) + (y * this.bitmapData_0.Stride)) + (x * 3));
                return Color.FromArgb(numPtr2[2], numPtr2[1], numPtr2[0]);
            }
            return Color.Empty;
        }

        public void Lock()
        {
            this.bitmapData_0 = this.bitmap_0.LockBits(new Rectangle(0, 0, this.bitmap_0.Width, this.bitmap_0.Height), ImageLockMode.ReadWrite, this.bitmap_0.PixelFormat);
        }

        public void Save(string filename)
        {
            this.bitmap_0.Save(filename);
        }

        public void Save(string filename, ImageFormat format)
        {
            this.bitmap_0.Save(filename, format);
        }

        public unsafe void SetPixel(int x, int y, Color c)
        {
            if (this.bitmapData_0.PixelFormat == PixelFormat.Format32bppArgb)
            {
                byte* numPtr = (byte*) ((((int) this.bitmapData_0.Scan0) + (y * this.bitmapData_0.Stride)) + (x * 4));
                numPtr[0] = c.B;
                numPtr[1] = c.G;
                numPtr[2] = c.R;
                numPtr[3] = c.A;
            }
            if (this.bitmapData_0.PixelFormat == PixelFormat.Format24bppRgb)
            {
                byte* numPtr2 = (byte*) ((((int) this.bitmapData_0.Scan0) + (y * this.bitmapData_0.Stride)) + (x * 3));
                numPtr2[0] = c.B;
                numPtr2[1] = c.G;
                numPtr2[2] = c.R;
            }
        }

        public void Unlock()
        {
            if (this.bitmapData_0 != null)
            {
                this.bitmap_0.UnlockBits(this.bitmapData_0);
                this.bitmapData_0 = null;
            }
        }

        public System.Drawing.Bitmap Bitmap
        {
            get
            {
                return this.bitmap_0;
            }
            set
            {
                if (value != null)
                {
                    this.bitmap_0 = value;
                }
            }
        }

        public int Height
        {
            get
            {
                return this.bitmap_0.Height;
            }
        }

        public int Width
        {
            get
            {
                return this.bitmap_0.Width;
            }
        }
    }
}

