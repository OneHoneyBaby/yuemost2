namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinTabItem : DuiButton
    {
        private bool bool_35 = false;
        [CompilerGenerated]
        private DSkinTabBar dskinTabBar_0;
        private System.Windows.Forms.TabPage tabPage_0;

        public DSkinTabItem()
        {
            this.ShowButtonBorder = false;
            this.BaseColor = Color.Transparent;
            this.AdaptImage = false;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!this.bool_35)
            {
                base.ControlState = ControlStates.Hover;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.bool_35)
            {
                base.ControlState = ControlStates.Normal;
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!this.bool_35)
            {
                base.ControlState = ControlStates.Hover;
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            base.OnPrePaint(e);
            Graphics graphics = e.Graphics;
        }

        public void SetSelect()
        {
            if (this.DSkinTabBar_0 != null)
            {
                this.DSkinTabBar_0.SetSelect(this);
            }
        }

        [DefaultValue(false)]
        public override bool AdaptImage
        {
            get
            {
                return base.AdaptImage;
            }
            set
            {
                base.AdaptImage = value;
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BaseColor
        {
            get
            {
                return base.BaseColor;
            }
            set
            {
                base.BaseColor = value;
            }
        }

        public DSkinTabBar DSkinTabBar_0
        {
            [CompilerGenerated]
            get
            {
                return this.dskinTabBar_0;
            }
            [CompilerGenerated]
            internal set
            {
                this.dskinTabBar_0 = value;
            }
        }

        public override bool MouseChangeControlState
        {
            get
            {
                return false;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Selected
        {
            get
            {
                return this.bool_35;
            }
            set
            {
                if (this.bool_35 != value)
                {
                    this.bool_35 = value;
                    if (value)
                    {
                        base.ControlState = ControlStates.Pressed;
                    }
                    else
                    {
                        base.ControlState = ControlStates.Normal;
                    }
                }
            }
        }

        [DefaultValue(false)]
        public override bool ShowButtonBorder
        {
            get
            {
                return base.ShowButtonBorder;
            }
            set
            {
                base.ShowButtonBorder = value;
            }
        }

        [Description("关联的TabPage")]
        public System.Windows.Forms.TabPage TabPage
        {
            get
            {
                return this.tabPage_0;
            }
            set
            {
                this.tabPage_0 = value;
            }
        }
    }
}

