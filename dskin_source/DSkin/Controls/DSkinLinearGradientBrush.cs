namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [ToolboxItem(true)]
    public class DSkinLinearGradientBrush : DSkinBrush
    {
        private bool bool_0 = false;
        private Collection<BlendColor> collection_0 = new Collection<BlendColor>();
        private int int_0 = 50;
        private LinearGradientBrush MqPxgrjaLp;
        private System.Drawing.Drawing2D.WrapMode wrapMode_0 = System.Drawing.Drawing2D.WrapMode.Tile;

        public DSkinLinearGradientBrush()
        {
            this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<BlendColor>>(this.method_0);
            this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<BlendColor>>(this.method_0);
        }

        protected override Brush CreateBrush()
        {
            Color white = Color.White;
            Color black = Color.Black;
            if (this.collection_0.Count == 0)
            {
                white = Color.Transparent;
                black = Color.Transparent;
            }
            else if (this.collection_0.Count == 1)
            {
                white = this.collection_0[0].Color;
                black = this.collection_0[0].Color;
            }
            else if (this.collection_0.Count == 2)
            {
                white = this.collection_0[0].Color;
                black = this.collection_0[1].Color;
            }
            this.MqPxgrjaLp = new LinearGradientBrush(new Point(), new Point(this.int_0, 0), white, black);
            if (this.collection_0.Count > 2)
            {
                ColorBlend blend = new ColorBlend {
                    Colors = new Color[this.collection_0.Count],
                    Positions = new float[this.collection_0.Count]
                };
                for (int i = 0; i < this.collection_0.Count; i++)
                {
                    blend.Colors[i] = this.collection_0[i].Color;
                    blend.Positions[i] = (i == 0) ? 0f : this.collection_0[i].Position;
                    blend.Positions[i] = (i == (this.collection_0.Count - 1)) ? 1f : this.collection_0[i].Position;
                }
                this.MqPxgrjaLp.InterpolationColors = blend;
            }
            return this.MqPxgrjaLp;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.MqPxgrjaLp != null)
            {
                this.MqPxgrjaLp.Dispose();
                this.MqPxgrjaLp = null;
            }
            base.Dispose(disposing);
        }

        private void method_0(object sender, CollectionEventArgs<BlendColor> e)
        {
            if (this.MqPxgrjaLp != null)
            {
                this.MqPxgrjaLp.Dispose();
                this.MqPxgrjaLp = null;
                this.Brush = null;
            }
        }

        [Description("渐变颜色集合，注意渐变颜色距离只能在0到1之间，第一个为0，最后一个为1"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<BlendColor> Colors
        {
            get
            {
                return this.collection_0;
            }
        }

        [Description("获取或设置一个值，该值指示是否为该 System.Drawing.Drawing2D.LinearGradientBrush 启用了灰度校正。")]
        public bool GammaCorrection
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                if (this.MqPxgrjaLp != null)
                {
                    this.MqPxgrjaLp.GammaCorrection = value;
                }
            }
        }

        [Description("渐变宽度"), DefaultValue(50)]
        public int Width
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
                    if (this.MqPxgrjaLp != null)
                    {
                        this.MqPxgrjaLp.Dispose();
                        this.MqPxgrjaLp = null;
                        this.Brush = null;
                    }
                }
            }
        }

        [Description("获取或设置 System.Drawing.Drawing2D.WrapMode 枚举，它指示该 System.Drawing.Drawing2D.LinearGradientBrush 的环绕模式。")]
        public System.Drawing.Drawing2D.WrapMode WrapMode
        {
            get
            {
                return this.wrapMode_0;
            }
            set
            {
                this.wrapMode_0 = value;
                if (this.MqPxgrjaLp != null)
                {
                    this.MqPxgrjaLp.WrapMode = value;
                }
            }
        }
    }
}

