namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class RotateText
    {
        private System.Drawing.Graphics graphics_0;

        public RotateText(System.Drawing.Graphics Graphics)
        {
            this.Graphics = Graphics;
        }

        public void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format, float angle)
        {
            Matrix transform = this.graphics_0.Transform;
            Matrix matrix2 = this.graphics_0.Transform;
            matrix2.RotateAt(angle, point);
            this.graphics_0.Transform = matrix2;
            this.graphics_0.DrawString(s, font, brush, point, format);
            this.graphics_0.Transform = transform;
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format, float angle)
        {
            SizeF ef = this.graphics_0.MeasureString(s, font);
            SizeF ef2 = this.method_0(ef, angle);
            PointF point = this.method_1(ef2, layoutRectangle, format);
            StringFormat format2 = new StringFormat(format) {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.DrawString(s, font, brush, point, format2, angle);
        }

        private SizeF method_0(SizeF sizeF_0, float float_0)
        {
            Matrix matrix = new Matrix();
            matrix.Rotate(float_0);
            PointF[] pts = new PointF[4];
            pts[0].X = -sizeF_0.Width / 2f;
            pts[0].Y = -sizeF_0.Height / 2f;
            pts[1].X = -sizeF_0.Width / 2f;
            pts[1].Y = sizeF_0.Height / 2f;
            pts[2].X = sizeF_0.Width / 2f;
            pts[2].Y = sizeF_0.Height / 2f;
            pts[3].X = sizeF_0.Width / 2f;
            pts[3].Y = -sizeF_0.Height / 2f;
            matrix.TransformPoints(pts);
            float maxValue = float.MaxValue;
            float minValue = float.MinValue;
            float y = float.MaxValue;
            float num4 = float.MinValue;
            foreach (PointF tf in pts)
            {
                if (tf.X < maxValue)
                {
                    maxValue = tf.X;
                }
                if (tf.X > minValue)
                {
                    minValue = tf.X;
                }
                if (tf.Y < y)
                {
                    y = tf.Y;
                }
                if (tf.Y > num4)
                {
                    num4 = tf.Y;
                }
            }
            return new SizeF(minValue - maxValue, num4 - y);
        }

        private PointF method_1(SizeF sizeF_0, RectangleF rectangleF_0, StringFormat stringFormat_0)
        {
            PointF tf = new PointF();
            switch (stringFormat_0.Alignment)
            {
                case StringAlignment.Near:
                    tf.X = rectangleF_0.Left + (sizeF_0.Width / 2f);
                    break;

                case StringAlignment.Center:
                    tf.X = (rectangleF_0.Left + rectangleF_0.Right) / 2f;
                    break;

                case StringAlignment.Far:
                    tf.X = rectangleF_0.Right - (sizeF_0.Width / 2f);
                    break;
            }
            switch (stringFormat_0.LineAlignment)
            {
                case StringAlignment.Near:
                    tf.Y = rectangleF_0.Top + (sizeF_0.Height / 2f);
                    return tf;

                case StringAlignment.Center:
                    tf.Y = (rectangleF_0.Top + rectangleF_0.Bottom) / 2f;
                    return tf;

                case StringAlignment.Far:
                    tf.Y = rectangleF_0.Bottom - (sizeF_0.Height / 2f);
                    return tf;
            }
            return tf;
        }

        public System.Drawing.Graphics Graphics
        {
            get
            {
                return this.graphics_0;
            }
            set
            {
                this.graphics_0 = value;
            }
        }
    }
}

