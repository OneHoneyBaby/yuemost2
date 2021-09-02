namespace DSkin.DirectUI.Transform
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Drawing2D;

    public class RotateTransform : DSkin.DirectUI.Transform.Transform
    {
        private float float_0 = 0f;

        public override void DoTransform(Matrix m)
        {
            m.Rotate(this.float_0, MatrixOrder.Append);
        }

        [DefaultValue(0)]
        public float Angle
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

        [Browsable(false)]
        public string Name
        {
            get
            {
                return ("顺时针旋转变换：" + this.float_0 + "度");
            }
        }
    }
}

