namespace DSkin.Html.Adapters
{
    using DSkin.DirectUI;
    using DSkin.Html;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class DuiControlAdapter : RControl
    {
        private readonly bool bool_0;
        private readonly DuiBaseControl duiBaseControl_0;

        public DuiControlAdapter(DuiBaseControl control, bool useGdiPlusTextRendering) : base(WinFormsAdapter.Instance)
        {
            ArgChecker.AssertArgNotNull(control, "DuiBaseControl");
            this.duiBaseControl_0 = control;
            this.bool_0 = useGdiPlusTextRendering;
        }

        public override void DoDragDropCopy(object dragDropData)
        {
            this.duiBaseControl_0.HostControl.DoDragDrop(dragDropData, DragDropEffects.Copy);
        }

        public override void Invalidate()
        {
            this.duiBaseControl_0.Invalidate();
        }

        public override void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth)
        {
            using (GraphicsAdapter adapter = new GraphicsAdapter(Graphics.FromHwnd(IntPtr.Zero), this.bool_0, true))
            {
                adapter.MeasureString(str, font, maxWidth, out charFit, out charFitWidth);
            }
        }

        public override void SetCursorDefault()
        {
            this.duiBaseControl_0.Cursor = Cursors.Default;
        }

        public override void SetCursorHand()
        {
            this.duiBaseControl_0.Cursor = Cursors.Hand;
        }

        public override void SetCursorIBeam()
        {
            this.duiBaseControl_0.Cursor = Cursors.IBeam;
        }

        public DuiBaseControl DuiControl
        {
            get
            {
                return this.duiBaseControl_0;
            }
        }

        public override bool LeftMouseButton
        {
            get
            {
                return ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.None);
            }
        }

        public override RPoint MouseLocation
        {
            get
            {
                Point locationToScreen = this.duiBaseControl_0.LocationToScreen;
                Point mousePosition = Control.MousePosition;
                return Utils.Convert((PointF) new Point(mousePosition.X - locationToScreen.X, mousePosition.Y - locationToScreen.Y));
            }
        }

        public override bool RightMouseButton
        {
            get
            {
                return ((Control.MouseButtons & MouseButtons.Right) != MouseButtons.None);
            }
        }
    }
}

