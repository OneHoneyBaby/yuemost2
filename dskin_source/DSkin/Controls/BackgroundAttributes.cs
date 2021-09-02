namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BackgroundAttributes
    {
        private Color color_0;
        private Color color_1;

        public BackgroundAttributes()
        {
            this.color_0 = Color.FromArgb(80, 0xee, 0xed, 0xee);
            this.color_1 = Color.FromArgb(0xff, 220, 220, 220);
        }

        public BackgroundAttributes(Color Highlight, Color Lowlight)
        {
            this.color_0 = Color.FromArgb(80, 0xee, 0xed, 0xee);
            this.color_1 = Color.FromArgb(0xff, 220, 220, 220);
            this.Highlight = Highlight;
            this.Lowlight = Lowlight;
        }

        [Category("DSkinChart"), Description("Highlighted Background Color\n背景色的高亮色")]
        public Color Highlight
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

        [Category("DSkinChart"), Description("Low Light of Background Color\n背景色的暗色")]
        public Color Lowlight
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
    }
}

