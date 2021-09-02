namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Attributes
    {
        private bool bool_0;
        private Color color_0;
        private Color color_1;
        private System.Drawing.Font font_0;

        public Attributes()
        {
            this.bool_0 = true;
            this.font_0 = new System.Drawing.Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.color_0 = Color.Black;
            this.color_1 = Color.White;
        }

        public Attributes(bool Show, Color ForeColor, Color BackColor)
        {
            this.bool_0 = true;
            this.font_0 = new System.Drawing.Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.color_0 = Color.Black;
            this.color_1 = Color.White;
            this.Show = Show;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
        }

        public Attributes(bool Show, Color ForeColor, Color BackColor, System.Drawing.Font Font)
        {
            this.bool_0 = true;
            this.font_0 = new System.Drawing.Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.color_0 = Color.Black;
            this.color_1 = Color.White;
            this.Show = Show;
            this.Font = Font;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
        }

        [Category("DSkinChart"), Description("Back Color\n背景色")]
        public Color BackColor
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

        [Category("DSkinChart"), Description("Fonts this block text\n字体")]
        public System.Drawing.Font Font
        {
            get
            {
                return this.font_0;
            }
            set
            {
                this.font_0 = value;
            }
        }

        [Description("Fore color, mostly represents text Color\n前景色，大部分时候指的是字体颜色"), Category("DSkinChart")]
        public Color ForeColor
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

        [Category("DSkinChart"), Description("Whether to show\n是否显示")]
        public bool Show
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
    }
}

