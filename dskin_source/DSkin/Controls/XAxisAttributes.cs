namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class XAxisAttributes : AxisAttributes
    {
        private float float_0;
        private int int_1;

        public XAxisAttributes()
        {
            this.int_1 = 1;
            this.float_0 = 30f;
        }

        public XAxisAttributes(int SampleSize, float RotateAngle)
        {
            this.int_1 = 1;
            this.float_0 = 30f;
            this.SampleSize = SampleSize;
            this.RotateAngle = RotateAngle;
        }

        public XAxisAttributes(bool Show, Color ForeColor, Color BackColor, Font Font, string UnitText, string ValueFormat, Font UnitFont, int SampleSize, float RotateAngle)
        {
            this.int_1 = 1;
            this.float_0 = 30f;
            this.SampleSize = SampleSize;
            this.RotateAngle = RotateAngle;
            base.Show = Show;
            base.Font = Font;
            base.ForeColor = ForeColor;
            base.BackColor = BackColor;
            base.UnitText = UnitText;
            base.ValueFormat = ValueFormat;
            base.UnitFont = Font;
        }

        [Category("DSkinChart"), Description("XLabels RotateAngle\nX坐标文字旋转角度")]
        public float RotateAngle
        {
            get
            {
                return this.float_0;
            }
            set
            {
                this.float_0 = value;
            }
        }

        [Category("DSkinChart"), Description("XLabels SampleSize\nX坐标抽样率")]
        public int SampleSize
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

