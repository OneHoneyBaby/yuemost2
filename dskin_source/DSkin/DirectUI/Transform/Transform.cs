namespace DSkin.DirectUI.Transform
{
    using System;
    using System.Drawing.Drawing2D;

    public abstract class Transform
    {
        protected Transform()
        {
        }

        public abstract void DoTransform(Matrix m);
    }
}

