namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Painting
    {
        private bool bool_0;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private DSkinChart.ColorStyles colorStyles_0;
        private HatchStyle hatchStyle_0;
        private int int_0;

        public Painting()
        {
            this.int_0 = 0;
            this.hatchStyle_0 = HatchStyle.DarkUpwardDiagonal;
            this.bool_0 = false;
            this.colorStyles_0 = DSkinChart.ColorStyles.None;
        }

        public Painting(int ShiftStep, Color Color1, Color Color2, Color Color3)
        {
            this.int_0 = 0;
            this.hatchStyle_0 = HatchStyle.DarkUpwardDiagonal;
            this.bool_0 = false;
            this.colorStyles_0 = DSkinChart.ColorStyles.None;
            this.ShiftStep = ShiftStep;
            this.Color1 = Color1;
            this.Color2 = Color2;
            this.Color3 = Color3;
        }

        public Painting(int ShiftStep, Color Color1, Color Color2, Color Color3, bool TextureEnable, HatchStyle TextureStyle)
        {
            this.int_0 = 0;
            this.hatchStyle_0 = HatchStyle.DarkUpwardDiagonal;
            this.bool_0 = false;
            this.colorStyles_0 = DSkinChart.ColorStyles.None;
            this.ShiftStep = ShiftStep;
            this.Color1 = Color1;
            this.Color2 = Color2;
            this.Color3 = Color3;
            this.TextureEnable = TextureEnable;
            this.TextureStyle = TextureStyle;
        }

        [Category("DSkinChart"), Description("First Color\n颜色1")]
        public Color Color1
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

        [Category("DSkinChart"), Description("Second Color\n颜色2")]
        public Color Color2
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        [Description("Third Color\n颜色3"), Category("DSkinChart")]
        public Color Color3
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        [Category("DSkinChart"), Description("Please Choose a Color Style\n颜色样式")]
        public DSkinChart.ColorStyles ColorStyle
        {
            get
            {
                return this.colorStyles_0;
            }
            set
            {
                this.colorStyles_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Color Index in Color Style\n颜色索引")]
        public int ShiftStep
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

        [Category("DSkinChart"), Description("Enable Texture Style\n启用纹理样式")]
        public bool TextureEnable
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

        [Description("Paint Texture Style\n纹理样式"), Category("DSkinChart")]
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
    }
}

