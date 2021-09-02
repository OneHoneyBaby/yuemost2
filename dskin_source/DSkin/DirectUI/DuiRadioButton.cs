namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class DuiRadioButton : DuiCheckBox
    {
        public DuiRadioButton()
        {
            this.InnerRectInflate = 4;
        }

        protected override void ClickToChangeState()
        {
            if (base.AutoCheck)
            {
                base.Checked = true;
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (((this.Parent != null) && (this.Parent is DuiBaseControl)) && base.Checked)
            {
                foreach (object obj2 in (this.Parent as DuiBaseControl).Controls)
                {
                    if ((obj2 != this) && (obj2 is DuiRadioButton))
                    {
                        ((DuiRadioButton) obj2).Checked = false;
                    }
                }
            }
        }

        protected override void OnDraw(Rectangle checkRect, Graphics g)
        {
            Color color;
            Pen pen;
            Color checkRectBackColorDisabled;
            SolidBrush brush;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (!base.Enabled)
            {
                checkRectBackColorDisabled = base.CheckRectBackColorDisabled;
            }
            else
            {
                switch (base.ControlState)
                {
                    case ControlStates.Hover:
                        checkRectBackColorDisabled = base.CheckRectBackColorHighLight;
                        goto Label_0048;

                    case ControlStates.Pressed:
                        checkRectBackColorDisabled = base.CheckRectBackColorPressed;
                        goto Label_0048;
                }
                checkRectBackColorDisabled = base.CheckRectBackColorNormal;
            }
        Label_0048:
            color = base.Enabled ? base.CheckRectColor : base.CheckRectColorDisabled;
            Color color1 = base.Enabled ? base.CheckFlagColor : base.CheckFlagColorDisabled;
            Rectangle rect = checkRect;
            rect.Width--;
            rect.Height--;
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                using (brush = new SolidBrush(checkRectBackColorDisabled))
                {
                    g.FillEllipse(brush, rect);
                }
            }
            using (pen = new Pen(color))
            {
                g.DrawEllipse(pen, checkRect);
            }
            if (base.ControlState == ControlStates.Hover)
            {
                using (pen = new Pen(Color.FromArgb(60, color)))
                {
                    pen.Width = 3f;
                    pen.Alignment = PenAlignment.Center;
                    g.DrawEllipse(pen, checkRect);
                }
            }
            if (this.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                checkRect.Inflate(-this.InnerRectInflate, -this.InnerRectInflate);
                using (brush = new SolidBrush(base.CheckFlagColor))
                {
                    g.FillEllipse(brush, checkRect);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override System.Windows.Forms.CheckState CheckState
        {
            get
            {
                return base.CheckState;
            }
            set
            {
                base.CheckState = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image IndeterminateHover
        {
            get
            {
                return base.IndeterminateHover;
            }
            set
            {
                base.IndeterminateHover = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Image IndeterminateNormal
        {
            get
            {
                return base.IndeterminateNormal;
            }
            set
            {
                base.IndeterminateNormal = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image IndeterminatePressed
        {
            get
            {
                return base.IndeterminatePressed;
            }
            set
            {
                base.IndeterminatePressed = value;
            }
        }

        public override int InnerRectInflate
        {
            get
            {
                return base.InnerRectInflate;
            }
            set
            {
                base.InnerRectInflate = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool ThreeState
        {
            get
            {
                return base.ThreeState;
            }
            set
            {
                base.ThreeState = value;
            }
        }
    }
}

