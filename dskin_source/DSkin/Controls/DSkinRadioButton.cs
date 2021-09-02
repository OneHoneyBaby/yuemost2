namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(RadioButton))]
    public class DSkinRadioButton : DSkinCheckBox
    {
        private DuiRadioButton duiRadioButton_0;

        public DSkinRadioButton()
        {
            this.duiRadioButton_0 = (DuiRadioButton) base.InnerDuiControl;
            this.duiRadioButton_0.CheckedChanged += new EventHandler(this.duiRadioButton_0_CheckedChanged);
        }

        private void duiRadioButton_0_CheckedChanged(object sender, EventArgs e)
        {
            if ((base.Parent != null) && base.Checked)
            {
                foreach (Control control in base.Parent.Controls)
                {
                    if ((control != this) && (control is DSkinRadioButton))
                    {
                        ((DSkinRadioButton) control).Checked = false;
                    }
                }
            }
            this.OnCheckedChanged(EventArgs.Empty);
        }

        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
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

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiRadioButton();
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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        [Description("设置被选中的时候内部园的缩进量")]
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

