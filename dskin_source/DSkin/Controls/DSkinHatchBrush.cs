namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [ToolboxItem(true)]
    public class DSkinHatchBrush : DSkinBrush
    {
        private Color color_0 = Color.Black;
        private Color color_1 = Color.White;
        private HatchBrush hatchBrush_0;
        private System.Drawing.Drawing2D.HatchStyle hatchStyle_0 = System.Drawing.Drawing2D.HatchStyle.Wave;

        protected override Brush CreateBrush()
        {
            this.hatchBrush_0 = new HatchBrush(this.hatchStyle_0, this.color_1, this.color_0);
            return this.hatchBrush_0;
        }

        [DefaultValue(typeof(Color), "Black"), Description("阴影线条的颜色")]
        public Color BackgroundColor
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
                    if (this.hatchBrush_0 != null)
                    {
                        this.hatchBrush_0.Dispose();
                        this.hatchBrush_0 = null;
                        this.Brush = null;
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "White"), Description("阴影线条的颜色")]
        public Color ForegroundColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                    if (this.hatchBrush_0 != null)
                    {
                        this.hatchBrush_0.Dispose();
                        this.hatchBrush_0 = null;
                        this.Brush = null;
                    }
                }
            }
        }

        [Description("阴影样式"), DefaultValue(0x25)]
        public System.Drawing.Drawing2D.HatchStyle HatchStyle
        {
            get
            {
                return this.hatchStyle_0;
            }
            set
            {
                if (this.hatchStyle_0 != value)
                {
                    this.hatchStyle_0 = value;
                    if (this.hatchBrush_0 != null)
                    {
                        this.hatchBrush_0.Dispose();
                        this.hatchBrush_0 = null;
                        this.Brush = null;
                    }
                }
            }
        }
    }
}

