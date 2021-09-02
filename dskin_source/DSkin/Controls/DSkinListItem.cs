namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class DSkinListItem : DSkinUserControl
    {
        public DSkinBaseControl DBaseControl;
        private IContainer icontainer_0 = null;

        public DSkinListItem()
        {
            this.InitializeComponent();
        }

        private void DBaseControl_SizeChanged(object sender, EventArgs e)
        {
            if (base.DesignMode)
            {
                base.Invalidate();
            }
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
            this.DBaseControl = new DSkinBaseControl();
            base.SuspendLayout();
            this.DBaseControl.BackColor = Color.FromArgb(0xc0, 0xc0, 0xff);
            this.DBaseControl.Borders.AllColor = Color.Empty;
            this.DBaseControl.Borders.BottomColor = Color.Empty;
            this.DBaseControl.Borders.LeftColor = Color.Empty;
            this.DBaseControl.Borders.RightColor = Color.Empty;
            this.DBaseControl.Borders.TopColor = Color.Empty;
            this.DBaseControl.Location = new Point(30, 30);
            this.DBaseControl.Margin = new Padding(0);
            this.DBaseControl.Name = "DBaseControl";
            this.DBaseControl.Size = new Size(200, 100);
            this.DBaseControl.TabIndex = 0;
            this.DBaseControl.SizeChanged += new EventHandler(this.DBaseControl_SizeChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0xc0, 0xff, 0xff);
            base.Borders.AllColor = Color.Empty;
            base.Borders.BottomColor = Color.Empty;
            base.Borders.LeftColor = Color.Empty;
            base.Borders.RightColor = Color.Empty;
            base.Borders.TopColor = Color.Empty;
            base.Controls.Add(this.DBaseControl);
            base.Margin = new Padding(0);
            base.Name = "DSkinListItem";
            base.Padding = new Padding(30);
            base.Size = new Size(260, 160);
            base.ResumeLayout(false);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (base.DesignMode)
            {
                if (e.Control is DSkinBaseControl)
                {
                    e.Control.Margin = new Padding(0, 0, 0, 0);
                    e.Control.SizeChanged += new EventHandler(this.DBaseControl_SizeChanged);
                }
                else
                {
                    base.Controls.Remove(e.Control);
                    MessageBox.Show("请勿添加非DSkinBaseControl的控件！");
                }
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (base.DesignMode)
            {
                base.Invalidate();
            }
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            if (base.DesignMode)
            {
                int num;
                SizeF ef;
                Point point;
                Point point2;
                Graphics graphics = e.Graphics;
                Color color = Color.FromArgb(220, 220, 220);
                Color color2 = Color.FromArgb(0xff, 0xff, 0xff);
                Bitmap image = new Bitmap(20, 20);
                using (Graphics graphics2 = Graphics.FromImage(image))
                {
                    graphics2.FillRectangle(new SolidBrush(color), 0, 0, 10, 10);
                    graphics2.FillRectangle(new SolidBrush(color2), 10, 0, 10, 10);
                    graphics2.FillRectangle(new SolidBrush(color2), 0, 10, 10, 10);
                    graphics2.FillRectangle(new SolidBrush(color), 10, 10, 10, 10);
                }
                graphics.FillRectangle(new TextureBrush(image), base.ClientRectangle);
                image.Dispose();
                image = null;
                int width = base.Width;
                int height = base.Height;
                Font font = new Font("Arial", 7f, FontStyle.Bold);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), 0, 0, base.Width, 20);
                graphics.DrawLine(new Pen(Color.Blue), new Point(0, 20), new Point(base.Width, 20));
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), 0, 0, 20, base.Height);
                graphics.DrawLine(new Pen(Color.Blue), new Point(20, 0), new Point(20, base.Height));
                for (num = 0; num <= width; num++)
                {
                    ef = graphics.MeasureString(Convert.ToString((int) (num / 10)), font);
                    int x = 30 + (10 * num);
                    point = new Point(x, 20);
                    point2 = new Point(x, 15);
                    if ((num % 5) == 0)
                    {
                        point2 = new Point(x, 12);
                    }
                    if ((num % 10) == 0)
                    {
                        point2 = new Point(x, 7);
                    }
                    graphics.DrawLine(Pens.Blue, point, point2);
                    if ((num % 10) == 0)
                    {
                        graphics.DrawString(Convert.ToString((int) (num * 10)), font, Brushes.Red, new PointF(x - (ef.Width / 2f), 0f));
                    }
                    else if ((num % 5) == 0)
                    {
                        graphics.DrawString(Convert.ToString((int) (num * 10)), font, Brushes.Red, new PointF(x - (ef.Width / 2f), 0f));
                    }
                }
                for (num = 0; num <= height; num++)
                {
                    ef = graphics.MeasureString(Convert.ToString((int) (num / 10)), font);
                    int y = 30 + (10 * num);
                    point = new Point(20, y);
                    point2 = new Point(15, y);
                    if ((num % 5) == 0)
                    {
                        point2 = new Point(12, y);
                    }
                    if ((num % 10) == 0)
                    {
                        point2 = new Point(7, y);
                    }
                    graphics.DrawLine(Pens.Blue, point, point2);
                    RotateText text = new RotateText(e.Graphics);
                    StringFormat format = new StringFormat();
                    if ((num % 10) == 0)
                    {
                        text.DrawString(Convert.ToString((int) (num * 10)), font, Brushes.Red, new PointF(0f, (10 + y) - (ef.Height / 2f)), format, 270f);
                    }
                    else if ((num % 5) == 0)
                    {
                        text.DrawString(Convert.ToString((int) (num * 10)), font, Brushes.Red, new PointF(0f, (10 + y) - (ef.Height / 2f)), format, 270f);
                    }
                }
                Font font2 = new Font("Arial", 7f, FontStyle.Bold);
                int num5 = 0;
                foreach (Control control in base.Controls)
                {
                    if (control is DSkinBaseControl)
                    {
                        string str = control.Width.ToString();
                        string str2 = control.Height.ToString();
                        SizeF ef2 = graphics.MeasureString(str, font2);
                        graphics.MeasureString(str2, font2);
                        graphics.DrawString(str, font2, Brushes.Blue, control.Left + ((control.Width - ef2.Width) / 2f), (float) control.Bottom);
                        graphics.DrawString(str2, font2, Brushes.Blue, (float) control.Right, control.Top + ((control.Height - ef2.Height) / 2f));
                        if (control.BackColor == Color.Transparent)
                        {
                            Pen pen = new Pen(Color.Blue, 1f) {
                                DashStyle = DashStyle.Custom,
                                DashPattern = new float[] { 5f, 5f }
                            };
                            graphics.DrawRectangle(pen, (int) (control.Left - 1), (int) (control.Top - 1), (int) (control.Width + 1), (int) (control.Height + 1));
                        }
                        num5++;
                    }
                }
                Font font3 = new Font("Arial", 8f, FontStyle.Bold);
                string str3 = string.Format("ItemCount: {0}", num5);
                SizeF ef3 = graphics.MeasureString(str3, font3);
                graphics.DrawString(str3, font3, new SolidBrush(Color.Blue), (float) ((base.Width - ef3.Width) - 2f), (float) ((base.Height - ef3.Height) - 2f));
                graphics.DrawRectangle(new Pen(Color.Blue), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            }
            base.OnLayeredPaint(e);
        }

        public DuiBaseControl DContent
        {
            get
            {
                return this.DBaseControl.InnerDuiControl;
            }
        }

        public DSkinListBox ParentListBox
        {
            get
            {
                return (DSkinListBox) this.DBaseControl.InnerDuiControl.HostControl;
            }
        }
    }
}

