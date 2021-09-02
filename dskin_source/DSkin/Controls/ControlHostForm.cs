namespace DSkin.Controls
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ControlHostForm : Form
    {
        private bool bool_0 = true;
        private IContainer icontainer_0 = null;

        public ControlHostForm()
        {
            this.InitializeComponent();
            this.method_0();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x105);
            base.ControlBox = false;
            base.FormBorderStyle = FormBorderStyle.None;
            this.MinimumSize = new Size(1, 1);
            base.Name = "ControlHostForm";
            base.Opacity = 0.0;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "ControlHostForm";
            base.ResumeLayout(false);
        }

        private void method_0()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }

        protected override void WndProc(ref Message m)
        {
            if (!this.bool_0 && !base.DesignMode)
            {
                if (m.Msg == 0x21)
                {
                    m.Result = new IntPtr(3);
                    return;
                }
                if ((m.Msg == 0x86) && ((((int) m.WParam) & 0xffff) != 0))
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        DSkin.NativeMethods.SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        DSkin.NativeMethods.SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanFocus
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }
    }
}

