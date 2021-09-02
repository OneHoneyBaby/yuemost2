namespace DSkin.DirectUI.Transform
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Drawing2D;

    public class ShearTransform : DSkin.DirectUI.Transform.Transform
    {
        private float float_0 = 0f;
        private float float_1 = 0f;

        public override void DoTransform(Matrix m)
        {
            m.Shear(this.float_0, this.float_1, MatrixOrder.Append);
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return string.Concat(new object[] { "切变变换：X:", this.float_0, "，Y:", this.float_1 });
            }
        }

        [DefaultValue(0)]
        public float ShearX
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

        [DefaultValue(0)]
        public float ShearY
        {
            get
            {
                return this.float_1;
            }
            set
            {
                this.float_1 = value;
            }
        }
    }
}

