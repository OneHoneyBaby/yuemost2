namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiComboBox : DuiButton
    {
        private bool bool_35 = false;
        private bool bool_36 = false;
        private bool bool_37 = true;
        private bool bool_38 = true;
        private bool bool_39 = true;
        private bool bool_40 = true;
        private Color color_7 = Color.FromArgb(0x33, 0x99, 0xff);
        private DSkinListBox dskinListBox_0;
        private DSkinToolStripDropDown dskinToolStripDropDown_0;
        private DuiTextBox duiTextBox_0;
        private ToolStripControlHost EdppuXvaIG;
        private int int_5 = -1;
        private int int_6 = 250;
        private int int_7 = 2;
        private int int_8 = -1;
        private string string_3 = string.Empty;

        [Description("内部列表控件中的被选中项目索引改变时候发生")]
        public event EventHandler SelectedIndexChanged;

        public DuiComboBox()
        {
            this.TextPadding = 3;
            base.Height = (this.Font.Height + 2) + this.TextPadding;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Radius = 0;
            this.BaseColor = Color.White;
            this.IsDrawText = false;
        }

        public void AddItem(string item)
        {
            DuiLabel control = new DuiLabel {
                AutoSize = true,
                Font = this.Font,
                ForeColor = this.ForeColor,
                Text = item
            };
            this.Items.Add(control);
        }

        public void CloseDropDown()
        {
            this.ToolStripDropDown.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.dskinListBox_0 != null)
            {
                this.dskinListBox_0.Dispose();
                this.dskinListBox_0 = null;
            }
            if (this.dskinToolStripDropDown_0 != null)
            {
                this.dskinToolStripDropDown_0.Dispose();
                this.dskinToolStripDropDown_0 = null;
            }
            base.Dispose(disposing);
        }

        [CompilerGenerated]
        private void DkepvfEhmH(object sender, EventArgs e)
        {
            this.Text = this.duiTextBox_0.Text;
        }

        private void dskinListBox_0_MouseClick(object sender, MouseEventArgs e)
        {
            if ((((this.int_8 != -1) && !this.dskinListBox_0.Ulmul) && (this.dskinListBox_0.Orientation == Orientation.Vertical)) && (!this.dskinListBox_0.InnerScrollBar.Visible || (this.dskinListBox_0.InnerScrollBar.Visible && (e.X < this.dskinListBox_0.InnerScrollBar.Left))))
            {
                this.SelectedIndex = this.int_8;
                if (this.bool_38)
                {
                    this.CloseDropDown();
                }
            }
        }

        private void dskinListBox_0_MouseLeave(object sender, EventArgs e)
        {
            this.method_34(-1);
        }

        private void dskinListBox_0_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.InnerListBox.Ulmul || (this.InnerListBox.Orientation == Orientation.Horizontal))
            {
                this.method_34(-1);
            }
            else
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    DuiBaseControl control = this.Items[i];
                    if ((control.Top <= (e.Y - this.dskinListBox_0.ListTop)) && ((control.Top + control.Height) > (e.Y - this.dskinListBox_0.ListTop)))
                    {
                        this.method_34(i);
                        return;
                    }
                }
                this.method_34(-1);
            }
        }

        private void dskinListBox_0_SizeChanged(object sender, EventArgs e)
        {
        }

        private void dskinToolStripDropDown_0_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.MouseChangeControlState = true;
            base.ControlState = ControlStates.Normal;
            this.bool_36 = false;
        }

        private void dskinToolStripDropDown_0_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked)
            {
                Rectangle rectangle = new Rectangle(base.LocationToScreen, this.Size);
                if (rectangle.Contains(Control.MousePosition))
                {
                    e.Cancel = true;
                }
            }
        }

        private void dskinToolStripDropDown_0_Opened(object sender, EventArgs e)
        {
            this.bool_36 = true;
            this.InnerListBox.Focus();
        }

        private void dskinToolStripDropDown_0_SizeChanged(object sender, EventArgs e)
        {
            if (this.ToolStripDropDown.Resizable)
            {
                this.InnerListBox.Size = new Size(this.ToolStripDropDown.Width - this.ToolStripDropDown.Padding.Horizontal, this.ToolStripDropDown.Height - this.ToolStripDropDown.ResizeGridSize.Height);
            }
            else if (!this.ToolStripDropDown.AutoSize)
            {
                this.InnerListBox.Size = new Size(this.ToolStripDropDown.Width - this.ToolStripDropDown.Padding.Horizontal, this.ToolStripDropDown.Height - this.ToolStripDropDown.Padding.Vertical);
            }
        }

        private int method_33()
        {
            return this.int_8;
        }

        private void method_34(int value)
        {
            if (this.int_8 != value)
            {
                this.int_8 = value;
                this.InnerListBox.Invalidate();
            }
        }

        private void method_35(object sender, PaintEventArgs e)
        {
            if ((this.int_8 >= 0) && (this.Items.Count > 0))
            {
                using (SolidBrush brush = new SolidBrush(this.color_7))
                {
                    DuiBaseControl control = this.Items[this.int_8];
                    Rectangle rect = new Rectangle(0, control.Top + this.dskinListBox_0.ListTop, this.InnerListBox.Width, control.Height);
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        private ToolStripControlHost method_36()
        {
            if (this.EdppuXvaIG == null)
            {
                this.EdppuXvaIG = new ToolStripControlHost(this.InnerListBox);
                this.EdppuXvaIG.Padding = Padding.Empty;
                this.EdppuXvaIG.Margin = Padding.Empty;
            }
            return this.EdppuXvaIG;
        }

        private void method_37(object sender, ItemClickEventArgs e)
        {
            this.SelectedIndex = e.Index;
            if (this.bool_38)
            {
                this.CloseDropDown();
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.duiTextBox_0 != null)
            {
                this.duiTextBox_0.Font = this.Font;
                this.duiTextBox_0.Height = this.Font.Height;
                this.duiTextBox_0.Left = this.TextPadding + base.TextInnerPadding.Left;
                this.duiTextBox_0.Top = (base.Height - this.duiTextBox_0.Height) / 2;
            }
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (this.duiTextBox_0 != null)
            {
                this.duiTextBox_0.ForeColor = this.ForeColor;
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.IsDropDown)
            {
                this.CloseDropDown();
            }
            else if (!this.bool_35 || (e.X >= (base.Width - 20)))
            {
                this.ShowDropDown();
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            if (this.duiTextBox_0 != null)
            {
                this.duiTextBox_0.TextRenderMode = this.TextRenderMode;
            }
            base.OnPrePaint(e);
            Graphics g = e.Graphics;
            if (((this.int_5 > -1) && (this.InnerListBox.Items.Count > this.int_5)) && this.AutoDrawSelecedItem)
            {
                DuiBaseControl control = this.InnerListBox.Items[this.int_5];
                g.TranslateTransform((float) this.int_7, (float) ((base.Height - control.Height) / 2));
                control.CanDraw = true;
                Rectangle invalidateRect = new Rectangle(this.int_7, (base.Height - control.Height) / 2, control.Width, control.Height);
                invalidateRect.Intersect(e.ClipRectangle);
                invalidateRect.Offset(-this.int_7, -(base.Height - control.Height) / 2);
                control.PaintControl(g, invalidateRect);
                control.CanDraw = false;
                g.TranslateTransform((float) -this.int_7, (float) (-(base.Height - control.Height) / 2));
            }
            if (this.bool_39)
            {
                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    g.SmoothingMode = SmoothingMode.Default;
                    g.SetClip(e.ClipRectangle);
                    Point[] points = new Point[] { new Point((base.Width - 8) - 9, (base.Height - 5) / 2), new Point((base.Width - 8) + 1, (base.Height - 5) / 2), new Point((base.Width - 8) - 4, ((base.Height - 5) / 2) + 5) };
                    g.FillPolygon(brush, points);
                }
            }
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.duiTextBox_0 != null)
            {
                this.duiTextBox_0.Width = ((base.Width - 0x12) - (this.TextPadding * 2)) - base.TextInnerPadding.Horizontal;
                this.duiTextBox_0.Top = (base.Height - this.duiTextBox_0.Height) / 2;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.bool_35)
            {
                this.InnerTextBox.Text = this.Text;
            }
        }

        public void ShowDropDown()
        {
            Point locationToScreen = base.LocationToScreen;
            locationToScreen.Y += base.Height;
            this.InnerListBox.LayoutContent();
            if (this.bool_40)
            {
                Size size;
                if (this.InnerListBox.ContentLength > this.int_6)
                {
                    size = new Size(base.Width, this.int_6);
                }
                else if (this.InnerListBox.ContentLength < 20)
                {
                    size = new Size(base.Width, 20);
                }
                else
                {
                    size = new Size(base.Width, this.InnerListBox.ContentLength);
                }
                this.InnerListBox.Size = size;
            }
            this.ToolStripDropDown.Show(locationToScreen);
            this.MouseChangeControlState = false;
            base.ControlState = ControlStates.Pressed;
        }

        [DefaultValue(true), Category("行为"), Description("选中项目之后自动关闭下拉框")]
        public bool AutoClose
        {
            get
            {
                return this.bool_38;
            }
            set
            {
                this.bool_38 = value;
            }
        }

        [Description("是否自动绘制被选中项目"), DefaultValue(true)]
        public bool AutoDrawSelecedItem
        {
            get
            {
                return this.bool_37;
            }
            set
            {
                if (this.bool_37 != value)
                {
                    this.bool_37 = value;
                    this.IsDrawText = !value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "White")]
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

        [DefaultValue(false), Description("是否可以编辑")]
        public bool CanEdit
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
                        this.bool_37 = false;
                        this.IsDrawText = false;
                        this.InnerTextBox.Visible = true;
                    }
                    else
                    {
                        this.IsDrawText = !this.bool_37;
                        this.InnerTextBox.Visible = false;
                    }
                }
            }
        }

        [DefaultValue(true), Description("下拉框自适应")]
        public bool DropDownAutoSize
        {
            get
            {
                return this.bool_40;
            }
            set
            {
                this.bool_40 = value;
            }
        }

        [Category("内部列表控件"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DSkinListBox InnerListBox
        {
            get
            {
                if (this.dskinListBox_0 == null)
                {
                    this.dskinListBox_0 = new DSkinListBox();
                    this.dskinListBox_0.ItemClick += new EventHandler<ItemClickEventArgs>(this.method_37);
                    this.dskinListBox_0.SizeChanged += new EventHandler(this.dskinListBox_0_SizeChanged);
                    this.dskinListBox_0.MouseMove += new MouseEventHandler(this.dskinListBox_0_MouseMove);
                    this.dskinListBox_0.MouseLeave += new EventHandler(this.dskinListBox_0_MouseLeave);
                    this.dskinListBox_0.MouseClick += new MouseEventHandler(this.dskinListBox_0_MouseClick);
                    this.dskinListBox_0.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_35);
                }
                return this.dskinListBox_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiTextBox InnerTextBox
        {
            get
            {
                EventHandler handler = null;
                if (this.duiTextBox_0 == null)
                {
                    DuiTextBox box2 = new DuiTextBox {
                        Name = "InnerTextBox",
                        Font = this.Font,
                        Text = this.Text,
                        ForeColor = this.ForeColor,
                        Height = this.Font.Height,
                        Width = ((base.Width - 0x12) - (this.TextPadding * 2)) - base.TextInnerPadding.Horizontal,
                        Left = this.TextPadding + base.TextInnerPadding.Left,
                        BackColor = Color.Transparent,
                        TextRenderMode = this.TextRenderMode,
                        DesignModeCanSelect = false
                    };
                    this.duiTextBox_0 = box2;
                    this.duiTextBox_0.Top = (base.Height - this.duiTextBox_0.Height) / 2;
                    this.Controls.Add(this.duiTextBox_0);
                    if (handler == null)
                    {
                        handler = new EventHandler(this.DkepvfEhmH);
                    }
                    this.duiTextBox_0.TextChanged += handler;
                }
                return this.duiTextBox_0;
            }
        }

        [Browsable(false)]
        public bool IsDropDown
        {
            get
            {
                return this.bool_36;
            }
        }

        [DefaultValue(typeof(Color), "51, 153, 255"), Description("单列下拉列表项目鼠标移入的背景色")]
        public Color ItemHoverBackColor
        {
            get
            {
                return this.color_7;
            }
            set
            {
                this.color_7 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("内部列表项目集合")]
        public DuiControlCollection Items
        {
            get
            {
                return this.InnerListBox.Items;
            }
        }

        [Category("行为"), Description("下拉框最大长度"), DefaultValue(250)]
        public int MaxLenght
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
            }
        }

        [Description("自动绘制项目的左间距"), DefaultValue(2)]
        public int PaddingLeft
        {
            get
            {
                return this.int_7;
            }
            set
            {
                if (this.int_7 != value)
                {
                    this.int_7 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(0)]
        public override int Radius
        {
            get
            {
                return base.Radius;
            }
            set
            {
                base.Radius = value;
            }
        }

        [Browsable(false)]
        public DuiBaseControl SelectedDuiControl
        {
            get
            {
                if ((this.Items.Count > this.int_5) && (this.int_5 > -1))
                {
                    return this.Items[this.int_5];
                }
                return null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
                if ((this.Items.Count > this.int_5) && (this.int_5 > -1))
                {
                    this.Text = this.Items[this.int_5].Text;
                }
                else
                {
                    this.Text = string.Empty;
                }
                this.OnSelectedIndexChanged(EventArgs.Empty);
                this.Invalidate();
                base.OnPropertyChanged("SelectedIndex");
            }
        }

        [Description("显示下拉箭头"), DefaultValue(true)]
        public bool ShowArrow
        {
            get
            {
                return this.bool_39;
            }
            set
            {
                if (this.bool_39 != value)
                {
                    this.bool_39 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), Description("字符串转项目，一行一个"), Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor)), DefaultValue("")]
        public string StringToItems
        {
            get
            {
                return this.string_3;
            }
            set
            {
                if (this.string_3 != value)
                {
                    this.string_3 = value;
                    this.Items.Clear();
                    if (!string.IsNullOrEmpty(this.string_3))
                    {
                        foreach (string str in this.string_3.Split(new char[] { '\n' }))
                        {
                            DuiLabel control = new DuiLabel {
                                AutoSize = true,
                                Font = this.Font,
                                ForeColor = this.ForeColor,
                                Text = str.Trim(new char[] { '\n', '\r' })
                            };
                            this.Items.Add(control);
                        }
                    }
                }
            }
        }

        [DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public override ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                base.TextAlign = value;
            }
        }

        [DefaultValue(3)]
        public override int TextPadding
        {
            get
            {
                return base.TextPadding;
            }
            set
            {
                base.TextPadding = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("下拉框窗口")]
        public DSkinToolStripDropDown ToolStripDropDown
        {
            get
            {
                if (this.dskinToolStripDropDown_0 == null)
                {
                    this.dskinToolStripDropDown_0 = new DSkinToolStripDropDown();
                    this.dskinToolStripDropDown_0.Items.Add(this.method_36());
                    this.dskinToolStripDropDown_0.Padding = Padding.Empty;
                    this.dskinToolStripDropDown_0.Opened += new EventHandler(this.dskinToolStripDropDown_0_Opened);
                    this.dskinToolStripDropDown_0.Closed += new ToolStripDropDownClosedEventHandler(this.dskinToolStripDropDown_0_Closed);
                    this.dskinToolStripDropDown_0.SizeChanged += new EventHandler(this.dskinToolStripDropDown_0_SizeChanged);
                    this.dskinToolStripDropDown_0.Closing += new ToolStripDropDownClosingEventHandler(this.dskinToolStripDropDown_0_Closing);
                    this.dskinToolStripDropDown_0.Resizable = false;
                }
                return this.dskinToolStripDropDown_0;
            }
        }
    }
}

