namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StrokeStyle : Painting
    {
        private int int_1;

        public StrokeStyle()
        {
            this.int_1 = 0;
        }

        public StrokeStyle(int Width)
        {
            this.int_1 = 0;
            this.Width = Width;
        }

        public StrokeStyle(int ShiftStep, Color Color1, Color Color2, Color Color3, bool TextureEnable, HatchStyle TextureStyle, int Width)
        {
            this.int_1 = 0;
            this.Width = Width;
            base.ShiftStep = ShiftStep;
            base.Color1 = Color1;
            base.Color2 = Color2;
            base.Color3 = Color3;
            base.TextureEnable = TextureEnable;
            base.TextureStyle = TextureStyle;
        }

        [Description("Stroke Line Width\n边框宽度"), Category("DSkinChart")]
        public int Width
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
    }
}

