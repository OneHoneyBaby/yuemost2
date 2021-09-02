namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class DuiLayoutEngine
    {
        internal bool bool_0 = false;
        private bool bool_1 = false;
        internal bool bool_2 = false;
        internal double double_0 = 0.0;
        internal double double_1 = 0.0;
        private DuiBaseControl duiBaseControl_0;
        private IDuiContainer iduiContainer_0;
        private Size size_0 = new Size(100, 100);

        public DuiLayoutEngine(DuiBaseControl owner)
        {
            this.duiBaseControl_0 = owner;
            this.duiBaseControl_0.SizeChanged += new EventHandler(this.duiBaseControl_0_SizeChanged);
            this.duiBaseControl_0.DockChanged += new EventHandler(this.duiBaseControl_0_DockChanged);
            this.duiBaseControl_0.AnchorChanged += new EventHandler(this.duiBaseControl_0_AnchorChanged);
            this.duiBaseControl_0.ControlAdded += new EventHandler<DuiControlEventArgs>(this.method_2);
            this.duiBaseControl_0.Move += new EventHandler(this.duiBaseControl_0_Move);
            this.duiBaseControl_0.StartPaint += new EventHandler(this.duiBaseControl_0_StartPaint);
            this.duiBaseControl_0.MarginChanged += new EventHandler(this.duiBaseControl_0_MarginChanged);
        }

        private void duiBaseControl_0_AnchorChanged(object sender, EventArgs e)
        {
            this.duiBaseControl_0.Dock = DockStyle.None;
            this.duiBaseControl_0.InheritanceSize = new SizeF();
            this.method_1();
        }

        private void duiBaseControl_0_DockChanged(object sender, EventArgs e)
        {
            if ((this.duiBaseControl_0.parent != null) && (this.duiBaseControl_0.parent is DuiBaseControl))
            {
                ((DuiBaseControl) this.duiBaseControl_0.parent).LayoutEngine.ManagedLayout();
            }
            if (this.duiBaseControl_0.Dock != DockStyle.None)
            {
                this.duiBaseControl_0.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                this.duiBaseControl_0.InheritanceSize = new SizeF();
                this.duiBaseControl_0.DesignModeCanMove = false;
                this.duiBaseControl_0.DesignModeCanResize = false;
            }
            else
            {
                this.duiBaseControl_0.DesignModeCanMove = true;
                this.duiBaseControl_0.DesignModeCanResize = true;
            }
        }

        private void duiBaseControl_0_MarginChanged(object sender, EventArgs e)
        {
            if (this.duiBaseControl_0.Parent != null)
            {
                this.method_0();
            }
        }

        private void duiBaseControl_0_Move(object sender, EventArgs e)
        {
            this.method_1();
        }

        private void duiBaseControl_0_SizeChanged(object sender, EventArgs e)
        {
            this.method_1();
            this.Layout();
            if (this.bool_1)
            {
                this.size_0 = this.duiBaseControl_0.Size;
            }
            this.method_0();
        }

        private void duiBaseControl_0_StartPaint(object sender, EventArgs e)
        {
            if (this.iduiContainer_0 == null)
            {
                this.iduiContainer_0 = this.duiBaseControl_0.parent;
            }
            DuiBaseControl control = this.iduiContainer_0 as DuiBaseControl;
            if (control != null)
            {
                if (this.duiBaseControl_0.InheritanceSize.Width > 0f)
                {
                    this.duiBaseControl_0.Width = (int) (this.duiBaseControl_0.InheritanceSize.Width * control.Width);
                }
                if (this.duiBaseControl_0.InheritanceSize.Height > 0f)
                {
                    this.duiBaseControl_0.Height = (int) (this.duiBaseControl_0.InheritanceSize.Height * control.Height);
                }
            }
        }

        public void Layout()
        {
            if (!this.bool_1)
            {
                Rectangle rectangle = new Rectangle(0, 0, this.duiBaseControl_0.Width, this.duiBaseControl_0.Height);
                foreach (DuiBaseControl control in this.duiBaseControl_0.Controls)
                {
                    rectangle = this.method_3(control, rectangle);
                    this.method_4(control);
                }
                this.size_0 = this.duiBaseControl_0.Size;
                this.duiBaseControl_0.method_10();
            }
        }

        public void ManagedLayout()
        {
            if (!((this.duiBaseControl_0.Controls.Count <= 0) || this.bool_1))
            {
                this.duiBaseControl_0.ManagedTask(new Action(this, (IntPtr) this.Layout));
            }
        }

        private void method_0()
        {
            if (this.duiBaseControl_0.Dock != DockStyle.None)
            {
                DuiBaseControl parent = this.duiBaseControl_0.Parent as DuiBaseControl;
                if ((parent != null) && (parent.LayoutEngine != null))
                {
                    parent.LayoutEngine.ManagedLayout();
                }
                else
                {
                    IDuiDesigner designer = this.duiBaseControl_0.parent as IDuiDesigner;
                    if (designer != null)
                    {
                        designer.InnerDuiControl.LayoutEngine.ManagedLayout();
                    }
                }
            }
        }

        private void method_1()
        {
            if (!((this.duiBaseControl_0.Anchor == (AnchorStyles.Left | AnchorStyles.Top)) || this.duiBaseControl_0.LayoutEngine.bool_0))
            {
                DuiBaseControl parent = this.duiBaseControl_0.Parent as DuiBaseControl;
                if (parent != null)
                {
                    this.double_0 = (1.0 * ((this.duiBaseControl_0.Width / 2) + this.duiBaseControl_0.Left)) / ((double) parent.Width);
                    this.double_1 = (1.0 * ((this.duiBaseControl_0.Height / 2) + this.duiBaseControl_0.Top)) / ((double) parent.Height);
                }
            }
        }

        private void method_2(object sender, DuiControlEventArgs e)
        {
            if ((e.Control.Anchor != (AnchorStyles.Left | AnchorStyles.Top)) && !this.bool_1)
            {
                e.Control.LayoutEngine.double_0 = (1.0 * ((e.Control.Width / 2) + e.Control.Left)) / ((double) this.duiBaseControl_0.Width);
                e.Control.LayoutEngine.double_1 = (1.0 * ((e.Control.Height / 2) + e.Control.Top)) / ((double) this.duiBaseControl_0.Height);
            }
        }

        private Rectangle method_3(DuiBaseControl duiBaseControl_1, Rectangle rectangle_0)
        {
            switch (duiBaseControl_1.Dock)
            {
                case DockStyle.Top:
                    duiBaseControl_1.ClientRectangle = new Rectangle(rectangle_0.X + duiBaseControl_1.Margin.Left, rectangle_0.Y + duiBaseControl_1.Margin.Top, duiBaseControl_1.AutoSize ? duiBaseControl_1.Width : (rectangle_0.Width - duiBaseControl_1.Margin.Horizontal), duiBaseControl_1.Height);
                    return new Rectangle(rectangle_0.X, (rectangle_0.Y + duiBaseControl_1.Height) + duiBaseControl_1.Margin.Vertical, rectangle_0.Width, (rectangle_0.Height - duiBaseControl_1.Height) - duiBaseControl_1.Margin.Vertical);

                case DockStyle.Bottom:
                    duiBaseControl_1.ClientRectangle = new Rectangle(rectangle_0.X + duiBaseControl_1.Margin.Left, ((rectangle_0.Y + rectangle_0.Height) - duiBaseControl_1.Height) - duiBaseControl_1.Margin.Bottom, duiBaseControl_1.AutoSize ? duiBaseControl_1.Width : (rectangle_0.Width - duiBaseControl_1.Margin.Horizontal), duiBaseControl_1.Height);
                    return new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, (rectangle_0.Height - duiBaseControl_1.Height) - duiBaseControl_1.Margin.Vertical);

                case DockStyle.Left:
                    duiBaseControl_1.ClientRectangle = new Rectangle(rectangle_0.X + duiBaseControl_1.Margin.Left, rectangle_0.Y + duiBaseControl_1.Margin.Top, duiBaseControl_1.Width, duiBaseControl_1.AutoSize ? duiBaseControl_1.Height : (rectangle_0.Height - duiBaseControl_1.Margin.Vertical));
                    return new Rectangle((rectangle_0.X + duiBaseControl_1.Width) + duiBaseControl_1.Margin.Horizontal, rectangle_0.Y, ((rectangle_0.Width - rectangle_0.X) - duiBaseControl_1.Width) + duiBaseControl_1.Margin.Horizontal, rectangle_0.Height);

                case DockStyle.Right:
                    duiBaseControl_1.ClientRectangle = new Rectangle(((rectangle_0.Width - duiBaseControl_1.Width) - duiBaseControl_1.Margin.Right) + rectangle_0.X, duiBaseControl_1.Margin.Top + rectangle_0.Y, duiBaseControl_1.Width, duiBaseControl_1.AutoSize ? duiBaseControl_1.Height : (rectangle_0.Height - duiBaseControl_1.Margin.Vertical));
                    return new Rectangle(rectangle_0.X, rectangle_0.Y, (rectangle_0.Width - duiBaseControl_1.Width) - duiBaseControl_1.Margin.Horizontal, rectangle_0.Height);

                case DockStyle.Fill:
                    duiBaseControl_1.ClientRectangle = new Rectangle(rectangle_0.X + duiBaseControl_1.Margin.Left, rectangle_0.Y + duiBaseControl_1.Margin.Top, duiBaseControl_1.AutoSize ? duiBaseControl_1.Width : (rectangle_0.Width - duiBaseControl_1.Margin.Horizontal), duiBaseControl_1.AutoSize ? duiBaseControl_1.Height : (rectangle_0.Height - duiBaseControl_1.Margin.Vertical));
                    return rectangle_0;
            }
            return rectangle_0;
        }

        private void method_4(DuiBaseControl duiBaseControl_1)
        {
            if (((duiBaseControl_1.Site == null) || !duiBaseControl_1.Site.DesignMode) && (duiBaseControl_1.Anchor != (AnchorStyles.Left | AnchorStyles.Top)))
            {
                Padding padding = new Padding(duiBaseControl_1.Left, duiBaseControl_1.Top, (this.size_0.Width - duiBaseControl_1.Left) - duiBaseControl_1.Width, (this.size_0.Height - duiBaseControl_1.Top) - duiBaseControl_1.Height);
                Rectangle rectangle = new Rectangle(((int) (this.duiBaseControl_0.Width * duiBaseControl_1.LayoutEngine.double_0)) - (duiBaseControl_1.Width / 2), ((int) (this.duiBaseControl_0.Height * duiBaseControl_1.LayoutEngine.double_1)) - (duiBaseControl_1.Height / 2), duiBaseControl_1.Width, duiBaseControl_1.Height);
                if ((duiBaseControl_1.Anchor & AnchorStyles.Top) == AnchorStyles.Top)
                {
                    rectangle.Y = padding.Top;
                }
                if ((duiBaseControl_1.Anchor & AnchorStyles.Left) == AnchorStyles.Left)
                {
                    rectangle.X = padding.Left;
                }
                if ((duiBaseControl_1.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
                {
                    if ((duiBaseControl_1.Anchor & AnchorStyles.Left) == AnchorStyles.Left)
                    {
                        rectangle.Width = (this.duiBaseControl_0.Width - rectangle.X) - padding.Right;
                    }
                    else
                    {
                        rectangle.X = (this.duiBaseControl_0.Width - rectangle.Width) - padding.Right;
                    }
                }
                if ((duiBaseControl_1.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                {
                    if ((duiBaseControl_1.Anchor & AnchorStyles.Top) == AnchorStyles.Top)
                    {
                        rectangle.Height = (this.duiBaseControl_0.Height - rectangle.Y) - padding.Bottom;
                    }
                    else
                    {
                        rectangle.Y = (this.duiBaseControl_0.Height - rectangle.Height) - padding.Bottom;
                    }
                }
                duiBaseControl_1.LayoutEngine.bool_0 = true;
                duiBaseControl_1.ClientRectangle = rectangle;
                duiBaseControl_1.LayoutEngine.bool_0 = false;
            }
        }

        public bool IsSuspendLayout
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    if (!value)
                    {
                        foreach (DuiBaseControl control in this.duiBaseControl_0.Controls)
                        {
                            control.LayoutEngine.method_1();
                        }
                    }
                }
            }
        }

        public object Parent
        {
            get
            {
                return this.iduiContainer_0;
            }
            set
            {
                this.iduiContainer_0 = (IDuiContainer) value;
            }
        }
    }
}

