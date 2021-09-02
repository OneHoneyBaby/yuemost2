namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LineAttributes
    {
        private bool bool_0;
        private System.Drawing.Color color_0;
        private HatchStyle hatchStyle_0;
        private int int_0;

        public LineAttributes()
        {
            this.int_0 = 1;
            this.color_0 = System.Drawing.Color.Black;
            this.bool_0 = false;
            this.hatchStyle_0 = HatchStyle.Cross;
        }

        public LineAttributes(int Width, System.Drawing.Color Color)
        {
            this.int_0 = 1;
            this.color_0 = System.Drawing.Color.Black;
            this.bool_0 = false;
            this.hatchStyle_0 = HatchStyle.Cross;
            this.Color = Color;
            this.Width = Width;
        }

        public LineAttributes(int Width, System.Drawing.Color Color, bool EnableTexture, HatchStyle TextureStype)
        {
            this.int_0 = 1;
            this.color_0 = System.Drawing.Color.Black;
            this.bool_0 = false;
            this.hatchStyle_0 = HatchStyle.Cross;
            this.Color = Color;
            this.EnableTexture = EnableTexture;
            this.Width = Width;
            this.TextureStyle = this.TextureStyle;
        }

        [Description("Line Color\n线条的颜色"), Category("DSkinChart")]
        public System.Drawing.Color Color
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Draw texture Line\n使用纹理线条")]
        public bool EnableTexture
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Texture style of Line\n纹理线条的纹理类型")]
        public HatchStyle TextureStyle
        {
            get
            {
                return this.hatchStyle_0;
            }
            set
            {
                this.hatchStyle_0 = value;
            }
        }

        [Description("Line width\n线条的粗细"), Category("DSkinChart")]
        public int Width
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }
    }
}

