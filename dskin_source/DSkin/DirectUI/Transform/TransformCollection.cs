namespace DSkin.DirectUI.Transform
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;

    [Editor(typeof(Class59), typeof(UITypeEditor))]
    public class TransformCollection : Collection<DSkin.DirectUI.Transform.Transform>, IDisposable
    {
        private Matrix matrix_0 = new Matrix();

        public void Dispose()
        {
            if (this.matrix_0 != null)
            {
                this.matrix_0.Dispose();
                this.matrix_0 = null;
            }
        }

        private void method_0()
        {
            this.matrix_0.Reset();
            foreach (DSkin.DirectUI.Transform.Transform transform in this)
            {
                transform.DoTransform(this.matrix_0);
            }
        }

        protected override void OnItemAdded(DSkin.DirectUI.Transform.Transform e, int index)
        {
            base.OnItemAdded(e, index);
            this.method_0();
        }

        protected override void OnItemRemoved(DSkin.DirectUI.Transform.Transform e, int index)
        {
            base.OnItemRemoved(e, index);
            this.method_0();
        }

        public Matrix Transform
        {
            get
            {
                return this.matrix_0;
            }
        }
    }
}

