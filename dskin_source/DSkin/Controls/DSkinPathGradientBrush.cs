namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [ToolboxItem(true)]
    public class DSkinPathGradientBrush : DSkinBrush
    {
        private Collection<DSkinPoint> collection_0 = new Collection<DSkinPoint>();
        private Collection<BlendColor> collection_1 = new Collection<BlendColor>();
        private PathGradientBrush pathGradientBrush_0;
        private System.Drawing.Drawing2D.WrapMode wrapMode_0 = System.Drawing.Drawing2D.WrapMode.Clamp;

        public DSkinPathGradientBrush()
        {
            this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinPoint>>(this.method_1);
            this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinPoint>>(this.method_1);
            this.collection_1.ItemAdded += new EventHandler<CollectionEventArgs<BlendColor>>(this.method_0);
            this.collection_1.ItemRemoved += new EventHandler<CollectionEventArgs<BlendColor>>(this.method_0);
        }

        protected override Brush CreateBrush()
        {
            int num;
            Point[] points = new Point[this.collection_0.Count];
            if (this.collection_0.Count < 3)
            {
                points = new Point[] { new Point(), new Point(1, 0), new Point(0, 1) };
            }
            else
            {
                for (num = 0; num < this.collection_0.Count; num++)
                {
                    points[num] = this.collection_0[num].Point;
                }
            }
            this.pathGradientBrush_0 = new PathGradientBrush(points);
            ColorBlend blend = new ColorBlend {
                Colors = new Color[this.collection_1.Count],
                Positions = new float[this.collection_1.Count]
            };
            for (num = 0; num < this.collection_1.Count; num++)
            {
                blend.Colors[num] = this.collection_1[num].Color;
                blend.Positions[num] = (num == 0) ? 0f : ((num == (this.collection_1.Count - 1)) ? 1f : this.collection_1[num].Position);
            }
            this.pathGradientBrush_0.InterpolationColors = blend;
            this.pathGradientBrush_0.WrapMode = this.wrapMode_0;
            return this.pathGradientBrush_0;
        }

        private void method_0(object sender, CollectionEventArgs<BlendColor> e)
        {
            this.method_2();
        }

        private void method_1(object sender, CollectionEventArgs<DSkinPoint> e)
        {
            this.method_2();
        }

        private void method_2()
        {
            if (this.pathGradientBrush_0 != null)
            {
                this.pathGradientBrush_0.Dispose();
                this.pathGradientBrush_0 = null;
                this.Brush = null;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("渐变颜色集合，注意渐变颜色距离只能在0到1之间，第一个为0，最后一个为1")]
        public Collection<BlendColor> Colors
        {
            get
            {
                return this.collection_1;
            }
        }

        [Description("多边形顶点，最少需要3个点"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<DSkinPoint> Points
        {
            get
            {
                return this.collection_0;
            }
        }

        [DefaultValue(4), Description("获取或设置换行模式。")]
        public System.Drawing.Drawing2D.WrapMode WrapMode
        {
            get
            {
                return this.wrapMode_0;
            }
            set
            {
                this.wrapMode_0 = value;
                if (this.pathGradientBrush_0 != null)
                {
                    this.pathGradientBrush_0.WrapMode = value;
                }
            }
        }
    }
}

