namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class RichTxtControl : UserControl
    {
        private IContainer icontainer_0 = null;

        public RichTxtControl()
        {
            this.method_0();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.CacheText | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.Opaque, false);
        }

        public virtual void CtrlMouseDown(GClass4 richTextBox, Point newP, MouseEventArgs e)
        {
        }

        public virtual void CtrlMouseMove(GClass4 richTextBox, Point newP, MouseEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void method_0()
        {
            this.icontainer_0 = new Container();
            base.AutoScaleMode = AutoScaleMode.Font;
        }
    }
}

