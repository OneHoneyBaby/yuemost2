namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextAttributes : Attributes
    {
        private int int_0;
        private string string_0;

        public TextAttributes()
        {
            this.string_0 = "";
            this.int_0 = 0;
        }

        public TextAttributes(string Text)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.Text = Text;
        }

        public TextAttributes(string Text, int OffsetY)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.Text = Text;
            this.OffsetY = OffsetY;
        }

        public TextAttributes(string Text, int OffsetY, bool Show, Color ForeColor, Color BackColor, Font Font)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.Text = Text;
            this.OffsetY = OffsetY;
            base.Show = Show;
            base.Font = Font;
            base.ForeColor = ForeColor;
            base.BackColor = BackColor;
        }

        [Description("Position Offset of Text\n文字的位置偏移，用来微调文字在图上的位置"), Category("DSkinChart")]
        public int OffsetY
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

        [Description("Text to show\n文字"), Category("DSkinChart")]
        public string Text
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

