namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    public class DuiPieItem
    {
        private System.Drawing.Brush brush_0;
        private System.Drawing.Color color_0 = System.Drawing.Color.White;
        private int int_0 = 30;

        public int Angle
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

        public System.Drawing.Brush Brush
        {
            get
            {
                return this.brush_0;
            }
            set
            {
                this.brush_0 = value;
            }
        }

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

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public string Name
        {
            get
            {
                return ("角度：" + this.int_0);
            }
        }
    }
}

