namespace DSkin.DirectUI.Transform
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Drawing2D;

    public class ScaleTransform : DSkin.DirectUI.Transform.Transform
    {
        private float float_0 = 1f;
        private float float_1 = 1f;

        public override void DoTransform(Matrix m)
        {
            m.Scale(this.float_0, this.float_1, MatrixOrder.Append);
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return string.Concat(new object[] { "缩放变换：X:", this.float_0, "，Y:", this.float_1 });
            }
        }

        [DefaultValue(1)]
        public float ScaleX
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

        [DefaultValue(1)]
        public float ScaleY
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

