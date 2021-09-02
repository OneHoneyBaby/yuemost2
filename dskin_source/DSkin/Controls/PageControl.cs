namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using DSkin.DirectUI.Transform;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class PageControl : DuiBaseControl
    {
        public DuiButton BtnBackPage;
        public DuiButton BtnFistPage;
        public DuiButton BtnGoPage;
        public DuiButton BtnLastPage;
        public DuiButton BtnNextPage;
        private DSkinGridList dskinGridList_0;
        private DSkinLinearGradientBrush dskinLinearGradientBrush_0;
        private DSkinLinearGradientBrush dskinLinearGradientBrush_1;
        private DSkinLinearGradientBrush dskinLinearGradientBrush_2;
        private DuiLabel duiLabel_0;
        private DuiLabel duiLabel_1;
        private DuiTextBox duiTextBox_0;
        private IContainer icontainer_0;

        public PageControl(DSkinGridList dSkinListView)
        {
            this.icontainer_0 = null;
            this.method_35();
            this.dskinGridList_0 = dSkinListView;
        }

        public PageControl(IContainer container)
        {
            this.icontainer_0 = null;
            container.Add(this);
            this.method_35();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void method_29()
        {
            this.duiLabel_0.Location = new Point(4, (base.Height - this.duiLabel_0.Height) / 2);
            this.duiLabel_1.Location = new Point((this.duiLabel_0.Width + this.duiLabel_0.Left) + 4, (base.Height - this.duiLabel_1.Height) / 2);
            this.duiTextBox_0.Location = new Point((this.duiLabel_1.Width + this.duiLabel_1.Left) + 4, (base.Height - this.duiTextBox_0.Height) / 2);
            this.BtnGoPage.Location = new Point((this.duiTextBox_0.Width + this.duiTextBox_0.Left) + 4, 4);
            this.BtnLastPage.Location = new Point((base.Width - 4) - this.BtnLastPage.Width, 4);
            this.BtnNextPage.Location = new Point((this.BtnLastPage.Left - 4) - this.BtnNextPage.Width, 4);
            this.BtnBackPage.Location = new Point((this.BtnNextPage.Left - 4) - this.BtnBackPage.Width, 4);
            this.BtnFistPage.Location = new Point((this.BtnBackPage.Left - 4) - this.BtnFistPage.Width, 4);
            if (this.BtnFistPage.Location.X < ((this.BtnGoPage.Width + this.BtnGoPage.Left) + 4))
            {
                this.BtnFistPage.Location = new Point((this.BtnGoPage.Width + this.BtnGoPage.Left) + 4, 4);
                this.BtnBackPage.Location = new Point((this.BtnFistPage.Width + this.BtnFistPage.Left) + 4, 4);
                this.BtnNextPage.Location = new Point((this.BtnBackPage.Width + this.BtnBackPage.Left) + 4, 4);
                this.BtnLastPage.Location = new Point((this.BtnNextPage.Width + this.BtnNextPage.Left) + 4, 4);
            }
        }

        private void method_30(object sender, DuiMouseEventArgs e)
        {
            this.dskinGridList_0.PageIndex += (this.dskinGridList_0.PageIndex < this.dskinGridList_0.PageCount) ? 1 : 0;
        }

        private void method_31(object sender, DuiMouseEventArgs e)
        {
            this.dskinGridList_0.PageIndex -= (this.dskinGridList_0.PageIndex > 1) ? 1 : 0;
        }

        private void method_32(object sender, DuiMouseEventArgs e)
        {
            this.dskinGridList_0.PageIndex = 1;
        }

        private void method_33(object sender, DuiMouseEventArgs e)
        {
            this.dskinGridList_0.PageIndex = this.dskinGridList_0.PageCount;
        }

        private void method_34(object sender, DuiMouseEventArgs e)
        {
            try
            {
                int num = int.Parse(this.duiTextBox_0.Text);
                if (num > this.dskinGridList_0.PageCount)
                {
                    this.duiTextBox_0.Text = this.dskinGridList_0.PageCount.ToString();
                    this.dskinGridList_0.PageIndex = this.dskinGridList_0.PageCount;
                }
                else
                {
                    this.dskinGridList_0.PageIndex = num;
                }
            }
            catch
            {
                this.duiTextBox_0.Text = 1.ToString();
            }
        }

        private void method_35()
        {
            BlendColor color = new BlendColor();
            BlendColor color2 = new BlendColor();
            RotateTransform transform = new RotateTransform();
            BlendColor color3 = new BlendColor();
            BlendColor color4 = new BlendColor();
            RotateTransform transform2 = new RotateTransform();
            BlendColor color5 = new BlendColor();
            BlendColor color6 = new BlendColor();
            RotateTransform transform3 = new RotateTransform();
            this.BtnFistPage = new DuiButton();
            this.dskinLinearGradientBrush_1 = new DSkinLinearGradientBrush();
            this.dskinLinearGradientBrush_0 = new DSkinLinearGradientBrush();
            this.dskinLinearGradientBrush_2 = new DSkinLinearGradientBrush();
            this.BtnBackPage = new DuiButton();
            this.BtnNextPage = new DuiButton();
            this.BtnLastPage = new DuiButton();
            this.duiLabel_0 = new DuiLabel();
            this.BtnGoPage = new DuiButton();
            this.duiLabel_1 = new DuiLabel();
            this.duiTextBox_0 = new DuiTextBox();
            this.BtnFistPage.AdaptImage = true;
            this.BtnFistPage.BaseColor = Color.FromArgb(0xef, 0xef, 0xef);
            this.BtnFistPage.Borders.AllWidth = 1;
            this.BtnFistPage.ButtonBorderColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnFistPage.ButtonBorderWidth = 1;
            this.BtnFistPage.Cursor = Cursors.Hand;
            this.BtnFistPage.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.BtnFistPage.HoverBrush = this.dskinLinearGradientBrush_1;
            this.BtnFistPage.HoverColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnFistPage.IsPureColor = true;
            this.BtnFistPage.Location = new Point(0x143, 5);
            this.BtnFistPage.Name = "BtnFistPage";
            this.BtnFistPage.NormalBrush = this.dskinLinearGradientBrush_0;
            this.BtnFistPage.PressColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
            this.BtnFistPage.PressedBrush = this.dskinLinearGradientBrush_2;
            this.BtnFistPage.Radius = 0;
            this.BtnFistPage.Size = new Size(0x2c, 0x18);
            this.BtnFistPage.Text = "首页";
            this.BtnFistPage.TextAlign = ContentAlignment.MiddleCenter;
            this.BtnFistPage.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnFistPage.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_32);
            color.Color = Color.White;
            color.Position = 0f;
            color2.Color = Color.FromArgb(0xdb, 0xdb, 0xdb);
            color2.Position = 1f;
            this.dskinLinearGradientBrush_1.Colors.AddRange(new BlendColor[] { color, color2 });
            this.dskinLinearGradientBrush_1.GammaCorrection = false;
            transform.Angle = 90f;
            this.dskinLinearGradientBrush_1.TransformCollection.AddRange(new DSkin.DirectUI.Transform.Transform[] { transform });
            this.dskinLinearGradientBrush_1.WrapMode = WrapMode.Tile;
            color3.Color = Color.White;
            color3.Position = 0f;
            color4.Color = Color.FromArgb(0xef, 0xef, 0xef);
            color4.Position = 1f;
            this.dskinLinearGradientBrush_0.Colors.AddRange(new BlendColor[] { color3, color4 });
            this.dskinLinearGradientBrush_0.GammaCorrection = false;
            transform2.Angle = 90f;
            this.dskinLinearGradientBrush_0.TransformCollection.AddRange(new DSkin.DirectUI.Transform.Transform[] { transform2 });
            this.dskinLinearGradientBrush_0.WrapMode = WrapMode.Tile;
            color5.Color = Color.White;
            color5.Position = 0f;
            color6.Color = Color.FromArgb(0xb3, 0xb3, 0xb3);
            color6.Position = 1f;
            this.dskinLinearGradientBrush_2.Colors.AddRange(new BlendColor[] { color5, color6 });
            this.dskinLinearGradientBrush_2.GammaCorrection = false;
            transform3.Angle = 90f;
            this.dskinLinearGradientBrush_2.TransformCollection.AddRange(new DSkin.DirectUI.Transform.Transform[] { transform3 });
            this.dskinLinearGradientBrush_2.WrapMode = WrapMode.Tile;
            this.BtnBackPage.AdaptImage = true;
            this.BtnBackPage.BaseColor = Color.FromArgb(0xef, 0xef, 0xef);
            this.BtnBackPage.Borders.AllWidth = 1;
            this.BtnBackPage.ButtonBorderColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnBackPage.ButtonBorderWidth = 1;
            this.BtnBackPage.Cursor = Cursors.Hand;
            this.BtnBackPage.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.BtnBackPage.HoverBrush = this.dskinLinearGradientBrush_1;
            this.BtnBackPage.HoverColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnBackPage.IsPureColor = true;
            this.BtnBackPage.Location = new Point(0x173, 4);
            this.BtnBackPage.Name = "BtnBackPage";
            this.BtnBackPage.NormalBrush = this.dskinLinearGradientBrush_0;
            this.BtnBackPage.PressColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
            this.BtnBackPage.PressedBrush = this.dskinLinearGradientBrush_2;
            this.BtnBackPage.Radius = 0;
            this.BtnBackPage.Size = new Size(50, 0x18);
            this.BtnBackPage.Text = "上一页";
            this.BtnBackPage.TextAlign = ContentAlignment.MiddleCenter;
            this.BtnBackPage.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnBackPage.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_31);
            this.BtnNextPage.AdaptImage = true;
            this.BtnNextPage.BaseColor = Color.FromArgb(0xef, 0xef, 0xef);
            this.BtnNextPage.Borders.AllWidth = 1;
            this.BtnNextPage.ButtonBorderColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnNextPage.ButtonBorderWidth = 1;
            this.BtnNextPage.Cursor = Cursors.Hand;
            this.BtnNextPage.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.BtnNextPage.HoverBrush = this.dskinLinearGradientBrush_1;
            this.BtnNextPage.HoverColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnNextPage.IsPureColor = true;
            this.BtnNextPage.Location = new Point(0x1ad, 5);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.NormalBrush = this.dskinLinearGradientBrush_0;
            this.BtnNextPage.PressColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
            this.BtnNextPage.PressedBrush = this.dskinLinearGradientBrush_2;
            this.BtnNextPage.Radius = 0;
            this.BtnNextPage.Size = new Size(50, 0x18);
            this.BtnNextPage.Text = "下一页";
            this.BtnNextPage.TextAlign = ContentAlignment.MiddleCenter;
            this.BtnNextPage.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnNextPage.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_30);
            this.BtnLastPage.AdaptImage = true;
            this.BtnLastPage.BaseColor = Color.FromArgb(0xef, 0xef, 0xef);
            this.BtnLastPage.Borders.AllWidth = 1;
            this.BtnLastPage.ButtonBorderColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnLastPage.ButtonBorderWidth = 1;
            this.BtnLastPage.Cursor = Cursors.Hand;
            this.BtnLastPage.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.BtnLastPage.HoverBrush = this.dskinLinearGradientBrush_1;
            this.BtnLastPage.HoverColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnLastPage.IsPureColor = true;
            this.BtnLastPage.Location = new Point(0x1e5, 6);
            this.BtnLastPage.Name = "BtnLastPage";
            this.BtnLastPage.NormalBrush = this.dskinLinearGradientBrush_0;
            this.BtnLastPage.PressColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
            this.BtnLastPage.PressedBrush = this.dskinLinearGradientBrush_2;
            this.BtnLastPage.Radius = 0;
            this.BtnLastPage.Size = new Size(0x2c, 0x18);
            this.BtnLastPage.Text = "末页";
            this.BtnLastPage.TextAlign = ContentAlignment.MiddleCenter;
            this.BtnLastPage.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnLastPage.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_33);
            this.duiLabel_0.AutoSize = true;
            this.duiLabel_0.Borders.AllWidth = 1;
            this.duiLabel_0.DesignModeCanResize = false;
            this.duiLabel_0.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.duiLabel_0.Location = new Point(0, 7);
            this.duiLabel_0.Name = "duiLabel1";
            this.duiLabel_0.Size = new Size(0x62, 0x12);
            this.duiLabel_0.Text = "当前页：1/共1页";
            this.duiLabel_0.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnGoPage.AdaptImage = true;
            this.BtnGoPage.BaseColor = Color.FromArgb(0xef, 0xef, 0xef);
            this.BtnGoPage.Borders.AllWidth = 1;
            this.BtnGoPage.ButtonBorderColor = Color.FromArgb(30, 0, 0, 0);
            this.BtnGoPage.ButtonBorderWidth = 1;
            this.BtnGoPage.Cursor = Cursors.Hand;
            this.BtnGoPage.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.BtnGoPage.HoverBrush = this.dskinLinearGradientBrush_1;
            this.BtnGoPage.HoverColor = Color.FromArgb(0xdb, 0xdb, 0xdb);
            this.BtnGoPage.IsPureColor = true;
            this.BtnGoPage.Location = new Point(0x113, 5);
            this.BtnGoPage.Name = "BtnGoPage";
            this.BtnGoPage.NormalBrush = this.dskinLinearGradientBrush_0;
            this.BtnGoPage.PressColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
            this.BtnGoPage.PressedBrush = this.dskinLinearGradientBrush_2;
            this.BtnGoPage.Radius = 0;
            this.BtnGoPage.Size = new Size(0x2c, 0x18);
            this.BtnGoPage.Text = "跳转";
            this.BtnGoPage.TextAlign = ContentAlignment.MiddleCenter;
            this.BtnGoPage.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BtnGoPage.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_34);
            this.duiLabel_1.AutoSize = true;
            this.duiLabel_1.Borders.AllWidth = 1;
            this.duiLabel_1.DesignModeCanResize = false;
            this.duiLabel_1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.duiLabel_1.Location = new Point(0xad, 8);
            this.duiLabel_1.Name = "duiLabel2";
            this.duiLabel_1.Size = new Size(0x2a, 0x12);
            this.duiLabel_1.Text = "跳转至";
            this.duiTextBox_0.AutoSize = false;
            this.duiTextBox_0.Borders.AllColor = Color.Silver;
            this.duiTextBox_0.Borders.AllWidth = 1;
            this.duiTextBox_0.Borders.BottomColor = Color.Silver;
            this.duiTextBox_0.Borders.LeftColor = Color.Silver;
            this.duiTextBox_0.Borders.RightColor = Color.Silver;
            this.duiTextBox_0.Borders.TopColor = Color.Silver;
            this.duiTextBox_0.CaretIndex = 1;
            this.duiTextBox_0.Cursor = Cursors.IBeam;
            this.duiTextBox_0.Font = new Font("微软雅黑", 10f);
            this.duiTextBox_0.InnerScrollBar.AutoSize = false;
            this.duiTextBox_0.InnerScrollBar.BackColor = Color.FromArgb(200, 0xff, 0xff, 0xff);
            this.duiTextBox_0.InnerScrollBar.BitmapCache = true;
            this.duiTextBox_0.InnerScrollBar.Borders.AllWidth = 1;
            this.duiTextBox_0.InnerScrollBar.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.duiTextBox_0.InnerScrollBar.KeyChangeValue = false;
            this.duiTextBox_0.InnerScrollBar.Location = new Point(30, 0);
            this.duiTextBox_0.InnerScrollBar.Name = "";
            this.duiTextBox_0.InnerScrollBar.ScrollBarPartitionWidth = new Padding(5);
            this.duiTextBox_0.InnerScrollBar.Size = new Size(10, 20);
            this.duiTextBox_0.InnerScrollBar.SmallChange = 5;
            this.duiTextBox_0.Location = new Point(0xe0, 6);
            this.duiTextBox_0.Name = "duiTextBox1";
            this.duiTextBox_0.SelectionBackColor = Color.DodgerBlue;
            this.duiTextBox_0.Size = new Size(40, 20);
            this.duiTextBox_0.Text = "1";
            this.duiTextBox_0.TextRenderMode = TextRenderingHint.ClearTypeGridFit;
            this.BackColor = Color.Transparent;
            base.Borders.AllWidth = 1;
            this.Controls.AddRange(new DuiBaseControl[] { this.BtnFistPage, this.BtnBackPage, this.BtnNextPage, this.BtnLastPage, this.duiLabel_0, this.BtnGoPage, this.duiLabel_1, this.duiTextBox_0 });
            this.Size = new Size(0x223, 0x23);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.method_29();
            base.OnSizeChanged(e);
        }

        public void ShowPageinfo()
        {
            this.duiLabel_0.Text = string.Format("当前页：{0}/共{1}页；总数据量：{2}行", this.dskinGridList_0.PageIndex, this.dskinGridList_0.PageCount, this.dskinGridList_0.RowCount);
            this.method_29();
        }
    }
}

