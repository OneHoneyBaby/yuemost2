namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.Forms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [Description("在Layered模式下承载普通控件")]
    public class ControlHost : ContainerControl
    {
        private bool bool_0 = false;
        private bool bool_1 = true;
        private bool bool_2 = true;
        private Color color_0 = Color.Empty;
        private ControlHostForm controlHostForm_0;
        private FormWindowState formWindowState_0;
        private Rectangle rectangle_0;
        private Timer timer_0;
        private Timer timer_1;

        private void controlHostForm_0_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(((this.controlHostForm_0.Owner == null) || (e.CloseReason == CloseReason.FormOwnerClosing)) || this.bool_0))
            {
                this.bool_0 = true;
                this.controlHostForm_0.Owner.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.controlHostForm_0 != null)
            {
                this.controlHostForm_0.Dispose();
                this.controlHostForm_0 = null;
            }
            if (this.timer_0 != null)
            {
                this.timer_0.Dispose();
                this.timer_0 = null;
            }
            if (this.timer_1 != null)
            {
                this.timer_1.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool method_0()
        {
            if (this.controlHostForm_0 == null)
            {
                EventHandler handler = null;
                DSkinForm f = base.FindForm() as DSkinForm;
                if ((!base.DesignMode && (f != null)) && f.IsLayeredWindowForm)
                {
                    this.controlHostForm_0 = new ControlHostForm();
                    this.controlHostForm_0.CanFocus = this.bool_2;
                    this.controlHostForm_0.TransparencyKey = this.color_0;
                    this.controlHostForm_0.BackColor = this.BackColor;
                    this.controlHostForm_0.BackgroundImage = this.BackgroundImage;
                    this.controlHostForm_0.BackgroundImageLayout = this.BackgroundImageLayout;
                    this.controlHostForm_0.Location = base.PointToScreen(new Point());
                    this.controlHostForm_0.Size = base.Size;
                    this.controlHostForm_0.FormClosing += new FormClosingEventHandler(this.controlHostForm_0_FormClosing);
                    this.controlHostForm_0.AcceptButton = f.AcceptButton;
                    this.controlHostForm_0.CancelButton = f.CancelButton;
                    this.controlHostForm_0.Padding = base.Padding;
                    f.LocationChanged += new EventHandler(this.method_5);
                    f.SizeChanged += new EventHandler(this.method_4);
                    f.Shown += new EventHandler(this.method_3);
                    List<Control> list = new List<Control>();
                    foreach (Control control in base.Controls)
                    {
                        list.Add(control);
                    }
                    base.SuspendLayout();
                    this.controlHostForm_0.SuspendLayout();
                    foreach (Control control in list)
                    {
                        this.controlHostForm_0.Controls.Add(control);
                    }
                    this.controlHostForm_0.ResumeLayout(false);
                    base.ResumeLayout(false);
                    this.controlHostForm_0.Owner = f;
                    this.controlHostForm_0.Show();
                    Timer timer = new Timer {
                        Interval = 20,
                        Enabled = true
                    };
                    this.timer_0 = timer;
                    if (handler == null)
                    {
                        <>c__DisplayClass6 class2;
                        handler = new EventHandler(class2.<GetForm>b__4);
                    }
                    this.timer_0.Tick += handler;
                    return true;
                }
            }
            return false;
        }

        private void method_1()
        {
            Rectangle rectangle = this.method_2(this, base.ClientRectangle);
            if (this.rectangle_0 != rectangle)
            {
                this.rectangle_0 = rectangle;
                if ((this.rectangle_0.Width < 1) || (this.rectangle_0.Height < 1))
                {
                    this.controlHostForm_0.Visible = false;
                }
                else
                {
                    this.controlHostForm_0.Visible = true;
                    this.controlHostForm_0.Region = new Region(this.rectangle_0);
                }
            }
        }

        private Rectangle method_2(Control control_0, Rectangle rectangle_1)
        {
            Rectangle clientRectangle;
            if (control_0.Parent != null)
            {
                clientRectangle = this.method_2(control_0.Parent, control_0.Bounds);
            }
            else
            {
                clientRectangle = control_0.ClientRectangle;
            }
            clientRectangle.Intersect(rectangle_1);
            clientRectangle.Offset(-rectangle_1.Left, -rectangle_1.Top);
            return clientRectangle;
        }

        private void method_3(object sender, EventArgs e)
        {
            if ((this.controlHostForm_0 != null) && (base.FindForm() != null))
            {
                Form owner = this.controlHostForm_0.Owner;
                if ((owner.WindowState != FormWindowState.Minimized) && (((owner.FormBorderStyle != FormBorderStyle.None) && (owner.FormBorderStyle != FormBorderStyle.FixedToolWindow)) && (owner.FormBorderStyle != FormBorderStyle.SizableToolWindow)))
                {
                    <>c__DisplayClassa classa;
                    this.bool_1 = false;
                    Timer timer = new Timer {
                        Interval = 300,
                        Enabled = true
                    };
                    timer.Tick += new EventHandler(classa.<f_Shown>b__9);
                }
            }
        }

        private void method_4(object sender, EventArgs e)
        {
            if ((this.controlHostForm_0 != null) && (base.FindForm() != null))
            {
                Form owner = this.controlHostForm_0.Owner;
                if (((this.formWindowState_0 == FormWindowState.Minimized) && (owner.WindowState != FormWindowState.Minimized)) && (((owner.FormBorderStyle != FormBorderStyle.None) && (owner.FormBorderStyle != FormBorderStyle.FixedToolWindow)) && (owner.FormBorderStyle != FormBorderStyle.SizableToolWindow)))
                {
                    <>c__DisplayClassf classf;
                    EventHandler handler = null;
                    this.bool_1 = false;
                    Timer timer = new Timer {
                        Interval = 300,
                        Enabled = true
                    };
                    handler = new EventHandler(classf.<f_SizeChanged>b__d);
                    timer.Tick += handler;
                }
                this.formWindowState_0 = owner.WindowState;
                this.method_1();
            }
        }

        private void method_5(object sender, EventArgs e)
        {
            if ((this.controlHostForm_0 != null) && (base.FindForm() != null))
            {
                this.controlHostForm_0.Location = base.PointToScreen(new Point());
            }
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            if (this.method_0())
            {
                this.timer_1.Dispose();
                this.timer_1 = null;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (this.controlHostForm_0 != null)
            {
                this.controlHostForm_0.BackColor = this.BackColor;
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            if (this.controlHostForm_0 != null)
            {
                this.controlHostForm_0.BackgroundImage = this.BackgroundImage;
            }
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            base.OnBackgroundImageLayoutChanged(e);
            if (this.controlHostForm_0 != null)
            {
                this.controlHostForm_0.BackgroundImageLayout = this.BackgroundImageLayout;
            }
        }

        protected override void OnCreateControl()
        {
            EventHandler handler = null;
            base.OnCreateControl();
            this.rectangle_0 = new Rectangle(0, 0, base.Width, base.Height);
            if (!base.DesignMode && !this.method_0())
            {
                Timer timer = new Timer {
                    Interval = 20,
                    Enabled = true
                };
                this.timer_1 = timer;
                if (handler == null)
                {
                    handler = new EventHandler(this.method_6);
                }
                this.timer_1.Tick += handler;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if ((this.controlHostForm_0 != null) && !(((base.Width <= 0) || (base.Height <= 0)) || this.controlHostForm_0.IsDisposed))
            {
                this.controlHostForm_0.DrawToBitmap(e.Graphics);
            }
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.controlHostForm_0 != null)
            {
                this.controlHostForm_0.Size = base.Size;
            }
        }

        [DefaultValue(true), Description("是否可以接受输入焦点"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("DSkin")]
        public bool CanFocus
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
                if (this.controlHostForm_0 != null)
                {
                    this.controlHostForm_0.CanFocus = value;
                }
            }
        }

        public Control.ControlCollection Controls
        {
            get
            {
                if (!((this.controlHostForm_0 == null) || this.controlHostForm_0.IsDisposed))
                {
                    return this.controlHostForm_0.Controls;
                }
                return base.Controls;
            }
        }

        [Browsable(false)]
        public ControlHostForm HostForm
        {
            get
            {
                return this.controlHostForm_0;
            }
        }

        [DefaultValue(typeof(Color), "Empty"), Category("DSkin"), Description("表示透明区域的颜色")]
        public Color TransparencyKey
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_0 = value;
                    if (this.controlHostForm_0 != null)
                    {
                        this.controlHostForm_0.TransparencyKey = this.color_0;
                    }
                }
            }
        }
    }
}

