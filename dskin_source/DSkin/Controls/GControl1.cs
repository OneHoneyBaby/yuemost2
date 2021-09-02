namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [Designer("DSkin.Design.DSkinNumericUpDownControlDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), ToolboxBitmap(typeof(NumericUpDown))]
    public class GControl1 : DSkinUserControl
    {
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2;
        private decimal decimal_3;
        private DSkinTextBox dskinTextBox_0;
        private DuiButton duiButton_0;
        private DuiButton duiButton_1;
        [CompilerGenerated]
        private static Func<char, bool> func_0;
        private int int_0;

        public event EventHandler ValueChanged;

        public GControl1()
        {
            DuiButton button = new DuiButton {
                Name = "upButton",
                Width = 0x12,
                Radius = 0,
                Text = "▲",
                Font = new System.Drawing.Font(FontHelper.FontAwesome, 4f),
                ButtonBorderColor = Color.FromArgb(0x17, 0xa9, 0xfe),
                ForeColor = Color.FromArgb(0, 0x5f, 0x98),
                BaseColor = Color.FromArgb(0xc3, 0xeb, 0xff)
            };
            this.duiButton_0 = button;
            DuiButton button2 = new DuiButton {
                Name = "downButton",
                Width = 0x12,
                Radius = 0,
                Text = "▼",
                Font = new System.Drawing.Font(FontHelper.FontAwesome, 4f),
                ButtonBorderColor = Color.FromArgb(0x17, 0xa9, 0xfe),
                ForeColor = Color.FromArgb(0, 0x5f, 0x98),
                BaseColor = Color.FromArgb(0xc3, 0xeb, 0xff)
            };
            this.duiButton_1 = button2;
            DSkinTextBox box = new DSkinTextBox {
                BorderStyle = BorderStyle.None,
                Location = new Point(2, 3),
                Text = "0"
            };
            this.dskinTextBox_0 = box;
            this.int_0 = 0x12;
            this.decimal_0 = 1M;
            this.decimal_1 = 100M;
            this.decimal_2 = 0M;
            this.decimal_3 = 0M;
            this.color_0 = Color.FromArgb(0x17, 0xa9, 0xfe);
            this.color_1 = Color.FromArgb(0xc3, 0xeb, 0xff);
            this.color_2 = Color.FromArgb(0, 0x5f, 0x98);
            this.BackColor = Color.White;
            base.DuiControlCollection_0.Add(this.duiButton_0);
            base.DuiControlCollection_0.Add(this.duiButton_1);
            this.dskinTextBox_0.Width = (base.Width - this.ButtonWidth) - 5;
            base.Controls.Add(this.dskinTextBox_0);
            base.Height = this.dskinTextBox_0.Height;
            base.Borders.AllColor = Color.FromArgb(0x17, 0xa9, 0xfe);
            this.duiButton_0.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_6);
            this.duiButton_1.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_5);
            this.dskinTextBox_0.KeyPress += new KeyPressEventHandler(this.dskinTextBox_0_KeyPress);
            this.dskinTextBox_0.KeyDown += new KeyEventHandler(this.dskinTextBox_0_KeyDown);
        }

        private void dskinTextBox_0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.Value += this.decimal_0;
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.Value -= this.decimal_0;
            }
        }

        private void dskinTextBox_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            MethodInvoker method = null;
            if ((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && (e.KeyChar == '.'))
            {
            }
            if ((func_0 != null) || (this.dskinTextBox_0.Text.Where<char>(func_0).Count<char>() == 0))
            {
                if (method == null)
                {
                    method = new MethodInvoker(this.method_8);
                }
                base.BeginInvoke(method);
            }
            else
            {
                e.Handled = true;
            }
        }

        private void method_5(object sender, DuiMouseEventArgs e)
        {
            this.Value -= this.decimal_0;
            this.method_7(this.duiButton_1);
        }

        private void method_6(object sender, DuiMouseEventArgs e)
        {
            this.Value += this.decimal_0;
            this.method_7(this.duiButton_0);
        }

        private void method_7(DuiButton duiButton_2)
        {
            <>c__DisplayClassb classb;
            DuiButton btn = duiButton_2;
            System.Windows.Forms.Timer sleep = new System.Windows.Forms.Timer {
                Enabled = true,
                Interval = 500
            };
            sleep.Tick += new EventHandler(classb.<ContinuousSetValue>b__9);
        }

        [CompilerGenerated]
        private void method_8()
        {
            decimal result = 0M;
            if ((this.dskinTextBox_0.Text == ".0") || (this.dskinTextBox_0.Text == "0."))
            {
                this.decimal_3 = 0M;
            }
            else if (decimal.TryParse(this.dskinTextBox_0.Text, out result))
            {
                this.Value = result;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                this.Value += this.decimal_0;
            }
            else
            {
                this.Value -= this.decimal_0;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.duiButton_0.Height = (base.Height - 5) / 2;
            this.duiButton_1.Height = (base.Height - 5) - this.duiButton_0.Height;
            this.duiButton_0.Top = 2;
            this.duiButton_0.Left = (base.Width - this.duiButton_0.Width) - 2;
            this.duiButton_1.Top = (this.duiButton_0.Top + this.duiButton_0.Height) + 1;
            this.duiButton_1.Left = (base.Width - this.duiButton_1.Width) - 2;
            this.dskinTextBox_0.Width = (base.Width - this.ButtonWidth) - 5;
            base.Height = this.dskinTextBox_0.Height + 6;
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        [CompilerGenerated]
        private static bool smethod_0(char char_0)
        {
            return (char_0 == '.');
        }

        [Description("箭头颜色"), DefaultValue(typeof(Color), "0, 95, 152"), Category("DSkin")]
        public Color ArrowColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                if (this.color_2 != value)
                {
                    this.color_2 = value;
                    this.duiButton_0.ForeColor = value;
                    this.duiButton_1.ForeColor = value;
                }
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (base.BackColor != value)
                {
                    base.BackColor = value;
                    this.dskinTextBox_0.BackColor = Color.FromArgb(0xff, value);
                }
            }
        }

        [Description("按钮基础色"), Category("DSkin"), DefaultValue(typeof(Color), "195, 235, 255")]
        public Color ButtonBaseColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                    this.duiButton_0.BaseColor = value;
                    this.duiButton_1.BaseColor = value;
                }
            }
        }

        [DefaultValue(typeof(Color), "23, 169, 254"), Description("按钮边框颜色"), Category("DSkin")]
        public Color ButtonBorderColor
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
                    this.duiButton_0.ButtonBorderColor = value;
                    this.duiButton_1.ButtonBorderColor = value;
                }
            }
        }

        [Category("DSkin"), Description("按钮宽度"), DefaultValue(0x12)]
        public int ButtonWidth
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    this.duiButton_0.Width = value;
                    this.duiButton_1.Width = value;
                    this.dskinTextBox_0.Width = (base.Width - this.ButtonWidth) - 5;
                }
            }
        }

        [Browsable(false)]
        public DuiButton DownButton
        {
            get
            {
                return this.duiButton_1;
            }
        }

        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                if (base.Font != value)
                {
                    this.dskinTextBox_0.Font = base.Font = value;
                    base.Height = this.dskinTextBox_0.Height + 6;
                }
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (base.ForeColor != value)
                {
                    this.dskinTextBox_0.ForeColor = base.ForeColor = value;
                }
            }
        }

        [Category("DSkin"), Description("获取或设置单击向上或向下按钮时，数字显示框（也称作 up-down 控件）递增或递减的值。"), DefaultValue(typeof(decimal), "1")]
        public decimal Increment
        {
            get
            {
                return this.decimal_0;
            }
            set
            {
                this.decimal_0 = value;
            }
        }

        [Browsable(false)]
        public DSkinTextBox InnerTextBox
        {
            get
            {
                return this.dskinTextBox_0;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(decimal), "100"), RefreshProperties(RefreshProperties.All), Description("获取或设置数字显示框（也称作 up-down 控件）的最大值。")]
        public decimal Maximum
        {
            get
            {
                return this.decimal_1;
            }
            set
            {
                this.decimal_1 = value;
            }
        }

        [Description("获取或设置数字显示框（也称作 up-down 控件）的最小允许值"), RefreshProperties(RefreshProperties.All), Category("DSkin"), DefaultValue(typeof(decimal), "0")]
        public decimal Minimum
        {
            get
            {
                return this.decimal_2;
            }
            set
            {
                this.decimal_2 = value;
            }
        }

        [DefaultValue(0), Description("文本对齐方式"), Category("DSkin")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.dskinTextBox_0.TextAlign;
            }
            set
            {
                this.dskinTextBox_0.TextAlign = value;
            }
        }

        [Browsable(false)]
        public DuiButton UpButton
        {
            get
            {
                return this.duiButton_0;
            }
        }

        [DefaultValue(typeof(decimal), "0"), Category("DSkin"), Description("获取或设置赋给数字显示框（也称作 up-down 控件）的值。")]
        public decimal Value
        {
            get
            {
                return this.decimal_3;
            }
            set
            {
                if (this.decimal_3 != value)
                {
                    if (value > this.decimal_1)
                    {
                        value = this.decimal_1;
                    }
                    if (value < this.decimal_2)
                    {
                        value = this.decimal_2;
                    }
                    this.decimal_3 = value;
                    this.dskinTextBox_0.Text = this.decimal_3.ToString();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }
    }
}

