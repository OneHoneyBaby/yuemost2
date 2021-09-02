namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public class ToolButtonDesigner : ControlDesigner
    {
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            Pen pen = new Pen(Color.SteelBlue, 1f) {
                DashStyle = DashStyle.Dot
            };
            pe.Graphics.DrawRectangle(pen, 0, 0, pe.ClipRectangle.Width - 1, 20);
            pen.Dispose();
            base.OnPaintAdornments(pe);
        }

        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                return (base.SelectionRules & ~System.Windows.Forms.Design.SelectionRules.AllSizeable);
            }
        }
    }
}

