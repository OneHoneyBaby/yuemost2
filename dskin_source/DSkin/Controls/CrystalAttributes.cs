namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CrystalAttributes
    {
        private bool bool_0;
        private bool bool_1;
        private DSkin.Controls.DSkinChart.Direction direction_0;
        private int int_0;

        public CrystalAttributes()
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.int_0 = 2;
            this.direction_0 = DSkin.Controls.DSkinChart.Direction.LeftRight;
        }

        public CrystalAttributes(bool Enable, bool CoverFull, int Contraction)
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.int_0 = 2;
            this.direction_0 = DSkin.Controls.DSkinChart.Direction.LeftRight;
            this.Enable = Enable;
            this.CoverFull = CoverFull;
            this.Contraction = Contraction;
        }

        [Category("DSkinChart"), Description("Pixes of crystal effect contraction\n高亮区域收缩像素")]
        public int Contraction
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

        [Description("Full Crystal or half crystal\n全高亮水晶效果，还是半高亮水晶效果"), Category("DSkinChart")]
        public bool CoverFull
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

        [Description("Crystal effect direction\n水晶效果的投射方向"), Category("DSkinChart")]
        public DSkin.Controls.DSkinChart.Direction Direction
        {
            get
            {
                return this.direction_0;
            }
            set
            {
                this.direction_0 = value;
            }
        }

        [Category("DSkinChart"), Description("Enable Crystal effect\n水晶效果")]
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
    }
}

