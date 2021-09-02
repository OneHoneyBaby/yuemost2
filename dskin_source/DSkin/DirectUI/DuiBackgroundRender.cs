namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DuiBackgroundRender : IDisposable
    {
        internal Bitmap bitmap_0;
        private bool bool_0 = false;
        private bool bool_1 = false;
        private BorderTypes borderTypes_0 = BorderTypes.Solid;
        private Color color_0 = Color.Black;
        private DSkinBrush dskinBrush_0;
        private DSkinPen dskinPen_0;
        private DuiBaseControl duiBaseControl_0;
        private int int_0 = 1;
        private int int_1 = 0;
        private Padding padding_0 = new Padding(5);
        private Rectangle rectangle_0 = new Rectangle();
        private Size size_0;

        public DuiBackgroundRender(DuiBaseControl owner)
        {
            this.duiBaseControl_0 = owner;
            this.size_0 = owner.Size;
        }

        public void Dispose()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
        }

        internal void method_0()
        {
            Rectangle srcRect = this.rectangle_0;
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            if (((this.duiBaseControl_0.BackgroundImage != null) && (srcRect.Width > 0)) && (srcRect.Height > 0))
            {
                this.bitmap_0 = new Bitmap(srcRect.Width, srcRect.Height);
                using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                {
                    graphics.DrawImage(this.duiBaseControl_0.BackgroundImage, new Rectangle(0, 0, srcRect.Width, srcRect.Height), srcRect, GraphicsUnit.Pixel);
                }
            }
        }

        [DefaultValue((string) null), Description("自定义背景刷")]
        public DSkinBrush BackgroundBrush
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
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("背景图剪辑区域"), DefaultValue(typeof(Rectangle), "0,0,0,0")]
        public Rectangle BackgroundImageClipRect
        {
            get
            {
                return this.rectangle_0;
            }
            set
            {
                if (this.rectangle_0 != value)
                {
                    this.rectangle_0 = value;
                    this.method_0();
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "Black"), Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_0 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Description("自定义边框画笔")]
        public DSkinPen BorderPen
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
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("边框类型"), DefaultValue(typeof(BorderTypes), "Solid")]
        public BorderTypes BorderType
        {
            get
            {
                return this.borderTypes_0;
            }
            set
            {
                if (this.borderTypes_0 != value)
                {
                    this.borderTypes_0 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("边框宽度"), DefaultValue(1)]
        public int BorderWidth
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
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(0), Description("边框圆角宽度")]
        public int Radius
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("是否渲染边框"), DefaultValue(false)]
        public bool RenderBorders
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool SudokuDrawBackImage
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Padding SudokuPartitionWidth
        {
            get
            {
                return this.padding_0;
            }
            set
            {
                if (this.padding_0 != value)
                {
                    this.padding_0 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }
    }
}

