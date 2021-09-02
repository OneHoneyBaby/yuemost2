namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using DSkin.Forms;
    using DSkin.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Windows.Forms;

    public class PictureBrowseForm : DSkinForm
    {
        private DSkinButton dBtnNext;
        private DSkinButton dBtnPre;
        private DSkinLabel dLbl;
        private DSkinButton dSkinButton1;
        private DSkinButton dSkinButton2;
        private DSkinButton dSkinButton3;
        private DSkinButton dSkinButton4;
        private DSkinButton dSkinButton5;
        private DSkinButton dSkinButton6;
        private DSkinPanel dSkinPanel1;
        private DSkinToolTip dskinToolTip_1;
        private IContainer icontainer_1;
        private int int_8;
        private List<System.Drawing.Image> list_0;
        private DuiPictureBox picBox;
        private Point point_3;
        private Timer timer_1;

        public PictureBrowseForm()
        {
            this.icontainer_1 = null;
            this.InitializeComponent_1();
        }

        public PictureBrowseForm(List<System.Drawing.Image> imageList, int index)
        {
            this.icontainer_1 = null;
            this.InitializeComponent_1();
            this.list_0 = imageList;
            this.int_8 = index;
            this.Image = imageList[index];
            this.method_24();
        }

        private void dBtnNext_Click(object sender, EventArgs e)
        {
            if (this.list_0 != null)
            {
                this.int_8 = (this.int_8 == (this.list_0.Count - 1)) ? 0 : (this.int_8 + 1);
                this.Image = this.list_0[this.int_8];
                this.method_24();
            }
        }

        private void dBtnPre_Click(object sender, EventArgs e)
        {
            if (this.list_0 != null)
            {
                this.int_8 = (this.int_8 == 0) ? (this.list_0.Count - 1) : (this.int_8 - 1);
                this.Image = this.list_0[this.int_8];
                this.method_24();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_1 != null))
            {
                this.icontainer_1.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Image = System.Drawing.Image.FromFile(dialog.FileName);
                    this.method_24();
                }
            }
        }

        private void dSkinButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.dLbl.Text = "100%";
                if (this.Image != null)
                {
                    this.picBox.Size = this.Image.Size;
                    this.picBox.Location = new Point((base.Width - this.picBox.Width) / 2, (base.Height - this.picBox.Height) / 2);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dSkinButton4_Click(object sender, EventArgs e)
        {
            if (base.WindowState != FormWindowState.Maximized)
            {
                base.WindowState = FormWindowState.Maximized;
            }
            else
            {
                base.WindowState = FormWindowState.Normal;
            }
        }

        private void dSkinButton5_Click(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "JPG格式|*.jpg|PNG格式|*.png|BMP格式|*.bmp|GIF格式|*.gif|所有格式(*.*)|*.*";
                    if ((dialog.ShowDialog() == DialogResult.OK) && !string.IsNullOrEmpty(dialog.FileName))
                    {
                        string str2 = Path.GetExtension(dialog.FileName).ToLower();
                        ImageFormat png = ImageFormat.Png;
                        switch (str2.ToLower())
                        {
                            case ".png":
                                png = ImageFormat.Png;
                                break;

                            case ".bmp":
                                png = ImageFormat.Bmp;
                                break;

                            case ".gif":
                                png = ImageFormat.Gif;
                                break;

                            case ".jpg":
                            case ".jpeg":
                                png = ImageFormat.Jpeg;
                                break;
                        }
                        this.Image.Save(dialog.FileName, png);
                    }
                }
            }
        }

        private void dSkinButton6_Click(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                try
                {
                    this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    this.picBox.Size = new Size(this.picBox.Height, this.picBox.Width);
                    this.picBox.Location = new Point((base.Width - this.picBox.Width) / 2, (base.Height - this.picBox.Height) / 2);
                    base.Invalidate();
                }
                catch (Exception)
                {
                }
            }
        }

        private void InitializeComponent_1()
        {
            this.icontainer_1 = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PictureBrowseForm));
            this.dBtnPre = new DSkinButton();
            this.dBtnNext = new DSkinButton();
            this.dLbl = new DSkinLabel();
            this.timer_1 = new Timer(this.icontainer_1);
            this.picBox = new DuiPictureBox();
            this.dSkinButton1 = new DSkinButton();
            this.dSkinButton2 = new DSkinButton();
            this.dSkinPanel1 = new DSkinPanel();
            this.dSkinButton6 = new DSkinButton();
            this.dSkinButton5 = new DSkinButton();
            this.dSkinButton4 = new DSkinButton();
            this.dSkinButton3 = new DSkinButton();
            this.dskinToolTip_1 = new DSkinToolTip(this.icontainer_1);
            this.dSkinPanel1.SuspendLayout();
            base.SuspendLayout();
            this.dBtnPre.AdaptImage = true;
            this.dBtnPre.Anchor = AnchorStyles.Left;
            this.dBtnPre.BackgroundImageLayout = ImageLayout.None;
            this.dBtnPre.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dBtnPre.ButtonBorderColor = Color.Gray;
            this.dBtnPre.ButtonBorderWidth = 1;
            this.dBtnPre.DialogResult = DialogResult.None;
            this.dBtnPre.HoverColor = Color.Empty;
            this.dBtnPre.HoverImage = (System.Drawing.Image) manager.GetObject("dBtnPre.HoverImage");
            this.dBtnPre.IsPureColor = false;
            this.dBtnPre.Location = new Point(7, 0xac);
            this.dBtnPre.Name = "dBtnPre";
            this.dBtnPre.NormalImage = (System.Drawing.Image) manager.GetObject("dBtnPre.NormalImage");
            this.dBtnPre.PressColor = Color.Empty;
            this.dBtnPre.PressedImage = (System.Drawing.Image) manager.GetObject("dBtnPre.PressedImage");
            this.dBtnPre.Radius = 10;
            this.dBtnPre.ShowButtonBorder = true;
            this.dBtnPre.Size = new Size(0x30, 0x30);
            this.dBtnPre.TabIndex = 0;
            this.dBtnPre.TextAlign = ContentAlignment.MiddleCenter;
            this.dBtnPre.TextPadding = 0;
            this.dBtnPre.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dBtnPre.Click += new EventHandler(this.dBtnPre_Click);
            this.dBtnNext.AdaptImage = true;
            this.dBtnNext.Anchor = AnchorStyles.Right;
            this.dBtnNext.BackgroundImageLayout = ImageLayout.None;
            this.dBtnNext.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dBtnNext.ButtonBorderColor = Color.Gray;
            this.dBtnNext.ButtonBorderWidth = 1;
            this.dBtnNext.DialogResult = DialogResult.None;
            this.dBtnNext.HoverColor = Color.Empty;
            this.dBtnNext.HoverImage = (System.Drawing.Image) manager.GetObject("dBtnNext.HoverImage");
            this.dBtnNext.IsPureColor = false;
            this.dBtnNext.Location = new Point(0x221, 0xac);
            this.dBtnNext.Name = "dBtnNext";
            this.dBtnNext.NormalImage = (System.Drawing.Image) manager.GetObject("dBtnNext.NormalImage");
            this.dBtnNext.PressColor = Color.Empty;
            this.dBtnNext.PressedImage = (System.Drawing.Image) manager.GetObject("dBtnNext.PressedImage");
            this.dBtnNext.Radius = 10;
            this.dBtnNext.ShowButtonBorder = true;
            this.dBtnNext.Size = new Size(0x30, 0x30);
            this.dBtnNext.TabIndex = 1;
            this.dBtnNext.TextAlign = ContentAlignment.MiddleCenter;
            this.dBtnNext.TextPadding = 0;
            this.dBtnNext.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dBtnNext.Click += new EventHandler(this.dBtnNext_Click);
            this.dLbl.Anchor = AnchorStyles.None;
            this.dLbl.AutoSize = false;
            this.dLbl.BackgroundImage = (System.Drawing.Image) manager.GetObject("dLbl.BackgroundImage");
            this.dLbl.BackgroundImageLayout = ImageLayout.None;
            this.dLbl.Font = new Font("黑体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.dLbl.ForeColor = Color.White;
            this.dLbl.Location = new Point(0xf6, 0xac);
            this.dLbl.Name = "dLbl";
            this.dLbl.Size = new Size(110, 0x2d);
            this.dLbl.TabIndex = 3;
            this.dLbl.Text = "100%";
            this.dLbl.TextAlign = ContentAlignment.MiddleCenter;
            this.dLbl.Visible = false;
            this.timer_1.Interval = 500;
            this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
            this.picBox.Anchor = AnchorStyles.None;
            this.picBox.AutoSize = false;
            this.picBox.BackgroundImageLayout = ImageLayout.None;
            this.picBox.Cursor = Cursors.NoMove2D;
            this.picBox.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.picBox.Images = new System.Drawing.Image[1];
            this.picBox.Interval = 100;
            this.picBox.Location = new Point(0xbc, 0x62);
            this.picBox.Name = "picBox";
            this.picBox.Size = new Size(0xeb, 0xcc);
            this.picBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.picBox.Text = "dSkinPictureBox1";
            this.picBox.MouseMove += new EventHandler<DuiMouseEventArgs>(this.method_26);
            this.picBox.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_25);
            this.dSkinButton1.AdaptImage = true;
            this.dSkinButton1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.dSkinButton1.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton1.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton1.ButtonBorderColor = Color.Gray;
            this.dSkinButton1.ButtonBorderWidth = 1;
            this.dSkinButton1.DialogResult = DialogResult.None;
            this.dSkinButton1.HoverColor = Color.Empty;
            this.dSkinButton1.HoverImage = Resources.smethod_22();
            this.dSkinButton1.IsPureColor = false;
            this.dSkinButton1.Location = new Point(570, 5);
            this.dSkinButton1.Name = "dSkinButton1";
            this.dSkinButton1.NormalImage = Resources.smethod_23();
            this.dSkinButton1.PressColor = Color.Empty;
            this.dSkinButton1.PressedImage = Resources.smethod_21();
            this.dSkinButton1.Radius = 10;
            this.dSkinButton1.ShowButtonBorder = true;
            this.dSkinButton1.Size = new Size(0x19, 0x19);
            this.dSkinButton1.TabIndex = 5;
            this.dSkinButton1.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton1.TextPadding = 0;
            this.dSkinButton1.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dSkinButton1.Click += new EventHandler(this.dSkinButton1_Click);
            this.dSkinButton2.AdaptImage = true;
            this.dSkinButton2.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton2.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton2.ButtonBorderColor = Color.Gray;
            this.dSkinButton2.ButtonBorderWidth = 1;
            this.dSkinButton2.DialogResult = DialogResult.None;
            this.dSkinButton2.HoverColor = Color.Empty;
            this.dSkinButton2.HoverImage = null;
            this.dSkinButton2.IsPureColor = false;
            this.dSkinButton2.Location = new Point(0xfe, 30);
            this.dSkinButton2.Name = "dSkinButton2";
            this.dSkinButton2.NormalImage = null;
            this.dSkinButton2.PressColor = Color.Empty;
            this.dSkinButton2.PressedImage = null;
            this.dSkinButton2.Radius = 10;
            this.dSkinButton2.ShowButtonBorder = true;
            this.dSkinButton2.Size = new Size(0x6a, 0x21);
            this.dSkinButton2.TabIndex = 6;
            this.dSkinButton2.Text = "打开图片";
            this.dSkinButton2.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton2.TextPadding = 0;
            this.dSkinButton2.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dSkinButton2.Visible = false;
            this.dSkinButton2.Click += new EventHandler(this.dSkinButton2_Click);
            this.dSkinPanel1.Anchor = AnchorStyles.Bottom;
            this.dSkinPanel1.BackColor = Color.FromArgb(80, 0, 0, 0);
            this.dSkinPanel1.BackgroundImageLayout = ImageLayout.None;
            this.dSkinPanel1.Controls.Add(this.dSkinButton6);
            this.dSkinPanel1.Controls.Add(this.dSkinButton5);
            this.dSkinPanel1.Controls.Add(this.dSkinButton4);
            this.dSkinPanel1.Controls.Add(this.dSkinButton3);
            this.dSkinPanel1.Location = new Point(0xbc, 0x161);
            this.dSkinPanel1.Name = "dSkinPanel1";
            this.dSkinPanel1.RightBottom = (System.Drawing.Image) manager.GetObject("dSkinPanel1.RightBottom");
            this.dSkinPanel1.Size = new Size(0xeb, 0x2c);
            this.dSkinPanel1.TabIndex = 7;
            this.dSkinButton6.AdaptImage = true;
            this.dSkinButton6.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton6.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton6.ButtonBorderColor = Color.Gray;
            this.dSkinButton6.ButtonBorderWidth = 1;
            this.dSkinButton6.DialogResult = DialogResult.None;
            this.dSkinButton6.HoverColor = Color.Empty;
            this.dSkinButton6.HoverImage = null;
            this.dSkinButton6.IsPureColor = false;
            this.dSkinButton6.Location = new Point(0xbc, 12);
            this.dSkinButton6.Name = "dSkinButton6";
            this.dSkinButton6.NormalImage = (System.Drawing.Image) manager.GetObject("dSkinButton6.NormalImage");
            this.dSkinButton6.PressColor = Color.Empty;
            this.dSkinButton6.PressedImage = null;
            this.dSkinButton6.Radius = 10;
            this.dSkinButton6.ShowButtonBorder = true;
            this.dSkinButton6.Size = new Size(0x15, 20);
            this.dSkinButton6.TabIndex = 3;
            this.dSkinButton6.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton6.TextPadding = 0;
            this.dSkinButton6.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dskinToolTip_1.SetToolTip(this.dSkinButton6, "向右旋转");
            this.dSkinButton6.Click += new EventHandler(this.dSkinButton6_Click);
            this.dSkinButton5.AdaptImage = true;
            this.dSkinButton5.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton5.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton5.ButtonBorderColor = Color.Gray;
            this.dSkinButton5.ButtonBorderWidth = 1;
            this.dSkinButton5.DialogResult = DialogResult.None;
            this.dSkinButton5.HoverColor = Color.Empty;
            this.dSkinButton5.HoverImage = null;
            this.dSkinButton5.IsPureColor = false;
            this.dSkinButton5.Location = new Point(0x87, 12);
            this.dSkinButton5.Name = "dSkinButton5";
            this.dSkinButton5.NormalImage = (System.Drawing.Image) manager.GetObject("dSkinButton5.NormalImage");
            this.dSkinButton5.PressColor = Color.Empty;
            this.dSkinButton5.PressedImage = null;
            this.dSkinButton5.Radius = 10;
            this.dSkinButton5.ShowButtonBorder = true;
            this.dSkinButton5.Size = new Size(0x15, 20);
            this.dSkinButton5.TabIndex = 2;
            this.dSkinButton5.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton5.TextPadding = 0;
            this.dSkinButton5.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dskinToolTip_1.SetToolTip(this.dSkinButton5, "保存");
            this.dSkinButton5.Click += new EventHandler(this.dSkinButton5_Click);
            this.dSkinButton4.AdaptImage = true;
            this.dSkinButton4.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton4.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton4.ButtonBorderColor = Color.Gray;
            this.dSkinButton4.ButtonBorderWidth = 1;
            this.dSkinButton4.DialogResult = DialogResult.None;
            this.dSkinButton4.HoverColor = Color.Empty;
            this.dSkinButton4.HoverImage = null;
            this.dSkinButton4.IsPureColor = false;
            this.dSkinButton4.Location = new Point(0x4b, 12);
            this.dSkinButton4.Name = "dSkinButton4";
            this.dSkinButton4.NormalImage = (System.Drawing.Image) manager.GetObject("dSkinButton4.NormalImage");
            this.dSkinButton4.PressColor = Color.Empty;
            this.dSkinButton4.PressedImage = null;
            this.dSkinButton4.Radius = 10;
            this.dSkinButton4.ShowButtonBorder = true;
            this.dSkinButton4.Size = new Size(0x15, 20);
            this.dSkinButton4.TabIndex = 1;
            this.dSkinButton4.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton4.TextPadding = 0;
            this.dSkinButton4.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dskinToolTip_1.SetToolTip(this.dSkinButton4, "全屏");
            this.dSkinButton4.Click += new EventHandler(this.dSkinButton4_Click);
            this.dSkinButton3.AdaptImage = true;
            this.dSkinButton3.BackgroundImageLayout = ImageLayout.None;
            this.dSkinButton3.BaseColor = Color.FromArgb(0x85, 0xba, 0xe9);
            this.dSkinButton3.ButtonBorderColor = Color.Gray;
            this.dSkinButton3.ButtonBorderWidth = 1;
            this.dSkinButton3.DialogResult = DialogResult.None;
            this.dSkinButton3.HoverColor = Color.Empty;
            this.dSkinButton3.HoverImage = null;
            this.dSkinButton3.IsPureColor = false;
            this.dSkinButton3.Location = new Point(0x16, 12);
            this.dSkinButton3.Name = "dSkinButton3";
            this.dSkinButton3.NormalImage = (System.Drawing.Image) manager.GetObject("dSkinButton3.NormalImage");
            this.dSkinButton3.PressColor = Color.Empty;
            this.dSkinButton3.PressedImage = null;
            this.dSkinButton3.Radius = 10;
            this.dSkinButton3.ShowButtonBorder = true;
            this.dSkinButton3.Size = new Size(0x15, 20);
            this.dSkinButton3.TabIndex = 0;
            this.dSkinButton3.TextAlign = ContentAlignment.MiddleCenter;
            this.dSkinButton3.TextPadding = 0;
            this.dSkinButton3.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.dskinToolTip_1.SetToolTip(this.dSkinButton3, "实际大小");
            this.dSkinButton3.Click += new EventHandler(this.dSkinButton3_Click);
            this.dskinToolTip_1.AutoPopDelay = 0x1388;
            this.dskinToolTip_1.BackColor = Color.White;
            this.dskinToolTip_1.ImageSize = new Size(20, 20);
            this.dskinToolTip_1.InitialDelay = 500;
            this.dskinToolTip_1.OwnerDraw = true;
            this.dskinToolTip_1.ReshowDelay = 800;
            this.dskinToolTip_1.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(180, 0, 0, 0);
            this.BackgroundImageLayout = ImageLayout.Zoom;
            base.BorderColor = Color.FromArgb(100, 250, 250, 250);
            base.CaptionShowMode = TextShowModes.None;
            base.ClientSize = new Size(600, 400);
            base.CloseBox.Size = new Size(0x19, 0x19);
            base.Controls.Add(this.dSkinPanel1);
            base.Controls.Add(this.dSkinButton2);
            base.Controls.Add(this.dSkinButton1);
            base.Controls.Add(this.dLbl);
            base.Controls.Add(this.dBtnNext);
            base.Controls.Add(this.dBtnPre);
            base.DrawIcon = false;
            this.DuiControlCollection_0.Add(this.picBox);
            base.EnableAnimation = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            this.MinimumSize = new Size(600, 400);
            base.Name = "PictureBrowseForm";
            base.Radius = 10;
            base.ShadowWidth = 6;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.ShowShadow = true;
            base.ShowSystemButtons = false;
            base.SystemButtonsOffset = new Point(2, 2);
            this.Text = "PicForm";
            base.Load += new EventHandler(this.PictureBrowseForm_Load);
            this.dSkinPanel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void method_24()
        {
            if (this.Image != null)
            {
                Size size = this.Image.Size;
                if ((size.Width <= 0x254) && (size.Height <= 0x18c))
                {
                    this.picBox.Size = this.Image.Size;
                }
                else
                {
                    double num = (1.0 * size.Width) / ((double) size.Height);
                    double num2 = (1.0 * base.Width) / ((double) base.Height);
                    if (num > num2)
                    {
                        this.picBox.Size = new Size(base.Width - 4, (int) (((double) (base.Width - 4)) / num));
                    }
                    else
                    {
                        this.picBox.Size = new Size((int) ((base.Height - 4) * num), base.Height - 4);
                    }
                    this.dLbl.Text = ((1.0 * this.picBox.Width) / ((double) this.Image.Width)).ToString("#00%");
                }
                this.picBox.Location = new Point((base.Width - this.picBox.Width) / 2, (base.Height - this.picBox.Height) / 2);
            }
        }

        private void method_25(object sender, DuiMouseEventArgs e)
        {
            this.point_3 = e.Location;
        }

        private void method_26(object sender, DuiMouseEventArgs e)
        {
            if (this.picBox.IsMouseDown)
            {
                this.picBox.Location = new Point((this.picBox.Left + e.X) - this.point_3.X, (this.picBox.Top + e.Y) - this.point_3.Y);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int num = int.Parse(this.dLbl.Text.Replace("%", ""));
            if (e.Delta > 0)
            {
                if (num >= 0x4b0)
                {
                    num = 0x640;
                }
                else if (num >= 600)
                {
                    num += 200;
                }
                else if (num >= 100)
                {
                    num += 50;
                }
                else if (num >= 90)
                {
                    num = 100;
                }
                else if (num >= 50)
                {
                    num += 10;
                }
                else if (num >= 20)
                {
                    num += 5;
                }
                else if (num >= 10)
                {
                    num += 2;
                }
                else if (num >= 5)
                {
                    num++;
                }
            }
            else if (num <= 5)
            {
                num = 5;
            }
            else if (num <= 10)
            {
                num--;
            }
            else if (num <= 20)
            {
                num -= 2;
            }
            else if (num <= 50)
            {
                num -= 5;
            }
            else if (num <= 100)
            {
                num -= 10;
            }
            else if (num <= 150)
            {
                num = 100;
            }
            else if (num <= 600)
            {
                num -= 50;
            }
            else if (num <= 0x4b0)
            {
                num -= 200;
            }
            else
            {
                num = 0x4b0;
            }
            if (this.Image != null)
            {
                try
                {
                    this.picBox.Size = new Size((num * this.Image.Width) / 100, (num * this.Image.Height) / 100);
                    this.picBox.Location = new Point((base.Width - this.picBox.Width) / 2, (base.Height - this.picBox.Height) / 2);
                }
                catch (Exception)
                {
                }
            }
            this.dLbl.Text = num + "%";
            this.timer_1.Start();
            this.dLbl.Visible = true;
        }

        private void PictureBrowseForm_Load(object sender, EventArgs e)
        {
        }

        public void SetZoom(int proportion)
        {
            if (this.Image != null)
            {
                try
                {
                    this.picBox.Size = new Size((proportion * this.Image.Width) / 100, (proportion * this.Image.Height) / 100);
                    this.picBox.Location = new Point((base.Width - this.picBox.Width) / 2, (base.Height - this.picBox.Height) / 2);
                }
                catch (Exception)
                {
                }
            }
            this.dLbl.Text = proportion + "%";
            this.timer_1.Start();
            this.dLbl.Visible = true;
        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            this.timer_1.Stop();
            this.dLbl.Visible = false;
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.picBox.Image;
            }
            set
            {
                this.picBox.Image = value;
            }
        }

        public List<System.Drawing.Image> ImageList
        {
            get
            {
                return this.list_0;
            }
        }
    }
}

