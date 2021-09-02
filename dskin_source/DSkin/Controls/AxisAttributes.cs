namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AxisAttributes : Attributes
    {
        private Font font_1;
        private int int_0;
        private string string_0;
        private string string_1;

        public AxisAttributes()
        {
            this.string_0 = "%";
            this.string_1 = "0.0";
            this.font_1 = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.int_0 = 5;
        }

        public AxisAttributes(string UnitText, string ValueFormat)
        {
            this.string_0 = "%";
            this.string_1 = "0.0";
            this.font_1 = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.int_0 = 5;
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
        }

        public AxisAttributes(string UnitText, string ValueFormat, Font UnitFont)
        {
            this.string_0 = "%";
            this.string_1 = "0.0";
            this.font_1 = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.int_0 = 5;
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
            this.UnitFont = base.Font;
        }

        public AxisAttributes(bool Show, Color ForeColor, Color BackColor, Font Font, string UnitText, string ValueFormat, Font UnitFont)
        {
            this.string_0 = "%";
            this.string_1 = "0.0";
            this.font_1 = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
            this.int_0 = 5;
            base.Show = Show;
            base.Font = Font;
            base.ForeColor = ForeColor;
            base.BackColor = BackColor;
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
            this.UnitFont = Font;
        }

        [Category("DSkinChart"), Description("标签数量")]
        public int LabelCount
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

        [Category("DSkinChart"), Description("Fonts this unit text\n坐标轴单位文字的字体")]
        public Font UnitFont
        {
            get
            {
                return this.font_1;
            }
            set
            {
                this.font_1 = value;
            }
        }

        [Description("Labels Unit\n坐标文字的单位"), Category("DSkinChart")]
        public string UnitText
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

        [Description("Text format for Y-label values\n纵坐标数值显示格式(用来控制小数位数)"), Category("DSkinChart")]
        public string ValueFormat
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
    }
}

