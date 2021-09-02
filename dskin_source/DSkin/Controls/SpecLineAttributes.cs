namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SpecLineAttributes : LineAttributes
    {
        private bool bool_1;
        private int int_1;
        private int int_2;

        public SpecLineAttributes()
        {
            this.int_1 = 0;
            this.int_2 = 0;
            this.bool_1 = false;
        }

        public SpecLineAttributes(bool Show, int LowLimit, int HighLimit)
        {
            this.int_1 = 0;
            this.int_2 = 0;
            this.bool_1 = false;
            this.Show = Show;
            this.LowLimit = LowLimit;
            this.HighLimit = HighLimit;
        }

        public SpecLineAttributes(bool Show, int LowLimit, int HighLimit, int Width, Color Color, bool EnableTexture, HatchStyle TextureStype)
        {
            this.int_1 = 0;
            this.int_2 = 0;
            this.bool_1 = false;
            base.Color = Color;
            base.EnableTexture = EnableTexture;
            base.Width = Width;
            base.TextureStyle = base.TextureStyle;
            this.Show = Show;
            this.LowLimit = LowLimit;
            this.HighLimit = HighLimit;
        }

        [Category("DSkinChart"), Description("Spec line high limit\nSpec线条的上限")]
        public int HighLimit
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        [Category("DSkinChart"), Description("Spec line Low limit\nSpec线条的下限")]
        public int LowLimit
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

        [Category("DSkinChart"), Description("Whether show Spec limit lines\n是否显示Spec极限线条")]
        public bool Show
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }
    }
}

