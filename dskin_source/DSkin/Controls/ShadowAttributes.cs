namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ShadowAttributes
    {
        private bool bool_0;
        private bool bool_1;
        private byte byte_0;
        private System.Drawing.Color color_0;
        private int int_0;
        private int int_1;
        private float wtptaFwGqv;

        public ShadowAttributes()
        {
            this.bool_0 = true;
            this.int_0 = 3;
            this.byte_0 = 0xc0;
            this.wtptaFwGqv = 60f;
            this.bool_1 = false;
            this.color_0 = System.Drawing.Color.Black;
        }

        public ShadowAttributes(bool Enable, int Radius, int Distance, byte Angle)
        {
            this.bool_0 = true;
            this.int_0 = 3;
            this.byte_0 = 0xc0;
            this.wtptaFwGqv = 60f;
            this.bool_1 = false;
            this.color_0 = System.Drawing.Color.Black;
            this.Enable = Enable;
            this.Radius = Radius;
            this.Distance = Distance;
            this.Angle = Angle;
        }

        public ShadowAttributes(bool Enable, int Radius, int Distance, byte Angle, bool Hollow, System.Drawing.Color Color)
        {
            this.bool_0 = true;
            this.int_0 = 3;
            this.byte_0 = 0xc0;
            this.wtptaFwGqv = 60f;
            this.bool_1 = false;
            this.color_0 = System.Drawing.Color.Black;
            this.Enable = Enable;
            this.Radius = Radius;
            this.Distance = Distance;
            this.Angle = Angle;
            this.Hollow = Hollow;
            this.Color = Color;
        }

        [Description("阴影透明度"), Category("DSkinChart")]
        public byte Alpha
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        [Category("DSkinChart"), Description("阴影角度")]
        public float Angle
        {
            get
            {
                return this.wtptaFwGqv;
            }
            set
            {
                this.wtptaFwGqv = value;
            }
        }

        [Category("DSkinChart"), Description("阴影颜色")]
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

        [Description("Shadow Distance\n阴影距离"), Category("DSkinChart")]
        public int Distance
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

        [Description("Enable shadow of chart elements\n是否给图表元素加上投影效果"), Category("DSkinChart")]
        public bool Enable
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

        [Description("Enable Hollow Shadow(Only drop shadow of the eage)\n是否使用中空的投影，只投影图形的边框"), Category("DSkinChart")]
        public bool Hollow
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

        [Category("DSkinChart"), Description("Radius of shadow\n阴影半径")]
        public int Radius
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

