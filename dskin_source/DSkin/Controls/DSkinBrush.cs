namespace DSkin.Controls
{
    using DSkin.DirectUI.Transform;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;

    [ToolboxItem(false)]
    public abstract class DSkinBrush : Component
    {
        private System.Drawing.Brush brush_0;
        private DSkin.DirectUI.Transform.TransformCollection transformCollection_0;

        public DSkinBrush()
        {
        }

        public DSkinBrush(IContainer container) : this()
        {
            container.Add(this);
        }

        protected abstract System.Drawing.Brush CreateBrush();
        protected override void Dispose(bool disposing)
        {
            if (this.brush_0 != null)
            {
                this.brush_0.Dispose();
                this.brush_0 = null;
            }
            base.Dispose(disposing);
        }

        public void ReCreateBrush()
        {
            if (this.brush_0 != null)
            {
                this.brush_0.Dispose();
            }
            this.brush_0 = this.CreateBrush();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual System.Drawing.Brush Brush
        {
            get
            {
                if (this.brush_0 == null)
                {
                    this.brush_0 = this.CreateBrush();
                }
                PropertyInfo property = this.brush_0.GetType().GetProperty("Transform");
                if (property != null)
                {
                    property.SetValue(this.brush_0, this.TransformCollection.Transform, null);
                }
                return this.brush_0;
            }
            set
            {
                this.brush_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("变换操作集合，只对一部分有效果")]
        public DSkin.DirectUI.Transform.TransformCollection TransformCollection
        {
            get
            {
                if (this.transformCollection_0 == null)
                {
                    this.transformCollection_0 = new DSkin.DirectUI.Transform.TransformCollection();
                }
                return this.transformCollection_0;
            }
        }
    }
}

