namespace DSkin.Html.Adapters
{
    using DSkin.Html;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class ControlAdapter : RControl
    {
        private readonly bool bool_0;
        private readonly System.Windows.Forms.Control control_0;

        public ControlAdapter(System.Windows.Forms.Control control, bool useGdiPlusTextRendering) : base(WinFormsAdapter.Instance)
        {
            ArgChecker.AssertArgNotNull(control, "control");
            this.control_0 = control;
            this.bool_0 = useGdiPlusTextRendering;
        }

        public override void DoDragDropCopy(object dragDropData)
        {
            this.control_0.DoDragDrop(dragDropData, DragDropEffects.Copy);
        }

        public override void Invalidate()
        {
            this.control_0.Invalidate();
        }

        public override void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth)
        {
            using (GraphicsAdapter adapter = new GraphicsAdapter(this.control_0.CreateGraphics(), this.bool_0, true))
            {
                adapter.MeasureString(str, font, maxWidth, out charFit, out charFitWidth);
            }
        }

        public override void SetCursorDefault()
        {
            this.control_0.Cursor = Cursors.Default;
        }

        public override void SetCursorHand()
        {
            this.control_0.Cursor = Cursors.Hand;
        }

        public override void SetCursorIBeam()
        {
            this.control_0.Cursor = Cursors.IBeam;
        }

        public System.Windows.Forms.Control Control
        {
            get
            {
                return this.control_0;
            }
        }

        public override bool LeftMouseButton
        {
            get
            {
                return ((System.Windows.Forms.Control.MouseButtons & MouseButtons.Left) != MouseButtons.None);
            }
        }

        public override RPoint MouseLocation
        {
            get
            {
                return Utils.Convert((PointF) this.control_0.PointToClient(System.Windows.Forms.Control.MousePosition));
            }
        }

        public override bool RightMouseButton
        {
            get
            {
                return ((System.Windows.Forms.Control.MouseButtons & MouseButtons.Right) != MouseButtons.None);
            }
        }
    }
}

