namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    public class BlendColor
    {
        private System.Drawing.Color color_0 = System.Drawing.Color.White;
        private float float_0 = 1f;

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

        [Browsable(false)]
        public string Name
        {
            get
            {
                return string.Concat(new object[] { "位置：", this.float_0, " ", this.color_0.ToString() });
            }
        }

        public float Position
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
    }
}

