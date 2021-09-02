namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public class TextShadow
    {
        private byte byte_0 = 0xc0;
        private double double_0 = 60.0;
        private int int_0 = 3;
        private int int_1 = 0;
        private int[] int_2;
        private int int_3 = 0;

        public void DropShadow(Graphics g, Rectangle r, Color c, string Action, string Type, GraphicsPath gp, int penWidth)
        {
            RectangleF rect = new RectangleF((float) (this.int_0 * 2), (float) (this.int_0 * 2), (float) r.Width, (float) r.Height);
            Rectangle rectangle = new Rectangle(this.int_0 * 2, this.int_0 * 2, r.Width, r.Height);
            Bitmap image = new Bitmap(((int) rect.Width) + (this.int_0 * 4), ((int) rect.Height) + (this.int_0 * 4), PixelFormat.Format32bppArgb);
            if (c.IsEmpty)
            {
                c = Color.Black;
            }
            if (penWidth == 0)
            {
                penWidth = 1;
            }
            Brush brush = new SolidBrush(Color.FromArgb(this.Alpha, c));
            Pen pen = new Pen(Color.FromArgb(this.Alpha, c), (float) penWidth);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            try
            {
                RectangleF ef2;
                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(0xfe, 0xff, 0, 0)))
                {
                    switch (Type)
                    {
                        case "Ellipse":
                            goto Label_0247;

                        case "Rectangle":
                            if (Action == "Fill")
                            {
                                graphics.FillRectangle(brush, rect);
                            }
                            else if (Action == "Draw")
                            {
                                graphics.DrawRectangle(pen, rectangle);
                            }
                            else
                            {
                                graphics.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel), brush2, rect);
                            }
                            break;

                        case "Path":
                            if (Action == "Fill")
                            {
                                graphics.TranslateTransform((float) ((r.Left * -1) + (this.int_0 * 2)), (float) ((r.Top * -1) + (this.int_0 * 2)));
                                graphics.FillPath(brush, gp);
                                break;
                            }
                            if (Action == "Draw")
                            {
                                graphics.TranslateTransform((float) ((r.Left * -1) + (this.int_0 * 2)), (float) ((r.Top * -1) + (this.int_0 * 2)));
                                graphics.DrawPath(pen, gp);
                            }
                            else
                            {
                                graphics.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel), brush2, rect);
                            }
                            break;
                    }
                    goto Label_02B1;
                Label_0247:
                    if (Action == "Fill")
                    {
                        graphics.FillEllipse(brush, rect);
                    }
                    else if (Action == "Draw")
                    {
                        graphics.DrawEllipse(pen, rectangle);
                    }
                    else
                    {
                        graphics.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel), brush2, rect);
                    }
                }
            Label_02B1:
                ef2 = r;
                if ((Action == "Fill") || (Action == "Draw"))
                {
                    this.method_0(image);
                    ef2.Offset((float) (Math.Cos((3.1415926535897931 * this.double_0) / 180.0) * this.int_1), (float) (Math.Sin((3.1415926535897931 * this.double_0) / 180.0) * this.int_1));
                    rect.Inflate((float) this.int_0, (float) this.int_0);
                    ef2.Inflate((float) this.int_0, (float) this.int_0);
                }
                g.DrawImage(image, ef2, rect, GraphicsUnit.Pixel);
            }
            finally
            {
                graphics.Dispose();
                brush.Dispose();
                image.Dispose();
            }
        }

        protected virtual void MakeGaussMatrix()
        {
            double num = ((double) this.int_0) / 2.0;
            if (num == 0.0)
            {
                num = 0.1;
            }
            int num2 = (this.int_0 * 2) + 1;
            int index = 0;
            this.int_3 = 0;
            this.int_2 = new int[num2 * num2];
            for (int i = -this.int_0; i <= this.int_0; i++)
            {
                for (int j = -this.int_0; j <= this.int_0; j++)
                {
                    this.int_2[index] = (int) Math.Round((double) ((Math.Exp(-((i * i) + (j * j)) / ((2.0 * num) * num)) / ((6.2831853071795862 * num) * num)) * 1000.0));
                    this.int_3 += this.int_2[index];
                    index++;
                }
            }
        }

        private unsafe void method_0(Bitmap bitmap_0)
        {
            if (this.int_3 == 0)
            {
                this.MakeGaussMatrix();
            }
            Rectangle rect = new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
            Bitmap bitmap = (Bitmap) bitmap_0.Clone();
            BitmapData bitmapdata = bitmap_0.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            BitmapData data2 = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                byte* numPtr = (byte*) data2.Scan0;
                numPtr += 3;
                byte* numPtr2 = (byte*) bitmapdata.Scan0;
                numPtr2 += (this.int_0 * (bitmapdata.Stride + 4)) + 3;
                int num = bitmapdata.Width - (this.int_0 * 2);
                int num2 = bitmapdata.Height - (this.int_0 * 2);
                int num3 = (this.int_0 * 2) + 1;
                int num4 = bitmapdata.Stride - (num3 * 4);
                int num5 = this.int_0 * 8;
                int num6 = num3 * num3;
                for (int i = 0; i < num2; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        byte* numPtr3 = numPtr - num4;
                        int num8 = 0;
                        int index = 0;
                        while (index < num6)
                        {
                            if ((index % num3) == 0)
                            {
                                numPtr3 += num4;
                            }
                            num8 += this.int_2[index] * numPtr3[0];
                            index++;
                            numPtr3 += 4;
                        }
                        numPtr2[0] = (byte) (num8 / this.int_3);
                        numPtr2 += 4;
                        numPtr += 4;
                    }
                    numPtr2 += num5;
                    numPtr += num5;
                }
            }
            finally
            {
                bitmap.UnlockBits(data2);
                bitmap_0.UnlockBits(bitmapdata);
                bitmap.Dispose();
            }
        }

        public void StringShadow(Graphics g, string text, Font font, PointF origin)
        {
            this.StringShadow(g, text, font, origin, null);
        }

        public void StringShadow(Graphics g, string text, Font font, RectangleF layoutRect)
        {
            this.StringShadow(g, text, font, layoutRect, null);
        }

        public void StringShadow(Graphics g, string text, Font font, PointF origin, StringFormat format)
        {
            RectangleF layoutRect = new RectangleF(origin, g.MeasureString(text, font, origin, format));
            this.StringShadow(g, text, font, layoutRect, format);
        }

        public void StringShadow(Graphics g, string text, Font font, RectangleF layoutRect, StringFormat format)
        {
            RectangleF layoutRectangle = new RectangleF((float) (this.int_0 * 2), (float) (this.int_0 * 2), layoutRect.Width, layoutRect.Height);
            Bitmap image = new Bitmap(((int) layoutRectangle.Width) + (this.int_0 * 4), ((int) layoutRectangle.Height) + (this.int_0 * 4), PixelFormat.Format32bppArgb);
            Brush brush = new SolidBrush(Color.FromArgb((this.Alpha == 0xff) ? 0xfe : this.Alpha, Color.Black));
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                graphics.DrawString(text, font, brush, layoutRectangle, format);
                this.method_0(image);
                RectangleF destRect = layoutRect;
                destRect.Offset((float) (Math.Cos((3.1415926535897931 * this.double_0) / 180.0) * this.int_1), (float) (Math.Sin((3.1415926535897931 * this.double_0) / 180.0) * this.int_1));
                layoutRectangle.Inflate((float) this.int_0, (float) this.int_0);
                destRect.Inflate((float) this.int_0, (float) this.int_0);
                g.DrawImage(image, destRect, layoutRectangle, GraphicsUnit.Pixel);
            }
            finally
            {
                graphics.Dispose();
                brush.Dispose();
                image.Dispose();
            }
        }

        public byte Alpha
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        public double Angle
        {
            get
            {
                return this.double_0;
            }
            set
            {
                this.double_0 = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        public int Radius
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
                    this.MakeGaussMatrix();
                }
            }
        }
    }
}

