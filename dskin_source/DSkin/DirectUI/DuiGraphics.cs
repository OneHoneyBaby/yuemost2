namespace DSkin.DirectUI
{
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class DuiGraphics : DuiBaseControl
    {
        private Collection<DSkinPoint> collection_0 = new Collection<DSkinPoint>();
        private DSkinBrush dskinBrush_0;
        private DSkinPen dskinPen_0;
        private GraphicsTypes graphicsTypes_0 = GraphicsTypes.Point;
        private Point point_1 = new Point();
        private System.Drawing.Drawing2D.SmoothingMode smoothingMode_0 = System.Drawing.Drawing2D.SmoothingMode.Default;

        public DuiGraphics()
        {
            this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinPoint>>(this.method_30);
            this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinPoint>>(this.method_29);
        }

        private void method_29(object sender, CollectionEventArgs<DSkinPoint> e)
        {
            this.Invalidate();
        }

        private void method_30(object sender, CollectionEventArgs<DSkinPoint> e)
        {
            this.Invalidate();
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            Point point;
            Size size;
            int count;
            Point[] pointArray;
            int num2;
            base.OnPrePaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = this.smoothingMode_0;
            switch (this.graphicsTypes_0)
            {
                case GraphicsTypes.Point:
                    if (this.dskinPen_0 != null)
                    {
                        foreach (DSkinPoint point3 in this.collection_0)
                        {
                            Rectangle rect = new Rectangle(new Point(point3.X + this.point_1.X, point3.Y + this.point_1.Y), new Size((int) this.dskinPen_0.Width, (int) this.dskinPen_0.Width));
                            if (this.dskinPen_0.DashCap == DashCap.Flat)
                            {
                                graphics.FillRectangle(this.dskinPen_0.Pen.Brush, rect);
                            }
                            else if (this.dskinPen_0.DashCap == DashCap.Round)
                            {
                                graphics.FillEllipse(this.dskinPen_0.Pen.Brush, rect);
                            }
                            else
                            {
                                Point[] points = new Point[] { new Point(rect.X, rect.Y + ((int) (this.dskinPen_0.Width / 2f))), new Point(rect.X + ((int) (this.dskinPen_0.Width / 2f)), rect.Y), new Point(rect.X + ((int) this.dskinPen_0.Width), rect.Y + ((int) (this.dskinPen_0.Width / 2f))), new Point(rect.X + ((int) (this.dskinPen_0.Width / 2f)), rect.Y + ((int) this.dskinPen_0.Width)) };
                                graphics.FillPolygon(this.dskinPen_0.Pen.Brush, points);
                            }
                        }
                    }
                    return;

                case GraphicsTypes.Line:
                    if ((this.dskinPen_0 != null) && (this.collection_0.Count > 0))
                    {
                        Point point2 = this.point_1;
                        if (this.collection_0.Count == 1)
                        {
                            Point point4 = new Point(this.collection_0[0].X + this.point_1.X, this.collection_0[0].Y + this.point_1.Y);
                            graphics.DrawLine(this.dskinPen_0.Pen, point2, point4);
                        }
                        else
                        {
                            point2 = new Point(this.collection_0[0].X + this.point_1.X, this.collection_0[0].Y + this.point_1.Y);
                            for (num2 = 1; num2 < this.collection_0.Count; num2++)
                            {
                                Point point5 = new Point(this.collection_0[num2].X + this.point_1.X, this.collection_0[num2].Y + this.point_1.Y);
                                graphics.DrawLine(this.dskinPen_0.Pen, point2, point5);
                                point2 = point5;
                            }
                        }
                    }
                    return;

                case GraphicsTypes.Rectangle:
                    if (this.collection_0.Count > 1)
                    {
                        point = new Point((this.collection_0[0].X < this.collection_0[1].X) ? this.collection_0[0].X : this.collection_0[1].X, (this.collection_0[0].Y < this.collection_0[1].Y) ? this.collection_0[0].Y : this.collection_0[1].Y);
                        size = new Size(Math.Abs((int) (this.collection_0[0].X - this.collection_0[1].X)), Math.Abs((int) (this.collection_0[0].Y - this.collection_0[1].Y)));
                        point.Offset(this.point_1);
                        if (this.dskinBrush_0 != null)
                        {
                            graphics.FillRectangle(this.dskinBrush_0.Brush, new Rectangle(point, size));
                        }
                        if (this.dskinPen_0 != null)
                        {
                            graphics.DrawRectangle(this.dskinPen_0.Pen, new Rectangle(point, size));
                        }
                    }
                    return;

                case GraphicsTypes.Ellipse:
                    if (this.collection_0.Count > 1)
                    {
                        point = new Point((this.collection_0[0].X < this.collection_0[1].X) ? this.collection_0[0].X : this.collection_0[1].X, (this.collection_0[0].Y < this.collection_0[1].Y) ? this.collection_0[0].Y : this.collection_0[1].Y);
                        size = new Size(Math.Abs((int) (this.collection_0[0].X - this.collection_0[1].X)), Math.Abs((int) (this.collection_0[0].Y - this.collection_0[1].Y)));
                        point.Offset(this.point_1);
                        if (this.dskinBrush_0 != null)
                        {
                            graphics.FillEllipse(this.dskinBrush_0.Brush, point.X, point.Y, size.Width, size.Height);
                        }
                        if (this.dskinPen_0 != null)
                        {
                            graphics.DrawEllipse(this.dskinPen_0.Pen, point.X, point.Y, size.Width, size.Height);
                        }
                    }
                    return;

                case GraphicsTypes.Pie:
                    if (this.collection_0.Count > 2)
                    {
                        point = new Point((this.collection_0[0].X < this.collection_0[1].X) ? this.collection_0[0].X : this.collection_0[1].X, (this.collection_0[0].Y < this.collection_0[1].Y) ? this.collection_0[0].Y : this.collection_0[1].Y);
                        size = new Size(Math.Abs((int) (this.collection_0[0].X - this.collection_0[1].X)), Math.Abs((int) (this.collection_0[0].Y - this.collection_0[1].Y)));
                        point.Offset(this.point_1);
                        if (this.dskinBrush_0 != null)
                        {
                            graphics.FillPie(this.dskinBrush_0.Brush, point.X, point.Y, size.Width, size.Height, this.collection_0[2].X, this.collection_0[2].Y);
                        }
                        if (this.dskinPen_0 != null)
                        {
                            graphics.DrawPie(this.dskinPen_0.Pen, point.X, point.Y, size.Width, size.Height, this.collection_0[2].X, this.collection_0[2].Y);
                        }
                    }
                    return;

                case GraphicsTypes.Arc:
                    if ((this.collection_0.Count > 2) && (this.dskinPen_0 != null))
                    {
                        point = new Point((this.collection_0[0].X < this.collection_0[1].X) ? this.collection_0[0].X : this.collection_0[1].X, (this.collection_0[0].Y < this.collection_0[1].Y) ? this.collection_0[0].Y : this.collection_0[1].Y);
                        size = new Size(Math.Abs((int) (this.collection_0[0].X - this.collection_0[1].X)), Math.Abs((int) (this.collection_0[0].Y - this.collection_0[1].Y)));
                        point.Offset(this.point_1);
                        graphics.DrawArc(this.dskinPen_0.Pen, point.X, point.Y, size.Width, size.Height, this.collection_0[2].X, this.collection_0[2].Y);
                    }
                    return;

                case GraphicsTypes.Bezier:
                    if ((this.collection_0.Count <= 3) || (this.dskinPen_0 == null))
                    {
                        return;
                    }
                    count = 4;
                    if ((this.collection_0.Count % 3) != 1)
                    {
                        count = (this.collection_0.Count - (this.collection_0.Count % 3)) + 1;
                        if (count > this.collection_0.Count)
                        {
                            count -= 3;
                        }
                        break;
                    }
                    count = this.collection_0.Count;
                    break;

                case GraphicsTypes.Polygon:
                    if (this.collection_0.Count > 2)
                    {
                        pointArray = new Point[this.collection_0.Count];
                        num2 = 0;
                        while (num2 < this.collection_0.Count)
                        {
                            pointArray[num2] = new Point(this.collection_0[num2].X + this.point_1.X, this.collection_0[num2].Y + this.point_1.Y);
                            num2++;
                        }
                        if (this.dskinBrush_0 != null)
                        {
                            graphics.FillPolygon(this.dskinBrush_0.Brush, pointArray);
                        }
                        if (this.dskinPen_0 != null)
                        {
                            graphics.DrawPolygon(this.dskinPen_0.Pen, pointArray);
                        }
                    }
                    return;

                default:
                    return;
            }
            pointArray = new Point[count];
            for (num2 = 0; num2 < count; num2++)
            {
                pointArray[num2] = new Point(this.collection_0[num2].X + this.point_1.X, this.collection_0[num2].Y + this.point_1.Y);
            }
            graphics.DrawBeziers(this.dskinPen_0.Pen, pointArray);
        }

        [Category("图形"), DefaultValue((string) null), Description("自定义填充刷")]
        public DSkinBrush Brush
        {
            get
            {
                return this.dskinBrush_0;
            }
            set
            {
                if (this.dskinBrush_0 != value)
                {
                    this.dskinBrush_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(0), Description("图形类型"), Category("图形")]
        public GraphicsTypes GraphicsType
        {
            get
            {
                return this.graphicsTypes_0;
            }
            set
            {
                if (this.graphicsTypes_0 != value)
                {
                    this.graphicsTypes_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Category("图形"), Description("自定义画笔")]
        public DSkinPen Pen
        {
            get
            {
                return this.dskinPen_0;
            }
            set
            {
                if (this.dskinPen_0 != value)
                {
                    this.dskinPen_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Description("图像偏移"), Category("图形")]
        public Point PointOffset
        {
            get
            {
                return this.point_1;
            }
            set
            {
                if (this.point_1 != value)
                {
                    this.point_1 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("点坐标集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("图形")]
        public Collection<DSkinPoint> Points
        {
            get
            {
                return this.collection_0;
            }
        }

        [Description("平滑模式"), DefaultValue(0), Category("图形")]
        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode
        {
            get
            {
                return this.smoothingMode_0;
            }
            set
            {
                if (this.smoothingMode_0 != value)
                {
                    this.smoothingMode_0 = value;
                    this.Invalidate();
                }
            }
        }
    }
}

